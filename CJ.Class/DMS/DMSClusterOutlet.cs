using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class DMSClusterOutlet
    {
        private int _nRetailID;
        private int _RetailID_TempTable;
        private int _CustomerID;
        private int _nRouteID;
        private string _sRetailName;
        private string _sRetailAddress;
        private string _sThanaNameSurvey;
        private string _sDistrictName;
        private string _sTownName;
        private string _sThanaName;
        private string _sTownType;
        private int _nTownRankID;
        private string _sAdmin;
        private string _sProprietorName;
        private string _sMarketName;
        private string _sMarketType;
        private string _sMarketLocation;
        private int _nRetailTypeID;
        private string _sRetailType;
        private string _sRetailTypeShort;
        private string _sMobile1;
        private string _sMobile2;
        private string _sMobile3;
        private string _sTNT;
        private string _nMapSerialNo;
        private int _nSlabOutlet;
        private string _sProductAvail;
        private int _nIsActive;
        private string _sElectricianName;
        private string _sElectricianContactNo;
        private double _MinPotential;
        private decimal _Latitude;
        private decimal _Longitude;
        private bool _nIsLocationConfirm;
        private string _sTier;
        private int _nRetailGroupID;

        public int RetailID
        {
            get {return _nRetailID;}
            set { _nRetailID = value; }             
            
        }
        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }

            set
            {
                _CustomerID = value;
            }
        }
        public int RouteID
        {
            get
            {
                return _nRouteID;
            }

            set
            {
                _nRouteID = value;
            }
        }
        public string RetailName
        {
            get
            {
                return _sRetailName;
            }

            set
            {
                _sRetailName = value;
            }
        }
        public string RetailAddress
        {
            get
            {
                return _sRetailAddress;
            }

            set
            {
                _sRetailAddress = value;
            }
        }
        public string ThanaNameSurvey
        {
            get
            {
                return _sThanaNameSurvey;
            }

            set
            {
                _sThanaNameSurvey = value;
            }
        }
        public string DistrictName
        {
            get
            {
                return _sDistrictName;
            }

            set
            {
                _sDistrictName = value;
            }
        }
        public string TownName
        {
            get
            {
                return _sTownName;
            }

            set
            {
                _sTownName = value;
            }
        }
        public string ThanaName
        {
            get
            {
                return _sThanaName;
            }

            set
            {
                _sThanaName = value;
            }
        }
        public string TownType
        {
            get
            {
                return _sTownType;
            }

            set
            {
                _sTownType = value;
            }
        }
        public int TownRankID
        {
            get
            {
                return _nTownRankID;
            }

            set
            {
                _nTownRankID = value;
            }
        }
        public string Admin
        {
            get
            {
                return _sAdmin;
            }

            set
            {
                _sAdmin = value;
            }
        }
        public string ProprietorName
        {
            get
            {
                return _sProprietorName;
            }

            set
            {
                _sProprietorName = value;
            }
        }
        public string MarketName
        {
            get
            {
                return _sMarketName;
            }

            set
            {
                _sMarketName = value;
            }
        }
        public string MarketType
        {
            get
            {
                return _sMarketType;
            }

            set
            {
                _sMarketType = value;
            }
        }
        public string MarketLocation
        {
            get
            {
                return _sMarketLocation;
            }

            set
            {
                _sMarketLocation = value;
            }
        }
        public int RetailTypeID
        {
            get
            {
                return _nRetailTypeID;
            }

            set
            {
                _nRetailTypeID = value;
            }
        }
        public string RetailType
        {
            get
            {
                return _sRetailType;
            }

            set
            {
                _sRetailType = value;
            }
        }
        public string RetailTypeShort
        {
            get
            {
                return _sRetailTypeShort;
            }

            set
            {
                _sRetailTypeShort = value;
            }
        }
        public string Mobile01
        {
            get
            {
                return _sMobile1;
            }

            set
            {
                _sMobile1 = value;
            }
        }
        public string Mobile02
        {
            get
            {
                return _sMobile2;
            }

            set
            {
                _sMobile2 = value;
            }
        }
        public string Mobile03
        {
            get
            {
                return _sMobile3;
            }

            set
            {
                _sMobile3 = value;
            }
        }
        public string TNT
        {
            get
            {
                return _sTNT;
            }

            set
            {
                _sTNT = value;
            }
        }
        public string MapSerialno
        {
            get
            {
                return _nMapSerialNo;
            }

            set
            {
                _nMapSerialNo = value;
            }
        }
        public int SlabOutlet
        {
            get
            {
                return _nSlabOutlet;
            }

            set
            {
                _nSlabOutlet = value;
            }
        }
        public string ProductAvail
        {
            get
            {
                return _sProductAvail;
            }

            set
            {
                _sProductAvail = value;
            }
        }
        public int IsActive
        {
            get
            {
                return _nIsActive;
            }

            set
            {
                _nIsActive = value;
            }
        }
        public string ElectricianName
        {
            get
            {
                return _sElectricianName;
            }

            set
            {
                _sElectricianName = value;
            }
        }
        public string ElectricianContactNo
        {
            get
            {
                return _sElectricianContactNo;
            }

            set
            {
                _sElectricianContactNo = value;
            }
        }
        public double MinPotential
        {
            get
            {
                return _MinPotential;
            }

            set
            {
                _MinPotential = value;
            }
        }
        public decimal Latitude
        {
            get
            {
                return _Latitude;
            }

            set
            {
                _Latitude = value;
            }
        }
        public decimal Longitude
        {
            get
            {
                return _Longitude;
            }

            set
            {
                _Longitude = value;
            }
        }
        public bool IsLocationConfirm
        {
            get
            {
                return _nIsLocationConfirm;
            }

            set
            {
                _nIsLocationConfirm = value;
            }
        }
        public string Tier
        {
            get
            {
                return _sTier;
            }

            set
            {
                _sTier = value;
            }
        }
        public int RetailGroupID
        {
            get
            {
                return _nRetailGroupID;
            }

            set
            {
                _nRetailGroupID = value;
            }
        }

        public int RetailID_TempTable
        {
            get
            {
                return _RetailID_TempTable;
            }

            set
            {
                _RetailID_TempTable = value;
            }
        }

        public void Add()
        {
            int nMaxRetailID = 0;
           
            string sSql = "";
            try
            {
                DBController.Instance.OpenNewConnection();
                OleDbCommand cmd = DBController.Instance.GetCommand();
               // DBController.Instance.BeginNewTransaction();
                sSql = "SELECT MAX([RetailID]) FROM t_DMSClusterOutlet";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxRetailID = 1;
                }
                else
                {
                    nMaxRetailID = Convert.ToInt32(maxID) + 1;
                }
                RetailID = nMaxRetailID;
                sSql = @"INSERT INTO t_DMSClusterOutlet(RetailID,CustomerID,RouteID,RetailName,RetailAddress,ThanaNameSurvey,DistrictName,TownName,ThanaName,TownType,TownRankID,Admin,
                        ProprietorName,MarketName,MarketType,MarketLocation,RetailTypeID,RetailType,
                        RetailTypeShort,Mobile01,Mobile02,Mobile03,TNT,MapSerialno,SlabOutlet,ProductAvail,IsActive,ElectricianName,ElectricianContactNo
                       ,MinPotential,Latitude,Longitude,IsLocationConfirm,Tier,RetailGroupID)
                         VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RetailID", RetailID);
                cmd.Parameters.AddWithValue("CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("RouteID", RouteID);
                cmd.Parameters.AddWithValue("RetailName", RetailName);
                cmd.Parameters.AddWithValue("RetailAddress", RetailAddress);
                cmd.Parameters.AddWithValue("ThanaNameSurvey", ThanaNameSurvey);
                cmd.Parameters.AddWithValue("DistrictName", DistrictName);
                cmd.Parameters.AddWithValue("TownName", TownName);
                cmd.Parameters.AddWithValue("ThanaName", ThanaName);
                cmd.Parameters.AddWithValue("TownType", TownType);
                cmd.Parameters.AddWithValue("TownRankID", TownRankID);
                cmd.Parameters.AddWithValue("Admin", Admin);
                cmd.Parameters.AddWithValue("ProprietorName", ProprietorName);
                cmd.Parameters.AddWithValue("MarketName", MarketName);
                cmd.Parameters.AddWithValue("MarketType", MarketType);
                cmd.Parameters.AddWithValue("MarketLocation", MarketLocation);
                cmd.Parameters.AddWithValue("RetailTypeID", RetailTypeID);
                cmd.Parameters.AddWithValue("RetailType", RetailType);
                cmd.Parameters.AddWithValue("RetailTypeShort", RetailTypeShort);
                cmd.Parameters.AddWithValue("Mobile01", Mobile01);
                cmd.Parameters.AddWithValue("Mobile02", Mobile02);
                cmd.Parameters.AddWithValue("Mobile03", Mobile03);
                cmd.Parameters.AddWithValue("TNT", TNT);
                cmd.Parameters.AddWithValue("MapSerialno", MapSerialno);
                cmd.Parameters.AddWithValue("SlabOutlet", SlabOutlet);
                cmd.Parameters.AddWithValue("ProductAvail", ProductAvail);
                cmd.Parameters.AddWithValue("IsActive", IsActive);
                cmd.Parameters.AddWithValue("ElectricianName", ElectricianName);
                cmd.Parameters.AddWithValue("ElectricianContactNo", ElectricianContactNo);
                cmd.Parameters.AddWithValue("MinPotential", MinPotential);
                cmd.Parameters.AddWithValue("Latitude", Latitude);
                cmd.Parameters.AddWithValue("Longitude", Longitude);
                cmd.Parameters.AddWithValue("IsLocationConfirm", IsLocationConfirm);
                cmd.Parameters.AddWithValue("Tier", Tier);
                cmd.Parameters.AddWithValue("RetailGroupID", RetailGroupID);

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
            string sSql = "";
            try
            {
                sSql = @"update t_DMSCLusterOutletTemp set Isapproved=1 where RetailID="+RetailID_TempTable+"";
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

       
    }
}
