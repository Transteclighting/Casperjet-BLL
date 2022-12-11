// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 08, 2012
// Time :  03:11 PM
// Description: Class for Technician.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class
{
    public class Technician
    {

        private int _nTechnicianID;
        private string _sCode;
        private string _sEmployeeCode;
        private string _sName;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private double _sMaxPay;
        private double _sMinPay;
        private int _nWorkshopTypeID;
        private int _nWorkshopLocationID;
        private int _nIsActive;
        private int _nIsVariable;
        private int _nThirdPartyID;
        private string _sThirdPartyName;
        private string _sThirdPartyCode;
        private int _nTechnicianTypeID;
        private string _sTechnicianTypeName;

        private int _nSupervisorID;
        private string _sSupervisorName;
        private string _sMobileNo;
        private string _sMobileNo1;




        private User _oUser;


        /// <summary>
        /// Get set property for SupervisorName
        /// </summary>
        public string SupervisorName
        {
            get { return _sSupervisorName; }
            set { _sSupervisorName = value; }
        }

        /// <summary>
        /// Get set property for SupervisorID
        /// </summary>
        public int SupervisorID
        {
            get { return _nSupervisorID; }
            set { _nSupervisorID = value; }
        }

        /// <summary>
        /// Get set property for MobileNo
        /// </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }

        /// <summary>
        /// Get set property for _sMobileNo1
        /// </summary>
        public string MobileNo1
        {
            get { return _sMobileNo1; }
            set { _sMobileNo1 = value; }
        }

        /// <summary>
        /// Get set property for ThirdPartyCode
        /// </summary>
        public string ThirdPartyCode
        {
            get { return _sThirdPartyCode; }
            set { _sThirdPartyCode = value; }
        }


        /// <summary>
        /// Get set property for TechnicianID
        /// </summary>
        public int TechnicianID
        {
            get { return _nTechnicianID; }
            set { _nTechnicianID = value; }
        }
        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EmployeeCode
        /// </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }

        /// <summary>
        /// Get set property for TechnicianTypeID
        /// </summary>
        public int TechnicianTypeID
        {
            get { return _nTechnicianTypeID; }
            set { _nTechnicianTypeID = value; }
        }

        /// <summary>
        /// Get set property for TechnicianTypeName
        /// </summary>
        public string TechnicianTypeName
        {
            get { return _sTechnicianTypeName; }
            set { _sTechnicianTypeName = value; }
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
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        /// <summary>
        /// Get set property for MaxPay
        /// </summary>
        public double MaxPay
        {
            get { return _sMaxPay; }
            set { _sMaxPay = value; }
        }
        /// <summary>
        /// Get set property for MinPay
        /// </summary>
        public double MinPay
        {
            get { return _sMinPay; }
            set { _sMinPay = value; }
        }
        /// <summary>
        /// Get set property for WorkshopTypeID
        /// </summary>
        public int WorkshopTypeID
        {
            get { return _nWorkshopTypeID; }
            set { _nWorkshopTypeID = value; }
        }
        /// <summary>
        /// Get set property for WorkshopLocationID
        /// </summary>
        public int WorkshopLocationID
        {
            get { return _nWorkshopLocationID; }
            set { _nWorkshopLocationID = value; }
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
        /// Get set property for IsVariable
        /// </summary>
        public int IsVariable
        {
            get { return _nIsVariable; }
            set { _nIsVariable = value; }
        }
        /// <summary>
        /// Get set property for ThirdPartyID
        /// </summary>
        public int ThirdPartyID
        {
            get { return _nThirdPartyID; }
            set { _nThirdPartyID = value; }
        }

        /// <summary>
        /// Get set property for ThirdPartyName
        /// </summary>
        public string ThirdPartyName
        {
            get { return _sThirdPartyName; }
            set { _sThirdPartyName = value; }
        }


        private Workshop _oWorkshop;
        public Workshop Workshop
        {
            get
            {
                if (_oWorkshop == null)
                {
                    _oWorkshop = new Workshop();
                    _oWorkshop.WorkshopTypeID = _nWorkshopTypeID;
                    _oWorkshop.RefreshByID();
                }

                return _oWorkshop;
            }
        }
        private WorkshopLocation _oWorkshopLocation;
        public WorkshopLocation WorkshopLocation
        {
            get
            {
                if (_oWorkshopLocation == null)
                {
                    _oWorkshopLocation = new WorkshopLocation();
                    _oWorkshopLocation.WorkshopLocationID = _nWorkshopLocationID;
                    _oWorkshopLocation.RefreshByWSLocationID();
                }

                return _oWorkshopLocation;
            }
        }

        private int _nWalkInJob;
        public int WalkInJob
        {
            get { return _nWalkInJob; }
            set { _nWalkInJob = value; }
        }
        private int _nHomeCallJob;
        public int HomeCallJob
        {
            get { return _nHomeCallJob; }
            set { _nHomeCallJob = value; }
        }
        private int _nInstallJob;
        public int InstallJob
        {
            get { return _nInstallJob; }
            set { _nInstallJob = value; }
        }
        private int _nTotalJob;
        public int TotalJob
        {
            get { return _nTotalJob; }
            set { _nTotalJob = value; }
        }

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    User.UserId = _nCreateUserID;
                    User.RefreshByUserID();
                }
                return _oUser;
            }
        }
        public void Add()
        {
            int nMaxTechnicianID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TechnicianID]) FROM t_CSDTechnician";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTechnicianID = 1;
                }
                else
                {
                    nMaxTechnicianID = Convert.ToInt32(maxID) + 1;
                }
                _nTechnicianID = nMaxTechnicianID;


                sSql = "INSERT INTO t_CSDTechnician(TechnicianID,Code,EmployeeCode,Name,Type,IsVariable,ThirdPartyID,CreateUserID,CreateDate, "
                    + "MaxPay, MinPay, WorkshopTypeID,WorkshopLocationID, IsActive,SupervisorID,MobileNo,MobileNo1 "
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("Name", _sName);

                cmd.Parameters.AddWithValue("Type", _nTechnicianTypeID);
                cmd.Parameters.AddWithValue("IsVariable", _nIsVariable);
                cmd.Parameters.AddWithValue("ThirdPartyID", _nThirdPartyID);

                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("MaxPay", _sMaxPay);
                cmd.Parameters.AddWithValue("MinPay", _sMinPay);
                cmd.Parameters.AddWithValue("WorkshopTypeID", _nWorkshopTypeID);
                cmd.Parameters.AddWithValue("WorkshopLocationID", _nWorkshopLocationID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("SupervisorID", _nSupervisorID);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("MobileNo1", _sMobileNo1);



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

                cmd.CommandText = "UPDATE t_CSDTechnician SET Code=?,EmployeeCode=?, Name=?,Type=?,IsVariable=?,ThirdPartyID=?, UpdateUserID=?,UpdateDate=?, "
                    + "MaxPay=?, MinPay=?, WorkshopTypeID=?,WorkshopLocationID=?, IsActive=?,SupervisorID=?,MobileNo=?,MobileNo1=? Where TechnicianID=? ";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("Name", _sName);

                cmd.Parameters.AddWithValue("Type", _nTechnicianTypeID);
                cmd.Parameters.AddWithValue("IsVariable", _nIsVariable);
                cmd.Parameters.AddWithValue("ThirdPartyID", _nThirdPartyID);

                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("MaxPay", _sMaxPay);
                cmd.Parameters.AddWithValue("MinPay", _sMinPay);
                cmd.Parameters.AddWithValue("WorkshopTypeID", _nWorkshopTypeID);
                cmd.Parameters.AddWithValue("WorkshopLocationID", _nWorkshopLocationID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("SupervisorID", _nSupervisorID);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("MobileNo1", _sMobileNo1);


                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckByTechnicianCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDTechnician where Code=?";
            cmd.Parameters.AddWithValue("Code", _sCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nTechnicianID = (int)reader["TechnicianID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];

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

        public int GetTechnicianIDByCode(string nTechnicialCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TechnicianID from t_CSDTechnician where Code= '" + nTechnicialCode + "' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nTechnicianID = (int)reader["TechnicianID"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _nTechnicianID;
        }
        public void RefreshByTechnicianID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select a.*,ISNULL(b.Code,'') TPCode,ISNULL(b.Name,'') TPName from t_CSDTechnician a LEFT JOIN t_CSDInterService b ON a.ThirdPartyID = b.InterserviceID where TechnicianID=?";

                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTechnicianID = (int)reader["TechnicianID"];
                    _nTechnicianTypeID = (int)reader["Type"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    if (reader["MobileNo"] != DBNull.Value)
                    {
                        _sMobileNo = (string)reader["MobileNo"];
                    }
                    if (reader["MobileNo1"] != DBNull.Value)
                    {
                        _sMobileNo1 = (string)reader["MobileNo1"];
                    }
                    if (reader["ThirdPartyID"] != DBNull.Value)
                    {
                        _nThirdPartyID = (int)reader["ThirdPartyID"];
                    }
                    if (reader["SupervisorID"] != DBNull.Value)
                    {
                        _nSupervisorID = (int)reader["SupervisorID"];
                    }
                    _sThirdPartyCode = (string)reader["TPCode"];
                    _sThirdPartyName = (string)reader["TPName"];
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
    public class Technicians : CollectionBase
    {

        public Technician this[int i]
        {
            get { return (Technician)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Technician oTechnician)
        {
            InnerList.Add(oTechnician);
        }
        public int GetIndex(int nTechnicianID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TechnicianID == nTechnicianID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(String txtTechnicianCode, String txtTechnicianName,string sMobileNo, int nTechnicianTypeID, int nWorkshopTypeID,int nSupervisorID,int nThirdPartyID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.*,b.Name AS ThirdPartyName,b.Code AS ThirdPartyCode,ISNULL(e.EmployeeName,'') SupervisorName from t_CSDTechnician a " 
                         +" LEFT JOIN dbo.t_CSDInterService b ON a.ThirdPartyID = b.InterServiceID"
                         +" LEFT JOIN t_CSDTechnicalSupervisor s ON a.SupervisorID =s.SupervisorID"
                         +" LEFT JOIN t_Employee e ON s.EmployeeID =e.EmployeeID Where a.TechnicianID <>0 ";


            if (txtTechnicianCode != "")
            {
                txtTechnicianCode = "%" + txtTechnicianCode + "%";
                sSql = sSql + " AND a.Code LIKE '" + txtTechnicianCode + "'";
            }
            if (txtTechnicianName != "")
            {
                txtTechnicianName = "%" + txtTechnicianName + "%";
                sSql = sSql + " AND a.Name LIKE '" + txtTechnicianName + "'";
            }
            if (nTechnicianTypeID != 0)
            {
                sSql += " AND a.Type = '" + nTechnicianTypeID + "' ";
            }
            if (nWorkshopTypeID != 0)
            {
                sSql += " AND a.WorkshopTypeID = '" + nWorkshopTypeID + "' ";
            }
            if (sMobileNo != string.Empty)
            {
                sSql += " AND a.MobileNo LIKE '%" + sMobileNo + "%' ";
            }

            if (nSupervisorID != 0)
            {
                sSql += " AND a.SupervisorID = '" + nSupervisorID + "' ";
            }
            if (nThirdPartyID != 0)
            {
                sSql += " AND a.ThirdPartyID = '" + nThirdPartyID + "' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Technician oTechnician = new Technician();

                    oTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oTechnician.Code = (string)reader["Code"];
                    oTechnician.EmployeeCode = (string)reader["EmployeeCode"];
                    oTechnician.Name = (string)reader["Name"];
                    oTechnician.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oTechnician.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTechnician.MaxPay = Convert.ToDouble(reader["MaxPay"].ToString());
                    oTechnician.MinPay = Convert.ToDouble(reader["MinPay"].ToString());
                    oTechnician.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    oTechnician.WorkshopLocationID = (int)reader["WorkshopLocationID"];
                    oTechnician.IsActive = (int)reader["IsActive"];
                    if (reader["ThirdPartyCode"] != DBNull.Value)
                    {
                        oTechnician.ThirdPartyCode = (string)reader["ThirdPartyCode"];
                    }
                    oTechnician.TechnicianTypeID = (int)reader["Type"];
                    oTechnician.TechnicianTypeName = Enum.GetName(typeof(Dictionary.CSDTechnicianType), oTechnician.TechnicianTypeID);
                    oTechnician.IsVariable = (int)reader["IsVariable"];
                    oTechnician.ThirdPartyID = (int)reader["ThirdPartyID"];

                    if ((int)reader["ThirdPartyID"] == 0)
                    {
                        oTechnician.ThirdPartyName = "Not Applicable.";
                    }
                    else
                    {
                        oTechnician.ThirdPartyName = (string)reader["ThirdPartyName"];
                    }
                    if (reader["SupervisorID"] != DBNull.Value)
                    {
                        oTechnician.SupervisorID = (int)reader["SupervisorID"];
                    }
                    oTechnician.SupervisorName = (string)reader["SupervisorName"];
                    if (reader["MobileNo"] != DBNull.Value)
                    {
                        oTechnician.MobileNo = (string)reader["MobileNo"];
                    }
                    if (reader["MobileNo1"] != DBNull.Value)
                    {
                        oTechnician.MobileNo1 = (string)reader["MobileNo1"];
                    }
                    
                    InnerList.Add(oTechnician);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTechnician()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_CSDTechnician Where IsActive=1 ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Technician oTechnician = new Technician();

                    oTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oTechnician.Code = (string)reader["Code"];
                    oTechnician.EmployeeCode = (string)reader["EmployeeCode"];
                    oTechnician.Name = (string)reader["Name"];
                    oTechnician.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oTechnician);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetOwnTechnician()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDTechnician Where Type = " + (int)Dictionary.OwnOrOtherTechnician.Own_Technician+ " ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Technician oTechnician = new Technician();

                    oTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oTechnician.Code = (string)reader["Code"];
                    oTechnician.EmployeeCode = (string)reader["EmployeeCode"];
                    oTechnician.Name = (string)reader["Name"];
                    oTechnician.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oTechnician);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTechnicianByWorkshop(int nWorkshopTypeID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select TechnicianID, Code, a.Name as Technician, a.WorkshopTypeID, b.Name as Workshop " +
            "from t_CSDTechnician a, t_CSDWorkshopType b Where a.WorkshopTypeID=b.WorkshopTypeID and a.IsActive=1 ";

            if (nWorkshopTypeID > 0)
            {
                sSql = sSql + " and a.WorkshopTypeID=" + nWorkshopTypeID + "";
            }

            sSql = sSql + " Order by a.WorkshopTypeID, a.Name ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Technician oTechnician = new Technician();

                    oTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oTechnician.Code = (string)reader["Code"];
                    oTechnician.Name = (string)reader["Technician"];
                    oTechnician.Workshop.Name = (string)reader["Workshop"];

                    InnerList.Add(oTechnician);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTechnicianJob(string sTechCode, int nType, string sTechName)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select Tech.TechnicianID,Tech.Code,Type,(Name +' ['+Code+']') as Name, IsNull(WalkIn,0) as WalkIn, " +
                          "  IsNull(HomeCallJob,0) as HomeCall, IsNull(InstallJob,0) as Install from t_CSDTechnician as Tech " +
                          "  Left Outer JOIN " +
                          "  ( " +
                          "  Select AssignTo, Sum(WalkIn) as WalkIn, Sum(HomeCallJob) as HomeCallJob, Sum(InstallJob) as InstallJob " +
                          "  from " +
                          "  ( " +
                          "  select AssignTo, count(JobID) as WalkIn, 0 as HomeCallJob, 0 as InstallJob  from t_CSDJob where OwnOrOtherTechnician=1 and IsDelivered=0  " +
                          "  and ServiceType<>3 and ServiceType=1 group by AssignTo " +
                          "  UNION ALL " +
                          "  select AssignTo, 0 as WalkIn, count(JobID) as HomeCallJob, 0 as InstallJob  from t_CSDJob where OwnOrOtherTechnician=1 and IsDelivered=0  " +
                          "  and ServiceType<>3 and ServiceType=2 group by AssignTo " +
                          "  UNION ALL " +
                          "  select AssignTo, 0 as WalkIn, 0 as HomeCallJob, count(JobID) as InstallJob  from t_CSDJob where OwnOrOtherTechnician=1 and IsDelivered=0  " +
                          "  and ServiceType<>3 and ServiceType=4 group by AssignTo " +
                          "  ) a Group by AssignTo)AssignJob " +
                          "  ON AssignJob.AssignTo=Tech.TechnicianID WHERE 1=1 ";
            //+ "  order by WorkshopTypeID, name ";

            if (sTechCode != string.Empty)
            {
                sSql += " AND Code = '" + sTechCode + "' ";
            }
            if (nType != -1)
            {
                sSql += " AND Type = " + nType + " ";
            }
            if (sTechName != string.Empty)
            {
                sSql += " AND Name LIKE '%" + sTechName + "%' ";
            }

            sSql += "  order by WorkshopTypeID, name ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Technician oTechnician = new Technician();

                    oTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oTechnician.Name = (string)reader["Name"];

                    oTechnician.WalkInJob = (int)reader["Walkin"];
                    oTechnician.HomeCallJob = (int)reader["HomeCall"];
                    oTechnician.InstallJob = (int)reader["Install"];

                    oTechnician.TotalJob = oTechnician.TotalJob + oTechnician.WalkInJob + oTechnician.HomeCallJob + oTechnician.InstallJob;

                    InnerList.Add(oTechnician);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
         public void GetTechBySupID(int nSupervisorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDTechnician Where SupervisorID = " + nSupervisorID + " Order By Name";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Technician oTechnician = new Technician();
                    oTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oTechnician.Code = (string)reader["Code"];
                    oTechnician.Name = (string)reader["Name"];
                    InnerList.Add(oTechnician);
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


