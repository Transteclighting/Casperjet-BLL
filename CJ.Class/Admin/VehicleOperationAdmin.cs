// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Nov 14, 2013
// Time :  4:00 PM
// Description: Class for Vehicle Operation for Admin.
// Modify Person And Date:
// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;


namespace CJ.Class.Admin
{
    public class VehicleExpenseAdmin
    {
        private int _nVehicleOperationID;
        private int _nExpenseHeadID;
        private int _nPaymentType;
        private double _nQty;
        private double _nUnitPrice;
        private double _nAmount;
        private string _sRemarks;

        public int VehicleOperationID
        {
            get { return _nVehicleOperationID; }
            set { _nVehicleOperationID = value; }

        }
        public int ExpenseheadID
        {
            get { return _nExpenseHeadID; }
            set { _nExpenseHeadID = value; }

        }
        public int PaymentType
        {
            get { return _nPaymentType; }
            set { _nPaymentType = value; }
        }
        public double Qty
        {
            get { return _nQty; }
            set { _nQty = value; }

        }
        public double UnitPrice
        {
            get { return _nUnitPrice; }
            set { _nUnitPrice = value; }

        }
        public double Amount
        {
            get { return _nAmount; }
            set { _nAmount = value; }

        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }

        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "INSERT INTO t_vehicleExpenseDetailsAdmin VALUES(?,?,?,?,?,?,?)";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
            cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
            cmd.Parameters.AddWithValue("PaymentType", _nPaymentType);
            cmd.Parameters.AddWithValue("Qty", _nQty);
            cmd.Parameters.AddWithValue("UnitPrice", _nUnitPrice);
            cmd.Parameters.AddWithValue("Amount", _nAmount);
            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                VehicleOperation oItem = new VehicleOperation();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = " Delete from t_vehicleExpenseDetailsAdmin where VehicleOperationID= ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }

    public class VehicleOperationAdmin : CollectionBase
    {
        public VehicleExpenseAdmin this[int i]
        {
            get { return (VehicleExpenseAdmin)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(VehicleExpenseAdmin oVehicleExpenseAdmin)
        {
            InnerList.Add(oVehicleExpenseAdmin);
        }

        private int _nVehicleOperationID;
        private int _nVehicleID;
        private DateTime _dTrandate;
        private int _nActiveToday;
        private int _nTripC;
        private int _nTripS;
        private int _nTripU;
        private int _nEndReading;
        private int _nKMRun;
        private double _nInvoiceAmount;
        private int _nMaxReading;
        private Vehicle oVehicle;
        private string _sVehicleCode;
        public string VehicleCode
        {
            get { return _sVehicleCode; }
            set { _sVehicleCode = value; }
        }
        private string _sVehicleName;
        public string VehicleName
        {
            get { return _sVehicleName; }
            set { _sVehicleName = value; }
        }
        private string _sRegistrationNo;
        public string RegistrationNo
        {
            get { return _sRegistrationNo; }
            set { _sRegistrationNo = value; }
        }
        private string _sCompany;
        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value; }
        }
        private string _sBU;
        public string BU
        {
            get { return _sBU; }
            set { _sBU = value; }
        }
        public Vehicle Vehicle
        {
            get
            {
                if (oVehicle == null)
                {
                    oVehicle = new Vehicle();
                    oVehicle.VehicleID = _nVehicleID;
                    oVehicle.Refresh();
                }
                return oVehicle;
            }
        }

        public int VehicleOperationID
        {
            get { return _nVehicleOperationID; }
            set { _nVehicleOperationID = value; }

        }
        public int VehicleID
        {
            get { return _nVehicleID; }
            set { _nVehicleID = value; }

        }

        public DateTime Trandate
        {
            get { return _dTrandate; }
            set { _dTrandate = value; }

        }
        public int ActiveToday
        {
            get { return _nActiveToday; }
            set { _nActiveToday = value; }

        }
        public int TripC
        {
            get { return _nTripC; }
            set { _nTripC = value; }

        }
        public int TripS
        {
            get { return _nTripS; }
            set { _nTripS = value; }

        }
        public int TripU
        {
            get { return _nTripU; }
            set { _nTripU = value; }

        }
        public int EndReading
        {
            get { return _nEndReading; }
            set { _nEndReading = value; }

        }
        public int KMRun
        {
            get { return _nKMRun; }
            set { _nKMRun = value; }

        }
        public double InvoiceAmount
        {
            get { return _nInvoiceAmount; }
            set { _nInvoiceAmount = value; }
        }

        public int MaxReading
        {
            get { return _nMaxReading; }
            set { _nMaxReading = value; }

        }

        public void Add()
        {
            int nMaxOperationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([VehicleOperationID]) FROM t_VehicleOperationAdmin";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOperationID = 1;
                }
                else
                {
                    nMaxOperationID = Convert.ToInt32(maxID) + 1;
                }
                _nVehicleOperationID = nMaxOperationID;

                sSql = "INSERT INTO t_VehicleOperationAdmin VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                cmd.Parameters.AddWithValue("TranDate", _dTrandate);
                cmd.Parameters.AddWithValue("ActiveToday", _nActiveToday);
                cmd.Parameters.AddWithValue("TripC", _nTripC);
                cmd.Parameters.AddWithValue("TripS", _nTripS);
                cmd.Parameters.AddWithValue("TripU", _nTripU);
                cmd.Parameters.AddWithValue("EndReading", _nEndReading);
                cmd.Parameters.AddWithValue("KMRun", _nKMRun);
                cmd.Parameters.AddWithValue("InvoiceAmount", _nInvoiceAmount);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (VehicleExpenseAdmin oVehicleExpenseAdmin in this)
                {
                    oVehicleExpenseAdmin.VehicleOperationID = _nVehicleOperationID;
                    oVehicleExpenseAdmin.Insert();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_VehicleOperationAdmin SET VehicleID=?, TranDate=?, ActiveToday=?, TripC=?, TripS=?,TripU=?, EndReading=?,KMRun=?, InvoiceAmount=?  "
                    + " WHERE VehicleOperationID= ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                cmd.Parameters.AddWithValue("TranDate", _dTrandate);
                cmd.Parameters.AddWithValue("ActiveToday", _nActiveToday);
                cmd.Parameters.AddWithValue("TripC", _nTripC);
                cmd.Parameters.AddWithValue("TripS", _nTripS);
                cmd.Parameters.AddWithValue("TripU", _nTripU);
                cmd.Parameters.AddWithValue("EndReading", _nEndReading);
                cmd.Parameters.AddWithValue("KMRun", _nKMRun);
                cmd.Parameters.AddWithValue("InvoiceAmount", _nInvoiceAmount);
                cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //foreach (VehicleOperationDetail oVehicleOperationDetail in this)
                //{
                //    oVehicleOperationDetail.VehicleOperationID = _nVehicleOperationID;
                //    if (nCount == 0)
                //    {
                //        oVehicleOperationDetail.Delete();

                //    }
                //    nCount++;
                //    oVehicleOperationDetail.Insert();

                //}
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
                VehicleOperation oItem = new VehicleOperation();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = " Delete from t_VehicleOperationAdmin where VehicleOperationID= ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void DeleteAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                VehicleOperation oItem = new VehicleOperation();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = " Delete from  t_VehicleExpenseDetailsAdmin where vehicleOperationID=? Delete  from  t_VehicleOperationAdmin where vehicleOperationID=?  ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
                cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetMaxReading()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select Max(Endreading) as MaxReading from t_VehicleOperationAdmin where VehicleID= ? ";
                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nMaxReading = (int)reader["MaxReading"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                VehicleOperation oItem = new VehicleOperation();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = " select * from t_vehicleexpenseDetailsAdmin where VehicleOperationID= ?  select * from t_vehicleOperationAdmin where VehicleOperationID= ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
                cmd.Parameters.AddWithValue("VehicleOperationID", _nVehicleOperationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshbyOID(int nOperationID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_vehicleOperationAdmin WHERE VehicleOperationID=? ";
            cmd.Parameters.AddWithValue("VehicleOperationID", nOperationID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nVehicleOperationID = (int)reader["VehicleOperationID"];
                    _nVehicleID = (int)reader["VehicleID"];
                    _dTrandate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _nActiveToday = (int)reader["ActiveToday"];
                    _nTripC = (int)reader["TripC"];
                    _nTripS = (int)reader["TripS"];
                    _nTripU = (int)reader["TripU"];
                    _nEndReading = (int)reader["EndReading"];

                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


    }
    public class VehicleOperationsAdmin : CollectionBaseCustom
    {
        public VehicleOperationAdmin this[int i]
        {
            get { return (VehicleOperationAdmin)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(VehicleOperationAdmin oVehicleOperationAdmin)
        {
            InnerList.Add(oVehicleOperationAdmin);
        }

        public int GetIndex(int nVehicleOperationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VehicleOperationID == nVehicleOperationID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate,string sVehicleCode, string sCompany)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_VehicleOperationAdmin a " +
                        "left outer join  " +
                        "( " +
                        "Select VehicleID,VehicleCode,VehicleName,RegistrationNo,b.VehicleUserName,MaxFuelLimit,Designation,MaxMaintenanceLimit,PurchaseDate,CostPrice,Model,EngineNo, " +
                        "ChasisNo,InsuranceExpiryDate,RoadTaxExpiryDate,case when a.IsActive=1 then 'Active' else 'InActive' end as IsActive, " +
                        "c.VehicleDriverName,c.MobileNo as DriverMobileNo,CompanyCode as Company,DepartmentName as Department,BU,Capacity " +
                        "From t_Vehicle a " +
                        "left outer join t_VehicleUser b on a.VehicleUserID=b.VehicleUserID " +
                        "left outer join t_VehicleDriver c on a.VehicleDriverID=c.VehicleDriverID " +
                        "left outer join t_Company d on a.CompanyID=d.CompanyID " +
                        "left outer join t_Department e on a.DepartmentID=e.DepartmentID " +
                        ") b on a.VehicleID=b.VehicleID  WHERE TranDate between '" + dFromDate + "'AND '" + dToDate + "' ";
            if (sVehicleCode != "")
            {
                sSql = sSql + " and VehicleCode like '%" + sVehicleCode + "%'";
            }
            if (sCompany != "")
            {
                sSql = sSql + " and Company ='" + sCompany + "'";
            }
            sSql = sSql + " order by TranDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleOperationAdmin oVehicleOperationAdmin = new VehicleOperationAdmin();

                    oVehicleOperationAdmin.VehicleOperationID = (int)reader["VehicleOperationID"];
                    oVehicleOperationAdmin.VehicleID = (int)reader["VehicleID"];

                    if (reader["Trandate"] != DBNull.Value)
                        oVehicleOperationAdmin.Trandate = Convert.ToDateTime(reader["Trandate"]);
                    else oVehicleOperationAdmin.Trandate = Convert.ToDateTime(0);

                    oVehicleOperationAdmin.ActiveToday = (int)(reader["ActiveToday"]);

                    if (reader["TripC"] != DBNull.Value)
                        oVehicleOperationAdmin.TripC = (int)reader["TripC"];
                    else oVehicleOperationAdmin.TripC = 0;

                    if (reader["TripS"] != DBNull.Value)
                        oVehicleOperationAdmin.TripS = (int)reader["TripS"];
                    else oVehicleOperationAdmin.TripS = 0;

                    if (reader["TripU"] != DBNull.Value)
                        oVehicleOperationAdmin.TripU = (int)reader["TripU"];
                    else oVehicleOperationAdmin.TripU = 0;

                    oVehicleOperationAdmin.EndReading = (int)reader["EndReading"];
                    oVehicleOperationAdmin.KMRun = (int)reader["KMRun"];


                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oVehicleOperationAdmin.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else oVehicleOperationAdmin.InvoiceAmount = 0;



                    if (reader["VehicleCode"] != DBNull.Value)
                        oVehicleOperationAdmin.VehicleCode = (string)reader["VehicleCode"];
                    else oVehicleOperationAdmin.VehicleCode = "";

                    if (reader["VehicleName"] != DBNull.Value)
                        oVehicleOperationAdmin.VehicleName = (string)reader["VehicleName"];
                    else oVehicleOperationAdmin.VehicleName = "";

                    if (reader["RegistrationNo"] != DBNull.Value)
                        oVehicleOperationAdmin.RegistrationNo = (string)reader["RegistrationNo"];
                    else oVehicleOperationAdmin.RegistrationNo = "";

                    if (reader["BU"] != DBNull.Value)
                        oVehicleOperationAdmin.BU = (string)reader["BU"];
                    else oVehicleOperationAdmin.BU = "";

                    if (reader["Company"] != DBNull.Value)
                        oVehicleOperationAdmin.Company = (string)reader["Company"];
                    else oVehicleOperationAdmin.Company = "";


                    InnerList.Add(oVehicleOperationAdmin);
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