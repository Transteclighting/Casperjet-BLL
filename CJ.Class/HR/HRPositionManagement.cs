// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Nov 03, 2016
// Time : 06:32 PM
// Description: Class for HRPosition.
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
    public class HRPosition
    {
        private int _nPositionID;
        private string _sPositionCode;
        private string _sPositionName;
        private int _nCompanyID;
        private int _nDepartmentID;
        private int _nBaseStationType;
        private int _nRoleType;
        private int _nRole;
        private int _nSort;
        private int _nParentID;
        private int _nMarketGroupType;
        private int _nMarketGroupID;
        private int _nEmployeeID;
        private int _nMarkAsVacant;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


        // <summary>
        // Get set property for PositionID
        // </summary>
        public int PositionID
        {
            get { return _nPositionID; }
            set { _nPositionID = value; }
        }

        // <summary>
        // Get set property for PositionCode
        // </summary>
        public string PositionCode
        {
            get { return _sPositionCode; }
            set { _sPositionCode = value.Trim(); }
        }

        // <summary>
        // Get set property for PositionName
        // </summary>
        public string PositionName
        {
            get { return _sPositionName; }
            set { _sPositionName = value.Trim(); }
        }

        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        // <summary>
        // Get set property for DepartmentID
        // </summary>
        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }

        // <summary>
        // Get set property for BaseStationType
        // </summary>
        public int BaseStationType
        {
            get { return _nBaseStationType; }
            set { _nBaseStationType = value; }
        }

        // <summary>
        // Get set property for RoleType
        // </summary>
        public int RoleType
        {
            get { return _nRoleType; }
            set { _nRoleType = value; }
        }

        // <summary>
        // Get set property for Role
        // </summary>
        public int Role
        {
            get { return _nRole; }
            set { _nRole = value; }
        }

        // <summary>
        // Get set property for Sort
        // </summary>
        public int Sort
        {
            get { return _nSort; }
            set { _nSort = value; }
        }

        // <summary>
        // Get set property for ParentID
        // </summary>
        public int ParentID
        {
            get { return _nParentID; }
            set { _nParentID = value; }
        }

        // <summary>
        // Get set property for MarketGroupType
        // </summary>
        public int MarketGroupType
        {
            get { return _nMarketGroupType; }
            set { _nMarketGroupType = value; }
        }

        // <summary>
        // Get set property for MarketGroupID
        // </summary>
        public int MarketGroupID
        {
            get { return _nMarketGroupID; }
            set { _nMarketGroupID = value; }
        }

        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        public int MarkAsVacant
        {
            get { return _nMarkAsVacant; }
            set { _nMarkAsVacant = value; }
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

        private string _sMarketGroupCode;
        public string MarketGroupCode
        {
            get { return _sMarketGroupCode; }
            set { _sMarketGroupCode = value; }
        }

        private string _sMarketGroupDesc;
        public string MarketGroupDesc
        {
            get { return _sMarketGroupDesc; }
            set { _sMarketGroupDesc = value; }
        }
        private string _sRemarks;
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        private string _sDepartmentName;
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value; }
        }
        private string _sMarketGroupTypeName;
        public string MarketGroupTypeName
        {
            get { return _sMarketGroupTypeName; }
            set { _sMarketGroupTypeName = value; }
        }
        private object _dLastWorkingDate;
        public object LastWorkingDate
        {
            get { return _dLastWorkingDate; }
            set { _dLastWorkingDate = value; }
        }
        private string _sStatus;
        public string Status
        {
            get { return _sStatus; }
            set { _sStatus = value; }
        }
        private string _sEmployeeCode;
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        private string _sEmployeeName;
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        private int _nAreaID;
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        private string _sAreaName;
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        private int _nTerritoryID;
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }
        private string _sTerritoryName;
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }
        private int _nCustomerID;
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }

        public void Add()
        {
            int nMaxPositionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PositionID]) FROM t_HRPosition";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPositionID = 1;
                }
                else
                {
                    nMaxPositionID = Convert.ToInt32(maxID) + 1;
                }
                _nPositionID = nMaxPositionID;
                sSql = "INSERT INTO t_HRPosition (PositionID, PositionCode, PositionName, CompanyID, DepartmentID, "+ 
                    " BaseStationType, RoleType, Role, Sort, ParentID, MarketGroupType, MarketGroupID, CreateUserID, CreateDate, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PositionID", _nPositionID);
                cmd.Parameters.AddWithValue("PositionCode", _sPositionCode);
                cmd.Parameters.AddWithValue("PositionName", _sPositionName);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("BaseStationType", _nBaseStationType);
                cmd.Parameters.AddWithValue("RoleType", _nRoleType);
                cmd.Parameters.AddWithValue("Role", _nRole);
                cmd.Parameters.AddWithValue("Sort", _nSort);
                cmd.Parameters.AddWithValue("ParentID", _nParentID);
                if (_nMarketGroupType != -1)
                    cmd.Parameters.AddWithValue("MarketGroupType", _nMarketGroupType);
                else cmd.Parameters.AddWithValue("MarketGroupType", null);
                if (_nMarketGroupID != -1)
                    cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                else cmd.Parameters.AddWithValue("MarketGroupID", null);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit(int nPositionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPosition SET PositionCode = ?, PositionName = ?, DepartmentID = ?, BaseStationType = ?, RoleType = ?, Role = ?, MarketGroupType = ?, MarketGroupID = ?, UpdateUserID = ?, UpdateDate = ?, Remarks = ? WHERE PositionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PositionCode", _sPositionCode);
                cmd.Parameters.AddWithValue("PositionName", _sPositionName);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("BaseStationType", _nBaseStationType);
                cmd.Parameters.AddWithValue("RoleType", _nRoleType);
                cmd.Parameters.AddWithValue("Role", _nRole);
                if (_nMarketGroupType != -1)
                    cmd.Parameters.AddWithValue("MarketGroupType", _nMarketGroupType);
                else cmd.Parameters.AddWithValue("MarketGroupType", null);
                if (_nMarketGroupID != -1)
                    cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                else cmd.Parameters.AddWithValue("MarketGroupID", null);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("PositionID", nPositionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPosition SET ParentID = ? WHERE PositionID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ParentID", _nParentID);

                cmd.Parameters.AddWithValue("PositionID", _nPositionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Assign()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPosition SET EmployeeID = ? WHERE PositionID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

                cmd.Parameters.AddWithValue("PositionID", _nPositionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateMarkAsVacant()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPosition SET MarkAsVacant = ? WHERE PositionID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                if (_nMarkAsVacant != 0)
                    cmd.Parameters.AddWithValue("MarkAsVacant", _nMarkAsVacant);
                else cmd.Parameters.AddWithValue("MarkAsVacant", null);
                cmd.Parameters.AddWithValue("PositionID", _nPositionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Unassign()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPosition SET EmployeeID = ?, MarkAsVacant = ? WHERE PositionID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", null);
                cmd.Parameters.AddWithValue("MarkAsVacant", null);

                cmd.Parameters.AddWithValue("PositionID", _nPositionID);

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
                sSql = "DELETE FROM t_HRPositionAssignHistory WHERE [PositionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PositionID", _nPositionID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_HRPosition WHERE [PositionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PositionID", _nPositionID);
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
                cmd.CommandText = "SELECT * FROM t_HRPosition where PositionID =?";
                cmd.Parameters.AddWithValue("PositionID", _nPositionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPositionID = (int)reader["PositionID"];
                    _sPositionCode = (string)reader["PositionCode"];
                    _sPositionName = (string)reader["PositionName"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nDepartmentID = (int)reader["DepartmentID"];
                    _nBaseStationType = (int)reader["BaseStationType"];
                    _nRoleType = (int)reader["RoleType"];
                    _nRole = (int)reader["Role"];
                    _nSort = (int)reader["Sort"];
                    _nParentID = (int)reader["ParentID"];
                    _nMarketGroupType = (int)reader["MarketGroupType"];
                    _nMarketGroupID = (int)reader["MarketGroupID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public int GetMarketGroupID(string sType, int nID, string sDB)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _nID = 0;
            if (sDB == "BLLSysDB")
            {
                sDB = "blldbserver01.BLLSysDB";
            }
            try
            {
                string sSQL = "";
                if (sType == "Area")
                {
                    sSQL = "Select ParentID as ID from " + sDB + ".dbo.t_MarketGroup  Where MarketGroupType = 2 and MarketGroupID=" + nID + " ";
                }
                else
                {
                    sSQL = "Select MarketGroupID as ID from " + sDB + ".dbo.t_Customer Where CustomerID = " + nID + " ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _nID;
        }

        public bool CheckMarkAsVacant(int nPositionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _nID = 0;
            try
            {
                string sSQL = "";

                sSQL = "Select IsNull(MarkAsVacant,0) as MarkAsVacant from dbo.t_HRPosition Where PositionID = " + nPositionID + " ";


                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["MarkAsVacant"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (_nID > 0)
                return true;
            else return false;
        }

        public bool CheckAssign(int nPositionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _nID = 0;
            try
            {
                string sSQL = "";

                sSQL = "Select IsNull(EmployeeID,0) as EmployeeID from dbo.t_HRPosition Where PositionID = " + nPositionID + " ";


                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["EmployeeID"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (_nID > 0)
                return true;
            else return false;
        }

        public bool CheckChild(int nPositionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                string sSQL = "";

                sSQL = "Select * from dbo.t_HRPosition Where ParentID = " + nPositionID + " ";


                cmd.CommandText = sSQL;
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
            if (nCount != 0)
                return true;
            else return false;
        }
    }
    public class HRPositions : CollectionBase
    {
        public HRPosition this[int i]
        {
            get { return (HRPosition)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRPosition oHRPosition)
        {
            InnerList.Add(oHRPosition);
        }
        public int GetIndex(int nPositionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PositionID == nPositionID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetMarketGroupIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].MarketGroupID == nID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRPosition";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPosition oHRPosition = new HRPosition();

                    oHRPosition.PositionID = (int)reader["PositionID"];
                    oHRPosition.PositionCode = (string)reader["PositionCode"];
                    oHRPosition.PositionName = (string)reader["PositionName"];
                    oHRPosition.CompanyID = (int)reader["CompanyID"];
                    oHRPosition.DepartmentID = (int)reader["DepartmentID"];
                    oHRPosition.BaseStationType = (int)reader["BaseStationType"];
                    oHRPosition.RoleType = (int)reader["RoleType"];
                    oHRPosition.Role = (int)reader["Role"];
                    oHRPosition.Sort = (int)reader["Sort"];
                    oHRPosition.ParentID = (int)reader["ParentID"];
                    oHRPosition.MarketGroupType = (int)reader["MarketGroupType"];
                    oHRPosition.MarketGroupID = (int)reader["MarketGroupID"];
                    oHRPosition.EmployeeID = (int)reader["EmployeeID"];
                    oHRPosition.CreateUserID = (int)reader["CreateUserID"];
                    oHRPosition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRPosition.UpdateUserID = (int)reader["UpdateUserID"];
                    oHRPosition.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());

                    InnerList.Add(oHRPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPositionList(string sDatabase, int nCompanyID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select PositionID, PositionCode, PositionName, CompanyID, DepartmentName, BaseStationType, RoleType, " +
            "Role, Sort, MarketGroupTypeName, MarketGroupID, EmployeeID, MarkAsVacant, LastWorkingDate, Status, EmployeeCode, " +
            "EmployeeName, AreaID, AreaName, TerritoryID, TerritoryName, CustomerID, CustomerName " +
            "from " +
            "( " +
            "Select a.PositionID, PositionCode, PositionName, CompanyID, DepartmentName, BaseStationType, RoleType,  " +
            "Role, Sort, CASE When a.MarketGroupType = 1 then 'Area' When a.MarketGroupType = 2 then 'Territory'  " +
            "When a.MarketGroupType = 3 then 'Customer' else '' end as MarketGroupTypeName,  " +
            "IsNull(a.MarketGroupID,0) as MarketGroupID, IsNull(a.EmployeeID,0) as EmployeeID,  " +
            "IsNull(a.MarkAsVacant,0) as MarkAsVacant, ToDate as LastWorkingDate,  " +
            "Case When IsNull(a.EmployeeID,0) = 0 then 'Vacant' When IsNull(a.EmployeeID,0) != 0 and IsNull(a.MarkAsVacant,0)=0 then 'Fill' " +
            "else 'ToBeVacant' end as Status, " +
            "IsNull(EmployeeCode,'') as EmployeeCode,  " +
            "IsNull(EmployeeName,'') as EmployeeName,IsNull(AreaID,0) as AreaID, IsNull(AreaName,'') as AreaName,  " +
            "IsNull(TerritoryID,0) as TerritoryID, IsNull(TerritoryName,'') as TerritoryName,  " +
            "IsNull(CustomerID,0) as CustomerID, IsNull(CustomerName,'') as CustomerName from  " +
            "( " +
            "Select PositionID, PositionCode, PositionName, CompanyID, DepartmentName, BaseStationType, RoleType.Name as RoleType,  " +
            "Role.Name as Role, Sort, MarketGroupType, MarketGroupID, EmployeeID, MarkAsVacant " +
            "from dbo.t_HRPosition a, t_Department b, (Select ID, Name from dbo.t_HRPositionRole Where Type = 1) as RoleType, " +
            "(Select ID, Name from dbo.t_HRPositionRole Where Type = 2) as Role " +
            "Where  a.DepartmentID =  b.DepartmentID and RoleType.ID=a.RoleType and Role.ID =  a.Role and a.CompanyID="+nCompanyID+" " +
            ")a " +
            "Left Outer JOIN " +
            "( " +
            "Select 1 as MarketGroupType, MarketGroupID, MarketGroupID as AreaID, MarketGroupDesc as AreaName,  0 as TerritoryID,  " +
            "'' as TerritoryName, 0 as CustomerID, '' as CustomerName from " + sDatabase + ".dbo.t_MarketGroup Where MarketGroupType = 1 " +
            "UNION ALL " +
            "Select 2 as MarketGroupType, TerritoryID as MarketGroupID, AreaID, AreaName, TerritoryID, TerritoryName, 0 as CustomerID, '' as CustomerName  " +
            "from " + sDatabase + ".dbo.v_CustomerDetails Group by AreaID, AreaName, TerritoryID, TerritoryName " +
            "UNION ALL " +
            "Select 3 as MarketGroupType, CustomerID as MarketGroupID, AreaID, AreaName, TerritoryID, TerritoryName, CustomerID, CustomerName  " +
            "from " + sDatabase + ".dbo.v_CustomerDetails Group by AreaID, AreaName, TerritoryID, TerritoryName, CustomerID, CustomerName " +
            ")b " +
            "ON a.MarketGroupType=b.MarketGroupType and a.MarketGroupID =  b.MarketGroupID " +
            "Left Outer JOIN " +
            "(Select EmployeeID, EmployeeCode, EmployeeName from t_Employee) c " +
            "ON c.EmployeeID=a.EmployeeID  " +
            "Left Outer JOIN " +
            "(Select 1 as MarkAsVacant, a.PositionID, ToDate from   " +
            "(Select Max(ID) as ID, PositionID from dbo.t_HRPositionAssignHistory Group by PositionID) a,  " +
            "(Select ID, PositionID, ToDate from dbo.t_HRPositionAssignHistory)b Where a.ID = b.ID)d " +
            "ON a.MarkAsVacant=d.MarkAsVacant and a.PositionID=d.PositionID " +
            ")x ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPosition oHRPosition = new HRPosition();

                    oHRPosition.PositionID = (int)reader["PositionID"];
                    oHRPosition.PositionCode = (string)reader["PositionCode"];
                    oHRPosition.PositionName = (string)reader["PositionName"];
                    oHRPosition.CompanyID = (int)reader["CompanyID"];

                    //oHRPosition.DepartmentID = (int)reader["DepartmentID"];
                    oHRPosition.DepartmentName = (string)reader["DepartmentName"];
                    oHRPosition.BaseStationType = (int)reader["BaseStationType"];
                   // oHRPosition.RoleType = (int)reader["RoleType"];
                    //oHRPosition.Role = (int)reader["Role"];
                    oHRPosition.Sort = (int)reader["Sort"];

                    //oHRPosition.ParentID = (int)reader["ParentID"];
                    oHRPosition.MarketGroupTypeName = (string)reader["MarketGroupTypeName"];
                    oHRPosition.MarketGroupID = (int)reader["MarketGroupID"];
                    oHRPosition.EmployeeID = (int)reader["EmployeeID"];

                    oHRPosition.MarkAsVacant = (int)reader["MarkAsVacant"];
                    oHRPosition.LastWorkingDate = (object)reader["LastWorkingDate"];
                    oHRPosition.Status = (string)reader["Status"];
                    oHRPosition.EmployeeCode = (string)reader["EmployeeCode"];

                    oHRPosition.EmployeeName = (string)reader["EmployeeName"];
                    oHRPosition.AreaID = (int)reader["AreaID"];
                    oHRPosition.AreaName = (string)reader["AreaName"];

                    oHRPosition.TerritoryID = (int)reader["TerritoryID"];
                    oHRPosition.TerritoryName = (string)reader["TerritoryName"];

                    oHRPosition.CustomerID = (int)reader["CustomerID"];
                    oHRPosition.CustomerName = (string)reader["CustomerName"];

                    InnerList.Add(oHRPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetMarketGroup(string sType, int nID, string sDatabase)
        {
            if (sDatabase == "BLLSysDB")
            {
                sDatabase = "blldbserver01.BLLSysDB";
            }
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (sType == "Area")
            {
                sSql = " Select MarketGroupID as ID, MarketGroupCode as Code, MarketGroupDesc as Des from " + sDatabase + ".dbo.t_MarketGroup " +
                       " Where MarketGroupType = 1 Order by MarketGroupDesc";

            }
            else if (sType == "Territory")
            {
                sSql = " Select MarketGroupID as ID, MarketGroupCode as Code, MarketGroupDesc as Des from " + sDatabase + ".dbo.t_MarketGroup " +
                       " Where MarketGroupType = 2 and ParentID = " + nID + " Order by MarketGroupDesc";
            }
            else if (sType == "Customer")
            {
                sSql = " Select CustomerID as ID, CustomerCode as Code, CustomerName as Des from " + sDatabase + ".dbo.t_Customer " +
                       " Where MarketGroupID = " + nID + " Order by CustomerName";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPosition oHRPosition = new HRPosition();

                    oHRPosition.MarketGroupID = (int)reader["ID"];
                    oHRPosition.MarketGroupCode = (string)reader["Code"];
                    oHRPosition.MarketGroupDesc = (string)reader["Des"];

                    InnerList.Add(oHRPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPosition()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select PositionID, PositionCode,  " +
                        "'['+PositionCode+']'+' '+ PositionName+' '+'['+CompanyCode+']' as PositionName,   " +
                        "a.CompanyID, DepartmentName, BaseStationType, RoleType.Name as RoleType,    " +
                        "Role.Name as Role, Sort, MarketGroupType, MarketGroupID, EmployeeID, MarkAsVacant,  " +
                        "Case When IsNull(a.EmployeeID,0) = 0 then 'Vacant' When IsNull(a.EmployeeID,0) != 0 and IsNull(a.MarkAsVacant,0)=0 then 'Fill'   " +
                        "else 'ToBeVacant' end as Status  " +
                        "from dbo.t_HRPosition a, t_Department b,t_Company c,   " +
                        "(  " +
                        "Select ID, Name from dbo.t_HRPositionRole Where Type = 1  " +
                        ") as RoleType,   " +
                        "(  " +
                        "Select ID, Name from dbo.t_HRPositionRole Where Type = 2  " +
                        ") as Role   " +
                        "Where a.CompanyID=c.CompanyID and    " +
                        "a.DepartmentID =  b.DepartmentID   " +
                        "and RoleType.ID=a.RoleType and Role.ID = a.Role";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPosition oHRPosition = new HRPosition();

                    oHRPosition.PositionID = (int)reader["PositionID"];
                    oHRPosition.PositionCode = (string)reader["PositionCode"];
                    oHRPosition.PositionName = (string)reader["PositionName"];
                    oHRPosition.CompanyID = (int)reader["CompanyID"];
                    oHRPosition.Status = (string)reader["Status"];

                    InnerList.Add(oHRPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetPositionByCompany(string sCompany)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select PositionID,PositionName+' '+'['+PositionCode+']' PositionName " +
                          "From dbo.t_HRPosition a,t_Company b where a.CompanyID=b.CompanyID and CompanyCode='" + sCompany + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPosition oHRPosition = new HRPosition();

                    oHRPosition.PositionID = (int)reader["PositionID"];
                    //oHRPosition.PositionCode = (string)reader["PositionCode"];
                    oHRPosition.PositionName = (string)reader["PositionName"];

                    InnerList.Add(oHRPosition);
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

