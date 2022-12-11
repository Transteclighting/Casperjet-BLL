using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;
using System.Data.OleDb;



namespace TEL.SMS.BO.DA
{
    //public enum DateType
    //{
    //    DateTypeUser,
    //    DateTypeGroup
    //}

    public class DASMSMarketVisit
    {
        //public void GetAllUserUsage(DSSMSUserUsage oDSSMSuserUsage, DateTime dFromDt, DateTime dToDt, DateType nDateType)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    OleDbDataAdapter adapter = new OleDbDataAdapter();

        //    cmd.CommandText = "select submittedby as UserName, count(*) as Messages,sum(successcount) as Success,sum(failcount) as Fail from SMSMessage where requestdate between ? and ? group by submittedby";
        //    cmd.Parameters.AddWithValue("RequestDate", dFromDt);
        //    cmd.Parameters.AddWithValue("RequestDate", dToDt);
        //    adapter.SelectCommand = cmd;
        //    try
        //    {
        //        oDSSMSUserUsage.Clear();
        //        adapter.Fill(oDSSMSuserUsage, "SMSMessage");
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message.ToString());
        //    }
        //}

        //public void GetAllGroupUsage(DSSMSGroupMessage oDSSMSGroupMessage, DateTime dFromDt, DateTime dToDt, DateType nDateType)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    OleDbDataAdapter adapter = new OleDbDataAdapter();

        //    cmd.CommandText = "select usergroupname, count(*) as Messages,sum(successcount) as Success,sum(failcount) as Fail from SMSMessage where requestdate between ? and ? group by usergroupname";
        //    cmd.Parameters.AddWithValue("RequestDate", dFromDt);
        //    cmd.Parameters.AddWithValue("RequestDate", dToDt);

        //    adapter.SelectCommand = cmd;
        //    try
        //    {
        //        oDSSMSGroupMessage.Clear();
        //        adapter.Fill(oDSSMSGroupMessage, "SMSMessage");
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message.ToString());
        //    }
        //}

        public void GetAllByParameters(DSSMSMarketVisit oDSSMSMarketVisit, DateTime dFromDt, DateTime dToDt)
        {

            string sSQL = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            //sSQL = "SELECT SMSMarketVisit.VisitDate as VisitDateTime,SMSMarketVisit.VisitorName,SMSMarketVisit.VisitorMobileNo as MobileNo,SMSMarketVisit.CustomerID,Customer.CustomerName, SMSMarketVisit.VisitCount, SMSMarketVisit.GapCount, SMSMarketVisit.CompetitorCount FROM   SMSMarketVisit INNER JOIN Customer ON SMSMarketVisit.CustomerID = Customer.CustomerID"
            //    + " WHERE SMSMarketVisit.VisitDate>=? AND SMSMarketVisit.VisitDate<=? ";

            sSQL = " SELECT t_SMSMarketVisit.VisitDate as VisitDateTime,t_SMSMarketVisit.VisitorName,t_SMSMarketVisit.VisitorMobileNo as MobileNo,t_SMSMarketVisit.CustomerID,t_Customer.CustomerName, t_SMSMarketVisit.VisitCount, t_SMSMarketVisit.GapCount, t_SMSMarketVisit.CompetitorCount FROM  t_SMSMarketVisit INNER JOIN t_Customer ON t_SMSMarketVisit.CustomerID = t_Customer.CustomerCode "
                 + " WHERE t_SMSMarketVisit.VisitDate>=? AND t_SMSMarketVisit.VisitDate<=? ";



            cmd.CommandText = sSQL;

            //if (nDeptID != 0) { cmd.Parameters.AddWithValue("DepartmentID", nDeptID); }
            //if (nMemberID != 0) { cmd.Parameters.AddWithValue("MemberID", nMemberID); }

            cmd.Parameters.AddWithValue("RequestDate", dFromDt);
            cmd.Parameters.AddWithValue("RequestDate", dToDt.AddDays(1));
            //if (sType != "") { cmd.Parameters.AddWithValue("IssueType", sType); }
            //if (sStatus != "") { cmd.Parameters.AddWithValue("Status", sStatus); }
            adapter.SelectCommand = cmd;

            try
            {
                oDSSMSMarketVisit.Clear();
                adapter.Fill(oDSSMSMarketVisit, oDSSMSMarketVisit.MarketVisit.TableName);


            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message.ToString());
            }
        }
    }
}

