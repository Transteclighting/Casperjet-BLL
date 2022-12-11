// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak K. C.
// Date: April 25, 2011
// Time :  12:00 PM
// Description: Class for Department.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{

    public class Department
    {

        private int _nDepartmentID;
        private string _sDepartmentCode;
        private string _sDepartmentName;
        private bool _bIsActive;
        private string _sDivisionName;
        private int _nDivisionID;

        public int DivisionID
        {
            get { return _nDivisionID; }
            set { _nDivisionID = value; }

        }

        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }

        }

        public string DepartmentCode
        {
            get { return _sDepartmentCode; }
            set { _sDepartmentCode = value; }

        }

        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value; }
        }

        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }

        }

        private int _nActive;
        public int Active
        {
            get { return _nActive; }
            set { _nActive = value; }

        }

        public string DivisionName
        {
            get { return _sDivisionName; }
            set { _sDivisionName = value; }
        }


        public void Add()
        {
            int nMaxDepartmentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([DepartmentID]) FROM t_Department";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDepartmentID = 1;
                }
                else
                {
                    nMaxDepartmentID = Convert.ToInt32(maxID) + 1;
                }
                _nDepartmentID = nMaxDepartmentID;

                sSql = "INSERT INTO t_Department (DepartmentID,DepartmentCode,DepartmentName,IsActive,DivisionID) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("DepartmentCode", _sDepartmentCode);
                cmd.Parameters.AddWithValue("DepartmentName", _sDepartmentName);
                cmd.Parameters.AddWithValue("IsActive", _nActive);
                cmd.Parameters.AddWithValue("DivisionID", _nDivisionID);

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

                sSql = "UPDATE t_Department SET DepartmentCode=?, DepartmentName=?, IsActive=?, DivisionID = ?  WHERE DepartmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DepartmentCode", _sDepartmentCode);
                cmd.Parameters.AddWithValue("DepartmentName", _sDepartmentName);
                cmd.Parameters.AddWithValue("IsActive", _nActive);
                cmd.Parameters.AddWithValue("DivisionID", _nDivisionID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);

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
                sSql = "DELETE FROM t_Department WHERE [DepartmentID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
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
                cmd.CommandText = "SELECT * FROM t_Department where DepartmentID =?";
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDepartmentID = (int)reader["DepartmentID"];
                    _sDepartmentCode = (string)reader["DepartmentCode"];
                    _sDepartmentName = (string)reader["DepartmentName"];
                    _bIsActive=Convert.ToBoolean(reader["IsActive"]);
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


    public class Departments : CollectionBaseCustom
    {

        public Department this[int i]
        {
            get { return (Department)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Department oDepartment)
        {
            InnerList.Add(oDepartment);
        }

        public int GetIndex(int nDepartmentID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DepartmentID == nDepartmentID)
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
                    Department oDepartment = new Department();

                    oDepartment.DepartmentID = (int)oRow["DepartmentID"];
                    oDepartment.DepartmentCode = (string)oRow["DepartmentCode"];
                    oDepartment.DepartmentName = (string)oRow["DepartmentName"];
                    oDepartment.IsActive = Convert.ToBoolean(oRow["IsActive"]);
                    InnerList.Add(oDepartment);
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
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,DivisionName FROM t_Department a,t_HRDivision b where a.DivisionID=b.DivisionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Department oDepartment = new Department();

                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oDepartment.DivisionID = (int)reader["DivisionID"];
                    oDepartment.DivisionName = (string)reader["DivisionName"];                    
                    InnerList.Add(oDepartment);
                }
                reader.Close();

                oDepartment = new Department();
                oDepartment.DepartmentID = -1;
                oDepartment.DepartmentName = "ALL";
                InnerList.Add(oDepartment);
                InnerList.TrimToSize(); 
                cmd.ExecuteNonQuery();
                cmd.Dispose();                          
                

                

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshNew()
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,DivisionName FROM t_Department a,t_HRDivision b where a.DivisionID=b.DivisionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Department oDepartment = new Department();

                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oDepartment.DivisionID = (int)reader["DivisionID"];
                    oDepartment.DivisionName = (string)reader["DivisionName"];
                    InnerList.Add(oDepartment);
                }
                reader.Close();

                oDepartment = new Department();
                oDepartment.DepartmentID = -1;
                oDepartment.DepartmentName = "---Select Department---";
                InnerList.Add(oDepartment);
                InnerList.TrimToSize();
                cmd.ExecuteNonQuery();
                cmd.Dispose();




            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDepartmentByDivisionID(int nDivisionID)
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Department where DivisionID=" + nDivisionID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oDepartment);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetAllDepartment()
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Department order By DepartmentID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oDepartment);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDepartmentByOrder()
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,DivisionName FROM t_Department a,t_HRDivision b where a.DivisionID=b.DivisionID order by a.DepartmentName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Department oDepartment = new Department();

                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oDepartment.DivisionID = (int)reader["DivisionID"];
                    oDepartment.DivisionName = (string)reader["DivisionName"];
                    InnerList.Add(oDepartment);
                }
                reader.Close();

                oDepartment = new Department();
                oDepartment.DepartmentID = -1;
                oDepartment.DepartmentName = "ALL";
                InnerList.Add(oDepartment);
                InnerList.TrimToSize();
                cmd.ExecuteNonQuery();
                cmd.Dispose();




            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nUserID)
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.* from t_Department a,t_UserPermissionData b "+
                          " where b.DataID=a.DepartmentID and b.UserID= " + nUserID + " and DataType='Department' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Department oDepartment = new Department();

                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    //oDepartment.DivisionName = (string)reader["DivisionName"];
                    InnerList.Add(oDepartment);
                }
                reader.Close();

                

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDepartment()
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_Department";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    InnerList.Add(oDepartment);
                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDepartment()
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Department";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDepartment = new Department();

                    oDepartment.DepartmentID = (int)reader["DepartmentID"];                  
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.DivisionID = (int)reader["DivisionID"];
                    InnerList.Add(oDepartment);
                }
                reader.Close();

                oDepartment = new Department();
                oDepartment.DepartmentID = -1;
                oDepartment.DepartmentName = "<All>";
                InnerList.Add(oDepartment);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDepartmentAll()
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,DivisionName FROM t_Department a,t_HRDivision b " +
                          "where a.DivisionID=b.DivisionID order by DepartmentName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oDepartment.DivisionName = (string)reader["DivisionName"];
                    oDepartment.DivisionID = (int)reader["DivisionID"];
                    InnerList.Add(oDepartment);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDepartmentHO(string sDepartmentCode, string sDepartmentName,int nDivisionID)
        {
            Department oDepartment;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "SELECT a.*,DivisionName FROM t_Department a,t_HRDivision b " +
                              "where a.DivisionID=b.DivisionID";
            }
            if (nDivisionID != 0)
            {
                sSql = sSql + " and a.DivisionID=" + nDivisionID + "";
            }
            if (sDepartmentCode != "")
            {
                sSql = sSql + " and DepartmentCode like '%" + sDepartmentCode + "%'";
            }
            if (sDepartmentName != "")
            {
                sSql = sSql + " and DepartmentName like '%" + sDepartmentName + "%'";
            }
            sSql = sSql + " order by DepartmentName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oDepartment = new Department();
                    oDepartment.DepartmentID = (int)reader["DepartmentID"];
                    oDepartment.DepartmentCode = (string)reader["DepartmentCode"];
                    oDepartment.DepartmentName = (string)reader["DepartmentName"];
                    oDepartment.Active = (int)reader["IsActive"];
                    oDepartment.DivisionName = (string)reader["DivisionName"];
                    oDepartment.DivisionID = (int)reader["DivisionID"];
                    InnerList.Add(oDepartment);
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
