// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Feb 29, 2012
// Time :  11:00 AM
// Description: Offical Price List [105]
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    public class RptOficialPriceList
    {
        public int _nPGID;
        public string _sPGCode;
        public string _sPGName;

        public int _nMAGID;
        public string _sMAGCode;
        public string _sMAGName;

        public int _nASGID;
        public string _sASGCode;
        public string _sASGName;

        public int _nAGID;
        public string _sAGCode;
        public string _sAGName;

        public int _nProductID;
        public string _sProductCode;
        public string _sProductName;

        public int _nBrandID;
        public string _sBrandCode;
        public string _sBrandName;       

        public double _sUOMConversionFactor;
        public string _sSmallUnitofMeasure;
        public string _sLargeUnitOfMeasure;
        public double _NSP;
        public double _RSP;
        public int _nIsActive;
        public double _VATApplicable;
        public int _nProductType;

        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        public string PGCode
        {
            get { return _sPGCode; }
            set { _sPGCode = value; }
        }
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        public string MAGCode
        {
            get { return _sMAGCode; }
            set { _sMAGCode = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public int ASGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        public string ASGCode
        {
            get { return _sASGCode; }
            set { _sASGCode = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        public string AGCode
        {
            get { return _sAGCode; }
            set { _sAGCode = value; }
        }
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string BrandCode
        {
            get { return _sBrandCode; }
            set { _sBrandCode = value; }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public string BrandDesc
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public string SmallUnitofMeasure
        {
            get { return _sSmallUnitofMeasure; }
            set { _sSmallUnitofMeasure = value; }
        }
        
        public string LargeUnitOfMeasure
        {
            get { return _sLargeUnitOfMeasure; }
            set { _sLargeUnitOfMeasure = value; }
        }        

        public double UOMConversionFactor
        {
            get { return _sUOMConversionFactor; }
            set { _sUOMConversionFactor = value; }
        }

        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }

        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }

        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public double VATApplicable
        {
            get { return _VATApplicable; }
            set { _VATApplicable = value; }
        }
        public int ProductType
        {
            get { return _nProductType; }
            set { _nProductType = value; }
        }
        
    }

    public class RptOficialPriceListDetails : CollectionBaseCustom
    {
        public void Add(RptOficialPriceList oRptOficialPriceList)
        {
            this.List.Add(oRptOficialPriceList);
        }

        public RptOficialPriceList this[Int32 Index]
        {
            get
            {
                return (RptOficialPriceList)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptOficialPriceList))))
                {
                    throw new Exception(" Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void OfficialPriceList()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for Official Price List [105]

            sQueryStringMaster.Append(" select ProductID, ProductCode, ProductName, PGID,PGCode, PGName, ");
            sQueryStringMaster.Append(" MAGID, MAGCode, MAGName, ASGID, ASGCode, ASGName,AGID, AGCode, AGName, BrandID, BrandCode, ");
            sQueryStringMaster.Append(" BrandDesc as BrandName, SmallUnitofMeasure, LargeUnitOfMeasure, UOMConversionFactor, NSP, RSP, IsActive, VATApplicable, ProductType from v_ProductDetails ");

            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();
            GetOfficialPriceList(cmd);

        }

        public void GetOfficialPriceList(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptOficialPriceList oItem = new RptOficialPriceList();

                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID = (int)reader["PGID"];
                    else oItem.PGID = -1;

                    if (reader["PGCode"] != DBNull.Value)
                        oItem.PGCode = (string)reader["PGCode"];
                    else oItem.PGCode = "";

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGID"] != DBNull.Value)
                        oItem.MAGID = (int)reader["MAGID"];
                    else oItem.MAGID = -1;

                    if (reader["MAGCode"] != DBNull.Value)
                        oItem.MAGCode = (string)reader["MAGCode"];
                    else oItem.MAGCode = "";

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = (int)reader["ASGID"];
                    else oItem.ASGID = -1;

                    if (reader["ASGCode"] != DBNull.Value)
                        oItem.ASGCode = (string)reader["ASGCode"];
                    else oItem.ASGCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = (int)reader["AGID"];
                    else oItem.AGID = -1;

                    if (reader["AGCode"] != DBNull.Value)
                        oItem.AGCode = (string)reader["AGCode"];
                    else oItem.AGCode = "";

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = (int)reader["BrandID"];
                    else oItem.BrandID = -1;

                    if (reader["BrandCode"] != DBNull.Value)
                        oItem.BrandCode = (string)reader["BrandCode"];
                    else oItem.BrandCode = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandDesc = (string)reader["BrandName"];
                    else oItem.BrandDesc = "";

                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = 0;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["SmallUnitofMeasure"] != DBNull.Value)
                        oItem.SmallUnitofMeasure = (string)reader["SmallUnitofMeasure"];
                    else oItem.SmallUnitofMeasure = "";

                    if (reader["LargeUnitOfMeasure"] != DBNull.Value)
                        oItem.LargeUnitOfMeasure = (string)reader["LargeUnitOfMeasure"];
                    else oItem.LargeUnitOfMeasure = "";

                    if (reader["UOMConversionFactor"] != DBNull.Value)
                        oItem.UOMConversionFactor = Convert.ToDouble(reader["UOMConversionFactor"]);
                    else oItem.UOMConversionFactor = 0;

                    if (reader["NSP"] != DBNull.Value)
                        oItem.NSP = Convert.ToDouble(reader["NSP"]);
                    else oItem.NSP = 0;

                    if (reader["RSP"] != DBNull.Value)
                        oItem.RSP = Convert.ToDouble(reader["RSP"]);
                    else oItem.RSP = 0;

                    if (reader["IsActive"] != DBNull.Value)
                        oItem.IsActive = Convert.ToInt32(reader["IsActive"]);
                    else oItem.IsActive = 0;

                    if (reader["VATApplicable"] != DBNull.Value)
                        oItem.VATApplicable = Convert.ToDouble(reader["VATApplicable"]);
                    else oItem.VATApplicable = 0;

                    if (reader["ProductType"] != DBNull.Value)
                        oItem.ProductType = Convert.ToInt32(reader["ProductType"]);
                    else oItem.ProductType = 0;
                    
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

        public void FromDataSetOfficialPriceList(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptOficialPriceList oRptOficialPriceList = new RptOficialPriceList();

                    oRptOficialPriceList.PGID = Convert.ToInt32(oRow["PGID"].ToString());
                    oRptOficialPriceList.PGCode = (string)oRow["PGCode"];
                    oRptOficialPriceList.PGName = (string)oRow["PGName"];

                    oRptOficialPriceList.MAGID = Convert.ToInt32(oRow["MAGId"].ToString());
                    oRptOficialPriceList.MAGCode = (string)oRow["MAGCode"];
                    oRptOficialPriceList.MAGName = (string)oRow["MAGName"];

                    oRptOficialPriceList.ASGID = Convert.ToInt32(oRow["ASGId"].ToString());
                    oRptOficialPriceList.ASGCode = (string)oRow["ASGCode"];
                    oRptOficialPriceList.ASGName = (string)oRow["ASGName"];

                    oRptOficialPriceList.AGID = Convert.ToInt32(oRow["AGID"].ToString());
                    oRptOficialPriceList.AGCode = (string)oRow["AGCode"];
                    oRptOficialPriceList.AGName = (string)oRow["AGName"];

                    oRptOficialPriceList.ProductID = Convert.ToInt32(oRow["ProductID"].ToString());
                    oRptOficialPriceList.ProductCode = (string)oRow["ProductCode"];
                    oRptOficialPriceList.ProductName = (string)oRow["ProductName"];

                    oRptOficialPriceList.BrandID = Convert.ToInt32(oRow["BrandID"].ToString());
                    oRptOficialPriceList.BrandCode = (string)oRow["BrandCode"];
                    oRptOficialPriceList.BrandName = (string)oRow["BrandName"];
                    oRptOficialPriceList.BrandDesc = (string)oRow["BrandName"];

                    oRptOficialPriceList.SmallUnitofMeasure = (string)oRow["SmallUnitofMeasure"];
                    oRptOficialPriceList.LargeUnitOfMeasure = (string)oRow["LargeUnitOfMeasure"];
                    oRptOficialPriceList.UOMConversionFactor =Convert.ToDouble( oRow["UOMConversionFactor"]);
                    oRptOficialPriceList.NSP = Convert.ToDouble( oRow["NSP"]);
                    oRptOficialPriceList.RSP = Convert.ToDouble (oRow["RSP"]);
                    oRptOficialPriceList.IsActive =Convert.ToInt32 (oRow["IsActive"]);
                    oRptOficialPriceList.VATApplicable = Convert.ToInt32(oRow["VATApplicable"]);
                    oRptOficialPriceList.ProductType = Convert.ToInt32(oRow["ProductType"]);
                    
                    InnerList.Add(oRptOficialPriceList);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }


}