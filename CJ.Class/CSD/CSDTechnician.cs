// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jan 08, 2017
// Time : 05:04 PM
// Description: Class for CSDTechnician.
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
    public class CSDTechnician
    {
        private int _nTechnicianID;
        private string _sCode;
        private string _sEmployeeCode;
        private string _sName;
        private int _nType;
        private int _nIsVariable;
        private int _nThirdPartyID;
        private string _sThirdPartyName;

        private string _sWorkshopTypeName;
        private string _sAddress;
        private string _sPhone;
        private string _sMobile;
        private int _nThanaID;
        private string _sThanaName;
        private int _nDistictID;
        private string _sDistictName;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private double _MaxPay;
        private double _MinPay;
        private int _nWorkshopTypeID;
        private int _nWorkshopLocationID;
        private int _nIsActive;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nSupervisorID;
        private string _sWorkshopLocationName;




        // <summary>
        // Get set property for WorkshopLocationName
        // </summary>
        public string WorkshopLocationName
        {
            get { return _sWorkshopLocationName; }
            set { _sWorkshopLocationName = value; }
        }

        // <summary>
        // Get set property for WorkshopTypeName
        // </summary>
        public string WorkshopTypeName
        {
            get { return _sWorkshopTypeName; }
            set { _sWorkshopTypeName = value; }
        }


        // <summary>
        // Get set property for DistictName
        // </summary>
        public int DistictID
        {
            get { return _nDistictID; }
            set { _nDistictID = value; }
        }

        // <summary>
        // Get set property for DistictName
        // </summary>
        public string DistictName
        {
            get { return _sDistictName; }
            set { _sDistictName = value; }
        }

        // <summary>
        // Get set property for ThanaID
        // </summary>
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }

        // <summary>
        // Get set property for Thana
        // </summary>
        public string ThanaName
        {
            get { return _sThanaName; }
            set { _sThanaName = value; }
        }
        // <summary>
        // Get set property for Phone
        // </summary>
        public string Phone
        {
            get { return _sPhone; }
            set { _sPhone = value; }
        }
        // <summary>
        // Get set property for Mobile
        // </summary>
        public string Mobile
        {
            get { return _sMobile; }
            set { _sMobile = value; }
        }
        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        // <summary>
        // Get set property for ThirdPartyName
        // </summary>
        public string ThirdPartyName
        {
            get { return _sThirdPartyName; }
            set { _sThirdPartyName = value; }
        }

        // <summary>
        // Get set property for TechnicianID
        // </summary>
        public int TechnicianID
        {
            get { return _nTechnicianID; }
            set { _nTechnicianID = value; }
        }

        // <summary>
        // Get set property for Code
        // </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }

        // <summary>
        // Get set property for EmployeeCode
        // </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }

        // <summary>
        // Get set property for Name
        // </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        // <summary>
        // Get set property for IsVariable
        // </summary>
        public int IsVariable
        {
            get { return _nIsVariable; }
            set { _nIsVariable = value; }
        }

        // <summary>
        // Get set property for ThirdPartyID
        // </summary>
        public int ThirdPartyID
        {
            get { return _nThirdPartyID; }
            set { _nThirdPartyID = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for MaxPay
        // </summary>
        public double MaxPay
        {
            get { return _MaxPay; }
            set { _MaxPay = value; }
        }

        // <summary>
        // Get set property for MinPay
        // </summary>
        public double MinPay
        {
            get { return _MinPay; }
            set { _MinPay = value; }
        }

        // <summary>
        // Get set property for WorkshopTypeID
        // </summary>
        public int WorkshopTypeID
        {
            get { return _nWorkshopTypeID; }
            set { _nWorkshopTypeID = value; }
        }

        // <summary>
        // Get set property for WorkshopLocationID
        // </summary>
        public int WorkshopLocationID
        {
            get { return _nWorkshopLocationID; }
            set { _nWorkshopLocationID = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        // <summary>
        // Get set property for SupervisorID
        // </summary>
        public int SupervisorID
        {
            get { return _nSupervisorID; }
            set { _nSupervisorID = value; }
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
                sSql = "INSERT INTO t_CSDTechnician (TechnicianID, Code, EmployeeCode, Name, Type, IsVariable, ThirdPartyID, CreateUserID, CreateDate, MaxPay, MinPay, WorkshopTypeID, WorkshopLocationID, IsActive, UpdateUserID, UpdateDate,SupervisorID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("IsVariable", _nIsVariable);
                cmd.Parameters.AddWithValue("ThirdPartyID", _nThirdPartyID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("MaxPay", _MaxPay);
                cmd.Parameters.AddWithValue("MinPay", _MinPay);
                cmd.Parameters.AddWithValue("WorkshopTypeID", _nWorkshopTypeID);
                cmd.Parameters.AddWithValue("WorkshopLocationID", _nWorkshopLocationID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("SupervisorID", _nSupervisorID);
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
                sSql = "UPDATE t_CSDTechnician SET Code = ?, EmployeeCode = ?, Name = ?, Type = ?, IsVariable = ?, ThirdPartyID = ?, CreateUserID = ?, CreateDate = ?, MaxPay = ?, MinPay = ?, WorkshopTypeID = ?, WorkshopLocationID = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ?,SupervisorID=? WHERE TechnicianID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("IsVariable", _nIsVariable);
                cmd.Parameters.AddWithValue("ThirdPartyID", _nThirdPartyID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("MaxPay", _MaxPay);
                cmd.Parameters.AddWithValue("MinPay", _MinPay);
                cmd.Parameters.AddWithValue("WorkshopTypeID", _nWorkshopTypeID);
                cmd.Parameters.AddWithValue("WorkshopLocationID", _nWorkshopLocationID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("SupervisorID", _nSupervisorID);
                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);

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
                sSql = "DELETE FROM t_CSDTechnician WHERE [TechnicianID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
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
                cmd.CommandText = "SELECT * FROM t_CSDTechnician where TechnicianID =?";
                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTechnicianID = (int)reader["TechnicianID"];
                    _sCode = (string)reader["Code"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sName = (string)reader["Name"];
                    _nType = (int)reader["Type"];
                    _nIsVariable = (int)reader["IsVariable"];
                    _nThirdPartyID = (int)reader["ThirdPartyID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _MaxPay = Convert.ToDouble(reader["MaxPay"].ToString());
                    _MinPay = Convert.ToDouble(reader["MinPay"].ToString());
                    _nWorkshopTypeID = (int)reader["WorkshopTypeID"];
                    _nWorkshopLocationID = (int)reader["WorkshopLocationID"];
                    _nIsActive = (int)reader["IsActive"];
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        _nUpdateUserID = (int)reader["UpdateUserID"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    if (reader["SupervisorID"] != DBNull.Value)
                    {
                        _nSupervisorID = (int)reader["SupervisorID"];
                    }

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetTechnicianByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                //cmd.CommandText = "SELECT * FROM t_CSDTechnician where Code = '" + sTechnicianCode + "' ";
                cmd.CommandText = "SELECT * FROM t_CSDTechnician where Code = ?";
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTechnicianID = (int)reader["TechnicianID"];
                    _sCode = (string)reader["Code"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sName = (string)reader["Name"];
                    _nType = (int)reader["Type"];
                    _nIsVariable = (int)reader["IsVariable"];
                    _nThirdPartyID = (int)reader["ThirdPartyID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _MaxPay = Convert.ToDouble(reader["MaxPay"].ToString());
                    _MinPay = Convert.ToDouble(reader["MinPay"].ToString());
                    _nWorkshopTypeID = (int)reader["WorkshopTypeID"];
                    _nWorkshopLocationID = (int)reader["WorkshopLocationID"];
                    _nIsActive = (int)reader["IsActive"];
                    if (reader["UpdateUserID"] != DBNull.Value)
                        _nUpdateUserID = (int)reader["UpdateUserID"];
                    if (reader["UpdateDate"] != DBNull.Value)
                        _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    if (reader["SupervisorID"] != DBNull.Value)
                    {
                        _nSupervisorID = (int)reader["SupervisorID"];
                    }
                    
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
    public class CSDTechnicians : CollectionBase
    {
        public CSDTechnician this[int i]
        {
            get { return (CSDTechnician)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDTechnician oCSDTechnician)
        {
            InnerList.Add(oCSDTechnician);
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
        public void GetData(int nThanaID, string sTechCode, string sTechName, int nThirdpartyID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT x.*,a.GeoLocationName AS DistictName,b.Name AS WorkshopTypeName FROM (select  a.Code AS TechnicianCode,a.TechnicianID,a.Name AS TechnicianName, a.Type AS TechType,"
                         + " a.ThirdPartyID,a.WorkshopTypeID,a.MaxPay,a.MinPay,b.Interserviceid,b.Name AS InterServiceName,b.Address,"
                         + " b.Phone,b.Mobile,b.ContactPerson,b.Thanaid,c.GeoLocationID,c.GeoLocationName AS ThanaName,"
                         + " c.ParentId AS DistictID from t_CSDTechnician a"
                         + " INNER JOIN t_CSDInterService b ON b.InterServiceID = a.ThirdPartyID"
                         + " LEFT JOIN t_Geolocation c on b.ThanaID = c.GeoLocationID WHERE a.IsActive = 1 AND Type = " + (int)Dictionary.CSDTechnicianType.ThirdParty + " )"
                         + " as x LEFT JOIN t_Geolocation a on x.DistictID = a.GeoLocationID"
                         + " LEFT JOIN dbo.t_CSDWorkshopType b ON x.WorkshopTypeID = b.WorkshopTypeID"
                         + " WHERE 1=1";

            if (nThanaID != -1)
            {
                sSql += " AND ThanaID  = " + nThanaID + " ";
            }
            if (nThirdpartyID != -1)
            {
                sSql += " AND InterServiceID  = " + nThirdpartyID + " ";
            }
            if (sTechCode != string.Empty)
            {
                sSql += " AND TechnicianCode = '" + sTechCode + "' ";
            }
            if (sTechName != string.Empty)
            {
                sSql += " AND TechnicianName LIKE '%" + sTechName + "%' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTechnician oCSDTechnician = new CSDTechnician();
                    oCSDTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oCSDTechnician.Type = (int)reader["TechType"];

                    oCSDTechnician.Name = (string)reader["TechnicianName"];
                    oCSDTechnician.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    oCSDTechnician.WorkshopTypeName = (string)reader["WorkshopTypeName"];
                    oCSDTechnician.Code = (string)reader["TechnicianCode"];
                    //oCSDTechnician.EmployeeCode = (string)reader["EmployeeCode"];
                    //oCSDTechnician.Type = (int)reader["Type"];
                    //oCSDTechnician.IsVariable = (int)reader["IsVariable"];
                    oCSDTechnician.ThirdPartyID = (int)reader["InterServiceID"];
                    oCSDTechnician.ThirdPartyName = (string)reader["InterServiceName"];
                    oCSDTechnician.Address = (string)reader["Address"];
                    oCSDTechnician.Phone = (string)reader["Phone"];
                    oCSDTechnician.Mobile = (string)reader["Mobile"];
                    oCSDTechnician.ThanaID = (int)reader["ThanaID"];
                    oCSDTechnician.ThanaName = (string)reader["ThanaName"];
                    oCSDTechnician.DistictID = (int)reader["DistictID"];
                    oCSDTechnician.DistictName = (string)reader["DistictName"];

                    //oCSDTechnician.CreateUserID = (int)reader["CreateUserID"];
                    //oCSDTechnician.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDTechnician.MaxPay = Convert.ToDouble(reader["MaxPay"].ToString());
                    oCSDTechnician.MinPay = Convert.ToDouble(reader["MinPay"].ToString());
                    //oCSDTechnician.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    //oCSDTechnician.WorkshopLocationID = (int)reader["WorkshopLocationID"];
                    //oCSDTechnician.IsActive = (int)reader["IsActive"];
                    //oCSDTechnician.UpdateUserID = (int)reader["UpdateUserID"];
                    //oCSDTechnician.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oCSDTechnician);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetOwnTechnician(string sTechCode, string sTechName, int nWorkshopLocationID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*,a.Name TechnicianName,b.Name AS WorkshopTypeName,WL.Name AS WorkshopLocationName FROM t_CSDTechnician a "
                        +" LEFT JOIN t_CSDWorkshopType b ON a.WorkshopTypeID = b.WorkshopTypeID "
                        +" LEFT OUTER JOIN t_CSDWorkshopLocation WL ON WL.WorkshopLocationID = a.WorkshopLocationID "
                        +" WHERE Type = " + (int)Dictionary.CSDTechnicianType.Own + " and a.isactive=1 ";


            if (sTechCode != string.Empty)
            {
                sSql += " AND Code = '" + sTechCode + "' ";
            }
            if (sTechName != string.Empty)
            {
                sSql += " AND a.Name LIKE '%" + sTechName + "%' ";
            }
            if (nWorkshopLocationID != 0)
            {
                sSql += " AND WL.WorkshopLocationID = " + nWorkshopLocationID+ " ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTechnician oCSDTechnician = new CSDTechnician();
                    oCSDTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oCSDTechnician.Type = (int)reader["Type"];
                    oCSDTechnician.Name = (string)reader["TechnicianName"];
                    oCSDTechnician.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    oCSDTechnician.WorkshopTypeName = (string)reader["WorkshopTypeName"];
                    oCSDTechnician.Code = (string)reader["Code"];
                    oCSDTechnician.WorkshopLocationName = (string)reader["WorkshopLocationName"];

                    //oCSDTechnician.ThirdPartyID = (int)reader["InterServiceID"];                    
                    //oCSDTechnician.ThanaID = (int)reader["ThanaID"];
                    //oCSDTechnician.ThanaName = (string)reader["ThanaName"];
                    //oCSDTechnician.DistictID = (int)reader["DistictID"];
                    //oCSDTechnician.DistictName = (string)reader["DistictName"];
                    oCSDTechnician.MaxPay = Convert.ToDouble(reader["MaxPay"].ToString());
                    oCSDTechnician.MinPay = Convert.ToDouble(reader["MinPay"].ToString());
                    InnerList.Add(oCSDTechnician);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void GetDataOfOwnTech()
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "SELECT a.TechnicianID ,a.Type As TechType,a.Code AS TechCode, a.Name AS TechName,a.WorkshopTypeID, b.Name AS WorkshopTypeName from t_CSDTechnician a "
        //        + " INNER JOIN dbo.t_CSDWorkshopType b ON a.WorkshopTypeID = b.WorkshopTypeID WHERE a.Type = " + (int)Dictionary.CSDTechnicianType.Own + "  ";
            
        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            CSDTechnician oCSDTechnician = new CSDTechnician();
        //            oCSDTechnician.TechnicianID = (int)reader["TechnicianID"];
        //            oCSDTechnician.Code = (string)reader["TechCode"];
        //            oCSDTechnician.Name = (string)reader["TechName"];
        //            oCSDTechnician.Type = (int)reader["TechType"];
        //            oCSDTechnician.WorkshopTypeID = (int)reader["WorkshopTypeID"];
        //            oCSDTechnician.WorkshopTypeName = (string)reader["WorkshopTypeName"];

        //            InnerList.Add(oCSDTechnician);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDTechnician";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTechnician oCSDTechnician = new CSDTechnician();
                    oCSDTechnician.TechnicianID = (int)reader["TechnicianID"];
                    oCSDTechnician.Code = (string)reader["Code"];
                    oCSDTechnician.EmployeeCode = (string)reader["EmployeeCode"];
                    oCSDTechnician.Name = (string)reader["Name"];
                    oCSDTechnician.Type = (int)reader["Type"];
                    oCSDTechnician.IsVariable = (int)reader["IsVariable"];
                    oCSDTechnician.ThirdPartyID = (int)reader["ThirdPartyID"];
                    oCSDTechnician.CreateUserID = (int)reader["CreateUserID"];
                    oCSDTechnician.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDTechnician.MaxPay = Convert.ToDouble(reader["MaxPay"].ToString());
                    oCSDTechnician.MinPay = Convert.ToDouble(reader["MinPay"].ToString());
                    oCSDTechnician.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    oCSDTechnician.WorkshopLocationID = (int)reader["WorkshopLocationID"];
                    oCSDTechnician.IsActive = (int)reader["IsActive"];
                    oCSDTechnician.UpdateUserID = (int)reader["UpdateUserID"];
                    oCSDTechnician.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oCSDTechnician);
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

