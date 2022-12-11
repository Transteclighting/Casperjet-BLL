// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 2, 2011
// Time : 5.00 PM
// Description: Class for IT Equipment Transaction Management.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class;

namespace CJ.Class.IT
{
    public class ITEquipmentTran
    {
        private int _TranID;
        private int _ITAssetID;
        private int _TypeID;
        private DateTime _TranDate;
        private int _TranType;       
        private int _EquipmentID;
        private int _EmployeeID;
        private int _DepartmentID;
        private int _CompanyID;
        private int _FromStoreID;
        private int _ToStoreID;
        private int _Qty;
        private string _Remarks;
        private ITEquipment _oITEquipment;
        private Employee _oEmployee;
        private Company _oCompany;
        private Department _oDepartment;


        public ITEquipment ITEquipment
        {
            get
            {
                if (_oITEquipment == null)
                {
                    _oITEquipment = new ITEquipment();
                    _oITEquipment.EquipmentID = _EquipmentID;
                    _oITEquipment.Refresh();
                }

                return _oITEquipment;
            }
        }
        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = _EmployeeID;
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }
        public Department Department
        {
            get
            {
                if (_oDepartment == null)
                {
                    _oDepartment = new Department();
                    _oDepartment.DepartmentID = _DepartmentID;
                    _oDepartment.Refresh();
                }

                return _oDepartment;
            }
        }
        public Company Company
        {
            get
            {
                if (_oCompany == null)
                {
                    _oCompany = new Company();
                    _oCompany.CompanyID = _CompanyID;
                    _oCompany.Refresh();
                }

                return _oCompany;
            }
        }


        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }
        public int ITAssetID
        {
            get { return _ITAssetID; }
            set { _ITAssetID = value; }
        }
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }

        /// <summary>
        /// Get set property for TranType
        /// </summary>
        public int TranType
        {
            get { return _TranType; }
            set { _TranType = value; }
        }       

        /// <summary>
        /// Get set property for EquipmentID
        /// </summary>
        public int EquipmentID
        {
            get { return _EquipmentID; }
            set { _EquipmentID = value; }
        }

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        /// <summary>
        /// Get set property for DepartmentID
        /// </summary>
        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        /// <summary>
        /// Get set property for CompanyID
        /// </summary>
        public int CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        /// <summary>
        /// Get set property for FromStoreID
        /// </summary>
        public int FromStoreID
        {
            get { return _FromStoreID; }
            set { _FromStoreID = value; }
        }

        /// <summary>
        /// Get set property for ToStoreID
        /// </summary>
        public int ToStoreID
        {
            get { return _ToStoreID; }
            set { _ToStoreID = value; }
        }

        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }

        public void Insert()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ITEquipmentTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ITEquipmentTran VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranType", _TranType);
                cmd.Parameters.AddWithValue("TypeID", _TypeID);
                cmd.Parameters.AddWithValue("EquipmentID", _EquipmentID);
                cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID);

                if (_EmployeeID != -1)
                    cmd.Parameters.AddWithValue("EmployeeID", _EmployeeID);
                else cmd.Parameters.AddWithValue("EmployeeID", null);
                if (_DepartmentID != -1)
                    cmd.Parameters.AddWithValue("DepartmentID", _DepartmentID);
                else cmd.Parameters.AddWithValue("DepartmentID", null);
                
                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
                cmd.Parameters.AddWithValue("FromStoreID",_FromStoreID);
                cmd.Parameters.AddWithValue("ToStoreID", _ToStoreID);
                cmd.Parameters.AddWithValue("Qty", 1);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                UpdateITAsset();
                UpdateFromStock(false);
                UpdateToStock(false);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateITAsset()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update  t_ITAsset set CompanyID=?,CurDepartmentID=?,CurEmployeeID=?,StoreID=? where ITAssetID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
               
                if (_DepartmentID != -1)
                    cmd.Parameters.AddWithValue("CurDepartmentID", _DepartmentID);
                else cmd.Parameters.AddWithValue("CurDepartmentID", null);
                if (_EmployeeID != -1)
                    cmd.Parameters.AddWithValue("CurEmployeeID", _EmployeeID);
                else cmd.Parameters.AddWithValue("CurEmployeeID", null);
               
                cmd.Parameters.AddWithValue("StoreID", _ToStoreID);

                cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateFromStock(bool IsDelete)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (_FromStoreID == -1)
                return;

            if (IsDelete == true)
            {
                if (_FromStoreID == 0)
                    sSql = "update  t_ITEquipmentType set MISStoreQty = MISStoreQty + 1 where  TypeID =?";
                if (_FromStoreID == 1)
                    sSql = "update  t_ITEquipmentType set UserEndQty = UserEndQty + 1 where  TypeID =?";
                if (_FromStoreID == 2)
                    sSql = "update  t_ITEquipmentType set DefectiveQty = DefectiveQty + 1 where  TypeID =?";
                if (_FromStoreID == 3)
                    sSql = "update  t_ITEquipmentType set RepairQty = RepairQty + 1 where  TypeID =?";
                if (_FromStoreID == 4)
                    sSql = "update  t_ITEquipmentType set LoanQty = LoanQty + 1 where  TypeID =?";
            }
            else
            {
                if (_FromStoreID == 0)
                    sSql = "update  t_ITEquipmentType set MISStoreQty = MISStoreQty - 1 where  TypeID =?";
                if (_FromStoreID == 1)
                    sSql = "update  t_ITEquipmentType set UserEndQty = UserEndQty - 1 where  TypeID =?";
                if (_FromStoreID == 2)
                    sSql = "update  t_ITEquipmentType set DefectiveQty = DefectiveQty - 1 where  TypeID =?";
                if (_FromStoreID == 3)
                    sSql = "update  t_ITEquipmentType set RepairQty = RepairQty - 1 where  TypeID =?";
                if (_FromStoreID == 4)
                    sSql = "update  t_ITEquipmentType set LoanQty = LoanQty - 1 where  TypeID =?";
            }

            cmd.Parameters.AddWithValue("TypeID", _TypeID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
               
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateToStock(bool IsDelete)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (_ToStoreID == -1)
                return;

            if (IsDelete == true)
            {
                if (_ToStoreID == 0)
                    sSql = "update  t_ITEquipmentType set MISStoreQty = MISStoreQty - 1 where  TypeID =?";
                if (_ToStoreID == 1)
                    sSql = "update  t_ITEquipmentType set UserEndQty = UserEndQty - 1 where  TypeID =?";
                if (_ToStoreID == 2)
                    sSql = "update  t_ITEquipmentType set DefectiveQty = DefectiveQty - 1 where  TypeID =?";
                if (_ToStoreID == 3)
                    sSql = "update  t_ITEquipmentType set RepairQty = RepairQty - 1 where  TypeID =?";
                if (_ToStoreID == 4)
                    sSql = "update  t_ITEquipmentType set LoanQty = LoanQty - 1 where  TypeID =?";
            }
            else
            {
                if (_ToStoreID == 0)
                    sSql = "update  t_ITEquipmentType set MISStoreQty = MISStoreQty + 1 where  TypeID =?";
                if (_ToStoreID == 1)
                    sSql = "update  t_ITEquipmentType set UserEndQty = UserEndQty + 1 where  TypeID =?";
                if (_ToStoreID == 2)
                    sSql = "update  t_ITEquipmentType set DefectiveQty = DefectiveQty + 1 where  TypeID =?";
                if (_ToStoreID == 3)
                    sSql = "update  t_ITEquipmentType set RepairQty = RepairQty + 1 where  TypeID =?";
                if (_ToStoreID == 4)
                    sSql = "update  t_ITEquipmentType set LoanQty = LoanQty + 1 where  TypeID =?";
            }

            cmd.Parameters.AddWithValue("TypeID", _TypeID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

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

            try
            {
                cmd.CommandText = "Delete from  t_ITEquipmentTran where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                UpdateFromStock(true);
                UpdateToStock(true);

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
                cmd.CommandText = "SELECT * FROM t_ITEquipmentTran where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _TranID = (int)reader["TranID"];
                    _TranDate = (DateTime)reader["TranDate"];
                    _TranType = (int)reader["TranType"];                  
                    _EquipmentID = (int)reader["EquipmentID"];
                    _ITAssetID = (int)reader["ITAssetID"];

                    if (reader["EmployeeID"] != DBNull.Value)
                        _EmployeeID = (int)reader["EmployeeID"];
                    else _EmployeeID = -1;

                    if (reader["DepartmentID"] != DBNull.Value)
                        _DepartmentID = (int)reader["DepartmentID"];
                    else _DepartmentID = -1;

                    _CompanyID = (int)reader["CompanyID"];
                    _FromStoreID = (int)reader["FromStoreID"];
                    _ToStoreID = (int)reader["ToStoreID"];
                    _Qty = (int)reader["Qty"];
                    _Remarks = reader["Remarks"].ToString();

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }           
        }

        public int MaxTranID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();            
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ITEquipmentTran where ITAssetID=?";
                cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID);
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                object maxTranID = cmd.ExecuteScalar();               
                return( int.Parse(maxTranID.ToString()));               

              
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
    }
    public class ITEquipmentTranList : CollectionBase
    {
        public ITEquipmentTran this[int i]
        {
            get { return (ITEquipmentTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ITEquipmentTran oITEquipmentTran)
        {
            InnerList.Add(oITEquipmentTran);
        }
        public void Refresh(int nITAssetID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ITEquipmentTran where ITAssetID=? ORDER BY TranID DESC ";
            cmd.Parameters.AddWithValue("ITAssetID", nITAssetID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITEquipmentTran oITEquipmentTran = new ITEquipmentTran();
                    oITEquipmentTran.TranID = (int)reader["TranID"];
                    oITEquipmentTran.TranDate = (DateTime)reader["TranDate"];
                    oITEquipmentTran.TranType = (int)reader["TranType"];
                    oITEquipmentTran.TypeID = (int)reader["TypeID"];
                    oITEquipmentTran.ITAssetID = (int)reader["ITAssetID"];
                    oITEquipmentTran.EquipmentID = (int)reader["EquipmentID"];
                    
                    if (reader["EmployeeID"] != DBNull.Value)
                        oITEquipmentTran.EmployeeID = (int)reader["EmployeeID"];
                    else oITEquipmentTran.EmployeeID = -1;

                    if (reader["DepartmentID"] != DBNull.Value)
                        oITEquipmentTran.DepartmentID = (int)reader["DepartmentID"];
                    else oITEquipmentTran.DepartmentID = -1;

                    oITEquipmentTran.CompanyID = (int)reader["CompanyID"];
                    oITEquipmentTran.FromStoreID = (int)reader["FromStoreID"];
                    oITEquipmentTran.ToStoreID = (int)reader["ToStoreID"];
                    oITEquipmentTran.Qty = (int)reader["Qty"];
                    oITEquipmentTran.Remarks = reader["Remarks"].ToString();

                    InnerList.Add(oITEquipmentTran);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void Refreshfor_BLLTAB(int nITAssetID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"Select Main.*,Convert(Varchar,Main.EmployeeID) as EmployeeID,lst.Name from 
            (
            SELECT * FROM t_ITEquipmentTran 
            ) as Main 

            left join  
            ( 
            Select Code as CurEmployeeID, Name 
            From (
            Select CustomerCode as Code,concat(CustomerName,'-DB') as Name from v_CustomerDetails
            union all  
            Select DSRCode as Code, concat(DSRName,'-',Designation )as Name from t_DMSDSRDetails   
            union all 
            Select CONVERT(varchar, EmployeeCode) as Code,
            Name=  concat(EmployeeName ,'-',DesignationName )
            from [LINKSERVERTEL].telsysdb.dbo.t_employee a,[LINKSERVERTEL].telsysdb.dbo.t_designation b
            where CompanyID = 82943 and a.designationID=b.designationID and a.DepartmentID in ( 82973, 82969, 82980, 82984 ,82992,83044,83045)
            ) as Userlist 
            ) as lst on Main.EmployeeID=lst.CurEmployeeID where ITAssetID=" + nITAssetID + " ORDER BY TranID DESC ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITEquipmentTran oITEquipmentTran = new ITEquipmentTran();
                    oITEquipmentTran.TranID = (int)reader["TranID"];
                    oITEquipmentTran.TranDate = (DateTime)reader["TranDate"];
                    oITEquipmentTran.TranType = (int)reader["TranType"];
                    oITEquipmentTran.TypeID = (int)reader["TypeID"];
                    oITEquipmentTran.ITAssetID = (int)reader["ITAssetID"];
                    oITEquipmentTran.EquipmentID = (int)reader["EquipmentID"];

                    if (reader["EmployeeID"] != DBNull.Value)
                        oITEquipmentTran.EmployeeID = (int)reader["EmployeeID"];
                    else oITEquipmentTran.EmployeeID = -1;

                    if (reader["Name"] != DBNull.Value)
                        oITEquipmentTran.Employee.EmployeeName = (string)reader["Name"];
                    else oITEquipmentTran.Employee.EmployeeName = "N/A";

                    if (reader["DepartmentID"] != DBNull.Value)
                        oITEquipmentTran.DepartmentID = (int)reader["DepartmentID"];
                    else oITEquipmentTran.DepartmentID = -1;

                    oITEquipmentTran.CompanyID = (int)reader["CompanyID"];
                    oITEquipmentTran.FromStoreID = (int)reader["FromStoreID"];
                    oITEquipmentTran.ToStoreID = (int)reader["ToStoreID"];
                    oITEquipmentTran.Qty = (int)reader["Qty"];
                    oITEquipmentTran.Remarks = reader["Remarks"].ToString();

                    InnerList.Add(oITEquipmentTran);
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
