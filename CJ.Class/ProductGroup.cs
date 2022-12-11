// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shahnoor Saeed
// Date: July 07, 2011
// Time :  11:00 PM
// Description: Class for ProductGroup.
// Modify Person And Date:
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
    public class ProductGroup
    {
        private int _nHSCodeID;
        private string _sHSCode;
        private int _PdtGroupID;
        private string _PdtGroupCode;
        private string _PdtGroupName;
        private int _PdtGroupType;
        private int _ParentID;
        private int _POS;
        private int _IsActive;
        private int _UploadStatus;
        private DateTime _UploadDate;
        private DateTime _DownloadDate;
        private DateTime _RowStatus;
        private DateTime _Terminal;
        private int _TransferType;
        private bool _bFlag;

        private int _nAGID;


        public int HSCodeID
        {
            get { return _nHSCodeID; }
            set { _nHSCodeID = value; }
        }

        public string HSCode
        {
            get { return _sHSCode; }
            set { _sHSCode = value; }
        }
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        private int _nASGID;
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        private int _nMAGID;
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        private int _nPGID;
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        
        private string _sFaultTypeName;
        public string FaultTypeName
        {
            get { return _sFaultTypeName; }
            set { _sFaultTypeName = value.Trim(); }
        }

        private string _sReplaceClaimNo;
        public string ReplaceClaimNo
        {
            get { return _sReplaceClaimNo; }
            set { _sReplaceClaimNo = value.Trim(); }
        }
        private string _sSubClaimNumber;
        public string SubClaimNumber
        {
            get { return _sSubClaimNumber; }
            set { _sSubClaimNumber = value.Trim(); }
        }

        int nCount = 0;
        //Written by Rifat Farhana: 19-May-2014
        private ProductGroup _oParentProductGroup;

        /// <summary>
        /// Get set property for PdtGroupID
        /// </summary>
        public int PdtGroupID
        {
            get { return _PdtGroupID; }
            set { _PdtGroupID = value; }
        }

        /// <summary>
        /// Get set property for PdtGroupCode
        /// </summary>
        public string PdtGroupCode
        {
            get { return _PdtGroupCode; }
            set { _PdtGroupCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PdtGroupName
        /// </summary>
        public string PdtGroupName
        {
            get { return _PdtGroupName; }
            set { _PdtGroupName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PdtGroupType
        /// </summary>
        public int PdtGroupType
        {
            get { return _PdtGroupType; }
            set { _PdtGroupType = value; }
        }

        /// <summary>
        /// Get set property for ParentID
        /// </summary>
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        private string _sComponentName;
        public string ComponentName
        {
            get { return _sComponentName; }
            set { _sComponentName = value.Trim(); }
        }
        private int _nComponentID;
        public int ComponentID
        {
            get { return _nComponentID; }
            set { _nComponentID = value; }
        }
        /// <summary>
        /// Get set property for POS
        /// </summary>
        public int POS
        {
            get { return _POS; }
            set { _POS = value; }
        }

        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        /// <summary>
        /// Get set property for UploadStatus
        /// </summary>
        public int UploadStatus
        {
            get { return _UploadStatus; }
            set { _UploadStatus = value; }
        }

        /// <summary>
        /// Get set property for UploadDate
        /// </summary>
        public DateTime UploadDate
        {
            get { return _UploadDate; }
            set { _UploadDate = value; }
        }

        /// <summary>
        /// Get set property for DownloadDate
        /// </summary>
        public DateTime DownloadDate
        {
            get { return _DownloadDate; }
            set { _DownloadDate = value; }
        }

        /// <summary>
        /// Get set property for RowStatus
        /// </summary>
        public DateTime RowStatus
        {
            get { return _RowStatus; }
            set { _RowStatus = value; }
        }

        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public DateTime Terminal
        {
            get { return _Terminal; }
            set { _Terminal = value; }
        }

        public int TransferType
        {
            get { return _TransferType; }
            set { _TransferType = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        //Written by Rifat Farhana: 18-May-2014
        public int GetParentID(int PdtGroupID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ProductGroup where PdtGroupID =?";
            cmd.Parameters.AddWithValue("PdtGroupID", _PdtGroupID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ParentID = (int)reader["ParentId"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ParentID;
        }
        public ProductGroup ParentProductGroup
        {
            get
            {
                if (_oParentProductGroup == null)
                {
                    _oParentProductGroup = new ProductGroup();
                    _oParentProductGroup.PdtGroupID = _ParentID;
                    _oParentProductGroup.Refresh();

                }
                return _oParentProductGroup;
            }
        }

        private int _nInventoryCategoryID;
        public int InventoryCategoryID
        {
            get { return _nInventoryCategoryID; }
            set { _nInventoryCategoryID = value; }
        }
        private string _sInventoryCategory;
        public string InventoryCategory
        {
            get { return _sInventoryCategory; }
            set { _sInventoryCategory = value; }
        }

        //Written by Md. Abdul Hakim: 17-Apr-2014
        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                string sSql = "";

                sSql = "INSERT INTO t_ProductGroup (PdtGroupID,PdtGroupCode,PdtGroupName,PdtGroupType, "+
                       "ParentId,POS,IsActive) VALUES(?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PdtGroupID", _PdtGroupID);
                cmd.Parameters.AddWithValue("PdtGroupCode", _PdtGroupCode);
                cmd.Parameters.AddWithValue("PdtGroupName", _PdtGroupName);
                cmd.Parameters.AddWithValue("PdtGroupType", _PdtGroupType);
                if (_ParentID != null)
                    cmd.Parameters.AddWithValue("ParentId", _ParentID);
                else cmd.Parameters.AddWithValue("ParentId", null);
                if (_POS != null)
                    cmd.Parameters.AddWithValue("POS", _POS);
                else cmd.Parameters.AddWithValue("POS", null);
                cmd.Parameters.AddWithValue("IsActive", _IsActive);

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

                sSql = "Update t_ProductGroup Set PdtGroupCode=?,PdtGroupName=?,PdtGroupType=?,ParentID=?,POS=?,IsActive=? " +
                               " Where PdtGroupID =?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PdtGroupCode", _PdtGroupCode);
                cmd.Parameters.AddWithValue("PdtGroupName", _PdtGroupName);
                cmd.Parameters.AddWithValue("PdtGroupType", _PdtGroupType);
                if (_ParentID != null)
                    cmd.Parameters.AddWithValue("ParentId", _ParentID);
                else cmd.Parameters.AddWithValue("ParentId", null);
                if (_POS != null)
                    cmd.Parameters.AddWithValue("POS", _POS);
                else cmd.Parameters.AddWithValue("POS", null);
                cmd.Parameters.AddWithValue("IsActive", _IsActive);

                cmd.Parameters.AddWithValue("PdtGroupID", _PdtGroupID);

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
                sSql = "DELETE FROM t_ProductGroup WHERE [PdtGroupID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PdtGroupID", _PdtGroupID);
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
                cmd.CommandText = "SELECT * FROM t_ProductGroup where PdtGroupID =?";
                cmd.Parameters.AddWithValue("PdtGroupID", _PdtGroupID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _PdtGroupID = int.Parse(reader["PdtGroupID"].ToString());
                    _PdtGroupCode = reader["PdtGroupCode"].ToString();
                    _PdtGroupName = reader["PdtGroupName"].ToString();
                    _PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] != DBNull.Value)
                        _ParentID = int.Parse(reader["ParentId"].ToString());
                    else _ParentID = 0;

                    if (reader["POS"] != DBNull.Value)
                        _POS = int.Parse(reader["POS"].ToString());
                    else _POS = 0;
                    _IsActive = int.Parse(reader["IsActive"].ToString());

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

        public void GetPdtGroupAllByAGID(int nAGID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select a.PdtGroupID AGID,a.PdtGroupName AGName, b.PdtGroupID ASGID,b.PdtGroupName ASGName, " +
                                "c.PdtGroupID MAGID,c.PdtGroupName MAGName, " +
                                "d.PdtGroupID PGID,d.PdtGroupName PGName  " +
                                "From t_ProductGroup a,t_ProductGroup b,t_ProductGroup c,t_ProductGroup d " +
                                "where a.ParentID=b.PdtGroupID and b.ParentID=c.PdtGroupID and c.ParentID=d.PdtGroupID " +
                                "and a.PdtGroupID=" + nAGID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nAGID = int.Parse(reader["AGID"].ToString());
                    _nASGID = int.Parse(reader["ASGID"].ToString());
                    _nMAGID = int.Parse(reader["MAGID"].ToString());
                    _nPGID = int.Parse(reader["PGID"].ToString());                   

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

        public int GetFaultTypeID(string sFaultTypeName, string sMAGName)
        {
            int nFaultTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select FaultTypeID From t_ReplaceClaimFaultTypeMAG where FaultTypeName='" + sFaultTypeName + "' and MAGName='" + sMAGName + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nFaultTypeID = (int)reader["FaultTypeID"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nFaultTypeID;
        }

        public void GetByName(string sPdtGroupName, int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From t_ProductGroup where pdtgroupName='" + sPdtGroupName + "' and PdtGroupType=" + nType + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _PdtGroupID = int.Parse(reader["PdtGroupID"].ToString());

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
    public class InventoryCategory
    {
       

        private int _nInventoryCategoryID;
        public int InventoryCategoryID
        {
            get { return _nInventoryCategoryID; }
            set { _nInventoryCategoryID = value; }
        }
        private string _sInventoryCategoryName;
        public string InventoryCategoryName
        {
            get { return _sInventoryCategoryName; }
            set { _sInventoryCategoryName = value; }
        }
        
    }
    public class ProductGroups : CollectionBase
    {
        public ProductGroup this[int i]
        {
            get { return (ProductGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductGroup oProductGroup)
        {
            InnerList.Add(oProductGroup);
        }

        public int GetIndex(int nProductGroupID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PdtGroupID== nProductGroupID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetIndexHSCode(int nHSCodeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].HSCodeID == nHSCodeID)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetIndexByID(int nProductGroupID)
        {
            int i = 0;
            foreach (ProductGroup oProductGroup in this)
            {
                if (oProductGroup.PdtGroupID == nProductGroupID)
                    return i;
                i++;
            }
            return -1;
        }

        public DataTable ToDataTable()
        {
            List<ProductGroup> oProductGroups = new List<ProductGroup>();

            foreach (ProductGroup oItem in this)
            {
                oProductGroups.Add(oItem);
            }

            DataTable oTable = CollectionHelper.ConvertTo<ProductGroup>(oProductGroups);

            return oTable;
        }

        //Arif Khan: 7-Apr-2014: Rewrite for Product UI 
        public void Refresh(Dictionary.ProductGroupType nProductGroupType)
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = ? order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("PdtGroupType", (int)nProductGroupType);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                //oProductGroup = new ProductGroup();
                //oProductGroup.PdtGroupID = -1;
                //oProductGroup.PdtGroupName = "ALL";
                //InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                //cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //Arif Khan: 7-Apr-2014: Rewrite for Product UI
        public void Refresh(int nParentID)
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where ParentId = ? order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ParentId", nParentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                //oProductGroup = new ProductGroup();
                //oProductGroup.PdtGroupID = -1;
                //oProductGroup.PdtGroupName = "ALL";
                //InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                //cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetProductGroup(int nProductGroupType)
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = ? order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("PdtGroupType", nProductGroupType);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());
                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());
                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        //Arif Khan: 4-May-2014: For Product Hierarchy
        public void RefreshProductHierarchy(Dictionary.ActiveOrInActiveStatus nActiveOrInActiveStatus)
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //nActiveOrInActiveStatus
            string sSql = "Select PdtGroupId as ID, PdtGroupCode as Code, PdtGroupName as Name, PdtGroupType as GroupType, ParentID from t_ProductGroup"
                + " UNION ALL " 
                + " Select -1 as ID, ProductCode as Code, ProductName as Name, 5 as GroupType, ProductGroupID as ParentID from t_Product";

            try
            {
                cmd.CommandText = sSql;
                //cmd.Parameters.AddWithValue("ParentId", nParentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["ID"].ToString());
                    oProductGroup.PdtGroupCode = reader["Code"].ToString();
                    oProductGroup.PdtGroupName = reader["Name"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["GroupType"].ToString());

                    if (reader["ParentID"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentID"].ToString());

                    //oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                //oProductGroup = new ProductGroup();
                //oProductGroup.PdtGroupID = -1;
                //oProductGroup.PdtGroupName = "ALL";
                //InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                //cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetHTVAG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_ProductGroup where PdtGrouptype=4 and ParentID=48 order by PdtGroupName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());
                    InnerList.Add(oProductGroup);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetHSCodeInfo()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_HSCodeInfo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.HSCodeID = int.Parse(reader["HSCodeID"].ToString());
                    oProductGroup.HSCode = reader["HSCode"].ToString();
                    InnerList.Add(oProductGroup);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #region These functions are written by Mr. Shyam S. Biswas. These should be obsolate. (Arif Khan 8-Apr-2014)
        public void GETPG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 1 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "ALL";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GETMAG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 2 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "ALL";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GETCACMAG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_CACQuotationBrandMag a, t_productgroup b where a.GroupID=b.PdtGroupID and Type=2 order by Sort asc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "ALL";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GETASG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 3 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "ALL";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GETAG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 4 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "ALL";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetMAG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select PDTGroupID,PdtGroupCode,PdtGroupName,PdtGroupType,IsActive From  " +
                          " t_ProductGroup where PdtGroupType=2 and IsActive=1 order by PdtGroupName ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetASGWithoutAll()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 3 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetAGWithoutAll()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select * from t_ProductGroup where PdtGroupType = 4 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProductComponent()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select distinct ComponentID,ComponentName From t_ProductComponentUniversal";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.ComponentID = int.Parse(reader["ComponentID"].ToString());
                    oProductGroup.ComponentName = reader["ComponentName"].ToString();

                    InnerList.Add(oProductGroup);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GETAGByEMITenure()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select * from t_ProductGroup where PdtGroupType = 4 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public void GEProductGroupFactory(string sGroup,string sGroupID)
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select distinct "+ sGroupID + ","+ sGroup + " From t_Product order by "+ sGroup + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["" + sGroupID + ""].ToString());
                    oProductGroup.PdtGroupName = reader["" + sGroup + ""].ToString();
                    InnerList.Add(oProductGroup);
                }

                reader.Close();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void GETMAGByEMITenure()
        //{
        //    ProductGroup oProductGroup;
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = " Select * from t_ProductGroup where PdtGroupType = 2 order by PdtGroupName ";

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            oProductGroup = new ProductGroup();
        //            oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
        //            oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
        //            oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
        //            oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());
        //            oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

        //            InnerList.Add(oProductGroup);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void GetMAGForReplace(int nType, string sReplaceClaimNo)
        {
            ProductGroup oProductGroup;
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (nType == 1)
            {
                sSql = "Select cast(max(ReplaceClaimNo)+1 AS varchar(100)) as ReplaceClaimNo, " +
                              "cast(max(ReplaceClaimNo)+1 AS varchar(100))+'_'+PdtGroupName AS SubClaimNumber " +
                              "From t_ProductGroup a,t_ReplaceClaimNoGenerator b " +
                              "where PdtGroupType=2 AND IsActive=1 " +
                              "group by PdtGroupName";
            }
            else
            {
                sSql = "Select * From  " +
                            "(  " +
                            "Select '" + sReplaceClaimNo + "' as ReplaceClaimNo,   " +
                            "'" + sReplaceClaimNo + "'+'_'+PdtGroupName AS SubClaimNumber   " +
                            "From t_ProductGroup a,t_ReplaceClaimNoGenerator b   " +
                            "where PdtGroupType=2 AND IsActive=1   " +
                            "group by PdtGroupName  " +
                            ") a where SubClaimNumber not in (Select SubClaimNumber   " +
                            "From dbo.t_ReplaceClaimNoGenerator where ReplaceClaimNo='" + sReplaceClaimNo + "')";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.ReplaceClaimNo = reader["ReplaceClaimNo"].ToString();
                    oProductGroup.SubClaimNumber = reader["SubClaimNumber"].ToString();
                    InnerList.Add(oProductGroup);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetReplaceFaultType(string sMAGName)
        {
            ProductGroup oProductGroup;
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSql = "Select * From [dbo].[t_ReplaceClaimFaultTypeMAG] where MAGName='" + sMAGName + "'";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.FaultTypeName = reader["FaultTypeName"].ToString();
                    InnerList.Add(oProductGroup);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetInventoryCategory()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_ProductInventoryCategory order by InventoryCategory";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.InventoryCategoryID = int.Parse(reader["InventoryCategoryID"].ToString());
                    oProductGroup.InventoryCategory = reader["InventoryCategory"].ToString();


                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllProductGroup()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();          
                    
                    InnerList.Add(oProductGroup);
                }

                reader.Close();
              
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllGroupForPOS(int nWarehouseID)
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup a inner join t_DataTransfer b on b.DataID=a.PdtGroupID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and WarehouseID= ? ";

            cmd.Parameters.AddWithValue("TableName", "t_ProductGroup");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());
                 
                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());
                    oProductGroup.TransferType = int.Parse(reader["TransferType"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();             
                InnerList.TrimToSize();
             
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
       

        //******************************************* FOR LIGHT ************************************//

        public void GETLightASG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductGroup where PdtGroupID ='126' or PdtGroupID ='688' or PdtGroupID ='125' or PdtGroupID ='127'or PdtGroupID ='140' or PdtGroupID ='139' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "ALL";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //******************************************* END LIGHT ************************************//


        public void POSGETPG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 1 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "< Select PG >";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void POSGETMAG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 2 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "< Select MAG >";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void POSGETASG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 3 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "< Select ASG >";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void POSGETAG()
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 4 order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "< Select AG >";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #region Web Service Funcation

        public DSProductGroups POSGetAllProductGroup(DSProductGroups oDSProductGroups)
        {
            oDSProductGroups = new DSProductGroups();

            POSGETPG();
            foreach (ProductGroup oProductGroup in this)
            {
                DSProductGroups.PGGroupRow oPGGroupRow = oDSProductGroups.PGGroup.NewPGGroupRow();

                oPGGroupRow.PdtGroupName = oProductGroup.PdtGroupName;
                oPGGroupRow.PdtGroupId = oProductGroup.PdtGroupID;

                oDSProductGroups.PGGroup.AddPGGroupRow(oPGGroupRow);
                oDSProductGroups.AcceptChanges();
            }

            POSGETMAG();
            foreach (ProductGroup oProductGroup in this)
            {
                DSProductGroups.MAGGroupRow oMAGGroupRow = oDSProductGroups.MAGGroup.NewMAGGroupRow();

                oMAGGroupRow.PdtGroupName = oProductGroup.PdtGroupName;
                oMAGGroupRow.PdtGroupId = oProductGroup.PdtGroupID;
                oMAGGroupRow.ParentId = (short)oProductGroup.ParentID;


                oDSProductGroups.MAGGroup.AddMAGGroupRow(oMAGGroupRow);
                oDSProductGroups.AcceptChanges();
            }

            POSGETASG();
            foreach (ProductGroup oProductGroup in this)
            {
                DSProductGroups.ASGGroupRow oASGGroupRow = oDSProductGroups.ASGGroup.NewASGGroupRow();

                oASGGroupRow.PdtGroupName = oProductGroup.PdtGroupName;
                oASGGroupRow.PdtGroupId = oProductGroup.PdtGroupID;
                oASGGroupRow.ParentId = (short)oProductGroup.ParentID;

                oDSProductGroups.ASGGroup.AddASGGroupRow(oASGGroupRow);
                oDSProductGroups.AcceptChanges();
            }
            POSGETAG();
            foreach (ProductGroup oProductGroup in this)
            {
                DSProductGroups.AGGroupRow oAGGroupRow = oDSProductGroups.AGGroup.NewAGGroupRow();

                oAGGroupRow.PdtGroupName = oProductGroup.PdtGroupName;
                oAGGroupRow.PdtGroupId = oProductGroup.PdtGroupID;
                oAGGroupRow.ParentId = (short)oProductGroup.ParentID;

                oDSProductGroups.AGGroup.AddAGGroupRow(oAGGroupRow);
                oDSProductGroups.AcceptChanges();
            }

            return oDSProductGroups;
        }

        #endregion

        public void GETMAGagainstPG(int nPG)
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where PdtGroupType = 2 and ParentID='"+ nPG + "' order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "ALL";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForAll(int nParentID)
        {
            ProductGroup oProductGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductGroup where ParentId = ? order by PdtGroupName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ParentId", nParentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductGroup = new ProductGroup();
                    oProductGroup.PdtGroupID = int.Parse(reader["PdtGroupId"].ToString());
                    oProductGroup.PdtGroupCode = reader["PdtGroupCode"].ToString();
                    oProductGroup.PdtGroupName = reader["PdtGroupName"].ToString();
                    oProductGroup.PdtGroupType = int.Parse(reader["PdtGroupType"].ToString());

                    if (reader["ParentId"] == DBNull.Value) oProductGroup.ParentID = 0;
                    else oProductGroup.ParentID = int.Parse(reader["ParentId"].ToString());

                    oProductGroup.POS = int.Parse(reader["Pos"].ToString());
                    oProductGroup.IsActive = int.Parse(reader["IsActive"].ToString());

                    InnerList.Add(oProductGroup);
                }

                reader.Close();

                oProductGroup = new ProductGroup();
                oProductGroup.PdtGroupID = -1;
                oProductGroup.PdtGroupName = "ALL";
                InnerList.Add(oProductGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //reader.Close();
                //InnerList.TrimToSize();
                //cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

    public class InventoryCategorys : CollectionBase
    {
        public InventoryCategory this[int i]
        {
            get { return (InventoryCategory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(InventoryCategory oInventoryCategory)
        {
            InnerList.Add(oInventoryCategory);
        }

        public int GetIndex(int nInventoryCategoryID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].InventoryCategoryID == nInventoryCategoryID)
                {
                    return i;
                }
            }
            return -1;
        }


        public void Refresh()
        {
            InventoryCategory oInventoryCategory;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_ProductInventoryCategory order by InventoryCategoryID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oInventoryCategory = new InventoryCategory();
                    oInventoryCategory.InventoryCategoryID = int.Parse(reader["InventoryCategoryID"].ToString());
                    oInventoryCategory.InventoryCategoryName = reader["InventoryCategory"].ToString();

                    InnerList.Add(oInventoryCategory);
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


    }
}