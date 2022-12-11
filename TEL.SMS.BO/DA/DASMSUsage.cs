using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;
using System.Data.OleDb;



namespace TEL.SMS.BO.DA
{
    public enum DateType
    {
        DateTypeUser,
        DateTypeGroup
    }
    
    public class DASMSUsage
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

        public void GetAllByParameters(DSSMSUserUsage oDSSMSUserUsage,DSSMSGroupMessage oDSSMSGroupMessage, DateTime dFromDt, DateTime dToDt,DateType nDateType)
        {

            string sSQL = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            if (nDateType == DateType.DateTypeUser)
            {
                sSQL = "select submittedby as UserName, count(*) as Messages,sum(successcount) as Success,sum(failcount) as Fail from t_SMSMessage "
                + " WHERE RequestDate>=? AND RequestDate<=? group by submittedby";
            }
            else if (nDateType == DateType.DateTypeGroup)
            {
                sSQL = "select usergroupname, count(*) as Messages,sum(successcount) as Success,sum(failcount) as Fail from t_SMSMessage "
                + " WHERE RequestDate>=? AND RequestDate<=? group by usergroupname";
            }


            
            cmd.CommandText = sSQL;

            //if (nDeptID != 0) { cmd.Parameters.AddWithValue("DepartmentID", nDeptID); }
            //if (nMemberID != 0) { cmd.Parameters.AddWithValue("MemberID", nMemberID); }

            cmd.Parameters.AddWithValue("RequestDate", dFromDt);
            cmd.Parameters.AddWithValue("RequestDate", dToDt);
            //if (sType != "") { cmd.Parameters.AddWithValue("IssueType", sType); }
            //if (sStatus != "") { cmd.Parameters.AddWithValue("Status", sStatus); }
            adapter.SelectCommand = cmd;

            try
            {
                oDSSMSUserUsage.Clear();
                adapter.Fill(oDSSMSUserUsage, oDSSMSUserUsage.SMSUserMesage.TableName);
                oDSSMSGroupMessage.Clear();
                adapter.Fill(oDSSMSGroupMessage, oDSSMSGroupMessage.SMSGroupMessage.TableName);

            }
            catch 
            {
                //AppLogger.LogFatal("Error in Action ID Setting" + e.Message.ToString());
                //Debug.WriteLine(e.Message.ToString());
            }
        }
    }
}
