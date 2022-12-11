// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 23, 2012
// Time :  04:30 PM
// Description: Class for Technical Supervisor.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;

namespace CJ.Class
{
    public class TechnicalSupervisor
    {

        private int _nSupervisorID;
        private int _nEmployeeID;
        private string _sEmployeeName;
        private int _nCategory;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private Object _sMobileNoSup;
        private Object _sRemarks;

        private string _sCategorys;
        private string _sIsActives;
        private string _sDesignation;
        private int _nInterServiceID;

        private User _oUser;
        private Employee _oEmployee;
        private CSDMapping _oCSDMapping;
        private InterService _oInterService;


        /// <summary>
        /// Get set property for SupervisorID
        /// </summary>
        public int SupervisorID
        {
            get { return _nSupervisorID; }
            set { _nSupervisorID = value; }
        }
        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        /// <summary>
        /// Get set property for Category
        /// </summary>
        public int Category
        {
            get { return _nCategory; }
            set { _nCategory = value; }
        }
        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
        /// Get set property for MobileNoSup
        /// </summary>
        public Object MobileNoSup
        {
            get { return _sMobileNoSup; }
            set { _sMobileNoSup = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public Object Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        /// <summary>
        /// Get set property for Categorys
        /// </summary>
        public string Categorys
        {
            get { return _sCategorys; }
            set { _sCategorys = value; }
        }
        /// <summary>
        /// Get set property for IsActives
        /// </summary>
        public string IsActives
        {
            get { return _sIsActives; }
            set { _sIsActives = value; }
        }
        /// <summary>
        /// Get set property for Designation
        /// </summary>
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value; }
        }
      
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
            }
        }
        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = _nEmployeeID;
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }
        public InterService InterService
        {
            get
            {
                if (_oInterService == null)
                {
                    _oInterService = new InterService();
                    _oInterService.InterServiceID = _nInterServiceID;
                    _oInterService.RefreshByID();
                }

                return _oInterService;
            }
        }
        public CSDMapping CSDMapping
        {
            get
            {
                if (_oCSDMapping == null)
                {
                    _oCSDMapping = new CSDMapping();
                    //_oCSDMapping.ID = _nEmployeeID;
                    //_oEmployee.Refresh();
                }

                return _oCSDMapping;
            }
        }

        public void Add()
        {
            int nMaxSupervisorID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SupervisorID]) FROM t_CSDTechnicalSupervisor";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSupervisorID = 1;
                }
                else
                {
                    nMaxSupervisorID = Convert.ToInt32(maxID) + 1;
                }
                _nSupervisorID = nMaxSupervisorID;


                sSql = "INSERT INTO t_CSDTechnicalSupervisor(SupervisorID,EmployeeID,Category,IsActive,CreateUserID,CreateDate,MobileNo,Remarks "
                    + " ) VALUES(?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SupervisorID", _nSupervisorID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNoSup);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                
                
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

                cmd.CommandText = "UPDATE t_CSDTechnicalSupervisor SET EmployeeID=?,Category=?,IsActive=?,MobileNo=?,Remarks=? Where SupervisorID=?";

                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNoSup);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);


                cmd.Parameters.AddWithValue("SupervisorID", _nSupervisorID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckEmployee()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDTechnicalSupervisor where EmployeeID=?";
            cmd.Parameters.AddWithValue("EmployeeID",_nEmployeeID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nEmployeeID=(int)reader["EmployeeID"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool Refresh()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDTechnicalSupervisor ts LEFT JOIN t_Employee t ON ts.EmployeeID = t.EmployeeID where SupervisorID =?";
            cmd.Parameters.AddWithValue("SupervisorID", _nSupervisorID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _sEmployeeName = (string)reader["EmployeeName"];
                    if (reader["MobileNo"] != DBNull.Value)
                    {
                        _sMobileNoSup = (object)reader["MobileNo"];
                    }
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
    }

    public class TechnicalSupervisors : CollectionBase
    {
        public TechnicalSupervisor this[int i]
        {
            get { return (TechnicalSupervisor)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndex(int nTechnicalSupervisorID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SupervisorID == nTechnicalSupervisorID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(TechnicalSupervisor oTechnicalSupervisor)
        {
            InnerList.Add(oTechnicalSupervisor);
        }
        public void Refresh(String txtSupervisorID, String txtEmplCode, String txtEmplName, int nIsActive, int nCategory) 
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SupervisorID,TS.EmployeeID EmployeeID, E.EmployeeCode EmployeeCode, "+
                            "E.EmployeeName EmployeeName,DesignationName,TS.MobileNo,Category, " +
                            "CategoryName=CASE " +
                            "When Category=0 Then 'Electronics' " +
                            "When Category=1 Then 'Home Appliance' " +
                            "else 'Residential AC' End, TS.IsActive, " +
                            "IsActives=CASE " +
                            "When TS.IsActive=1 Then 'True' " +
                            "else 'False' end, " +
                            "CreateUserID,U.UserName,CreateDate,Remarks From t_CSDTechnicalSupervisor TS " +
                            "INNER JOIN t_user U " +
                            "ON u.UserID=TS.CreateUserID " +
                            "INNER JOIN t_Employee E " +
                            "ON E.EmployeeID=TS.EmployeeID "+
                            "INNER JOIN  t_Designation D "+
			                "ON D.DesignationID=E.DesignationID "+
                            "Where SupervisorID <>-1 ";

            if (txtSupervisorID != "")
            {
                sSql = sSql + " AND SupervisorID ='" + txtSupervisorID + "'";
            }
            if (txtEmplCode != "")
            {
                txtEmplCode = "%" + txtEmplCode + "%";
                sSql = sSql + " AND E.EmployeeCode LIKE '" + txtEmplCode + "'";
            }

            if (nIsActive >= 0)
            {
                sSql = sSql + " and TS.IsActive=?";
                cmd.Parameters.AddWithValue("TS.IsActive", nIsActive);
            }
            if (nCategory >= 0)
            {
                sSql = sSql + " and Category=?";
                cmd.Parameters.AddWithValue("Category", nCategory);
            }
            
            if (txtEmplName != "")
            {
                txtEmplName = "%" + txtEmplName + "%";
                sSql = sSql + " AND E.EmployeeName LIKE '" + txtEmplName + "'";
            }

            sSql = sSql + " order by SupervisorID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TechnicalSupervisor oTechnicalSupervisor = new TechnicalSupervisor();

                    oTechnicalSupervisor.SupervisorID = (int)reader["SupervisorID"];
                    oTechnicalSupervisor.EmployeeID = (int)reader["EmployeeID"];
                    oTechnicalSupervisor.Employee.EmployeeCode = (string)reader["EmployeeCode"];
                    oTechnicalSupervisor.Employee.EmployeeName = (string)reader["EmployeeName"];
                    oTechnicalSupervisor.Category = (int)reader["Category"];
                    oTechnicalSupervisor.Categorys = (string)reader["CategoryName"];
                    oTechnicalSupervisor.IsActive = (int)reader["IsActive"];
                    oTechnicalSupervisor.IsActives = (string)reader["IsActives"];
                    oTechnicalSupervisor.Employee.Designation.DesignationName = (string)reader["DesignationName"];
                    oTechnicalSupervisor.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oTechnicalSupervisor.User.Username = (string)reader["UserName"];
                    oTechnicalSupervisor.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTechnicalSupervisor.MobileNoSup = (Object)reader["MobileNo"].ToString();
                    oTechnicalSupervisor.Remarks = (Object)reader["Remarks"].ToString();
                    
                    //oPaidJobForInterService.RefreshUser();
                    InnerList.Add(oTechnicalSupervisor);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshAll()
        {            

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * FROM  t_CSDTechnicalSupervisor TS INNER JOIN t_Employee E ON TS.EmployeeID = E.EmployeeID "
                          +"ORDER BY E.EmployeeName";
                         
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TechnicalSupervisor oTechnicalSupervisor = new TechnicalSupervisor();

                    oTechnicalSupervisor.SupervisorID = (int)reader["SupervisorID"];
                    oTechnicalSupervisor.EmployeeID = (int)reader["EmployeeID"];
                    oTechnicalSupervisor.Employee.EmployeeCode = (string)reader["EmployeeCode"];
                    oTechnicalSupervisor.Employee.EmployeeName = (string)reader["EmployeeName"];
                    oTechnicalSupervisor.Category = (int)reader["Category"];
                    //oTechnicalSupervisor.Categorys = (string)reader["CategoryName"];
                    oTechnicalSupervisor.IsActive = (int)reader["IsActive"];
                    //oTechnicalSupervisor.IsActives = (string)reader["IsActives"];
                    //oTechnicalSupervisor.Employee.Designation.DesignationName = (string)reader["DesignationName"];
                    oTechnicalSupervisor.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    //oTechnicalSupervisor.User.Username = (string)reader["UserName"];
                    oTechnicalSupervisor.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTechnicalSupervisor.MobileNoSup = (Object)reader["MobileNo"].ToString();
                    oTechnicalSupervisor.Remarks = (Object)reader["Remarks"].ToString();
                                        
                    InnerList.Add(oTechnicalSupervisor);
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


