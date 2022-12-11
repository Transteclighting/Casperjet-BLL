// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Dec 07, 2011
// Time :  10:00 AM
// Description: Class for Fixed Asset.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.HR;

namespace CJ.Class.Admin
{
    public class FixedAsset
    {
        private int _nFAID;
        private string _sFANo;
        private int _nFATypeID;
        private string _sSerialNo;
        private string _sFADescription;
        private int _nLifeYear;
        private double _CostPrice;
        private double _DepreciateValue;
        private string _sGLAccHead;
        private int _nSupplierID;
        private DateTime _dPurchaseDate;
        private object _dDiscardDate;
        private int _nCompanyID;
        private int _nDepartmentID;
        private int _nEmployeeID;
        private int _nLocationID;
        private string _sRemarks;
        private FixedAssetType _oFixedAssetType;
        private Supplier _oSupplier;
        private Employee _oEmployee;
        private Company _oCompany;
        private Department _oDepartment;
        private JobLocation _oJobLocation;

        public FixedAssetType FixedAssetType
        {
            get
            {
                if (_oFixedAssetType == null)
                {
                    _oFixedAssetType = new FixedAssetType();
                    _oFixedAssetType.FATypeID = _nFATypeID;
                    _oFixedAssetType.Refresh();
                }
                return _oFixedAssetType;
            }
        }
        public Supplier Supplier
        {
            get
            {
                if (_oSupplier == null)
                {
                    _oSupplier = new Supplier();
                    _oSupplier.SupplierID = _nSupplierID;
                    _oSupplier.RefreshBySupplierID();
                }
                return _oSupplier;
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
        public JobLocation JobLocation
        {
            get
            {
                if (_oJobLocation == null)
                {
                    _oJobLocation = new JobLocation();
                    _oJobLocation.JobLocationID = _nLocationID;
                    _oJobLocation.Refresh();
                }

                return _oJobLocation;
            }
        }
        public Company Company
        {
            get
            {
                if (_oCompany == null)
                {
                    _oCompany = new Company();
                    _oCompany.CompanyID = _nCompanyID;
                    _oCompany.Refresh();
                }

                return _oCompany;
            }
        }
        public Department Department
        {
            get
            {
                if (_oDepartment == null)
                {
                    _oDepartment = new Department();
                    _oDepartment.DepartmentID = _nDepartmentID;
                    _oDepartment.Refresh();
                }

                return _oDepartment;
            }
        }


        /// <summary>
        /// Get set property for FAID
        /// </summary>
        public int FAID
        {
            get { return _nFAID; }
            set { _nFAID = value; }
        }

        /// <summary>
        /// Get set property for FANo
        /// </summary>
        public string FANo
        {
            get { return _sFANo; }
            set { _sFANo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for FATypeID
        /// </summary>
        public int FATypeID
        {
            get { return _nFATypeID; }
            set { _nFATypeID = value; }
        }

        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public string SerialNo
        {
            get { return _sSerialNo; }
            set { _sSerialNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for FADescription
        /// </summary>
        public string FADescription
        {
            get { return _sFADescription; }
            set { _sFADescription = value.Trim(); }
        }

        /// <summary>
        /// Get set property for LifeYear
        /// </summary>
        public int LifeYear
        {
            get { return _nLifeYear; }
            set { _nLifeYear = value; }
        }

        /// <summary>
        /// Get set property for CostPrice
        /// </summary>
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }

        /// <summary>
        /// Get set property for DepreciateValue
        /// </summary>
        public double DepreciateValue
        {
            get { return _DepreciateValue; }
            set { _DepreciateValue = value; }
        }

        /// <summary>
        /// Get set property for GLAccHead
        /// </summary>
        public string GLAccHead
        {
            get { return _sGLAccHead; }
            set { _sGLAccHead = value.Trim(); }
        }

        /// <summary>
        /// Get set property for SupplierID
        /// </summary>
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }

        /// <summary>
        /// Get set property for PurchaseDate
        /// </summary>
        public DateTime PurchaseDate
        {
            get { return _dPurchaseDate; }
            set { _dPurchaseDate = value; }
        }

        /// <summary>
        /// Get set property for DiscardDate
        /// </summary>
        public object DiscardDate
        {
            get { return _dDiscardDate; }
            set { _dDiscardDate = value; }
        }

        /// <summary>
        /// Get set property for CompanyID
        /// </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        /// <summary>
        /// Get set property for DepartmentID
        /// </summary>
        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        /// <summary>
        /// Get set property for LocationID
        /// </summary>
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxFAID = 0;
            int nMaxAssetNo = 0;
            string sAssetCode = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([FAID]) FROM t_FixedAsset";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFAID = 1;
                }
                else
                {
                    nMaxFAID = Convert.ToInt32(maxID) + 1;
                }
                _nFAID = nMaxFAID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                _oFixedAssetType = new FixedAssetType();
                _oFixedAssetType.FATypeID = _nFATypeID;
                _oFixedAssetType.Refresh();
                sAssetCode = "%" + _oFixedAssetType.FATypeCode + "%";

                sSql = "select max( convert(int, (right(FANo,4)),1)) as MaxAssetNo from t_FixedAsset where FANo like ? ";
                cmd.Parameters.AddWithValue("FANo", sAssetCode);

                cmd.CommandText = sSql;
                object MaxAssetNo = cmd.ExecuteScalar();
                if (MaxAssetNo == DBNull.Value)
                {
                    nMaxAssetNo = 1;
                }
                else
                {
                    nMaxAssetNo = int.Parse(MaxAssetNo.ToString())+1;

                }               

                _sFANo = _oFixedAssetType.FATypeCode + "-" + nMaxAssetNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_FixedAsset VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FAID", _nFAID);
                cmd.Parameters.AddWithValue("FANo", _sFANo);
                cmd.Parameters.AddWithValue("FATypeID", _nFATypeID);
                cmd.Parameters.AddWithValue("SerialNo", _sSerialNo);
                cmd.Parameters.AddWithValue("FADescription", _sFADescription);
                cmd.Parameters.AddWithValue("LifeYear", _nLifeYear);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("DepreciateValue", _DepreciateValue);
                cmd.Parameters.AddWithValue("GLAccHead", _sGLAccHead);

                if (_nSupplierID != -1)
                    cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                else cmd.Parameters.AddWithValue("SupplierID", null);

                cmd.Parameters.AddWithValue("PurchaseDate", _dPurchaseDate);
                cmd.Parameters.AddWithValue("DiscardDate", _dDiscardDate);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);

                if (_nDepartmentID != -1)
                    cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                else cmd.Parameters.AddWithValue("DepartmentID", null);

                if (_nEmployeeID != -1)
                    cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                else cmd.Parameters.AddWithValue("EmployeeID", null);
              
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
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
                sSql = "Update t_FixedAsset Set SerialNo=?,FADescription=?,LifeYear=?,CostPrice=?,DepreciateValue=?,GLAccHead=?,SupplierID=?,PurchaseDate=?,"
                       + " DiscardDate=?, CompanyID=?,DepartmentID=?,EmployeeID=?,LocationID=?,Remarks=? Where FAID =?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;              
               
                cmd.Parameters.AddWithValue("SerialNo", _sSerialNo);
                cmd.Parameters.AddWithValue("FADescription", _sFADescription);
                cmd.Parameters.AddWithValue("LifeYear", _nLifeYear);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("DepreciateValue", _DepreciateValue);
                cmd.Parameters.AddWithValue("GLAccHead", _sGLAccHead);

                if (_nSupplierID != -1)
                    cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                else cmd.Parameters.AddWithValue("SupplierID", null);

                cmd.Parameters.AddWithValue("PurchaseDate", _dPurchaseDate);
                cmd.Parameters.AddWithValue("DiscardDate", _dDiscardDate);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);

                if (_nDepartmentID != -1)
                    cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                else cmd.Parameters.AddWithValue("DepartmentID", null);

                if (_nEmployeeID != -1)
                    cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                else cmd.Parameters.AddWithValue("EmployeeID", null);

                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("FAID", _nFAID);

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
                sSql = "DELETE FROM t_FixedAsset WHERE [FAID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FAID", _nFAID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class FixedAssets : CollectionBase
    {
        public FixedAsset this[int i]
        {
            get { return (FixedAsset)InnerList[i]; }
            set { InnerList[i] = value; }
       }
        public void Add(FixedAsset oFixedAsset)
        {
            InnerList.Add(oFixedAsset);
        }
        public void Refresh(DateTime dtFromDate,DateTime dtToDate,string sFANo,string sSerial)
        {
            dtToDate=dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_FixedAsset WHERE PurchaseDate Between '" + dtFromDate + "' and '" + dtToDate + "' and PurchaseDate < '" + dtToDate + "'";
            if (sFANo != "")
            {
                sFANo = "%" + sFANo + "%";
                sSql = sSql + " and FANo Like '" + sFANo + "'";
            }
            if (sSerial != "")
            {
                sSerial = "%" + sSerial + "%";
                sSql = sSql + " and SerialNo Like '" + sSerial + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FixedAsset oFixedAsset = new FixedAsset();

                    oFixedAsset.FAID = (int)reader["FAID"];
                    oFixedAsset.FANo = reader["FANo"].ToString();
                    oFixedAsset.FATypeID = (int)reader["FATypeID"];
                    oFixedAsset.SerialNo = reader["SerialNo"].ToString();
                    oFixedAsset.FADescription = reader["FADescription"].ToString();
                    oFixedAsset.LifeYear = (int)reader["LifeYear"];
                    oFixedAsset.CostPrice = Convert.ToDouble(reader["CostPrice"]);
                    oFixedAsset.DepreciateValue = Convert.ToDouble(reader["DepreciateValue"]);
                    oFixedAsset.GLAccHead = reader["GLAccHead"].ToString();
                    if (reader["SupplierID"] != DBNull.Value)
                        oFixedAsset.SupplierID = (int)reader["SupplierID"];
                    else oFixedAsset.SupplierID = -1;
                    oFixedAsset.PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]);
                    if (reader["DiscardDate"] != DBNull.Value)
                        oFixedAsset.DiscardDate = Convert.ToDateTime(reader["DiscardDate"]);
                    else oFixedAsset.DiscardDate = null;
                    oFixedAsset.CompanyID = (int)reader["CompanyID"];
                    if (reader["DepartmentID"] != DBNull.Value)
                        oFixedAsset.DepartmentID = (int)reader["DepartmentID"];
                    else oFixedAsset.DepartmentID = -1;
                    if (reader["EmployeeID"] != DBNull.Value)
                        oFixedAsset.EmployeeID = (int)reader["EmployeeID"];
                    else oFixedAsset.EmployeeID = -1;
                    oFixedAsset.LocationID = (int)reader["LocationID"];
                    oFixedAsset.Remarks = reader["Remarks"].ToString();

                    InnerList.Add(oFixedAsset);
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
