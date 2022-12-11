// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: May 04, 2014
// Time :  02:00 PM
// Description: Class for Outlet Campaign.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
   public class CampaignOutlet
    {
        private string _sAreaName;
        private int _nAreaID;
        private string _sTerritoryName;
        private int _nTerritoryID;
        private string _sCustomerName;        
        private int _nOutletID; 
        private int _nOutletCode;
        private int _nRouteID;
        private int _nDistributorID;
        private string _sRouteName;
        private string _sOutletName;
        private string _sAddress;       
        private string _sContact;        
        private string _sTargetSlab;
        private int _nCampaignD;        
        private int _nIsActive;
        private double _nUptoWeek4;
        private double _nWeek9;
        private double _nWeek10;
        private double _nWeek11;
        private double _nWeek12;
        private double _nTotal;
        private double _nAch;
        private int _nWeeekID;
        private string _sWeekname;
        private DateTime _dFromDate;
        private DateTime _dTodate;
        private double _nUptoWeek4TO;
        private double _nWeek9TO;
        private double _nWeek10TO;
        private double _nWeek11TO;
        private double _nWeek12TO;
        private double _nTotalTO;
        private double _nSalesQDz;
        private double _nSalesTk;
        private DateTime _dTranDate;
        private double _nSalesCount;
        private int _nPHGLS;
        private double _nPHGLSTO;

        private int _nTRGLS;
        private double _nTRGLSTO;

        private int _nCFL;
        private double _nCFLTO;

        private int _nTL;
        private int _nTLTO;

       public string AreaName
       {
           get { return _sAreaName; }
           set { _sAreaName = value; }
       }

       public int AreaID
       {
           get { return _nAreaID; }
           set { _nAreaID = value; }
       }

       public string TerritoryName
       {
           get { return _sTerritoryName; }
           set { _sTerritoryName = value; }
       }

       public int TerritoryID
       {
           get { return _nTerritoryID; }
           set { _nTerritoryID = value; }
       }

        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        public int OutletCode
        {
           get { return _nOutletCode; }
           set { _nOutletCode = value; }
        }
       public int RouteID
       {
           get { return _nRouteID; }
           set { _nRouteID = value; }
       }
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }
       public string CustomerName
       {
           get { return _sCustomerName; }
           set { _sCustomerName = value.Trim(); }
       }  

       public string RouteName
       {
           get { return _sRouteName; }
           set { _sRouteName = value.Trim(); }
       }        
        
        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value.Trim(); }
        }
        
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }    
               
        public string Contact
        {
            get { return _sContact; }
            set { _sContact = value.Trim(); }
        }

       public string TargetSlab
       {
           get { return _sTargetSlab; }
           set { _sTargetSlab = value; }
       }
        
        public int CampaignID
        {
            get { return _nCampaignD; }
            set { _nCampaignD = value; }
        }        
        
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
       public double UptoWeek4
       {
           get { return _nUptoWeek4; }
           set { _nUptoWeek4 = value; }
       }

       public double UptoWeek4TO
       {
           get { return _nUptoWeek4TO; }
           set { _nUptoWeek4TO = value; }
       }

       public double Week9
       {
           get { return _nWeek9; }
           set { _nWeek9 = value; }
       }
       public double Week10
       {
           get { return _nWeek10; }
           set { _nWeek10 = value; }
       }
       public double Week11
       {
           get { return _nWeek11; }
           set { _nWeek11 = value; }
       }
       public double Week12
       {
           get { return _nWeek12; }
           set { _nWeek12 = value; }
       }
       public double Total
       {
           get { return _nTotal; }
           set { _nTotal = value; }
       }
       public double Ach
       {
           get { return _nAch; }
           set { _nAch = value; }
       }

       public int WeekID
       {
           get { return _nWeeekID; }
           set { _nWeeekID = value; }
       }

       public string WeekName
       {
           get { return _sWeekname; }
           set { _sWeekname = value; }
       }

       public DateTime FromDate
       {
           get { return _dFromDate; }
           set { _dFromDate = value; }
       }
       public DateTime ToDate
       {
           get { return _dTodate; }
           set { _dTodate = value; }
       }

       public double Week9TO
       {
           get { return _nWeek9TO; }
           set { _nWeek9TO = value; }
       }

       public double Week10TO
       {
           get { return _nWeek10TO; }
           set { _nWeek10TO = value; }
       }

       public double Week11TO
       {
           get { return _nWeek11TO; }
           set { _nWeek11TO = value; }
       }

       public double Week12TO
       {
           get { return _nWeek12TO; }
           set { _nWeek12TO = value; }
       }

       public double TotalTO
       {
           get { return _nTotalTO; }
           set { _nTotalTO = value; }
       }

       public double SalesDz
       {
           get { return _nSalesQDz; }
           set { _nSalesQDz = value; }
       }

       public double SalesTk
       {
           get { return _nSalesTk; }
           set { _nSalesTk = value; }
       }

       public DateTime  TranDate
       {
           get { return _dTranDate; }
           set { _dTranDate = value; }
       }

       public double SalesCount
       {
           get { return _nSalesCount; }
           set { _nSalesCount = value; }
       }

       public int PHGLS
       {
           get { return _nPHGLS; }
           set { _nPHGLS = value; }
       }

       public double PHGLSTO
       {
           get { return _nPHGLSTO; }
           set { _nPHGLSTO = value; }
       }

       public int TRGLS
       {
           get { return _nTRGLS; }
           set { _nTRGLS = value; }
       }

       public double TRGLSTO
       {
           get { return _nTRGLSTO; }
           set { _nTRGLSTO = value; }
       }

       public int CFL
       {
           get { return _nCFL; }
           set { _nCFL = value; }
       }

       public double CFLTO
       {
           get { return _nCFLTO; }
           set { _nCFLTO = value; }
       }


       public int TL
       {
           get { return _nTL; }
           set { _nTL = value; }
       }
       public int TLTO
       {
           get { return _nTLTO; }
           set { _nTLTO = value; }
       }




       public void CheckData()
       {
           OleDbCommand cmd = DBController.Instance.GetCommand();
           int nCount = 0;
           //string sSql = " select outletID,CustomerID,weekID, sum(salesQty)as salesQty from TELAddDB.dbo.t_CampaignOutletTran where OutletID= ? and WeekID= ? and SalesQty > 0 group by outletID,CustomerID,weekID ";

           string sSql = " select outletID,CustomerID,weekID, isnull(sum(PHGLS+TRGLS+CFL+TL),0)as SalesQty, isnull(sum(PHGLS),0)as PHGLS, isnull(sum(TRGLS),0)as TRGLS, isnull(sum(CFL),0)as CFL, isnull(sum(TL),0)as TL   "
                       +" from TELAddDB.dbo.t_CampaignOutletTran "
                       +" where OutletID= ? and WeekID= ? and trandate >= DATEADD(day,-15,getdate()) "
                       +" group by outletID,CustomerID,weekID ";
           
           cmd.Parameters.AddWithValue("OutletID", _nOutletCode);
           cmd.Parameters.AddWithValue("WeekID", _nWeeekID);
          
           try
           {
               cmd.CommandText = sSql;

               cmd.CommandType = CommandType.Text;
               IDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {
                   _nDistributorID=int.Parse(reader["CustomerID"].ToString());
                   _nOutletID= int.Parse(reader["OutletID"].ToString());
                   _nWeeekID = int.Parse(reader["weekID"].ToString());
                   _nSalesCount = int.Parse(reader["SalesQty"].ToString());
                   //_nPHGLS = int.Parse(reader["PHGLS"].ToString());
                   //_nTRGLS = int.Parse(reader["TRGLS"].ToString());
                   //_nCFL = int.Parse(reader["CFL"].ToString());
                   //_nTL = int.Parse(reader["TL"].ToString());

                   nCount++;
               }

               reader.Close();
           }
           catch (Exception ex)
           {
               throw (ex);
           }


       }
       public void CheckOutletID(int nOutletCode)
       {
           OleDbCommand cmd = DBController.Instance.GetCommand();
           int nCount = 0;
           string sSql = " select OutletID, Outletcode from BLLSysDb.dbo.t_CampaignOutlet where Outletcode=? ";

           cmd.Parameters.AddWithValue("OutletID", nOutletCode);
          

           try
           {
               cmd.CommandText = sSql;

               cmd.CommandType = CommandType.Text;
               IDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {
                  
                   _nOutletID = int.Parse(reader["OutletID"].ToString());                 
                  
                   nCount++;
               }

               reader.Close();
           }
           catch (Exception ex)
           {
               throw (ex);
           }


       }

       public void GetOutletinfo()
       {

           OleDbCommand cmd = DBController.Instance.GetCommand();


           string sSql = "SELECT outletId, OutletCode,OutletName, DistributorID, b.CustomerName, Address, Contact  FROM TELAddDB.DBO.t_CampaignOutlet a, v_CustomerDetails b  where  a.DistributorID=b.CustomerID and  OutletID= ? ";
           
           cmd.Parameters.AddWithValue("OutletID", _nOutletCode);

           try
           {
               cmd.CommandText = sSql;
               cmd.CommandType = CommandType.Text;
               IDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   _nOutletID = (int)reader["OutletID"];
                   _nOutletCode = (int)reader["OutletCode"];
                   _sOutletName = (string)reader["OutletName"];
                   _nDistributorID = (int)reader["DistributorID"];
                   _sCustomerName = (string)reader["CustomerName"];
                   //_sRouteName = (string)reader["RouteName"];
                   _sAddress = (string)reader["Address"];
                   _sContact = (string)reader["Contact"];
               }
               reader.Close();

           }
           catch (Exception ex)
           {
               throw (ex);
           }
       }
       public void AddSales()
       {
           int nMaxTranID = 0;
          
           OleDbCommand cmd = DBController.Instance.GetCommand();
           string sSql = "";

           try
           {
               sSql = " SELECT MAX([TranID]) FROM TelAddDb.dbo.t_CampaignOutletTran ";
               cmd.CommandText = sSql;
               object maxID = cmd.ExecuteScalar();
               if (maxID == DBNull.Value)
               {
                   nMaxTranID = 1;
               }
               else
               {
                   nMaxTranID = Convert.ToInt32(maxID) + 1;
               }
              // _nOutletID = nMaxOutletID;

               cmd.Dispose();
               
               cmd = DBController.Instance.GetCommand();

               sSql = " insert into TelAddDb.dbo.t_CampaignOutletTran values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
               cmd.CommandText = sSql;
               cmd.CommandType = CommandType.Text;

               cmd.Parameters.AddWithValue("TranID", nMaxTranID);
               cmd.Parameters.AddWithValue("OutletId", _nOutletID);
               cmd.Parameters.AddWithValue("CustomerId", _nDistributorID);
               cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
               cmd.Parameters.AddWithValue("WeekID", _nWeeekID);

               cmd.Parameters.AddWithValue("SalesQty", 0);
               cmd.Parameters.AddWithValue("SalesAmount", 0);

               cmd.Parameters.AddWithValue("PHGLS", _nPHGLS);
               cmd.Parameters.AddWithValue("PHGLSTO", _nPHGLSTO);

               cmd.Parameters.AddWithValue("TRGLS", _nTRGLS);
               cmd.Parameters.AddWithValue("TRGLSTO", _nTRGLSTO);

               cmd.Parameters.AddWithValue("CFL", _nCFL);
               cmd.Parameters.AddWithValue("CFLTO", _nCFLTO);

               cmd.Parameters.AddWithValue("TL", _nTL);
               cmd.Parameters.AddWithValue("TLTO", _nTLTO);
                                           

               cmd.ExecuteNonQuery();
               cmd.Dispose();
           }
           catch (Exception ex)
           {
               throw (ex);
           }
       }
       public void Delete(int _nOutletID)
       {
           OleDbCommand cmd = DBController.Instance.GetCommand();
           string sSql = "";

           try
           {
               sSql = "DELETE FROM TELAddDB.DBO.t_CampaignOutlet WHERE [OutletID]=?";

               cmd.CommandText = sSql;
               cmd.CommandType = CommandType.Text;
               cmd.Parameters.AddWithValue("OutletID", _nOutletID);
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
           

           string sSql = "SELECT * FROM TELAddDB.DBO.t_CampaignOutlet where DistributorID=? and OutletID=? and Isactive=1";
           cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
           cmd.Parameters.AddWithValue("OutletID", _nOutletID);
           
           try
           {
               cmd.CommandText = sSql;
               cmd.CommandType = CommandType.Text;
               IDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   _nOutletID = (int)reader["OutletID"];
                   _nOutletCode = (int)reader["OutletCode"];
                   _sOutletName = (string)reader["OutletName"];
               }
               reader.Close();

           }
           catch (Exception ex)
           {
               throw (ex);
           }
       }
       public bool CheckCode()
       {
           int nCount = 0;
           OleDbCommand cmd = DBController.Instance.GetCommand();
           string sSql = "";

           try
           {
               sSql = "SELECT * FROM t_DMSOutlet where OutletCode=? ";
               cmd.Parameters.AddWithValue("OutletCode", _nOutletCode);
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

           if (nCount == 0)
               return true;
           else return false;
       }
       public void RefreshByID(int nOutletID)
       {
           
           OleDbCommand cmd = DBController.Instance.GetCommand();


           string sSql = "select OutletID,OutletCode,DistributorID,IsNull(RouteID,0)RouteID,OutletName, Address,Contact,TargetSlab,IsActive from TELAddDB.DBO.t_CampaignOutlet where OutletID=?";


           cmd.Parameters.AddWithValue("OutletID", nOutletID);


           try
           {
               cmd.CommandText = sSql;
               cmd.CommandType = CommandType.Text;
               IDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   

                   _nOutletID = (int)reader["OutletID"];
                   _nOutletCode = (int)reader["OutletCode"];
                   _nDistributorID = (int)reader["DistributorID"];
                    _nRouteID = (int)reader["RouteID"];
                   _sOutletName = (string)reader["OutletName"];
                   _sAddress = (string)reader["Address"];
                   _sContact = (string)reader["Contact"];
                   _sTargetSlab = (string)reader["TargetSlab"];
                   _nIsActive = Convert.ToInt16(reader["IsActive"]);








                   
               }
               reader.Close();
             

           }
           catch (Exception ex)
           {
               throw (ex);
           }
       }
    }
    public class CampaignOutlets : CollectionBase
    {
        public CampaignOutlet this[int i]
        {
            get { return (CampaignOutlet)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nOutletID)
        {
            int i = 0;
            foreach (CampaignOutlet oCampaignOutlet in this)
            {
                if (oCampaignOutlet.OutletID == nOutletID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Add(CampaignOutlet oCampaignOutlet)
        {
            InnerList.Add(oCampaignOutlet);
        }
        public void Refresh(int nUserID, DateTime dFromDate, DateTime dTodate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

                                 
                    
            //string sSql = " select  Q1.OutletID, DistributorID, OutletName, Address, Week9,Week9TO, Week10,Week10TO, Week11,Week11TO, Week12,Week12TO, "
            //       + "  isnull(sum(Week9+Week10+Week11+Week12 ),0) as TotalQty, isnull(sum(Week9TO+Week10TO+Week11TO+Week12TO),0)as TotalTO  "
            //       + "   from   "
            //       + "   (  "
            //       + "   select Cust.*, isnull(Week9,0)as Week9,isnull(Week10,0)as Week10,isnull(Week11,0)as Week11,isnull(Week12,0)as Week12,      "
            //       + "   isnull(Week9TO,0)as Week9TO,isnull(Week10TO,0)as Week10TO,isnull(Week11TO,0)as Week11TO,isnull(Week12TO,0)as Week12TO,   "
            //       + "   isnull((Week9TO+Week10TO+Week11TO+Week11TO),0) as TotalTO     "
            //       + "   from    "
            //       + "   (  "
            //       + "   select OutletID,OutletName,Address,TargetSlab,DistributorID from TELAddDB.DBO.t_CampaignOutlet   "
            //       + "   ) as Cust    "
            //       + "   left outer join    "
            //       + "   (    "
            //       + "   select OutletID, sum( case WeekID when 9 then SalesQty else 0 end) as Week9,sum( case WeekID when 9 then SalesAmount else 0 end) as Week9TO, "
            //       + "   sum( case WeekID when 10 then SalesQty else 0 end) as Week10, sum( case WeekID when 10 then SalesAmount else 0 end) as Week10TO,     "
            //       + "   sum( case WeekID when 11 then SalesQty else 0 end) as Week11, sum( case WeekID when 11 then SalesAmount else 0 end) as Week11TO, "
            //       + "   sum( case WeekID when 12 then SalesQty else 0 end) as Week12, sum( case WeekID when 12 then SalesAmount else 0 end) as Week12TO   "
            //       + "   from TELAddDB.DBO.t_CampaignOutletTran  "
            //       + "   group by OutletID   "
            //       + "   )as Tra on Cust.OutletID=Tra.OutletID  where DistributorID= ? "
            //       + "   )as  Q1 "
            //       + "   left outer join  "
            //       + "   ( "
            //       + "   select OutletID, sum(SalesQty)as UptoWeek4, sum(SalesAmount)as UptoWeek4TO  from TELAddDB.DBO.t_CampaignOutletTran where Weekid in (1,2,3,4) group by OutletID  "
            //       + "   ) as Q2 on Q1.OutletID=Q2.OutletID		"
            //       + "    group by  Q1.OutletID, DistributorID, OutletName, Address,TargetSlab, Week9,Week9TO, Week10,Week10TO, Week11,Week11TO, Week12,Week12TO "
            //       + "  ORDER BY Q1.OutletID "; 


            string sSql = "  select Q1.OutletID,OutletName,Address,DistributorID, isnull(PHGLS,0)as PHGLS, isnull(PHGLSTO,0)as PHGLSTO,isnull(TRGLS,0)as TRGLS, isnull(TRGLSTO,0)as TRGLSTO, isnull(CFL,0)as CFL, isnull(CFLTO,0)as CFLTO, isnull(TL,0)as TL,isnull(TLTO,0)as TLTO    "
                  +"  from "
                  +" ( "
                  +"  select OutletID,OutletName,Address,DistributorID from TELAddDB.DBO.t_CampaignOutlet "
                  +"  )as Q1 "
                  +"  left outer join "
                  +"  ( "
                  + "  select OutletID,CustomerID, isnull(sum(PHGLS),0)as PHGLS,  isnull(sum(PHGLSTO),0)as PHGLSTO, isnull(sum(TRGLS),0)as TRGLS, isnull(sum(TRGLSTO),0)as TRGLSTO, isnull(sum(CFL),0)as CFL, isnull(sum(CFLTO),0)as CFLTO, isnull(sum(TL),0)as TL,isnull(sum(TLTO),0)as TLTO "
                  +"  from TELAddDB.DBO.t_CampaignOutletTran "
                  +"  where Trandate between ? and ? "
                  +"  group by OutletID,CustomerID "
                  +"  )as Q2 on Q1.OutletID=Q2.OutletID  " 
                  +"  where  DistributorID= ? " ;


            cmd.Parameters.AddWithValue("FromDate", dFromDate);
            cmd.Parameters.AddWithValue("ToDate", dTodate);
            cmd.Parameters.AddWithValue("DistributorID", nUserID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CampaignOutlet oCampaignOutlet = new CampaignOutlet();

                    oCampaignOutlet.OutletID = (int)reader["OutletID"];                   
                    oCampaignOutlet.DistributorID = (int)reader["DistributorID"];
                    //oCampaignOutlet.RouteName = (string)reader["RouteName"];                    
                    oCampaignOutlet.OutletName = (string)reader["OutletName"];
                    oCampaignOutlet.Address = (string)reader["Address"];

                    oCampaignOutlet.PHGLS = Convert.ToInt16(reader["PHGLS"]);
                    oCampaignOutlet.PHGLSTO = Convert.ToDouble(reader["PHGLSTO"]);

                    oCampaignOutlet.TRGLS = Convert.ToInt16(reader["TRGLS"]); 
                    oCampaignOutlet.TRGLSTO = Convert.ToDouble(reader["TRGLSTO"]);

                    oCampaignOutlet.CFL = Convert.ToInt16(reader["CFL"]);
                    oCampaignOutlet.CFLTO = Convert.ToDouble(reader["CFLTO"]);

                    oCampaignOutlet.TL = Convert.ToInt16(reader["TL"]);
                    oCampaignOutlet.TLTO = Convert.ToInt16(reader["TLTO"]);

                  
                    //oCampaignOutlet.Week9 = Convert.ToDouble(reader["Week9"]);
                    //oCampaignOutlet.Week10 = Convert.ToDouble(reader["Week10"]);
                    //oCampaignOutlet.Week11 = Convert.ToDouble(reader["Week11"]);
                    //oCampaignOutlet.Week12 = Convert.ToDouble(reader["Week12"]);
                    //oCampaignOutlet.Total = Convert.ToDouble(reader["TotalQty"]);
                    //oCampaignOutlet.Ach=Convert.ToDouble(reader["Ach"]);
                    //oCampaignOutlet.Week9TO = Convert.ToDouble(reader["Week9TO"]);
                    //oCampaignOutlet.Week10TO = Convert.ToDouble(reader["Week10TO"]);
                    //oCampaignOutlet.Week11TO = Convert.ToDouble(reader["Week11TO"]);
                    //oCampaignOutlet.Week12TO = Convert.ToDouble(reader["Week12TO"]);
                    //oCampaignOutlet.TotalTO = Convert.ToDouble(reader["TotalTO"]);




                    InnerList.Add(oCampaignOutlet);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetDistributorsBy(int nTerritoryID)
        {
            InnerList.Clear();

            //DMSUser oDMSUser;
            //Customer oCustomer;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select CustomerID,CustomerCode, CustomerName, TerritoryID,TerritoryName from v_CustomerDetails where TerritoryID= ?";
            cmd.Parameters.AddWithValue("TerritoryID", nTerritoryID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CampaignOutlet oCampaignOutlet = new CampaignOutlet();
                    oCampaignOutlet.DistributorID = (int)reader["CustomerID"];
                    oCampaignOutlet.CustomerName = (string)reader["CustomerName"];

                    InnerList.Add(oCampaignOutlet);

                }
                reader.Close();              
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {

                throw (ex);
            }


        }

        public void GetOutletBy(int nDistributorID)
        {
            CampaignOutlet oCampaignOutlet = new CampaignOutlet();

            InnerList.Clear();

            //DMSUser oDMSUser;
            //Customer oCustomer;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from TELaddDB.dbo.t_CampaignOutlet where DistributorID=? ";
            cmd.Parameters.AddWithValue("TerritoryID", nDistributorID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                //oCampaignOutlet = new CampaignOutlet();
                //oCampaignOutlet.DistributorID = -1;
                //oCampaignOutlet.OutletName = "<Select Outlet>";
                //InnerList.Add(oCampaignOutlet);


                while (reader.Read())
                {
                    oCampaignOutlet = new CampaignOutlet();
                    oCampaignOutlet.DistributorID = (int)reader["DistributorID"];
                    oCampaignOutlet.OutletID = (int)reader["OutletID"];
                    oCampaignOutlet.OutletName = (string)reader["OutletName"];
                    oCampaignOutlet.Address = (string)reader["Address"];
                    oCampaignOutlet.Contact = (string)reader["Contact"];
                    
                    InnerList.Add(oCampaignOutlet);

                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {

                throw (ex);
            }


        }

        public void GetWeek(DateTime dSysdate)
        {
            CampaignOutlet oCampaignOutlet = new CampaignOutlet();

            InnerList.Clear();           

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from TELAddDB.DBO.t_CampaignWeek where ? >=FromDate and  ? <= todate ";
            cmd.Parameters.AddWithValue("SysDate", dSysdate);
            cmd.Parameters.AddWithValue("SysDate", dSysdate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();              
                
                while (reader.Read())
                {
                    oCampaignOutlet = new CampaignOutlet();
                    oCampaignOutlet.WeekID = (int)reader["WeekID"];
                    oCampaignOutlet.WeekName = (string)reader["WeekName"];                   

                    InnerList.Add(oCampaignOutlet);

                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {

                throw (ex);
            }


        }
    
    }
}
