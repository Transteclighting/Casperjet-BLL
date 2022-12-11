// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Nov 2, 2011
// Time :  12:00 PM
// Description: Class for Vehicle User.
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

    public class Vehicle
    {

        private int _nVehicleID;
        private string _sVehicleCode;
        private string _sVehicleName;
        private string _sRegistrationNo;
        private int _nVehicleUserID;
        private DateTime _dPurchaseDate;
        private double _nCostPrice;	
        private string _sModel;	
        private object _sEngineNo;
        private object _sChasisNo;
        private object _dInsuranceExpiryDate;
        private object _dRoadTaxExpiryDate;
        private int _bIsActive;
        private int _nVehicleDriverID;
        private int _nFuelTypeID;
        private int _nMaxReading;
        private int _nDepartmentID;
        private int _nCompanyID;
        private string _sBU;
        private string _sDriverName;
        private string _sCapacity;
        private int _nVendorID;
        private string _sDriverMobileNo;


        public string DriverMobileNo
        {
            get { return _sDriverMobileNo; }
            set { _sDriverMobileNo = value; }

        }
        private string _sDepartment;
        public string Department
        {
            get { return _sDepartment; }
            set { _sDepartment = value; }

        }


        private string _sCompany;
        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value; }

        }
        public int VendorID
        {
            get { return _nVendorID; }
            set { _nVendorID = value; }

        }
        private int _nVendorType;
        public int VendorType
        {
            get { return _nVendorType; }
            set { _nVendorType = value; }

        }


        private int _nDeliveryMode;
        public int DeliveryMode
        {
            get { return _nDeliveryMode; }
            set { _nDeliveryMode = value; }

        }

        private string _sVendorName;

        public string VendorName
        {
            get { return _sVendorName; }
            set { _sVendorName = value; }

        }

        public int VehicleID
        {
            get { return _nVehicleID; }
            set { _nVehicleID = value; }

        }
        private int _nCapacityVehicleID;
        public int CapacityVehicleID
        {
            get { return _nCapacityVehicleID; }
            set { _nCapacityVehicleID = value; }

        }

        public string VehicleCode
        {
            get { return _sVehicleCode; }
            set { _sVehicleCode = value; }

        }

        public string VehicleName
        {
            get { return _sVehicleName; }
            set { _sVehicleName = value; }
        }

        public string RegistrationNo
        {
            get { return _sRegistrationNo; }
            set { _sRegistrationNo = value; }
        }

        public int VehicleUserID
        {
            get { return _nVehicleUserID; }
            set { _nVehicleUserID = value; }
        }

        public DateTime PurchaseDate
        {
            get { return _dPurchaseDate; }
            set { _dPurchaseDate = value; }
        }

        public double CostPrice
        {
            get { return _nCostPrice; }
            set { _nCostPrice = value; }
        }

        public string Model
        {
            get { return _sModel; }
            set { _sModel = value; }
        }

        public object EngineNo
        {
            get { return _sEngineNo; }
            set { _sEngineNo = value; }
        }

        public object ChasisNo
        {
            get { return _sChasisNo; }
            set { _sChasisNo = value; }
        }

        public object InsuranceExpiryDate
        {
            get { return _dInsuranceExpiryDate; }
            set { _dInsuranceExpiryDate = value; }
        }

        public object RoadTaxExpiryDate
        {
            get { return _dRoadTaxExpiryDate; }
            set { _dRoadTaxExpiryDate = value; }
        }

        public int IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }

        }

        public int VehicleDriverID
        {
            get { return _nVehicleDriverID; }
            set { _nVehicleDriverID = value; }

        }

        public int FuelTypeID
        {
            get { return _nFuelTypeID; }
            set { _nFuelTypeID = value; }

        }

        public int MaxReading
        {
            get { return _nMaxReading; }
            set { _nMaxReading = value; }

        }

        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }

        }

        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }

        }
        public string BU
        {
            get { return _sBU; }
            set { _sBU = value; }

        }

        public string DriverName
        {
            get { return _sDriverName; }
            set { _sDriverName = value; }

        }

        public string Capacity
        {
            get { return _sCapacity; }
            set { _sCapacity = value; }

        }


        public void Add()
        {
            int nMaxVehicleID = 0;
            int nMaxUserID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            string ssql1 = "";
            
            try
            {
                sSql = "SELECT MAX([VehicleID])FROM t_Vehicle";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVehicleID = 1;                   

                }
                else
                {
                    nMaxVehicleID = Convert.ToInt32(maxID) + 1;                    
                }
                _nVehicleID = nMaxVehicleID;

                             
                
                
                sSql = "INSERT INTO t_Vehicle VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                cmd.Parameters.AddWithValue("VehicleCode", _sVehicleCode);
                cmd.Parameters.AddWithValue("VehicleName", _sVehicleName);
                cmd.Parameters.AddWithValue("RegistrationNo", _sRegistrationNo);
                cmd.Parameters.AddWithValue("VehicleuserID", _nVehicleUserID);
                cmd.Parameters.AddWithValue("PurchaseDate", _dPurchaseDate);
                cmd.Parameters.AddWithValue("Costprice", _nCostPrice);
                cmd.Parameters.AddWithValue("Model", _sModel);
                cmd.Parameters.AddWithValue("EngineNo", _sEngineNo);
                cmd.Parameters.AddWithValue("ChasisNo", _sChasisNo);
                cmd.Parameters.AddWithValue("InsuranceExpiryDate", _dInsuranceExpiryDate);
                cmd.Parameters.AddWithValue("RoadtexExpiryDate", _dRoadTaxExpiryDate);                                                            
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("VehicleDriverID", _nVehicleDriverID);
                cmd.Parameters.AddWithValue("FuelTypeID", _nFuelTypeID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("BU", _sBU);
                cmd.Parameters.AddWithValue("DriverName", _sDriverName);
                cmd.Parameters.AddWithValue("Capacity", _sCapacity);
                cmd.Parameters.AddWithValue("VendorID", _nVendorID);

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

                sSql = "UPDATE t_Vehicle SET VehicleCode=?, VehicleName=?, RegistrationNo=?, VehicleuserID=?, PurchaseDate= ?, Costprice=?, Model=?, EngineNo=?,ChasisNo=?, "
                    + " InsuranceExpiryDate=?,RoadTaxExpiryDate=?, IsActive=?, VehicleDriverID= ?,FuelTypeID=?, DepartmentID=?, CompanyID=?, BU=?,DriverName=?, Capacity=?,VehicleVendorID=? "
                    + " WHERE VehicleID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VehicleCode", _sVehicleCode);
                cmd.Parameters.AddWithValue("VehicleName", _sVehicleName);
                cmd.Parameters.AddWithValue("RegistrationNo", _sRegistrationNo);
                cmd.Parameters.AddWithValue("VehicleuserID", _nVehicleUserID);
                cmd.Parameters.AddWithValue("PurchaseDate", _dPurchaseDate);
                cmd.Parameters.AddWithValue("Costprice", _nCostPrice);
                cmd.Parameters.AddWithValue("Model", _sModel);
                cmd.Parameters.AddWithValue("EngineNo", _sEngineNo);
                cmd.Parameters.AddWithValue("ChasisNo", _sChasisNo);
                cmd.Parameters.AddWithValue("InsuranceExpiryDate", _dInsuranceExpiryDate);
                cmd.Parameters.AddWithValue("RoadtexExpiryDate", _dRoadTaxExpiryDate);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("VehicleDriverID", _nVehicleDriverID);
                cmd.Parameters.AddWithValue("FuelTypeID", _nFuelTypeID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("BU", _sBU);
                cmd.Parameters.AddWithValue("DriverName", _sDriverName);
                cmd.Parameters.AddWithValue("Capacity", _sCapacity);
                cmd.Parameters.AddWithValue("VehicleVendorID", _nVendorID);

                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);

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
                sSql = "DELETE FROM t_Vehicle WHERE [VehicleID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
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
                cmd.CommandText = "SELECT * FROM t_Vehicle where VehicleID =?";
                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVehicleID = (int)reader["VehicleID"];
                    _sVehicleCode = (string)reader["VehicleCode"];
                    _sVehicleName = (string)reader["VehicleName"];
                    _sRegistrationNo = (string)reader["RegistrationNo"];
                    _nVehicleUserID = (int)reader["VehicleUserID"];
                    _dPurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]);
                    _nCostPrice =Convert.ToDouble(reader["CostPrice"]);
                    _sModel = (string)reader["Model"];
                    _sEngineNo = (string)reader["EngineNo"];
                    _sChasisNo = (string)reader["ChasisNo"];
                    _dInsuranceExpiryDate = Convert.ToDateTime(reader["InsuranceExpiryDate"]);

                    if (reader["RoadTaxExpiryDate"] != DBNull.Value)
                    {
                        _dRoadTaxExpiryDate = Convert.ToDateTime(reader["RoadTaxExpiryDate"]);

                    }
                    else _dRoadTaxExpiryDate = DateTime.Today.Date;
                    
                   
                    _bIsActive = (int)reader["IsActive"];


                    if (reader["VehicleDriverID"] != DBNull.Value)
                    {
                        _nVehicleDriverID = (int)reader["VehicleDriverID"];
                    }
                    else _nVehicleDriverID = 0;

                    if (reader["FuelTypeID"] != DBNull.Value)
                    {
                        _nFuelTypeID = (int)reader["FuelTypeID"];
                    }
                    else _nFuelTypeID = 0;


                    if (reader["DepartmentID"] != DBNull.Value)
                    {
                        _nDepartmentID = (int)reader["DepartmentID"];
                    }
                    else _nDepartmentID = 0;


                    if (reader["CompanyID"] != DBNull.Value)
                    {
                        _nCompanyID = (int)reader["CompanyID"];
                    }
                    else _nCompanyID = 0;

                    if (reader["BU"] != DBNull.Value)
                    {
                        _sBU = Convert.ToString (reader["BU"]);
                    }
                    else _sBU = "";

                    if (reader["DriverName"] != DBNull.Value)
                    {
                        _sDriverName = (string)reader["DriverName"];
                    }
                    else _sDriverName = "";

                    if (reader["Capacity"] != DBNull.Value)
                    {
                        _sCapacity = (string)reader["Capacity"];
                    }
                    else Capacity = "";                
                                      
                                                           
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshbyCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Vehicle where VehicleCode =?";
                cmd.Parameters.AddWithValue("VehicleCode", _sVehicleCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVehicleID = (int)reader["VehicleID"];
                    _sVehicleCode = (string)reader["VehicleCode"];
                    _sVehicleName = (string)reader["VehicleName"];
                    _sRegistrationNo = (string)reader["RegistrationNo"];
                    _sBU = (string)reader["BU"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshById(int nVechicleId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            //string sSql = "Select VehicleID,VehicleCode,VehicleName+' '+'['+RegistrationNo+']' as VehicleName, " +
            //           " ISNULL(a.VehicleDriverID, -1) VehicleDriverID, " +
            //           " ISNULL(DriverName, '') DriverName,ISNULL(MobileNo, '') MobileNo from t_Vehicle a " +
            //           " LEFT OUTER JOIN " +
            //           " t_VehicleDriver b ON a.VehicleDriverID = b.VehicleDriverID " +
            //           " Where IsActive = 1 AND VehicleID = "+ nVechicleId + " ";

            string sSql = @"Select VehicleID,VehicleCode,VehicleName+' '+'['+RegistrationNo+']' as VehicleName,  
                            ISNULL(a.VehicleDriverID, -1) VehicleDriverID,  ISNULL(b.VehicleDriverName, '') DriverName,
                            ISNULL(b.MobileNo, '') MobileNo from t_Vehicle a  
                            LEFT OUTER JOIN  t_VehicleDriver b ON a.VehicleDriverID = b.VehicleDriverID
                            Where IsActive = 1 AND VehicleID = {0} ";

            sSql = string.Format(sSql, nVechicleId);

            int nCount = 0;
            try
            {

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVehicleID = (int)reader["VehicleID"];
                    _sVehicleCode = (string)reader["VehicleCode"];
                    _sVehicleName = (string)reader["VehicleName"];
                    _sDriverName = (string)reader["DriverName"];
                    _nVehicleDriverID = (int)reader["VehicleDriverID"];
                    _sDriverMobileNo = (string)reader["MobileNo"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVendorByVendorID(int nVendorID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_LogDeliveryShipmentVendor where VendorID=" + nVendorID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle oVehicle = new Vehicle();

                    _nVendorID = (int)reader["VendorID"];
                    _sVendorName = (string)reader["VendorName"];
                    _nDeliveryMode = (int)reader["DeliveryMode"];
                    
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }


    public class Vehicles : CollectionBaseCustom
    {

        public Vehicle this[int i]
        {
            get { return (Vehicle)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Vehicle oVehicle)
        {
            InnerList.Add(oVehicle);
        }

        public int GetIndex(int nVehicleID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VehicleID == nVehicleID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetIndexVendor(int nVendorID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VendorID == nVendorID)
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
                    Vehicle oVehicle = new Vehicle();

                    oVehicle.VehicleID = (int)oRow["VehicleID"];
                    oVehicle.VehicleCode = (string)oRow["VehicleCode"];
                    oVehicle.VehicleName = (string)oRow["VehicleName"];
                    oVehicle.RegistrationNo = (string)oRow["RegistrationNo"];
                    oVehicle.PurchaseDate = (DateTime)oRow["PurchaseDate"];
                    oVehicle.CostPrice = (double)oRow["CostPrice"];
                    oVehicle.Model = (string)oRow["Model"];
                    oVehicle.EngineNo = oRow["EngineNo"];
                    oVehicle.ChasisNo = oRow["ChasisNo"];
                    oVehicle.InsuranceExpiryDate = oRow["InsuranceExpiryDate"];
                    oVehicle.RoadTaxExpiryDate = oRow["RoadTaxExpiryDate"];
                    oVehicle.IsActive = (int)(oRow["IsActive"]);
                    oVehicle.DepartmentID = (int)oRow["DepartmentID"];
                    oVehicle.CompanyID = (int)oRow["CompanyID"];

                    InnerList.Add(oVehicle);
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

            string sSql = "SELECT * FROM t_Vehicle where DepartmentID= 82972 ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle oVehicle = new Vehicle();

                    oVehicle.VehicleID = (int)reader["VehicleID"];
                    oVehicle.VehicleCode = (string)reader["VehicleCode"];
                    oVehicle.VehicleName = (string)reader["VehicleName"];
                    oVehicle.RegistrationNo = (string)reader["RegistrationNo"];
                    oVehicle.VehicleUserID = (int)reader["VehicleUserID"];
                    oVehicle.PurchaseDate = (DateTime)reader["PurchaseDate"];
                    oVehicle.CostPrice = (double)reader["CostPrice"];
                    oVehicle.Model = (string)reader["Model"];
                    oVehicle.EngineNo = reader["EngineNo"];
                    oVehicle.ChasisNo = reader["ChasisNo"];
                    oVehicle.InsuranceExpiryDate = reader["InsuranceExpiryDate"];
                    oVehicle.RoadTaxExpiryDate = reader["RoadTaxExpiryDate"];
                    oVehicle.IsActive = Convert.ToInt32(reader["IsActive"]);
                    //oVehicle.VehicleDriverID = (int)reader["VehicleDriverID"];
                    //oVehicle.FuelTypeID = (int)reader["FuelTypeID"];
                    //oVehicle.DepartmentID = (int)reader["DepartmentID"];
                    //oVehicle.CompanyID = (int)reader["CompanyID"];
                    //oVehicle.BU = (string)reader["BU"];
                    // oVehicle.DriverName = (string)reader["DriverName"];
                    //oVehicle.Capasity = (string)reader["Capasity"];

                    InnerList.Add(oVehicle);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshVehicleCapacity()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_VehicleCapacity";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle oVehicle = new Vehicle();

                    oVehicle.CapacityVehicleID = (int)reader["ID"];
                    oVehicle.Capacity = (string)reader["Description"];



                    InnerList.Add(oVehicle);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVehicle(int nDepartmentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT VehicleID,VehicleCode,VehicleName+' '+'['+RegistrationNo+']' as VehicleName FROM t_Vehicle where DepartmentID=" + nDepartmentID + " and IsActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle oVehicle = new Vehicle();

                    oVehicle.VehicleID = (int)reader["VehicleID"];
                    oVehicle.VehicleCode = (string)reader["VehicleCode"];
                    oVehicle.VehicleName = (string)reader["VehicleName"];

                    InnerList.Add(oVehicle);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVendorByDeliveryMode(int nVendorType, int nDeliveryMode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_LogDeliveryShipmentVendor where VendorType=" + nVendorType + "  and DeliveryMode=" + nDeliveryMode + " and IsActive=1 order by VendorName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle oVehicle = new Vehicle();

                    oVehicle.VendorID = (int)reader["VendorID"];
                    oVehicle.VendorName = (string)reader["VendorName"];

                    InnerList.Add(oVehicle);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        

        public void GetAllVendor()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_LogDeliveryShipmentVendor order by VendorName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle oVehicle = new Vehicle();

                    oVehicle.VendorID = (int)reader["VendorID"];
                    oVehicle.VendorName = (string)reader["VendorName"];
                    oVehicle.VendorType= (int)reader["VendorType"];
                    oVehicle.DeliveryMode = (int)reader["DeliveryMode"];
                    oVehicle.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oVehicle);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVehicle(int nDepartmentID,int nVendorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select VehicleID,VehicleCode,VehicleName+' '+'['+RegistrationNo+']' as VehicleName, "+
                        " ISNULL(a.VehicleDriverID, -1) VehicleDriverID, "+
                        " ISNULL(DriverName, '') DriverName,ISNULL(MobileNo, '') MobileNo from t_Vehicle a " +
                        " LEFT OUTER JOIN " +
                        " t_VehicleDriver b ON a.VehicleDriverID = b.VehicleDriverID " +
                        " Where DepartmentID = " + nDepartmentID + " and IsActive = 1 AND VehicleVendorID = " + nVendorID+" ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle oVehicle = new Vehicle();

                    oVehicle.VehicleID = (int)reader["VehicleID"];
                    oVehicle.VehicleCode = (string)reader["VehicleCode"];
                    oVehicle.VehicleName = (string)reader["VehicleName"];
                    oVehicle.DriverName = (string)reader["DriverName"];
                    oVehicle.VehicleDriverID=(int)reader["VehicleDriverID"];
                    oVehicle.DriverMobileNo = (string)reader["MobileNo"];

                    InnerList.Add(oVehicle);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(string code,string name,string registrationNo,int nCompany,int nDepartment,string sBU)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.*,isnull(CompanyCode,'') as Company,isnull(DepartmentName,'') as Department From (Select VehicleID,VehicleCode,VehicleName,RegistrationNo,VehicleUserID,PurchaseDate,  " +
                        "CostPrice,Model,IsActive,BU,  " +
                        "isnull(EngineNo,'') EngineNo,  " +
                        "isnull(ChasisNo, '') ChasisNo,  " +
                        "isnull(DriverName, '') DriverName,  " +
                        "isnull(Capacity, '') Capacity,  " +
                        "isnull(VehicleDriverID,-1) VehicleDriverID,  " +
                        "isnull(FuelTypeID, -1) FuelTypeID,  " +
                        "isnull(DepartmentID, -1) DepartmentID,  " +
                        "isnull(CompanyID, -1) CompanyID,  " +
                        "isnull(VehicleVendorID, -1) VehicleVendorID,  " +
                        "isnull(InsuranceExpiryDate,getdate()) InsuranceExpiryDate,  " +
                        "isnull(RoadTaxExpiryDate, getdate()) RoadTaxExpiryDate FROM t_Vehicle) a " +
                        "left outer join t_Company d on a.CompanyID = d.CompanyID " +
                        "left outer join t_Department e on a.DepartmentID = e.DepartmentID WHERE 1 =1 ";

            if (!string.IsNullOrEmpty(code))
            {
                sSql += " AND VehicleCode = '"+ code + "' ";
            }
            if (!string.IsNullOrEmpty(name))
            {
                sSql += " AND VehicleName LIKE '%"+ name + "%' ";
            }
            if (!string.IsNullOrEmpty(registrationNo))
            {
                   sSql += " AND RegistrationNo LIKE '%" + registrationNo + "%' ";
            }
            if (sBU != "<All>")
            {
                sSql += " AND BU LIKE '%" + sBU + "%' ";
            }
            if (nCompany != -1)
            {
                sSql += " AND a.CompanyID=" + nCompany + "";
            }
            if (nDepartment != -1)
            {
                sSql += " AND a.DepartmentID=" + nDepartment + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle oVehicle = new Vehicle();
                    oVehicle.VehicleID = (int)reader["VehicleID"];
                    oVehicle.VehicleCode = (string)reader["VehicleCode"];
                    oVehicle.VehicleName = (string)reader["VehicleName"];
                    oVehicle.RegistrationNo = (string)reader["RegistrationNo"];
                    oVehicle.VehicleUserID = (int)reader["VehicleUserID"];
                    oVehicle.PurchaseDate = (DateTime)reader["PurchaseDate"];
                    oVehicle.CostPrice = (double)reader["CostPrice"];
                    oVehicle.Model = (string)reader["Model"];
                    oVehicle.EngineNo = reader["EngineNo"];
                    oVehicle.ChasisNo = reader["ChasisNo"];
                    oVehicle.InsuranceExpiryDate = reader["InsuranceExpiryDate"];
                    oVehicle.RoadTaxExpiryDate = reader["RoadTaxExpiryDate"];
                    oVehicle.IsActive = Convert.ToInt32(reader["IsActive"]);
                    oVehicle.VehicleDriverID = (int)reader["VehicleDriverID"];
                    oVehicle.FuelTypeID = (int)reader["FuelTypeID"];
                    oVehicle.DepartmentID = (int)reader["DepartmentID"];
                    oVehicle.CompanyID = (int)reader["CompanyID"];
                    oVehicle.BU = (string)reader["BU"];
                    oVehicle.DriverName = (string)reader["DriverName"];
                    oVehicle.Capacity = (string)reader["Capacity"];
                    oVehicle.VendorID = (int)reader["VehicleVendorID"];

                    oVehicle.Company= (string)reader["Company"];
                    oVehicle.Department = (string)reader["Department"];
                    InnerList.Add(oVehicle);
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
