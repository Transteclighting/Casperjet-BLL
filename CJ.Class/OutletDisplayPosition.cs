// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Mar 24, 2016
// Time : 11:36 AM
// Description: Class for OutletDisplayPosition.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Class
{
    public class OutletDisplayPosition
    {
        private int _nDisplayPositionID;
        private string _sPositionCode;
        private string _sPositionName;
        private int _nMAGID;
        private int _nWHID;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private int _nProductID;
        private string _sProductSerialNo;
        private object _dAssignDate;
        private object _nAssignUserID;
        private object _dDay;
        private int _nCurrentStock;
        private string _sRackStatus;

        //private DateTime _dFillDate;
        //private int _nFillUserID;
        private int _nStatus;
        private int _nIsActive;

        private string _sShowroomCode;
        private string _sProductCode;
        private string _sProductName;
        private string _sPdtGroupName;
        private int _nHistoryID;
        private int _nType;
        private int _nIsDownload;


        public object AssignDate
        {
            get { return _dAssignDate; }
            set { _dAssignDate = value; }
        }
        public object AssignUserID
        {
            get { return _nAssignUserID; }
            set { _nAssignUserID = value; }
        }
        public string RackStatus
        {
            get { return _sRackStatus; }
            set { _sRackStatus = value; }
        }
        public object Day
        {
            get { return _dDay; }
            set { _dDay = value; }
        }
        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }

        // <summary>
        // Get set property for HistoryID
        // </summary>
        public int IsDownload
        {
            get { return _nIsDownload; }
            set { _nIsDownload = value; }
        }

        // <summary>
        // Get set property for HistoryID
        // </summary>
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
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
        // Get set property for ShowroomCode
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        // <summary>
        // Get set property for PdtGroupName
        // </summary>
        public string PdtGroupName
        {
            get { return _sPdtGroupName; }
            set { _sPdtGroupName = value.Trim(); }
        }




        // <summary>
        // Get set property for DisplayPositionID
        // </summary>
        public int DisplayPositionID
        {
            get { return _nDisplayPositionID; }
            set { _nDisplayPositionID = value; }
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
        // Get set property for MAGID
        // </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        // <summary>
        // Get set property for WHID
        // </summary>
        public int WHID
        {
            get { return _nWHID; }
            set { _nWHID = value; }
        }
        private int _nSort;

        public int Sort
        {
            get { return _nSort; }
            set { _nSort = value; }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        private int _nThanaID;
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }
        private string _sThanaName;
        public string ThanaName
        {
            get { return _sThanaName; }
            set { _sThanaName = value; }
        }
        private int _nDistrictID;
        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }
        private string _sDistrictName;
        public string DistrictName
        {
            get { return _sDistrictName; }
            set { _sDistrictName = value; }
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
        private string _sProductModel;
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value.Trim(); }
        }
        private string _sAGName;
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }
        private string _sMAGName;
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }
        private string _sPGName;
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }
        private string _sBrandDesc;
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductSerialNo
        // </summary>
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value.Trim(); }
        }

        //// <summary>
        //// Get set property for FillDate
        //// </summary>
        //public DateTime FillDate
        //{
        //    get { return _dFillDate; }
        //    set { _dFillDate = value; }
        //}

        //// <summary>
        //// Get set property for FillUserID
        //// </summary>
        //public int FillUserID
        //{
        //    get { return _nFillUserID; }
        //    set { _nFillUserID = value; }
        //}

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        private int _nAssignProductID;
        public int AssignProductID
        {
            get { return _nAssignProductID; }
            set { _nAssignProductID = value; }
        }
        private string _sAssignProductDetail;
        public string AssignProductDetail
        {
            get { return _sAssignProductDetail; }
            set { _sAssignProductDetail = value.Trim(); }
        }
        private string _sForProductDetail;
        public string ForProductDetail
        {
            get { return _sForProductDetail; }
            set { _sForProductDetail = value.Trim(); }
        }
        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        private string _sRackName;
        public string RackName
        {
            get { return _sRackName; }
            set { _sRackName = value.Trim(); }
        }

        private int _nRackID;
        public int RackID
        {
            get { return _nRackID; }
            set { _nRackID = value; }
        }

        private object _dSaleAfter;
        public object SaleAfter
        {
            get { return _dSaleAfter; }
            set { _dSaleAfter = value; }
        }
        private string _sBlankRemarks;
        public string BlankRemarks
        {
            get { return _sBlankRemarks; }
            set { _sBlankRemarks = value; }
        }

        private bool _bOpenForAll;
        public bool OpenForAll
        {
            get { return _bOpenForAll; }
            set { _bOpenForAll = value; }
        }
        public void Add()
        {
            int nMaxDisplayPositionID = 0;
            int nMaxOutletPositionID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                string sShortCode = "";
                DateTime dOperationDate;

                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.GetDisplayPositionID(_nWHID);
                if (oSystemInfo.PositionID == 0)
                {
                    nMaxOutletPositionID = 1;
                }
                else
                {
                    nMaxOutletPositionID = Convert.ToInt32(oSystemInfo.PositionID) + 1;
                }

                sSql = "SELECT MAX([DisplayPositionID]) FROM t_OutletDisplayPosition";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDisplayPositionID = 1;
                }
                else
                {
                    nMaxDisplayPositionID = Convert.ToInt32(maxID) + 1;
                }
                _nDisplayPositionID = nMaxDisplayPositionID;

                string sPositionCode = "";
                DateTime dToday = DateTime.Today;
                sPositionCode = "ODP-" + oSystemInfo.Shortcode + "-" + dToday.ToString("yy") + nMaxOutletPositionID.ToString("000");
                _sPositionCode = sPositionCode;


                sSql = "INSERT INTO t_OutletDisplayPosition (DisplayPositionID, PositionCode, PositionName, MAGID, WHID, CreateDate, CreateUserID, UpdateDate, UpdateUserID, ProductID, ProductSerialNo, Status, IsActive,RackID,SaleAfter,OpenForAll) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);
                cmd.Parameters.AddWithValue("PositionCode", _sPositionCode);
                cmd.Parameters.AddWithValue("PositionName", _sPositionName);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", null);
                //cmd.Parameters.AddWithValue("FillDate", null);
                //cmd.Parameters.AddWithValue("FillUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("RackID", _nRackID);
                cmd.Parameters.AddWithValue("SaleAfter", _dSaleAfter);
                cmd.Parameters.AddWithValue("OpenForAll", _bOpenForAll);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddRack()
        {
            int nMaxRackID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                
                sSql = "SELECT MAX([RackID]) FROM t_OutletDisplayPositionRack";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxRackID = 1;
                }
                else
                {
                    nMaxRackID = Convert.ToInt32(maxID) + 1;
                }
                _nRackID = nMaxRackID;


                sSql = "INSERT INTO t_OutletDisplayPositionRack (RackID, RackName, CreateDate, CreateUserID, UpdateDate, UpdateUserID, IsActive) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RackID", _nRackID);
                cmd.Parameters.AddWithValue("RackName", _sRackName);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddRackForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

            

                sSql = "INSERT INTO t_OutletDisplayPositionRack (RackID, RackName, CreateDate, CreateUserID, UpdateDate, UpdateUserID, IsActive, Sort) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RackID", _nRackID);
                cmd.Parameters.AddWithValue("RackName", _sRackName);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Sort", _nSort);

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
                sSql = "UPDATE t_OutletDisplayPosition SET  PositionName = ?, MAGID = ?, ProductID = ?, WHID = ?, UpdateDate = ?, UpdateUserID = ?, IsActive = ?,RackID = ?, SaleAfter=?, OpenForAll=? WHERE DisplayPositionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PositionName", _sPositionName);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("RackID", _nRackID);
                cmd.Parameters.AddWithValue("SaleAfter", _dSaleAfter);
                cmd.Parameters.AddWithValue("OpenForAll", _bOpenForAll);

                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditForExcel()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletDisplayPosition SET  PositionName = ?, MAGID = ?, ProductID = ?, WHID = ?, UpdateDate = ?, UpdateUserID = ?, IsActive = ?,RackID = ?, SaleAfter=?, OpenForAll=? WHERE DisplayPositionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PositionName", _sPositionName);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("RackID", _nRackID);
                cmd.Parameters.AddWithValue("SaleAfter", _dSaleAfter);
                cmd.Parameters.AddWithValue("OpenForAll", _bOpenForAll);
                //if (_sProductSerialNo == null)
                //{
                //    _sProductSerialNo = "NULL";
                //}

                //if (_sProductSerialNo.ToUpper() == "NULL")
                //{
                //    cmd.Parameters.AddWithValue("ProductSerialNo", null);
                //    cmd.Parameters.AddWithValue("Status", 0);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                //    cmd.Parameters.AddWithValue("Status", 1);
                //}

                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditRack()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletDisplayPositionRack SET  RackName = ?,UpdateDate = ?, UpdateUserID = ?, IsActive = ?,Sort = ? WHERE RackID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RackName", _sRackName);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Sort", _nSort);

                cmd.Parameters.AddWithValue("RackID", _nRackID);

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
                sSql = "DELETE FROM t_OutletDisplayPosition WHERE [DisplayPositionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);
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
                cmd.CommandText = "SELECT * FROM t_OutletDisplayPosition where DisplayPositionID =?";
                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDisplayPositionID = (int)reader["DisplayPositionID"];
                    _sPositionCode = (string)reader["PositionCode"];
                    _sPositionName = (string)reader["PositionName"];
                    _nMAGID = (int)reader["MAGID"];
                    _nWHID = (int)reader["WHID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nProductID = (int)reader["ProductID"];
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    //_dFillDate = Convert.ToDateTime(reader["FillDate"].ToString());
                    //_nFillUserID = (int)reader["FillUserID"];
                    _nStatus = (int)reader["Status"];
                    _nIsActive = (int)reader["IsActive"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPositionCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletDisplayPosition where PositionCode =? and WHID=?";
                cmd.Parameters.AddWithValue("PositionCode", _sPositionCode);
                cmd.Parameters.AddWithValue("WHID", _nWHID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDisplayPositionID = (int)reader["DisplayPositionID"];
                    _sPositionCode = (string)reader["PositionCode"];
                    _nWHID = (int)reader["WHID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshRackNew(string sRackName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletDisplayPositionRack where RackName='" + sRackName + "'";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nRackID = (int)reader["RackID"];
                    _sRackName = (string)reader["RackName"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletDisplayPosition SET  AssignProductID = ?, ProductSerialNo = ?, Status = ?,AssignDate = ?,AssignUserID = ?, BlankRemarks = ?, OpenForAll=? WHERE DisplayPositionID = ? and WHID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                if (_nAssignProductID != 0)
                {
                    cmd.Parameters.AddWithValue("AssignProductID", _nAssignProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AssignProductID", null);
                }

                if (_sProductSerialNo != "")
                {

                    cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductSerialNo", null);
                }

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AssignDate", _dAssignDate);
                cmd.Parameters.AddWithValue("AssignUserID", _nAssignUserID);
                cmd.Parameters.AddWithValue("BlankRemarks",_sBlankRemarks);
                cmd.Parameters.AddWithValue("OpenForAll", _bOpenForAll);

                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditForPOSNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletDisplayPosition SET  AssignProductID = ?, ProductSerialNo = ?, Status = ?,AssignDate = ?,AssignUserID = ?, BlankRemarks = ? WHERE DisplayPositionID = ? and WHID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                if (_nAssignProductID != 0)
                {
                    cmd.Parameters.AddWithValue("AssignProductID", _nAssignProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AssignProductID", null);
                }

                if (_sProductSerialNo != "")
                {

                    cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductSerialNo", null);
                }

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AssignDate", _dAssignDate);
                cmd.Parameters.AddWithValue("AssignUserID", _nAssignUserID);
                cmd.Parameters.AddWithValue("BlankRemarks", _sBlankRemarks);

                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditForPOSInvoice()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletDisplayPosition SET  AssignProductID = ?, ProductSerialNo = ?, Status = ? WHERE DisplayPositionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AssignProductID", null);
                cmd.Parameters.AddWithValue("ProductSerialNo", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddHistory()
        {
            int nMaxHistoryID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM t_OutletDisplayPositionHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nHistoryID = nMaxHistoryID;
                sSql = "INSERT INTO t_OutletDisplayPositionHistory (HistoryID, DisplayPositionID, Type, ProductSerialNo, CreateDate, CreateUserID,BlankRemarks) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_sProductSerialNo != "")
                {

                    cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductSerialNo", null);
                }
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("BlankRemarks", _sBlankRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddHistoryWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_OutletDisplayPositionHistory (HistoryID, DisplayPositionID, Type, ProductSerialNo, CreateDate, CreateUserID, BlankRemarks) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);
                cmd.Parameters.AddWithValue("Type", _nType);

                if (_sProductSerialNo != "")
                {

                    cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductSerialNo", null);
                }
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("BlankRemarks", _sBlankRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditHistory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletDisplayPositionHistory SET  DisplayPositionID = ?, Type = ?, ProductSerialNo = ? WHERE HistoryID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DisplayPositionID", _nDisplayPositionID);

                cmd.Parameters.AddWithValue("Type", _nType);
                if (_sProductSerialNo != "")
                {

                    cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductSerialNo", null);
                }
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckOutletDisplayPositionRack(int nRackID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From dbo.t_OutletDisplayPositionRack where RackID = ?";
                cmd.Parameters.AddWithValue("RackID", nRackID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }
    }
    public class OutletDisplayPositions : CollectionBase
    {
        public OutletDisplayPosition this[int i]
        {
            get { return (OutletDisplayPosition)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletDisplayPosition oOutletDisplayPosition)
        {
            InnerList.Add(oOutletDisplayPosition);
        }
        public int GetIndex(int nDisplayPositionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DisplayPositionID == nDisplayPositionID)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetIndexRack(int nRackID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].RackID == nRackID)
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
            string sSql = "SELECT * FROM t_OutletDisplayPosition";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.PositionCode = (string)reader["PositionCode"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.MAGID = (int)reader["MAGID"];
                    oOutletDisplayPosition.WHID = (int)reader["WHID"];
                    oOutletDisplayPosition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletDisplayPosition.CreateUserID = (int)reader["CreateUserID"];
                    oOutletDisplayPosition.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oOutletDisplayPosition.UpdateUserID = (int)reader["UpdateUserID"];
                    oOutletDisplayPosition.ProductID = (int)reader["ProductID"];
                    oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    //oOutletDisplayPosition.FillDate = Convert.ToDateTime(reader["FillDate"].ToString());
                    //oOutletDisplayPosition.FillUserID = (int)reader["FillUserID"];
                    oOutletDisplayPosition.Status = (int)reader["Status"];
                    oOutletDisplayPosition.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshRack()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletDisplayPositionRack where IsActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.RackID = (int)reader["RackID"];
                    oOutletDisplayPosition.RackName = (string)reader["RackName"];
                    oOutletDisplayPosition.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
                
        //  nASGID, nAGID, nArea, nTerritory, nDistrict, nThana, nOutlet, IsCheck
        public void RefreshDataHO(DateTime dFromDate, DateTime dToDate, string sPositionCode, string sPositionName, 
        string sProductModel, int nIsActive, int nStatus,int nBrandID,int nPGID,int nMAGID, int nASGID, int nAGID, int nArea, int nTerritoryID, int nDistrictID, int nThana, int nOutlet,int nProductID,  bool IsCheck,int nRackID, bool bOpenForAll)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "Select* From " +
                    "( " +
                    "Select a.*, isnull('[' + b.ProductCode + ']' + b.ProductName, '') as AssignProductDetail From " +
                    "( " +
                    "Select ShowroomCode, Areaid, AreaName, TerritoryID, TerritoryName, d.ThanaID, " +
                    "ThanaName, DistrictID, DistrictName, DisplayPositionID, PositionCode, " +
                    "PositionName, b.MAGID, WHID, a.CreateDate, a.CreateUserID, a.ProductID, " +
                    "ProductCode, ProductName, isnull(ProductModel, '') ProductModel, " +
                    "AGID, AGName, ASGID, ASGName, MAGName, PGID, PGName, BrandID, BrandDesc, " +
                    "isnull(ProductSerialNo, '') ProductSerialNo, a.Status, a.IsActive, " +
                    "isnull(AssignProductID, -1) AssignProductID, a.RackID, RackName, a.SaleAfter, OpenForAll " +
                    "From t_OutletDisplayPosition a, v_ProductDetails b, " +
                    "t_Showroom c, v_CustomerDetails d, t_OutletDisplayPositionRack e " +
                    "where a.ProductID = b.ProductID and a.WHID = c.WarehouseID " +
                    "and c.CustomerID = d.CustomerID and a.RackID = e.RackID " +
                    ") a " +
                    "Left Outer Join " +
                    "( " +
                    "Select ProductID, ProductCode, ProductName From t_Product " +
                    ") b on a.AssignProductID = b.ProductID " +
                    ") Main where 1 = 1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }
            if (sPositionCode != "")
            {
                sSql = sSql + " AND PositionCode like '%" + sPositionCode + "%'";
            }
            if (sPositionName != "")
            {
                sSql = sSql + " AND PositionName like '%" + sPositionName + "%'";
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sProductModel != "")
            {
                sSql = sSql + " AND ProductModel like '%" + sProductModel + "%'";
            }
            if (nProductID != -1)
            {
                sSql = sSql + " AND ProductID=" + nProductID + "";
            }
            if (nArea != -1)
            {
                sSql = sSql + " AND AreaID=" + nArea + "";
            }
            if (nDistrictID != -1)
            {
                sSql = sSql + " AND DistrictID=" + nDistrictID + "";
            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " AND TerritoryID=" + nTerritoryID + "";
            }
            if (nThana != -1)
            {
                sSql = sSql + " AND ThanaID=" + nThana + "";
            }
            if (nOutlet != -1)
            {
                sSql = sSql + " AND WHID=" + nOutlet + "";
            }

            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }

            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }

            if (nRackID != -1)
            {
                sSql = sSql + " AND RackID=" + nRackID + "";
            }

            if(bOpenForAll)
            {
                sSql = sSql + " AND OpenForAll='" + bOpenForAll + "'";
            }

            sSql = sSql + " Order by DisplayPositionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.PositionCode = (string)reader["PositionCode"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.WHID = (int)reader["WHID"];
                    oOutletDisplayPosition.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletDisplayPosition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletDisplayPosition.CreateUserID = (int)reader["CreateUserID"];
                    oOutletDisplayPosition.ProductID = (int)reader["ProductID"];
                    oOutletDisplayPosition.ProductCode = (string)reader["ProductCode"];
                    oOutletDisplayPosition.ProductName = (string)reader["ProductName"];
                    oOutletDisplayPosition.ProductModel = (string)reader["ProductModel"];
                    oOutletDisplayPosition.MAGName = (string)reader["MAGName"];
                    oOutletDisplayPosition.PGName = (string)reader["PGName"];
                    oOutletDisplayPosition.BrandDesc = (string)reader["BrandDesc"];
                    oOutletDisplayPosition.ASGName = (string)reader["ASGName"];
                    oOutletDisplayPosition.AGName = (string)reader["AGName"];
                    oOutletDisplayPosition.AreaName = (string)reader["AreaName"];
                    oOutletDisplayPosition.DistrictName = (string)reader["DistrictName"];
                    oOutletDisplayPosition.TerritoryName = (string)reader["TerritoryName"];
                    oOutletDisplayPosition.ThanaName = (string)reader["ThanaName"];
                    oOutletDisplayPosition.MAGID = (int)reader["MAGID"];
                    oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oOutletDisplayPosition.Status = (int)reader["Status"];
                    oOutletDisplayPosition.IsActive = (int)reader["IsActive"];
                    oOutletDisplayPosition.RackID = (int)reader["RackID"];
                    oOutletDisplayPosition.RackName = (string)reader["RackName"];
                    oOutletDisplayPosition.AssignProductID = (int)reader["AssignProductID"];
                    oOutletDisplayPosition.AssignProductDetail = (string)reader["AssignProductDetail"];
                    if (reader["SaleAfter"] != DBNull.Value)
                    {
                        oOutletDisplayPosition.SaleAfter = (DateTime)reader["SaleAfter"];
                    }
                    else
                    {
                        oOutletDisplayPosition.SaleAfter = null;
                    }
                    oOutletDisplayPosition.OpenForAll = Convert.ToBoolean(reader["OpenForAll"]);

                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshDataPOS(DateTime dFromDate, DateTime dToDate, string sPositionCode, string sPositionName, int nMAG, int nIsActive, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select * From (Select DisplayPositionID,PositionCode,PositionName,WHID,ShowroomCode,CreateDate, " +
                       " CreateUserID,isnull(a.ProductID,0) ProductID,isnull(ProductCode,'') ProductCode,  " +
                       " isnull(ProductName,'') ProductName,a.MAGID,PdtGroupName,isnull (ProductSerialNo,'') ProductSerialNo, " +
                       " Status,a.IsActive From  " +
                       " (Select a.*,PdtGroupName,ShowroomCode From t_OutletDisplayPosition a,t_ProductGroup b,t_Showroom c " +
                       " where a.MAGID=b.PdtGroupID and a.WHID=c.WarehouseID) a " +
                       " Left Outer Join " +
                       " (Select * From v_ProductDetails) b on a.ProductID=b.ProductID) Main where 1=1 ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (sPositionCode != "")
            {
                sSql = sSql + " AND PositionCode like '%" + sPositionCode + "%'";
            }
            if (sPositionName != "")
            {
                sSql = sSql + " AND PositionName like '%" + sPositionName + "%'";
            }
            if (nMAG != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAG + "";
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            sSql = sSql + " Order by DisplayPositionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.PositionCode = (string)reader["PositionCode"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.WHID = (int)reader["WHID"];
                    oOutletDisplayPosition.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletDisplayPosition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletDisplayPosition.CreateUserID = (int)reader["CreateUserID"];
                    oOutletDisplayPosition.ProductID = (int)reader["ProductID"];
                    oOutletDisplayPosition.ProductCode = (string)reader["ProductCode"];
                    oOutletDisplayPosition.ProductName = (string)reader["ProductName"];
                    oOutletDisplayPosition.MAGID = (int)reader["MAGID"];
                    oOutletDisplayPosition.PdtGroupName = (string)reader["PdtGroupName"];
                    oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    //oOutletDisplayPosition.FillDate = Convert.ToDateTime(reader["FillDate"].ToString());
                    oOutletDisplayPosition.Status = (int)reader["Status"];
                    oOutletDisplayPosition.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshDataPOSNew(DateTime dFromDate, DateTime dToDate, string sPositionCode, string sPositionName,
        string sProductModel, int nIsActive, int nStatus, int nBrandID, int nPGID, int nMAGID, int nASGID, int nAGID, string sForProduct,string sAssignProduct, bool IsCheck,int nRackID, bool bOpenForAll)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "Select* From " +
                    "( " +
                    "Select a.*, isnull('[' + a.ProductCode + ']' + a.ProductName, '') as ForProductDetail, isnull('[' + b.ProductCode + ']' + b.ProductName, '') as AssignProductDetail From " +
                    "( " +
                    "Select ShowroomCode, Areaid, AreaName, TerritoryID, TerritoryName, d.ThanaID, " +
                    "ThanaName, DistrictID, DistrictName, DisplayPositionID, PositionCode, " +
                    "PositionName, b.MAGID, WHID, a.CreateDate, a.CreateUserID, a.ProductID, " +
                    "ProductCode, ProductName, isnull(ProductModel, '') ProductModel, " +
                    "AGID, AGName, ASGID, ASGName, MAGName, PGID, PGName, BrandID, BrandDesc, " +
                    "isnull(ProductSerialNo, '') ProductSerialNo, a.Status, a.IsActive, " +
                    "isnull(AssignProductID, -1) AssignProductID, a.RackID, RackName, SaleAfter, BlankRemarks,OpenForAll " +
                    "From t_OutletDisplayPosition a, v_ProductDetails b, " +
                    "t_Showroom c, v_CustomerDetails d, t_OutletDisplayPositionRack e " +
                    "where a.ProductID = b.ProductID and a.WHID = c.WarehouseID " +
                    "and c.CustomerID = d.CustomerID and a.RackID = e.RackID " +
                    ") a " +
                    "Left Outer Join " +
                    "( " +
                    "Select ProductID, ProductCode, ProductName From t_Product " +
                    ") b on a.AssignProductID = b.ProductID " +
                    ") Main where 1 = 1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }
            if (sPositionCode != "")
            {
                sSql = sSql + " AND PositionCode like '%" + sPositionCode + "%'";
            }
            if (sPositionName != "")
            {
                sSql = sSql + " AND PositionName like '%" + sPositionName + "%'";
            }
            //if (nIsActive != -1)
            //{
            //    sSql = sSql + " AND IsActive=" + nIsActive + "";
            //}
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sProductModel != "")
            {
                sSql = sSql + " AND ProductModel like '%" + sProductModel + "%'";
            }
            if (sForProduct != "")
            {
                sSql = sSql + " AND ForProductDetail like '%" + sForProduct + "%'";
            }
            if (sAssignProduct != "")
            {
                sSql = sSql + " AND AssignProductDetail like '%" + sAssignProduct + "%'";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }

            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }
            if (nRackID != -1)
            {
                sSql = sSql + " AND RackID=" + nRackID + "";
            }
            if(bOpenForAll)
            {
                sSql = sSql + " AND OpenForAll='" + bOpenForAll + "'";
            }
            sSql = sSql + " and IsActive=1 Order by DisplayPositionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.PositionCode = (string)reader["PositionCode"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.WHID = (int)reader["WHID"];
                    oOutletDisplayPosition.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletDisplayPosition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletDisplayPosition.CreateUserID = (int)reader["CreateUserID"];
                    oOutletDisplayPosition.ProductID = (int)reader["ProductID"];
                    oOutletDisplayPosition.ProductCode = (string)reader["ProductCode"];
                    oOutletDisplayPosition.ProductName = (string)reader["ProductName"];
                    oOutletDisplayPosition.ProductModel = (string)reader["ProductModel"];
                    oOutletDisplayPosition.MAGName = (string)reader["MAGName"];
                    oOutletDisplayPosition.PGName = (string)reader["PGName"];
                    oOutletDisplayPosition.BrandDesc = (string)reader["BrandDesc"];
                    oOutletDisplayPosition.ASGName = (string)reader["ASGName"];
                    oOutletDisplayPosition.AGName = (string)reader["AGName"];
                    oOutletDisplayPosition.AreaName = (string)reader["AreaName"];
                    oOutletDisplayPosition.DistrictName = (string)reader["DistrictName"];
                    oOutletDisplayPosition.TerritoryName = (string)reader["TerritoryName"];
                    oOutletDisplayPosition.ThanaName = (string)reader["ThanaName"];
                    oOutletDisplayPosition.MAGID = (int)reader["MAGID"];
                    oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oOutletDisplayPosition.Status = (int)reader["Status"];
                    oOutletDisplayPosition.IsActive = (int)reader["IsActive"];
                    oOutletDisplayPosition.RackID = (int)reader["RackID"];
                    oOutletDisplayPosition.RackName = (string)reader["RackName"];
                    oOutletDisplayPosition.AssignProductID = (int)reader["AssignProductID"];
                    oOutletDisplayPosition.AssignProductDetail = (string)reader["AssignProductDetail"];
                    oOutletDisplayPosition.ForProductDetail = (string)reader["ForProductDetail"];
                    if (reader["SaleAfter"] != DBNull.Value)
                    {
                        oOutletDisplayPosition.SaleAfter = (DateTime)reader["SaleAfter"];
                    }
                    else
                    {
                        oOutletDisplayPosition.SaleAfter = null;
                    }
                    if (reader["BlankRemarks"] != DBNull.Value)
                    {
                        oOutletDisplayPosition.BlankRemarks = reader["BlankRemarks"].ToString();
                    }
                    else
                    {
                        oOutletDisplayPosition.BlankRemarks = "";
                    }

                    oOutletDisplayPosition.OpenForAll= Convert.ToBoolean(reader["OpenForAll"]);
                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void RefreshDataPOSRT(DateTime dFromDate, DateTime dToDate, string sPositionCode, string sPositionName,
        string sProductModel, int nIsActive, int nStatus, int nBrandID, int nPGID, int nMAGID, int nASGID, int nAGID, string sForProduct, string sAssignProduct, bool IsCheck, int nRackID, bool bOpenForAll)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "Select* From " +
                    "( " +
                    "Select a.*, isnull('[' + a.ProductCode + ']' + a.ProductName, '') as ForProductDetail, isnull('[' + b.ProductCode + ']' + b.ProductName, '') as AssignProductDetail From " +
                    "( " +
                    "Select ShowroomCode, Areaid, AreaName, TerritoryID, TerritoryName, d.ThanaID, " +
                    "ThanaName, DistrictID, DistrictName, DisplayPositionID, PositionCode, " +
                    "PositionName, b.MAGID, WHID, a.CreateDate, a.CreateUserID, a.ProductID, " +
                    "ProductCode, ProductName, isnull(ProductModel, '') ProductModel, " +
                    "AGID, AGName, ASGID, ASGName, MAGName, PGID, PGName, BrandID, BrandDesc, " +
                    "isnull(ProductSerialNo, '') ProductSerialNo, a.Status, a.IsActive, " +
                    "isnull(AssignProductID, -1) AssignProductID, a.RackID, RackName, SaleAfter, BlankRemarks,OpenForAll " +
                    "From t_OutletDisplayPosition a, v_ProductDetails b, " +
                    "t_Showroom c, v_CustomerDetails d, t_OutletDisplayPositionRack e " +
                    "where a.ProductID = b.ProductID and a.WHID = c.WarehouseID " +
                    "and c.CustomerID = d.CustomerID and a.RackID = e.RackID and a.WHID=" + Utility.WarehouseID + " " +
                    ") a " +
                    "Left Outer Join " +
                    "( " +
                    "Select ProductID, ProductCode, ProductName From t_Product " +
                    ") b on a.AssignProductID = b.ProductID " +
                    ") Main where 1 = 1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }
            if (sPositionCode != "")
            {
                sSql = sSql + " AND PositionCode like '%" + sPositionCode + "%'";
            }
            if (sPositionName != "")
            {
                sSql = sSql + " AND PositionName like '%" + sPositionName + "%'";
            }
            //if (nIsActive != -1)
            //{
            //    sSql = sSql + " AND IsActive=" + nIsActive + "";
            //}
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sProductModel != "")
            {
                sSql = sSql + " AND ProductModel like '%" + sProductModel + "%'";
            }
            if (sForProduct != "")
            {
                sSql = sSql + " AND ForProductDetail like '%" + sForProduct + "%'";
            }
            if (sAssignProduct != "")
            {
                sSql = sSql + " AND AssignProductDetail like '%" + sAssignProduct + "%'";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }

            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }
            if (nRackID != -1)
            {
                sSql = sSql + " AND RackID=" + nRackID + "";
            }
            if (bOpenForAll)
            {
                sSql = sSql + " AND OpenForAll='" + bOpenForAll + "'";
            }
            sSql = sSql + " and IsActive=1 Order by DisplayPositionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.PositionCode = (string)reader["PositionCode"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.WHID = (int)reader["WHID"];
                    oOutletDisplayPosition.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletDisplayPosition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletDisplayPosition.CreateUserID = (int)reader["CreateUserID"];
                    oOutletDisplayPosition.ProductID = (int)reader["ProductID"];
                    oOutletDisplayPosition.ProductCode = (string)reader["ProductCode"];
                    oOutletDisplayPosition.ProductName = (string)reader["ProductName"];
                    oOutletDisplayPosition.ProductModel = (string)reader["ProductModel"];
                    oOutletDisplayPosition.MAGName = (string)reader["MAGName"];
                    oOutletDisplayPosition.PGName = (string)reader["PGName"];
                    oOutletDisplayPosition.BrandDesc = (string)reader["BrandDesc"];
                    oOutletDisplayPosition.ASGName = (string)reader["ASGName"];
                    oOutletDisplayPosition.AGName = (string)reader["AGName"];
                    oOutletDisplayPosition.AreaName = (string)reader["AreaName"];
                    oOutletDisplayPosition.DistrictName = (string)reader["DistrictName"];
                    oOutletDisplayPosition.TerritoryName = (string)reader["TerritoryName"];
                    oOutletDisplayPosition.ThanaName = (string)reader["ThanaName"];
                    oOutletDisplayPosition.MAGID = (int)reader["MAGID"];
                    oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oOutletDisplayPosition.Status = (int)reader["Status"];
                    oOutletDisplayPosition.IsActive = (int)reader["IsActive"];
                    oOutletDisplayPosition.RackID = (int)reader["RackID"];
                    oOutletDisplayPosition.RackName = (string)reader["RackName"];
                    oOutletDisplayPosition.AssignProductID = (int)reader["AssignProductID"];
                    oOutletDisplayPosition.AssignProductDetail = (string)reader["AssignProductDetail"];
                    oOutletDisplayPosition.ForProductDetail = (string)reader["ForProductDetail"];
                    if (reader["SaleAfter"] != DBNull.Value)
                    {
                        oOutletDisplayPosition.SaleAfter = (DateTime)reader["SaleAfter"];
                    }
                    else
                    {
                        oOutletDisplayPosition.SaleAfter = null;
                    }
                    if (reader["BlankRemarks"] != DBNull.Value)
                    {
                        oOutletDisplayPosition.BlankRemarks = reader["BlankRemarks"].ToString();
                    }
                    else
                    {
                        oOutletDisplayPosition.BlankRemarks = "";
                    }

                    oOutletDisplayPosition.OpenForAll = (bool)reader["OpenForAll"];
                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshInvoiceData(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select DisplayPositionID,ProductSerialNo From (  " +
                          " Select DisplayPositionID,a.ProductSerialNo From  " +
                          " (Select InvoiceID,ProductSerialNo   " +
                          " From t_SalesInvoiceProductSerial where InvoiceID =" + nInvoiceID + ") a  " +
                          " left Outer Join   " +
                          " (Select DisplayPositionID,ProductSerialNo From t_OutletDisplayPosition where   " +
                          " ProductSerialNo is not null or ProductSerialNo<> '' ) b   " +
                          " on a.ProductSerialNo=b.ProductSerialNo) x   " +
                          " where DisplayPositionID is not null or DisplayPositionID<> '' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetDisplayPositionByProductSerial(string sProductSerial)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select* From t_OutletDisplayPosition where ProductSerialNo = '" + sProductSerial + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.WHID = (int)reader["WHID"];
                    oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oOutletDisplayPosition.OpenForAll = (bool)reader["OpenForAll"];

                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ViewOutletDisplayPositionRack(string sCode, int nPGID, int nMAGID, int nASGID, int nAGID,int nRackID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = @"Select * From  
                            (  
                            Select a.*, isnull(b.ProductName, '') as AssignProductDetail,
                            ISNULL(CurrentStock, 0)as CurrentStock,
                            ISNULL(convert(varchar(10),DATEDIFF(day, HistoryDate, GETDATE()),120),'Not Assigned')as Day
                            From  
                            (  
                            Select ShowroomCode, Areaid, AreaName, TerritoryID, TerritoryName, d.ThanaID,  
                            ThanaName, DistrictID, DistrictName, a.DisplayPositionID,PositionCode,  
                            PositionName, b.MAGID, WHID, a.CreateDate, a.CreateUserID,a.ProductID,  
                            ProductCode, ProductName, isnull(ProductModel, '')ProductModel,  
                            AGID, AGName, ASGID, ASGName, MAGName, PGID, PGName, BrandID, BrandDesc,  
                            isnull(a.ProductSerialNo, '')ProductSerialNo,
                            case when a.Status=1 then 'Fill' else 'Blank' end as Status, 
                            case when a.IsActive=1 then 'Active' else 'InActive' end as IsActive, 
                            isnull(AssignProductID, -1) AssignProductID,Assigndate  as Assigndate,
                            RackName, Sort,e.RackID
                            From t_OutletDisplayPosition a, v_ProductDetails b, t_Showroom c, v_CustomerDetails d,
                            t_OutletDisplayPositionRack e 
                            where a.ProductID = b.ProductID and a.WHID = c.WarehouseID and c.CustomerID = d.CustomerID 
                            and a.RackID=e.RackID
                            ) a  
                            Left Outer Join  
                            (  
                            Select ProductID, ProductCode, ProductName From t_Product  
                            ) b on a.AssignProductID = b.ProductID
                            Left Outer Join  
                            (  
                            Select ProductModel,WarehouseID,sum(CurrentStock) as CurrentStock from t_Product a,t_ProductStock
                            b where a.ProductID=b.ProductID and ProductModel is not null group by ProductModel,WarehouseID 
                            ) c on a.ProductModel = c.ProductModel and a.WHID=c.WarehouseID
                            Left Outer Join  
                            (  
                            Select max(HistoryID)HistoryID,DisplayPositionID,CreateDate as HistoryDate From t_OutletDisplayPositionHistory 
                            group by DisplayPositionID,CreateDate 
                            ) d on a.DisplayPositionID = d.DisplayPositionID 
                            ) Main where 1 = 1 ";
                            
            }
            if (sCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sCode + "%'";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }
            if (nRackID != -1)
            {
                sSql = sSql + " AND RackID=" + nRackID + "";
            }
            sSql = sSql + "order by Sort";
            //sSql = string.Format(sSql, nDisplayPositionID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.PositionCode = (string)reader["PositionCode"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.ProductModel= (string)reader["ProductModel"];
                    oOutletDisplayPosition.RackName = (string)reader["RackName"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.BrandDesc = (string)reader["BrandDesc"];
                    if (reader["ProductSerialNo"] != DBNull.Value)
                        oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oOutletDisplayPosition.AssignProductID = (int)reader["AssignProductID"];
                    oOutletDisplayPosition.Day = (string)reader["Day"];
                    oOutletDisplayPosition.CurrentStock = Convert.ToInt32(reader["CurrentStock"]);
                    oOutletDisplayPosition.RackStatus= (string)reader["Status"];
                    //oOutletDisplayPosition.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ViewOutletDisplayPositionRackRT(string sCode, int nPGID, int nMAGID, int nASGID, int nAGID, int nRackID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select * From  " +
                            "(    " +
                            "Select a.*, isnull(b.ProductName, '') as AssignProductDetail,  " +
                            "ISNULL(CurrentStock, 0)as CurrentStock,  " +
                            "ISNULL(convert(varchar(10),DATEDIFF(day, HistoryDate, GETDATE()),120),'Not Assigned')as Day  " +
                            "From    " +
                            "(    " +
                            "Select ShowroomCode, Areaid, AreaName, TerritoryID, TerritoryName, d.ThanaID,    " +
                            "ThanaName, DistrictID, DistrictName, a.DisplayPositionID,PositionCode,    " +
                            "PositionName, b.MAGID, WHID, a.CreateDate, a.CreateUserID,a.ProductID,    " +
                            "ProductCode, ProductName, isnull(ProductModel, '')ProductModel,    " +
                            "AGID, AGName, ASGID, ASGName, MAGName, PGID, PGName, BrandID, BrandDesc,    " +
                            "isnull(a.ProductSerialNo, '')ProductSerialNo,  " +
                            "case when a.Status=1 then 'Fill' else 'Blank' end as Status,   " +
                            "case when a.IsActive=1 then 'Active' else 'InActive' end as IsActive,   " +
                            "isnull(AssignProductID, -1) AssignProductID,Assigndate  as Assigndate,  " +
                            "RackName, Sort,e.RackID  " +
                            "From t_OutletDisplayPosition a, v_ProductDetails b, t_Showroom c, v_CustomerDetails d,  " +
                            "t_OutletDisplayPositionRack e   " +
                            "where a.ProductID = b.ProductID and a.WHID = c.WarehouseID and c.CustomerID = d.CustomerID   " +
                            "and a.RackID=e.RackID and  a.WHID=" + Utility.WarehouseID + " " +
                            ") a    " +
                            "Left Outer Join    " +
                            "(    " +
                            "Select ProductID, ProductCode, ProductName From t_Product    " +
                            ") b on a.AssignProductID = b.ProductID  " +
                            "Left Outer Join    " +
                            "(    " +
                            "Select ProductModel,WarehouseID,sum(CurrentStock) as CurrentStock from t_Product a,t_ProductStock  " +
                            "b where a.ProductID=b.ProductID and b.WarehouseID=" + Utility.WarehouseID + " group by ProductModel,WarehouseID   " +
                            ") c on a.ProductModel = c.ProductModel and a.WHID=c.WarehouseID  " +
                            "Left Outer Join    " +
                            "(    " +
                            "Select max(HistoryID)HistoryID,DisplayPositionID,CreateDate as HistoryDate From t_OutletDisplayPositionHistory   " +
                            "group by DisplayPositionID,CreateDate   " +
                            ") d on a.DisplayPositionID = d.DisplayPositionID   " +
                            ") Main where 1 = 1 ";

            }
            if (sCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sCode + "%'";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }
            if (nRackID != -1)
            {
                sSql = sSql + " AND RackID=" + nRackID + "";
            }
            sSql = sSql + "order by Sort";
            //sSql = string.Format(sSql, nDisplayPositionID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.PositionCode = (string)reader["PositionCode"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.ProductModel = (string)reader["ProductModel"];
                    oOutletDisplayPosition.RackName = (string)reader["RackName"];
                    oOutletDisplayPosition.BrandDesc = (string)reader["BrandDesc"];
                    if (reader["ProductSerialNo"] != DBNull.Value)
                        oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oOutletDisplayPosition.AssignProductID = (int)reader["AssignProductID"];
                    oOutletDisplayPosition.AssignProductDetail = (string)reader["AssignProductDetail"];
                    oOutletDisplayPosition.Day = (string)reader["Day"];
                    oOutletDisplayPosition.CurrentStock = Convert.ToInt32(reader["CurrentStock"]);
                    oOutletDisplayPosition.RackStatus = (string)reader["Status"];
                    //oOutletDisplayPosition.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oOutletDisplayPosition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ViewOutletDisplayPositionRackHead(string sCode,int nPGID, int nMAGID, int nASGID, int nAGID, int nOutlet,int nRackID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = @"Select * From  
                            (  
                            Select a.*, isnull(b.ProductName, '') as AssignProductDetail,
                            ISNULL(CurrentStock, 0)as CurrentStock,
                            ISNULL(convert(varchar(10),DATEDIFF(day, HistoryDate, GETDATE()),120),'Not Assigned')as Day
                            From  
                            (  
                            Select ShowroomCode, Areaid, AreaName, TerritoryID, TerritoryName, d.ThanaID,  
                            ThanaName, DistrictID, DistrictName, a.DisplayPositionID,PositionCode,  
                            PositionName, b.MAGID, WHID, a.CreateDate, a.CreateUserID,a.ProductID,  
                            ProductCode, ProductName, isnull(ProductModel, '')ProductModel,  
                            AGID, AGName, ASGID, ASGName, MAGName, PGID, PGName, BrandID, BrandDesc,  
                            isnull(a.ProductSerialNo, '')ProductSerialNo,
                            case when a.Status=1 then 'Fill' else 'Blank' end as Status, 
                            case when a.IsActive=1 then 'Active' else 'InActive' end as IsActive, 
                            isnull(AssignProductID, -1) AssignProductID,Assigndate  as Assigndate,
                            RackName, Sort,e.RackID
                            From t_OutletDisplayPosition a, v_ProductDetails b, t_Showroom c, v_CustomerDetails d,
                            t_OutletDisplayPositionRack e 
                            where a.ProductID = b.ProductID and a.WHID = c.WarehouseID and c.CustomerID = d.CustomerID 
                            and a.RackID=e.RackID
                            ) a  
                            Left Outer Join  
                            (  
                            Select ProductID, ProductCode, ProductName From t_Product  
                            ) b on a.AssignProductID = b.ProductID
                            Left Outer Join  
                            (  
                            Select ProductModel,WarehouseID,sum(CurrentStock) as CurrentStock from t_Product a,t_ProductStock
                            b where a.ProductID=b.ProductID and ProductModel is not null group by ProductModel,WarehouseID 
                            ) c on a.ProductModel = c.ProductModel and a.WHID=c.WarehouseID
                            Left Outer Join  
                            (  
                            Select max(HistoryID)HistoryID,DisplayPositionID,CreateDate as HistoryDate From t_OutletDisplayPositionHistory 
                            group by DisplayPositionID,CreateDate 
                            ) d on a.DisplayPositionID = d.DisplayPositionID 
                            ) Main where 1 = 1 ";

            }
            if (sCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sCode + "%'";
            }
            if (nOutlet != -1)
            {
                sSql = sSql + " AND WHID=" + nOutlet + "";
            }

            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }           

            if (nRackID != -1)
            {
                sSql = sSql + " AND RackID=" + nRackID + "";
            }

            sSql = sSql + "order by Sort";
            //sSql = string.Format(sSql, nDisplayPositionID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDisplayPosition oOutletDisplayPosition = new OutletDisplayPosition();
                    oOutletDisplayPosition.DisplayPositionID = (int)reader["DisplayPositionID"];
                    oOutletDisplayPosition.RackID = (int)reader["RackID"];
                    oOutletDisplayPosition.PositionCode = (string)reader["PositionCode"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.ProductModel = (string)reader["ProductModel"];
                    oOutletDisplayPosition.RackName = (string)reader["RackName"];
                    oOutletDisplayPosition.PositionName = (string)reader["PositionName"];
                    oOutletDisplayPosition.BrandDesc = (string)reader["BrandDesc"];
                    if (reader["ProductSerialNo"] != DBNull.Value)
                        oOutletDisplayPosition.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oOutletDisplayPosition.AssignProductID = (int)reader["AssignProductID"];
                    oOutletDisplayPosition.Day = (string)reader["Day"];
                    oOutletDisplayPosition.CurrentStock = Convert.ToInt32(reader["CurrentStock"]);
                    oOutletDisplayPosition.RackStatus = (string)reader["Status"];
                    //oOutletDisplayPosition.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oOutletDisplayPosition);
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

