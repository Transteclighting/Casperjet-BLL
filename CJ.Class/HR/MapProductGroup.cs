// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Oct 04, 2015
// Time : 04:28 PM
// Description: Class for MapProductGroup.
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
    public class MapProductGroupItem
    {
        private int _nID;
        private int _nDataID;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for DataID
        // </summary>
        public int DataID
        {
            get { return _nDataID; }
            set { _nDataID = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_MapProductGroupItem (ID, DataID) VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("DataID", _nDataID);

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
                sSql = "UPDATE t_MapProductGroupItem SET DataID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DataID", _nDataID);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_MapProductGroupItem WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_MapProductGroupItem where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nDataID = (int)reader["DataID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class MapProductGroup: CollectionBase
    {
        public MapProductGroupItem this[int i]
        {
            get { return (MapProductGroupItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MapProductGroupItem oMapProductGroupItem)
        {
            InnerList.Add(oMapProductGroupItem);
        }

        private int _nID;
        private int _nEmployeeID;
        private int _nMapEmployeeType;
        private int _nMapGroupType;
        private string _sRemarks;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nSort;
        private string _sEmployeeName;
        private string _sMAPEmployeeTypeName;
        private string _sMAPGroupTypeName;
        private string _sDesignationName;


        private Warehouses oMAPWarehouses;
        private ProductGroups oMAPProductGroups;


        public Warehouses Warehouses
        {
            get
            {
                if (oMAPWarehouses == null)
                {
                    oMAPWarehouses = new Warehouses();
                }
                return oMAPWarehouses;
            }
        }
        public ProductGroups ProductGroups
        {
            get
            {
                if (oMAPProductGroups == null)
                {
                    oMAPProductGroups = new ProductGroups();
                }
                return oMAPProductGroups;
            }
        }



        //private MapProductGroupItems oMapProductGroupItems;

        //public MapProductGroupItems MapProductGroupItems
        //{
        //    get
        //    {
        //        if (oMapProductGroupItems == null)
        //        {
        //            oMapProductGroupItems = new MapProductGroupItems();
        //        }
        //        return oMapProductGroupItems;
        //    }
        //}


        // <summary>
        // Get set property for DesignationName
        // </summary>
        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }
        
        // <summary>
        // Get set property for EmployeeName
        // </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }

        // <summary>
        // Get set property for MAPEmployeeTypeName
        // </summary>
        public string MAPEmployeeTypeName
        {
            get { return _sMAPEmployeeTypeName; }
            set { _sMAPEmployeeTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for MAPGroupTypeName
        // </summary>
        public string MAPGroupTypeName
        {
            get { return _sMAPGroupTypeName; }
            set { _sMAPGroupTypeName = value.Trim(); }
        }


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        // <summary>
        // Get set property for MapEmployeeType
        // </summary>
        public int MapEmployeeType
        {
            get { return _nMapEmployeeType; }
            set { _nMapEmployeeType = value; }
        }

        // <summary>
        // Get set property for MapGroupType
        // </summary>
        public int MapGroupType
        {
            get { return _nMapGroupType; }
            set { _nMapGroupType = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
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
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for Sort
        // </summary>
        public int Sort
        {
            get { return _nSort; }
            set { _nSort = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MapProductGroup";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_MapProductGroup (ID, EmployeeID, MapEmployeeType, MapGroupType, Remarks, IsActive, CreateUserID, CreateDate, UpdateUserID, UpdateDate, Sort) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("MapEmployeeType", _nMapEmployeeType);
                cmd.Parameters.AddWithValue("MapGroupType", _nMapGroupType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Sort", _nSort);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Insert()
        {
            int nMPGID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MapProductGroup";
                cmd.CommandText = sSql;
                object maxMPGID = cmd.ExecuteScalar();
                if (maxMPGID == DBNull.Value)
                {
                    nMPGID = 1;
                }
                else
                {
                    nMPGID = Convert.ToInt32(maxMPGID) + 1;
                }
                _nID = nMPGID;

                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_MapProductGroup (ID, EmployeeID, MapEmployeeType, MapGroupType, Remarks, IsActive, CreateUserID, CreateDate, UpdateUserID, UpdateDate, Sort) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("MapEmployeeType", _nMapEmployeeType);
                cmd.Parameters.AddWithValue("MapGroupType", _nMapGroupType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Sort", _nSort);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                ////if (oMapProductGroupItems!= null)
                ////{
                //    foreach (MapProductGroupItem oMapProductGroupItem in oMapProductGroupItems)
                //    {
                //        oMapProductGroupItem.ID = _nID;
                //        oMapProductGroupItem.Add();
                //    }
                ////}


                foreach (MapProductGroupItem oItem in this)
                {
                    oItem.ID = _nID;
                    oItem.Add();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MapProductGroup SET EmployeeID = ?, MapEmployeeType = ?, MapGroupType = ?, Remarks = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ?, Sort = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("MapEmployeeType", _nMapEmployeeType);
                cmd.Parameters.AddWithValue("MapGroupType", _nMapGroupType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("Sort", _nSort);

                cmd.Parameters.AddWithValue("ID", nID);

                MapProductGroupItem oItems = new MapProductGroupItem();
                oItems.ID = nID;
                oItems.Delete();

                foreach (MapProductGroupItem oItem in this)
                {
                    oItem.ID = nID;
                    oItem.Add();
                }

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
                sSql = "DELETE FROM t_MapProductGroup WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_MapProductGroup where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nMapEmployeeType = (int)reader["MapEmployeeType"];
                    _nMapGroupType = (int)reader["MapGroupType"];
                    _sRemarks = (string)reader["Remarks"];
                    _nIsActive = (int)reader["IsActive"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nSort = (int)reader["Sort"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDataItem(int nID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From t_MapProductGroupItem where ID= ?";

                cmd.Parameters.AddWithValue("ID", nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapProductGroupItem oItem = new MapProductGroupItem();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.DataID = int.Parse(reader["DataID"].ToString());

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
    }
    public class MapProductGroups : CollectionBase
    {
        public MapProductGroup this[int i]
        {
            get { return (MapProductGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MapProductGroup oMapProductGroup)
        {
            InnerList.Add(oMapProductGroup);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM t_MapProductGroup";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapProductGroup oMapProductGroup = new MapProductGroup();
                    oMapProductGroup.ID = (int)reader["ID"];
                    oMapProductGroup.EmployeeID = (int)reader["EmployeeID"];
                    oMapProductGroup.MapEmployeeType = (int)reader["MapEmployeeType"];
                    oMapProductGroup.MapGroupType = (int)reader["MapGroupType"];
                    oMapProductGroup.Remarks = (string)reader["Remarks"];
                    oMapProductGroup.IsActive = (int)reader["IsActive"];
                    oMapProductGroup.CreateUserID = (int)reader["CreateUserID"];
                    oMapProductGroup.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oMapProductGroup.UpdateUserID = (int)reader["UpdateUserID"];
                    oMapProductGroup.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oMapProductGroup.Sort = (int)reader["Sort"];
                    InnerList.Add(oMapProductGroup);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetData(int nEmployeeType, int nGroupType,int nEmployeeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select ID,a.EmployeeID,EmployeeName,DesignationName,MAPEmployeeType, "+
                          " MAPEmployeeTypeName=case when MAPEmployeeType=1 then 'ProductManager' "+
                          " when MAPEmployeeType=2 then 'CategoryManager' else 'Other' end, "+
                          " MAPGroupType,MAPGroupTypeName=case when MAPGroupType=1 then 'Brand' "+
                          " when MAPGroupType=2 then 'MAG' else 'Other' end ,  "+
                          " Remarks,IsActive,Sort,CreateUserID,CreateDate  "+
                          " From t_MapproductGroup a,v_EmployeeDetails b " +
                          " where a.EmployeeID=b.EmployeeID and 1=1 ";

            if (nEmployeeType != -1)
            {
                sSql = sSql + " AND MAPEmployeeType=" + nEmployeeType + "";
            }
            if (nGroupType != -1)
            {
                sSql = sSql + " AND MAPGroupType=" + nGroupType + "";
            }
            if (nEmployeeID != -1)
            {
                sSql = sSql + " AND a.EmployeeID=" + nEmployeeID + "";
            }
            sSql = sSql + " Order by ID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapProductGroup oMapProductGroup = new MapProductGroup();
                    oMapProductGroup.ID = (int)reader["ID"];
                    oMapProductGroup.EmployeeID = (int)reader["EmployeeID"];
                    oMapProductGroup.EmployeeName = (string)reader["EmployeeName"];
                    oMapProductGroup.DesignationName = (string)reader["DesignationName"];
                    oMapProductGroup.MapEmployeeType = (int)reader["MapEmployeeType"];
                    oMapProductGroup.MAPEmployeeTypeName = (string)reader["MAPEmployeeTypeName"];
                    oMapProductGroup.MapGroupType = (int)reader["MapGroupType"];
                    oMapProductGroup.MAPGroupTypeName = (string)reader["MAPGroupTypeName"];
                    oMapProductGroup.Remarks = (string)reader["Remarks"];
                    oMapProductGroup.IsActive = (int)reader["IsActive"];
                    oMapProductGroup.Sort = (int)reader["Sort"];
                    oMapProductGroup.CreateUserID = (int)reader["CreateUserID"];
                    oMapProductGroup.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oMapProductGroup);
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

