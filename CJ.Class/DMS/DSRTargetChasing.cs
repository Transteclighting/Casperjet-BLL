// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak kumar Chakraborty
// Date: Jun 21, 2014
// Time: 02:00 PM
// Description: Class for DSR Target 
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
    public class DSRTargetChasing
    {
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nRouteCode;
        private string _sRouteName;       
        private int _nSACode;
        private string _sSAName;
        private int _nASGID;
        private string _sASGname;
        private int _nBrandID;
        private string _sBrandName;
        private int _nTargetQty;
        private int _nW1;
        private int _nW2;
        private int _nW3;
        private int _nW4;
        private int _nW5;
        private int _nToOutlet;

        private int _nTranID;
        private DateTime _dTranDate;
        private int _nSalesPlan;
        private int _nSalesUPlan;
        private int _nSalesFinal;
        private int _nSalesConfirm;

        private int _nOutletPlan;
        private int _nOutletUplan;
        private int _nOutletFinal;
        private int _nOutletDelivered;

        private int _nNOutletPlan;
        private int _nNOutletUpdatePlan;
        private int _nNoutletFinal;
        private int _nNOutletDelivered;

                

       //  VIEW first Table

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }

        public int RouteCode
        {
            get { return _nRouteCode; }
            set { _nRouteCode = value; }
        }

        public string RouteName
        {
            get { return _sRouteName; }
            set { _sRouteName = value; }
        }

        public int SACode
        {
            get { return _nSACode; }
            set { _nSACode = value; }
        }

        public string SAName
        {
            get { return _sSAName; }
            set { _sSAName = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        public string ASGName
        {
            get { return _sASGname; }
            set { _sASGname = value; }
        }

        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        public int TGTQty
        {
            get { return _nTargetQty; }
            set { _nTargetQty = value; }
        }

        public int W1
        {
            get { return _nW1; }
            set { _nW1 = value; }
        }

        public int W2
        {
            get { return _nW2; }
            set { _nW2 = value; }
        }

        public int W3
        {
            get { return _nW3; }
            set { _nW3 = value; }
        }
        public int W4
        {
            get { return _nW4; }
            set { _nW4 = value; }
        }

        public int W5
        {
            get { return _nW5; }
            set { _nW5 = value; }
        }
        public int ToOutlet
        {
            get { return _nToOutlet; }
            set { _nToOutlet = value; }
        }


        // Sales Entry

        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        public int SalesPlan
        {
            get { return _nSalesPlan; }
            set { _nSalesPlan = value; }
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

        // outlet Old 


        public int OutletPlan
        {
            get { return _nOutletPlan; }
            set { _nOutletPlan = value; }
        }

        public int OutletUplan
        {
            get { return _nOutletUplan; }
            set { _nOutletUplan = value; }
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

        // Outlet New

        public int NOutletPlan
        {
            get { return _nNOutletPlan; }
            set { _nNOutletPlan = value; }
        }
        public int NOutletUpdatePlan
        {
            get { return _nNOutletUpdatePlan; }
            set { _nNOutletUpdatePlan = value; }
        }
        public int NoutletFinal
        {
            get { return _nNoutletFinal; }
            set { _nNoutletFinal = value; }
        }
        public int NOutletDelivered
        {
            get { return _nNOutletDelivered; }
            set { _nNOutletDelivered = value; }
        }


        public void AddSales()
        {
            int nMaxTranID = 0;
            //int nMaxDSRCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) from TELAddDb.dbo.t_RouteSalesTran ";
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
                _nTranID = nMaxTranID;
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO TELAddDb.DBO.t_RouteSalesTran VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
                cmd.Parameters.AddWithValue("RouteCode", _nRouteCode);
                cmd.Parameters.AddWithValue("Trandate", _dTranDate);
                cmd.Parameters.AddWithValue("ASGID", _nASGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                if (_nSalesPlan != -1)
                    cmd.Parameters.AddWithValue("SalesPlan", _nSalesPlan);
                else cmd.Parameters.AddWithValue("SalesPlan", null);

                if (_nSalesUPlan != -1)
                    cmd.Parameters.AddWithValue("SalesUPlan", _nSalesUPlan);
                else cmd.Parameters.AddWithValue("SalesUPlan", null);

                if (_nSalesFinal != -1)
                    cmd.Parameters.AddWithValue("SalesFinal", _nSalesFinal);
                else cmd.Parameters.AddWithValue("SalesFinal", null);

                if (_nSalesConfirm != -1)
                    cmd.Parameters.AddWithValue("SalesConfirm", _nSalesConfirm);
                else cmd.Parameters.AddWithValue("SalesConfirm", null);

                if (_nOutletPlan != -1)
                    cmd.Parameters.AddWithValue("OutletPlan", _nOutletPlan);
                else cmd.Parameters.AddWithValue("OutletPlan", null);

                if (_nOutletUplan != -1)
                    cmd.Parameters.AddWithValue("OutletUplan", _nOutletUplan);
                else cmd.Parameters.AddWithValue("OutletUplan", null);

                if (_nOutletFinal != -1)
                    cmd.Parameters.AddWithValue("OutletFinal", _nOutletFinal);
                else cmd.Parameters.AddWithValue("OutletFinal", null);

                if (_nOutletDelivered != -1)
                    cmd.Parameters.AddWithValue("OutletDelivered", _nOutletDelivered);
                else cmd.Parameters.AddWithValue("OutletDelivered", null);

                if (_nNOutletPlan != -1)
                    cmd.Parameters.AddWithValue("NOutletPlan", _nNOutletPlan);
                else cmd.Parameters.AddWithValue("NOutletPlan", null);

                if (_nNOutletUpdatePlan != -1)
                    cmd.Parameters.AddWithValue("NOutletUpdatePlan", _nNOutletUpdatePlan);
                else cmd.Parameters.AddWithValue("NOutletUpdatePlan", null);

                if (_nNoutletFinal != -1)
                    cmd.Parameters.AddWithValue("NoutletFinal", _nNoutletFinal);
                else cmd.Parameters.AddWithValue("NoutletFinal", null);

                if (_nNOutletDelivered != -1)
                    cmd.Parameters.AddWithValue("NOutletDelivered", _nNOutletDelivered);
                else cmd.Parameters.AddWithValue("NOutletDelivered", null);

                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditSales()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {             

                sSql = " UPDATE TELAddDb.DBO.t_RouteSalesTran  SET Trandate=?, SalesPlan=?, SalesUPlan=?, SalesFinal=? ,SalesConfirm=?, "                
                     +" OutletPlan=?, OutletUplan=?, OutletFinal=? ,OutletDelivered=?,"
                     +" NOutletPlan=?, NOutletUpdatePlan=?, NoutletFinal=? ,NOutletDelivered=?  WHERE TranID=? ";
 
                               
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Trandate", _dTranDate);

                if (_nSalesPlan != -1)
                    cmd.Parameters.AddWithValue("SalesPlan", _nSalesPlan);
                else cmd.Parameters.AddWithValue("SalesPlan", null);

                if (_nSalesUPlan != -1)
                    cmd.Parameters.AddWithValue("SalesUPlan", _nSalesUPlan);
                else cmd.Parameters.AddWithValue("SalesUPlan", null);

                if (_nSalesFinal != -1)
                    cmd.Parameters.AddWithValue("SalesFinal", _nSalesFinal);
                else cmd.Parameters.AddWithValue("SalesFinal", null);

                if (_nSalesConfirm != -1)
                    cmd.Parameters.AddWithValue("SalesConfirm", _nSalesConfirm);
                else cmd.Parameters.AddWithValue("SalesConfirm", null);

                if (_nOutletPlan != -1)
                    cmd.Parameters.AddWithValue("OutletPlan", _nOutletPlan);
                else cmd.Parameters.AddWithValue("OutletPlan", null);

                if (_nOutletUplan != -1)
                    cmd.Parameters.AddWithValue("OutletUplan", _nOutletUplan);
                else cmd.Parameters.AddWithValue("OutletUplan", null);

                if (_nOutletFinal != -1)
                    cmd.Parameters.AddWithValue("OutletFinal", _nOutletFinal);
                else cmd.Parameters.AddWithValue("OutletFinal", null);

                if (_nOutletDelivered != -1)
                    cmd.Parameters.AddWithValue("OutletDelivered", _nOutletDelivered);
                else cmd.Parameters.AddWithValue("OutletDelivered", null);

                if (_nNOutletPlan != -1)
                    cmd.Parameters.AddWithValue("NOutletPlan", _nNOutletPlan);
                else cmd.Parameters.AddWithValue("NOutletPlan", null);

                if (_nNOutletUpdatePlan != -1)
                    cmd.Parameters.AddWithValue("NOutletUpdatePlan", _nNOutletUpdatePlan);
                else cmd.Parameters.AddWithValue("NOutletUpdatePlan", null);

                if (_nNoutletFinal != -1)
                    cmd.Parameters.AddWithValue("NoutletFinal", _nNoutletFinal);
                else cmd.Parameters.AddWithValue("NoutletFinal", null);

                if (_nNOutletDelivered != -1)
                    cmd.Parameters.AddWithValue("NOutletDelivered", _nNOutletDelivered);
                else cmd.Parameters.AddWithValue("NOutletDelivered", null);

                cmd.Parameters.AddWithValue("TranID", _nTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * from TELAddDb.dbo.t_RouteSalesTran Where TranDate=? and CustomerCode=? and RouteCode=?";
            cmd.Parameters.AddWithValue("TranDate", _dTranDate);
            cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
            cmd.Parameters.AddWithValue("RouteCode", _nRouteCode);
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;
        }

    }

        public class DSRTargetChasings : CollectionBase
        {

            public DSRTargetChasing this[int i]
            {
                get { return (DSRTargetChasing)InnerList[i]; }
                set { InnerList[i] = value; }
            }

            public int GetIndexByID(int nRouteCode)
            {
                int i = 0;
                foreach (DSRTargetChasing oDSRTargetChasing in this)
                {
                    if (oDSRTargetChasing.RouteCode == nRouteCode)
                        return i;
                    i++;
                }
                return -1;
            }

            public void Add(DSRTargetChasing oDSRTargetChasing)
            {
                InnerList.Add(oDSRTargetChasing);
            }
            public void Refresh(string sCustomerCode, int nRouteCode, DateTime dTranDate)
            {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();


                string sSql = " Select a.ASGID,a.BrandID,ASGname,IsNull(TranID,-1)TranID,IsNull(CustomerCode,-1)CustomerCode,IsNull(RouteCode,-1)RouteCode, " +
                                "IsNull(SalesPlan,-1)SalesPlan,IsNull(SalesUPlan,-1)SalesUPlan,IsNull(SalesFinal,-1)SalesFinal, " +
                                "IsNull(SalesConfirm,-1)SalesConfirm,IsNull(OutletPlan,-1)OutletPlan,IsNull(OutletUPlan,-1)OutletUPlan, " +
                                "IsNull(OutletFinal,-1)OutletFinal,IsNull(OutletDelivered,-1)OutletDelivered,IsNull(NOutletPlan,-1)NOutletPlan, " +
                                "IsNull(NOutletUpdatePlan,-1)NOutletUpdatePlan,IsNull(NOutletFinal,-1)NOutletFinal,IsNull(NOutletDelivered,-1)NOutletDelivered from  " +
                                "( " +
                                "Select distinct ASGID, BrandID,ASGname +'('+ Branddesc +')' as ASGname, SL=case when asgid=126 then 1  " +
                                "when asgid=127 then 2 when asgid=125 then 3 else 4 end " +
                                "from v_productDetails  " +
                                "Where ASGID IN (125,126,127) and BrandID IN (1,4) " +
                                ")a  " +
                                "Left Outer Join " +
                                "( " +
                                "select TranID,CustomerCode,RouteCode,Trandate,ASGID,BrandID,SalesPlan,SalesUPlan,SalesFinal, " +
                                "SalesConfirm,OutletPlan,OutletUPlan,OutletFinal,OutletDelivered,NOutletPlan, " +
                                "NOutletUpdatePlan,NOutletFinal,NOutletDelivered from TELAddDB.dbo.t_RouteSalesTran  " +
                                "Where CustomerCode='" + sCustomerCode + "' and RouteCode=" + nRouteCode + " and TranDate='" + dTranDate + "' " +
                                ")b " +
                                "ON a.ASGID=b.ASGID and a.BrandID=b.BrandID " +
                                "order by SL, a.BrandID "; 


                cmd.Parameters.AddWithValue("RouteCode", nRouteCode);

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        DSRTargetChasing oDSRTargetChasing = new DSRTargetChasing();

                        oDSRTargetChasing.ASGID = (int)reader["ASGID"];
                        oDSRTargetChasing.BrandID = (int)reader["BrandID"];
                        oDSRTargetChasing.ASGName = (string)reader["ASGName"];
                        oDSRTargetChasing.TranID = (int)reader["TranID"];
                        oDSRTargetChasing.CustomerCode = (string)reader["CustomerCode"];
                        oDSRTargetChasing.RouteCode = (int)reader["RouteCode"];

                        oDSRTargetChasing.SalesPlan = (int)reader["SalesPlan"];
                        oDSRTargetChasing.SalesUPlan = (int)reader["SalesUPlan"];
                        oDSRTargetChasing.SalesFinal = (int)reader["SalesFinal"];
                        oDSRTargetChasing.SalesConfirm = (int)reader["SalesConfirm"];

                        oDSRTargetChasing.OutletPlan = (int)reader["OutletPlan"];
                        oDSRTargetChasing.OutletUplan = (int)reader["OutletUPlan"];
                        oDSRTargetChasing.OutletFinal = (int)reader["OutletFinal"];
                        oDSRTargetChasing.OutletDelivered = (int)reader["OutletDelivered"];

                        oDSRTargetChasing.NOutletPlan = (int)reader["NOutletPlan"];
                        oDSRTargetChasing.NOutletUpdatePlan = (int)reader["NOutletUpdatePlan"];
                        oDSRTargetChasing.NoutletFinal = (int)reader["NOutletFinal"];
                        oDSRTargetChasing.NOutletDelivered = (int)reader["NOutletDelivered"];

                        InnerList.Add(oDSRTargetChasing);
                    }
                    reader.Close();
                    InnerList.TrimToSize();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }   
            public void RefreshRoute(int nRouteCode)
            {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();

                                           
                    string sSql = " select Final.RouteCode, RouteName, CustomerCode, CustomerName, SACode,SAName, ASGID, ASGName, BrandID, BrandName, TGTQty,W1,W2,W3,W4,W5,ToOutlet "
                      +"   from"
                      +"  ( "
                      +"  select TGT.RouteCode, TGT.RouteName, TGT.CustomerCode, TGT.CustomerName, TGT.SACode,SAName, ASGID, ASGName, BrandID, BrandName,  "
                      +"  Sl= case when ASGID=126 then 1 when ASGID=127 then 2 when ASGID=125 then 3 else 0 end, "
                      +"  sum(case WeekID when 1 then TGTQty else 0 end ) as W1,sum(case WeekID when 2 then TGTQty else 0 end ) as W2, "
                      +"  sum(case WeekID when 3 then TGTQty else 0 end ) as W3, sum(case WeekID when 4 then TGTQty else 0 end ) as W4,  "
                      +"  sum(case WeekID when 5 then TGTQty else 0 end ) as W5, sum(TGTQty)as TGTQty "
                      +"  from "
                      +"  ( "
                      +"  select a.RouteCode, RouteName, b.CustomerCode, c.CustomerName, SACode, WeekID,ASGID, ASGName, BrandID, BrandName, sum(TGTQty)as TGTQty "
                      +"  from TELAddDB.dbo.t_RouteTarget a, TELAddDB.dbo.t_Route b, BLLSysDB.DBO.v_CustomerDetails c "
                      +"  where a.Routecode=b.RouteCode  and TargetDate >= CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) "
                      +"  and TargetDate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) "
                      +"  and b.CustomerCode=c.CustomerCode and a.RouteCode= ? "
                      +"  group by a.RouteCode, RouteName, b.CustomerCode, c.CustomerName, SACode, WeekID,ASGID, ASGName, BrandID, BrandName "
                      +"  )as TGT "
                      +"  left outer join "
                      +"  ( "
                      +"  select SACode, SAName from TELAddDB.dbo.t_SADetailInfo  "
                      +"  )as SA on TGT.SACode=SA.SACode "                       
                      +"  group by TGT.RouteCode, TGT.RouteName, TGT.CustomerCode, TGT.CustomerName, TGT.SACode,SAName, ASGID, ASGName, BrandID, BrandName "
                      +"  )as Final "
                      +"  left outer join "
                      + " ( "
                      +"  select RouteCode, sum(ElOutlet+GrOutlet) as ToOutlet from TELAddDB.dbo.t_Route group by RouteCode " 
                      +"  )as Olet on Final.RouteCode=Olet.RouteCode "
                      +"  order by Sl,BrandID ";


             cmd.Parameters.AddWithValue("RouteCode", nRouteCode);

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        DSRTargetChasing oDSRTargetChasing = new DSRTargetChasing();


                        oDSRTargetChasing.RouteCode = (int)reader["RouteCode"];
                        oDSRTargetChasing.RouteName = (string)reader["RouteName"];
                        oDSRTargetChasing.CustomerName = (string)reader["CustomerName"];
                        oDSRTargetChasing.SACode = (int)reader["SACode"];
                        oDSRTargetChasing.SAName = (string)reader["SAName"];
                        oDSRTargetChasing.ASGID = (int)reader["ASGID"];
                        oDSRTargetChasing.ASGName = (string)reader["ASGName"];

                        oDSRTargetChasing.BrandID = (int)reader["BrandID"];
                        oDSRTargetChasing.BrandName = (string)reader["BrandName"];
                        oDSRTargetChasing.TGTQty = (int)reader["TGTQty"];
                        oDSRTargetChasing.W1 = (int)reader["W1"];
                        oDSRTargetChasing.W2 = (int)reader["W2"];
                        oDSRTargetChasing.W3 = (int)reader["W3"];
                        oDSRTargetChasing.W4 = (int)reader["W4"];
                        oDSRTargetChasing.W5 = (int)reader["W5"];
                        oDSRTargetChasing.ToOutlet = (int)reader["ToOutlet"];                        
                        InnerList.Add(oDSRTargetChasing);
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
