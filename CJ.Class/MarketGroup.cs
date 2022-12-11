// <summary>
// Compamy: Transcom Electronics Limited
// Author:.
// Date: April 25, 2011
// Time :  12:00 PM
// Description: Class for Channel.
// Modify Person And Date:Uttam Kar 27-Apr-2014
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class MarketGroup
    {
        private int _MarketGroupID;
        private int _Pos;
        private string _MarketGroupCode;
        private string _MarketGroupDesc;
        private int _MarketGroupType;
        private int _ParentID;
        private int _EmployeeID;
        private int _nChannelID;
        private string _sChannelDescription;

        //Created By: Uttam
        private Channel _oChannel;
        private MarketGroup _oArea;

        /// <summary>
        /// Get set property for MarketGroupID
        /// </summary>
        public int MarketGroupID
        {
            get { return _MarketGroupID; }
            set { _MarketGroupID = value; }
        }

        /// <summary>
        /// Get set property for Pos
        /// </summary>
        public int Pos
        {
            get { return _Pos; }
            set { _Pos = value; }
        }

        /// <summary>
        /// Get set property for MarketGroupCode
        /// </summary>
        public string MarketGroupCode
        {
            get { return _MarketGroupCode; }
            set { _MarketGroupCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MarketGroupDesc
        /// </summary>
        public string MarketGroupDesc
        {
            get { return _MarketGroupDesc; }
            set { _MarketGroupDesc = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MarketGroupType
        /// </summary>
        public int MarketGroupType
        {
            get { return _MarketGroupType; }
            set { _MarketGroupType = value; }
        }

        /// <summary>
        /// Get set property for ParentID
        /// </summary>
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        public string ChannelDescription
        {
            get { return _sChannelDescription; }
            set { _sChannelDescription = value; }
        }

        //uttam
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
        //Uttam
        public MarketGroup MarketDesc
        {
            get
            {
                if (_oArea == null)
                {
                    _oArea = new MarketGroup();
                    _oArea.MarketGroupID = _ParentID;
                    _oArea.Refresh();
                }
                return _oArea;
            }
        }

        //Uttam
        public void Add()
        {
            int nMarketGroupID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX(MarketGroupID) FROM t_MarketGroup";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMarketGroupID = 1;
                }
                else
                {
                    nMarketGroupID = Convert.ToInt32(maxID) + 1;
                }
                _MarketGroupID = nMarketGroupID;

                sSql = "INSERT INTO t_MarketGroup(MarketGroupID,Pos,MarketGroupCode,MarketGroupDesc,MarketGroupType,ParentID,EmployeeID,ChannelID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MarketGroupID", _MarketGroupID);
                cmd.Parameters.AddWithValue("Pos", _Pos);
                cmd.Parameters.AddWithValue("MarketGroupCode", _MarketGroupCode);
                cmd.Parameters.AddWithValue("MarketGroupDesc", _MarketGroupDesc);
                cmd.Parameters.AddWithValue("MarketGroupType", _MarketGroupType);
                if (_ParentID != -1)
                {
                    cmd.Parameters.AddWithValue("ParentID", _ParentID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentID", null);
                }
                if (_EmployeeID != -1)
                {
                    cmd.Parameters.AddWithValue("EmployeeID", _EmployeeID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("EmployeeID", null);
                }
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Uttam
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_MarketGroup SET Pos=?, MarketGroupCode=?, MarketGroupDesc=?, MarketGroupType=?, ParentID=?,EmployeeID=?,ChannelID=?"
                    + " WHERE MarketGroupID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Pos", _Pos);
                cmd.Parameters.AddWithValue("MarketGroupCode", _MarketGroupCode);
                cmd.Parameters.AddWithValue("MarketGroupDesc", _MarketGroupDesc);
                cmd.Parameters.AddWithValue("MarketGroupType", _MarketGroupType);
                if (_ParentID != -1)
                {
                    cmd.Parameters.AddWithValue("ParentID", _ParentID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentID", null);
                }
                //cmd.Parameters.AddWithValue("EmployeeID", _EmployeeID);
                if (_EmployeeID != -1)
                {
                    cmd.Parameters.AddWithValue("EmployeeID", _EmployeeID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("EmployeeID", null);
                }
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);

                cmd.Parameters.AddWithValue("MarketGroupID", _MarketGroupID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Uttam
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_MarketGroup WHERE [MarketGroupID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MarketGroupID", _MarketGroupID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        //Uttam
        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_MarketGroup where  MarketGroupID=?";
            cmd.Parameters.AddWithValue("MarketGroupID", _MarketGroupID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    _Pos = Convert.ToInt32(reader["Pos"].ToString());
                    _MarketGroupCode = reader["MarketGroupCode"].ToString();
                    _MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    _MarketGroupType = Convert.ToInt32(reader["MarketGroupType"].ToString());
                    _ParentID = Convert.ToInt32(reader["ParentID"].ToString());
                    _ParentID = Convert.ToInt32(reader["EmployeeID"].ToString());
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

    }
    public class MarketGroups : CollectionBase
    {
        public MarketGroup this[int i]
        {
            get { return (MarketGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MarketGroup oMarketGroup)
        {
            InnerList.Add(oMarketGroup);
        }
        public int GetIndex(int nMarketGroupID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].MarketGroupID == nMarketGroupID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh()
        {
            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_MarketGroup where ParentID is null";
            //cmd.Parameters.AddWithValue("ParentID", DBNull.Value);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "ALL";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nMarketGroupType)
        {
            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_MarketGroup WHERE MarketGroupType=?";
            cmd.Parameters.AddWithValue("MarketGroupType", nMarketGroupType);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.Pos = int.Parse(reader["Pos"].ToString());
                    oMarketGroup.MarketGroupCode = reader["MarketGroupCode"].ToString();
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    oMarketGroup.MarketGroupType = int.Parse(reader["MarketGroupType"].ToString());
                    //oMarketGroup.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        oMarketGroup.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    }
                    else
                    {
                        oMarketGroup.EmployeeID = -1;
                    }
                    oMarketGroup.ChannelID = int.Parse(reader["ChannelID"].ToString());

                    InnerList.Add(oMarketGroup);
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
        public void RefreshMarketGroupByChannelID(int nMarketGroupType,int nChannelID)
        {
            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_MarketGroup WHERE MarketGroupType=? and ChannelID=?";
            cmd.Parameters.AddWithValue("MarketGroupType", nMarketGroupType);
            cmd.Parameters.AddWithValue("ChannelID", nChannelID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.Pos = int.Parse(reader["Pos"].ToString());
                    oMarketGroup.MarketGroupCode = reader["MarketGroupCode"].ToString();
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    oMarketGroup.MarketGroupType = int.Parse(reader["MarketGroupType"].ToString());
                    //oMarketGroup.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        oMarketGroup.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    }
                    else
                    {
                        oMarketGroup.EmployeeID = -1;
                    }
                    oMarketGroup.ChannelID = int.Parse(reader["ChannelID"].ToString());

                    InnerList.Add(oMarketGroup);
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
        public void GetMarketGroupForTD(int nMarketGroupType)
        {
            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nMarketGroupType == (int)Dictionary.MarketGroupType.Area)
            {
                sSql = "Select distinct Areaid,AreaName from t_Showroom a,v_CustomerDetails b where a.CustomerID = b.CustomerID and IsPOSActive = 1";
            }
            else if (nMarketGroupType == (int)Dictionary.MarketGroupType.Territory)
            {
                sSql = "Select distinct TerritoryID,TerritoryName from t_Showroom a,v_CustomerDetails b where a.CustomerID=b.CustomerID and IsPOSActive=1";
            }
            cmd.Parameters.AddWithValue("MarketGroupType", nMarketGroupType);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    if (nMarketGroupType == (int)Dictionary.MarketGroupType.Area)
                    {
                        oMarketGroup.MarketGroupID = int.Parse(reader["Areaid"].ToString());
                        oMarketGroup.MarketGroupDesc = reader["AreaName"].ToString();
                    }
                    else if (nMarketGroupType == (int)Dictionary.MarketGroupType.Territory)
                    {

                        oMarketGroup.MarketGroupID = int.Parse(reader["TerritoryID"].ToString());
                        oMarketGroup.MarketGroupDesc = reader["TerritoryName"].ToString();
                    }

                    InnerList.Add(oMarketGroup);
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

        public void RefreshCompanyWise(string sCompany, int nMarketGroupType)
        {
            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From  " +
                        "( " +
                        "SELECT a.*,'TEL' as Company FROM TELSYSDB.DBO.t_MarketGroup a  " +
                        "Union All " +
                        "SELECT b.*,'BLL' as Company FROM BLLDBSERVER01.BLLSYSDB.DBO.t_MarketGroup b  " +
                        "Union All " +
                        "SELECT c.*,'TML' as Company FROM TMLSYSDB.DBO.t_MarketGroup c " +
                        ") a where Company='" + sCompany + "' and MarketGroupType=" + nMarketGroupType + "";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.Pos = int.Parse(reader["Pos"].ToString());
                    oMarketGroup.MarketGroupCode = reader["MarketGroupCode"].ToString();
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    oMarketGroup.MarketGroupType = int.Parse(reader["MarketGroupType"].ToString());
                    //oMarketGroup.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        oMarketGroup.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    }
                    else
                    {
                        oMarketGroup.EmployeeID = -1;
                    }
                    oMarketGroup.ChannelID = int.Parse(reader["ChannelID"].ToString());

                    InnerList.Add(oMarketGroup);
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

        //public void RefreshAll()
        //{
        //    MarketGroup oMarketGroup;
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "SELECT * FROM t_MarketGroup";
        //    //cmd.Parameters.AddWithValue("MarketGroupType", nMarketGroupType);
        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            oMarketGroup = new MarketGroup();
        //            oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
        //            oMarketGroup.Pos = int.Parse(reader["Pos"].ToString());
        //            oMarketGroup.MarketGroupCode = reader["MarketGroupCode"].ToString();
        //            oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
        //            oMarketGroup.MarketGroupType = int.Parse(reader["MarketGroupType"].ToString());
        //            if (reader["EmployeeID"] != DBNull.Value)
        //            {
        //                oMarketGroup.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
        //            }
        //            else
        //            {
        //                oMarketGroup.EmployeeID = -1;
        //            }
        //            oMarketGroup.ChannelID = int.Parse(reader["ChannelID"].ToString());

        //            InnerList.Add(oMarketGroup);
        //        }

        //        reader.Close();

        //        oMarketGroup = new MarketGroup();
        //        oMarketGroup.MarketGroupID = -1;
        //        oMarketGroup.MarketGroupDesc = "ALL";
        //        InnerList.Add(oMarketGroup);
        //        InnerList.TrimToSize();

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }

        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void GetArea(int nUserID)
        {
            Users oUsers = new Users();
            string sPermission = oUsers.GetDataID(nUserID, "Area");
            if (sPermission == "")
                return;

            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_MarketGroup where MarketGroupType = 1 and MarketGroupID in (" + sPermission + ")";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "ALL";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllArea()
        {
            Users oUsers = new Users();
          
            

            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_MarketGroup where MarketGroupType = 1 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "ALL";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTerritory(int nUserID)
        {
            Users oUsers = new Users();
            string sPermission = oUsers.GetDataID(nUserID, "Territory");
            if (sPermission == "")
                return;

            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_MarketGroup where MarketGroupType = 2 and MarketGroupID in (" + sPermission + ")";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "ALL";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DMSGetRegion()
        {

            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_MarketGroup where MarketGroupType = 0 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "ALL";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void DMSGetArea(int nParentid)
        {
            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_MarketGroup where parentid = ?";
            cmd.Parameters.AddWithValue("parentid", nParentid);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "ALL";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }


        }

        public void DMSGetTerritory(int nParentID)
        {

            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql;

            sSql = " select * from t_MarketGroup where parentid = ?";

            cmd.Parameters.AddWithValue("parentid", nParentID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "ALL";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void DMSGetRegionBY()
        {

            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_MarketGroup where MarketGroupType = 0 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "Select";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void DMSGetAreaBy(int nParentid)
        {
            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_MarketGroup where parentid = ?";
            cmd.Parameters.AddWithValue("parentid", nParentid);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "Select";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }


        }

        public void DMSGetTerritoryBy(int nParentID)
        {

            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql;

            sSql = " select * from t_MarketGroup where parentid = ?";

            cmd.Parameters.AddWithValue("parentid", nParentID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "Select";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void DMSGetTerritoryALl(int nParentID)
        {

            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql;

            sSql = " select * from t_MarketGroup where parentid = ?";

            cmd.Parameters.AddWithValue("parentid", nParentID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();

                oMarketGroup = new MarketGroup();
                oMarketGroup.MarketGroupID = -1;
                oMarketGroup.MarketGroupDesc = "ALL";
                InnerList.Add(oMarketGroup);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetParentID()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT MarketGroupID,MarketGroupDesc FROM t_MarketGroup  WHERE marketGroupType=1";
            MarketGroup oMarketGroup;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetAreaWiseTerritory(int nParentID)
        {
            MarketGroup oMarketGroup;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql;

            sSql = " select * from t_MarketGroup where parentid = ?";

            cmd.Parameters.AddWithValue("parentid", nParentID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarketGroup = new MarketGroup();
                    oMarketGroup.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oMarketGroup.MarketGroupDesc = reader["MarketGroupDesc"].ToString();
                    InnerList.Add(oMarketGroup);
                }

                reader.Close();
                //InnerList.Add(oMarketGroup);
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
