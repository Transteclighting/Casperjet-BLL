// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak kumar Chakraborty
// Date: Jan 12, 2012
// Time :  11:00 AM
// Description: Class for Vehicle Operation
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class.Report
{
   public class RptVehicleOperationReportAdmin
    {

        private int _nDepartmentID;
        private string _sDepartmentName;
        private int _nCompanyID;
        private string _sCompanyName;
        private int _nvehicleOperationID;
        private int _nVehicleID;
        private string _sVehicleCode;
        private string _sVehicleName;
        private string _sRegistrationNo;
        private DateTime _dTranDate;
        private double _nKMRun;
        private string _sExpenseHeadName;
        private double _nQty;
        private double _nUnitPrice;
        private double _nAmount;
        private int _nPaymentType;
        private string _sRemarks;
        private double _nEndReading;
        private int _nTripC;
        private int _nTripS;
        private int _nTripU;
       private int _nExpenseHeadID;


        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }

        }

        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value; }

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

        public int vehicleOperationID
        {
            get { return _nvehicleOperationID; }
            set { _nvehicleOperationID = value; }

        }
        public int VehicleID
        {
            get { return _nVehicleID; }
            set { _nVehicleID = value; }

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
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }

        }
        public double KMRun
        {
            get { return _nKMRun; }
            set { _nKMRun = value; }
        }
        public string ExpenseHeadName
        {
            get { return _sExpenseHeadName; }
            set { _sExpenseHeadName = value; }
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
        public int PaymentType
        {
            get { return _nPaymentType; }
            set { _nPaymentType = value; }

        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public double EndReading
        {
            get { return _nEndReading; }
            set { _nEndReading = value; }
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
       public int ExpenseHeadID
       {
           get { return _nExpenseHeadID; }
           set { _nExpenseHeadID = value; }

       }

    }

    public class RptVehicleOperationReportAdminDetails : CollectionBaseCustom
    {
        public void Add(RptVehicleOperationReportAdmin oRptVehicleOperationReportAdmin)
        {
            this.List.Add(oRptVehicleOperationReportAdmin);
        }

        public RptVehicleOperationReportAdmin this[Int32 Index]
        {
            get
            {
                return (RptVehicleOperationReportAdmin)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptVehicleOperationReportAdmin))))
                {
                    throw new Exception(" Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void VehicleOperation(DateTime dYFromDate, DateTime dYToDate, int nCompanyID, int nDepartmentID, string sVehCode,int nExpenseHeadID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("  select final.DepartmentID, final.DepartmentName, final.CompanyID, final.CompanyName, final.vehicleOperationID, final.VehicleID,final.VehicleCode,final.VehicleName, final.RegistrationNo,final.TranDate,final.KMRun, ");
            sQueryStringMaster.Append("  final.ExpenseHeadID,final.ExpenseHeadName, final.Qty, final.UnitPrice, final.Amount, final.PaymentType, final.Remarks, final.EndReading, final.TripC,final.TripS,final.TripU ");
            sQueryStringMaster.Append("  from  ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select F2.DepartmentID, F2.DepartmentName, F2.CompanyID, F2.CompanyName, F1.vehicleOperationID, F1.VehicleID,F1.VehicleCode,F1.VehicleName, F1.RegistrationNo,F1.TranDate,F1.KMRun, ");
            sQueryStringMaster.Append(" F1.ExpenseHeadID,F1.ExpenseHeadName, F1.Qty, F1.UnitPrice, F1.Amount, F1.PaymentType, F1.Remarks, F1.EndReading, F1.TripC,F1.TripS,F1.TripU  ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select VOP.vehicleOperationID, VOP.VehicleID,VOP.VehicleCode,VOP.VehicleName, VOP.RegistrationNo,VOP.TranDate,VOP.KMRun, ");
            sQueryStringMaster.Append(" q2.ExpenseHeadID,q2.ExpenseHeadName, q2.Qty, q2.UnitPrice, q2.Amount, q2.PaymentType, q2.Remarks, VOP.EndReading, VOP.TripC,VOP.TripS,VOP.TripU  ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select a.vehicleOperationID, a.VehicleID, b.VehicleCode, b.VehicleName, b.RegistrationNo, a.TranDate,a.KMRun, ");
            sQueryStringMaster.Append(" Max(a.Endreading)as EndReading, sum(a.TripC)as TripC, sum(a.TripS)as TripS, sum(a.Tripu)as TripU  ");
            sQueryStringMaster.Append(" from t_vehicleOperationAdmin a, t_Vehicle b ");
            sQueryStringMaster.Append(" where TranDate between ? and ?  and TranDate < ? and a.VehicleID=b.VehicleID ");
            sQueryStringMaster.Append(" group by a.vehicleOperationID, a.VehicleID, b.VehicleCode, b.VehicleName,b.RegistrationNo, a.TranDate,a.KMRun ");
            sQueryStringMaster.Append(" ) as VOP  ");
            sQueryStringMaster.Append(" left outer join  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select a.vehicleOperationID, b.ExpenseHeadID, b.ExpenseHeadName,a.Qty,a.UnitPrice, a.Amount,a.PaymentType, a.Remarks ");
            sQueryStringMaster.Append(" from t_VehicleExpenseDetailsAdmin a, t_VehicleExpenseHead b ");
            sQueryStringMaster.Append(" where a.ExpenseHeadID=b.ExpenseHeadID  ");
            sQueryStringMaster.Append(" group by a.vehicleOperationID, b.ExpenseHeadID, b.ExpenseHeadName,a.Qty,a.UnitPrice, a.Amount,a.PaymentType, a.Remarks ");
            sQueryStringMaster.Append(" ) as q2 on VOP.vehicleOperationID=q2.vehicleOperationID ");
            sQueryStringMaster.Append(" group by VOP.vehicleOperationID, VOP.VehicleID,VOP.VehicleCode,VOP.VehicleName, VOP.RegistrationNo,VOP.TranDate,VOP.KMRun, ");
            sQueryStringMaster.Append(" q2.ExpenseHeadID,q2.ExpenseHeadName, q2.Qty, q2.UnitPrice, q2.Amount, q2.PaymentType, q2.Remarks, VOP.EndReading, VOP.TripC,VOP.TripS,VOP.TripU ");
            sQueryStringMaster.Append(" ) as F1	 ");
            sQueryStringMaster.Append(" left outer join  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select a.DepartmentID, a.DepartmentName, b.CompanyID, b.CompanyName, c.VehicleCode,c.VehicleID  ");
            sQueryStringMaster.Append(" from t_Department a, t_Company b, t_Vehicle c ");
            sQueryStringMaster.Append(" where a.departmentID=c.departmentID and b.CompanyID=c.CompanyID ");
            sQueryStringMaster.Append(" group by a.DepartmentID, a.DepartmentName, b.CompanyID, b.CompanyName, c.VehicleCode, c.VehicleID ");
            sQueryStringMaster.Append(" ) as F2 on F1.VehicleID=F2.VehicleID ");
            sQueryStringMaster.Append(" group by F2.DepartmentID, F2.DepartmentName, F2.CompanyID, F2.CompanyName, F2.VehicleCode, F1.vehicleOperationID, F1.VehicleID,F1.VehicleCode,F1.VehicleName, F1.RegistrationNo,F1.TranDate,F1.KMRun, ");
            sQueryStringMaster.Append(" F1.ExpenseHeadID,F1.ExpenseHeadName, F1.Qty, F1.UnitPrice, F1.Amount, F1.PaymentType, F1.Remarks, F1.EndReading, F1.TripC,F1.TripS,F1.TripU ");
            sQueryStringMaster.Append(" ) as final where ");

            if (nDepartmentID > 0)
            {
                sQueryStringMaster.Append("  DepartmentID= ?  and ");
            }
            if (nCompanyID > 0)
            {
                sQueryStringMaster.Append("  CompanyID= ? and ");
            }

            if (sVehCode != "")
            {
                sQueryStringMaster.Append(" VehicleCode= ? and ");
            }
            if (nExpenseHeadID >0)
            {
                sQueryStringMaster.Append(" ExpenseHeadID= ? and ");
            }

            sQueryStringMaster.Append(" PaymentType in (1,2) ");
            sQueryStringMaster.Append(" group by final.DepartmentID, final.DepartmentName, final.CompanyID, final.CompanyName, final.vehicleOperationID, final.VehicleID,final.VehicleCode,final.VehicleName, final.RegistrationNo,final.TranDate,final.KMRun, ");
            sQueryStringMaster.Append(" final.ExpenseHeadID,final.ExpenseHeadName, final.Qty, final.UnitPrice, final.Amount, final.PaymentType, final.Remarks, final.EndReading, final.TripC,final.TripS,final.TripU  ");
            sQueryStringMaster.Append(" order by final.CompanyName, final.DepartmentName, final.TranDate, final.VehicleCode,final.PaymentType ");

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);

            if (nDepartmentID > 0)
            {
                oCmd.Parameters.AddWithValue("DepartmentID", nDepartmentID);
            }
            if (nCompanyID > 0)
            {

                oCmd.Parameters.AddWithValue("CompanyID", nCompanyID);
            }

            if (sVehCode != "")
            {
                oCmd.Parameters.AddWithValue("VehCode", sVehCode.ToString());
            }
            if (nExpenseHeadID > 0)
            {
                oCmd.Parameters.AddWithValue("ExpenseHeadID", nExpenseHeadID);
            }
            GetVehicleOperation(oCmd);

        }
        public void GetVehicleOperation(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptVehicleOperationReportAdmin oItem = new RptVehicleOperationReportAdmin();

                    if (reader["DepartmentID"] != DBNull.Value)
                        oItem.DepartmentID = (int)reader["DepartmentID"];
                    else oItem.DepartmentID = -1;

                    if (reader["DepartmentName"] != DBNull.Value)
                        oItem.DepartmentName = (string)reader["DepartmentName"];
                    else oItem.DepartmentName = "";

                    if (reader["CompanyID"] != DBNull.Value)
                        oItem.CompanyID = (int)reader["CompanyID"];
                    else oItem.CompanyID = -1;

                    if (reader["CompanyName"] != DBNull.Value)
                        oItem.CompanyName = (string)reader["CompanyName"];
                    else oItem.CompanyName = "";

                    if (reader["vehicleOperationID"] != DBNull.Value)
                        oItem.vehicleOperationID = (int)reader["vehicleOperationID"];
                    else oItem.vehicleOperationID = -1;

                    if (reader["VehicleID"] != DBNull.Value)
                        oItem.VehicleID = (int)reader["VehicleID"];
                    else oItem.VehicleID = -1;

                    if (reader["VehicleCode"] != DBNull.Value)
                        oItem.VehicleCode = (string)reader["VehicleCode"];
                    else oItem.VehicleCode = "";

                    if (reader["VehicleName"] != DBNull.Value)
                        oItem.VehicleName = (string)reader["VehicleName"];
                    else oItem.VehicleName = "";

                    if (reader["RegistrationNo"] != DBNull.Value)
                        oItem.RegistrationNo = (string)reader["RegistrationNo"];
                    else oItem.RegistrationNo = "";

                    if (reader["TranDate"] != DBNull.Value)
                        oItem.TranDate = (DateTime)reader["TranDate"];
                    else oItem.TranDate = Convert.ToDateTime("01-Jan-1980");

                    if (reader["KMRun"] != DBNull.Value)
                        oItem.KMRun = Convert.ToDouble(reader["KMRun"]);
                    else oItem.KMRun = -1;

                    if (reader["ExpenseHeadName"] != DBNull.Value)
                        oItem.ExpenseHeadName = (string)reader["ExpenseHeadName"];
                    else oItem.ExpenseHeadName = "";

                    if (reader["Qty"] != DBNull.Value)
                        oItem.Qty = (double)reader["Qty"];
                    else oItem.Qty = -1;

                    if (reader["UnitPrice"] != DBNull.Value)
                        oItem.UnitPrice = (double)reader["UnitPrice"];
                    else oItem.UnitPrice = -1;

                    if (reader["Amount"] != DBNull.Value)
                        oItem.Amount = (double)reader["Amount"];
                    else oItem.Amount = -1;

                    if (reader["PaymentType"] != DBNull.Value)
                        oItem.PaymentType = (int)reader["PaymentType"];
                    else oItem.PaymentType = -1;

                    if (reader["Remarks"] != DBNull.Value)
                        oItem.Remarks = (string)reader["Remarks"];
                    else oItem.Remarks = "";

                    if (reader["EndReading"] != DBNull.Value)
                        oItem.EndReading = Convert.ToDouble(reader["EndReading"]);
                    else oItem.EndReading = -1;

                    if (reader["TripC"] != DBNull.Value)
                        oItem.TripC = (int)reader["TripC"];
                    else oItem.TripC = -1;

                    if (reader["TripS"] != DBNull.Value)
                        oItem.TripS = (int)reader["TripS"];
                    else oItem.TripS = -1;

                    if (reader["TripU"] != DBNull.Value)
                        oItem.TripU = (int)reader["TripU"];
                    else oItem.TripU = -1;

                    InnerList.Add(oItem);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void FromDataSetVehicleOperation(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptVehicleOperationReportAdmin oRptVehicleOperationReportAdmin = new RptVehicleOperationReportAdmin();

                    oRptVehicleOperationReportAdmin.DepartmentID = Convert.ToInt32(oRow["DepartmentID"]);
                    oRptVehicleOperationReportAdmin.DepartmentName = (string)oRow["DepartmentName"];
                    oRptVehicleOperationReportAdmin.CompanyID = Convert.ToInt32(oRow["CompanyID"]);
                    oRptVehicleOperationReportAdmin.CompanyName = (string)oRow["CompanyName"];
                    oRptVehicleOperationReportAdmin.vehicleOperationID = Convert.ToInt32(oRow["vehicleOperationID"]);
                    oRptVehicleOperationReportAdmin.VehicleID = Convert.ToInt32(oRow["VehicleID"]);
                    oRptVehicleOperationReportAdmin.VehicleName = (string)oRow["VehicleName"];
                    oRptVehicleOperationReportAdmin.RegistrationNo = (string)oRow["RegistrationNo"];
                    oRptVehicleOperationReportAdmin.TranDate = Convert.ToDateTime(oRow["TranDate"]);
                    oRptVehicleOperationReportAdmin.KMRun = Convert.ToDouble(oRow["KMRun"]);
                    oRptVehicleOperationReportAdmin.ExpenseHeadName = (string)oRow["ExpenseHeadName"];
                    oRptVehicleOperationReportAdmin.Qty = Convert.ToDouble(oRow["Qty"]);
                    oRptVehicleOperationReportAdmin.UnitPrice = Convert.ToDouble(oRow["UnitPrice"]);
                    oRptVehicleOperationReportAdmin.Amount = Convert.ToDouble(oRow["Amount"]);
                    oRptVehicleOperationReportAdmin.PaymentType = Convert.ToInt32(oRow["PaymentType"]);
                    oRptVehicleOperationReportAdmin.Remarks = (string)oRow["Remarks"];
                    oRptVehicleOperationReportAdmin.EndReading = Convert.ToDouble(oRow["EndReading"]);
                    oRptVehicleOperationReportAdmin.TripC = Convert.ToInt32(oRow["TripC"]);
                    oRptVehicleOperationReportAdmin.TripS = Convert.ToInt32(oRow["TripS"]);
                    oRptVehicleOperationReportAdmin.TripU = Convert.ToInt32(oRow["TripU"]);
                    InnerList.Add(oRptVehicleOperationReportAdmin);

                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }    
    
    }

}
