using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class rptJourneyPlan
    {
       
        private string _sRouteName;
        private string _sDsrName;
        private int _nOutletCode;
        private string _sOutletName;
        private string _sWeekDay;

        public string RouteName
        {
            get { return _sRouteName; }
            set { _sRouteName = value; }

        }
        public string DSRName
        {
            get { return _sDsrName; }
            set { _sDsrName = value; }
        }


        public int OutletCode
        {
            get { return _nOutletCode; }
            set { _nOutletCode = value; }
        }

        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value; }
        }

        public string WeekDay
        {
            get { return _sWeekDay; }
            set { _sWeekDay = value; }
        }
        
    }

    public class rptJourneyPlans : CollectionBase
    {
        public rptJourneyPlan this[int i]
        {
            get { return (rptJourneyPlan)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(rptJourneyPlan orptJourneyPlan)
        {
            InnerList.Add(orptJourneyPlan);
        }
        public void GetJourneyPlan(int nUserID, int nRouteID, int nDSRID, int nDay)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "select routename,dsrname,outletcode,outletname,dayno"
              + " from t_dmsdsr dsr,t_dmsjourneyplan jp, t_dmsroute route, t_dmsoutlet ot, t_customer c"
              + " where dsr.dsrid=jp.dsrid and dsr.distributorid=jp.distributorid and route.routeid=jp.routeid"
              + " and ot.routeid=route.routeid and c.customerid=ot.distributorid and ot.distributorid= '" + nUserID + "'";

            if (nRouteID != -1)
            {
                sSql = sSql + " and route.routeid = '" + nRouteID + "'";
            }
            if (nDSRID != -1)
            {
                sSql = sSql + " and dsr.dsrid = '" + nDSRID + "'";
            }

            if (nDay != 0)
            {
                sSql = sSql + " and jp.dayno = '" + nDay + "'";
            }

            try
            {
                cmd.CommandText = sSql + " group by dayno,customername,dsrname,routename,outletcode,outletname";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["OutletCode"] != null)
                    {
                        rptJourneyPlan orptJourneyPlan = new rptJourneyPlan();

                        orptJourneyPlan.RouteName = (string)reader["RouteName"];
                        orptJourneyPlan.DSRName = (string)reader["DSRName"];
                        orptJourneyPlan.OutletCode = (int)reader["OutletCode"];
                        orptJourneyPlan.OutletName = (string)reader["OutletName"];
                        if ((int)reader["DayNo"] == 1) orptJourneyPlan.WeekDay = "Saturday";
                        if ((int)reader["DayNo"] == 2) orptJourneyPlan.WeekDay = "Sunday";
                        if ((int)reader["DayNo"] == 3) orptJourneyPlan.WeekDay = "Monday";
                        if ((int)reader["DayNo"] == 4) orptJourneyPlan.WeekDay = "Tuesday";
                        if ((int)reader["DayNo"] == 5) orptJourneyPlan.WeekDay = "Wednesday";
                        if ((int)reader["DayNo"] == 6) orptJourneyPlan.WeekDay = "Thursday";
                        if ((int)reader["DayNo"] == 7) orptJourneyPlan.WeekDay = "Friday";

                        InnerList.Add(orptJourneyPlan);
                    }

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
