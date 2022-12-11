// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak K. Chakraborty.
// Date: July 04, 2013
// Time :  12:00 PM
// Description: Class for Allowance and Deduction
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class AllowanceDeduction
    {
        private int _nID;
        private string _sCode;
        private string _sName;
        private int _nType;
        private string _sTypeName;
        private int _nGradeID;
        private string _sGradeName;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private int _nIsActive;

        private int _nMapID;
        private int _nCompanyID;
        private string _sCompanyName;
        private double _Amount;
        private int _nParentType;

        public int ParentType
        {
            get { return _nParentType; }
            set { _nParentType = value; }

        }

        public int MapID
        {
            get { return _nMapID; }
            set { _nMapID = value; }
        }

        
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }


        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }

        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value; }

        }


        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }

        }
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }

        public int Type
        {
            get { return _nType; }
            set { _nType = value; }

        }

        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }

        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }

        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }

        }

        public int GradeID
        {
            get { return _nGradeID; }
            set { _nGradeID = value; }

        }

        public string GradeName
        {
            get { return _sGradeName; }
            set { _sGradeName = value; }

        }
        public string TypeName
        {
            get { return _sTypeName; }
            set { _sTypeName = value; }

        }

        public void Add()
        {
            int nMaxID = 0;
            int nLotID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRAllowanceDeduction";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;

                string sCode = "";
                string sShortCode = "";
                DateTime dToday = DateTime.Today;

                if (_nType == (int)Dictionary.AllowanceDeductionType.Add)
                {
                    sShortCode = "A";
                }
                else
                {
                    sShortCode = "D";
                }

                sCode = sShortCode + _nID.ToString("0000");
                _sCode = sCode;

                sSql = "INSERT INTO t_HRAllowanceDeduction (ID, Code, Name, Type, CreateUserID, CreateDate, UpdateUserID, UpdateDate, IsActive, ParentType) VALUES(?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                if (_nParentType != null)
                {
                    cmd.Parameters.AddWithValue("ParentType", _nParentType);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentType", 0);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddADMapping()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([MapID]) FROM t_HRAllowanceDeductionMapping";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nMapID = nMaxID;

                sSql = "INSERT INTO t_HRAllowanceDeductionMapping (MapID, ADID, GradeID, CompanyID, Amount, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MapID", _nMapID);
                cmd.Parameters.AddWithValue("ADID", _nID);
                cmd.Parameters.AddWithValue("GradeID", _nGradeID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditADMapping()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_HRAllowanceDeductionMapping  SET ADID = ?, GradeID = ?, CompanyID = ?, Amount = ?, UpdateUserID = ?, UpdateDate = ? WHERE MapID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ADID", _nID);
                cmd.Parameters.AddWithValue("GradeID", _nGradeID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("MapID", _nMapID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddGrade()
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {              

                sSql = "INSERT INTO t_HRAllowanceDeduction Grades VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);              
                cmd.Parameters.AddWithValue("GradeID", _nGradeID);               

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

                sSql = "UPDATE t_HRAllowanceDeduction  SET Code = ?, Name = ?, Type = ?, UpdateUserID = ?, UpdateDate = ?, IsActive = ?, ParentType = ?  WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                if (_nParentType != null)
                {
                    cmd.Parameters.AddWithValue("ParentType", _nParentType);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentType", 0);
                }
                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditAllGrade()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_HRAllowanceDeduction grades SET ID=?, GradeID=?" 
                    + " WHERE ID=? and GradeID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("GradeID", _nGradeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_HRAllowanceDeduction  WHERE [ID]=?";
               

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void DeleteADGrade()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {               
                sSql = "DELETE FROM t_HRAllowanceDeduction Grades WHERE [ID]=? and [GradeID]=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("GradeID", _nGradeID);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRAllowanceDeduction  where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _nType = Convert.ToInt32(reader["Type"]);
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetCodeForEdit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select right(Code,4) as Code From dbo.t_HRAllowanceDeduction where Code = ?";

                cmd.Parameters.AddWithValue("Code", _sCode);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sCode = (string)reader["Code"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class AllowanceDeductions : CollectionBaseCustom
    {

        public AllowanceDeduction this[int i]
        {
            get { return (AllowanceDeduction)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(AllowanceDeduction oAllowanceDeduction)
        {
            InnerList.Add(oAllowanceDeduction);
        }

        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void FromDataSet(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    AllowanceDeduction oAllowanceDeduction = new AllowanceDeduction();

                    oAllowanceDeduction.ID = (int)oRow["ID"];
                    oAllowanceDeduction.Code = (string)oRow["Code"];
                    oAllowanceDeduction.Name = (string)oRow["Name"];
                    oAllowanceDeduction.Type = Convert.ToInt32(oRow["Type"]);
                    InnerList.Add(oAllowanceDeduction);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRAllowanceDeduction ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AllowanceDeduction oAllowanceDeduction = new AllowanceDeduction();

                    oAllowanceDeduction.ID = (int)reader["ID"];
                    oAllowanceDeduction.Code = (string)reader["Code"];
                    oAllowanceDeduction.Name = (string)reader["Name"];
                    oAllowanceDeduction.Type = Convert.ToInt32(reader["Type"]);

                    if (oAllowanceDeduction.Type == 1)
                    {
                        oAllowanceDeduction.TypeName = "Allowance";
                    }
                    else oAllowanceDeduction.TypeName = "Deduction";

                    InnerList.Add(oAllowanceDeduction);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshGrade()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.ID,a.Code, a.Name,c.JobGradeID,c.JobGradeName  from t_HRAllowanceDeduction  a,t_HRAllowanceDeduction grades b,  t_JobGrade c   where b.ID=a.ID and b.GradeID=c.JobGradeID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;        
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AllowanceDeduction oAllowanceDeduction = new AllowanceDeduction();

                    oAllowanceDeduction.ID = (int)reader["ID"];
                    oAllowanceDeduction.Code = (string)reader["Code"];
                    oAllowanceDeduction.Name = (string)reader["Name"];
                    oAllowanceDeduction.GradeID = (int)reader["JobGradeID"];
                    oAllowanceDeduction.GradeName = (string)reader["JobGradeName"];
                    InnerList.Add(oAllowanceDeduction);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllowDed()
        {
            AllowanceDeduction oAllowanceDeduction;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRAllowanceDeduction ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oAllowanceDeduction = new AllowanceDeduction();

                    oAllowanceDeduction.ID = (int)reader["ID"];
                    oAllowanceDeduction.Code = (string)reader["Code"];
                    oAllowanceDeduction.Name = (string)reader["Name"];
                    oAllowanceDeduction.Type = Convert.ToInt32(reader["Type"]);
                    InnerList.Add(oAllowanceDeduction);
                }
                reader.Close();

                oAllowanceDeduction = new AllowanceDeduction();
                oAllowanceDeduction.ID = -1;
                oAllowanceDeduction.Name = "<Select Name>";
                InnerList.Add(oAllowanceDeduction);
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshData(string sCode, string sName, int nIsActive, int nType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            
            {
                sSql = "Select * From t_HRAllowanceDeduction where 1=1";
            }
            if (sCode != "")
            {
                sSql = sSql + " AND Code like '%" + sCode + "%'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND Name like '%" + sName + "%'";
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            if (nType != -1)
            {
                sSql = sSql + " AND Type=" + nType + "";
            }

            sSql = sSql + " Order by ID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AllowanceDeduction oAllowanceDeduction = new AllowanceDeduction();
                    oAllowanceDeduction.ID = (int)reader["ID"];
                    oAllowanceDeduction.Code = (string)reader["Code"];
                    oAllowanceDeduction.Name = (string)reader["Name"];
                    oAllowanceDeduction.IsActive = Convert.ToInt32(reader["IsActive"]);
                    oAllowanceDeduction.Type = Convert.ToInt32(reader["Type"]);
                    oAllowanceDeduction.CreateUserID = Convert.ToInt32(reader["CreateUserID"]);
                    oAllowanceDeduction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oAllowanceDeduction.ParentType = (int)reader["ParentType"];

                    InnerList.Add(oAllowanceDeduction);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshMappingData(int nType, int nGradeID, int nCompany)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            {
                sSql = " Select * From (Select MapID,ADID,d.Type,d.Name,a.CreateDate,GradeID,  " +
                       " '['+JobGradeCode+']'+' '++ JobGradeName as JobGradeName,a.CompanyID,CompanyName,Amount  "+
                       " From t_HRAllowanceDeductionMapping a,t_JobGrade b,t_Company c,t_HRAllowanceDeduction d  "+
                       " where a.ADID=d.ID and a.GradeID=b.JobGradeID and a.CompanyID=c.CompanyID) x where 1=1";
            }

            if (nType != -1)
            {
                sSql = sSql + " AND Type =" + nType + "";
            }
            if (nGradeID != -1)
            {
                sSql = sSql + " AND GradeID =" + nGradeID + "";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND CompanyID =" + nCompany + "";
            }

            sSql = sSql + " Order by MapID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AllowanceDeduction oAllowanceDeduction = new AllowanceDeduction();
                    oAllowanceDeduction.MapID = (int)reader["MapID"];
                    oAllowanceDeduction.ID = (int)reader["ADID"];
                    oAllowanceDeduction.Type = Convert.ToInt32(reader["Type"]);
                    oAllowanceDeduction.Name = (string)reader["Name"];
                    oAllowanceDeduction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oAllowanceDeduction.GradeID = Convert.ToInt32(reader["GradeID"]);
                    oAllowanceDeduction.GradeName = (string)reader["JobGradeName"];
                    oAllowanceDeduction.CompanyID = Convert.ToInt32(reader["CompanyID"]);
                    oAllowanceDeduction.CompanyName = (string)reader["CompanyName"];
                    oAllowanceDeduction.Amount = Convert.ToDouble(reader["Amount"]);
                    InnerList.Add(oAllowanceDeduction);
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