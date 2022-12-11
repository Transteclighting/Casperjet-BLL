// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: August 18, 2013
// Time :  06:51 PM
// Description: Class for TD Sales Plan.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.Library;

namespace CJ.Class
{
    
    public class TDSalesPlan
    {
        private int _nSalesPlanID;
        private string _sSalesPlanCode;
        private int _nCustomerID;
        private int _nPGID;
        private int _nASGID;
        private int _nSalesPersonelID;
        private DateTime _dPlanningMonth;
        private int _nWeek1;
        private int _nWeek2;
        private int _nWeek3;
        private int _nWeek4;
        private int _nWeek5;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nSubmittedBy;
        private DateTime _dSubmitDate;
        private int _nStatus;
        private bool _bFlag;

        private int _nSaleWeek1;
        private int _nSaleWeek2;
        private int _nSaleWeek3;
        private int _nSaleWeek4;
        private int _nSaleWeek5;

        private int _neWeek1;
        private int _neWeek2;
        private int _neWeek3;
        private int _neWeek4;
        private int _neWeek5;


        /// <summary>
        /// Get set property for SalesPlanID
        /// </summary>
        public int SalesPlanID
         {
             get { return _nSalesPlanID; }
             set { _nSalesPlanID = value; }
         } 
        /// <summary>
         /// Get set property for SalesPlanCode
        /// </summary>
        public string SalesPlanCode
         {
             get { return _sSalesPlanCode; }
             set { _sSalesPlanCode = value.Trim(); }
         } 
        /// <summary>
         /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
         {
             get { return _nCustomerID; }
             set { _nCustomerID = value; }
         } 
        /// <summary>
         /// Get set property for PGID
        /// </summary>
        public int PGID
         {
             get { return _nPGID; }
             set { _nPGID = value; }
         } 
        /// <summary>
         /// Get set property for ASGID
        /// </summary>
        public int ASGID
         {
             get { return _nASGID; }
             set { _nASGID = value; }
         } 
        /// <summary>
         /// Get set property for SalesPersonelID
        /// </summary>
        public int SalesPersonelID
         {
             get { return _nSalesPersonelID; }
             set { _nSalesPersonelID = value; }
         } 
        /// <summary>
         /// Get set property for _dPlainingMonth
        /// </summary>
        public DateTime PlanningMonth
         {
             get { return _dPlanningMonth; }
             set { _dPlanningMonth = value; }
         } 
        /// <summary>
         /// Get set property for Week1
        /// </summary>
        public int Week1
         {
             get { return _nWeek1; }
             set { _nWeek1 = value; }
         }
        /// <summary>
         /// Get set property for Week2
         /// </summary>
        public int Week2
         {
             get { return _nWeek2; }
             set { _nWeek2 = value; }
         }
        /// <summary>
         /// Get set property for Week3
         /// </summary>
        public int Week3
         {
             get { return _nWeek3; }
             set { _nWeek3 = value; }
         }
        /// <summary>
         /// Get set property for Week4
         /// </summary>
        public int Week4
         {
             get { return _nWeek4; }
             set { _nWeek4 = value; }
         }
        /// <summary>
         /// Get set property for Week5
         /// </summary>
        public int Week5
         {
             get { return _nWeek5; }
             set { _nWeek5 = value; }
         } 
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
         {
             get { return _nCreateUserID; }
             set { _nCreateUserID = value; }
         } 
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
         {
             get { return _dCreateDate; }
             set { _dCreateDate = value; }
         }
        /// <summary>
         /// Get set property for SubmittedBy
         /// </summary>
        public int SubmittedBy
         {
             get { return _nSubmittedBy; }
             set { _nSubmittedBy = value; }
         }
        /// <summary>
         /// Get set property for SubmitDate
         /// </summary>
        public DateTime SubmitDate
         {
             get { return _dSubmitDate; }
             set { _dSubmitDate = value; }
         }
        /// <summary>
         /// Get set property for Status
         /// </summary>
        public int Status
         {
             get { return _nStatus; }
             set { _nStatus = value; }
         }
        /// <summary>
         /// Get set property for Sale Week1
         /// </summary>
        public int SaleWeek1
         {
             get { return _nSaleWeek1; }
             set { _nSaleWeek1 = value; }
         }
        /// <summary>
         /// Get set property for Sale Week2
         /// </summary>
        public int SaleWeek2
         {
             get { return _nSaleWeek2; }
             set { _nSaleWeek2 = value; }
         }
        /// <summary>
         /// Get set property for Sale Week3
         /// </summary>
        public int SaleWeek3
         {
             get { return _nSaleWeek3; }
             set { _nSaleWeek3 = value; }
         }
        /// <summary>
         /// Get set property for Sale Week4
         /// </summary>
        public int SaleWeek4
         {
             get { return _nSaleWeek4; }
             set { _nSaleWeek4 = value; }
         }
        /// <summary>
         /// Get set property for Sale Week5
         /// </summary>
        public int SaleWeek5
         {
             get { return _nSaleWeek5; }
             set { _nSaleWeek5 = value; }
         }

         /// <summary>
         /// Get set property for Edit Week1
         /// </summary>
         public int eWeek1
         {
             get { return _neWeek1; }
             set { _neWeek1 = value; }
         }
         /// <summary>
         /// Get set property for Edit Week2
         /// </summary>
         public int eWeek2
         {
             get { return _neWeek2; }
             set { _neWeek2 = value; }
         }
         /// <summary>
         /// Get set property for Edit Week3
         /// </summary>
         public int eWeek3
         {
             get { return _neWeek3; }
             set { _neWeek3 = value; }
         }
         /// <summary>
         /// Get set property for Edit Week4
         /// </summary>
         public int eWeek4
         {
             get { return _neWeek4; }
             set { _neWeek4 = value; }
         }
         /// <summary>
         /// Get set property for Edit Week5
         /// </summary>
         public int eWeek5
         {
             get { return _neWeek5; }
             set { _neWeek5 = value; }
         } 

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        private string _sSalesPerson;
        public string SalesPerson
        {
            get { return _sSalesPerson; }
            set { _sSalesPerson = value; }
        }
        private string _sPGName;
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        private string _sStatusName;
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        private double _sASP;
        public double ASP
        {
            get { return _sASP; }
            set { _sASP = value; }
        }
        private int _nTotalQty;
        public int TotalQty
        {
            get { return _nTotalQty; }
            set { _nTotalQty = value; }
        }
        
        public void Add()
         {
             int nMaxSalesPlanID = 0;
             OleDbCommand cmd = DBController.Instance.GetCommand();
             string sSql = "";

             try
             {
                 sSql = "SELECT MAX([SalesPlanID]) FROM t_TDSalesPlan";
                 cmd.CommandText = sSql;
                 object maxID = cmd.ExecuteScalar();
                 if (maxID == DBNull.Value)
                 {
                     nMaxSalesPlanID = 1;
                 }
                 else
                 {
                     nMaxSalesPlanID = Convert.ToInt32(maxID) + 1;
                 }
                 _nSalesPlanID = nMaxSalesPlanID;

                 sSql = "INSERT INTO t_TDSalesPlan (SalesPlanID,SalesPlanCode,CustomerID,PGID,ASGID,SalesPersonelID,PlanningMonth, " +
                 "Week1,Week2,Week3,Week4,Week5,CreateDate,CreateUserID,Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                 cmd.CommandText = sSql;
                 cmd.CommandType = CommandType.Text;
                 cmd.Parameters.AddWithValue("SalesPlanID", _nSalesPlanID);
                 cmd.Parameters.AddWithValue("SalesPlanCode", _sSalesPlanCode);
                 cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                 cmd.Parameters.AddWithValue("PGID", _nPGID);
                 cmd.Parameters.AddWithValue("ASGID", _nASGID);
                 cmd.Parameters.AddWithValue("SalesPersonelID", _nSalesPersonelID);
                 cmd.Parameters.AddWithValue("PlanningMonth", _dPlanningMonth);
                 cmd.Parameters.AddWithValue("Week1", _nWeek1);
                 cmd.Parameters.AddWithValue("Week2", _nWeek2);
                 cmd.Parameters.AddWithValue("Week3", _nWeek3);
                 cmd.Parameters.AddWithValue("Week4", _nWeek4);
                 cmd.Parameters.AddWithValue("Week5", _nWeek5);
                 cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                 cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                 cmd.Parameters.AddWithValue("Status", _nStatus);

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

                 sSql = "Update t_TDSalesPlan Set SalesPersonelID=?,PlanningMonth=?, " +
                        "Week1=?,Week2=?,Week3=?,Week4=?,Week5=?,SubmittedBy=?,SubmitDate=? Where SalesPlanCode=? and ASGID=?";

                 cmd.CommandText = sSql;
                 cmd.CommandType = CommandType.Text;                
                 
                 cmd.Parameters.AddWithValue("SalesPersonelID", _nSalesPersonelID);
                 cmd.Parameters.AddWithValue("PlanningMonth", _dPlanningMonth);
                 cmd.Parameters.AddWithValue("Week1", _nWeek1);
                 cmd.Parameters.AddWithValue("Week2", _nWeek2);
                 cmd.Parameters.AddWithValue("Week3", _nWeek3);
                 cmd.Parameters.AddWithValue("Week4", _nWeek4);
                 cmd.Parameters.AddWithValue("Week5", _nWeek5);
                 cmd.Parameters.AddWithValue("SubmittedBy", Utility.UserId);
                 cmd.Parameters.AddWithValue("SubmitDate", DateTime.Now);

                 cmd.Parameters.AddWithValue("SalesPlanCode", _sSalesPlanCode);
                 cmd.Parameters.AddWithValue("ASGID", _nASGID);

                 cmd.ExecuteNonQuery();
                 cmd.Dispose();
                 
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
         }
        public void GetPGIDByCode(string sSalesPlanCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT Distinct PGID,SalesPersonelID FROM t_TDSalesPlan Where SalesPlanCode=?";
                cmd.Parameters.AddWithValue("SalesPlanCode", sSalesPlanCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPGID = (int)reader["PGID"];
                    _nSalesPersonelID = (int)reader["SalesPersonelID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetStatus(string sSalesPlanCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT Distinct Status FROM t_TDSalesPlan Where SalesPlanCode=?";
                cmd.Parameters.AddWithValue("SalesPlanCode", sSalesPlanCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nStatus = (int)reader["Status"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void CheckDuplicate()
         {
             OleDbCommand cmd = DBController.Instance.GetCommand();
             int nCount = 0;
             try
             {
                 cmd.CommandText = "SELECT * FROM t_TDSalesPlan where PlanningMonth =?";
                 cmd.Parameters.AddWithValue("PlanningMonth", _dPlanningMonth);
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
             if (nCount != 0) Flag = false;
             else Flag = true;

         }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "Update t_TDSalesPlan Set Status=? Where SalesPlanCode=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.YesOrNoStatus.YES);
                cmd.Parameters.AddWithValue("SalesPlanCode", _sSalesPlanCode);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
    }
    public class TDSalesPlans : CollectionBase
    {

        public TDSalesPlan this[int i]
        {
            get { return (TDSalesPlan)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nTDSalesPlan)
        {
            int i=0;
            foreach (TDSalesPlan oTDSalesPlan in this)
            {
                if (oTDSalesPlan.SalesPlanID == nTDSalesPlan)
                    return i;
                i++;
            }
            return -1;
        }


        public void Add(TDSalesPlan oTDSalesPlan)
        {
            InnerList.Add(oTDSalesPlan);
        }

        public void Refresh(DateTime dtPlanMonth, int nCustomerID, string sCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT Distinct SalesPlanCode, a.CustomerID, OutletCode,PGName,SalesPersonName,PlanningMonth, " +
                        "StatusName=CASE When Status=0 then 'No' else 'Yes'end,Status FROM t_TDSalesPlan a " +
                        "INNER JOIN (select CustomerID,left(CustomerName,3)OutletCode from t_Customer)b " +
                        "ON a.CustomerID=b.CustomerID INNER JOIN " +
                        "(select Distinct PGID, PGName from v_productDetails Where PGID IN (4,1,6))C " +
                        "ON C.PGID=a.PGID INNER JOIN (select * from t_FootFallSalesPerson)d " +
                        "ON d.SalesPersonID=a.SalesPersonelID  Where PlanningMonth=? and a.CustomerID=?";

            cmd.Parameters.AddWithValue("PlanningMonth", dtPlanMonth);
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            if (sCode != "")
            {
                sCode = "%" + sCode + "%";
                sSql = sSql + " and SalesPlanCode LIKE'" + sCode + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlan oTDSalesPlan = new TDSalesPlan();

                    //oTDSalesPlan.SalesPlanID = (int)reader["SalesPlanID"];
                    oTDSalesPlan.SalesPlanCode = (string)reader["SalesPlanCode"];
                    oTDSalesPlan.CustomerID = (int)reader["CustomerID"];
                    oTDSalesPlan.PGName = (string)reader["PGName"];
                    //oTDSalesPlan.ASGID = (int)reader["ASGID"];
                    //oTDSalesPlan.SalesPersonelID = (int)reader["SalesPersonelID"];
                    oTDSalesPlan.PlanningMonth = Convert.ToDateTime(reader["PlanningMonth"].ToString());

                    oTDSalesPlan.StatusName = (string)reader["StatusName"];
                    oTDSalesPlan.SalesPerson = (string)reader["SalesPersonName"];
                    oTDSalesPlan.Status = (int)reader["Status"];

                    InnerList.Add(oTDSalesPlan);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDataByCodeNPG(string sSalesPlanCode, int nPGID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,b.ASGName FROM t_TDSalesPlan a INNER JOIN (Select distinct ASGID, ASGName from v_ProductDetails) b "+
                            "ON a.ASGID=b.ASGID Where SalesPlanCode=? and PGID=?";

            cmd.Parameters.AddWithValue("SalesPlanCode", sSalesPlanCode);
            cmd.Parameters.AddWithValue("PGID", nPGID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlan oTDSalesPlan = new TDSalesPlan();

                    oTDSalesPlan.SalesPlanID = (int)reader["SalesPlanID"];
                    oTDSalesPlan.SalesPlanCode = (string)reader["SalesPlanCode"];
                    oTDSalesPlan.CustomerID = (int)reader["CustomerID"];
                    oTDSalesPlan.PGID = (int)reader["PGID"];
                    oTDSalesPlan.ASGID = (int)reader["ASGID"];
                    oTDSalesPlan.ASGName = (string)reader["ASGName"];
                    oTDSalesPlan.SalesPersonelID = (int)reader["SalesPersonelID"];
                    oTDSalesPlan.PlanningMonth = Convert.ToDateTime(reader["PlanningMonth"].ToString());
                    oTDSalesPlan.Week1 = (int)reader["Week1"];
                    oTDSalesPlan.Week2 = (int)reader["Week2"];
                    oTDSalesPlan.Week3 = (int)reader["Week3"];
                    oTDSalesPlan.Week4 = (int)reader["Week4"];
                    oTDSalesPlan.Week5 = (int)reader["Week5"];
                    oTDSalesPlan.CreateUserID = (int)reader["CreateUserID"];
                    oTDSalesPlan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTDSalesPlan.Status = (int)reader["Status"];

                    InnerList.Add(oTDSalesPlan);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPlanASGByPGID_New(DateTime PlanDate, int nCustomerID, int nPGID)
        {
            TELLib oTELLib = new TELLib();
            DateTime FirstDayLM = oTELLib.FirstDayofLastMonth(PlanDate);
            DateTime FirstDayCM = oTELLib.FirstDayofMonth(PlanDate);

            int nYear = FirstDayLM.Year;
            int nMonth = FirstDayLM.Month;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select CustomerID, a.ASGID,ASGName, PlanYear, PlanMonth, PlanMonthName= CASE When PlanMonth=1 then 'Jan' " +
                        "When PlanMonth=2 then 'Feb' When PlanMonth=3 then 'Mar' When PlanMonth=4 then 'Apr' When PlanMonth=5 then 'May' " +
                        "When PlanMonth=6 then 'Jun' When PlanMonth=7 then 'Jul' When PlanMonth=8 then 'Aug' When PlanMonth=9 then 'Sep' " +
                        "When PlanMonth=10 then 'Oct' When PlanMonth=11 then 'Nov' When PlanMonth=12 then 'Dec' end, Quantity, IsPlanned, Status from t_TDSalesPlan a,   " +
                        "(Select Distinct ASGID, ASGName, PGID from v_productdetails Where PGID IN (1,4,6) and ASGID <> 78)b   " +
                        "Where CustomerID=? and PGID=? and PlanYear=? and PlanMonth=? and a.ASGID=b.ASGID  ";

            


            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("PGID", nPGID);
            cmd.Parameters.AddWithValue("YearID", nYear);
            cmd.Parameters.AddWithValue("MonthNo", nMonth);

            string sASGName = "'CAC'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlan oTDSalesPlan = new TDSalesPlan();

                    oTDSalesPlan.ASGID = (int)reader["ASGID"];
                    oTDSalesPlan.ASGName = (string)reader["ASGName"];
                    //oTDSalesPlan.ASP = Convert.ToDouble(reader["ASP"].ToString());
                    oTDSalesPlan.TotalQty = int.Parse(reader["Quantity"].ToString());
                    

                    //oTDSalesPlan.SaleWeek1 = int.Parse(reader["Week1"].ToString());
                    //oTDSalesPlan.SaleWeek2 = int.Parse(reader["Week2"].ToString());
                    //oTDSalesPlan.SaleWeek3 = int.Parse(reader["Week3"].ToString());
                    //oTDSalesPlan.SaleWeek4 = int.Parse(reader["Week4"].ToString());
                    //oTDSalesPlan.SaleWeek5 = int.Parse(reader["Week5"].ToString());

                    //oTDSalesPlan.Week1 = int.Parse(reader["PWeek1"].ToString());
                    //oTDSalesPlan.Week2 = int.Parse(reader["PWeek2"].ToString());
                    //oTDSalesPlan.Week3 = int.Parse(reader["PWeek3"].ToString());
                    //oTDSalesPlan.Week4 = int.Parse(reader["PWeek4"].ToString());
                    //oTDSalesPlan.Week5 = int.Parse(reader["PWeek5"].ToString());

                    InnerList.Add(oTDSalesPlan);

                    sASGName = sASGName + "," + "'" + oTDSalesPlan.ASGName + "'";
                }

                GetUnmatchASG_NEW(nCustomerID, nYear, nMonth, nPGID, sASGName);
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPlanASGByPGID(DateTime PlanDate, int nCustomerID, int nPGID)
        {
            TELLib oTELLib = new TELLib();
            DateTime FirstDayLM = oTELLib.FirstDayofLastMonth(PlanDate);
            DateTime FirstDayCM = oTELLib.FirstDayofMonth(PlanDate);

            int nYear = FirstDayLM.Year;
            int nMonth = FirstDayLM.Month;            

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.CustomerID,a.ASGID,p.ASGName,round((SaleAmt/TtlQty),0)ASP, a.PGID,a.YearID,a.MonthNo,a.Week1,a.Week2,a.Week3,a.Week4,a.Week5,TtlQty, " +
                            "IsNull(TDPlan.Week1,0) as PWeek1,IsNull(TDPlan.Week2,0) as PWeek2,IsNull(TDPlan.Week3,0) as PWeek3,   " +
                            "IsNull(TDPlan.Week4,0) as PWeek4,IsNull(TDPlan.Week5,0) as PWeek5  " +
                            "from (  " +
                            "Select Distinct ASGID, ASGName from v_ProductDetails where PGID iN (1,4,6) and ASGID<>78)p  " +
                            "Left OUter JOIN  " +
                            "( " +
                            "Select CustomerID,ASGID, PGID,YearID,MonthNo,Sum(SaleAmt)SaleAmt,Sum(TtlQty)TtlQty,Sum(Week1)Week1,Sum(Week2)Week2,Sum(Week3)Week3,Sum(Week4)Week4,Sum(Week5)Week5  " +
                            "from   " +
                            "(  " +
                            "select CustomerID,ASGID, PGID,YearID,MonthNo,Week1,Week2,Week3,Week4,Week5, SaleAmt,(Week1+Week2+Week3+Week4+Week5)TtlQty " +
                            "from(  " +
                            "Select CustomerID,ProductID,YearID,MonthNo, Sum(SaleAmt)SaleAmt, " +
                            "Sum(case WeekName when 'Week1' then SaleQty  else 0 end) as Week1,  " +
                            "Sum(case WeekName when 'Week2' then SaleQty  else 0 end) as Week2,  " +
                            "Sum(case WeekName when 'Week3' then SaleQty  else 0 end) as Week3,  " +
                            "Sum(case WeekName when 'Week4' then SaleQty  else 0 end) as Week4,  " +
                            "Sum(case WeekName when 'Week5' then SaleQty  else 0 end) as Week5  " +
                            "From  " +
                            "(   " +
                            "select CustomerID,ProductID,YearID,MonthNo,WeekName,isnull((sum(CRQty)- sum(DRQty)),0) as SaleQty, isnull((sum(CRAmt)- sum(DRAmt)),0) as SaleAmt  " +
                            "from (  " +
                            "select CustomerID,ProductID,YearID,MonthNo,WeekName,CRQty,DRQty, CRAmt, DRAmt from   " +
                            "(  " +
                            "select InvoiceDate,CustomerID,ProductID,sum(Quantity)as CRQty, 0 as DRQty, Sum(Amt) as CRAmt, 0 as DRAmt  " +
                            "from( " +
                            "select InvoiceDate,sa.CustomerID,ProductID,Quantity,(UnitPrice*Quantity)Amt  " +
                            "from t_salesinvoice sa, t_salesinvoicedetail sd,(Select CustomerID from v_CustomerDetails Where ChannelID=4)c   " +
                            "where c.CustomerID=sa.CustomerID and sa.invoiceid = sd.invoiceid and invoicedate   " +
                            "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "' " +
                            "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)   " +
                            ")CR " +
                            "Group by InvoiceDate,CustomerID,ProductID  " +
                            "union all  " +
                            "select InvoiceDate,CustomerID,ProductID,0 as CRQty,sum(Quantity)as DRQty , 0 as CRAmt, Sum(Amt) as DRAmt  " +
                            "from ( " +
                            "select InvoiceDate,sa.CustomerID,ProductID,Quantity,(UnitPrice*Quantity)Amt  " +
                            "from t_salesinvoice sa, t_salesinvoicedetail sd,(Select CustomerID from v_CustomerDetails Where ChannelID=4)c   " +
                            "where c.CustomerID=sa.CustomerID and sa.invoiceid = sd.invoiceid and invoicedate   " +
                            "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "' " +
                            "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   " +
                            ")DR " +
                            "Group by InvoiceDate,CustomerID,ProductID  " +
                            ")as Sale,t_TDSalesPlanCalendar b Where Sale.InvoiceDate between FromDate and ToDate  " +
                            ")final  " +
                            "Group by  " +
                            "CustomerID,ProductID,YearID,MonthNo,WeekName  " +
                            ") x Group by CustomerID,ProductID,YearID,MonthNo " +
                            ") a   " +
                            "INNER JOIN (Select ProductID,ASGID,PGID from v_productdetails where PGID iN (1,4,6) and ASGID<>78 )Prod  " +
                            "ON Prod.productID=a.ProductID  " +
                            ")final group by CustomerID,ASGID, PGID,YearID,MonthNo  " +
                            ") a ON A.ASGID=P.ASGID  " +
                            "Left Outer JOIN   " +
                            "(select CustomerID,PGID,ASGID,Year(PlanningMonth)as YearID, Month(PlanningMonth) as MonthNo,  " +
                            "Week1,Week2,Week3,Week4,Week5 from dbo.t_TDSalesPlan) TDPlan  " +
                            "ON TDPlan.CustomerID=a.CustomerID and TDPlan.PGID=a.PGID and TDPlan.ASGID=a.ASGID   " +
                            "and TDPlan.YearID=a.YearID and TDPlan.MonthNo=a.MonthNo  " +
                            "Where a.CustomerID=? and a.PGID=? and a.YearID=? and a.MonthNo=? ";

            //string sSql = "Select a.CustomerID,a.ASGID,p.ASGName, a.PGID,a.YearID,a.MonthNo,a.Week1,a.Week2,a.Week3,a.Week4,a.Week5, " +
            //                "IsNull(TDPlan.Week1,0) as PWeek1,IsNull(TDPlan.Week2,0) as PWeek2,IsNull(TDPlan.Week3,0) as PWeek3,  " +
            //                "IsNull(TDPlan.Week4,0) as PWeek4,IsNull(TDPlan.Week5,0) as PWeek5 " +
            //                "from ( " +
            //                "Select Distinct ASGID, ASGName from v_ProductDetails where PGID iN (1,4,6) and ASGID<>78)p " +
            //                "Left OUter JOIN " +
            //                "(Select CustomerID,ASGID, PGID,YearID,MonthNo,Sum(Week1)Week1,Sum(Week2)Week2,Sum(Week3)Week3,Sum(Week4)Week4,Sum(Week5)Week5 " +
            //                "from  " +
            //                "( " +
            //                "select CustomerID,ASGID, PGID,YearID,MonthNo,Week1,Week2,Week3,Week4,Week5  " +
            //                "from( " +
            //                "Select CustomerID,ProductID,YearID,MonthNo, " +
            //                "Sum(case WeekName when 'Week1' then SaleQty  else 0 end) as Week1, " +
            //                "Sum(case WeekName when 'Week2' then SaleQty  else 0 end) as Week2, " +
            //                "Sum(case WeekName when 'Week3' then SaleQty  else 0 end) as Week3, " +
            //                "Sum(case WeekName when 'Week4' then SaleQty  else 0 end) as Week4, " +
            //                "Sum(case WeekName when 'Week5' then SaleQty  else 0 end) as Week5 " +
            //                "From " +
            //                "(  " +
            //                "select CustomerID,ProductID,YearID,MonthNo,WeekName,isnull((sum(CRQty)- sum(DRQty)),0) as SaleQty " +
            //                "from ( " +
            //                "select CustomerID,ProductID,YearID,MonthNo,WeekName,CRQty,DRQty from  " +
            //                "( " +
            //                "select InvoiceDate,sa.CustomerID,ProductID,sum(Quantity)as CRQty, 0 as DRQty " +
            //                "from t_salesinvoice sa, t_salesinvoicedetail sd,(Select CustomerID from v_CustomerDetails Where ChannelID=4)c  " +
            //                "where c.CustomerID=sa.CustomerID and sa.invoiceid = sd.invoiceid and invoicedate  " +
            //                "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "' " +
            //                "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  " +
            //                "Group by InvoiceDate,sa.CustomerID,ProductID " +
            //                "union all " +
            //                "select InvoiceDate,sa.CustomerID,ProductID,0 as CRQty,sum(Quantity)as DRQty " +
            //                "from t_salesinvoice sa, t_salesinvoicedetail sd,(Select CustomerID from v_CustomerDetails Where ChannelID=4)c  " +
            //                "where c.CustomerID=sa.CustomerID and sa.invoiceid = sd.invoiceid and invoicedate  " +
            //                "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "' " +
            //                "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  " +
            //                "Group by InvoiceDate,sa.CustomerID,ProductID " +
            //                ")as Sale,t_TDSalesPlanCalendar b Where Sale.InvoiceDate between FromDate and ToDate " +
            //                ")final " +
            //                "Group by " +
            //                "CustomerID,ProductID,YearID,MonthNo,WeekName " +
            //                ") x Group by CustomerID,ProductID,YearID,MonthNo " +
            //                ") a  " +
            //                "INNER JOIN (Select ProductID,ASGID,PGID from v_productdetails where PGID iN (1,4,6) and ASGID<>78 )Prod " +
            //                "ON Prod.productID=a.ProductID " +
            //                ")final group by CustomerID,ASGID, PGID,YearID,MonthNo " +
            //                ") a ON A.ASGID=P.ASGID " +
            //                "Left Outer JOIN  " +
            //                "(select CustomerID,PGID,ASGID,Year(PlanningMonth)as YearID, Month(PlanningMonth) as MonthNo, " +
            //                "Week1,Week2,Week3,Week4,Week5 from dbo.t_TDSalesPlan) TDPlan " +
            //                "ON TDPlan.CustomerID=a.CustomerID and TDPlan.PGID=a.PGID and TDPlan.ASGID=a.ASGID  " +
            //                "and TDPlan.YearID=a.YearID and TDPlan.MonthNo=a.MonthNo " +
            //                "Where a.CustomerID=? and a.PGID=? and a.YearID=? and a.MonthNo=? ";



            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("PGID", nPGID);
            cmd.Parameters.AddWithValue("YearID", nYear);
            cmd.Parameters.AddWithValue("MonthNo", nMonth);

            string sASGName = "'CAC'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlan oTDSalesPlan = new TDSalesPlan();

                    oTDSalesPlan.ASGID = (int)reader["ASGID"];
                    oTDSalesPlan.ASGName = (string)reader["ASGName"];
                    oTDSalesPlan.ASP = Convert.ToDouble(reader["ASP"].ToString());
                    oTDSalesPlan.TotalQty = int.Parse(reader["TtlQty"].ToString());

                    oTDSalesPlan.SaleWeek1 = int.Parse(reader["Week1"].ToString());
                    oTDSalesPlan.SaleWeek2 = int.Parse(reader["Week2"].ToString());
                    oTDSalesPlan.SaleWeek3 = int.Parse(reader["Week3"].ToString());
                    oTDSalesPlan.SaleWeek4 = int.Parse(reader["Week4"].ToString());
                    oTDSalesPlan.SaleWeek5 = int.Parse(reader["Week5"].ToString());

                    oTDSalesPlan.Week1 = int.Parse(reader["PWeek1"].ToString());
                    oTDSalesPlan.Week2 = int.Parse(reader["PWeek2"].ToString());
                    oTDSalesPlan.Week3 = int.Parse(reader["PWeek3"].ToString());
                    oTDSalesPlan.Week4 = int.Parse(reader["PWeek4"].ToString());
                    oTDSalesPlan.Week5 = int.Parse(reader["PWeek5"].ToString());

                    InnerList.Add(oTDSalesPlan);

                    sASGName = sASGName + "," + "'" + oTDSalesPlan.ASGName + "'";
                }

                GetUnmatchASG(nCustomerID, nYear, nMonth, nPGID, sASGName);
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetUnmatchASG_NEW(int nCustomerID, int nYearID, int nMonthNo, int nPGID, string sASGName)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ASGID, a.ASGName,ASP, PGID,CustomerID,  PlanYear, PlanMonth, PlanMonthName= CASE When PlanMonth=1 then 'Jan' " +
                            "When PlanMonth=2 then 'Feb' When PlanMonth=3 then 'Mar' When PlanMonth=4 then 'Apr' When PlanMonth=5 then 'May' " +
                            "When PlanMonth=6 then 'Jun' When PlanMonth=7 then 'Jul' When PlanMonth=8 then 'Aug' When PlanMonth=9 then 'Sep' " +
                            "When PlanMonth=10 then 'Oct' When PlanMonth=11 then 'Nov' When PlanMonth=12 then 'Dec' end, IsNull(Quantity,0)Quantity, " +
                            "IsNull(IsPlanned,0)IsPlanned, IsNull(Status,0)Status  from   " +
                            "(  " +
                            "Select ASGID, ASGName, PGID, round((RSP/Qty),0)ASP from  " +
                            "( " +
                            "Select ASGID, ASGName, PGID, Count(ASGID)Qty,Sum(RSP)RSP from  " +
                            "( " +
                            "Select ProductID,ASGID, ASGName, PGID, RSP from v_productdetails Where PGID IN (1,4,6) and ASGID <> 78 and IsActive=1 " +
                            ") a group by ASGID, ASGName, PGID)a  " +
                            ")a   " +
                            "Left OUter JOIN   " +
                            "(  " +
                            "Select CustomerID, a.ASGID,ASGName, PlanYear,   " +
                            "PlanMonth, Quantity, IsPlanned, Status from t_TDSalesPlan a,   " +
                            "(Select Distinct ASGID, ASGName, PGID from v_productdetails Where PGID IN (1,4,6) and ASGID <> 78)b   " +
                            "Where CustomerID=? and PlanYear=? and PlanMonth=? and a.ASGID=b.ASGID  " +
                            "and ASGName Not IN (" + sASGName + ")  " +
                            ") b   " +
                            "ON a.ASGID=b.ASGID where a.PGID=? and a.ASGName Not IN (" + sASGName + ")";

            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("YearID", nYearID);
            cmd.Parameters.AddWithValue("MonthNo", nMonthNo);
            cmd.Parameters.AddWithValue("PGID", nPGID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlan oTDSalesPlan = new TDSalesPlan();

                    oTDSalesPlan.ASGID = (int)reader["ASGID"];
                    oTDSalesPlan.ASGName = (string)reader["ASGName"];
                    oTDSalesPlan.ASP = Convert.ToDouble(reader["ASP"].ToString());
                    oTDSalesPlan.Week1 = int.Parse(reader["Week1"].ToString());
                    oTDSalesPlan.Week2 = int.Parse(reader["Week2"].ToString());
                    oTDSalesPlan.Week3 = int.Parse(reader["Week3"].ToString());
                    oTDSalesPlan.Week4 = int.Parse(reader["Week4"].ToString());
                    oTDSalesPlan.Week5 = int.Parse(reader["Week5"].ToString());

                    oTDSalesPlan.SaleWeek1 = 0;
                    oTDSalesPlan.SaleWeek2 = 0;
                    oTDSalesPlan.SaleWeek3 = 0;
                    oTDSalesPlan.SaleWeek4 = 0;
                    oTDSalesPlan.SaleWeek5 = 0;

                    InnerList.Add(oTDSalesPlan);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetUnmatchASG(int nCustomerID, int nYearID, int nMonthNo, int nPGID, string sASGName)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ASGID, a.ASGName,ASP, PGID,CustomerID,  YearID, MonthNo, IsNull(Week1,0)Week1, IsNull(Week2,0)Week2, " +
                            "IsNull(Week3,0)Week3, IsNull(Week4,0)Week4, IsNull(Week5,0)Week5  from  " +
                            "( " +
                            "Select ASGID, ASGName, PGID, round((RSP/Qty),0)ASP from " +
                            "(" +
                            "Select ASGID, ASGName, PGID, Count(ASGID)Qty,Sum(RSP)RSP from " +
                            "(" +
                            "Select ProductID,ASGID, ASGName, PGID, RSP from v_productdetails Where PGID IN (1,4,6) and ASGID <> 78 and IsActive=1" +
                            ") a group by ASGID, ASGName, PGID)a " +
                            ")a  " +
                            "Left OUter JOIN  " +
                            "( " +
                            "Select CustomerID, a.ASGID,ASGName, Year(PlanningMonth) YearID,  " +
                            "Month(PlanningMonth) MonthNo, Week1,Week2,Week3,Week4,Week5 from t_TDSalesPlan a,  " +
                            "(Select Distinct ASGID, ASGName, PGID from v_productdetails Where PGID IN (1,4,6) and ASGID <> 78)b  " +
                            "Where CustomerID=? and Year(PlanningMonth)=? and Month(PlanningMonth)=? and a.ASGID=b.ASGID " +
                            "and ASGName Not IN (" + sASGName + ") " +
                            ") b  " +
                            "ON a.ASGID=b.ASGID where a.PGID=? and a.ASGName Not IN (" + sASGName + ") ";

            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("YearID", nYearID);
            cmd.Parameters.AddWithValue("MonthNo", nMonthNo);
            cmd.Parameters.AddWithValue("PGID", nPGID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlan oTDSalesPlan = new TDSalesPlan();

                    oTDSalesPlan.ASGID = (int)reader["ASGID"];
                    oTDSalesPlan.ASGName = (string)reader["ASGName"];
                    oTDSalesPlan.ASP = Convert.ToDouble(reader["ASP"].ToString());
                    oTDSalesPlan.Week1 = int.Parse(reader["Week1"].ToString());
                    oTDSalesPlan.Week2 = int.Parse(reader["Week2"].ToString());
                    oTDSalesPlan.Week3 = int.Parse(reader["Week3"].ToString());
                    oTDSalesPlan.Week4 = int.Parse(reader["Week4"].ToString());
                    oTDSalesPlan.Week5 = int.Parse(reader["Week5"].ToString());

                    oTDSalesPlan.SaleWeek1 = 0;
                    oTDSalesPlan.SaleWeek2 = 0;
                    oTDSalesPlan.SaleWeek3 = 0;
                    oTDSalesPlan.SaleWeek4 = 0;
                    oTDSalesPlan.SaleWeek5 = 0;

                    InnerList.Add(oTDSalesPlan);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDataForEdit(DateTime PlanDate, int nCustomerID, int nPGID)
        {
            TELLib oTELLib = new TELLib();
            DateTime FirstDayLM = oTELLib.FirstDayofLastMonth(PlanDate);
            DateTime FirstDayCM = oTELLib.FirstDayofMonth(PlanDate);

            int nCYear = FirstDayCM.Year;
            int nCMonth = FirstDayCM.Month;

            int nLYear = FirstDayLM.Year;
            int nLMonth = FirstDayLM.Month;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TDPlanEdit.CustomerID,TDPlanEdit.ASGID,TDPlanEdit.ASGName, TDPlanEdit.PGID,TDPlanEdit.YearID,TDPlanEdit.MonthNo, " +
                        "IsNull(sWeek1,0)sWeek1,IsNull(sWeek2,0)sWeek2,IsNull(sWeek3,0)sWeek3,IsNull(sWeek4,0)sWeek4,IsNull(sWeek5,0)sWeek5,  " +
                        "IsNull(pWeek1,0)pWeek1,IsNull(pWeek2,0)pWeek2,IsNull(pWeek3,0)pWeek3,IsNull(pWeek4,0)pWeek4,IsNull(pWeek5,0)pWeek5,  " +
                        "eWeek1,eWeek2,eWeek3,eWeek4,eWeek5 " +
                        "from " +
                        "( " +
                        "select a.CustomerID,a.PGID,a.ASGID,ASGName, Year(PlanningMonth)as YearID, Month(PlanningMonth) as MonthNo,  " +
                        "Week1 as eWeek1,Week2 as eWeek2,Week3 as eWeek3,Week4 as eWeek4,Week5 as eWeek5 from dbo.t_TDSalesPlan a " +
                        "INNER JOIN (Select Distinct ASGID,ASGName from v_productdetails where PGID iN (1,4,6) and ASGID<>78 )Prod  " +
                        "ON Prod.ASGID=a.ASGID Where a.CustomerID="+nCustomerID+" and a.PGID="+ nPGID+"and Year(PlanningMonth)="+nCYear+" and Month(PlanningMonth)="+nCMonth+" " +
                        ") TDPlanEdit " +
                        "Left Outer JOIN  " +
                        "( " +
                        "Select a.CustomerID,a.ASGID, a.PGID,a.YearID,a.MonthNo,a.Week1 as sWeek1, a.Week2 as sWeek2,a.Week3 as sWeek3, " +
                        "a.Week4 as sWeek4, a.Week5 as sWeek5,TDPlan.Week1 as PWeek1,TDPlan.Week2 as PWeek2, TDPlan.Week3 as PWeek3,   " +
                        "TDPlan.Week4 as PWeek4, TDPlan.Week5 as PWeek5 " +
                        "from ( " +
                        "Select CustomerID,ASGID, PGID,YearID,MonthNo,Sum(Week1)Week1,Sum(Week2)Week2,Sum(Week3)Week3,Sum(Week4)Week4,Sum(Week5)Week5  " +
                        "from   " +
                        "(  " +
                        "select CustomerID,ASGID, PGID,YearID,MonthNo,Week1,Week2,Week3,Week4,Week5   " +
                        "from " +
                        "(  " +
                        "Select CustomerID,ProductID,YearID,MonthNo,  " +
                        "Sum(case WeekName when 'Week1' then SaleQty  else 0 end) as Week1,  " +
                        "Sum(case WeekName when 'Week2' then SaleQty  else 0 end) as Week2,  " +
                        "Sum(case WeekName when 'Week3' then SaleQty  else 0 end) as Week3,  " +
                        "Sum(case WeekName when 'Week4' then SaleQty  else 0 end) as Week4,  " +
                        "Sum(case WeekName when 'Week5' then SaleQty  else 0 end) as Week5  " +
                        "From  " +
                        "(   " +
                        "select CustomerID,ProductID,YearID,MonthNo,WeekName,isnull((sum(CRQty)- sum(DRQty)),0) as SaleQty  " +
                        "from (  " +
                        "select CustomerID,ProductID,YearID,MonthNo,WeekName,CRQty,DRQty from   " +
                        "(  " +
                        "select InvoiceDate,sa.CustomerID,ProductID,sum(Quantity)as CRQty, 0 as DRQty  " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,(Select CustomerID from v_CustomerDetails Where ChannelID=4)c   " +
                        "where c.CustomerID=sa.CustomerID and sa.invoiceid = sd.invoiceid and invoicedate   " +
                        "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "' " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)   " +
                        "Group by InvoiceDate,sa.CustomerID,ProductID  " +
                        "union all " +

                        "select InvoiceDate,sa.CustomerID,ProductID,0 as CRQty,sum(Quantity)as DRQty  " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,(Select CustomerID from v_CustomerDetails Where ChannelID=4)c   " +
                        "where c.CustomerID=sa.CustomerID and sa.invoiceid = sd.invoiceid and invoicedate   " +
                        "between '" + FirstDayLM + "' and '" + FirstDayCM + "' and invoicedate < '" + FirstDayCM + "' " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   " +
                        "Group by InvoiceDate,sa.CustomerID,ProductID  " +
                        ")as Sale,t_TDSalesPlanCalendar b Where Sale.InvoiceDate between FromDate and ToDate  " +
                        ")final Group by CustomerID,ProductID,YearID,MonthNo,WeekName  " +
                        ") x Group by CustomerID,ProductID,YearID,MonthNo  " +
                        ") a   " +
                        "INNER JOIN (Select ProductID,ASGID,PGID from v_productdetails where PGID iN (1,4,6) and ASGID<>78 )Prod  " +
                        "ON Prod.productID=a.ProductID  " +
                        ")final group by CustomerID,ASGID, PGID,YearID,MonthNo  " +
                        ")a " +
                        "Left Outer JOIN   " +
                        "(select CustomerID,PGID,ASGID,Year(PlanningMonth)as YearID, Month(PlanningMonth) as MonthNo,  " +
                        "Week1,Week2,Week3,Week4,Week5 from dbo.t_TDSalesPlan) TDPlan  " +
                        "ON TDPlan.CustomerID=a.CustomerID and TDPlan.PGID=a.PGID and TDPlan.ASGID=a.ASGID   " +
                        "and TDPlan.YearID=a.YearID and TDPlan.MonthNo=a.MonthNo   " +
                        "Where a.CustomerID=" + nCustomerID + "and a.PGID=" + nPGID + " and a.YearID=" + nLYear + " and a.MonthNo=" + nLMonth + " " +
                        ")Prevoius " +
                        "ON TDPlanEdit.CustomerID=Prevoius.CustomerID and TDPlanEdit.PGID=Prevoius.PGID and TDPlanEdit.ASGID=Prevoius.ASGID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDSalesPlan oTDSalesPlan = new TDSalesPlan();

                    oTDSalesPlan.ASGID = (int)reader["ASGID"];
                    oTDSalesPlan.ASGName = (string)reader["ASGName"];

                    oTDSalesPlan.SaleWeek1 = int.Parse(reader["sWeek1"].ToString());
                    oTDSalesPlan.SaleWeek2 = int.Parse(reader["sWeek2"].ToString());
                    oTDSalesPlan.SaleWeek3 = int.Parse(reader["sWeek3"].ToString());
                    oTDSalesPlan.SaleWeek4 = int.Parse(reader["sWeek4"].ToString());
                    oTDSalesPlan.SaleWeek5 = int.Parse(reader["sWeek5"].ToString());

                    oTDSalesPlan.Week1 = int.Parse(reader["PWeek1"].ToString());
                    oTDSalesPlan.Week2 = int.Parse(reader["PWeek2"].ToString());
                    oTDSalesPlan.Week3 = int.Parse(reader["PWeek3"].ToString());
                    oTDSalesPlan.Week4 = int.Parse(reader["PWeek4"].ToString());
                    oTDSalesPlan.Week5 = int.Parse(reader["PWeek5"].ToString());

                    oTDSalesPlan.eWeek1 = int.Parse(reader["eWeek1"].ToString());
                    oTDSalesPlan.eWeek2 = int.Parse(reader["eWeek2"].ToString());
                    oTDSalesPlan.eWeek3 = int.Parse(reader["eWeek3"].ToString());
                    oTDSalesPlan.eWeek4 = int.Parse(reader["eWeek4"].ToString());
                    oTDSalesPlan.eWeek5 = int.Parse(reader["eWeek5"].ToString());


                    InnerList.Add(oTDSalesPlan);

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

