// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Dec 26, 2017
// Time : 03:03 PM
// Description: Class for ConsumerPromotionEngine.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Promotion;

namespace CJ.Class
{
    public class ConsumerPromotionEngine
    {
        private int _nConsumerPromoID;
        private int _nSlabID;
        private int _nOfferID;
        private int _nOfferType;
        private int _nOfferProductID;
        private int _nOfferQty;
        private double _Discount;
        private string _sOfferDetail;
        private string _sOfferDesctiption;
        private string _sConsumerPromoName;
        private string _sConsumerPromoCode;
        private int _nBankDiscountID;
        private int _nDiscountID;
        private double _MaxDiscountAmount;
        private int _CardType;
        private int _IsEMIMandatory;

        public int IsEMIMandatory
        {
            get { return _IsEMIMandatory; }
            set { _IsEMIMandatory = value; }
        }

        public int CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }

        public double MaxDiscountAmount
        {
            get { return _MaxDiscountAmount; }
            set { _MaxDiscountAmount = value; }
        }

        public int DiscountID
        {
            get { return _nDiscountID; }
            set { _nDiscountID = value; }
        }

        public int BankDiscountID
        {
            get { return _nBankDiscountID; }
            set { _nBankDiscountID = value; }
        }

        public string ConsumerPromoName
        {
            get { return _sConsumerPromoName; }
            set { _sConsumerPromoName = value.Trim(); }
        }
        public string ConsumerPromoCode
        {
            get { return _sConsumerPromoCode; }
            set { _sConsumerPromoCode = value.Trim(); }
        }

        private string _sSlabName;
        public string SlabName
        {
            get { return _sSlabName; }
            set { _sSlabName = value.Trim(); }
        }
        private string _sOfferName;
        public string OfferName
        {
            get { return _sOfferName; }
            set { _sOfferName = value.Trim(); }
        }
        private string _sOfferProduct;
        public string OfferProduct
        {
            get { return _sOfferProduct; }
            set { _sOfferProduct = value.Trim(); }
        }
        private double _OfferAmount;
        public double OfferAmount
        {
            get { return _OfferAmount; }
            set { _OfferAmount = value; }
        }
        private double _OfferPercentage;
        public double OfferPercentage
        {
            get { return _OfferPercentage; }
            set { _OfferPercentage = value; }
        }
        public string OfferDetail
        {
            get { return _sOfferDetail; }
            set { _sOfferDetail = value.Trim(); }
        }
        public string OfferDesctiption
        {
            get { return _sOfferDesctiption; }
            set { _sOfferDesctiption = value.Trim(); }
        }

        // <summary>
        // Get set property for ConsumerPromoID
        // </summary>
        public int ConsumerPromoID
        {
            get { return _nConsumerPromoID; }
            set { _nConsumerPromoID = value; }
        }

        // <summary>
        // Get set property for SlabID
        // </summary>
        public int SlabID
        {
            get { return _nSlabID; }
            set { _nSlabID = value; }
        }

        // <summary>
        // Get set property for OfferID
        // </summary>
        public int OfferID
        {
            get { return _nOfferID; }
            set { _nOfferID = value; }
        }

        // <summary>
        // Get set property for OfferType
        // </summary>
        public int OfferType
        {
            get { return _nOfferType; }
            set { _nOfferType = value; }
        }

        // <summary>
        // Get set property for OfferProductID
        // </summary>
        public int OfferProductID
        {
            get { return _nOfferProductID; }
            set { _nOfferProductID = value; }
        }

        // <summary>
        // Get set property for OfferQty
        // </summary>
        public int OfferQty
        {
            get { return _nOfferQty; }
            set { _nOfferQty = value; }
        }

        // <summary>
        // Get set property for Discount
        // </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        private int _nWarrantyID;
        public int WarrantyID
        {
            get { return _nWarrantyID; }
            set { _nWarrantyID = value; }
        }
        private int _nSpecialDiscountID;
        private string _sApprovalNumber;
        private int _nChannelID;
        private int _nCustomerID;
        private int _nType;
        private int _nConsumerID;
        private int _nWarehouseID;
        private double _Amount;
        private int _nIsApplicableB2BDiscount;
        private int _nStatus;
        private int _nCreateUserID;

        private DateTime _dCreateDate;
        private int _nApproveUserID;
        private object _dtApproveDate;
        private string _sReason;
        private string _sApproveRemarks;
        private int _nEMITenureID;
        private int _nAuthorityID;
        private string _sEmployeeName;
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        private int _nEmployeeID;
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        private int _nIsApplicableOnOfferPrice;
        public int IsApplicableOnOfferPrice
        {
            get { return _nIsApplicableOnOfferPrice; }
            set { _nIsApplicableOnOfferPrice = value; }
        }

        public int AuthorityID
        {
            get { return _nAuthorityID; }
            set { _nAuthorityID = value; }
        }
        // <summary>
        // Get set property for SpecialDiscountID
        // </summary>
        public int SpecialDiscountID
        {
            get { return _nSpecialDiscountID; }
            set { _nSpecialDiscountID = value; }
        }

        // <summary>
        // Get set property for ApprovalNumber
        // </summary>
        public string ApprovalNumber
        {
            get { return _sApprovalNumber; }
            set { _sApprovalNumber = value.Trim(); }
        }

        // <summary>
        // Get set property for ChannelID
        // </summary>
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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
        // Get set property for ConsumerID
        // </summary>
        public int ConsumerID
        {
            get { return _nConsumerID; }
            set { _nConsumerID = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
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
        // Get set property for IsApplicableB2BDiscount
        // </summary>
        public int IsApplicableB2BDiscount
        {
            get { return _nIsApplicableB2BDiscount; }
            set { _nIsApplicableB2BDiscount = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
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
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
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
        // Get set property for ApproveDate
        // </summary>
        public object ApproveDate
        {
            get { return _dtApproveDate; }
            set { _dtApproveDate = value; }
        }

        // <summary>
        // Get set property for Reason
        // </summary>
        public string Reason
        {
            get { return _sReason; }
            set { _sReason = value.Trim(); }
        }

        // <summary>
        // Get set property for ApproveRemarks
        // </summary>
        public string ApproveRemarks
        {
            get { return _sApproveRemarks; }
            set { _sApproveRemarks = value.Trim(); }
        }
        public int EMITenureID
        {
            get { return _nEMITenureID; }
            set { _nEMITenureID = value; }
        }
        private int _nTerminal;
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }
        private int _nProductID;
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        private string _sDiscountType;

        public string DiscountType
        {
            get { return _sDiscountType; }
            set { _sDiscountType = value; }
        }

        public bool GetFreeEMITenureByProduct(int nEMITEnureID, int nProductID, DateTime dtSystemDate, int nFreeEMIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtSystemDate.ToString("dd-MMM-yyyy");
            if (nEMITEnureID > nFreeEMIID)
            {
                nFreeEMIID = 0;
            }
            int nCount = 0;
            try
            {
                //cmd.CommandText = "Select * From t_PromoDiscountASGBrandEMI where " +
                //                "AgID = (Select AgID from v_ProductDetails where ProductID = " + nProductID + ") and EMITEnureID = " + nEMITEnureID + " " +
                //                "and IsActive = " + (int)Dictionary.IsActive.Active + " and Status = " + (int)Dictionary.BankDiscountStatus.Approved + " and EffectiveDate<='" + dtSystemDate + "'";


                cmd.CommandText = "Select  distinct * From  " +
                                "(  " +
                                "Select EMITenureID From t_PromoDiscountASGBrandEMI where  " +
                                "AgID = (Select AgID from v_ProductDetails where ProductID = " + nProductID + ") and EMITEnureID = " + nEMITEnureID + "  " +
                                "and IsActive = " + (int)Dictionary.IsActive.Active + " and Status = " + (int)Dictionary.BankDiscountStatus.Approved + " and DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate))<= '" + sDate + "'  " +
                                "Union All  " +
                                "Select EMITenureID From t_EMITenure where EMITenureID<= " + nFreeEMIID + "  " +
                                ") Main";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public double GetExtendedEMICharge(int nExtendenEMI, int nProductID, int nPromoFreeEMI)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _ExtendedCharge = 0;
            try
            {
                if (nPromoFreeEMI == 0)
                {
                    cmd.CommandText = "Select isnull(cast (sum(ExtendenEMI)-sum(FreeEMI) as float),0) as  ExtendedCharge  " +
                                    " From  " +
                                    " (  " +
                                    " Select ChargePercent ExtendenEMI, 0 as FreeEMI  " +
                                    " From[dbo].[t_EMIExtendedCharge] where EMITenureID = " + nExtendenEMI + "  " +
                                    " union all  " +
                                    " Select 0 ExtendenEMI, ChargePercent as FreeEMI  " +
                                    " From[dbo].[t_EMIExtendedCharge] where  " +
                                    " EMITenureID = (  " +
                                    " Select  max(EMITenureID) EMITenureID  " +
                                    " From t_PromoDiscountASGBrandEMI where  " +
                                    " AGID = (select AGID From v_ProductDetails where ProductID = " + nProductID + ")  " +
                                    " )  " +
                                    " ) Main";
                }
                else
                {
                    cmd.CommandText = "Select isnull(cast (sum(ExtendenEMI)-sum(FreeEMI) as float),0) as  ExtendedCharge   " +
                                    " from (   " +
                                    " Select ChargePercent ExtendenEMI, 0 as FreeEMI   " +
                                    " From[dbo].[t_EMIExtendedCharge]   " +
                                    " where EMITenureID = " + nExtendenEMI + "   " +
                                    " union all   " +
                                    " Select 0 ExtendenEMI, ChargePercent as FreeEMI  From   " +
                                    " [dbo].[t_EMIExtendedCharge]   " +
                                    " where  EMITenureID = " + nPromoFreeEMI + "   " +
                                    " ) Main";
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ExtendedCharge = Convert.ToDouble(reader["ExtendedCharge"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ExtendedCharge;
        }

        public double GetExtendedEMIChargeForInvoice(int nSelectedEMITenureID, string sOperationDate, int nProductID, int nFreeEMITenureID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _ExtendedCharge = 0;
            try
            {
                cmd.CommandText = "Select case when Tenure-FreeTenure<0 then 0 else ChargePercent-FreeEMICharge end as ExtendedCharge From " +
                                "( " +
                                "Select max(Tenure) Tenure, max(ChargePercent) ChargePercent, " +
                                "max(FreeTenure) FreeTenure, max(FreeEMICharge) FreeEMICharge " +
                                "From " +
                                "( " +
                                "Select Tenure, ChargePercent, 0 as FreeTenure, 0 FreeEMICharge " +
                                "From t_EMITenure a, t_EMIExtendedCharge b " +
                                "where  a.EMITenureID = b.EMITenureID and a.EMITenureID = " + nSelectedEMITenureID + " " + ///Selected EMI 
                                "Union All " +
                                "Select 0 Tenure, 0 ChargePercent, a.Tenure FreeTenure, " +
                                "ChargePercent as FreeEMICharge From " +
                                "( " +
                                "Select max(Tenure) Tenure From " +
                                "( " +
                                "Select max(Tenure) Tenure From t_PromoDiscountASGBrandEMI a, t_EMITenure b " +
                                "where '" + sOperationDate + "' between EffectiveDate and '" + sOperationDate + "' " +
                                "and IsActive = " + (int)Dictionary.IsActive.Active + " and a.Status = " + (int)Dictionary.ASGWaiseFreeEMIStatus.Approved + " and " +
                                "AgID = (Select AgID from v_ProductDetails where ProductID = " + nProductID + ") " +
                                "and a.EMITenureID = b.EMITenureID and BrandID = (Select BrandID from v_ProductDetails where ProductID = " + nProductID + ") " +
                                "Union All " +
                                "Select Tenure From t_EMITenure where EMITenureID = " + nFreeEMITenureID + "  " + ///FreeEMITenureID
                                ") x " +
                                ") a, t_EMITenure b, t_EMIExtendedCharge c " +
                                "where a.Tenure = b.Tenure and b.EMITenureID = c.EMITenureID " +
                                ") x " +
                                ") Main";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ExtendedCharge = Convert.ToDouble(reader["ExtendedCharge"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ExtendedCharge;
        }

        public double GetExtendedEMIChargeForInvoiceNew(int nSelectedEMITenureID, string sOperationDate, int nProductID, int nFreeEMITenureID, int nWHID, int nSalesType, string sSDApprovalNumber, int nCustomerID, int nConsumerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _ExtendedCharge = 0;

            string sSql = "Select a.EMITenureID From t_PromoDiscountSpecial a, t_EMITenure b " +
                        "where a.EMITenureID = b.EMITenureID and DiscountType = 'Free EMI' " +
                        "and WarehouseID = " + nWHID + " and a.Status = 3 and SalesType = " + nSalesType + " and ProductID = " + nProductID + " " +
                        "and ApprovalNumber = '" + sSDApprovalNumber + "' and CustomerID = " + nCustomerID + "";
            if (nSalesType == (int)Dictionary.SalesType.Retail || nSalesType == (int)Dictionary.SalesType.B2C || nSalesType == (int)Dictionary.SalesType.HPA || nSalesType == (int)Dictionary.SalesType.eStore)
            {
                sSql = sSql + "  and ConsumerID = " + nConsumerID + "";
            }

            if (nSalesType == (int)Dictionary.SalesType.Retail || nSalesType == (int)Dictionary.SalesType.B2C || nSalesType == (int)Dictionary.SalesType.HPA || nSalesType == (int)Dictionary.SalesType.eStore)
            {
                sSql = sSql + "  and ConsumerID = " + nConsumerID + "";
            }

            try
            {
                cmd.CommandText = "Select case when Tenure-FreeTenure<0 then 0 else ChargePercent-FreeEMICharge end as ExtendedCharge From " +
                                "( " +
                                "Select max(Tenure) Tenure, max(ChargePercent) ChargePercent, " +
                                "max(FreeTenure) FreeTenure, max(FreeEMICharge) FreeEMICharge " +
                                "From " +
                                "( " +
                                "Select Tenure, ChargePercent, 0 as FreeTenure, 0 FreeEMICharge " +
                                "From t_EMITenure a, t_EMIExtendedCharge b " +
                                "where  a.EMITenureID = b.EMITenureID and a.EMITenureID = " + nSelectedEMITenureID + " " + ///Selected EMI 
                                "Union All " +
                                "Select 0 Tenure, 0 ChargePercent, a.Tenure FreeTenure, " +
                                "ChargePercent as FreeEMICharge From " +
                                "( " +
                                "Select max(Tenure) Tenure From " +
                                "( " +
                                "Select max(Tenure) Tenure From t_PromoDiscountASGBrandEMI a, t_EMITenure b " +
                                "where '" + sOperationDate + "' between EffectiveDate and '" + sOperationDate + "' " +
                                "and IsActive = " + (int)Dictionary.IsActive.Active + " and a.Status = " + (int)Dictionary.ASGWaiseFreeEMIStatus.Approved + " and " +
                                "AgID = (Select AgID from v_ProductDetails where ProductID = " + nProductID + ") " +
                                "and a.EMITenureID = b.EMITenureID and BrandID = (Select BrandID from v_ProductDetails where ProductID = " + nProductID + ") " +
                                "Union All " +
                                "Select Tenure From t_EMITenure where EMITenureID in ( " + nFreeEMITenureID + ",(" + sSql + ") ) " + ///FreeEMITenureID
                                ") x " +
                                ") a, t_EMITenure b, t_EMIExtendedCharge c " +
                                "where a.Tenure = b.Tenure and b.EMITenureID = c.EMITenureID " +
                           
                                ") x " +
                                ") Main";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ExtendedCharge = Convert.ToDouble(reader["ExtendedCharge"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ExtendedCharge;
        }

        public double GetExtendedEMIChargeForInvoiceFI(int nSelectedEMITenureID, string sOperationDate, int nProductID, int nFreeEMITenureID, int nWHID, int nSalesType, string sSDApprovalNumber, int nCustomerID, int nConsumerID, int nBankID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _ExtendedCharge = 0;

            string sSql = "Select a.EMITenureID From t_PromoDiscountSpecial a, t_EMITenure b " +
                        "where a.EMITenureID = b.EMITenureID and DiscountType = 'Free EMI' " +
                        "and WarehouseID = " + nWHID + " and a.Status = 3 and SalesType = " + nSalesType + " and ProductID = " + nProductID + " " +
                        "and ApprovalNumber = '" + sSDApprovalNumber + "' and CustomerID = " + nCustomerID + "";
            if (nSalesType == (int)Dictionary.SalesType.Retail || nSalesType == (int)Dictionary.SalesType.B2C || nSalesType == (int)Dictionary.SalesType.HPA || nSalesType == (int)Dictionary.SalesType.eStore)
            {
                sSql = sSql + "  and ConsumerID = " + nConsumerID + "";
            }

            if (nSalesType == (int)Dictionary.SalesType.Retail || nSalesType == (int)Dictionary.SalesType.B2C || nSalesType == (int)Dictionary.SalesType.HPA || nSalesType == (int)Dictionary.SalesType.eStore)
            {
                sSql = sSql + "  and ConsumerID = " + nConsumerID + "";
            }

            try
            {
                cmd.CommandText = "Select case when Tenure-FreeTenure<0 then 0 else ChargePercent-FreeEMICharge end as ExtendedCharge From " +
                                "( " +
                                "Select max(Tenure) Tenure, max(ChargePercent) ChargePercent, " +
                                "max(FreeTenure) FreeTenure, max(FreeEMICharge) FreeEMICharge " +
                                "From " +
                                "( " +
                                "Select Tenure, ChargePercent, 0 as FreeTenure, 0 FreeEMICharge " +
                                "From t_EMITenure a, t_EMIExtendedCharge b " +
                                "where  a.EMITenureID = b.EMITenureID and a.EMITenureID = " + nSelectedEMITenureID + " and b.BankID=" + nBankID + " " +

                                ") x " +
                                ") Main";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ExtendedCharge = Convert.ToDouble(reader["ExtendedCharge"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ExtendedCharge;
        }

        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    double _ExtendedCharge = 0;

        //    string sSql = "Select a.EMITenureID From t_PromoDiscountSpecial a, t_EMITenure b " +
        //                "where a.EMITenureID = b.EMITenureID and DiscountType = 'Free EMI' " +
        //                "and WarehouseID = " + nWHID + " and a.Status = 3 and SalesType = " + nSalesType + " and ProductID = " + nProductID + " " +
        //                "and ApprovalNumber = '" + sSDApprovalNumber + "' and CustomerID = " + nCustomerID + "";
        //    if (nSalesType == (int)Dictionary.SalesType.Retail || nSalesType == (int)Dictionary.SalesType.B2C || nSalesType == (int)Dictionary.SalesType.HPA || nSalesType == (int)Dictionary.SalesType.eStore)
        //    {
        //        sSql = sSql + "  and ConsumerID = " + nConsumerID + "";
        //    }


        //    try
        //    {
        //        cmd.CommandText = "Select case when Tenure-FreeTenure<0 then 0 else ChargePercent-FreeEMICharge end as ExtendedCharge From " +
        //                        "( " +
        //                        "Select max(Tenure) Tenure, max(ChargePercent) ChargePercent, " +
        //                        "max(FreeTenure) FreeTenure, max(FreeEMICharge) FreeEMICharge " +
        //                        "From " +
        //                        "( " +
        //                        "Select Tenure, ChargePercent, 0 as FreeTenure, 0 FreeEMICharge " +
        //                        "From t_EMITenure a, t_EMIExtendedCharge b " +
        //                        "where  a.EMITenureID = b.EMITenureID and a.EMITenureID = " + nSelectedEMITenureID + " " + ///Selected EMI 
        //                        "and b.BankID=" + nBankID + "  " +
        //                        "Union All " +
        //                        "Select 0 Tenure, 0 ChargePercent, a.Tenure FreeTenure, " +
        //                        "ChargePercent as FreeEMICharge From " +
        //                        "( " +
        //                        "Select max(Tenure) Tenure From " +
        //                        "( " +
        //                        "Select max(Tenure) Tenure From t_PromoDiscountASGBrandEMI a, t_EMITenure b " +
        //                        "where '" + sOperationDate + "' between EffectiveDate and '" + sOperationDate + "' " +
        //                        "and IsActive = " + (int)Dictionary.IsActive.Active + " and a.Status = " + (int)Dictionary.ASGWaiseFreeEMIStatus.Approved + " and " +
        //                        "AgID = (Select AgID from v_ProductDetails where ProductID = " + nProductID + ") " +
        //                        "and a.EMITenureID = b.EMITenureID and BrandID = (Select BrandID from v_ProductDetails where ProductID = " + nProductID + ") " +
        //                        "Union All " +
        //                        "Select Tenure From t_EMITenure where EMITenureID in ( " + nFreeEMITenureID + ",(" + sSql + ") ) " + ///FreeEMITenureID
        //                        ") x " +
        //                        ") a, t_EMITenure b, t_EMIExtendedCharge c " +
        //                        "where a.Tenure = b.Tenure and b.EMITenureID = c.EMITenureID and c.BankID=" + nBankID + " " +
        //                        ") x " +
        //                        ") Main";

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            _ExtendedCharge = Convert.ToDouble(reader["ExtendedCharge"].ToString());

        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return _ExtendedCharge;
        //}

        public int GetExtendedEMIChargeID(int nExtendenEMI)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _ExtendedChargeID = 0;
            try
            {
                cmd.CommandText = "Select ID From[dbo].[t_EMIExtendedCharge] where EMITenureID = " + nExtendenEMI + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ExtendedChargeID = Convert.ToInt32(reader["ID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ExtendedChargeID;
        }

        public int GetExtendedEMIChargeIDFI(int nExtendenEMI, int nBankID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _ExtendedChargeID = 0;
            try
            {
                cmd.CommandText = "Select ID From[dbo].[t_EMIExtendedCharge] where EMITenureID = " + nExtendenEMI + " and BankID=" + nBankID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ExtendedChargeID = Convert.ToInt32(reader["ID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ExtendedChargeID;
        }

        public double GetBankDiscount(int nBankID, int nProductID, DateTime dtOperationDate, int nCardType)
        {


            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _DiscountPercent = 0;
            try
            {
                cmd.CommandText =
                    "Select BankDiscountID,DiscountPercent,isnull(MaxDiscountAmount,0) MaxDiscountAmount,isnull(CardType,0) CardType,isnull(b.IsEMIMandatory,0) IsEMIMandatory "+ 
                    "From v_ProductDetails a,t_PromoDiscountBank b  " +
                    "where a.AGID = b.AGID and a.BrandID = b.BrandID  " +
                    "and ProductID = " + nProductID + " and BankID = " + nBankID + " and b.IsActive = 1  " +
                    "and Status = " + (int)Dictionary.BankDiscountStatus.Approved + " and '" + sDate +
                    "' between FromDate and Todate and isnull(IsBankDiscount,1)=1 and b.BankID<>-1 and isnull(CardType,0)=" +
                    nCardType + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nBankDiscountID = Convert.ToInt32(reader["BankDiscountID"].ToString());
                    _DiscountPercent = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    _MaxDiscountAmount = Convert.ToDouble(reader["MaxDiscountAmount"].ToString());
                    _CardType = Convert.ToInt32(reader["CardType"].ToString());
                    _IsEMIMandatory = Convert.ToInt32(reader["IsEMIMandatory"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _DiscountPercent;
        }

        public double GetPaymentModeWiseDiscount(int nPaymentModeID, int nProductID, DateTime dtOperationDate)
        {

            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _DiscountPercent = 0;
            try
            {
                cmd.CommandText = "Select BankDiscountID,DiscountPercent,isnull(MaxDiscountAmount,0) MaxDiscountAmount From v_ProductDetails a,t_PromoDiscountBank b  " +
                                "where a.AGID = b.AGID and a.BrandID = b.BrandID  " +
                                "and ProductID = " + nProductID + " and IsBankDiscount=" + (int)Dictionary.YesOrNoStatus.NO + " and PaymentModeID=" + nPaymentModeID + "and b.IsActive = 1  " +
                                "and Status = " + (int)Dictionary.BankDiscountStatus.Approved + " and '" + sDate + "' between FromDate and Todate ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nBankDiscountID = Convert.ToInt32(reader["BankDiscountID"].ToString());
                    _DiscountPercent = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    _MaxDiscountAmount = Convert.ToDouble(reader["MaxDiscountAmount"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _DiscountPercent;
        }

        public double GetSpecialDiscount(int nWHID, int nCustomerID, string sConsumerCode, string sApprovalNumber, int nUIType, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();//_nProductID
            double _Amount = 0;
            try
            {
                if (nUIType == (int)Dictionary.SalesType.Retail || nUIType == (int)Dictionary.SalesType.B2C || nUIType == (int)Dictionary.SalesType.HPA || nUIType == (int)Dictionary.SalesType.eStore)
                {
                    cmd.CommandText = "Select * From t_PromoDiscountSpecial a,t_RetailConsumer b, t_Product c where a.ConsumerID = b.ConsumerID and a.ProductID=c.ProductID and WarehouseID = " + nWHID + "  " + "and a.ProductID = " + nProductID +
                                      "and a.CustomerID = " + nCustomerID + " and ConsumerCode = '" + sConsumerCode + "' and ApprovalNumber = '" + sApprovalNumber + "' and Status = " + (int)Dictionary.SpacialDiscountStatus.Approved + " and a.SalesType in (1,2,4,6) and DiscountType='Amount'";
                }
                else
                {
                    cmd.CommandText = "Select * From t_PromoDiscountSpecial a,t_Product b where a.ProductID=b.ProductID and WarehouseID=" + nWHID + "  " + "and a.ProductID = " + nProductID +
                                      "and CustomerID=" + nCustomerID + " and ApprovalNumber='" + sApprovalNumber + "' and Status = " + (int)Dictionary.SpacialDiscountStatus.Approved + " and SalesType in (" + (int)Dictionary.SalesType.B2B + "," + (int)Dictionary.SalesType.Dealer + ") and DiscountType='Amount'";
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nDiscountID = Convert.ToInt32(reader["SpecialDiscountID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;
        }

        public double GetSpecialDiscountRT(int nWHID, int nCustomerID, string sConsumerCode, string sApprovalNumber, int nUIType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Amount = 0;
            try
            {
                if (nUIType == (int)Dictionary.SalesType.Retail || nUIType == (int)Dictionary.SalesType.B2C || nUIType == (int)Dictionary.SalesType.HPA || nUIType == (int)Dictionary.SalesType.eStore)
                {
                    cmd.CommandText = "Select * From t_PromoDiscountSpecial a,t_RetailConsumer b where a.ConsumerID = b.ConsumerID and a.WarehouseID = " + nWHID + "  " +
                                      "and a.WarehouseID=b.WarehouseID and a.CustomerID = " + nCustomerID + " and ConsumerCode = '" + sConsumerCode + "' and ApprovalNumber = '" + sApprovalNumber + "' and Status = " + (int)Dictionary.SpacialDiscountStatus.Approved + " and a.SalesType in (1,2,4,6) and DiscountType='Amount'";
                }
                else
                {
                    cmd.CommandText = "Select * From t_PromoDiscountSpecial where WarehouseID=" + nWHID + "  " +
                                      "and CustomerID=" + nCustomerID + " and ApprovalNumber='" + sApprovalNumber + "' and Status = " + (int)Dictionary.SpacialDiscountStatus.Approved + " and SalesType in (" + (int)Dictionary.SalesType.B2B + "," + (int)Dictionary.SalesType.Dealer + ") and DiscountType='Amount'";
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nDiscountID = Convert.ToInt32(reader["SpecialDiscountID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;
        }
        public int GetSpecialDiscountID(string sApprovalNumber)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nSpecialDiscountID = 0;
            try
            {

                cmd.CommandText = "Select * From t_PromoDiscountSpecial where ApprovalNumber='" + sApprovalNumber + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nSpecialDiscountID = Convert.ToInt32(reader["SpecialDiscountID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nSpecialDiscountID;
        }
        public void AddSpacialDiscount(string sShortCode)
        {
            int nMaxSpecialDiscountID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SpecialDiscountID]) FROM t_PromoDiscountSpecial";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSpecialDiscountID = 1;
                }
                else
                {
                    nMaxSpecialDiscountID = Convert.ToInt32(maxID) + 1;
                }
                _nSpecialDiscountID = nMaxSpecialDiscountID;
                _sApprovalNumber = "SD-" + sShortCode + "-" + _nSpecialDiscountID.ToString("00000") + "";

                sSql = "INSERT INTO t_PromoDiscountSpecial (SpecialDiscountID, ApprovalNumber, SalesType, CustomerID, Type, ConsumerID, WarehouseID, Amount, IsApplicableB2BDiscount, Status, CreateUserID, CreateDate, ApproveUserID, ApproveDate, Reason, ApproveRemarks, AuthorityID, DiscountType, ProductID, EMITenureID, Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
                cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);
                cmd.Parameters.AddWithValue("SalesType", _nChannelID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("IsApplicableB2BDiscount", _nIsApplicableB2BDiscount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", null);
                cmd.Parameters.AddWithValue("ApproveDate", null);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("ApproveRemarks", null);
                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);
                cmd.Parameters.AddWithValue("DiscountType", _sDiscountType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                if (_nEMITenureID != -1)
                    cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                else cmd.Parameters.AddWithValue("EMITenureID", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddSpacialDiscountRT(string sShortCode)
        {
            int nMaxSpecialDiscountID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SpecialDiscountID]) FROM t_PromoDiscountSpecial where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSpecialDiscountID = 1;
                }
                else
                {
                    nMaxSpecialDiscountID = Convert.ToInt32(maxID) + 1;
                }
                _nSpecialDiscountID = nMaxSpecialDiscountID;
                _sApprovalNumber = "SD-" + sShortCode + "-" + _nSpecialDiscountID.ToString("00000") + "";

                sSql = "INSERT INTO t_PromoDiscountSpecial (SpecialDiscountID, ApprovalNumber, SalesType, CustomerID, Type, ConsumerID, WarehouseID, Amount, IsApplicableB2BDiscount, Status, CreateUserID, CreateDate, ApproveUserID, ApproveDate, Reason, ApproveRemarks, AuthorityID, DiscountType, ProductID, EMITenureID, Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
                cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);
                cmd.Parameters.AddWithValue("SalesType", _nChannelID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_nConsumerID == -1)
                {
                    cmd.Parameters.AddWithValue("ConsumerID", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                }
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("IsApplicableB2BDiscount", _nIsApplicableB2BDiscount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", null);
                cmd.Parameters.AddWithValue("ApproveDate", null);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("ApproveRemarks", null);
                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);
                cmd.Parameters.AddWithValue("DiscountType", _sDiscountType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                if (_nEMITenureID != -1)
                    cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                else cmd.Parameters.AddWithValue("EMITenureID", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateSpacialDiscount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_PromoDiscountSpecial Set Status=? Where ApprovalNumber = ? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckSpacialDiscountHOEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * From t_PromoDiscountSpecial where SpecialDiscountID = ? and ApprovalNumber = ? and WarehouseID = ? ";
            cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
            cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);
            cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;

        }
        public void AddSpacialDiscountHO()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_PromoDiscountSpecial (SpecialDiscountID, ApprovalNumber, SalesType, CustomerID, Type, ConsumerID, WarehouseID, Amount, IsApplicableB2BDiscount, Status, CreateUserID, CreateDate, ApproveUserID, ApproveDate, Reason, ApproveRemarks,AuthorityID,DiscountType, ProductID, EMITenureID, Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
                cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);
                cmd.Parameters.AddWithValue("SalesType", _nChannelID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_nConsumerID != 0)
                {
                    cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ConsumerID", null);
                }
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("IsApplicableB2BDiscount", _nIsApplicableB2BDiscount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                if (_dtApproveDate != null)
                {
                    cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                }
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("ApproveRemarks", _sApproveRemarks);
                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);

                cmd.Parameters.AddWithValue("DiscountType", _sDiscountType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                if (_nEMITenureID != -1)
                    cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                else cmd.Parameters.AddWithValue("EMITenureID", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetB2BDiscount(int nCustomerID, double nSalesPrice, DateTime dtOperationDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _B2BDiscount = 0;

            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            try
            {
                cmd.CommandText = "Select ROUND(" + nSalesPrice + "*DiscountPercent/100,0) as B2BDiscount From t_PromoDiscountB2B where CustomerID =" + nCustomerID + " and Status = " + (int)Dictionary.B2BDiscountStatus.Approved + " and IsActive = " + (int)Dictionary.IsActive.Active + " and DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate))<= '" + sDate + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _B2BDiscount = Convert.ToDouble(reader["B2BDiscount"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _B2BDiscount;
        }

        public double GetB2BDiscountRT(int nCustomerID, double nSalesPrice, DateTime dtOperationDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _B2BDiscount = 0;

            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            try
            {
                cmd.CommandText = "Select ROUND(" + nSalesPrice + "*DiscountPercent/100,0) as B2BDiscount From t_PromoDiscountB2B where CustomerID =" + nCustomerID + " and Status = " + (int)Dictionary.B2BDiscountStatus.Approved + " and IsActive = " + (int)Dictionary.IsActive.Active + " and DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate))<= '" + sDate + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _B2BDiscount = Convert.ToDouble(reader["B2BDiscount"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _B2BDiscount;
        }

        public bool GetScretchCardOfferCustomerType(DateTime dtOperationDate, int nWarehouseID, int nProductID, int nSalesType, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");
            string sCustomerType = "";
            int nCustType = 0;
            try

            {
                cmd.CommandText = "Select isnull(CustType,5) CustType,OfferType From [dbo].[t_ScratchCardOffer] a,[t_ScratchCardOfferProductFor] b,[t_ScratchCardOfferWarehouse] c, " +
                                "[t_ScratchCardOfferSalesType] d where a.ScratchCardOfferID=b.ScratchCardOfferID and a.ScratchCardOfferID=c.ScratchCardOfferID " +
                                "and a.ScratchCardOfferID=d.ScratchCardOfferID and WarehouseID=" + nWarehouseID + " and FromDate <='" + dtOperationDate + "' and Todate>='" + dtOperationDate + "' " +
                                "and d.SalesType=" + nSalesType + " and ProductID=" + nProductID + " and a.IsActive=" + (int)Dictionary.IsActive.Active + " and a.Status=" + (int)Dictionary.SalesPromStatus.Approved + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nOfferType = Convert.ToInt32(reader["OfferType"].ToString());
                    if (sCustomerType == "")
                    {
                        sCustomerType = (reader["CustType"].ToString());
                    }
                    else
                    {
                        sCustomerType = sCustomerType + ',' + (reader["CustType"].ToString());
                    }

                }
                Customer oCustomer = new Customer();
                oCustomer.GetCustomerTypeByID(nCustomerID);
                nCustType = oCustomer.CustTypeID;
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (sCustomerType.Contains(nCustType.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetScretchCardOfferCustomerTypeRT(DateTime dtOperationDate, int nWarehouseID, int nProductID, int nSalesType, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");
            string sCustomerType = "";
            int nCustType = 0;
            try

            {
                cmd.CommandText = "Select isnull(CustType,5) CustType,OfferType From [dbo].[t_ScratchCardOffer] a,[t_ScratchCardOfferProductFor] b,[t_ScratchCardOfferWarehouse] c, " +
                                "[t_ScratchCardOfferSalesType] d where a.ScratchCardOfferID=b.ScratchCardOfferID and a.ScratchCardOfferID=c.ScratchCardOfferID " +
                                "and a.ScratchCardOfferID=d.ScratchCardOfferID and WarehouseID=" + nWarehouseID + " and FromDate <='" + dtOperationDate + "' and Todate>='" + dtOperationDate + "' " +
                                "and d.SalesType=" + nSalesType + " and ProductID=" + nProductID + " and a.IsActive=" + (int)Dictionary.IsActive.Active + " and a.Status=" + (int)Dictionary.SalesPromStatus.Approved + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nOfferType = Convert.ToInt32(reader["OfferType"].ToString());
                    if (sCustomerType == "")
                    {
                        sCustomerType = (reader["CustType"].ToString());
                    }
                    else
                    {
                        sCustomerType = sCustomerType + ',' + (reader["CustType"].ToString());
                    }

                }
                Customer oCustomer = new Customer();
                oCustomer.GetCustomerTypeByID(nCustomerID);
                nCustType = oCustomer.CustTypeID;
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (sCustomerType.Contains(nCustType.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool GetExchangeOfferPromo(DateTime dtOperationDate, int nWarehouseId, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");
            int nCount = 0;
            try

            {
                //cmd.CommandText = "Select * From t_PromoExchangeOffers  " +
                //                  "where '" + dtOperationDate + "' between FromDate and ToDate  " +
                //                  "and IsActive=1 and Status=2 and OfferId in (  " +
                //                  "Select OfferId From t_PromoExchangeOfferDetails where DataType=1 and DataId=(Select ProductGroupID from t_Product where ProductID=" +
                //                  nProductID + ")  " +
                //                  "Union All  " +
                //                  "Select OfferId From t_PromoExchangeOfferDetails where DataType=2 and DataId=" +
                //                  nWarehouseId + "  " +
                //                  "Union All  " +
                //                  "Select OfferId From t_PromoExchangeOfferDetails where DataType=3 and DataId=(  " +
                //                  "Select b.ParentID from t_Product a,t_Brand b where ProductID=" + nProductID +
                //                  " and a.BrandID=b.BrandID))";


                cmd.CommandText = "Select * From  " +
                                "(  " +
                                "Select * From t_PromoExchangeOfferDetails  " +
                                "where DataType=3 and DataId=(Select b.ParentID from t_Product a,t_Brand b   " +
                                "where ProductID=" + nProductID + " and a.BrandID=b.BrandID)  " +
                                ") a  " +
                                "Inner join (  " +
                                "Select OfferId From t_PromoExchangeOfferDetails   " +
                                "where DataType=1 and DataId=(Select ProductGroupID from t_Product where ProductID=" + nProductID + ")  " +
                                ")  b on a.OfferId=b.OfferId  " +
                                "Inner join   " +
                                "(  " +
                                "Select OfferId From t_PromoExchangeOfferDetails  " +
                                "where DataType=2 and DataId=" + nWarehouseId + "   " +
                                ") c on a.OfferId=c.OfferId  " +
                                "inner join t_PromoExchangeOffers d on a.OfferId=d.OfferId  " +
                                "where '" + sDate + "' between FromDate and ToDate  and IsActive=1 and Status=2";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetExchangeOfferPromoRT(DateTime dtOperationDate, int nWarehouseId, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");
            int nCount = 0;
            try

            {
                //cmd.CommandText = "Select * From t_PromoExchangeOffers  " +
                //                  "where '" + dtOperationDate + "' between FromDate and ToDate  " +
                //                  "and IsActive=1 and Status=2 and OfferId in (  " +
                //                  "Select OfferId From t_PromoExchangeOfferDetails where DataType=1 and DataId=(Select ProductGroupID from t_Product where ProductID=" +
                //                  nProductID + ")  " +
                //                  "Union All  " +
                //                  "Select OfferId From t_PromoExchangeOfferDetails where DataType=2 and DataId=" +
                //                  nWarehouseId + "  " +
                //                  "Union All  " +
                //                  "Select OfferId From t_PromoExchangeOfferDetails where DataType=3 and DataId=(  " +
                //                  "Select b.ParentID from t_Product a,t_Brand b where ProductID=" + nProductID +
                //                  " and a.BrandID=b.BrandID))";


                cmd.CommandText = "Select * From  " +
                                "(  " +
                                "Select * From t_PromoExchangeOfferDetails  " +
                                "where DataType=3 and DataId=(Select b.ParentID from t_Product a,t_Brand b   " +
                                "where ProductID=" + nProductID + " and a.BrandID=b.BrandID)  " +
                                ") a  " +
                                "Inner join (  " +
                                "Select OfferId From t_PromoExchangeOfferDetails   " +
                                "where DataType=1 and DataId=(Select ProductGroupID from t_Product where ProductID=" + nProductID + ")  " +
                                ")  b on a.OfferId=b.OfferId  " +
                                "Inner join   " +
                                "(  " +
                                "Select OfferId From t_PromoExchangeOfferDetails  " +
                                "where DataType=2 and DataId=" + nWarehouseId + "   " +
                                ") c on a.OfferId=c.OfferId  " +
                                "inner join t_PromoExchangeOffers d on a.OfferId=d.OfferId  " +
                                "where '" + sDate + "' between FromDate and ToDate  and IsActive=1 and Status=2";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetWarrantyPromo(DateTime dtOperationDate, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");
            string sExtendedWarranty = "";
            try

            {

                cmd.CommandText = "Select isnull(ExtendedWarranty,'') ExtendedWarranty,isnull(WarrantyID,-1) WarrantyID From t_PromoWarranty where WarrantyID=( " +
                                "Select isnull(max(a.WarrantyID),-1) WarrantyID From t_PromoWarranty a,t_PromoWarrantyDetail b " +
                                "where a.WarrantyID=b.WarrantyID and ProductID=" + nProductID + " and IsActive=" + (int)Dictionary.IsActive.Active + " and Status=" + (int)Dictionary.PromoWarrantyStatus.Approved + " " +
                                "and '" + sDate + "' between fromdate and todate)";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sExtendedWarranty = (reader["ExtendedWarranty"].ToString());
                    _nWarrantyID = Convert.ToInt32(reader["WarrantyID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return sExtendedWarranty;

        }

        public int GetB2BDiscountID(int nCustomerID, DateTime dtOperationDate)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _B2BDiscountID = 0;
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            try
            {
                cmd.CommandText = "Select B2BDiscountID From t_PromoDiscountB2B where CustomerID =" + nCustomerID + " and Status = " + (int)Dictionary.B2BDiscountStatus.Approved + " and IsActive = " + (int)Dictionary.IsActive.Active + " and DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate))<= '" + sDate + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _B2BDiscountID = Convert.ToInt32(reader["B2BDiscountID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _B2BDiscountID;
        }

        public bool GetIsGetB2BDiscount(int nCustomerID, string sApprovalNumber)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nIsApplicableB2BDiscount = 0;
            try
            {
                cmd.CommandText = "Select IsApplicableB2BDiscount From t_PromoDiscountSpecial where CustomerID = " + nCustomerID + " and ApprovalNumber = '" + sApprovalNumber + "'";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nIsApplicableB2BDiscount = Convert.ToInt32(reader["IsApplicableB2BDiscount"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nIsApplicableB2BDiscount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public double GetB2CDealerDiscount(int nSalesType, int nProductID, DateTime dtOperationDate, double _TotalRSAmount)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            double _Discount = 0;
            try
            {
                cmd.CommandText = "Select DiscountID,ROUND(" + _TotalRSAmount + " * DiscountPercent / 100, 0) as DiscountAmount " +
                                "From t_PromoDiscountMAGBrand A,v_ProductDetails b " +
                                "where a.MAGID = b.MAGID and a.BrandID = b.BrandID and ProductID = " + nProductID + " " +
                                "and DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate))<= '" + sDate + "' and a.IsActive = " + (int)Dictionary.IsActive.Active + " and Status = " + (int)Dictionary.MAGBrandWiseDiscount.Approved + " " +
                                "and SalesType = " + nSalesType + "";

                ////cast(REPLACE(CONVERT(VARCHAR(11), EffectiveDate, 106), ' ', '-') as date) <= '" + sDate + "'

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Discount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nDiscountID = Convert.ToInt32(reader["DiscountID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Discount;
        }

        public double GetB2CDealerDiscountRT(int nSalesType, int nProductID, DateTime dtOperationDate, double _TotalRSAmount)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            double _Discount = 0;
            try
            {
                cmd.CommandText = "Select DiscountID,ROUND(" + _TotalRSAmount + " * DiscountPercent / 100, 0) as DiscountAmount " +
                                "From t_PromoDiscountMAGBrand A,v_ProductDetails b " +
                                "where a.MAGID = b.MAGID and a.BrandID = b.BrandID and ProductID = " + nProductID + " " +
                                "and DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate))<= '" + sDate + "' and a.IsActive = " + (int)Dictionary.IsActive.Active + " and Status = " + (int)Dictionary.MAGBrandWiseDiscount.Approved + " " +
                                "and SalesType = " + nSalesType + "";

                ////cast(REPLACE(CONVERT(VARCHAR(11), EffectiveDate, 106), ' ', '-') as date) <= '" + sDate + "'

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Discount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nDiscountID = Convert.ToInt32(reader["DiscountID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Discount;
        }

        public double GetCustTypeMarginDiscountRSP(int nCustomerID, int nProductID, DateTime dtOperationDate, int Qty)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            double _Discount = 0;
            try
            {
                cmd.CommandText = "Select a.ID,ProductID,ProductCode,ProductName,MAGName,BrandDesc,RSP,CostPrice,a.ProfitPercent,  " +
                                "" + Qty + " *isnull(ROUND(RSP - (  " +
                                "(case when PriceOption = 4 then CostPrice else TradePrice end) +  " +
                                "((case when PriceOption = 4 then CostPrice else TradePrice end) * ProfitPercent / 100)),0),0) As DiscountAmount  " +
                                "From t_PromoDiscountMAGBrandDealerMargin a,v_ProductDetails b,t_Customer c  " +
                                "where a.CustTypeID=c.CustTypeID and a.MAGID = b.MAGID and a.BrandID = b.BrandID and a.IsActive = " + (int)Dictionary.IsActive.Active + "  " +
                                "and a.Status = " + (int)Dictionary.MAGBrandWiseDiscount.Approved + " and DATEADD(dd, 0, DATEDIFF(dd, 0, a.EffectiveDate))<= '" + sDate + "'  " +
                                "and ProductID = " + nProductID + " and CustomerID=" + nCustomerID + "";



                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Discount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nDiscountID = Convert.ToInt32(reader["ID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Discount;
        }

        public double GetCustTypeMarginDiscountRSPRT(int nCustomerID, int nProductID, DateTime dtOperationDate, int Qty)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            double _Discount = 0;
            try
            {
                cmd.CommandText = "Select a.ID,ProductID,ProductCode,ProductName,MAGName,BrandDesc,RSP,CostPrice,a.ProfitPercent,  " +
                                "" + Qty + " *isnull(ROUND(RSP - (  " +
                                "(case when PriceOption = 4 then CostPrice else TradePrice end) +  " +
                                "((case when PriceOption = 4 then CostPrice else TradePrice end) * ProfitPercent / 100)),0),0) As DiscountAmount  " +
                                "From t_PromoDiscountMAGBrandDealerMargin a,v_ProductDetails b,t_Customer c  " +
                                "where a.CustTypeID=c.CustTypeID and a.MAGID = b.MAGID and a.BrandID = b.BrandID and a.IsActive = " + (int)Dictionary.IsActive.Active + "  " +
                                "and a.Status = " + (int)Dictionary.MAGBrandWiseDiscount.Approved + " and DATEADD(dd, 0, DATEDIFF(dd, 0, a.EffectiveDate))<= '" + sDate + "'  " +
                                "and ProductID = " + nProductID + " and CustomerID=" + nCustomerID + "";



                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Discount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nDiscountID = Convert.ToInt32(reader["ID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Discount;
        }

        public double GetCustTypeMarginDiscount(int nCustomerID, int nProductID, DateTime dtOperationDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            double _Discount = 0;
            try
            {
                cmd.CommandText = "Select a.ID,ProductID,ProductCode,ProductName,MAGName,BrandDesc,RSP,CostPrice,a.ProfitPercent,  " +
                                "isnull(ROUND(RSP - (  " +
                                "(case when PriceOption = 4 then CostPrice else TradePrice end) +  " +
                                "((case when PriceOption = 4 then CostPrice else TradePrice end) * ProfitPercent / 100)),0),0) As DiscountAmount  " +
                                "From t_PromoDiscountMAGBrandDealerMargin a,v_ProductDetails b,t_Customer c  " +
                                "where a.CustTypeID=c.CustTypeID and a.MAGID = b.MAGID and a.BrandID = b.BrandID and a.IsActive = " + (int)Dictionary.IsActive.Active + "  " +
                                "and a.Status = " + (int)Dictionary.MAGBrandWiseDiscount.Approved + " and DATEADD(dd, 0, DATEDIFF(dd, 0, a.EffectiveDate))<= '" + sDate + "'  " +
                                "and ProductID = " + nProductID + " and CustomerID=" + nCustomerID + "";



                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Discount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nDiscountID = Convert.ToInt32(reader["ID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Discount;
        }

        public double GetB2CDealerDiscount(int nSalesType, int nProductID, DateTime dtOperationDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDate = dtOperationDate.ToString("dd-MMM-yyyy");

            double _Discount = 0;
            try
            {
                cmd.CommandText = "Select DiscountID,ROUND(RSP * DiscountPercent / 100, 0) as DiscountAmount " +
                                "From t_PromoDiscountMAGBrand A,v_ProductDetails b " +
                                "where a.MAGID = b.MAGID and a.BrandID = b.BrandID and ProductID = " + nProductID + " " +
                                "and DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate))<= '" + sDate + "' and a.IsActive = " + (int)Dictionary.IsActive.Active + " and Status = " + (int)Dictionary.MAGBrandWiseDiscount.Approved + " " +
                                "and SalesType = " + nSalesType + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Discount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nDiscountID = Convert.ToInt32(reader["DiscountID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Discount;
        }
    }
    public class ConsumerPromotionEngines : CollectionBase
    {
        public ConsumerPromotionEngine this[int i]
        {
            get { return (ConsumerPromotionEngine)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ConsumerPromotionEngine oConsumerPromotionEngine)
        {
            InnerList.Add(oConsumerPromotionEngine);
        }
        public int GetIndex(int nConsumerPromoID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ConsumerPromoID == nConsumerPromoID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void GetSinglePromotion(DateTime _dtOperationDate, int nConsumerPromoTypeID, int nChannelID, int nWarehouseID, int nGroupTypeID, int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select distinct a.ConsumerPromoID,'['+ConsumerPromoNo+']'+' '+ConsumerPromoName as ConsumerPromoName  " +
                        "From t_PromoCP a,t_PromoCPProductFor b,t_PromoCPType c,  " +
                        "t_PromoCPChannel d,t_PromoCPWarehouse e  " +
                        "where a.ConsumerPromoID=b.ConsumerPromoID and a.ConsumerPromoID=c.ConsumerPromoID and   " +
                        "a.ConsumerPromoID=d.ConsumerPromoID and a.ConsumerPromoID=e.ConsumerPromoID and   " +
                        "a.ConsumerPromoID in (  " +
                        "Select a.ConsumerPromoID From (Select ConsumerPromoID From t_PromoCPProductFor   " +
                        "group by ConsumerPromoID HAVING COUNT(ProductID)=1) a,  " +
                        "(Select ConsumerPromoID From  dbo.t_PromoCPSlab where IsActive=1  " +
                        "group by ConsumerPromoID HAVING COUNT(SlabID)=1) b  " +
                        "where a.ConsumerPromoID=b.ConsumerPromoID) and   " +
                        "'" + _dtOperationDate + "' between fromdate and toDate   " +
                        "and ConsumerPromoTypeID=" + nConsumerPromoTypeID + " and ChannelID=" + nChannelID + "  " +
                        "and WarehouseID=" + nWarehouseID + " and GroupTypeID=" + nGroupTypeID + " and ProductID=" + nProductID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionEngine oConsumerPromotionOfferDetail = new ConsumerPromotionEngine();
                    oConsumerPromotionOfferDetail.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotionOfferDetail.ConsumerPromoName = (string)reader["ConsumerPromoName"];
                    InnerList.Add(oConsumerPromotionOfferDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSinglePromotionOffers(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ConsumerPromoID,SlabID,SlabName,OfferID,OfferName, " +
                        "max(OfferProduct) OfferProduct,max(OfferAmount) OfferAmount, " +
                        "max(OfferPercentage) OfferPercentage  " +
                        "From  " +
                        "( " +
                        "Select ConsumerPromoID,SlabID,SlabName,OfferID,OfferName, " +
                        "case OfferType when 0 then ProductName+':'+CAST(OfferQty as varchar(100))+'Pcs'  " +
                        "else '' end as OfferProduct, " +
                        "case OfferType when 1 then Discount else 0 end as OfferAmount, " +
                        "case OfferType when 2 then Discount else 0 end as OfferPercentage  " +
                        "From  " +
                        "( " +
                        "Select a.*,SlabName,OfferType,OfferProductID,OfferQty,Discount  " +
                        "From t_PromoCPOffer a,t_PromoCPOfferDetail b,t_PromoCPSlab c " +
                        "where a.ConsumerPromoID=b.ConsumerPromoID and a.SlabID=b.SlabID and a.OfferID=b.OfferID " +
                        "and a.ConsumerPromoID=c.ConsumerPromoID and a.SlabID=c.SlabID " +
                        "and a.IsActive=1 and c.IsActive=1 " +
                        ") a " +
                        "Left Outer Join  " +
                        "( " +
                        "Select * From t_Product " +
                        ") b " +
                        "on a.OfferProductID=b.ProductID " +
                        ") Main  where ConsumerPromoID=" + nConsumerPromoID + "  " +
                        "group by ConsumerPromoID,SlabID,SlabName,OfferID,OfferName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionEngine oConsumerPromotionOfferDetail = new ConsumerPromotionEngine();
                    oConsumerPromotionOfferDetail.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotionOfferDetail.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionOfferDetail.SlabName = (string)reader["SlabName"];
                    oConsumerPromotionOfferDetail.OfferID = (int)reader["OfferID"];
                    oConsumerPromotionOfferDetail.OfferName = (string)reader["OfferName"];
                    oConsumerPromotionOfferDetail.OfferProduct = (string)reader["OfferProduct"];
                    oConsumerPromotionOfferDetail.OfferAmount = Convert.ToDouble(reader["OfferAmount"].ToString());
                    oConsumerPromotionOfferDetail.OfferPercentage = Convert.ToDouble(reader["OfferPercentag"].ToString());
                    InnerList.Add(oConsumerPromotionOfferDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool IsEligiblePromoByCustType(string sCustType, int sInvoiceCustType)
        {
            string[] sCustomerTypeArr = null;
            int nArrayLen = 0;
            char[] splitchar = { ',' };
            string sCustomerType = sCustType.ToString();
            sCustomerTypeArr = sCustomerType.Split(splitchar);
            nArrayLen = sCustomerTypeArr.Length;
            bool _IsTrue = false;
            for (int i = 0; i < nArrayLen; i++)
            {
                if (sInvoiceCustType.ToString() == sCustomerTypeArr[i])
                {
                    _IsTrue = true;
                    break;
                }
            }
            return _IsTrue;
        }

        public DSConsumerPromo GetEligiblePromo(DateTime _dtOperationDate, string sProductID, int nWarehouseID, int nSalesType, int nConsumerPromoTypeID, int nInvoiceCustomerTypeID)
        {
            DSConsumerPromo _oDSEligiblePromo = new Promotion.DSConsumerPromo();
            string _sOperationDate = _dtOperationDate.ToString("dd-MMM-yyyy");
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select isnull(CustType,'') as CustomerType,a.ConsumerPromoID, a.ConsumerPromoNo, a.ConsumerPromoName, FromDate, ToDate, IsApplicableOnOfferPrice from [dbo].[t_PromoCP] a, [dbo].[t_PromoCPWarehouse] b, [dbo].[t_PromoCPSalesType] c, [dbo].[t_PromoCPType] d, " +
                          " (Select distinct ConsumerPromoID from[dbo].[t_PromoCPProductFor] where ProductID IN(" + sProductID + ")) e " +
                          " where a.ConsumerPromoID = b.ConsumerPromoID and a.ConsumerPromoID = c.ConsumerPromoID and a.ConsumerPromoID = d.ConsumerPromoID and " +
                          " a.ConsumerPromoID = e.ConsumerPromoID and IsActive = " + (int)Dictionary.YesOrNoStatus.YES + " and " +
                          " Status = " + (int)Dictionary.SalesPromStatus.Approved + " and '" + _sOperationDate + "' between FromDate and ToDate and b.WarehouseID = " + nWarehouseID + " " +
                          " and c.SalesType = " + nSalesType + " and d.ConsumerPromoTypeID = " + nConsumerPromoTypeID + " Order by IsApplicableOnOfferPrice, a.ConsumerPromoID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //ConsumerPromotionEngine oEligiblePromo = new ConsumerPromotionEngine();
                    DSConsumerPromo.ConsumerPromoRow _oEligiblePromo = _oDSEligiblePromo.ConsumerPromo.NewConsumerPromoRow();

                    _oEligiblePromo.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _oEligiblePromo.ConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                    _oEligiblePromo.ConsumerPromoName = (string)reader["ConsumerPromoName"];
                    string sPromoCustTypeID = (string)reader["CustomerType"];

                    if (reader["IsApplicableOnOfferPrice"] != DBNull.Value)
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    }
                    else
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = 0;
                    }

                    ///New Code (Shuvo, Date:09-Apr-2019)
                    if (nInvoiceCustomerTypeID == -1)
                    {
                        _oDSEligiblePromo.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                        _oDSEligiblePromo.AcceptChanges();
                    }
                    else
                    {

                        if (sPromoCustTypeID == "")
                        {
                            _oDSEligiblePromo.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                            _oDSEligiblePromo.AcceptChanges();
                        }
                        else
                        {
                            if (IsEligiblePromoByCustType(sPromoCustTypeID, nInvoiceCustomerTypeID))
                            {
                                _oDSEligiblePromo.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                                _oDSEligiblePromo.AcceptChanges();
                            }
                        }
                    }
                    //End 



                    //_oDSEligiblePromo.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                    //_oDSEligiblePromo.AcceptChanges();
                    ////InnerList.Add(oEligiblePromo);
                }
                reader.Close();

                //InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSEligiblePromo;
        }

        public DSConsumerPromo GetEligiblePromoTP(DateTime _dtOperationDate, string sProductGroupID, string sBrandID, int nWarehouseID, int nSalesType, int nTradePromoTypeID, int nInvoiceCustomerTypeID)
        {
            DSConsumerPromo _oDSEligiblePromoTP = new Promotion.DSConsumerPromo();
            string _sOperationDate = _dtOperationDate.ToString("dd-MMM-yyyy");
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select isnull(CustType,'') as CustomerType,a.TradePromoID, a.TradePromoNo, a.TradePromoName, FromDate, ToDate, IsApplicableOnOfferPrice from [dbo].[t_PromoTP] a, " +
                          " [dbo].[t_PromoTPWarehouse] b, [dbo].[t_PromoTPSalesType] c, [dbo].[t_PromoTPType] d, " +
                          " (Select distinct TradePromoID from[dbo].[t_PromoTPProductFor] where ProductGroupID IN(" + sProductGroupID + ") and BrandID IN(" + sBrandID + ")) e " +
                          " where a.TradePromoID = b.TradePromoID and a.TradePromoID = c.TradePromoID and a.TradePromoID = d.TradePromoID and " +
                          " a.TradePromoID = e.TradePromoID and IsActive = " + (int)Dictionary.YesOrNoStatus.YES + " and Status = " + (int)Dictionary.SalesPromStatus.Approved + " " +
                          " and '" + _sOperationDate + "' between FromDate and ToDate and b.WarehouseID = " + nWarehouseID + " " +
                          " and c.SalesType = " + nSalesType + "  and d.TradePromoTypeID = " + nTradePromoTypeID + " Order by IsApplicableOnOfferPrice, a.TradePromoID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSConsumerPromo.ConsumerPromoRow _oEligiblePromo = _oDSEligiblePromoTP.ConsumerPromo.NewConsumerPromoRow();

                    _oEligiblePromo.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oEligiblePromo.ConsumerPromoNo = (string)reader["TradePromoNo"];
                    _oEligiblePromo.ConsumerPromoName = (string)reader["TradePromoName"];
                    string sPromoCustTypeID = (string)reader["CustomerType"];
                    if (reader["IsApplicableOnOfferPrice"] != DBNull.Value)
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    }
                    else
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = 0;
                    }

                    ///New Code (Shuvo, Date:09-Apr-2019)
                    if (nInvoiceCustomerTypeID == -1)
                    {
                        _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                        _oDSEligiblePromoTP.AcceptChanges();
                    }
                    else
                    {

                        if (sPromoCustTypeID == "")
                        {
                            _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                            _oDSEligiblePromoTP.AcceptChanges();
                        }
                        else
                        {
                            if (IsEligiblePromoByCustType(sPromoCustTypeID, nInvoiceCustomerTypeID))
                            {
                                _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                                _oDSEligiblePromoTP.AcceptChanges();
                            }
                        }
                    }
                    //End 





                    //_oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                    //_oDSEligiblePromoTP.AcceptChanges();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSEligiblePromoTP;
        }

        public DSConsumerPromo GetEligiblePromoTPSecondary(DateTime _dtOperationDate, string sProductGroupID, string sBrandID, int nSalesType, int nTradePromoTypeID, int nInvoiceCustomerTypeID)
        {
            DSConsumerPromo _oDSEligiblePromoTP = new Promotion.DSConsumerPromo();
            string _sOperationDate = _dtOperationDate.ToString("dd-MMM-yyyy");
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select isnull(CustType,'') as CustomerType,a.TradePromoID, a.TradePromoNo, a.TradePromoName, FromDate, ToDate, IsApplicableOnOfferPrice from [dbo].[t_PromoTPSecondary] a, " +
                          " [dbo].[t_PromoTPSalesTypeSecondary] c, [dbo].[t_PromoTPTypeSecondary] d, " +
                          " (Select distinct TradePromoID from[dbo].[t_PromoTPProductForSecondary] where ProductGroupID IN(" + sProductGroupID + ") and BrandID IN(" + sBrandID + ")) e " +
                          " where a.TradePromoID = c.TradePromoID and a.TradePromoID = d.TradePromoID and " +
                          " a.TradePromoID = e.TradePromoID and IsActive = " + (int)Dictionary.YesOrNoStatus.YES + " and Status = " + (int)Dictionary.SalesPromStatus.Approved + " " +
                          " and '" + _sOperationDate + "' between FromDate and ToDate  " +
                          " and c.SalesType = " + nSalesType + "  and d.TradePromoTypeID = " + nTradePromoTypeID + " Order by IsApplicableOnOfferPrice, a.TradePromoID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSConsumerPromo.ConsumerPromoRow _oEligiblePromo = _oDSEligiblePromoTP.ConsumerPromo.NewConsumerPromoRow();

                    _oEligiblePromo.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oEligiblePromo.ConsumerPromoNo = (string)reader["TradePromoNo"];
                    _oEligiblePromo.ConsumerPromoName = (string)reader["TradePromoName"];
                    string sPromoCustTypeID = (string)reader["CustomerType"];
                    if (reader["IsApplicableOnOfferPrice"] != DBNull.Value)
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    }
                    else
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = 0;
                    }

                    ///New Code (Shuvo, Date:09-Apr-2019)
                    if (nInvoiceCustomerTypeID == -1)
                    {
                        _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                        _oDSEligiblePromoTP.AcceptChanges();
                    }
                    else
                    {

                        if (sPromoCustTypeID == "")
                        {
                            _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                            _oDSEligiblePromoTP.AcceptChanges();
                        }
                        else
                        {
                            if (IsEligiblePromoByCustType(sPromoCustTypeID, nInvoiceCustomerTypeID))
                            {
                                _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                                _oDSEligiblePromoTP.AcceptChanges();
                            }
                        }
                    }
                    //End 





                    //_oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                    //_oDSEligiblePromoTP.AcceptChanges();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSEligiblePromoTP;
        }



        public DSConsumerPromo GetEligiblePromoCPSimple(DateTime _dtOperationDate, int nWarehouseID, int nSalesType, int nCPSimpleTypeID, int nCustomerTypeID, int nProductID)
        {
            DSConsumerPromo _oDSEligiblePromoTP = new Promotion.DSConsumerPromo();
            string _sOperationDate = _dtOperationDate.ToString("dd-MMM-yyyy");
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @" Select * From 
                        (
                        Select a.CPSimpleID,CPSimpleNo,CPSimpleName,
                        Remarks,DiscountType,Amount,isnull(FreeEMITenureID,-1) FreeEMITenureID,PromoDetail,
                        (Select value From  dbo.fn_split(ProductID,',') where value=" + nProductID + @") ProductID,
                        (Select value From  dbo.fn_split(CustomerType,',') where value=" + nCustomerTypeID + @") CustomerType,
                        (Select value From  dbo.fn_split(Warehouse,',') where value=" + nWarehouseID + @") Warehouse,
                        (Select value From  dbo.fn_split(CPSimpleTypeID,',') where value=" + nCPSimpleTypeID + @") CPSimpleTypeID,
                        (Select value From  dbo.fn_split(SalesType,',') where value=" + nSalesType + @") SalesType
                        from t_PromoCPSimple a
                        where Cast('" + _dtOperationDate + @"' as date) 
                        between FromDate and ToDate and IsActive=" + (int)Dictionary.IsActive.Active + @"
                        and Status=" + (int)Dictionary.SalesPromStatus.Approved + @" 
                        ) Promo where ProductID=" + nProductID + @" and
                        CustomerType=" + nCustomerTypeID + @" and Warehouse=" + nWarehouseID + @" and SalesType = " + nSalesType + @" and CPSimpleTypeID=" + nCPSimpleTypeID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSConsumerPromo.ConsumerPromoRow _oEligiblePromo = _oDSEligiblePromoTP.ConsumerPromo.NewConsumerPromoRow();

                    _oEligiblePromo.ConsumerPromoID = (int)reader["CPSimpleID"];
                    _oEligiblePromo.ConsumerPromoNo = (string)reader["CPSimpleNo"];
                    _oEligiblePromo.ConsumerPromoName = (string)reader["CPSimpleName"];
                    _oEligiblePromo.PromoType = "CPSimple";
                    _oEligiblePromo.SlabName = "CP Simple Slab-1";
                    _oEligiblePromo.OfferDescription = (string)reader["PromoDetail"];
                    _oEligiblePromo.Flag = false;
                    _oEligiblePromo.OfferID = 1;
                    _oEligiblePromo.SlabID = 1;
                    _oEligiblePromo.SlabID = 1;
                    _oEligiblePromo.MultiplyTimes = 0;
                    _oEligiblePromo.ProductID = nProductID;
                    _oEligiblePromo.DiscountType = (int)reader["DiscountType"];
                    _oEligiblePromo.FreeEMITenureID = (int)reader["FreeEMITenureID"];
                    _oEligiblePromo.DiscountAmount = (double)reader["Amount"];
                    _oEligiblePromo.IsApplicableOnOfferPrice = 0;
                    _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                    _oDSEligiblePromoTP.AcceptChanges();


                    //oRow.Cells[0].Value = oDSApplicablePromoRow.ConsumerPromoNo;
                    //oRow.Cells[1].Value = oDSApplicablePromoRow.ConsumerPromoName;
                    //oRow.Cells[2].Value = oDSApplicablePromoRow.PromoType;
                    //oRow.Cells[3].Value = oDSApplicablePromoRow.SlabName;
                    //oRow.Cells[4].Value = oDSApplicablePromoRow.OfferDescription;
                    //if (oDSApplicablePromoRow.Flag == false)
                    //{
                    //    oRow.Cells[5].ReadOnly = true;
                    //}
                    //oRow.Cells[6].Value = oDSApplicablePromoRow.OfferID;
                    //oRow.Cells[7].Value = oDSApplicablePromoRow.SlabID;
                    //oRow.Cells[8].Value = oDSApplicablePromoRow.ConsumerPromoID;
                    //oRow.Cells[9].Value = oDSApplicablePromoRow.MultiplyTimes;
                    //oRow.Cells[10].Value = oDSApplicablePromoRow.IsApplicableOnOfferPrice;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSEligiblePromoTP;
        }


        public DSConsumerPromo GetPromoTPByPromoID(string sTradePromoID)
        {
            DSConsumerPromo _oDSEligiblePromoTP = new Promotion.DSConsumerPromo();

            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, TradePromoNo, TradePromoName, FromDate, ToDate, IsApplicableOnOfferPrice from [dbo].[t_PromoTP] " +
                          " Where TradePromoID IN(" + sTradePromoID + ") Order by IsApplicableOnOfferPrice, TradePromoID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSConsumerPromo.ConsumerPromoRow _oEligiblePromo = _oDSEligiblePromoTP.ConsumerPromo.NewConsumerPromoRow();

                    _oEligiblePromo.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oEligiblePromo.ConsumerPromoNo = (string)reader["TradePromoNo"];
                    _oEligiblePromo.ConsumerPromoName = (string)reader["TradePromoName"];

                    if (reader["IsApplicableOnOfferPrice"] != DBNull.Value)
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    }
                    else
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = 0;
                    }
                    _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                    _oDSEligiblePromoTP.AcceptChanges();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSEligiblePromoTP;
        }
        public DSConsumerPromo GetPromoTPByPromoIDSecondary(string sTradePromoID)
        {
            DSConsumerPromo _oDSEligiblePromoTP = new Promotion.DSConsumerPromo();

            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, TradePromoNo, TradePromoName, FromDate, ToDate, IsApplicableOnOfferPrice from [dbo].[t_PromoTPSecondary] " +
                          " Where TradePromoID IN(" + sTradePromoID + ") Order by IsApplicableOnOfferPrice, TradePromoID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSConsumerPromo.ConsumerPromoRow _oEligiblePromo = _oDSEligiblePromoTP.ConsumerPromo.NewConsumerPromoRow();

                    _oEligiblePromo.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oEligiblePromo.ConsumerPromoNo = (string)reader["TradePromoNo"];
                    _oEligiblePromo.ConsumerPromoName = (string)reader["TradePromoName"];

                    if (reader["IsApplicableOnOfferPrice"] != DBNull.Value)
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    }
                    else
                    {
                        _oEligiblePromo.IsApplicableOnOfferPrice = 0;
                    }
                    _oDSEligiblePromoTP.ConsumerPromo.AddConsumerPromoRow(_oEligiblePromo);
                    _oDSEligiblePromoTP.AcceptChanges();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSEligiblePromoTP;
        }

        public DSConsumerPromo GetPromoForProduct(string sConsumerPromoID)
        {
            DSConsumerPromo _oDSPromoForProduct = new Promotion.DSConsumerPromo();
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ConsumerPromoID, GroupTypeID, ProductID, DiscountRatio from [dbo].[t_PromoCPProductFor] where ConsumerPromoID IN (" + sConsumerPromoID + ")";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoForProduct = _oDSPromoForProduct.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoForProduct.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _oPromoForProduct.GroupTypeID = (int)reader["GroupTypeID"];
                    _oPromoForProduct.ProductID = (int)reader["ProductID"];
                    _oPromoForProduct.DiscountRatio = (double)reader["DiscountRatio"];

                    _oDSPromoForProduct.ConsumerPromo.AddConsumerPromoRow(_oPromoForProduct);
                    _oDSPromoForProduct.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoForProduct;
        }

        public DSConsumerPromo GetPromoTPForProduct(string sTradePromoID)
        {
            DSConsumerPromo _oDSPromoTPForProduct = new Promotion.DSConsumerPromo();
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, GroupTypeID, ProductGroupID, BrandID, DiscountRatio, IsApplicableOnAllSKU, ApplicableProductID from [dbo].[t_PromoTPProductFor] where TradePromoID IN (" + sTradePromoID + ") order by TradePromoID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoTPForProduct = _oDSPromoTPForProduct.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoTPForProduct.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oPromoTPForProduct.GroupTypeID = (int)reader["GroupTypeID"];
                    _oPromoTPForProduct.ProductGroupID = (int)reader["ProductGroupID"];
                    _oPromoTPForProduct.BrandID = (int)reader["BrandID"];
                    _oPromoTPForProduct.DiscountRatio = (double)reader["DiscountRatio"];

                    if (reader["IsApplicableOnAllSKU"] != DBNull.Value)
                    {
                        _oPromoTPForProduct.IsApplicableOnAllSKU = (int)reader["IsApplicableOnAllSKU"];
                    }
                    else
                    {
                        _oPromoTPForProduct.IsApplicableOnAllSKU = 1; // 1 means allpicable for all sku under the selected MAG and Brand
                    }

                    if (reader["ApplicableProductID"] != DBNull.Value)
                    {
                        _oPromoTPForProduct.ApplicableProductID = (string)reader["ApplicableProductID"];
                    }
                    else
                    {
                        _oPromoTPForProduct.ApplicableProductID = "";
                    }

                    _oDSPromoTPForProduct.ConsumerPromo.AddConsumerPromoRow(_oPromoTPForProduct);
                    _oDSPromoTPForProduct.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoTPForProduct;
        }
        public DSConsumerPromo GetPromoTPForProductSecondary(string sTradePromoID)
        {
            DSConsumerPromo _oDSPromoTPForProduct = new Promotion.DSConsumerPromo();
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, GroupTypeID, ProductGroupID, BrandID, DiscountRatio, IsApplicableOnAllSKU, ApplicableProductID from [dbo].[t_PromoTPProductForSecondary] where TradePromoID IN (" + sTradePromoID + ") order by TradePromoID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoTPForProduct = _oDSPromoTPForProduct.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoTPForProduct.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oPromoTPForProduct.GroupTypeID = (int)reader["GroupTypeID"];
                    _oPromoTPForProduct.ProductGroupID = (int)reader["ProductGroupID"];
                    _oPromoTPForProduct.BrandID = (int)reader["BrandID"];
                    _oPromoTPForProduct.DiscountRatio = (double)reader["DiscountRatio"];

                    if (reader["IsApplicableOnAllSKU"] != DBNull.Value)
                    {
                        _oPromoTPForProduct.IsApplicableOnAllSKU = (int)reader["IsApplicableOnAllSKU"];
                    }
                    else
                    {
                        _oPromoTPForProduct.IsApplicableOnAllSKU = 1; // 1 means allpicable for all sku under the selected MAG and Brand
                    }

                    if (reader["ApplicableProductID"] != DBNull.Value)
                    {
                        _oPromoTPForProduct.ApplicableProductID = (string)reader["ApplicableProductID"];
                    }
                    else
                    {
                        _oPromoTPForProduct.ApplicableProductID = "";
                    }

                    _oDSPromoTPForProduct.ConsumerPromo.AddConsumerPromoRow(_oPromoTPForProduct);
                    _oDSPromoTPForProduct.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoTPForProduct;
        }
        public DSConsumerPromo GetPromoSlab(string sConsumerPromoID)
        {
            DSConsumerPromo _oDSPromoSlab = new Promotion.DSConsumerPromo();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ConsumerPromoID, SlabID, SlabName from [dbo].[t_PromoCPSlab] Where ConsumerPromoID IN (" + sConsumerPromoID + ")  Order by ConsumerPromoID ASC, SlabID DESC";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoSlab = _oDSPromoSlab.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoSlab.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _oPromoSlab.SlabID = (int)reader["SlabID"];
                    _oPromoSlab.SlabName = (string)reader["SlabName"];

                    _oDSPromoSlab.ConsumerPromo.AddConsumerPromoRow(_oPromoSlab);
                    _oDSPromoSlab.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoSlab;
        }

        public DSConsumerPromo GetPromoSlabTP(string sTradePromoID)
        {
            DSConsumerPromo _oDSPromoSlabTP = new Promotion.DSConsumerPromo();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, SlabID, SlabName, MinInvoiceQty from [dbo].[t_PromoTPSlab] Where TradePromoID IN (" + sTradePromoID + ")  Order by TradePromoID ASC, SlabID DESC";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoSlabTP = _oDSPromoSlabTP.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoSlabTP.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oPromoSlabTP.SlabID = (int)reader["SlabID"];
                    _oPromoSlabTP.SlabName = (string)reader["SlabName"];
                    _oPromoSlabTP.MinInvoiceQty = (int)reader["MinInvoiceQty"];

                    _oDSPromoSlabTP.ConsumerPromo.AddConsumerPromoRow(_oPromoSlabTP);
                    _oDSPromoSlabTP.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoSlabTP;
        }
        public DSConsumerPromo GetPromoSlabTPSecondary(string sTradePromoID)
        {
            DSConsumerPromo _oDSPromoSlabTP = new Promotion.DSConsumerPromo();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, SlabID, SlabName, MinInvoiceQty from [dbo].[t_PromoTPSlabSecondary] Where TradePromoID IN (" + sTradePromoID + ")  Order by TradePromoID ASC, SlabID DESC";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoSlabTP = _oDSPromoSlabTP.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoSlabTP.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oPromoSlabTP.SlabID = (int)reader["SlabID"];
                    _oPromoSlabTP.SlabName = (string)reader["SlabName"];
                    _oPromoSlabTP.MinInvoiceQty = (int)reader["MinInvoiceQty"];

                    _oDSPromoSlabTP.ConsumerPromo.AddConsumerPromoRow(_oPromoSlabTP);
                    _oDSPromoSlabTP.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoSlabTP;
        }

        public DSConsumerPromo GetPromoSlabRatio(string sConsumerPromoID)
        {
            DSConsumerPromo _oDSPromoSlabRatio = new Promotion.DSConsumerPromo();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ConsumerPromoID, SlabID, ProductID, Qty from [dbo].[t_PromoCPSlabRatio] Where ConsumerPromoID IN (" + sConsumerPromoID + ")";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoSlabRatio = _oDSPromoSlabRatio.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoSlabRatio.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _oPromoSlabRatio.SlabID = (int)reader["SlabID"];
                    _oPromoSlabRatio.ProductID = (int)reader["ProductID"];
                    _oPromoSlabRatio.Qty = (int)reader["Qty"];

                    _oDSPromoSlabRatio.ConsumerPromo.AddConsumerPromoRow(_oPromoSlabRatio);
                    _oDSPromoSlabRatio.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoSlabRatio;
        }

        public DSConsumerPromo GetPromoSlabRatioTP(string sTradePromoID)
        {
            DSConsumerPromo _oDSPromoTPSlabRatio = new Promotion.DSConsumerPromo();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, SlabID, GroupTypeID, ProductGroupID, BrandID, MinQty from [dbo].[t_PromoTPSlabRatio] Where TradePromoID IN (" + sTradePromoID + ")";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoTPSlabRatio = _oDSPromoTPSlabRatio.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoTPSlabRatio.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oPromoTPSlabRatio.SlabID = (int)reader["SlabID"];
                    _oPromoTPSlabRatio.GroupTypeID = Convert.ToInt32(reader["GroupTypeID"]);
                    _oPromoTPSlabRatio.ProductGroupID = Convert.ToInt32(reader["ProductGroupID"]);
                    _oPromoTPSlabRatio.BrandID = Convert.ToInt32(reader["BrandID"]);
                    _oPromoTPSlabRatio.MinQty = Convert.ToInt32(reader["MinQty"]);

                    _oDSPromoTPSlabRatio.ConsumerPromo.AddConsumerPromoRow(_oPromoTPSlabRatio);
                    _oDSPromoTPSlabRatio.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoTPSlabRatio;
        }
        public DSConsumerPromo GetPromoSlabRatioTPSecondary(string sTradePromoID)
        {
            DSConsumerPromo _oDSPromoTPSlabRatio = new Promotion.DSConsumerPromo();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, SlabID, GroupTypeID, ProductGroupID, BrandID, MinQty from [dbo].[t_PromoTPSlabRatioSecondary] Where TradePromoID IN (" + sTradePromoID + ")";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSConsumerPromo.ConsumerPromoRow _oPromoTPSlabRatio = _oDSPromoTPSlabRatio.ConsumerPromo.NewConsumerPromoRow();

                    _oPromoTPSlabRatio.ConsumerPromoID = (int)reader["TradePromoID"];
                    _oPromoTPSlabRatio.SlabID = (int)reader["SlabID"];
                    _oPromoTPSlabRatio.GroupTypeID = Convert.ToInt32(reader["GroupTypeID"]);
                    _oPromoTPSlabRatio.ProductGroupID = Convert.ToInt32(reader["ProductGroupID"]);
                    _oPromoTPSlabRatio.BrandID = Convert.ToInt32(reader["BrandID"]);
                    _oPromoTPSlabRatio.MinQty = Convert.ToInt32(reader["MinQty"]);

                    _oDSPromoTPSlabRatio.ConsumerPromo.AddConsumerPromoRow(_oPromoTPSlabRatio);
                    _oDSPromoTPSlabRatio.AcceptChanges();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _oDSPromoTPSlabRatio;
        }

        public void GetPromoOffer(int nConsumerPromoID, int nSlabID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ConsumerPromoID, SlabID, OfferID, OfferName, Description from [dbo].[t_PromoCPOffer] " +
                " where ConsumerPromoID = " + nConsumerPromoID + " and SlabID = " + nSlabID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ConsumerPromotionEngine oPromoOffer = new ConsumerPromotionEngine();

                    oPromoOffer.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oPromoOffer.SlabID = (int)reader["SlabID"];
                    oPromoOffer.OfferID = (int)reader["OfferID"];
                    oPromoOffer.OfferName = (string)reader["OfferName"];
                    oPromoOffer.OfferDesctiption = (string)reader["Description"];

                    InnerList.Add(oPromoOffer);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetPromoOfferTP(int nTradePromoID, int nSlabID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, SlabID, OfferID, OfferName, Description from [dbo].[t_PromoTPOffer] " +
                " where TradePromoID = " + nTradePromoID + " and SlabID = " + nSlabID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ConsumerPromotionEngine oPromoOffer = new ConsumerPromotionEngine();

                    oPromoOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    oPromoOffer.SlabID = (int)reader["SlabID"];
                    oPromoOffer.OfferID = (int)reader["OfferID"];
                    oPromoOffer.OfferName = (string)reader["OfferName"];
                    oPromoOffer.OfferDesctiption = (string)reader["Description"];

                    InnerList.Add(oPromoOffer);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetPromoOfferTPSecondary(int nTradePromoID, int nSlabID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, SlabID, OfferID, OfferName, Description from [dbo].[t_PromoTPOfferSecondary] " +
                " where TradePromoID = " + nTradePromoID + " and SlabID = " + nSlabID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ConsumerPromotionEngine oPromoOffer = new ConsumerPromotionEngine();

                    oPromoOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    oPromoOffer.SlabID = (int)reader["SlabID"];
                    oPromoOffer.OfferID = (int)reader["OfferID"];
                    oPromoOffer.OfferName = (string)reader["OfferName"];
                    oPromoOffer.OfferDesctiption = (string)reader["Description"];

                    InnerList.Add(oPromoOffer);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetPromoOfferDetail(int nConsumerPromoID, int nSlabID, int nOfferID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ConsumerPromoID, SlabID, OfferID, OfferType, OfferProductID, OfferQty, Discount, EMITenureID from t_PromoCPOfferDetail " +
                " where ConsumerPromoID = " + nConsumerPromoID + " and SlabID = " + nSlabID + " and OfferID = " + nOfferID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ConsumerPromotionEngine oPromoOffer = new ConsumerPromotionEngine();

                    oPromoOffer.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oPromoOffer.SlabID = (int)reader["SlabID"];
                    oPromoOffer.OfferID = (int)reader["OfferID"];
                    oPromoOffer.OfferType = (int)reader["OfferType"];
                    if (reader["OfferProductID"] != DBNull.Value)
                        oPromoOffer.OfferProductID = (int)reader["OfferProductID"];
                    else oPromoOffer.OfferProductID = 0;
                    if (reader["OfferQty"] != DBNull.Value)
                        oPromoOffer.OfferQty = (int)reader["OfferQty"];
                    else oPromoOffer.OfferQty = 0;
                    if (reader["Discount"] != DBNull.Value)
                        oPromoOffer.Discount = (double)reader["Discount"];
                    else oPromoOffer.Discount = 0;
                    if (reader["EMITenureID"] != DBNull.Value)
                        oPromoOffer.EMITenureID = (int)reader["EMITenureID"];
                    else oPromoOffer.EMITenureID = 0;

                    InnerList.Add(oPromoOffer);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetPromoTPOfferDetail(int nTredePromoID, int nSlabID, int nOfferID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, SlabID, OfferID, OfferType, OfferProductID, OfferQty, Discount from t_PromoTPOfferDetail " +
                " where TradePromoID = " + nTredePromoID + " and SlabID = " + nSlabID + " and OfferID = " + nOfferID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ConsumerPromotionEngine oPromoOffer = new ConsumerPromotionEngine();

                    oPromoOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    oPromoOffer.SlabID = (int)reader["SlabID"];
                    oPromoOffer.OfferID = (int)reader["OfferID"];
                    oPromoOffer.OfferType = (int)reader["OfferType"];
                    if (reader["OfferProductID"] != DBNull.Value)
                        oPromoOffer.OfferProductID = (int)reader["OfferProductID"];
                    else oPromoOffer.OfferProductID = 0;
                    if (reader["OfferQty"] != DBNull.Value)
                        oPromoOffer.OfferQty = (int)reader["OfferQty"];
                    else oPromoOffer.OfferQty = 0;
                    if (reader["Discount"] != DBNull.Value)
                        oPromoOffer.Discount = (double)reader["Discount"];
                    else oPromoOffer.Discount = 0;


                    InnerList.Add(oPromoOffer);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetPromoTPOfferDetailSecondary(int nTredePromoID, int nSlabID, int nOfferID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select TradePromoID, SlabID, OfferID, OfferType, OfferProductID, OfferQty, Discount from t_PromoTPOfferDetailSecondary " +
                " where TradePromoID = " + nTredePromoID + " and SlabID = " + nSlabID + " and OfferID = " + nOfferID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ConsumerPromotionEngine oPromoOffer = new ConsumerPromotionEngine();

                    oPromoOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    oPromoOffer.SlabID = (int)reader["SlabID"];
                    oPromoOffer.OfferID = (int)reader["OfferID"];
                    oPromoOffer.OfferType = (int)reader["OfferType"];
                    if (reader["OfferProductID"] != DBNull.Value)
                        oPromoOffer.OfferProductID = (int)reader["OfferProductID"];
                    else oPromoOffer.OfferProductID = 0;
                    if (reader["OfferQty"] != DBNull.Value)
                        oPromoOffer.OfferQty = (int)reader["OfferQty"];
                    else oPromoOffer.OfferQty = 0;
                    if (reader["Discount"] != DBNull.Value)
                        oPromoOffer.Discount = (double)reader["Discount"];
                    else oPromoOffer.Discount = 0;


                    InnerList.Add(oPromoOffer);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetSpecialDiscountAuthority()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From [t_PromoDiscountSpecialAuthority] order By Sort";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ConsumerPromotionEngine oPromoOffer = new ConsumerPromotionEngine();
                    oPromoOffer.AuthorityID = (int)reader["AuthorityID"];
                    oPromoOffer.EmployeeID = (int)reader["EmployeeID"];
                    oPromoOffer.EmployeeName = (string)reader["EmployeeName"];


                    InnerList.Add(oPromoOffer);

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

