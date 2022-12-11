// <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana
// Date: August 2014
// Time : 010:00 AM
// Description: Form for frmRptRouteSalesTran 
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
    public class rptRouteSalesTran
    {
        private int _nTranID;
        private string _sCustomerCode;
        private int _nRouteCode;
        private DateTime _dTranDate;
        private int _nASGID;
        private int _nBrandID;
        private int _nSalesplan;
        private int _nSalesUPlan;
        private int _nSalesFinal;
        private int _nSalesConfirm;
        private int _nOutletPlan;
        private int _nOutletUPlan;
        private int _nOutletFinal;
        private int _nOutletDelivered;
        private int _nNOutletplan;
        private int _nNOutletUpdateplan;
        private int _nNOutletFinal;
        private int _nNOutletDelivered;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nAreaID;
        private int _nTerritoryID;
        private string _sAreaName;
        private string _sTerritoryName;
        private string _sCustomerName;
        private string _sRouteName;
        private int _nCustomerID;
        private string _sASGName;
        private string _sBrandName;
        private string _sSACode;
        private string _sSAName;
        private string _sDesignation;
        private int _nISActive;
        private int _nD1;
        private int _nD2;
        private int _nD3;
        private int _nD4;
        private int _nD5;
        private int _nD6;
        private int _nD7;
        private int _nD8;
        private int _nD9;
        private int _nD10;
        private int _nD11;
        private int _nD12;
        private int _nD13;
        private int _nD14;
        private int _nD15;
        private int _nD16;
        private int _nD17;
        private int _nD18;
        private int _nD19;
        private int _nD20;
        private int _nD21;
        private int _nD22;
        private int _nD23;
        private int _nD24;
        private int _nD25;
        private int _nD26;
        private int _nD27;
        private int _nD28;
        private int _nD29;
        private int _nD30;
        private int _nD31;



        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        public int RouteCode
        {
            get { return _nRouteCode; }
            set { _nRouteCode = value; }
        }
        public DateTime Trandate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public int Salesplan
        {
            get { return _nSalesplan; }
            set { _nSalesplan = value; }
        }
        public int SalesUPlan
        {
            get { return _nSalesUPlan; }
            set { _nSalesUPlan = value; }
        }
        public int SalesFinal
        {
            get { return _nSalesFinal; }
            set { _nSalesFinal = value; }
        }
        public int SalesConfirm
        {
            get { return _nSalesConfirm; }
            set { _nSalesConfirm = value; }
        }
        public int OutletPlan
        {
            get { return _nOutletPlan; }
            set { _nOutletPlan = value; }
        }
        public int OutletUPlan
        {
            get { return _nOutletUPlan; }
            set { _nOutletUPlan = value; }
        }
        public int OutletFinal
        {
            get { return _nOutletFinal; }
            set { _nOutletFinal = value; }
        }
        public int OutletDelivered
        {
            get { return _nOutletDelivered; }
            set { _nOutletDelivered = value; }
        }
        public int NOutletplan
        {
            get { return _nNOutletplan; }
            set { _nNOutletplan = value; }
        }
        public int NOutletUpdateplan
        {
            get { return _nNOutletUpdateplan; }
            set { _nNOutletUpdateplan = value; }
        }
        public int NOutletFinal
        {
            get { return _nNOutletFinal; }
            set { _nNOutletFinal = value; }
        }
        public int NOutletDelivered
        {
            get { return _nNOutletDelivered; }
            set { _nNOutletDelivered = value; }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }

        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value.Trim(); }
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
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value.Trim(); }
        }
        public string SACode
        {
            get { return _sSACode; }
            set { _sSACode = value.Trim(); }
        }
        public string SAName
        {
            get { return _sSAName; }
            set { _sSAName = value.Trim(); }
        }
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value.Trim(); }
        }
        public int ISActive
        {
            get { return _nISActive; }
            set { _nISActive = value; }
        }
        public int D1
        {
            get { return _nD1; }
            set { _nD1 = value; }
        }
        public int D2
        {
            get { return _nD2; }
            set { _nD2 = value; }
        }
        public int D3
        {
            get { return _nD3; }
            set { _nD3 = value; }
        }
        public int D4
        {
            get { return _nD4; }
            set { _nD4 = value; }
        }
        public int D5
        {
            get { return _nD5; }
            set { _nD5 = value; }
        }
        public int D6
        {
            get { return _nD6; }
            set { _nD6 = value; }
        }
        public int D7
        {
            get { return _nD7; }
            set { _nD7 = value; }
        }
        public int D8
        {
            get { return _nD8; }
            set { _nD8 = value; }
        }
        public int D9
        {
            get { return _nD9; }
            set { _nD9 = value; }
        }
        public int D10
        {
            get { return _nD10; }
            set { _nD10 = value; }
        }
        public int D11
        {
            get { return _nD11; }
            set { _nD11 = value; }
        }
        public int D12
        {
            get { return _nD12; }
            set { _nD12 = value; }
        }
        public int D13
        {
            get { return _nD13; }
            set { _nD13 = value; }
        }
        public int D14
        {
            get { return _nD14; }
            set { _nD14 = value; }
        }
        public int D15
        {
            get { return _nD15; }
            set { _nD15 = value; }
        }
        public int D16
        {
            get { return _nD16; }
            set { _nD16 = value; }
        }
        public int D17
        {
            get { return _nD17; }
            set { _nD17 = value; }
        }
        public int D18
        {
            get { return _nD18; }
            set { _nD18 = value; }
        }
        public int D19
        {
            get { return _nD19; }
            set { _nD19 = value; }
        }
        public int D20
        {
            get { return _nD20; }
            set { _nD20 = value; }
        }
        public int D21
        {
            get { return _nD21; }
            set { _nD21 = value; }
        }
        public int D22
        {
            get { return _nD22; }
            set { _nD22 = value; }
        }
        public int D23
        {
            get { return _nD23; }
            set { _nD23 = value; }
        }
        public int D24
        {
            get { return _nD24; }
            set { _nD24 = value; }
        }
        public int D25
        {
            get { return _nD25; }
            set { _nD25 = value; }
        }
        public int D26
        {
            get { return _nD26; }
            set { _nD26 = value; }
        }
        public int D27
        {
            get { return _nD27; }
            set { _nD27 = value; }
        }
        public int D28
        {
            get { return _nD28; }
            set { _nD28 = value; }
        }
        public int D29
        {
            get { return _nD29; }
            set { _nD29 = value; }
        }
        public int D30
        {
            get { return _nD30; }
            set { _nD30 = value; }
        }
        public int D31
        {
            get { return _nD31; }
            set { _nD31 = value; }
        }
    }
    public class rptRouteSalesTrans : CollectionBaseCustom
    {
        public void Add(rptRouteSalesTran orptRouteSalesTran)
        {
            this.List.Add(orptRouteSalesTran);
        }
        public rptRouteSalesTran this[Int32 Index]
        {
            get
            {
                return (rptRouteSalesTran)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptRouteSalesTran))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void RouteSalesTran(int nUserID,DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID, int nASGID, int nBrandID)
        {
           // Users oUsers = new Users();
           // string sPermission = oUsers.GetDataID(nUserID, "Area");
           //// oUser = (User)Session["User"];
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql =  "select AreaID,AreaName,TerritoryID,Territoryname,CustomerName, CustomerCode, " + 
                    "RouteCode,RouteName, Final.ASGID,Final.CustomerID, ASGName= case when ASGID=125 then " +
                    "'GLS' when ASGID=126 then 'CFL' when ASGID=127 then 'TL'  " +
                    "else 'No' " +
                    "end, " +
                    "BrandName= case when BrandID=1 then 'Philips' when BrandID=4 then 'Transtec' " + 
                    "else 'No' end, " +
                    "Final.BrandID,SalesTgt, SalesAch,Delivery, MemoTGT,MemoAch,  MemoDelivery, NewMemoTGT,NewMemoAch,NewMemoDeli from " +
                    "( " +
                    "select AreaID,AreaName,TerritoryID,Territoryname,CustomerID,CustomerName, Q1.CustomerCode, Q1.RouteCode,Q1.RouteName, " +
                    "Q1.ASGID, Q1.BrandID, isnull(SalesTgt,0) as SalesTgt, isnull(SalesAch,0)as SalesAch, isnull(Delivery,0)as Delivery, " +
                    "isnull(MemoTGT,0)as MemoTGT,isnull(MemoAch,0)as MemoAch, isnull(MemoDelivery,0)as MemoDelivery, isnull(NewMemoTGT,0)as NewMemoTGT, " +
                    "isnull(NewMemoAch,0)as NewMemoAch, isnull(NewMemoDeli,0)as NewMemoDeli from  " + 
                    "( " +
                    "select a.CustomerCode, a.RouteCode,RouteName, ASGID, BrandID, sum(SalesPlan) as SalesTgt, sum(SalesFinal)as SalesAch, " +
                    "sum(SalesConfirm)as Delivery, sum(OutletPlan)as MemoTGT, sum(OutletFinal)as MemoAch, sum(OutletDelivered)as MemoDelivery, " +
                    "sum(NOutletPlan)as NewMemoTGT, sum(NOutletFinal)as NewMemoAch, sum(NOutletDelivered)as NewMemoDeli  " +
                    "from TElAddDb.dbo.t_RouteSalesTran a, TELAddDb.dbo.t_Route b where a.RouteCode=b.RouteCode  " +
                    "and Trandate between ' " + dDFromDate + "' and ' " + dDToDate + " ' " +
                    "group by  a.CustomerCode, a.RouteCode,RouteName, ASGID,BrandID  )as Q1  " +
                    "inner join (select AreaID,AreaName,TerritoryID,Territoryname,CustomerID,CustomerCode,CustomerName from " + 
                    "BLLSysDB.DBO.v_Customerdetails )as Q2 on Q1.CustomerCode=Q2.CustomerCode )As Final  ";
            if (nCustomerID > -1)
            {
                sSql = sSql + " where customerid= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " where customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {

                sSql = sSql + " and areaid = " + nAreaID + "";

            }
            //else
            //{
                
            //    sSql = sSql + " and OutletID IN (select * from t_MarketGroup where MarketGroupType = 1 and MarketGroupID in (" + sPermission + "))";

            //    cmd.Parameters.AddWithValue("UserID", nUserID);
            
            
            //}
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }
           
            if (nASGID != -1)
            {
                sSql = sSql + " and asgid = '" + nASGID + "'";

            }
            if (nBrandID != -1)
            {
                sSql = sSql + " and brandid = '" + nBrandID + "'";

            }



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptRouteSalesTran orptRouteSalesTran = new rptRouteSalesTran();


                    orptRouteSalesTran.AreaID = (int)reader["AreaID"];
                    orptRouteSalesTran.AreaName = reader["AreaName"].ToString();
                    orptRouteSalesTran.TerritoryID = (int)reader["TerritoryID"];
                    orptRouteSalesTran.TerritoryName = reader["TerritoryName"].ToString();
                    orptRouteSalesTran.CustomerName = reader["CustomerName"].ToString();
                    orptRouteSalesTran.CustomerCode = reader["CustomerCode"].ToString();
                    orptRouteSalesTran.RouteCode = (int)reader["RouteCode"];
                    orptRouteSalesTran.RouteName = reader["RouteName"].ToString();
                    orptRouteSalesTran.ASGID = (int)reader["ASGID"];
                    orptRouteSalesTran.CustomerID = (int)reader["CustomerID"];
                    orptRouteSalesTran.ASGName = reader["ASGName"].ToString();
                    orptRouteSalesTran.BrandName = reader["BrandName"].ToString();
                    orptRouteSalesTran.BrandID = (int)reader["BrandID"];
                   // orptRouteSalesTran.Trandate = (DateTime)reader["Trandate"];
                    orptRouteSalesTran.Salesplan = (int)reader["SalesTgt"];
                    orptRouteSalesTran.SalesFinal = (int)reader["SalesAch"];
                    orptRouteSalesTran.SalesConfirm = (int)reader["Delivery"];
                    orptRouteSalesTran.OutletPlan = (int)reader["MemoTGT"];
                    orptRouteSalesTran.OutletFinal = (int)reader["MemoAch"];
                    orptRouteSalesTran.OutletDelivered = (int)reader["MemoDelivery"];
                    orptRouteSalesTran.NOutletplan = (int)reader["NewMemoTGT"];
                    orptRouteSalesTran.NOutletFinal = (int)reader["NewMemoAch"];
                    orptRouteSalesTran.NOutletDelivered = (int)reader["NewMemoDeli"];


                    InnerList.Add(orptRouteSalesTran);
                    
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RouteSalesTranLog(int nUserID, DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID)
        {
            // Users oUsers = new Users();
            // string sPermission = oUsers.GetDataID(nUserID, "Area");
            //// oUser = (User)Session["User"];
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "select CustomerID,Q1.CustomerCode,CustomerName,AreaID, AreaName,TerritoryID,TerritoryName,SACode,SAName,Q1.RouteCode,RouteName, DesigNation,Q1.Isactive, " +
                   "ISNULL(D1,0) AS D1,ISNULL(D2,0) AS D2,ISNULL(D3,0) AS D3,ISNULL(D4,0) AS D4,ISNULL(D5,0) AS D5,ISNULL(D6,0) AS D6,ISNULL(D7,0)AS D7,ISNULL(D8,0) AS D8,ISNULL(D9,0) AS D9,ISNULL(D10,0) AS D10,ISNULL(D11,0) AS D11,ISNULL(D12,0) AS D12,ISNULL(D13,0)AS D13,ISNULL(D14,0) AS D14,ISNULL(D15,0) AS D15,ISNULL(D16,0) AS D16,ISNULL(D17,0) AS D17,ISNULL(D18,0) AS D18,ISNULL(D19,0) AS D19, " +
                   "ISNULL(D20,0) AS D20,ISNULL(D21,0) AS D21,ISNULL(D22,0) AS D22,ISNULL(D23,0) AS D23,ISNULL(D24,0) AS D24,ISNULL(D25,0) AS D25,ISNULL(D26,0) AS D26,ISNULL(D27,0) AS D27,ISNULL(D28,0) AS D28,ISNULL(D29,0) AS D29,ISNULL(D30,0) AS D30,ISNULL(D31,0) AS D31 " +
                   "from " +
                   "( " +
                   "select CustomerID,a.CustomerCode,CustomerName, AreaID,AreaName,TerritoryID,TerritoryName,SACode,SAName,RouteCode,RouteName, DesigNation,a.Isactive " +
                   "from TELAddDb.dbo.t_SADetailInfo a, TELAddDb.dbo.t_Route b, BLLsysDB.dbo.v_Customerdetails c " +
                   "where b.Isactive=1 and a.SACode=b.JSACode and a.CustomerCode=c.CustomerCode " +
                   ")Q1 " +
                   "left outer join  " +
                   "(  " +
                   "select RouteCode, " +
                   "sum(case day(Trandate) when 1 then Delivery else 0 end ) as D1, " +
                   "sum(case day(Trandate) when 2 then Delivery else 0 end ) as D2, " +
                   "sum(case day(Trandate) when 3 then Delivery else 0 end ) as D3, " +
                   "sum(case day(Trandate) when 4 then Delivery else 0 end ) as D4, " +
                   "sum(case day(Trandate) when 5 then Delivery else 0 end ) as D5, " +
                   "sum(case day(Trandate) when 6 then Delivery else 0 end ) as D6, " +
                   "sum(case day(Trandate) when 7 then Delivery else 0 end ) as D7, " +
                   "sum(case day(Trandate) when 8 then Delivery else 0 end ) as D8, " +
                   "sum(case day(Trandate) when 9 then Delivery else 0 end ) as D9, " +
                   "sum(case day(Trandate) when 10 then Delivery else 0 end ) as D10, " +
                   "sum(case day(Trandate) when 11 then Delivery else 0 end ) as D11, " +
                   "sum(case day(Trandate) when 12 then Delivery else 0 end ) as D12, " +
                   "sum(case day(Trandate) when 13 then Delivery else 0 end ) as D13, " +
                   "sum(case day(Trandate) when 14 then Delivery else 0 end ) as D14, " +
                   "sum(case day(Trandate) when 15 then Delivery else 0 end ) as D15, " +
                   "sum(case day(Trandate) when 16 then Delivery else 0 end ) as D16, " +
                   "sum(case day(Trandate) when 17 then Delivery else 0 end ) as D17, " +
                   "sum(case day(Trandate) when 18 then Delivery else 0 end ) as D18, " +
                   "sum(case day(Trandate) when 19 then Delivery else 0 end ) as D19, " +
                   "sum(case day(Trandate) when 20 then Delivery else 0 end ) as D20, " +
                   "sum(case day(Trandate) when 21 then Delivery else 0 end ) as D21, " +
                   "sum(case day(Trandate) when 22 then Delivery else 0 end ) as D22, " +
                   "sum(case day(Trandate) when 23 then Delivery else 0 end ) as D23, " +
                   "sum(case day(Trandate) when 24 then Delivery else 0 end ) as D24, " +
                   "sum(case day(Trandate) when 25 then Delivery else 0 end ) as D25, " +
                   "sum(case day(Trandate) when 26 then Delivery else 0 end ) as D26, " +
                   "sum(case day(Trandate) when 27 then Delivery else 0 end ) as D27, " +
                   "sum(case day(Trandate) when 28 then Delivery else 0 end ) as D28, " +
                   "sum(case day(Trandate) when 29 then Delivery else 0 end ) as D29, " +
                   "sum(case day(Trandate) when 30 then Delivery else 0 end ) as D30, " +
                   "sum(case day(Trandate) when 31 then Delivery else 0 end ) as D31 " +
                   "from " +
                   "( " +
                   "select RouteCode,Trandate, isnull(sum(SalesPlan),0) as SalesTgt, isnull(sum(SalesFinal),0)as SalesAch, isnull(sum(SalesConfirm),0)as Delivery, " +
                   "isnull(sum(OutletPlan),0)as MemoTGT, isnull(sum(OutletFinal),0)as MemoAch, isnull(sum(OutletDelivered),0)as MemoDelivery, " +
                   "isnull(sum(NOutletPlan),0)as NewMemoTGT, isnull(sum(NOutletFinal),0)as NewMemoAch, isnull(sum(NOutletDelivered),0)as NewMemoDeli " +
                   "from TELAddDb.dbo.t_RouteSalesTran " +
                   "where Trandate between ' " + dDFromDate + " ' and ' " + dDToDate + " ' and Trandate<' " + dDToDate + " ' " + 
                   "group by RouteCode,Trandate " +
                    ")as Q1 " +
                   "group by RouteCode " +
                   ")as Q2 on Q1.RouteCode=Q2.RouteCode ";
            if (nCustomerID > -1)
            {
                sSql = sSql + " where customerid= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " where customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {

                sSql = sSql + " and areaid = " + nAreaID + "";

            }
            //else
            //{

            //    sSql = sSql + " and OutletID IN (select * from t_MarketGroup where MarketGroupType = 1 and MarketGroupID in (" + sPermission + "))";

            //    cmd.Parameters.AddWithValue("UserID", nUserID);


            //}
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }

              sSql = sSql + " order by CustomerCode,SACode,SAName,Q1.RouteCode";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptRouteSalesTran orptRouteSalesTran = new rptRouteSalesTran();

                    orptRouteSalesTran.CustomerID = (int)reader["CustomerID"];
                    orptRouteSalesTran.CustomerCode = reader["CustomerCode"].ToString();
                    orptRouteSalesTran.CustomerName = reader["CustomerName"].ToString();
                    orptRouteSalesTran.AreaID = (int)reader["AreaID"];
                    orptRouteSalesTran.AreaName = reader["AreaName"].ToString();
                    orptRouteSalesTran.TerritoryID = (int)reader["TerritoryID"];
                    orptRouteSalesTran.TerritoryName = reader["TerritoryName"].ToString();
                    orptRouteSalesTran.SACode = reader["SACode"].ToString();
                    orptRouteSalesTran.SAName = reader["SAName"].ToString();
                    orptRouteSalesTran.RouteCode = (int)reader["RouteCode"];
                    orptRouteSalesTran.RouteName = reader["RouteName"].ToString();
                    orptRouteSalesTran.Designation = reader["Designation"].ToString();
                    orptRouteSalesTran.ISActive = (int)reader["ISActive"];
                    orptRouteSalesTran.D1 = (int)reader["D1"];
                    orptRouteSalesTran.D2 = (int)reader["D2"];
                    orptRouteSalesTran.D3 = (int)reader["D3"];
                    orptRouteSalesTran.D4 = (int)reader["D4"];
                    orptRouteSalesTran.D5 = (int)reader["D5"];
                    orptRouteSalesTran.D6 = (int)reader["D6"];
                    orptRouteSalesTran.D7 = (int)reader["D7"];
                    orptRouteSalesTran.D8 = (int)reader["D8"];
                    orptRouteSalesTran.D9 = (int)reader["D9"];
                    orptRouteSalesTran.D10 = (int)reader["D10"];
                    orptRouteSalesTran.D11 = (int)reader["D11"];
                    orptRouteSalesTran.D12 = (int)reader["D12"];
                    orptRouteSalesTran.D13 = (int)reader["D13"];
                    orptRouteSalesTran.D14 = (int)reader["D14"];
                    orptRouteSalesTran.D15 = (int)reader["D15"];
                    orptRouteSalesTran.D16 = (int)reader["D16"];
                    orptRouteSalesTran.D17 = (int)reader["D17"];
                    orptRouteSalesTran.D18 = (int)reader["D18"];
                    orptRouteSalesTran.D19 = (int)reader["D19"];
                    orptRouteSalesTran.D20 = (int)reader["D20"];
                    orptRouteSalesTran.D21 = (int)reader["D21"];
                    orptRouteSalesTran.D22 = (int)reader["D22"];
                    orptRouteSalesTran.D23 = (int)reader["D23"];
                    orptRouteSalesTran.D24 = (int)reader["D24"];
                    orptRouteSalesTran.D25 = (int)reader["D25"];
                    orptRouteSalesTran.D26 = (int)reader["D26"];
                    orptRouteSalesTran.D27 = (int)reader["D27"];
                    orptRouteSalesTran.D28 = (int)reader["D28"];
                    orptRouteSalesTran.D29 = (int)reader["D29"];
                    orptRouteSalesTran.D30 = (int)reader["D30"];
                    orptRouteSalesTran.D31 = (int)reader["D31"];



                    InnerList.Add(orptRouteSalesTran);

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
