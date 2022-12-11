// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: March 31, 2011
// Time : 11:00 AM
// Description: class for warehouse.
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
    public class Warehouse
    {
        private string _sWarehouseParentName;
        private string _sWarehouseName;
        private string _sWarehouseCode;
        private string _sShortcode;
        private int _nWarehouseParentID;
        private int _nStockType;//Uttam
        private int _nIsActive;//uttam
        private int _nWarehouseID;
        private int _nChannelID;
        private int _nWarehouseType;//uttam
        private int _nViewPosition;//uttam
        private int _nThanaID;//uttam
        private string _sRemark;//uttam
        private int _nLocationID;
        //private string _sShortCode;//uttam
        private int _nShowroomID;
        private double _CPCreditLimit;
        private string _sAddress;
        private int _nWarehouseGroupID;
        private string _sWarehouseGroupName;
        public string WarehouseGroupName
        {
            get { return _sWarehouseGroupName; }
            set { _sWarehouseGroupName = value; }
        }
        public int WarehouseGroupID
        {
            get { return _nWarehouseGroupID; }
            set { _nWarehouseGroupID = value; }
        }

        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        private ParentWarehouse _oParentWarehouse;
        private Channel _oChannel;

        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        public int ShowroomID
        {
            get { return _nShowroomID; }
            set { _nShowroomID = value; }
        }
        public string WarehouseParentName
        {
            get { return _sWarehouseParentName; }
            set { _sWarehouseParentName = value; }
        }

        private string _sWarehouseDetail;
        public string WarehouseDetail
        {
            get { return _sWarehouseDetail; }
            set { _sWarehouseDetail = value; }
        }
        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }
        public string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }
        public string Shortcode
        {
            get { return _sShortcode; }
            set { _sShortcode = value; }
        }
        public int WarehouseParentID
        {
            get { return _nWarehouseParentID; }
            set { _nWarehouseParentID = value; }
        }
        //uttam
        public int StockType
        {
            get { return _nStockType; }
            set { _nStockType = value; }
        }
        //uttam
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        //uttam
        public int WarehouseType
        {
            get { return _nWarehouseType; }
            set { _nWarehouseType = value; }
        }
        //uttam
        public int ViewPosition
        {
            get { return _nViewPosition; }
            set { _nViewPosition = value; }
        }
        //uttam
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }
        //uttam
        public string Remark
        {
            get { return _sRemark; }
            set { _sRemark = value; }
        }
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }
        //uttam
        //public string ShortCode
        //{
        //    get { return _sShortCode; }
        //    set { _sShortCode = value; }
        //}
        public double CPCreditLimit
        {
            get { return _CPCreditLimit; }
            set { _CPCreditLimit = value; }
        }

        //uttam
        public ParentWarehouse ParentWarehouse
        {
            get
            {
                if (_oParentWarehouse == null)
                {
                    _oParentWarehouse = new ParentWarehouse();
                    _oParentWarehouse.WarehouseParentID = _nWarehouseParentID;
                    _oParentWarehouse.Refresh();
                }
                return _oParentWarehouse;
            }
        }
        public Channel ChnnelDesc 
        {
            get
            {
                if (_oChannel == null)
                {
                    _oChannel = new Channel();
                    _oChannel.ChannelID = _nChannelID;
                    _oChannel.Refresh();
                }
                return _oChannel;
            }
        }

        public void Reresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_Warehouse where warehouseid=?";
            cmd.Parameters.AddWithValue("warehouseid", _nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sWarehouseName = (string)reader["WarehouseName"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sWarehouseCode = (string)reader["WarehouseCode"];
                    _nChannelID = (int)reader["ChannelID"];
                    if (reader["Shortcode"] != DBNull.Value)
                        _sShortcode = reader["Shortcode"].ToString();
                    else _sShortcode = "";
                    _nWarehouseParentID = (int)reader["WarehouseParentID"];
                    if (reader["LocationID"] != DBNull.Value)
                        _nLocationID = (int)reader["LocationID"];
                    else _nLocationID = 0;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetRetailWarehouse()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From  " +
                        "(  " +
                        "select a.WarehouseID,WarehouseCode,WarehouseName,a.ChannelID,  " +
                        "Shortcode,WarehouseParentID,a.LocationID,ShowroomAddress as Address  " +
                        "from t_Warehouse a,t_Showroom b where a.WarehouseID=b.WarehouseID  " +
                        "Union All   " +
                        "Select 70,14,'Central Retail Warehouse',4,'HO',6,1,'Sadar Road,Mohakhali,Dhaka-1206'  " +
                        ") Main where WarehouseID=?";

            cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sWarehouseName = (string)reader["WarehouseName"];
                    _nWarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());
                    _sWarehouseCode = Convert.ToString(reader["WarehouseCode"].ToString());
                    _nChannelID = Convert.ToInt32(reader["ChannelID"].ToString());
                    if (reader["Shortcode"] != DBNull.Value)
                        _sShortcode = reader["Shortcode"].ToString();
                    else _sShortcode = "";
                    _nWarehouseParentID = Convert.ToInt32(reader["WarehouseParentID"].ToString());
                    if (reader["LocationID"] != DBNull.Value)
                        _nLocationID = Convert.ToInt32(reader["LocationID"].ToString());
                    else _nLocationID = 0;
                    if (reader["Address"] != DBNull.Value)
                        _sAddress = reader["Address"].ToString();
                    else _sAddress = "";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RereshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_Warehouse where warehousecode=?";
            cmd.Parameters.AddWithValue("warehousecode", _sWarehouseCode);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sWarehouseName = (string)reader["WarehouseName"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sWarehouseCode = (string)reader["WarehouseCode"];
                    _nChannelID = (int)reader["ChannelID"];
                    if (reader["Shortcode"] != DBNull.Value)
                        _sShortcode = reader["Shortcode"].ToString();
                    else _sShortcode = "";
                    _nWarehouseParentID = (int)reader["WarehouseParentID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void POSReresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_Warehouse where warehouseid=?";
            cmd.Parameters.AddWithValue("warehouseid", _nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sWarehouseName = (string)reader["WarehouseName"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sWarehouseCode = (string)reader["WarehouseCode"];
                    if (reader["Shortcode"] != DBNull.Value)
                        _sShortcode = reader["Shortcode"].ToString();
                    else _sShortcode = "";

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetParentWarehouseByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_warehouse inner join  t_warehouseparent on t_warehouse.WarehouseParentID=t_warehouseparent.WarehouseParentID where warehouseid=?";
            cmd.Parameters.AddWithValue("warehouseid", _nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nWarehouseParentID = (int)reader["WarehouseParentID"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        ///
        // Get Show ID from Cassiopeia
        ///
        public void GetShowroomID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from Cassiopeia_HO.dbo.Showroom where Code=?";
            cmd.Parameters.AddWithValue("Code", _sShortcode);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nShowroomID = (int)reader["ShowroomID"];
                    _CPCreditLimit = Convert.ToDouble(reader["CreditLimit"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #region Web Service Functions

        /// <summary>
        /// Web Service Functions
        /// </summary>
        /// 

        public int POSGetParentWarehouse(int nWarehouseID)
        {
            _nWarehouseID = nWarehouseID;

            GetParentWarehouseByID();

            return _nWarehouseParentID;
        }

        #endregion

        //Uttam: create date 05-May-2014
        public void Add()
        {
            int nWarehouseID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([WarehouseID]) FROM t_warehouse";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nWarehouseID = 1;
                }
                else
                {
                    nWarehouseID = Convert.ToInt32(maxID) + 1;
                }
                _nWarehouseID = nWarehouseID;

                sSql = "INSERT INTO t_warehouse(WarehouseID,WarehouseCode,WarehouseName,WarehouseParentID,StockType,IsActive,ChannelID,WarehouseType, " +
                       "ViewPosition,ThanaID,Remark,LocationID,ShortCode) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("WarehouseCode", _sWarehouseCode);
                cmd.Parameters.AddWithValue("WarehouseName", _sWarehouseName);
                cmd.Parameters.AddWithValue("WarehouseParentID", _nWarehouseParentID);
                cmd.Parameters.AddWithValue("StockType", _nStockType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("WarehouseType", _nWarehouseType);
                cmd.Parameters.AddWithValue("ViewPosition", _nViewPosition);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("Remark", _sRemark);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("ShortCode", _sShortcode);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Uttam: create date 05-May-2014
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_warehouse where WarehouseID =?";
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sWarehouseCode = reader["WarehouseCode"].ToString();

                    _sWarehouseName = reader["WarehouseName"].ToString();
                    _nWarehouseParentID = int.Parse(reader["WarehouseParentID"].ToString());
                    _nStockType = int.Parse(reader["StockType"].ToString());
                    _nIsActive = int.Parse(reader["IsActive"].ToString());
                    _nChannelID = int.Parse(reader["ChannelID"].ToString());
                    _nWarehouseType = int.Parse(reader["WarehouseType"].ToString());
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool ChkChkCentralWarehouse(int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From v_WarehouseDetails where WarehouseGroupName='Saleable' and WarehouseParentID=6 and WarehouseID=" + nWarehouseID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount > 0)
            {

                return false;
            }
            else
            {
                return true;
            }
        }
        //Uttam: create date 05-May-2014
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_warehouse SET WarehouseCode=?, WarehouseName=?, WarehouseParentID=?, StockType=?, IsActive=?,ChannelID=?,WarehouseType=?"
                    + ",ViewPosition=?,ThanaID=?,Remark=?,LocationID=?,ShortCode=? WHERE WarehouseID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseCode", _sWarehouseCode);
                cmd.Parameters.AddWithValue("WarehouseName", _sWarehouseName);
                cmd.Parameters.AddWithValue("WarehouseParentID", _nWarehouseParentID);
                cmd.Parameters.AddWithValue("StockType", _nStockType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("WarehouseType", _nWarehouseType);
                cmd.Parameters.AddWithValue("ViewPosition", _nViewPosition);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("Remark", _sRemark);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("ShortCode", _sShortcode);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Uttam: create date 05-May-2014
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_Warehouse WHERE [WarehouseID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void ResetVatChallan()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_NextDocumentNo SET NextVatChallanNo='1', NextIVChallanNo='1' WHERE WarehouseID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }


    public class Warehouses : CollectionBase
    {

        public Warehouse this[int i]
        {
            get { return (Warehouse)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(Warehouse oWarehouse)
        {
            InnerList.Add(oWarehouse);
        }
        public int GetIndex(int nWarehouseID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarehouseID == nWarehouseID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetIndexParentWarehouse(int nParentWarehouseID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarehouseParentID == nParentWarehouseID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void GetWarehouseName(string sParentWarehouseName)
        {
            int CarryParentWarehouseID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select WarehouseParentID from t_WarehouseParent where WarehouseParentName='" + sParentWarehouseName + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Warehouse oWarehouseParentID = new Warehouse();
                    CarryParentWarehouseID = (int)reader["WarehouseParentID"];

                }
                reader.Close();
                sSql = "select WarehouseName from t_Warehouse where WarehouseParentID='" + CarryParentWarehouseID + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    Warehouse oWarehouse = new Warehouse();
                    oWarehouse.WarehouseName = (string)reader1["WarehouseName"];
                    InnerList.Add(oWarehouse);
                }
                reader1.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }               
          
        }
        public void GetWarehouseName(int nChannelID,string sWarehouse,int nUserID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "";
            if (nUserID != 0)
            {
                sSql = " select a.*,b.* from t_Warehouse a ,t_UserPermissionData b "
                               + " where b.DataID=a.warehouseid and a.ChannelID=? and b.UserID=? and DataType='Warehouse' Order by ViewPosition";


                cmd.Parameters.AddWithValue("ChannelID", nChannelID);
                cmd.Parameters.AddWithValue("userid", nUserID);
            }
            else
            {
                sSql = " select * from t_Warehouse  "
                              + " where ChannelID=? Order by ViewPosition ";
                cmd.Parameters.AddWithValue("ChannelID", nChannelID);
              
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];                    
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                    nCount++;
                }
                reader.Close();
               
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetWarehouse()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select * from t_Warehouse where warehouseid <>1 order by WarehouseName ";         
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseCode = (string)reader["WarehouseCode"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = -1;
                _oWarehouse.WarehouseName = "<ALL>";
                InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetBLLLightWarehouse()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = " select * from BLLSysDB.dbo.t_Warehouse where warehouseid <>1 and WarehouseCode in (22,12,11,1,132,42) order by WarehouseName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = -1;
                _oWarehouse.WarehouseName = "ALL";
                InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetLightWarehouse(int nCompanyID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;

            string sSql;

            if (nCompanyID == 82941)
            {
                sSql = " select * from t_Warehouse where warehouseid <>1 and WarehouseCode in (22,12,1, 99, 42) order by WarehouseName ";
            }
            else 
            {
                sSql = "select * from BLLSysDB.dbo.t_Warehouse where warehouseid <>1 and WarehouseCode in (22,12,11,1,132,42) order by WarehouseName ";
            }
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = -1;
                _oWarehouse.WarehouseName = "ALL";
                InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetWarehouseParents()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse oWarehouse;
            string sSql = "select * from t_WarehouseParent where WarehouseParentID<>1 order by WarehouseParentName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseParentName = (string)reader["WarehouseParentName"];
                    oWarehouse.WarehouseParentID = (int)reader["WarehouseParentID"];
                    oWarehouse.Address = (string)reader["Description"];
                    InnerList.Add(oWarehouse);
                }
                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetWarehouseParent()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse oWarehouse;
            string sSql = "select * from t_WarehouseParent where WarehouseParentID<>1 order by WarehouseParentName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseParentName = (string)reader["WarehouseParentName"];
                    oWarehouse.WarehouseParentID = (int)reader["WarehouseParentID"];
                    InnerList.Add(oWarehouse);
                }
                reader.Close();

                oWarehouse = new Warehouse();
                oWarehouse.WarehouseParentID = -1;
                oWarehouse.WarehouseParentName = "<ALL>";
                InnerList.Add(oWarehouse);

                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetWarehouseGroup()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse oWarehouse;
            string sSql = "select* from t_WarehouseGroup ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseGroupName = (string)reader["WarehouseGroupName"];
                    oWarehouse.WarehouseGroupID = (int)reader["WarehouseGroupID"];
                    InnerList.Add(oWarehouse);
                }
                reader.Close();

                oWarehouse = new Warehouse();
                oWarehouse.WarehouseGroupID = -1;
                oWarehouse.WarehouseGroupName = "<ALL>";
                InnerList.Add(oWarehouse);

                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetWarehouseAgainstGroup(int nWHGroup, int nWHParent)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select a.WarehouseID,'['+a.WarehouseCode+'] '+WarehouseName as [WarehouseName] from dbo.t_Warehouse a  INNER JOIN dbo.t_WarehouseGroupMapping ON a.WarehouseID = dbo.t_WarehouseGroupMapping.WarehouseID "
                + "INNER JOIN dbo.t_WarehouseParent ON a.WarehouseParentID = dbo.t_WarehouseParent.WarehouseParentID "
                        + "INNER JOIN dbo.t_WarehouseGroup ON dbo.t_WarehouseGroupMapping.WarehouseGroupID = dbo.t_WarehouseGroup.WarehouseGroupID ";

            sSql = sSql + "where 1=1 ";
            if (nWHGroup > -1)
            {
                sSql = sSql + " and dbo.t_WarehouseGroup.WarehouseGroupID=" + nWHGroup + "";
            }
            if(nWHParent >-1)
            {
                sSql = sSql + " and dbo.t_WarehouseParent.WarehouseParentID=" + nWHParent + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = -1;
                _oWarehouse.WarehouseName = "<ALL>";
                InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllWarehouse()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select * from t_Warehouse where warehouseid <>1 order by WarehouseName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    _oWarehouse.ChannelID = (int)reader["ChannelID"];
                    if (reader["Shortcode"] != DBNull.Value)
                        _oWarehouse.Shortcode = reader["Shortcode"].ToString();
                    else _oWarehouse.Shortcode = "";

                    //_oWarehouse.WarehouseDetail = '[' + (string)reader["WarehouseParentCode"] + ']' + _oWarehouse.WarehouseName;

                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = -1;
                _oWarehouse.WarehouseName = "<Select Warehouse Name>";
                InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAllWarehouseNew()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select * from v_WarehouseDetails where warehouseid <>1 order by WarehouseName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    _oWarehouse.ChannelID = (int)reader["ChannelID"];
                    if (reader["Shortcode"] != DBNull.Value)
                        _oWarehouse.Shortcode = reader["Shortcode"].ToString();
                    else _oWarehouse.Shortcode = "";

                    _oWarehouse.WarehouseDetail = '[' + (string)reader["WarehouseParentCode"] + ']' + _oWarehouse.WarehouseName;

                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = -1;
                _oWarehouse.WarehouseDetail = "<Select Warehouse Name>";
                InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllShowroom()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select * from t_Warehouse a , t_WarehouseParent b where a.WarehouseParentID = b.WarehouseParentID and a.WarehouseParentID = 7 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = -1;
                _oWarehouse.WarehouseName = "ALL";
                InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetGiftVoucherTransferWH()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            Warehouse _oWarehouse;
            string sSql = "Select * from t_Warehouse Where WarehouseParentID=7 UNION ALL Select * from t_Warehouse Where WarehouseCode=14";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                //_oWarehouse = new Warehouse();
                //_oWarehouse.WarehouseID = -1;
                //_oWarehouse.WarehouseName = "ALL";
                //InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetEPSWarehouse()
        {
            int nEPSWarehouse = Utility.EPSWarehouse;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select * from t_Warehouse where warehouseid in (?) order by WarehouseName ";
            cmd.Parameters.AddWithValue("warehouseid", nEPSWarehouse);   

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();               
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetWebStore()
        {
            int nWebStore = Utility.WebStore;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select * from t_Warehouse where warehouseid in (?) order by WarehouseName ";
            cmd.Parameters.AddWithValue("warehouseid", nWebStore);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetFromWarehouseForPOS(int nUserID)
        {
            bool _bAuthorize= false;
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            Users oUsers = new Users();
            oUsers.AllPermission(nUserID);

            foreach (User oUser in oUsers)
            {
                if (oUser.Permission == "M1.60" || oUser.Permission == "M1.58")
                {
                    _bAuthorize = true;
                    break;
                }
            }

            if (_bAuthorize)
            {
                sSql = "select * from t_Warehouse";
            }
            else
            {
                sSql = " select a.* from t_Warehouse a ,t_UserPermissionData b "
                            + " where b.DataID=a.warehouseid and b.UserID=? and DataType='Warehouse' ";

                cmd.Parameters.AddWithValue("userid", nUserID);
            }           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetToWarehouseForPOS(int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;

            string sSql = "select * from t_Warehouse Where WarehouseID in (select ToWH from t_ProductRequisitionWH Where FromWH ='" + nWarehouseID + "')";

         
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetRetailWarehouseForPOS()//Hakim
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;

            string sSql = "select WarehouseID,WarehouseName from t_Warehouse Where channelID=4 and IsActive <> 0 and " +
                            "WarehouseParentID=7 and WarehouseID NOT IN (81,118,119) order by WarehouseName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetWarehousByChannel(int nChannelID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;

            string sSql = "select * from t_Warehouse Where ChannelID=?";

            cmd.Parameters.AddWithValue("ChannelID", nChannelID);         

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseCode = (string)reader["WarehouseCode"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllWarehousByChannel(int nChannelID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;

            string sSql = "select * from v_WarehouseDetails Where ChannelID=?";

            cmd.Parameters.AddWithValue("ChannelID", nChannelID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    _oWarehouse.WarehouseParentID = (int)reader["WarehouseParentID"];
                    _oWarehouse.WarehouseDetail = '[' + (string)reader["WarehouseParentCode"] + ']' + _oWarehouse.WarehouseName;
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();
                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = -1;
                _oWarehouse.WarehouseName = "<Select WarehouseName>";
                _oWarehouse.WarehouseDetail = "<Select WarehouseName>";
                InnerList.Add(_oWarehouse);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetWarehouseForPromotion()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select a.* from t_Warehouse a,t_Showroom b where a.WarehouseID=b.WarehouseID and IsPosActive=1 order by WarehouseName";
            cmd.Parameters.AddWithValue("WarehouseParentID", Utility.PromotionParentWHID);
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.ActiveOrInActiveStatus.ACTIVE); 

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    _oWarehouse.Shortcode = reader["Shortcode"].ToString();
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();            

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPOSShowroom()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            string sSql = "select * from t_Warehouse a,t_Employee b where a.LocationID=b.LocationID and b.EmployeeID='" + Utility.EmployeeID + "' ";
    
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();            

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetFromWarehouseByUser(int nUserID)
        {
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
                sSql = " select a.* from t_Warehouse a ,t_UserPermissionData b "
                            + " where b.DataID=a.warehouseid and b.UserID=? and DataType='Warehouse' ";

                cmd.Parameters.AddWithValue("userid", nUserID);
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetStockReqDeliveryWH(int nParentWHID)
        {
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            sSql = "Select WarehouseID,WarehouseCode,WarehouseName,isnull(ShortCode,'') ShortCode,WarehouseAddress From v_WarehouseDetails where WarehouseGroupName='Saleable' and WarehouseParentID=" + nParentWHID + " order by WarehouseName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseCode = (string)reader["WarehouseCode"];
                    _oWarehouse.Shortcode = (string)reader["Shortcode"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];

                    _oWarehouse.Address = (string)reader["WarehouseAddress"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetStockByParent(int nParentWHID)
        {
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Warehouse _oWarehouse;
            sSql = "Select WarehouseID,WarehouseCode,WarehouseName,isnull(ShortCode,'') ShortCode,WarehouseAddress From v_WarehouseDetails where WarehouseParentID=" + nParentWHID + " order by WarehouseName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseCode = (string)reader["WarehouseCode"];
                    _oWarehouse.Shortcode = (string)reader["Shortcode"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];

                    _oWarehouse.Address = (string)reader["WarehouseAddress"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetMappedWHForShowroom(int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            string sMAPWarehouse = "";
            sSql = "Select MappedWarehouseID From t_Showroom where WarehouseID=" + nWHID + "";
            cmd.CommandText = sSql;
            object maxID = cmd.ExecuteScalar();
            if (maxID == DBNull.Value)
            {
                sMAPWarehouse = "174";
            }
            else
            {
                sMAPWarehouse = Convert.ToString(maxID);
            }
                        
            
            Warehouse _oWarehouse;
            sSql = "Select WarehouseID,WarehouseCode,WarehouseName,isnull(ShortCode,'') ShortCode,WarehouseAddress From v_WarehouseDetails where WarehouseID in (" + sMAPWarehouse + ")";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseName = (string)reader["WarehouseName"];
                    _oWarehouse.WarehouseCode = (string)reader["WarehouseCode"];
                    _oWarehouse.Shortcode = (string)reader["Shortcode"];
                    _oWarehouse.WarehouseID = (int)reader["WarehouseID"];

                    _oWarehouse.Address = (string)reader["WarehouseAddress"];
                    InnerList.Add(_oWarehouse);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Uttam: create date 05-May-2014
        public void Refresh(string sCode, string sCustomerName)
        {
            Warehouse oWarehouse;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_warehouse Where 1=1";
            if (sCode != "")
            {
                sSql = sSql + " AND WarehouseCode = '" + sCode + "'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND WarehouseName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by WarehouseCode";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oWarehouse.WarehouseCode = reader["WarehouseCode"].ToString();
                    oWarehouse.WarehouseName = reader["WarehouseName"].ToString();
                    oWarehouse.WarehouseParentID = int.Parse(reader["WarehouseParentID"].ToString());
                    oWarehouse.StockType = int.Parse(reader["StockType"].ToString());
                    oWarehouse.IsActive = int.Parse(reader["IsActive"].ToString());
                    oWarehouse.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oWarehouse.WarehouseType = int.Parse(reader["WarehouseType"].ToString());
                    if (reader["ThanaID"] != DBNull.Value)
                        oWarehouse.ThanaID = int.Parse(reader["ThanaID"].ToString());
                    if (reader["LocationID"] != DBNull.Value)
                        oWarehouse.LocationID = int.Parse(reader["LocationID"].ToString());
                    if (reader["ViewPosition"] != DBNull.Value)
                        oWarehouse.ViewPosition = int.Parse(reader["ViewPosition"].ToString());
                    if (reader["Shortcode"] != DBNull.Value)
                        oWarehouse.Shortcode = (string)reader["ShortCode"];
                    if (reader["Remark"] != DBNull.Value)
                        oWarehouse.Remark = (string)reader["Remark"];
                    InnerList.Add(oWarehouse);
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

        public void GetWarehouseForVat()
        {
            Warehouse oWarehouse;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_NextDocumentNo";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    InnerList.Add(oWarehouse);
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

        //Shuvo: create date 02-Dec-2015
        public void GetWHForGRD(int nChannelID)
        {
            Warehouse oWarehouse;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_Warehouse where WarehouseParentID in (9,6) and ChannelID = ? ";

            cmd.Parameters.AddWithValue("ChannelID", nChannelID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oWarehouse.WarehouseCode = reader["WarehouseCode"].ToString();
                    oWarehouse.WarehouseName = reader["WarehouseName"].ToString();
                    oWarehouse.WarehouseParentID = int.Parse(reader["WarehouseParentID"].ToString());
                    oWarehouse.StockType = int.Parse(reader["StockType"].ToString());
                    oWarehouse.IsActive = int.Parse(reader["IsActive"].ToString());
                    oWarehouse.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oWarehouse.WarehouseType = int.Parse(reader["WarehouseType"].ToString());
                    oWarehouse.ThanaID = int.Parse(reader["ThanaID"].ToString());
                    oWarehouse.LocationID = int.Parse(reader["LocationID"].ToString());
                    InnerList.Add(oWarehouse);
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

        #region Web Service Functions

        /// <summary>
        /// Web Service Functions
        /// </summary>
        /// 

        public DSWarehouse POSGetWarehouse(DSWarehouse oDSWarehouse)
        {
            int nUserID = 0;
            //nUserID = int.Parse(oDSWarehouse.Warehouse[0].UserID.ToString());
            GetFromWarehouseForPOS(nUserID);

            oDSWarehouse = new DSWarehouse();

            foreach (Warehouse oWarehouse in this)
            {
                DSWarehouse.WarehouseRow oWarehouseRow = oDSWarehouse.Warehouse.NewWarehouseRow();

                oWarehouseRow.WarehouseName = oWarehouse.WarehouseName;
                oWarehouseRow.WarehouseID = oWarehouse.WarehouseID;

                oDSWarehouse.Warehouse.AddWarehouseRow(oWarehouseRow);
                oDSWarehouse.AcceptChanges();
            }

            return oDSWarehouse;
        }

        public DSWarehouse POSGetToWarehouse(DSWarehouse oDSWarehouse, string sWarehouseID)
        {
            int nWarehouseID = 0;
            nWarehouseID = int.Parse(sWarehouseID);
            GetToWarehouseForPOS(nWarehouseID);

            oDSWarehouse = new DSWarehouse();

            foreach (Warehouse oWarehouse in this)
            {
                DSWarehouse.WarehouseRow oWarehouseRow = oDSWarehouse.Warehouse.NewWarehouseRow();

                oWarehouseRow.WarehouseName = oWarehouse.WarehouseName;
                oWarehouseRow.WarehouseID = oWarehouse.WarehouseID;

                oDSWarehouse.Warehouse.AddWarehouseRow(oWarehouseRow);
                oDSWarehouse.AcceptChanges();
            }

            return oDSWarehouse;
        }

        public DSWarehouse POSGetAllWarehouse(DSWarehouse oDSWarehouse)
        {
            GetAllWarehouse();

            oDSWarehouse = new DSWarehouse();

            foreach (Warehouse oWarehouse in this)
            {
                DSWarehouse.WarehouseRow oWarehouseRow = oDSWarehouse.Warehouse.NewWarehouseRow();

                oWarehouseRow.WarehouseName = oWarehouse.WarehouseName;
                oWarehouseRow.WarehouseID = oWarehouse.WarehouseID;

                oDSWarehouse.Warehouse.AddWarehouseRow(oWarehouseRow);
                oDSWarehouse.AcceptChanges();
            }

            return oDSWarehouse;
        }

        #endregion
    }


    //This Class Created By Uttam And Suggest by Mr. Arif Khan
    public class ParentWarehouse
    {
        private int _nWarehouseParentID;
        private string _sWarehouseParentCode;
        private string _sWarehouseParentName;

        public int WarehouseParentID
        {
            get { return _nWarehouseParentID; }
            set { _nWarehouseParentID = value; }
        }
        public string WarehouseParentCode
        {
            get { return _sWarehouseParentCode; }
            set { _sWarehouseParentCode = value; }
        }
        public string WarehouseParentName
        {
            get { return _sWarehouseParentName; }
            set { _sWarehouseParentName = value; }
        }

        //Uttam: Crate date 05-May-2014
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_warehouseparent where WarehouseParentID=?";
            cmd.Parameters.AddWithValue("WarehouseParentID", _nWarehouseParentID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sWarehouseParentCode = (string)reader["WarehouseParentCode"];
                    _sWarehouseParentName = (string)reader["WarehouseParentName"];
                   
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Uttam: Crate date 05-May-2014
        public void Add()
        {
            int nWarehouseParentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([WarehouseParentID]) FROM t_warehouseparent";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nWarehouseParentID = 1;
                }
                else
                {
                    nWarehouseParentID = Convert.ToInt32(maxID) + 1;
                }
                _nWarehouseParentID = nWarehouseParentID;

                sSql = "INSERT INTO t_warehouseparent(WarehouseParentID,WarehouseParentCode,WarehouseParentName) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseParentID", _nWarehouseParentID);
                cmd.Parameters.AddWithValue("WarehouseParentCode", _sWarehouseParentCode);
                cmd.Parameters.AddWithValue("WarehouseParentName", _sWarehouseParentName);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Uttam: Crate date 05-May-2014
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_warehouseparent WHERE [WarehouseParentID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseParentID", _nWarehouseParentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        //Uttam:Crate date 05-May-2014
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "UPDATE t_warehouseparent SET WarehouseParentCode=?, WarehouseParentName=? WHERE WarehouseParentID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseParentCode", _sWarehouseParentCode);
                cmd.Parameters.AddWithValue("WarehouseParentName", _sWarehouseParentName);
                cmd.Parameters.AddWithValue("WarehouseParentID", _nWarehouseParentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }

    public class ParentWarehouses : CollectionBase
    {

        public ParentWarehouse this[int i]
        {
            get { return (ParentWarehouse)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ParentWarehouse oParentWarehouse)
        {
            InnerList.Add(oParentWarehouse);
        }
        public int GetIndex(int nWarehouseParentID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarehouseParentID == nWarehouseParentID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh()
        {
            ParentWarehouse oParentWarehouse;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_warehouseparent";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oParentWarehouse = new ParentWarehouse();
                    oParentWarehouse.WarehouseParentID = (int)reader["WarehouseParentID"];
                    oParentWarehouse.WarehouseParentCode = (string)reader["WarehouseParentCode"];
                    oParentWarehouse.WarehouseParentName = (string)reader["WarehouseParentName"];
                    InnerList.Add(oParentWarehouse);
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
        public void RefreshByWarehouse()
        {
            ParentWarehouse oParentWarehouse;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_warehouse";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oParentWarehouse = new ParentWarehouse();
                    oParentWarehouse.WarehouseParentID = (int)reader["WarehouseID"];
                    oParentWarehouse.WarehouseParentCode = (string)reader["WarehouseCode"];
                    oParentWarehouse.WarehouseParentName = (string)reader["WarehouseName"];
                    InnerList.Add(oParentWarehouse);
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
    }
}
