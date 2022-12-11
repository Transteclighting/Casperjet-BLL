// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shahnoor Saeed
// Date: July 07, 2011
// Time :  03:30 PM
// Description: Class for Brand.
// Modify Person And Date: Arif Khan, 30-Apr-2014 (Brand & Sub Brand UIs)
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;

namespace CJ.Class
{
    public class Brand
    {
        private int _nBrandID;
        private string _sBrandCode;
        private string _sBrandDesc;
        private int _bIsActive;
        private int _nBrandLevel;
        private int _nParentID;
        private int _nBrandPos;
        private int _nUploadStatus;
        private DateTime _dUploadDate;
        private DateTime _dDownloadDate;
        private int _nRowStatus;
        private DateTime _dTerminal;
        private int _nTransferType;
        private bool _bFlag;

        //Written by Arif Khan: 30-Apr-2014
        private Brand _oParentBrand;

        int nCount = 0;


        /// <summary>
        /// Get set property for BrandID
        /// </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        /// <summary>
        /// Get set property for BrandCode
        /// </summary>
        public string BrandCode
        {
            get { return _sBrandCode; }
            set { _sBrandCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for BrandDesc
        /// </summary>
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }

        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
        }

        /// <summary>
        /// Get set property for BrandLevel
        /// </summary>
        public int BrandLevel
        {
            get { return _nBrandLevel; }
            set { _nBrandLevel = value; }
        }

        /// <summary>
        /// Get set property for ParentID
        /// </summary>
        public int ParentID
        {
            get { return _nParentID; }
            set { _nParentID = value; }
        }

        /// <summary>
        /// Get set property for BrandPos
        /// </summary>
        public int BrandPos
        {
            get { return _nBrandPos; }
            set { _nBrandPos = value; }
        }

        /// <summary>
        /// Get set property for UploadStatus
        /// </summary>
        public int UploadStatus
        {
            get { return _nUploadStatus; }
            set { _nUploadStatus = value; }
        }

        /// <summary>
        /// Get set property for UploadDate
        /// </summary>
        public DateTime UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }
        }

        /// <summary>
        /// Get set property for DownloadDate
        /// </summary>
        public DateTime DownloadDate
        {
            get { return _dDownloadDate; }
            set { _dDownloadDate = value; }
        }

        /// <summary>
        /// Get set property for RowStatus
        /// </summary>
        public int RowStatus
        {
            get { return _nRowStatus; }
            set { _nRowStatus = value; }
        }

        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public DateTime Terminal
        {
            get { return _dTerminal; }
            set { _dTerminal = value; }
        }
        public int TransferType
        {
            get { return _nTransferType; }
            set { _nTransferType = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        //Written by Arif Khan: 30-Apr-2014
        public Brand ParentBrand
        {
            get
            {
                if (_oParentBrand == null)
                {
                    _oParentBrand = new Brand();
                    _oParentBrand.BrandID = _nParentID;
                    _oParentBrand.Refresh();

                }
                return _oParentBrand;
            }
        } 

        //Written by Md. Abdul Hakim: 17-Apr-2014
        public void Add()
        {
            int nMaxBrandID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                string sSql = "";
                if (_nBrandID == 0)
                {

                    sSql = "SELECT MAX([BrandID]) FROM t_Brand";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxBrandID = 1;
                    }
                    else
                    {
                        nMaxBrandID = Convert.ToInt32(maxID) + 1;
                    }
                    _nBrandID = nMaxBrandID;
                }

                sSql = "INSERT INTO t_Brand (BrandID,BrandCode,BrandDesc,IsActive,BrandLevel,ParentID,BrandPos) VALUES(?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("BrandCode", _sBrandCode);
                cmd.Parameters.AddWithValue("BrandDesc", _sBrandDesc);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("BrandLevel", _nBrandLevel);
                if (_nParentID != null)
                    cmd.Parameters.AddWithValue("ParentID", _nParentID);
                else cmd.Parameters.AddWithValue("ParentID", null);
                if (_nBrandPos != null)
                    cmd.Parameters.AddWithValue("BrandPos", _nBrandPos);
                else cmd.Parameters.AddWithValue("BrandPos", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Written by Md. Abdul Hakim: 17-Apr-2014
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            nCount = 0;
            try
            {

                sSql = "Update t_Brand Set BrandCode=?,BrandDesc=?,IsActive=?,BrandLevel=?,ParentID=?,BrandPos=? "
                               + " Where BrandID =? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("BrandCode", _sBrandCode);
                cmd.Parameters.AddWithValue("BrandDesc", _sBrandDesc);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("BrandLevel", _nBrandLevel);
                if (_nParentID != null)
                    cmd.Parameters.AddWithValue("ParentID", _nParentID);
                else cmd.Parameters.AddWithValue("ParentID", null);
                if (_nBrandPos != null)
                    cmd.Parameters.AddWithValue("BrandPos", _nBrandPos);
                else cmd.Parameters.AddWithValue("BrandPos", null);

                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;
        }
        //Written by Md. Abdul Hakim: 17-Apr-2014
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_Brand WHERE [BrandID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        //Written by Md. Abdul Hakim: 17-Apr-2014
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Brand where BrandID =?";
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBrandID = int.Parse(reader["BrandID"].ToString());
                    
                    _sBrandCode = reader["BrandCode"].ToString();
                    _sBrandDesc = reader["BrandDesc"].ToString();
                    _bIsActive = int.Parse(reader["IsActive"].ToString());
                    _nBrandLevel = int.Parse(reader["BrandLevel"].ToString());
                    if (reader["ParentID"] != DBNull.Value)
                        _nParentID = int.Parse(reader["ParentID"].ToString());


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) Flag = true;
            else Flag = false;
        }

        public void GetBrandByName(string sBrandDesc)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Brand where BrandDesc =? and IsActive=1 and BrandLevel=1";
                cmd.Parameters.AddWithValue("BrandDesc", sBrandDesc);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBrandID = int.Parse(reader["BrandID"].ToString());

                    _sBrandCode = reader["BrandCode"].ToString();
                    _sBrandDesc = reader["BrandDesc"].ToString();
                    _bIsActive = int.Parse(reader["IsActive"].ToString());
                    _nBrandLevel = int.Parse(reader["BrandLevel"].ToString());
                    if (reader["ParentID"] != DBNull.Value)
                        _nParentID = int.Parse(reader["ParentID"].ToString());


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) Flag = true;
            else Flag = false;
        }

    }
    public class Brands : CollectionBase
    {
        public Brand this[int i]
        {
            get { return (Brand)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(Brand oBrand)
        {
            InnerList.Add(oBrand);
        }

        public int GetIndex(int nBrandID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BrandID == nBrandID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(Dictionary.BrandLevel nBrandLevel)
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_Brand Where BrandLevel=? order by BrandDesc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("BrandLevel", (int)nBrandLevel);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    oBrand.BrandLevel = int.Parse(reader["BrandLevel"].ToString());
                    if (reader["ParentID"] != DBNull.Value)
                        oBrand.ParentID = int.Parse(reader["ParentID"].ToString());
                    
                    InnerList.Add(oBrand);
                }

                reader.Close();

                oBrand = new Brand();
                oBrand .BrandID= -1;
                oBrand .BrandDesc= "ALL";
                InnerList.Add(oBrand);
                InnerList.TrimToSize();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nParentID)
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_Brand Where ParentID=? order by BrandDesc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ParentID", (int)nParentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    oBrand.BrandLevel = int.Parse(reader["BrandLevel"].ToString());

                    InnerList.Add(oBrand);
                }

                reader.Close();

                oBrand = new Brand();
                oBrand.BrandID = -1;
                oBrand.BrandDesc = "ALL";
                InnerList.Add(oBrand);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetBrand(int nBrandLevel)
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_Brand Where BrandLevel=" + nBrandLevel + " order by BrandPos ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    oBrand.BrandLevel = int.Parse(reader["BrandLevel"].ToString());

                    InnerList.Add(oBrand);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAllBrand()
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select BrandID,BrandCode,BrandDesc,IsActive From t_Brand where IsActive=1 " +
                          " order by BrandDesc ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    InnerList.Add(oBrand);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCACBrand()
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_CACQuotationBrandMag a, t_brand b " +
                          " where a.GroupID=b.BrandID and Type=1 order by Sort asc ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    InnerList.Add(oBrand);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetMasterBrand()
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_Brand where BrandLevel=" + (int)Dictionary.BrandLevel.MasterBrand + " and IsActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    InnerList.Add(oBrand);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetBrand()
        {
            this.Refresh(Dictionary.BrandLevel.MasterBrand);
        }

        public void GetAllBrand(Dictionary.BrandLevel nBrandLevel)
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_Brand Where BrandLevel=? order by BrandDesc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("BrandLevel", (int)nBrandLevel);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();

                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    oBrand.BrandLevel = int.Parse(reader["BrandLevel"].ToString());             

                    InnerList.Add(oBrand);
                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetAllBrandFactory()
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select distinct BrandID,BrandDesc From t_Product order by BrandDesc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();

                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();

                    InnerList.Add(oBrand);
                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetALlBrandForPOS(int nWarehouseID)
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_Brand a inner join t_DataTransfer b on b.DataID=a.BrandID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and WarehouseID= ? ";

            cmd.Parameters.AddWithValue("TableName", "t_Brand");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    oBrand.BrandLevel = int.Parse(reader["BrandLevel"].ToString());
                    if (reader["ParentID"] != DBNull.Value)
                        oBrand.ParentID = int.Parse(reader["ParentID"].ToString());
                    else oBrand.ParentID = -1;
                    if (reader["BrandPos"] != DBNull.Value)
                        oBrand.BrandPos = int.Parse(reader["BrandPos"].ToString());
                    else oBrand.BrandPos = -1;
                    oBrand.TransferType = int.Parse(reader["TransferType"].ToString());


                    InnerList.Add(oBrand);
                }

                reader.Close();               
                InnerList.TrimToSize();
              
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForLCM()
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_Brand Where BrandID in (38,23) order by BrandDesc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    oBrand.BrandLevel = int.Parse(reader["BrandLevel"].ToString());
                    if (reader["ParentID"] != DBNull.Value)
                        oBrand.ParentID = int.Parse(reader["ParentID"].ToString());

                    InnerList.Add(oBrand);
                }

                reader.Close();

                
                InnerList.TrimToSize();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // **************************************************** FOR LIGHT ***********************************//

        public void GetLightBrand()
        {
            Brand oBrand;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_Brand where BrandID='1' or BrandID='4'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBrand = new Brand();
                    oBrand.BrandID = int.Parse(reader["BrandID"].ToString());
                    oBrand.BrandCode = reader["BrandCode"].ToString();
                    oBrand.BrandDesc = reader["BrandDesc"].ToString();
                    oBrand.IsActive = int.Parse(reader["IsActive"].ToString());
                    oBrand.BrandLevel = int.Parse(reader["BrandLevel"].ToString());

                    InnerList.Add(oBrand);
                }

                reader.Close();

                oBrand = new Brand();
                oBrand.BrandID = -1;
                oBrand.BrandDesc = "ALL";
                InnerList.Add(oBrand);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // **************************************************** FOR LIGHT ***********************************//


        #region Web Service Funcation

        public DSBrand POSGetBrand(DSBrand oDSBrand)
        {
            oDSBrand = new DSBrand();
            this.Refresh(Dictionary.BrandLevel.MasterBrand);

            foreach (Brand oBrand in this)
            {
                DSBrand.BrandRow oBrandRow = oDSBrand.Brand.NewBrandRow();

                oBrandRow.BrandDesc = oBrand.BrandDesc;
                oBrandRow.BrandID = oBrand.BrandID;

                oDSBrand.Brand.AddBrandRow(oBrandRow);
                oDSBrand.AcceptChanges();
            }
            return oDSBrand;
        }

         #endregion

    }
}

