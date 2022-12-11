// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam K. Kar
// Date: April 20, 2014
// Time :  02:16 PM
// Description: Class for Product Price.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.BasicData
{
    public class ProductPrice
    {
        private int _nPriceID;
        private int _nMCSetupID;
        private int _nProductID;
        private DateTime _dEffectiveDate;
        private double _nCostPrice;
        private double _nTradePrice;
        private double _nNSP;
        private double _MC;
        private double _VATCP;

        private double _nRSP;
        private double _nSpecialPrice;
        private double _dDistributorPrice;
        private double _dVAT;
        private int _nIsCurrent;
        private int _nUploadStatus;
        private DateTime _dUploadDate;
        private DateTime _dDownloadDate;
        private int _nRowStatus;
        private int _nTerminal;
        private int _nEntryUserID;
        private double _CPUSD;

        private string _sERPCode;
        private double _nCOGS;
        private double _nVCMaterial;
        private double _nVCVariableFactory;
        private double _nVCDirectLabor;

        private double _nFreightCost;
        private double _nReplacement;
        private double _nAdvertisement;
        private double _nTPRetailOffer;
        private double _nTPDBIncentive;

        private double _nTPTeamIncentive;
        private double _nTPYearlyIncentive;
        private double _nRoyality;
        private double _nDistributorTax;

        private string _sProductCode;

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        public string ERPCode
        {
            get { return _sERPCode; }
            set { _sERPCode = value; }
        }

        public double COGS
        {
            get { return _nCOGS; }
            set { _nCOGS = value; }
        }

        public double VATCP
        {
            get { return _VATCP; }
            set { _VATCP = value; }
        }

        public double VCMaterial
        {
            get { return _nVCMaterial; }
            set { _nVCMaterial = value; }
        }

        public double VCVariableFactory
        {
            get { return _nVCVariableFactory; }
            set { _nVCVariableFactory = value; }
        }

        public double VCDirectLabor
        {
            get { return _nVCDirectLabor; }
            set { _nVCDirectLabor = value; }
        }

        public double FreightCost
        {
            get { return _nFreightCost; }
            set { _nFreightCost = value; }
        }

        public double Replacement
        {
            get { return _nReplacement; }
            set { _nReplacement = value; }
        }

        public double Advertisement
        {
            get { return _nAdvertisement; }
            set { _nAdvertisement = value; }
        }

        public double TPRetailOffer
        {
            get { return _nTPRetailOffer; }
            set { _nTPRetailOffer = value; }
        }

        public double TPDBIncentive
        {
            get { return _nTPDBIncentive; }
            set { _nTPDBIncentive = value; }
        }

        public double TPTeamIncentive
        {
            get { return _nTPTeamIncentive; }
            set { _nTPTeamIncentive = value; }
        }

        public double TPYearlyIncentive
        {
            get { return _nTPYearlyIncentive; }
            set { _nTPYearlyIncentive = value; }
        }

        public double Royality
        {
            get { return _nRoyality; }
            set { _nRoyality = value; }
        }

        public double DistributorTax
        {
            get { return _nDistributorTax; }
            set { _nDistributorTax = value; }
        }

        public double MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        public double CPUSD
        {
            get { return _CPUSD; }
            set { _CPUSD = value; }
        }
        private double _CPBDT;
        public double CPBDT
        {
            get { return _CPBDT; }
            set { _CPBDT = value; }
        }

        private string _sRemarks;
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public int PriceID
        {
            get { return _nPriceID; }
            set { _nPriceID = value; }
        }

        public int MCSetupID
        {
            get { return _nMCSetupID; }
            set { _nMCSetupID = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public DateTime EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
        }
        public double CostPrice
        {
            get { return _nCostPrice; }
            set { _nCostPrice = value; }
        }


        private double _nNetPrice;
        public double NetPrice
        {
            get { return _nNetPrice; }
            set { _nNetPrice = value; }
        }
        private double _nCommission;
        public double Commission
        {
            get { return _nCommission; }
            set { _nCommission = value; }
        }


        public double TradePrice
        {
            get { return _nTradePrice; }
            set { _nTradePrice = value; }
        }
        public double NSP
        {
            get { return _nNSP; }
            set { _nNSP = value; }
        }
        public double RSP
        {
            get { return _nRSP; }
            set { _nRSP = value; }
        }
        public double SpecialPrice
        {
            get { return _nSpecialPrice; }
            set { _nSpecialPrice = value; }
        }
        public double DistributorPrice
        {
            get { return _dDistributorPrice; }
            set { _dDistributorPrice = value; }
        }
        public double VAT
        {
            get { return _dVAT; }
            set { _dVAT = value; }
        }
        public int IsCurrent
        {
            get { return _nIsCurrent; }
            set { _nIsCurrent = value; }
        }
        public int UploadStatus
        {
            get { return _nUploadStatus; }
            set { _nUploadStatus = value; }
        }
        public DateTime UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }
        }
        public DateTime DownloadDate
        {
            get { return _dDownloadDate; }
            set { _dDownloadDate = value; }
        }
        public int RowStatus
        {
            get { return _nRowStatus; }
            set { _nRowStatus = value; }
        }
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }
        public int EntryUserID
        {
            get { return _nEntryUserID; }
            set { _nEntryUserID = value; }
        }
        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        private int _nSmartWarrantyTenure;

        public int SmartWarrantyTenure
        {
            get { return _nSmartWarrantyTenure; }
            set { _nSmartWarrantyTenure = value; }
        }


        private DateTime _dCreateDate;

        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_FinishedGoodsPrice where PriceID=?";
                cmd.Parameters.AddWithValue("PriceID", _nPriceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPriceID = (int)reader["PriceID"];
                    _nProductID = (int)reader["ProductID"];
                    _dEffectiveDate = (DateTime)reader["EffectiveDate"];
                    _nCostPrice = (double)reader["CostPrice"];

                    if (reader["TradePrice"] != DBNull.Value)
                        _nTradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _nTradePrice = 0;

                    _nNSP = (double)reader["NSP"];
                    _nRSP = (double)reader["RSP"];

                    if (reader["SpecialPrice"] != DBNull.Value)
                        _nSpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else _nSpecialPrice = 0;

                    if (reader["DistributorPrice"] != DBNull.Value)
                        _dDistributorPrice = Convert.ToDouble(reader["DistributorPrice"].ToString());
                    else _dDistributorPrice = 0;

                    _dVAT = (double)reader["VAT"];
                    _nIsCurrent = (int)reader["IsCurrent"];

                    if (reader["UploadStatus"] != DBNull.Value)
                        _nUploadStatus = Convert.ToInt32(reader["UploadStatus"].ToString());
                    else
                        _nUploadStatus = 0;

                    if (reader["RowStatus"] != DBNull.Value)
                        _nRowStatus = Convert.ToInt32(reader["RowStatus"].ToString());
                    else
                        _nRowStatus = 0;

                    if (reader["Terminal"] != DBNull.Value)
                        _nTerminal = Convert.ToInt32(reader["Terminal"].ToString());
                    else
                        _nTerminal = 0;

                    if (reader["EntryUserID"] != DBNull.Value)
                        _nEntryUserID = Convert.ToInt32(reader["EntryUserID"].ToString());
                    else
                        _nEntryUserID = 0;

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByProductID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_FinishedGoodsPrice where ProductID=? and IsCurrent=1";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPriceID = (int)reader["PriceID"];
                    _nProductID = (int)reader["ProductID"];
                    _dEffectiveDate = (DateTime)reader["EffectiveDate"];
                    _nCostPrice = (double)reader["CostPrice"];

                    if (reader["TradePrice"] != DBNull.Value)
                        _nTradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _nTradePrice = 0;

                    _nNSP = (double)reader["NSP"];
                    _nRSP = (double)reader["RSP"];

                    if (reader["SpecialPrice"] != DBNull.Value)
                        _nSpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else _nSpecialPrice = 0;

                    if (reader["DistributorPrice"] != DBNull.Value)
                        _dDistributorPrice = Convert.ToDouble(reader["DistributorPrice"].ToString());
                    else _dDistributorPrice = 0;

                    _dVAT = (double)reader["VAT"];
                    _nIsCurrent = (int)reader["IsCurrent"];

                    if (reader["UploadStatus"] != DBNull.Value)
                        _nUploadStatus = Convert.ToInt32(reader["UploadStatus"].ToString());
                    else
                        _nUploadStatus = 0;

                    if (reader["RowStatus"] != DBNull.Value)
                        _nRowStatus = Convert.ToInt32(reader["RowStatus"].ToString());
                    else
                        _nRowStatus = 0;

                    if (reader["Terminal"] != DBNull.Value)
                        _nTerminal = Convert.ToInt32(reader["Terminal"].ToString());
                    else
                        _nTerminal = 0;

                    if (reader["EntryUserID"] != DBNull.Value)
                        _nEntryUserID = Convert.ToInt32(reader["EntryUserID"].ToString());
                    else
                        _nEntryUserID = 0;

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
                _bFlag = false;
            }
            else
            {
                _bFlag = true;
            }
        }

        public void RefreshByProductIDPrice()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_FinishedGoodsPrice where ProductID=? and IsCurrent=1";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPriceID = (int)reader["PriceID"];
                    _nProductID = (int)reader["ProductID"];
                    _dEffectiveDate = (DateTime)reader["EffectiveDate"];
                    _nCostPrice = (double)reader["CostPrice"];

                    if (reader["TradePrice"] != DBNull.Value)
                        _nTradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _nTradePrice = 0;

                    _nNSP = (double)reader["NSP"];
                    _nRSP = (double)reader["RSP"];

                    if (reader["SpecialPrice"] != DBNull.Value)
                        _nSpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else _nSpecialPrice = 0;

                    if (reader["DistributorPrice"] != DBNull.Value)
                        _dDistributorPrice = Convert.ToDouble(reader["DistributorPrice"].ToString());
                    else _dDistributorPrice = 0;

                    _dVAT = (double)reader["VAT"];
                    _nIsCurrent = (int)reader["IsCurrent"];

                    if (reader["UploadStatus"] != DBNull.Value)
                        _nUploadStatus = Convert.ToInt32(reader["UploadStatus"].ToString());
                    else
                        _nUploadStatus = 0;

                    if (reader["RowStatus"] != DBNull.Value)
                        _nRowStatus = Convert.ToInt32(reader["RowStatus"].ToString());
                    else
                        _nRowStatus = 0;

                    if (reader["Terminal"] != DBNull.Value)
                        _nTerminal = Convert.ToInt32(reader["Terminal"].ToString());
                    else
                        _nTerminal = 0;

                    if (reader["EntryUserID"] != DBNull.Value)
                        _nEntryUserID = Convert.ToInt32(reader["EntryUserID"].ToString());
                    else
                        _nEntryUserID = 0;

                    if (reader["MC"] != DBNull.Value)
                        _MC = Convert.ToDouble(reader["MC"].ToString());
                    else _MC = 0;


                    if (reader["VATCP"] != DBNull.Value)
                        _VATCP = Convert.ToDouble(reader["VATCP"].ToString());
                    else _VATCP = 0;

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
                _bFlag = false;
            }
            else
            {
                _bFlag = true;
            }
        }

        public void RefreshByProductIDMC()
            {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select * from TestTELAddDB.dbo.t_SKUwiseMCData where Iscurrent=1 and ProductID =? ";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["ERPCode"] != DBNull.Value)
                        _sERPCode = (reader["ERPCode"].ToString());
                    else _sERPCode = "";

                    if (reader["COGS"] != DBNull.Value)
                        _nCOGS = Convert.ToDouble(reader["COGS"].ToString());
                    else _nCOGS = 0;

                    if (reader["VCMaterial"] != DBNull.Value)
                        _nVCMaterial = Convert.ToDouble(reader["VCMaterial"].ToString());
                    else _nVCMaterial = 0;

                    if (reader["VCVariableFactory"] != DBNull.Value)
                        _nVCVariableFactory = Convert.ToDouble(reader["VCVariableFactory"].ToString());
                    else _nVCVariableFactory = 0;

                    if (reader["VCDirectLabor"] != DBNull.Value)
                        _nVCDirectLabor = Convert.ToDouble(reader["VCDirectLabor"].ToString());
                    else _nVCDirectLabor = 0;

                    if (reader["FreightCost"] != DBNull.Value)
                        _nFreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    else _nFreightCost = 0;

                    if (reader["Replacement"] != DBNull.Value)
                        _nReplacement = Convert.ToDouble(reader["Replacement"].ToString());
                    else _nReplacement = 0;

                    if (reader["Advertisement"] != DBNull.Value)
                        _nAdvertisement = Convert.ToDouble(reader["Advertisement"].ToString());
                    else _nAdvertisement = 0;

                    if (reader["TPRetailOffer"] != DBNull.Value)
                        _nTPRetailOffer = Convert.ToDouble(reader["TPRetailOffer"].ToString());
                    else _nTPRetailOffer = 0;

                    if (reader["TPDBIncentive"] != DBNull.Value)
                        _nTPDBIncentive = Convert.ToDouble(reader["TPDBIncentive"].ToString());
                    else _nTPDBIncentive = 0;

                    if (reader["TPTeamIncentive"] != DBNull.Value)
                        _nTPTeamIncentive = Convert.ToDouble(reader["TPTeamIncentive"].ToString());
                    else _nTPTeamIncentive = 0;

                    if (reader["TPYearlyIncentive"] != DBNull.Value)
                        _nTPYearlyIncentive = Convert.ToDouble(reader["TPYearlyIncentive"].ToString());
                    else _nTPYearlyIncentive = 0;

                    if (reader["Royality"] != DBNull.Value)
                        _nRoyality = Convert.ToDouble(reader["Royality"].ToString());
                    else _nRoyality = 0;

                    if (reader["DistributorTax"] != DBNull.Value)
                        _nDistributorTax = Convert.ToDouble(reader["DistributorTax"].ToString());
                    else _nDistributorTax = 0;

                    _dEffectiveDate = (DateTime)reader["EffectiveDate"];
                    _nIsCurrent = (int)reader["IsCurrent"];

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
                _bFlag = false;
            }
            else
            {
                _bFlag = true;
            }
        }

        public bool ERPCodeCheck(string txterpcode)
        {
            int Count = 0;
            string mapcode = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_MapERPProduct where ProductERPCode='" + txterpcode + @"' ";
            cmd.Parameters.AddWithValue("ProductERPCode", _sProductCode);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Count++;
                }
                reader.Close();
                if (Count == 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void RefreshSmartWarrantyItem()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_ExtendedWarrantyItem where ProductID=? and IsCurrent=1 and SmartWarrantyTenure = ?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SmartWarrantyTenure", _nSmartWarrantyTenure);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPriceID = (int)reader["SmartWarrantyID"];
                    _nProductID = (int)reader["ProductID"];
                    _nSmartWarrantyTenure = (int)reader["SmartWarrantyTenure"];
                    _nNetPrice = (double)reader["NetPrice"];
                    _nCommission= (double)reader["Commission"];
                    _dEffectiveDate = (DateTime)reader["EffectiveDate"];

                    if (reader["Remarks"] != DBNull.Value)
                        _sRemarks = (reader["Remarks"].ToString());
                    else _sRemarks = "";
                    _dCreateDate = (DateTime)reader["CreateDate"];
                    _nEntryUserID = Convert.ToInt32(reader["CreateUserID"].ToString());
                   _nIsCurrent = (int)reader["IsCurrent"];


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
                _bFlag = false;
            }
            else
            {
                _bFlag = true;
            }
        }

        public void Add()
        {
            int nMaxPriceID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([PriceID]) FROM t_FinishedGoodsPrice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPriceID = 1;
                }
                else
                {
                    nMaxPriceID = Convert.ToInt32(maxID) + 1;
                }
                _nPriceID = nMaxPriceID;


                //sSql = "INSERT INTO t_FinishedGoodsPrice"
                //    + "(PriceID,ProductID,EffectiveDate,CostPrice,TradePrice,NSP,RSP,"
                //    + "SpecialPrice,DistributorPrice,VAT,IsCurrent,UploadStatus,UploadDate,DownloadDate,"
                //    + "RowStatus,Terminal,EntryUserID)"
                //    + " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                sSql = "INSERT INTO t_FinishedGoodsPrice"
                    + "(PriceID,ProductID,EffectiveDate,CostPrice,TradePrice,NSP,RSP,"
                    + "SpecialPrice,DistributorPrice,VAT,IsCurrent,"
                    + "EntryUserID,Remarks,UploadDate,MC,VATCP)"
                    + " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PriceID", _nPriceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("CostPrice", _nCostPrice);

                cmd.Parameters.AddWithValue("TradePrice", _nTradePrice);
                cmd.Parameters.AddWithValue("NSP", _nNSP);

                cmd.Parameters.AddWithValue("RSP", _nRSP);

                cmd.Parameters.AddWithValue("SpecialPrice", _nSpecialPrice);
                cmd.Parameters.AddWithValue("DistributorPrice", _dDistributorPrice);
                cmd.Parameters.AddWithValue("VAT", _dVAT);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                //cmd.Parameters.AddWithValue("UploadStatus", _nUploadStatus);

                //cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);
                //cmd.Parameters.AddWithValue("DownloadDate", _dDownloadDate);
                //cmd.Parameters.AddWithValue("RowStatus", _nRowStatus);
                //cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("EntryUserID", _nEntryUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);
                cmd.Parameters.AddWithValue("MC", _MC);
                cmd.Parameters.AddWithValue("VATCP", _VATCP);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddMC()
        {
            int nMaxMCSetupID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([MCSetupID]) FROM TestTELAddDB.dbo.t_SKUwiseMCData";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMCSetupID = 1;
                }
                else
                {
                    nMaxMCSetupID = Convert.ToInt32(maxID) + 1;
                }
                _nMCSetupID = nMaxMCSetupID;

                sSql = "Insert into TestTELAddDB.dbo.t_SKUwiseMCData values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MCSetupID", _nMCSetupID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ERPCode", _sERPCode);
                cmd.Parameters.AddWithValue("COGS", _nCOGS);
                cmd.Parameters.AddWithValue("FreightCost", _nFreightCost);
                cmd.Parameters.AddWithValue("Replacement", _nReplacement);
                cmd.Parameters.AddWithValue("Advertisement", _nAdvertisement);
                cmd.Parameters.AddWithValue("VCMaterial", _nVCMaterial);
                cmd.Parameters.AddWithValue("VCVariableFactory", _nVCVariableFactory);
                cmd.Parameters.AddWithValue("VCDirectLabor", _nVCDirectLabor);
                cmd.Parameters.AddWithValue("TPRetailOffer", _nTPRetailOffer);
                cmd.Parameters.AddWithValue("TPDBIncentive", _nTPDBIncentive);
                cmd.Parameters.AddWithValue("TPTeamIncentive", _nTPTeamIncentive);
                cmd.Parameters.AddWithValue("TPYearlyIncentive", _nTPYearlyIncentive);
                cmd.Parameters.AddWithValue("Royality", _nRoyality);
                cmd.Parameters.AddWithValue("DistributorTax", _nDistributorTax);

                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);

                //cmd.Parameters.AddWithValue("UploadStatus", _nUploadStatus);

                //cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);
                //cmd.Parameters.AddWithValue("DownloadDate", _dDownloadDate);
                //cmd.Parameters.AddWithValue("RowStatus", _nRowStatus);
                //cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                //cmd.Parameters.AddWithValue("EntryUserID", _nEntryUserID);
                //cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                //cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);
                //cmd.Parameters.AddWithValue("MC", _MC);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddforBLLMC()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Insert into testteladddb.dbo.t_SKUwiseMCData values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ERPCode", _sERPCode);
                cmd.Parameters.AddWithValue("RSP", _nRSP);
                cmd.Parameters.AddWithValue("NSP", _nNSP);
                cmd.Parameters.AddWithValue("COGS", _nCOGS);
                cmd.Parameters.AddWithValue("FreightCost", _nFreightCost);
                cmd.Parameters.AddWithValue("Replacement", _nReplacement);
                cmd.Parameters.AddWithValue("Advertisement", _nAdvertisement);
                cmd.Parameters.AddWithValue("VCMaterial", _nVCMaterial);
                cmd.Parameters.AddWithValue("VCVariableFactory", _nVCVariableFactory);
                cmd.Parameters.AddWithValue("VCDirectLabor", _nVCDirectLabor);
                cmd.Parameters.AddWithValue("TPRetailOffer", _nTPRetailOffer);
                cmd.Parameters.AddWithValue("TPDBIncentive", _nTPDBIncentive);
                cmd.Parameters.AddWithValue("TPTeamIncentive", _nTPTeamIncentive);
                cmd.Parameters.AddWithValue("TPYearlyIncentive", _nTPYearlyIncentive);
                cmd.Parameters.AddWithValue("Royality", _nRoyality);
                cmd.Parameters.AddWithValue("DistributorTax", _nDistributorTax);
                cmd.Parameters.AddWithValue("GM", 0);
                cmd.Parameters.AddWithValue("MC", 0);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void UpdateforBLLMC(string ProductCode)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "Insert into testteladddb.dbo.t_SKUwiseMCData values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
        //        cmd.Parameters.AddWithValue("ERPCode", _sERPCode);
        //        cmd.Parameters.AddWithValue("RSP", _nRSP);
        //        cmd.Parameters.AddWithValue("NSP", _nNSP);
        //        cmd.Parameters.AddWithValue("COGS", _nCOGS);
        //        cmd.Parameters.AddWithValue("FreightCost", _nFreightCost);
        //        cmd.Parameters.AddWithValue("Replacement", _nReplacement);
        //        cmd.Parameters.AddWithValue("Advertisement", _nAdvertisement);
        //        cmd.Parameters.AddWithValue("VCMaterial", _nVCMaterial);
        //        cmd.Parameters.AddWithValue("VCVariableFactory", _nVCVariableFactory);
        //        cmd.Parameters.AddWithValue("VCDirectLabor", _nVCDirectLabor);
        //        cmd.Parameters.AddWithValue("TPRetailOffer", _nTPRetailOffer);
        //        cmd.Parameters.AddWithValue("TPDBIncentive", _nTPDBIncentive);
        //        cmd.Parameters.AddWithValue("TPTeamIncentive", _nTPTeamIncentive);
        //        cmd.Parameters.AddWithValue("TPYearlyIncentive", _nTPYearlyIncentive);
        //        cmd.Parameters.AddWithValue("Royality", _nRoyality);
        //        cmd.Parameters.AddWithValue("DistributorTax", _nDistributorTax);
        //        cmd.Parameters.AddWithValue("GM", 0);
        //        cmd.Parameters.AddWithValue("MC", 0);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void AddSmartWarrantyItem()
        {
            int nMaxPriceID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SmartWarrantyID]) FROM t_ExtendedWarrantyItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPriceID = 1;
                }
                else
                {
                    nMaxPriceID = Convert.ToInt32(maxID) + 1;
                }
                _nPriceID = nMaxPriceID;


                sSql = "INSERT INTO t_ExtendedWarrantyItem (SmartWarrantyID,ProductID,SmartWarrantyTenure,NetPrice,Commission,  " +
                        "EffectiveDate,Remarks,CreateDate,CreateUserID,UpdateDate,UpdateUserID,IsCurrent) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SmartWarrantyID", _nPriceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SmartWarrantyTenure", _nSmartWarrantyTenure);
                cmd.Parameters.AddWithValue("NetPrice", _nNetPrice);
                cmd.Parameters.AddWithValue("Commission", _nCommission);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);                
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddCACPrice()
        {
            int nMaxPriceID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([PriceID]) FROM t_CACFinishedGoodsPrice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPriceID = 1;
                }
                else
                {
                    nMaxPriceID = Convert.ToInt32(maxID) + 1;
                }
                _nPriceID = nMaxPriceID;


                sSql = "INSERT INTO t_CACFinishedGoodsPrice (PriceID, ProductID, EffectiveDate, CPUSD, CPBDT, RSP,  " +
                       "IsCurrent, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PriceID", _nPriceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("CPUSD", _CPUSD);
                cmd.Parameters.AddWithValue("CPBDT", _CPBDT);
                cmd.Parameters.AddWithValue("RSP", _nRSP);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);

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

                sSql = "UPDATE t_FinishedGoodsPrice SET ProductID=?,EffectiveDate=?,CostPrice=?,TradePrice=?,NSP=?,"
                    + "RSP=?,SpecialPrice=?,DistributorPrice=?,VAT=?,IsCurrent=?,UploadStatus=?,"
                    + "UploadDate=?,DownloadDate=?,RowStatus=?,Terminal=?,EntryUserID=?"
                    + " WHERE PriceID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("CostPrice", _nCostPrice);

                cmd.Parameters.AddWithValue("TradePrice", _nTradePrice);
                cmd.Parameters.AddWithValue("NSP", _nNSP);

                cmd.Parameters.AddWithValue("RSP", _nRSP);

                cmd.Parameters.AddWithValue("SpecialPrice", _nSpecialPrice);
                cmd.Parameters.AddWithValue("DistributorPrice", _dDistributorPrice);
                cmd.Parameters.AddWithValue("VAT", _dVAT);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                cmd.Parameters.AddWithValue("UploadStatus", _nUploadStatus);

                cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);
                cmd.Parameters.AddWithValue("DownloadDate", _dDownloadDate);
                cmd.Parameters.AddWithValue("RowStatus", _nRowStatus);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("EntryUserID", _nEntryUserID);

                cmd.Parameters.AddWithValue("PriceID", _nPriceID);

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
                sSql = "DELETE FROM t_FinishedGoodsPrice WHERE [PriceID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PriceID", _nPriceID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

    }

    public class ProductPrices : CollectionBase
    {
        public ProductPrice this[int i]
        {
            get { return (ProductPrice)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductPrice oProductPrice)
        {
            InnerList.Add(oProductPrice);
        }

        public void ResetIsCurrent(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_FinishedGoodsPrice SET IsCurrent=0 WHERE [ProductID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void ResetIsCurrentMC(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE TestTELAddDB.dbo.t_SKUwiseMCData SET IsCurrent=0 WHERE [ProductID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void ResetIsCurrentSmartWarranty(int nProductID,int nSmartWarrantyTenure)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_ExtendedWarrantyItem SET IsCurrent=0 WHERE [ProductID]=? and [SmartWarrantyTenure]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("SmartWarrantyTenure", nSmartWarrantyTenure);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void ResetCACIsCurrent(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_CACFinishedGoodsPrice SET IsCurrent=0 WHERE [ProductID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void Refresh(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_FinishedGoodsPrice WHERE ProductID=? Order by EffectiveDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductPrice oProductPrice = new ProductPrice();

                    oProductPrice.ProductID = (int)reader["ProductID"];
                    oProductPrice.EffectiveDate = (DateTime)reader["EffectiveDate"];
                    oProductPrice.CostPrice = (double)reader["CostPrice"];
                    
                    if (reader["TradePrice"] != DBNull.Value)
                        oProductPrice.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else oProductPrice.TradePrice = 0;

                    oProductPrice.NSP = (double)reader["NSP"];
                    oProductPrice.RSP = (double)reader["RSP"];

                    if (reader["SpecialPrice"] != DBNull.Value)
                        oProductPrice.SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else oProductPrice.SpecialPrice = 0;

                    if (reader["DistributorPrice"] != DBNull.Value)
                        oProductPrice.DistributorPrice = Convert.ToDouble(reader["DistributorPrice"].ToString());
                    else oProductPrice.DistributorPrice = 0;

                    if (reader["VAT"] != DBNull.Value)
                        oProductPrice.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    else oProductPrice.VAT = 0;

                    if (reader["IsCurrent"] != DBNull.Value)
                        oProductPrice.IsCurrent = (int)reader["IsCurrent"];
                    else oProductPrice.IsCurrent = 0;
                    if (reader["MC"] != DBNull.Value)
                        oProductPrice.MC = Convert.ToDouble(reader["MC"].ToString());
                    else oProductPrice.MC = 0;

                    if (reader["VATCP"] != DBNull.Value)
                        oProductPrice.VATCP = Convert.ToDouble(reader["VATCP"].ToString());
                    else oProductPrice.VATCP = 0;


                    //oProductPrice.IsCurrent = (int)reader["IsCurrent"];
                    //oProductPrice.UploadStatus = (int)reader["UploadStatus"];
                    //oProductPrice.UploadDate = (DateTime)reader["UploadDate"];
                    //oProductPrice.DownloadDate = (DateTime)reader["DownloadDate"];
                    //oProductPrice.RowStatus = (int)reader["RowStatus"];
                    //oProductPrice.Terminal = (int)reader["Terminal"];
                    //oProductPrice.EntryUserID = (int)reader["EntryUserID"];
                    InnerList.Add(oProductPrice);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshforBLL(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @" Select *from TestTELAddDB.dbo.t_SKUwiseMCData
                            where ProductID=?  order by EffectiveDate desc";

            //string sSql = @"Select Main.*,ERPCode,COGS,VCMaterial,VCVariableFactory,VCDirectLabor,FreightCost,Replacement,Advertisement,TPRetailOffer,TPDBIncentive,
            //                TPTeamIncentive,TPYearlyIncentive,Royality,DistributorTax
            //                from
            //                (
            //                SELECT * FROM t_FinishedGoodsPrice 
            //                ) as Main
            //                left outer join
            //                (
            //                select ProductID,ERPCode,COGS,VCMaterial,VCVariableFactory,VCDirectLabor,FreightCost,Replacement,Advertisement,TPRetailOffer,TPDBIncentive,
            //                TPTeamIncentive,TPYearlyIncentive,Royality,DistributorTax
            //                from teladddb.dbo.t_SKUwiseMCData a, v_ProductDetails b
            //                where a.ProductCode=b.ProductCode
            //                ) as mc on Main.ProductID=mc.ProductID
            //                where Main.ProductID=? 
            //                order by EffectiveDate desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductPrice oProductPrice = new ProductPrice();

                    oProductPrice.ProductID = (int)reader["ProductID"];
                    if (reader["ERPCode"] != DBNull.Value)
                        oProductPrice.ERPCode = (reader["ERPCode"].ToString());
                    else oProductPrice.ERPCode = null;

                    if (reader["COGS"] != DBNull.Value)
                        oProductPrice.COGS = Convert.ToDouble(reader["COGS"].ToString());
                    else oProductPrice.COGS = 0;

                    if (reader["VCMaterial"] != DBNull.Value)
                        oProductPrice.VCMaterial = Convert.ToDouble(reader["VCMaterial"].ToString());
                    else oProductPrice.VCMaterial = 0;

                    if (reader["VCVariableFactory"] != DBNull.Value)
                        oProductPrice.VCVariableFactory = Convert.ToDouble(reader["VCVariableFactory"].ToString());
                    else oProductPrice.VCVariableFactory = 0;

                    if (reader["VCDirectLabor"] != DBNull.Value)
                        oProductPrice.VCDirectLabor = Convert.ToDouble(reader["VCDirectLabor"].ToString());
                    else oProductPrice.VCDirectLabor = 0;

                    if (reader["FreightCost"] != DBNull.Value)
                        oProductPrice.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    else oProductPrice.FreightCost = 0;

                    if (reader["Replacement"] != DBNull.Value)
                        oProductPrice.Replacement = Convert.ToDouble(reader["Replacement"].ToString());
                    else oProductPrice.Replacement = 0;

                    if (reader["Advertisement"] != DBNull.Value)
                        oProductPrice.Advertisement = Convert.ToDouble(reader["Advertisement"].ToString());
                    else oProductPrice.Advertisement = 0;

                    if (reader["TPRetailOffer"] != DBNull.Value)
                        oProductPrice.TPRetailOffer = Convert.ToDouble(reader["TPRetailOffer"].ToString());
                    else oProductPrice.TPRetailOffer = 0;

                    if (reader["TPDBIncentive"] != DBNull.Value)
                        oProductPrice.TPDBIncentive = Convert.ToDouble(reader["TPDBIncentive"].ToString());
                    else oProductPrice.TPDBIncentive = 0;

                    if (reader["TPTeamIncentive"] != DBNull.Value)
                        oProductPrice.TPTeamIncentive = Convert.ToDouble(reader["TPTeamIncentive"].ToString());
                    else oProductPrice.TPTeamIncentive = 0;

                    if (reader["TPYearlyIncentive"] != DBNull.Value)
                        oProductPrice.TPYearlyIncentive = Convert.ToDouble(reader["TPYearlyIncentive"].ToString());
                    else oProductPrice.TPYearlyIncentive = 0;

                    if (reader["Royality"] != DBNull.Value)
                        oProductPrice.Royality = Convert.ToDouble(reader["Royality"].ToString());
                    else oProductPrice.Royality = 0;

                    if (reader["DistributorTax"] != DBNull.Value)
                        oProductPrice.DistributorTax = Convert.ToDouble(reader["DistributorTax"].ToString());
                    else oProductPrice.DistributorTax = 0;

                    oProductPrice.EffectiveDate = (DateTime)reader["EffectiveDate"];

                    if (reader["IsCurrent"] != DBNull.Value)
                        oProductPrice.IsCurrent = (int)reader["IsCurrent"];
                    else oProductPrice.IsCurrent = 0;


                    //oProductPrice.IsCurrent = (int)reader["IsCurrent"];
                    //oProductPrice.UploadStatus = (int)reader["UploadStatus"];
                    //oProductPrice.UploadDate = (DateTime)reader["UploadDate"];
                    //oProductPrice.DownloadDate = (DateTime)reader["DownloadDate"];
                    //oProductPrice.RowStatus = (int)reader["RowStatus"];
                    //oProductPrice.Terminal = (int)reader["Terminal"];
                    //oProductPrice.EntryUserID = (int)reader["EntryUserID"];

                    InnerList.Add(oProductPrice);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void ERPCodeCheck(int nProductID)
        //{
        //    InnerList.Clear();

        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = @" Select ProductERPCode as ERPCode  from t_MapERPProduct a, t_product b 
        //                     where a.productcode=b.productcode and ProductID=?";

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.Parameters.AddWithValue("ProductID", nProductID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ProductPrice oProductPrice = new ProductPrice();

        //            oProductPrice.ProductID = (int)reader["ProductID"];
        //            if (reader["ERPCode"] != DBNull.Value)
        //                oProductPrice.ERPCode = (reader["ERPCode"].ToString());
        //            else oProductPrice.ERPCode = null;


        //            InnerList.Add(oProductPrice);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        public void RefreshSmartWarrantyItem(int nProductID,int nSmartWarrantyTenure)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ExtendedWarrantyItem WHERE ProductID=? and SmartWarrantyTenure = ? Order by EffectiveDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("SmartWarrantyTenure", nSmartWarrantyTenure);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductPrice oProductPrice = new ProductPrice();

                    oProductPrice.ProductID = (int)reader["ProductID"];
                    oProductPrice.EffectiveDate = (DateTime)reader["EffectiveDate"];
                    oProductPrice.NetPrice = (double)reader["NetPrice"];
                    oProductPrice.Commission = (double)reader["Commission"];
                    oProductPrice.EntryUserID = (int)reader["CreateUserID"];
                    oProductPrice.CreateDate = (DateTime)reader["CreateDate"];
                    oProductPrice.SmartWarrantyTenure = (int)reader["SmartWarrantyTenure"];
                    if (reader["IsCurrent"] != DBNull.Value)
                        oProductPrice.IsCurrent = (int)reader["IsCurrent"];
                    else oProductPrice.IsCurrent = 0;
                    InnerList.Add(oProductPrice);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshCACPrice(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT PriceID,ProductID,EffectiveDate,isnull(CPUSD,0) CPUSD,isnull(CPBDT,0) CPBDT, " +
                        "RSP,IsCurrent,CreateDate,CreateUserID FROM t_CACFinishedGoodsPrice WHERE ProductID=" + nProductID + "  " +
                        "Order by EffectiveDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductPrice oProductPrice = new ProductPrice();

                    oProductPrice.ProductID = (int)reader["ProductID"];
                    oProductPrice.EffectiveDate = (DateTime)reader["EffectiveDate"];
                    oProductPrice.CPBDT = (double)reader["CPBDT"];
                    oProductPrice.CPUSD = (double)reader["CPUSD"];
                    oProductPrice.RSP = (double)reader["RSP"];
                    if (reader["IsCurrent"] != DBNull.Value)
                        oProductPrice.IsCurrent = (int)reader["IsCurrent"];
                    else oProductPrice.IsCurrent = 0;

                   InnerList.Add(oProductPrice);
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
