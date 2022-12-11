// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 04, 2012
// Time :  12:49 PM
// Description: Class for Loan Product From Cassandra.
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
    public class LoanProductCassandra
    {

        private int _nID;
        private int _nProductID;
        private int _nStatus;
        private string _sSerialNo;
        private string _sDamageWarehouseCode;
        private int _nPurposeType;
        private string _sJobCardNo;
        private int _nIsService;
        private string _sProductName;
       
        private bool _bFlag;
    
        private ReplaceJobFromCassandra _oReplaceJobFromCassandra;

        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public string SerialNo
        {
            get { return _sSerialNo; }
            set { _sSerialNo = value; }
        }
        /// <summary>
        /// Get set property for DamageWarehouseCode
        /// </summary>
        public string DamageWarehouseCode
        {
            get { return _sDamageWarehouseCode; }
            set { _sDamageWarehouseCode = value; }
        }
        /// <summary>
        /// Get set property for PurposeType
        /// </summary>
        public int PurposeType
        {
            get { return _nPurposeType; }
            set { _nPurposeType = value; }
        }
        /// <summary>
        /// Get set property for JobCardNo
        /// </summary>
        public string JobCardNo
        {
            get { return _sJobCardNo; }
            set { _sJobCardNo = value; }
        }
        /// <summary>
        /// Get set property for IsService
        /// </summary>
        public int IsService
        {
            get { return _nIsService; }
            set { _nIsService = value; }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }


        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public ReplaceJobFromCassandra ReplaceJobFromCassandra
        {
            get
            {
                if (_oReplaceJobFromCassandra == null)
                {
                    _oReplaceJobFromCassandra = new ReplaceJobFromCassandra();

                }
                return _oReplaceJobFromCassandra;
            }
        }

        public void RefreshByJobCardNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ID,DS.ProductID,P.Code ProductCode, P.Name ProductName, " +
                                    "SerialNo,DamageWareHouseCode WHCode,JobCardNo " +
                                    "from TELServiceDB.dbo.DamageStock DS " +
                                    "INNER JOIN TELServiceDB.dbo.Product P " +
                                    "oN P.ProductID=DS.ProductID " +
                                    "Where JobCardNo=? ";

                cmd.Parameters.AddWithValue("JobCardNo", _sJobCardNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nID = (int)reader["ID"];
                    //_oReplaceJobFromCassandra.ProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sSerialNo = (string)reader["SerialNo"];
                    _sJobCardNo = (string)reader["JobCardNo"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag=false;
        }
        public void RefreshByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * from TELServiceDB.dbo.DamageStock Where ID=? ";

                cmd.Parameters.AddWithValue("ID",_nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sSerialNo = (string)reader["SerialNo"];


                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        //public void RefreshByID()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    try
        //    {

        //        cmd.CommandText = "Select ID,Code,Name,Address,Phone,Mobile,ContactPerson, IsActives=Case " +
        //                          "When IsActive=1 THEN 'Active' " +
        //                          "ELSE 'InActive' END " +
        //                          "from TELServiceDB.dbo.InterService Where ID=?";

        //        cmd.Parameters.AddWithValue("ID", _nInterServiceID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {

        //            _nInterServiceID = (int)reader["ID"];
        //            _sCode = (string)reader["Code"];
        //            _sName = (string)reader["Name"];
        //            _sAddress = (string)reader["Address"];
        //            _sPhone = (string)reader["Phone"];
        //            _sMobile = (string)reader["Mobile"];
        //            _sContactPerson = (string)reader["ContactPerson"];
        //            _sIsActives = (string)reader["IsActives"];

        //            nCount++;
        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    if (nCount != 0)
        //        _bFlag = true;
        //    else _bFlag = false;
        //}

    }

    public class LoanProductCassandras : CollectionBase
        {
        public LoanProductCassandra this[int i]
            {
                get { return (LoanProductCassandra)InnerList[i]; }
                set { InnerList[i] = value; }
            }

        public void Add(LoanProductCassandra oLoanProductCassandra)
            {
                InnerList.Add(oLoanProductCassandra);
            }


        public void Refresh(String txtLoanProductNo, String txtProductCode, String txtProductName, String txtBarcodeSerial)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ID,DS.ProductID,P.Code ProductCode, P.Name ProductName, " +
                            "SerialNo,DamageWareHouseCode WHCode,JobCardNo " +
                            "from TELServiceDB.dbo.DamageStock DS " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "oN P.ProductID=DS.ProductID " +
                            "Where ID <> -1";

            if (txtLoanProductNo != "")
            {
                txtLoanProductNo = "%" + txtLoanProductNo + "%";
                sSql = sSql + " AND JobCardNo LIKE '" + txtLoanProductNo + "'";
            }
            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND P.Code LIKE '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND P.Name LIKE '" + txtProductName + "'";
            }
            if (txtBarcodeSerial != "")
            {
                txtBarcodeSerial = "%" + txtBarcodeSerial + "%";
                sSql = sSql + " AND SerialNo LIKE '" + txtBarcodeSerial + "'";
            }
          
            sSql = sSql + " order by ID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    LoanProductCassandra oLoanProductCassandra = new LoanProductCassandra();

                    oLoanProductCassandra.ID=(int)reader["ID"];
                    oLoanProductCassandra.JobCardNo = (string)reader["JobCardNo"];
                    oLoanProductCassandra.ReplaceJobFromCassandra.ProductCode = (string)reader["ProductCode"];
                    oLoanProductCassandra.ReplaceJobFromCassandra.ProductName = (string)reader["ProductName"];
                    oLoanProductCassandra.SerialNo = (string)reader["SerialNo"];

                    InnerList.Add(oLoanProductCassandra);
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


