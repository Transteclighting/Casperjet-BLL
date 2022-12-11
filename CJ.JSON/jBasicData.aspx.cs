using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.ANDROID;

public partial class jBasicData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sType = c.Request.Form["Type"].Trim();
           
            string sCompany = "";

            if (c.Request.Form["Company"] != null)
            {
                sCompany = c.Request.Form["Company"].Trim();
            }
            else
            {
                sCompany = "TEL";
            }

            //string sUser = "hakim";
            //string sType = "ASG";

            Datas _oDatas = new Datas();
            string sOutput = "";
            DBController.Instance.OpenNewConnection();

            if (sType == "Brand")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetBrand(sCompany), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "ASG")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataASG(sCompany), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "MAG")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataMAG(sCompany), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "PG")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataPG(sCompany), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "IC")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataInventoryCategory(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "AreaZoneOutlet")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataAreaZoneOutlet(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "PM")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetProductManager(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "CM")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetCategoryManager(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "BLLArea")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetBLLArea(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "BLLTerritory")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetBLLTerritory(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "BLLDistributor")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetBLLDistributor(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            
            DBController.Instance.CloseConnection();
        }
    }
    public class Data
    {
        public string DataID;
        public string Description;
        public string PGID;
        public string MAGID;
        public string ParentID;
        public string CustomerCode;
        public string TerritoryID;
        
        public string Value;
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

        public List<Data> GetBrand(string sCompany)
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            if (sCompany == "TEL")
            {
                sSQL = "select BrandID, BrandDesc as BrandName from t_Brand where IsActive=1 and BrandLevel=1 order by BrandPos ";
            }
            else if (sCompany == "BLL")
            {
                sSQL = "select BrandID, BrandDesc as BrandName from BLLSysDB.dbo.t_Brand where IsActive=1 and BrandLevel=1 order by BrandPos ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.DataID = reader["BrandID"].ToString();
                    oData.Description = reader["BrandName"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetDataASG(string sCompany)
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sCompany == "BLL")
            {
                sSQL = "select ParentID as MAGID, PdtGroupID as ASGID, PdtGroupName as ASGName from BLLSysDB.dbo.t_ProductGroup Where PdtGroupType=3 and IsActive=1 order by POS ";
            }


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.Value = "Success";

                    oData.DataID = reader["ASGID"].ToString();
                    oData.Description = reader["ASGName"].ToString();
                    oData.MAGID = reader["MAGID"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetDataMAG(string sCompany)
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

          string sSQL = "";
          if (sCompany == "TEL")
          {
              sSQL = "select ParentID as PGID, PdtGroupID as MAGID, CASE When PdtGroupName = 'Camera & Mobile' then 'C&M' else PdtGroupName end as MAGName from t_ProductGroup Where PdtGroupType=2 and IsActive=1 " +
                          "and PdtGroupID NOT IN (41,42,43,44,785,487,353,374,706) order by POS";
          }
          else if (sCompany == "BLL")
          {
              sSQL = "select ParentID as PGID, PdtGroupID as MAGID, PdtGroupName as MAGName from BLLSysDB.dbo.t_ProductGroup Where PdtGroupType=2 and IsActive=1 order by POS ";
          }

            
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.Value = "Success";

                    oData.DataID = reader["MAGID"].ToString();
                    oData.Description = reader["MAGName"].ToString();
                    oData.PGID = reader["PGID"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetDataPG(string sCompany)
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

          string sSQL = "";
          if (sCompany == "TEL")
          {
              sSQL = "select PdtGroupID as PGID, CASE When PdtGroupName = 'Camera & Mobile' then 'C&M' " +
                            "  else PdtGroupName end as PGName from t_ProductGroup Where PdtGroupType=1 and IsActive=1  " +
                            " and PdtGroupID NOT IN (8,333,705) order by POS";
          }
          else if (sCompany == "BLL")
          {
              sSQL = "select ParentID as PGID, PdtGroupName as PGName from BLLSysDB.dbo.t_ProductGroup Where PdtGroupType=1 and IsActive=1 order by POS ";
          }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.Value = "Success";

                    oData.DataID = reader["PGID"].ToString();
                    oData.Description = reader["PGName"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetDataInventoryCategory()
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InventoryCate)))
                {
                    Data oData = new Data();
                    oData.Value = "Success";
                    
                    oData.Description = Enum.GetName(typeof(Dictionary.InventoryCate), GetEnum);
                    if (oData.Description == "Regular")
                    {
                        oData.DataID = Convert.ToString((int)Dictionary.InventoryCate.Regular);
                    }
                    else if (oData.Description == "Aged")
                    {
                        oData.DataID = Convert.ToString((int)Dictionary.InventoryCate.Aged);
                    }
                    else if (oData.Description == "IPB")
                    {
                        oData.DataID = Convert.ToString((int)Dictionary.InventoryCate.IPB);
                    }
                    else if (oData.Description == "Discontinue")
                    {
                        oData.DataID = Convert.ToString((int)Dictionary.InventoryCate.Discontinue);
                    }
                    else if (oData.Description == "Others")
                    {
                        oData.DataID = Convert.ToString((int)Dictionary.InventoryCate.Others);
                    }
                    eList.Add(oData);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetDataAreaZoneOutlet()
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "Select AreaID, right(AreaName,6) as AreaName, Sort " +
                          "  from  " +
                          "  ( " +
                          "  select a.AreaID, left(AreaName,9) as AreaName, 1 as Sort " +
                          "  from DWDB.dbo.t_CustomerDetails a, TELSysDB.dbo.t_Showroom b  " +
                          "  Where a.CustomerID=b.CustomerID and CompanyName='TEL' and IsPOSActive = 1  " +
                          "  ) a group by AreaID, right(AreaName,6), Sort " +
                          "  UNION ALL " +
                          "  Select TerritoryID, right(TerritoryName,6) as TerritoryName, Sort " +
                          "  from  " +
                          "  ( " +
                          "  select a.TerritoryID, left(TerritoryName,9) as TerritoryName, 2 as Sort " +
                          "  from DWDB.dbo.t_CustomerDetails a, TELSysDB.dbo.t_Showroom b  " +
                          "  Where a.CustomerID=b.CustomerID and CompanyName='TEL' and IsPOSActive = 1  " +
                          "  ) a group by TerritoryID, right(TerritoryName,6) , Sort " +
                          "  UNION ALL " +
                          "  select CustomerID, ShowroomCode as Outlet, 3 as Sort from TELSysDB.dbo.t_Showroom  " +
                          "  Where IsPOSActive=1 order by Sort, AreaName";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.Value = "Success";

                    oData.DataID = reader["AreaID"].ToString();
                    oData.Description = reader["AreaName"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetProductManager()
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "select a.EmployeeID, IsNull(NickName,'Blank') as NickName from t_MapProductGroup a, t_Employee b " +
                          " Where a.EmployeeID=b.EmployeeID and MapEmployeeType=1 and a.IsActive=1 " +
                           " order by Sort ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.DataID = reader["EmployeeID"].ToString();
                    oData.Description = reader["NickName"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }
        
        public List<Data> GetCategoryManager()
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "select a.EmployeeID, IsNull(NickName,'Blank') as NickName from t_MapProductGroup a, t_Employee b " +
                          " Where a.EmployeeID=b.EmployeeID and MapEmployeeType=2 and a.IsActive=1 " +
                           " order by Sort ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.DataID = reader["EmployeeID"].ToString();
                    oData.Description = reader["NickName"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetBLLArea()
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " Select distinct AreaID as ID, AreaShortName as ShortName, AreaSort from " +
            " BLLSysDB.dbo.v_CustomerDetails Where ChannelID=2 order by AreaSort ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.Value = "Success";

                    oData.DataID = reader["ID"].ToString();
                    oData.Description = reader["ShortName"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }
        
        public List<Data> GetBLLTerritory()
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " Select distinct TerritoryID as ID, TerritoryShortName as ShortName, AreaID as ParentID,  " +
            " TerritorySort from BLLSysDB.dbo.v_CustomerDetails Where ChannelID=2 order by TerritorySort ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.Value = "Success";

                    oData.DataID = reader["ID"].ToString();
                    oData.Description = reader["ShortName"].ToString();
                    oData.ParentID = reader["ParentID"].ToString();
                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }
        
        public List<Data> GetBLLDistributor()
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " Select CustomerID, CustomerCode, CustomerName, TerritoryID, a.IsActive from BLLSysDB.dbo.v_CustomerDetails a, BLLSysDB.dbo.t_DMSRoute b " +
                          " Where a.CustomerID=b.DistributorID  Group by CustomerID, CustomerCode, CustomerName, TerritoryID, a.IsActive  " +
                          " Order by a.IsActive DESC, CustomerName ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.Value = "Success";

                    oData.DataID = reader["ID"].ToString();
                    oData.Description = reader["CustomerName"].ToString();
                    oData.CustomerCode = reader["CustomerCode"].ToString();
                    oData.TerritoryID = reader["TerritoryID"].ToString();
                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }
    }
}
