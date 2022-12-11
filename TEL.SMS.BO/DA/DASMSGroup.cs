using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using System.Data.OleDb;
using System.Diagnostics;

namespace TEL.SMS.BO.DA
{
    public class DASMSGroup
    {
        public void Insert(DSSMSGroup oDSSMSGroup)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSSMSGroup.SMSGroupRow oSMSGroupRow in oDSSMSGroup.SMSGroup)
            {
                cmd.CommandText = "INSERT INTO t_SMSGroup(SMSGroupID, SMSGroupName) VALUES(?,?)";
                oSMSGroupRow.SMSGroupID = getNewID();
                cmd.Parameters.AddWithValue("SMSGroupID", oSMSGroupRow.SMSGroupID);
                cmd.Parameters.AddWithValue("SMSGroupName", oSMSGroupRow.SMSGroupName);
                cmd.ExecuteNonQuery();
            }
        }

        private long getNewID()
        {
            long nNextID;
            Utility oUtil = new Utility();
            nNextID = oUtil.GenerateID("t_SMSGroup", "SMSGroupID");
            return nNextID;
        }

        public void Update(DSSMSGroup oDSSMSGroup)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSSMSGroup.SMSGroupRow oSMSGroupRow in oDSSMSGroup.SMSGroup)
            {
                cmd.CommandText = "UPDATE t_SMSGroup SET SMSGroupName=? WHERE SMSGroupID=?";
                cmd.Parameters.AddWithValue("SMSGroupName", oSMSGroupRow.SMSGroupName);
                cmd.Parameters.AddWithValue("SMSGroupID", oSMSGroupRow.SMSGroupID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(DSSMSGroup oDSSMSGroup)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSSMSGroup.SMSGroupRow oSMSGroupRow in oDSSMSGroup.SMSGroup)
            {
                cmd.CommandText = "DELETE FROM t_SMSGroup WHERE SMSGroupID=?";
                cmd.Parameters.AddWithValue("SMSGroupID", oSMSGroupRow.SMSGroupID);
                cmd.ExecuteNonQuery();
            }
        }

        public void GetSMSGroup(DSSMSGroup oDSSMSGroup)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_SMSGroup WHERE SMSGroupID=?";
            cmd.Parameters.AddWithValue("SMSGroupID", oDSSMSGroup.SMSGroup[0].SMSGroupID);

            adapter.SelectCommand = cmd;
            try
            {
                oDSSMSGroup.Clear();
                adapter.Fill(oDSSMSGroup, "SMSGroup");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetAllSMSGroups(DSSMSGroup oDSSMSGroup)
        {
            string sUserGroup=Utility.GetUserGroupName();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            
            if(sUserGroup=="All")
            {
                cmd.CommandText = "SELECT * FROM t_SMSGroup";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM t_SMSGroup,t_UserGroupSMSGroup "
                    + " WHERE t_SMSGroup.SMSGroupID=t_UserGroupSMSGroup.SMSGroupID "
                    + " AND t_UserGroupSMSGroup.UserGroupName=?";

            }
            adapter.SelectCommand = cmd;
            try
            {
                if (sUserGroup != "All") { cmd.Parameters.AddWithValue("UserGroupName", sUserGroup); }
                oDSSMSGroup.Clear();
                adapter.Fill(oDSSMSGroup, "SMSGroup");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void AddPerson(DSSMSGroup oDSSMSGroup)
        {
            OleDbCommand cmd = new OleDbCommand();

            foreach (DSSMSGroup.SMSGroupPersonRow oSMSGroupPersonRow in oDSSMSGroup.SMSGroupPerson)
            {
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_SMSGroupPerson(SMSGroupID, MobileID) VALUES(?,?)";
                cmd.Parameters.AddWithValue("SMSGroupID", oSMSGroupPersonRow.SMSGroupID);
                cmd.Parameters.AddWithValue("PersonID", oSMSGroupPersonRow.PersonID);
                cmd.ExecuteNonQuery();
            }
        }

        public void RemovePerson(DSSMSGroup oDSSMSGroup)
        {
            OleDbCommand cmd = new OleDbCommand();

            foreach (DSSMSGroup.SMSGroupPersonRow oSMSGroupPersonRow in oDSSMSGroup.SMSGroupPerson)
            {
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "DELETE FROM t_SMSGroupPerson WHERE SMSGroupID=? AND MobileID=?";
                cmd.Parameters.AddWithValue("SMSGroupID", oSMSGroupPersonRow.SMSGroupID);
                cmd.Parameters.AddWithValue("PersonID", oSMSGroupPersonRow.PersonID);
                cmd.ExecuteNonQuery();
            }
        }

        public void GetPersonsSelected(DSPerson oDSPerson, long nSMSGroupID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT t_MobilePhone.*"
                + " FROM t_MobilePhone,t_SMSGroupPerson"
                + " WHERE t_MobilePhone.MobileID=t_SMSGroupPerson.MobileID"
                + " AND t_SMSGroupPerson.SMSGroupID=?";
            adapter.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("SMSGroupID", nSMSGroupID);
            try
            {
                oDSPerson.Clear();
                adapter.Fill(oDSPerson, "Person");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetPersonsAvailable(DSPerson oDSPerson, long nSMSGroupID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            //cmd.CommandText = "SELECT * FROM t_MobilePhone"
            //    + " WHERE PersonID NOT IN"
            //    + " (SELECT PersonID FROM SMSGroupPerson"
            //    + " WHERE SMSGroupID=?)";

            cmd.CommandText = " SELECT * FROM t_MobilePhone "
                + " WHERE MobileID NOT IN "
                + " (SELECT MobileID FROM t_SMSGroupPerson "
                + " WHERE SMSGroupID=?)";

            adapter.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("SMSGroupID", nSMSGroupID);
            try
            {
                oDSPerson.Clear();
                adapter.Fill(oDSPerson, "Person");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

    }
}
