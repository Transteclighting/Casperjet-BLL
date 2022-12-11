using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Data.OleDb;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;

public partial class jUserAuthentication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            /*string sUserName = c.Request.Form["UserName"].Trim();
            string sPassword = c.Request.Form["Password"].Trim();*/

            string sUserName = "kabedul";
            string sPassword = "123456";
            //358918058749541

            string sIMEI = "";
            string sSIMSerial = "";
            string sAndroidAppID = "";
            string sVersionNo = "";
            if (c.Request.Form["IMEI"] != null)
            {
                sIMEI = c.Request.Form["IMEI"].Trim();
            }
            if (c.Request.Form["SIMSerial"] != null)
            {
                sSIMSerial = c.Request.Form["SIMSerial"].Trim();
            }
            if (c.Request.Form["VersionNo"] != null)
            {
                sVersionNo = c.Request.Form["VersionNo"].Trim();
            }
            if (c.Request.Form["AndroidAppID"] != null)
            {
                sAndroidAppID = c.Request.Form["AndroidAppID"].Trim();
            }
            else
            {
                sAndroidAppID = Convert.ToString((int)Dictionary.AndroidAppID.CJ_Apps);
            }

            Datas _oDatas = new Datas();
            MarketGroups _oMarketGroups = new MarketGroups();
            BLLDistributors _oBLLDistributors = new BLLDistributors();
            TELProductGroups _oTELProductGroups = new TELProductGroups();
            TELBrands _oTELBrands = new TELBrands();
            BLLRetailTypes _oBLLRetailTypes = new BLLRetailTypes();
            string sOutput = "";

            Data oResponse = new Data();
            List<Data> eList = new List<Data>();
            List<Data> eListx = new List<Data>();

            DBController.Instance.OpenNewConnection();
            //eListx = _oDatas.Authentication(sUserName, sPassword, sIMEI, sSIMSerial);
            Data oData = new Data();

            TELLib _oTELLib = new TELLib();

            DateTime dFromDate = DateTime.Now.Date;
            int DayOfMonth = dFromDate.Day;
            DateTime dLastDateOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int TotalDayOfMonth = dLastDateOfMonth.Day;

            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);

            oData.Authentication(sUserName, sPassword, sIMEI, sSIMSerial, sAndroidAppID);
            oData.GetOtherInfo(sUserName, sIMEI);

            oResponse.Value = oData.Value;
            oResponse.Values = oData.Values;
            oResponse.CheckRegistration = oData.CheckRegistration;
            oResponse.Status = oData.Status;
            oResponse.Message = oData.Message;
            oResponse.DayPassing = Convert.ToString(Math.Round((Convert.ToDouble(DayOfMonth) / TotalDayOfMonth) * 100)) + "%";

            //if (oData.BLLMarketGroup != 0)
            {
                oResponse.MarketGroupList = _oMarketGroups.GetMarketGroup(sAndroidAppID, sUserName);
            }
            oResponse.BLLDistributorList = _oBLLDistributors.GetBLLDistributor(sAndroidAppID, sUserName);
            oResponse.BLLRetailTypeList = _oBLLRetailTypes.GetBLLRetailType();
            if (nAndroidAppID != (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                oResponse.TELProductGroupList = _oTELProductGroups.GetTELProductGroup();
                oResponse.TELBrandList = _oTELBrands.GetTELBrand();
            }

            eList.Add(oResponse);
            DBController.Instance.CloseConnection();
            sOutput = JsonConvert.SerializeObject(eList, Formatting.Indented);
            Response.Write(sOutput);

        }
    }
   
    public class Data
    {
        public string Value;//After implementation v6 this field should be deleted
        public string Values;
        public string CheckRegistration;
        public string Status;
        public string Message;
        public string DayPassing;
        public int BLLMarketGroup;
        public List<MarketGroup> MarketGroupList;
        public List<BLLDistributor> BLLDistributorList;
        public List<TELProductGroup> TELProductGroupList;
        public List<TELBrand> TELBrandList;
        public List<BLLRetailType> BLLRetailTypeList;
        public void Authentication(string sUserName, string sPassword, string sIMEI, string sSIMSerial, string sAndroidAppID)
        {
            DBController.Instance.OpenNewConnection();
            User oUser = new User();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);

            string sDatabase = "x";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sDatabase = "BLLSysDB";
            }
            else
            {
                sDatabase = "TELSysDB";
            }
            if (oUser.UserAuthentication(sUserName, sDatabase) != false)
            {
                PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);

                string sHashValue = mph.CreateHash(sPassword, oUser.Salt);
                if (oUser.UserPassword.CompareTo(sHashValue) != 0)
                {
                    Value = "Invalid Password"; //For Old Version Before v6
                    Values = "Invalid Password";
                }
                else
                {
                    Value = "Registration Required!!!\nContact MIS Dept."; //For Old Version Before v6
                    Values = "Success";

                    if (sIMEI != "")
                    {
                        if (oUser.GetAndroidAppID(sIMEI) == nAndroidAppID)
                        {
                            if (oUser.CheckRegistrationCJApps(sIMEI, sUserName)) //CheckRegistrationCJApps() Old
                            {
                                if (oUser.Status == "InActive")
                                {
                                    Status = "InActive";
                                    Message = "Inactive User!!\nPlease Contact MIS Dept.";
                                }
                                else
                                {
                                    Status = "Active";
                                    if (oUser.AuthenticateMode != "Null")
                                    {
                                        if (oUser.AuthenticateMode != "IMEI")
                                        {
                                            if (oUser.CheckSIMSerial(sSIMSerial))
                                            {
                                                CheckRegistration = "true";
                                            }
                                            else
                                            {
                                                CheckRegistration = "false";
                                                Message = "Invalid SIM Authentication!!\nPlease Contact MIS Dept.";
                                            }
                                        }
                                        else
                                        {
                                            CheckRegistration = "true";
                                            Message = "Success";
                                        }
                                    }
                                    else
                                    {
                                        //oData.CheckRegistration = "false";
                                        Message = "Authentication Error!!\nPlease Contact MIS Dept.";
                                    }
                                }


                            }
                            else
                            {
                                CheckRegistration = "RegistrationRequired";
                                //oData.Message = "Invalid Handset Authentication!!\nPlease Contact MIS Dept.";
                            }
                        }
                        else
                        {
                            if (oUser.CheckRegistrationCJApps(sIMEI, sUserName))
                            {
                                string sAppName = "";
                                if (oUser.AndroidAppID == (int)Dictionary.AndroidAppID.CJ_Apps)
                                {
                                    sAppName = "CJ.Apps";
                                }
                                else if (oUser.AndroidAppID == (int)Dictionary.AndroidAppID.CJ_Digital)
                                {
                                    sAppName = "CJ.Digital";
                                }
                                else
                                {
                                    sAppName = "CJ.Lighting";
                                }

                                if (oUser.Status == "InActive")
                                {
                                    Status = "InActive";
                                    Message = "Inactive User!!\nPlease Contact MIS Dept.";
                                }
                                else
                                {
                                    Status = "Active";
                                    if (oUser.AuthenticateMode != "Null")
                                    {
                                        if (oUser.AuthenticateMode != "IMEI")
                                        {
                                            if (oUser.CheckSIMSerialCJApps(sSIMSerial, sUserName))
                                            {
                                                if (oUser.AndroidAppID != (int)Dictionary.AndroidAppID.All)
                                                {
                                                    if (nAndroidAppID == oUser.AndroidAppID)
                                                    {
                                                        CheckRegistration = "true";
                                                        Message = "Success";
                                                    }
                                                    else
                                                    {

                                                        CheckRegistration = "false";
                                                        Message = "You have no permission to use the App!!\nYou can only use " + sAppName + "\nContact MIS Department";
                                                    }
                                                }
                                                else
                                                {
                                                    CheckRegistration = "true";
                                                    Message = "Success";
                                                }
                                            }
                                            else
                                            {
                                                CheckRegistration = "false";
                                                Message = "Invalid SIM Authentication!!\nPlease Contact MIS Dept.";
                                            }
                                        }
                                        else
                                        {
                                            if (oUser.AndroidAppID != (int)Dictionary.AndroidAppID.All)
                                            {
                                                if (nAndroidAppID == oUser.AndroidAppID)
                                                {
                                                    CheckRegistration = "true";
                                                    Message = "Success";
                                                }
                                                else
                                                {
                                                    
                                                    CheckRegistration = "false";
                                                    Message = "You have no permission to use the App!!\nYou can only use " + sAppName + "\nContact MIS Department";
                                                }
                                            }
                                            else
                                            {
                                                CheckRegistration = "true";
                                                Message = "Success";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //oData.CheckRegistration = "false";
                                        Message = "Authentication Error!!\nPlease Contact MIS Dept.";
                                    }
                                }


                            }
                            else
                            {
                                CheckRegistration = "RegistrationRequired";
                                //oData.Message = "Invalid Handset Authentication!!\nPlease Contact MIS Dept.";
                            }
                        }
                    }
                }
            }
            else
            {
                Value = "Invalid User ID"; //For Old Version Before v6
                Values = "Invalid User ID";
            }

        }

        public void GetOtherInfo(string sUserName, string sIMEI)
        {
          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " select BLLMarketGroup from dbo.t_A_UserRegistration Where UserName='" + sUserName + "' and IMEINo = '" + sIMEI + "' ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["BLLMarketGroup"] != DBNull.Value)
                        BLLMarketGroup = (int)reader["BLLMarketGroup"];
                    else BLLMarketGroup = 0;

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
    
    public class MarketGroup
    {
        public string Company;
        public string AreaID;
        public string AreaName;
        public string AreaSort;
        public string TerritoryID;
        public string TerritoryName;
        public string TerritorySort;

    }
    public class BLLDistributor
    {
        public string Company;
        public string CustomerID;
        public string CustomerCode;
        public string CustomerName;
        public string CustomerShortName;
        public string TerritoryID;

    }
    public class TELProductGroup
    {
        public string Company;
        public string ProductGroupID;
        public string ProductGroupName;
        public string ProductGroupType;
        public string ParentID;
        public string Sort;
    }
    public class TELBrand
    {
        public string Company;
        public string BrandID;
        public string BrandName;
    }
    public class BLLRetailType
    {
        public string RetailType;
    }
    public class Datas : CollectionBase
    {

        public Data this[int i]
        {
            get { return (Data)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Data oData)
        {
            InnerList.Add(oData);
        }
        /*
        public List<Data> Authentication(string sUserName, string sPassword, string sIMEI, string sSIMSerial)
        {
            List<Data> eList = new List<Data>();
            User oUser = new User();
            Data oData = new Data();
            DBController.Instance.OpenNewConnection();
            InnerList.Clear();
            if (oUser.authenticate(sUserName) != false)
            {
                PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);

                string sHashValue = mph.CreateHash(sPassword, oUser.Salt);
                if (oUser.UserPassword.CompareTo(sHashValue) != 0)
                {
                    oData.Value = "Invalid Password"; //For Old Version Before v6
                    oData.Values = "Invalid Password";
                    eList.Add(oData);
                }
                else
                {
                    oData.Value = "Registration Required!!!\nContact MIS Dept."; //For Old Version Before v6
                    oData.Values = "Success";

                    if (sIMEI != "")
                    {
                        if (oUser.CheckRegistrationCJApps(sIMEI))
                        {
                            if (oUser.Status == "InActive")
                            {
                                oData.Status = "InActive";
                                oData.Message = "Inactive User!!\nPlease Contact MIS Dept.";
                            }
                            else
                            {
                                oData.Status = "Active";
                                if (oUser.AuthenticateMode != "Null")
                                {
                                    if (oUser.AuthenticateMode != "IMEI")
                                    {
                                        if (oUser.CheckSIMSerialCJApps(sSIMSerial))
                                        {
                                            oData.CheckRegistration = "true";
                                        }
                                        else
                                        {
                                            oData.CheckRegistration = "false";
                                            oData.Message = "Invalid SIM Authentication!!\nPlease Contact MIS Dept.";
                                        }
                                    }
                                    else
                                    {
                                        oData.CheckRegistration = "true";
                                        oData.Message = "Success";
                                    }
                                }
                                else
                                {
                                    //oData.CheckRegistration = "false";
                                    oData.Message = "Authentication Error!!\nPlease Contact MIS Dept.";
                                }
                            }

                        }
                        else
                        {
                            oData.CheckRegistration = "RegistrationRequired";
                            //oData.Message = "Invalid Handset Authentication!!\nPlease Contact MIS Dept.";
                        }
                    }
                    eList.Add(oData);
                }
            }
            else
            {
                oData.Value = "Invalid User ID"; //For Old Version Before v6
                oData.Values = "Invalid User ID";
                eList.Add(oData);
            }
            return eList;
        }
         */
    }
   
    public class MarketGroups : CollectionBase
    {

        public MarketGroup this[int i]
        {
            get { return (MarketGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(MarketGroup oMarketGroup)
        {
            InnerList.Add(oMarketGroup);
        }
        public List<MarketGroup> GetMarketGroup(string sAndroidAppID, string sUser)
        {
            List<MarketGroup> eList = new List<MarketGroup>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            InnerList.Clear();
            string sSQL = " Select Distinct 'BLL' as Company, AreaID, AreaShortName as AreaName, AreaSort, " +
                " TerritoryID, TerritoryShortName as TerritoryName, TerritorySort from BLLSysDB.dbo.v_CustomerDetails Where ChannelID=2 ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }
            sSQL = sSQL + " order by AreaSort, TerritorySort ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MarketGroup oMarketGroup = new MarketGroup();

                    oMarketGroup.Company = reader["Company"].ToString();
                    oMarketGroup.AreaID = reader["AreaID"].ToString();
                    oMarketGroup.AreaName = reader["AreaName"].ToString();
                    oMarketGroup.AreaSort = reader["AreaSort"].ToString();
                    oMarketGroup.TerritoryID = reader["TerritoryID"].ToString();
                    oMarketGroup.TerritoryName = reader["TerritoryName"].ToString();
                    oMarketGroup.TerritorySort = reader["TerritorySort"].ToString();

                    eList.Add(oMarketGroup);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
               
            }
            return eList;
        }
        
    }
    public class BLLDistributors : CollectionBase
    {

        public BLLDistributor this[int i]
        {
            get { return (BLLDistributor)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(BLLDistributor oBLLDistributor)
        {
            InnerList.Add(oBLLDistributor);
        }

        public List<BLLDistributor> GetBLLDistributor(string sAndroidAppID, string sUser)
        {
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            List<BLLDistributor> eList = new List<BLLDistributor>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = " Select 'BLL' Company, CustomerID, CustomerCode, CustomerName, Isnull(CustomerShortName,CustomerName) as CustomerShortName, " +
                          " TerritoryID, a.IsActive from BLLSysDB.dbo.v_CustomerDetails a, BLLSysDB.dbo.t_DMSRoute b  " +
                          " Where a.CustomerID=b.DistributorID  ";

                            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                            {
                                sSQL = sSQL + " and a.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
                            }
                            sSQL = sSQL + " Group by CustomerID, CustomerCode, CustomerName, CustomerShortName, TerritoryID, a.IsActive  " +
                          " Order by a.IsActive DESC, CustomerName ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BLLDistributor oBLLDistributor = new BLLDistributor();

                    oBLLDistributor.Company = reader["Company"].ToString();
                    oBLLDistributor.CustomerID = reader["CustomerID"].ToString();
                    oBLLDistributor.CustomerCode = reader["CustomerCode"].ToString();
                    string s = reader["CustomerName"].ToString();
                    oBLLDistributor.CustomerName = s.Replace("'", "");
                    oBLLDistributor.CustomerShortName = reader["CustomerShortName"].ToString();
                    oBLLDistributor.TerritoryID = reader["TerritoryID"].ToString();

                    eList.Add(oBLLDistributor);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }
    }
    public class TELProductGroups : CollectionBase
    {

        public TELProductGroup this[int i]
        {
            get { return (TELProductGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(TELProductGroup oTELProductGroup)
        {
            InnerList.Add(oTELProductGroup);
        }
        public List<TELProductGroup> GetTELProductGroup()
        {
            List<TELProductGroup> eList = new List<TELProductGroup>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = " Select 'TEL' as Company, PdtGroupID as ProductGroupID, PdtGroupName as ProductGroupName, PdtGroupType as ProductGroupType, "+
                          " IsNull(ParentID,0) as ParentID, POS as Sort from TELSysDB.dbo.t_ProductGroup where IsActive=1 Order by PdtGroupType, POS ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TELProductGroup oTELProductGroup = new TELProductGroup();

                    oTELProductGroup.Company = reader["Company"].ToString();
                    oTELProductGroup.ProductGroupID = reader["ProductGroupID"].ToString();
                    oTELProductGroup.ProductGroupName = reader["ProductGroupName"].ToString();
                    oTELProductGroup.ProductGroupType = reader["ProductGroupType"].ToString();
                    oTELProductGroup.ParentID = reader["ParentID"].ToString();
                    oTELProductGroup.Sort = reader["Sort"].ToString();

                    eList.Add(oTELProductGroup);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }

    }
    public class TELBrands : CollectionBase
    {

        public TELBrand this[int i]
        {
            get { return (TELBrand)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(TELBrand oTELBrand)
        {
            InnerList.Add(oTELBrand);
        }
        public List<TELBrand> GetTELBrand()
        {
            List<TELBrand> eList = new List<TELBrand>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = " Select 'TEL' as Company,BrandID, BrandDesc as BrandName from TELSysDB.dbo.t_Brand Where IsActive=1 and BrandLevel=1 Order by BrandPos ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TELBrand oTELBrand = new TELBrand();

                    oTELBrand.Company = reader["Company"].ToString();
                    oTELBrand.BrandID = reader["BrandID"].ToString();
                    oTELBrand.BrandName = reader["BrandName"].ToString();

                    eList.Add(oTELBrand);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }

    }
    public class BLLRetailTypes : CollectionBase
    {

        public BLLRetailType this[int i]
        {
            get { return (BLLRetailType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(BLLRetailType oBLLRetailType)
        {
            InnerList.Add(oBLLRetailType);
        }
        public List<BLLRetailType> GetBLLRetailType()
        {
            List<BLLRetailType> eList = new List<BLLRetailType>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = " Select Distinct RetailType from BLLSysDB.dbo.t_DMSClusterOutlet Order by RetailType ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BLLRetailType oBLLRetailType = new BLLRetailType();

                    if (reader["RetailType"] != DBNull.Value)
                    {
                        oBLLRetailType.RetailType = reader["RetailType"].ToString();
                    }
                    else
                    {
                        oBLLRetailType.RetailType = "";
                    }
                    eList.Add(oBLLRetailType);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }

    }
}


