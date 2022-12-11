// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 9, 2011
// Time : 12.00 PM
// Description: Class for IT Asset Management.
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
    public class ITAsset
    {
        private int _ITAssetID;
        private int _TypeID;
        private string _AssetNo;
        private int _EquipmentID;
        private string _SerialNo;
        private int _SupplierID;
        private object _PurchaseDate;
        private DateTime _PDate;
        private object _DiscardDate;
        private int _CompanyID;
        private int _CurDepartmentID;
        private int _CurEmployeeID;
        private int _StoreID;
        private object _EntryDate;
        private string _Remarks;
        private ITEquipment _oITEquipment;
        private Employee _oEmployee;
        private string _sEmployeeCode;

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
                    _oEmployee.EmployeeID = _CurEmployeeID;
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        /// <summary>
        /// Get set property for ITAssetID
        /// </summary>
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
        /// Get set property for AssetNo
        /// </summary>
        public string AssetNo
        {
            get { return _AssetNo; }
            set { _AssetNo = value.Trim(); }
        }
        public DateTime PDate
        {
            get { return _PDate; }
            set { _PDate = value; }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
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
        /// Get set property for SerialNo
        /// </summary>
        public string SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for SupplierID
        /// </summary>
        public int SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }

        /// <summary>
        /// Get set property for PurchaseDate
        /// </summary>
        public object PurchaseDate
        {
            get { return _PurchaseDate; }
            set { _PurchaseDate = value; }
        }

        /// <summary>
        /// Get set property for DiscardDate
        /// </summary>
        public object DiscardDate
        {
            get { return _DiscardDate; }
            set { _DiscardDate = value; }
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
        /// Get set property for CurDepartmentID
        /// </summary>
        public int CurDepartmentID
        {
            get { return _CurDepartmentID; }
            set { _CurDepartmentID = value; }
        }

        /// <summary>
        /// Get set property for CurEmployeeID
        /// </summary>
        public int CurEmployeeID
        {
            get { return _CurEmployeeID; }
            set { _CurEmployeeID = value; }
        }

        /// <summary>
        /// Get set property for StoreID
        /// </summary>
        public int StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }

        /// <summary>
        /// Get set property for EntryDate
        /// </summary>
        public object EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
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
            int nMaxITAssetID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ITAssetID]) FROM t_ITAsset";
                cmd.CommandText = sSql;
                object maxITAssetID = cmd.ExecuteScalar();
                if (maxITAssetID == DBNull.Value)
                {
                    nMaxITAssetID = 1;
                }
                else
                {
                    nMaxITAssetID = int.Parse(maxITAssetID.ToString()) + 1;

                }

                _ITAssetID = nMaxITAssetID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ITAsset VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID);
                cmd.Parameters.AddWithValue("AssetNo", _AssetNo);
                cmd.Parameters.AddWithValue("EquipmentID", _EquipmentID);
                cmd.Parameters.AddWithValue("SerialNo", _SerialNo);
                cmd.Parameters.AddWithValue("SupplierID", _SupplierID);
                cmd.Parameters.AddWithValue("PurchaseDate", _PurchaseDate);
                cmd.Parameters.AddWithValue("DiscardDate", null);
                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
                cmd.Parameters.AddWithValue("CurDepartmentID", null);
                cmd.Parameters.AddWithValue("CurEmployeeID", null);
                cmd.Parameters.AddWithValue("StoreID", (short)Dictionary.ITEquipmentStock.MIS);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
               
                cmd = DBController.Instance.GetCommand();                
                cmd.CommandText = "update t_ITEquipmentType set MISStoreQty =MISStoreQty +1 where TypeID =?";           
                cmd.Parameters.AddWithValue("TypeID", _TypeID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

                InsertTran();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertTran()
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

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ITEquipmentTran VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nMaxTranID);
                cmd.Parameters.AddWithValue("TranDate", _PurchaseDate);
                cmd.Parameters.AddWithValue("TranType", (short)Dictionary.ITEquipmentTranType.Purchase);
                cmd.Parameters.AddWithValue("EquipmentTypeID", _TypeID); 
                cmd.Parameters.AddWithValue("EquipmentID", _EquipmentID);
                cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID); 
                cmd.Parameters.AddWithValue("EmployeeID", null);
                cmd.Parameters.AddWithValue("DepartmentID", null);
                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
                cmd.Parameters.AddWithValue("FromStoreID", (short)Dictionary.ITEquipmentSystemStock.System);
                cmd.Parameters.AddWithValue("ToStoreID", (short)Dictionary.ITEquipmentStock.MIS);
                cmd.Parameters.AddWithValue("Qty", 1);
                cmd.Parameters.AddWithValue("Remarks", null);

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

            try
            {
                cmd.CommandText = "update  t_ITAsset set AssetNo=?,SerialNo=?,SupplierID=?,PurchaseDate=?,CompanyID=?,Remarks=? where ITAssetID=?";
                cmd.CommandType = CommandType.Text;                
                cmd.Parameters.AddWithValue("AssetNo", _AssetNo);                
                cmd.Parameters.AddWithValue("SerialNo", _SerialNo);
                cmd.Parameters.AddWithValue("SupplierID", _SupplierID);
                cmd.Parameters.AddWithValue("PurchaseDate", _PurchaseDate);               
                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);               
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID);
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
                cmd.CommandText = "Delete from  t_ITEquipmentTran where ITAssetID=?";
                cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();           

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_ITAsset where ITAssetID=?";
                cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                UpdateStock();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (_StoreID == -1)
                return;           
       
            if (_StoreID == 0)
                sSql = "update  t_ITEquipmentType set MISStoreQty = MISStoreQty - 1 where  TypeID =?";
            if (_StoreID == 1)
                sSql = "update  t_ITEquipmentType set UserEndQty = UserEndQty - 1 where  TypeID =?";
            if (_StoreID == 2)
                sSql = "update  t_ITEquipmentType set DefectiveQty = DefectiveQty - 1 where  TypeID =?";
            if (_StoreID == 3)
                sSql = "update  t_ITEquipmentType set RepairQty = RepairQty - 1 where  TypeID =?";
            if (_StoreID == 4)
                sSql = "update  t_ITEquipmentType set LoanQty = LoanQty - 1 where  TypeID =?";
        

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
        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ITAsset where ITAssetID=?";
            cmd.Parameters.AddWithValue("ITAssetID", _ITAssetID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ITAssetID = int.Parse(reader["ITAssetID"].ToString());
                    _EquipmentID = int.Parse(reader["EquipmentID"].ToString());
                    _AssetNo = reader["AssetNo"].ToString();
                    _SerialNo = reader["SerialNo"].ToString();
                    _SupplierID = int.Parse(reader["SupplierID"].ToString());
                    _CompanyID = int.Parse(reader["CompanyID"].ToString());
                    _PurchaseDate = reader["PurchaseDate"].ToString();
                    _Remarks = reader["Remarks"].ToString();

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshByAssetNo(string sAssetNo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ITAsset where AssetNo=?";
            cmd.Parameters.AddWithValue("AssetNo", sAssetNo);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ITAssetID = int.Parse(reader["ITAssetID"].ToString());
                    _EquipmentID = int.Parse(reader["EquipmentID"].ToString());
                    _AssetNo = reader["AssetNo"].ToString();
                    _SerialNo = reader["SerialNo"].ToString();
                    _SupplierID = int.Parse(reader["SupplierID"].ToString());
                    _CompanyID = int.Parse(reader["CompanyID"].ToString());
                    _StoreID = int.Parse(reader["StoreID"].ToString());
                    _PurchaseDate = reader["PurchaseDate"].ToString();
                    _Remarks = reader["Remarks"].ToString();

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class ITAssets : CollectionBase
    {
        public ITAsset this[int i]
        {
            get { return (ITAsset)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ITAsset oITAsset)
        {
            InnerList.Add(oITAsset);
        }
        public void Refresh( string sAssetNo,string sSerialNo,string sModelNo, string sBrand,int nType,string sCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "select t1.*,t2.* from t_ITAsset as t1 inner join t_ITEquipment as t2 on t1.EquipmentID=t2.EquipmentID where StoreID in(0,1,2,3,4)";
            string sSql = "select t1.*,t2.*,t3.* from t_ITAsset as t1 inner join t_ITEquipment as t2 on t1.EquipmentID=t2.EquipmentID left join t_Employee as t3 on t1.CurEmployeeID=t3.EmployeeID where StoreID in(0,1,2,3,4)";
           
            if (sAssetNo != "")
            {
                sAssetNo = "%" + sAssetNo + "%";
                sSql = sSql + "and  AssetNo like '" + sAssetNo + "'";
            }     
            if (sSerialNo != "")
            {
                sSerialNo = "%" + sSerialNo + "%";
                sSql = sSql + "and  SerialNo like '" + sSerialNo + "'";
            }
            if (sModelNo != "")
            {
                sModelNo = "%" + sModelNo + "%";
                sSql = sSql + "and  ModelNo like '" + sModelNo + "'";
            }
            if (sBrand != "")
            {
                sBrand = "%" + sBrand + "%";
                sSql = sSql + "and  Brand like '" + sBrand + "'";
            }
            if (nType != -1)          
            {

                sSql = sSql + "and  TypeID = '" + nType + "'";
            }
            if (sCode != "")
            {
                sSql = sSql + " AND EmployeeCode LIKE '%" + sCode + "%' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITAsset _oITAsset = new ITAsset();

                    _oITAsset.ITAssetID = int.Parse(reader["ITAssetID"].ToString());                    
                    _oITAsset.EquipmentID = int.Parse(reader["EquipmentID"].ToString());
                    _oITAsset.AssetNo = reader["AssetNo"].ToString();
                    _oITAsset.SerialNo = reader["SerialNo"].ToString();
                    _oITAsset.SupplierID = int.Parse(reader["SupplierID"].ToString());

                   if(reader["CurEmployeeID"]!=DBNull.Value)
                    {
                        _oITAsset.CurEmployeeID = int.Parse(reader["CurEmployeeID"].ToString());
                    }
                    else
                    {
                        _oITAsset.CurEmployeeID = -1;
                    }


                    _oITAsset.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    _oITAsset.StoreID = int.Parse(reader["StoreID"].ToString());
                    _oITAsset.TypeID = int.Parse(reader["TypeID"].ToString());
                    _oITAsset.PurchaseDate = reader["PurchaseDate"].ToString();
                    if (reader["PurchaseDate"] != DBNull.Value)
                        _oITAsset.PDate = Convert.ToDateTime(reader["PurchaseDate"].ToString());
                    _oITAsset.Remarks = reader["Remarks"].ToString();

                    InnerList.Add(_oITAsset);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForBLL_TAB(string sAssetNo, string sSerialNo, string sModelNo, string sBrand, int nType, string sCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "select t1.*,t2.* from t_ITAsset as t1 inner join t_ITEquipment as t2 on t1.EquipmentID=t2.EquipmentID where StoreID in(0,1,2,3,4)";
            //string sSql = "select t1.*,t2.*,t3.* from t_ITAsset as t1 inner join t_ITEquipment as t2 on t1.EquipmentID=t2.EquipmentID left join t_Employee as t3 on t1.CurEmployeeID=t3.EmployeeID where StoreID in(0,1,2,3,4)";
            //string sSql = @"Select Final.*,List.Name from 
            //(  
            //Select assetlist.*, EmployeeID as CurEmployeeID from (  select aa.ITAssetID,aa.CompanyID, bb.EquipmentID, aa.AssetNo,bb.TypeID,aa.SupplierID,aa.Remarks, aa.SerialNo, bb.ModelNo, bb.Brand, aa.PurchaseDate, aa.StoreID 
            //from t_ITAsset aa , t_ITEquipment bb where aa.EquipmentID = bb.EquipmentID ) as assetlist left join t_ITEquipmentTran bb on assetlist.EquipmentID = bb.EquipmentID ) as Final 
            //left join  
            //( 
            //Select Code as CurEmployeeID, Name 
            //From (
            //Select CustomerCode as Code,concat(CustomerName,'-DB') as Name from v_CustomerDetails
            //union all  
            //Select DSRCode as Code, concat(DSRName,'-',Designation )as Name from t_DMSDSRDetails   
            //union all 
            //Select CONVERT(varchar, EmployeeCode) as Code,
            //Name=  concat(EmployeeName ,'-',DesignationName )
            //from [LINKSERVERTEL].telsysdb.dbo.t_employee a,[LINKSERVERTEL].telsysdb.dbo.t_designation b
            //where CompanyID = 82943 and a.designationID=b.designationID and a.DepartmentID in ( 82973, 82969, 82980, 82984 ,82992,83044,83045)
            //) as Userlist  
            //) as List on list.CurEmployeeID = Final.CurEmployeeID  where StoreID in(0,1,2,3,4) ";
            string sSql = @"
            select t1.*,t2.*,List.* 
            from t_ITAsset as t1 
            inner join t_ITEquipment as t2 on t1.EquipmentID=t2.EquipmentID 
            left outer join 
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

            ) as List on list.CurEmployeeID = T1.CurEmployeeID  where StoreID in(0,1,2,3,4) ";

            if (sAssetNo != "")
            {
                sAssetNo = "%" + sAssetNo + "%";
                sSql = sSql + "and  AssetNo like '" + sAssetNo + "'";
            }
            if (sSerialNo != "")
            {
                sSerialNo = "%" + sSerialNo + "%";
                sSql = sSql + "and  SerialNo like '" + sSerialNo + "'";
            }
            if (sModelNo != "")
            {
                sModelNo = "%" + sModelNo + "%";
                sSql = sSql + "and  ModelNo like '" + sModelNo + "'";
            }
            if (sBrand != "")
            {
                sBrand = "%" + sBrand + "%";
                sSql = sSql + "and  Brand like '" + sBrand + "'";
            }
            if (nType != -1)
            {

                sSql = sSql + "and  TypeID = '" + nType + "'";
            }
            if (sCode != "")
            {
                sSql = sSql + " AND t1.CurEmployeeID LIKE '%" + sCode + "%' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITAsset _oITAsset = new ITAsset();

                    _oITAsset.ITAssetID = int.Parse(reader["ITAssetID"].ToString());
                    _oITAsset.EquipmentID = int.Parse(reader["EquipmentID"].ToString());
                    _oITAsset.AssetNo = reader["AssetNo"].ToString();
                    _oITAsset.SerialNo = reader["SerialNo"].ToString();
                    _oITAsset.SupplierID = int.Parse(reader["SupplierID"].ToString());

                    if (reader["CurEmployeeID"] != DBNull.Value)
                    {
                        _oITAsset.CurEmployeeID = int.Parse(reader["CurEmployeeID"].ToString());
                    }
                    else
                    {
                        _oITAsset.CurEmployeeID = -1;
                    }

                    if (reader["Name"] != DBNull.Value)
                    {
                        _oITAsset.Employee.EmployeeName = (string)(reader["Name"].ToString());
                    }
                    else
                    {
                        _oITAsset.Employee.EmployeeName = "N/A";
                    }

                    _oITAsset.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    _oITAsset.StoreID = int.Parse(reader["StoreID"].ToString());
                    _oITAsset.TypeID = int.Parse(reader["TypeID"].ToString());
                    _oITAsset.PurchaseDate = reader["PurchaseDate"].ToString();
                    if (reader["PurchaseDate"] != DBNull.Value)
                        _oITAsset.PDate = Convert.ToDateTime(reader["PurchaseDate"].ToString());
                    _oITAsset.Remarks = reader["Remarks"].ToString();

                    InnerList.Add(_oITAsset);

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
