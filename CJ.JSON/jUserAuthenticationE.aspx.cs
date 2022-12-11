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

            string sUserName = c.Request.Form["UserName"].Trim();
            string sPassword = c.Request.Form["Password"].Trim();

            //string sUserName = "";
            //string sPassword = "";
            //99c42bb98da14cca

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
            TELProductGroups _oTELProductGroups = new TELProductGroups();
            TELBrands _oTELBrands = new TELBrands();
            TELMarketGroups _oTELMarketGroups = new TELMarketGroups();
            TELCompanyDepartments _oTELCompanyDepartments = new TELCompanyDepartments();
            TELCompanyDesignations _oTELCompanyDesignations = new TELCompanyDesignations();
            JobGrades _oJobGrades = new JobGrades();
            EmployeeStatuss _oEmployeeStatuss = new EmployeeStatuss();
            Companys _oCompanys = new Companys();
            BUs _oBUs = new BUs();
            SalesCalendars _oSalesCalendar = new SalesCalendars();

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
            string sMSG = "";
            sMSG = oData.Authentication(sUserName, sPassword, sIMEI, sSIMSerial, sAndroidAppID);

            oResponse.Value = oData.Value;
            oResponse.Values = oData.Values;
            oResponse.CheckRegistration = oData.CheckRegistration;
            oResponse.Status = oData.Status;
            oResponse.Message = oData.Message;
            oResponse.DayPassing = Convert.ToString(Math.Round((Convert.ToDouble(DayOfMonth) / TotalDayOfMonth) * 100)) + "%";
            if(sMSG == "Success")
            {
                oResponse.TELProductGroupList = _oTELProductGroups.GetTELProductGroup();
                oResponse.TELBrandList = _oTELBrands.GetTELBrand();
                oResponse.TELMarketGroupList = _oTELMarketGroups.GetTELMarketGroup();
                //oResponse.TELCompanyDesignationList = _oTELCompanyDesignations.GetTELCompanyDesignation();
                oResponse.TELCompanyDepartmentList = _oTELCompanyDepartments.GetTELCompanyDepartment();
                oResponse.CompanyList = _oCompanys.GetCompany();
                oResponse.BUList = _oBUs.GetBU(sUserName);
                oResponse.JobGradeList = _oJobGrades.GetJobGrade();
                oResponse.EmployeeStatusList = _oEmployeeStatuss.GetEmployeeStatus();
                oResponse.SalesCalendarList = _oSalesCalendar.GetSalesCalendar();
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

        public List<TELProductGroup> TELProductGroupList;
        public List<TELBrand> TELBrandList;
        public List<TELMarketGroup> TELMarketGroupList;
        public List<TELCompanyDesignation> TELCompanyDesignationList;
        public List<TELCompanyDepartment> TELCompanyDepartmentList;
        public List<JobGrade> JobGradeList;
        public List<EmployeeStatus> EmployeeStatusList;
        public List<Company> CompanyList;
        public List<BU> BUList;
        public List<SalesCalendar> SalesCalendarList;

        public string Authentication(string sUserName, string sPassword, string sIMEI, string sSIMSerial, string sAndroidAppID)
        {
            DBController.Instance.OpenNewConnection();
            User oUser = new User();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);

            string sDatabase = "TELSysDB";

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
                                                Message = "Success";//Added By Saidujjaman
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
            return Message;
        }

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

    public class TELMarketGroup
    {
        public string Type;
        public string Name;
        public string Parent;
        public string Channel;
    }

    public class TELCompanyDepartment
    {
        public string Company;
        public string DepartmentId;
        public string DepartmentName;
    }

    public class TELCompanyDesignation
    {
        public string Company;
        public string DesignationId;
        public string DesignationName;
    }
    public class JobGrade
    {
        public string JobGradeId;
        public string JobGradeName;
    }
    public class EmployeeStatus
    {
        public string Name;
    }
    public class Company
    {
        public string Name;
    }
    public class BU
    {
        public string Name;
        public string Type;
        public string ParentName;
    }
    public class SalesCalendar
    {
        public string CYear;
        public string CMonth;
        public string WeekNo;
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

    public class TELMarketGroups : CollectionBase
    {

        public TELMarketGroup this[int i]
        {
            get { return (TELMarketGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(TELMarketGroup oTELMarketGroup)
        {
            InnerList.Add(oTELMarketGroup);
        }
        public List<TELMarketGroup> GetTELMarketGroup()
        {
            List<TELMarketGroup> eList = new List<TELMarketGroup>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = @" Select * from 
                        (
                        Select 'Region' as Type, RegionName as Name, '' as Parent, 0 as Sort, 1 as SL, b.Channel from t_MarketGroup a,
                        DWDB.dbo.t_ActiveArea b Where a.MarketGroupID = b.MarketGroupId and MarketGroupType = 1 and RegionName Is not null group by RegionName,  b.Channel
                        UNION ALL
                        Select 'Area' as Type, a.ShortName as Name, isnull(RegionName,'') as Parent, a.Pos as Sort, 1 as SL, b.Channel from t_MarketGroup a,
                        DWDB.dbo.t_ActiveArea b Where a.MarketGroupID = b.MarketGroupId and MarketGroupType = 1
                        UNION ALL
                        Select 'Zone' as Type, b.ShortName as Name, a.ShortName as Parent, b.Pos as Sort, 2 as SL, c.Channel as Channel from
                        (Select MarketGroupID as AreaID, ShortName from t_MarketGroup Where MarketGroupType = 1)a,
                        (Select MarketGroupID as ZoneID, ShortName, ParentID, Pos from t_MarketGroup Where MarketGroupType = 2)b,
                        DWDB.dbo.t_ActiveArea c, (Select MarketGroupID from t_Customer group by MarketGroupID) d Where a.AreaID = b.ParentID and a.AreaID = c.MarketGroupId and d.MarketGroupID = b.ZoneID
                        UNION ALL
                        select 'Outlet' as Type, b.ShowroomCode as Name, c.ShortName as Parent, 1 as Sort, 3 as SL, d.Channel as Channel from t_Customer a, t_Showroom b,
                        (Select MarketGroupID as ZoneID, ShortName, ParentID from t_MarketGroup Where MarketGroupType = 2)c,
                        DWDB.dbo.t_ActiveArea d
                        where a.CustomerID = b.CustomerID and a.MarketGroupID = c.ZoneID and c.ParentID=d.MarketGroupId and IsDepot = 0 and b.IsPOSActive = 1
                        ) Final Order by Channel, SL, Sort, Name ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TELMarketGroup oTELMarketGroup = new TELMarketGroup();

                    oTELMarketGroup.Type = reader["Type"].ToString();
                    oTELMarketGroup.Name = reader["Name"].ToString();
                    oTELMarketGroup.Parent = reader["Parent"].ToString();
                    oTELMarketGroup.Channel = reader["Channel"].ToString();

                    eList.Add(oTELMarketGroup);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }

    }

    public class TELCompanyDepartments : CollectionBase
    {

        public TELCompanyDepartment this[int i]
        {
            get { return (TELCompanyDepartment)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(TELCompanyDepartment oTELCompanyDepartment)
        {
            InnerList.Add(oTELCompanyDepartment);
        }
        public List<TELCompanyDepartment> GetTELCompanyDepartment()
        {
            List<TELCompanyDepartment> eList = new List<TELCompanyDepartment>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = @" Select distinct CompanyCode, DepartmentId, DepartmentName from v_EmployeeDetails
                            Where CompanyCode IN ('TEL','BLL','BEIL') order by CompanyCode, DepartmentName ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TELCompanyDepartment oTELCompanyDepartment = new TELCompanyDepartment();

                    oTELCompanyDepartment.Company = reader["CompanyCode"].ToString();
                    oTELCompanyDepartment.DepartmentId = reader["DepartmentId"].ToString();
                    oTELCompanyDepartment.DepartmentName = reader["DepartmentName"].ToString();

                    eList.Add(oTELCompanyDepartment);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }


    }

    public class TELCompanyDesignations : CollectionBase
    {

        public TELCompanyDesignation this[int i]
        {
            get { return (TELCompanyDesignation)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(TELCompanyDesignation oTELCompanyDesignation)
        {
            InnerList.Add(oTELCompanyDesignation);
        }
        public List<TELCompanyDesignation> GetTELCompanyDesignation()
        {
            List<TELCompanyDesignation> eList = new List<TELCompanyDesignation>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = @" Select distinct CompanyCode, DesignationId, DesignationName from v_EmployeeDetails
                            Where CompanyCode IN ('TEL','BLL','BEIL')  order by CompanyCode, DesignationName ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TELCompanyDesignation oTELCompanyDesignation = new TELCompanyDesignation();

                    oTELCompanyDesignation.Company = reader["CompanyCode"].ToString();
                    oTELCompanyDesignation.DesignationId = reader["DesignationId"].ToString();
                    oTELCompanyDesignation.DesignationName = reader["DesignationName"].ToString();

                    eList.Add(oTELCompanyDesignation);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }


    }

    public class JobGrades : CollectionBase
    {

        public JobGrade this[int i]
        {
            get { return (JobGrade)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(JobGrade oJobGrade)
        {
            InnerList.Add(oJobGrade);
        }
        public List<JobGrade> GetJobGrade()
        {
            List<JobGrade> eList = new List<JobGrade>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = @" Select JobGradeId, JobGradeName from t_JobGrade Where IsActive = 1 Order by Sort, JobGradeName desc ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobGrade oJobGrade = new JobGrade();

                    oJobGrade.JobGradeId = reader["JobGradeId"].ToString();
                    oJobGrade.JobGradeName = reader["JobGradeName"].ToString();

                    eList.Add(oJobGrade);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }
    }

    public class EmployeeStatuss : CollectionBase
    {

        public EmployeeStatus this[int i]
        {
            get { return (EmployeeStatus)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(EmployeeStatus oEmployeeStatus)
        {
            InnerList.Add(oEmployeeStatus);
        }
        public List<EmployeeStatus> GetEmployeeStatus()
        {
            int nCount = 0;
            List<EmployeeStatus> eList = new List<EmployeeStatus>();
            InnerList.Clear();

            string[] x;
            x = Enum.GetNames(typeof(Dictionary.HREmployeeStatus));

            foreach (string a in x)
            {
                EmployeeStatus oEmployeeStatus = new EmployeeStatus();
                if (nCount == 0)
                {
                    oEmployeeStatus.Name = "Running";//NotEmployed overwrite by Running
                    eList.Add(oEmployeeStatus);
                    nCount++;
                }
                else
                {
                    oEmployeeStatus.Name = a;
                    eList.Add(oEmployeeStatus);
                }
              
            }

            return eList;
        }

    }

    public class Companys : CollectionBase
    {

        public Company this[int i]
        {
            get { return (Company)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Company oCompany)
        {
            InnerList.Add(oCompany);
        }
        public List<Company> GetCompany()
        {
            List<Company> eList = new List<Company>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = @"Select CompanyID, CompanyCode from t_Company Where IsActive = 1 order by CompanyCode desc ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company oCompany = new Company();

                    oCompany.Name = reader["CompanyCode"].ToString();

                    eList.Add(oCompany);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }
       
    }
    public class BUs : CollectionBase
    {

        public BU this[int i]
        {
            get { return (BU)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(BU oBU)
        {
            InnerList.Add(oBU);
        }
        public List<BU> GetBU(string sUser)
        {
            List<BU> eList = new List<BU>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            //string sSQL = @" Select SBUName as BU from t_SBU a where a.SBUID IN(Select value from fn_split((select UserSBUs from t_User Where UserName = '" + sUser + "'),',')) order by Sort ";
            string sSQL = " Select Distinct Type, Description, IsNull(ParentName,'') ParentName, 1 as Priority, Sort "+
                          " from DWDB.dbo.t_BUWiseSalesNew Where Type IN ('BU') and Description IN(" +
                          " Select SBUName as BU from t_SBU a where a.SBUID IN(Select value from fn_split((select UserSBUs from t_User Where UserName = '" + sUser + "'),','))) "+
                          " UNION ALL " +
                          " Select Distinct Type, Description, IsNull(ParentName,'') ParentName, 2 as Priority, Sort  " +
                          " from DWDB.dbo.t_BUWiseSalesNew Where Type IN ('Channel') and ParentName IN(" +
                          " Select SBUName as BU from t_SBU a where a.SBUID IN(Select value from fn_split((select UserSBUs from t_User Where UserName = '" + sUser + "'),','))) "+
                          " order by Priority, Sort";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BU oBU = new BU();

                    oBU.Name = reader["Description"].ToString();
                    oBU.Type = reader["Type"].ToString();
                    oBU.ParentName = reader["ParentName"].ToString();

                    eList.Add(oBU);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;
        }
    }

    public class SalesCalendars : CollectionBase
    {

        public SalesCalendar this[int i]
        {
            get { return (SalesCalendar)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesCalendar oSalesCalendar)
        {
            InnerList.Add(oSalesCalendar);
        }
        public List<SalesCalendar> GetSalesCalendar()
        {
            List<SalesCalendar> eList = new List<SalesCalendar>();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSQL = @"select CYear, CMonth, WeekNo from [dbo].[t_CalendarWeekSales] Order by CYear, CMonth, WeekNo ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesCalendar oSalesCalendar = new SalesCalendar();

                    oSalesCalendar.CYear = reader["CYear"].ToString();
                    oSalesCalendar.CMonth = reader["CMonth"].ToString();
                    oSalesCalendar.WeekNo = reader["WeekNo"].ToString();

                    eList.Add(oSalesCalendar);
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


