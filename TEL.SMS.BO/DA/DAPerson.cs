using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using System.Data.OleDb;
using System.Diagnostics;

namespace TEL.SMS.BO.DA
{
    public class DAPerson
    {
        public void Insert(DSPerson oDSPerson)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
             
            foreach (DSPerson.PersonRow oPersonRow in oDSPerson.Person)
            {
                cmd.CommandText = "INSERT INTO t_MobilePhone(MobileID, PersonCode, PersonName, MobileNo,IsActive)"
                    + " VALUES(?,?,?,?,?)";
                oPersonRow.MobileID = getNewID();
                cmd.Parameters.AddWithValue("MobileID", oPersonRow.MobileID);
                cmd.Parameters.AddWithValue("PersonCode", oPersonRow.PersonCode);
                cmd.Parameters.AddWithValue("PersonName", oPersonRow.PersonName);
                cmd.Parameters.AddWithValue("MobileNo", oPersonRow.MobileNo);                
                cmd.Parameters.AddWithValue("IsActive", (oPersonRow.IsIsActiveNull() == false) ? oPersonRow.IsActive : Convert.DBNull);
                cmd.ExecuteNonQuery();
            }
        }

        private long getNewID()
        {
            long nNextID;
            Utility oUtil = new Utility();
            nNextID = oUtil.GenerateID("t_MobilePhone", "MobileID");
            return nNextID;
        }

        public void Update(DSPerson oDSPerson)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSPerson.PersonRow oPersonRow in oDSPerson.Person)
            {
                cmd.CommandText = "UPDATE t_MobilePhone SET PersonCode=?, PersonName=?, MobileNo=?, IsActive=? "
                    + " WHERE MobileID=?";
                cmd.Parameters.AddWithValue("PersonCode", oPersonRow.PersonCode);
                cmd.Parameters.AddWithValue("PersonName", oPersonRow.PersonName);
                cmd.Parameters.AddWithValue("MobileNo", oPersonRow.MobileNo);
                cmd.Parameters.AddWithValue("IsActive", (oPersonRow.IsIsActiveNull()==false ) ? oPersonRow.IsActive : Convert.DBNull);
                cmd.Parameters.AddWithValue("MobileID", oPersonRow.MobileID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(DSPerson oDSPerson)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSPerson.PersonRow oPersonRow in oDSPerson.Person)
            {
                cmd.CommandText = "DELETE FROM t_MobilePhone WHERE MobileID=?";
                cmd.Parameters.AddWithValue("MobileID", oPersonRow.MobileID);
                cmd.ExecuteNonQuery();
            }
        }

        public void GetPerson(DSPerson oDSPerson)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_MobilePhone WHERE MobileID=?";
            cmd.Parameters.AddWithValue("PersonID", oDSPerson.Person[0].MobileID);

            adapter.SelectCommand = cmd;
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

        public void GetAllPersons(DSPerson oDSPerson)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "select q1.*,q2.EmployeeID,q2.EmployeeCode,q2.EmployeeName from " +
                              " (select * from t_MobilePhone) as q1 " +
                              "     left outer join " +
                              " (select * from t_Employee) as q2 on q1.MobileID=q2.MobileID ";
            adapter.SelectCommand = cmd;
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

        public void DoesMobileNoExists(DSPerson oDSPerson)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            
            cmd.CommandText = "Select * from t_MobilePhone where MobileNo = ?";
            cmd.Parameters.AddWithValue("MobileNo", oDSPerson.Person[0].MobileNo);

            adapter.SelectCommand = cmd;
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
