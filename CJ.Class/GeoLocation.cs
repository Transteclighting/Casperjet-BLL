// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 19, 2011
// Time :  10:00 AM
// Description: Class for DMS Market Information.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class GeoLocation
    {
        private int _nGeoLocationID;
        private string _sGeoLocationCode;
        private string _sGeoLocationName;
        private int _nGeoLocationType;
        private int _nParentID;
        private string _sGeoLocationCategory;


        private int _nThanaID;
        private string _sThanaCode;
        private string _sThanaName;

        private int _nDistrictID;
        private string _sDistrictCode;
        private string _sDistrictName;


        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }

        public string ThanaCode
        {
            get { return _sThanaCode; }
            set { _sThanaCode = value; }
        }

        public string ThanaName
        {
            get { return _sThanaName; }
            set { _sThanaName = value; }
        }




        //Written by Rifat Farhana: 18-May-2014
        private GeoLocation _oParentDistrict;

        /// <summary>
        /// Get set property for GeoLocationID
        /// </summary>
        public int GeoLocationID
        {
            get { return _nGeoLocationID; }
            set { _nGeoLocationID = value; }
        }

        /// <summary>
        /// Get set property for GeoLocationCode
        /// </summary>
        public string GeoLocationCode
        {
            get { return _sGeoLocationCode; }
            set { _sGeoLocationCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for GeoLocationName
        /// </summary>
        public string GeoLocationName
        {
            get { return _sGeoLocationName; }
            set { _sGeoLocationName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for GeoLocationType
        /// </summary>
        public int GeoLocationType
        {
            get { return _nGeoLocationType; }
            set { _nGeoLocationType = value; }
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
        /// Get set property for GeoLocationCategory
        /// </summary>
        public string GeoLocationCategory
        {
            get { return _sGeoLocationCategory; }
            set { _sGeoLocationCategory = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ParentID
        /// </summary>
        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }
        /// <summary>
        /// Get set property for DistrictCode
        /// </summary>
        public string DistrictCode
        {
            get { return _sDistrictCode; }
            set { _sDistrictCode = value; }
        }
        /// <summary>
        /// Get set property for DistrictName
        /// </summary>
        public string DistrictName
        {
            get { return _sDistrictName; }
            set { _sDistrictName = value; }
        }
        public void RefreshByGeoLocationCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = "Select Tha.GeoLocationID ThanaID, Tha.GeoLocationCode ThanaCode, Tha.GeoLocationName ThanaName, " +
                            "Dis.GeoLocationCode DistrictCode, Dis.GeoLocationName DistrictName " +
                            "from (Select * from t_GeoLocation Where GeoLocationType=2)Tha " +
                            "INNER JOIN (Select * from t_GeoLocation Where GeoLocationType=1)Dis " +
                            "ON Dis.GeoLocationID=Tha.ParentID Where Tha.GeoLocationCode = ?";

                cmd.Parameters.AddWithValue("ThanaCode",_sGeoLocationCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nGeoLocationID = (int)reader["ThanaID"];
                    _sGeoLocationCode = (string)reader["ThanaCode"];
                    _sGeoLocationName = (string)reader["ThanaName"];
                    _sDistrictName = (string)reader["DistrictName"];
                   
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            //if (nCount != 0)
            //    _bFlag = true;
            //else _bFlag = false;
        }

        /// <summary>
        /// Shuvo
        /// Date-16-Jul-2016
        /// </summary>
        public void RefreshByGeoLocationID(int nGeoLocationID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = " Select Tha.GeoLocationID ThanaID, Tha.GeoLocationCode ThanaCode, "+
                                " Tha.GeoLocationName ThanaName, Dis.GeoLocationID DistrictID, "+
                                " Dis.GeoLocationCode DistrictCode, Dis.GeoLocationName DistrictName "+ 
                                " from (Select * from t_GeoLocation Where GeoLocationType=2)Tha "+
                                " INNER JOIN (Select * from t_GeoLocation Where GeoLocationType=1)Dis " +
                                " ON Dis.GeoLocationID=Tha.ParentID Where Tha.GeoLocationID = " + nGeoLocationID + "";
    
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nThanaID = (int)reader["ThanaID"];
                    _sThanaCode = (string)reader["ThanaCode"];
                    _sThanaName = (string)reader["ThanaName"];
                    _nDistrictID = (int)reader["DistrictID"];
                    _sDistrictCode = (string)reader["DistrictCode"];
                    _sDistrictName = (string)reader["DistrictName"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            //if (nCount != 0)
            //    _bFlag = true;
            //else _bFlag = false;
        }
        public int GetParentID(int nGeoLocationID)
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_GeoLocation where GeoLocationID =?";
            cmd.Parameters.AddWithValue("GeoLocationID", nGeoLocationID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                { 
                    _nParentID = (int)reader["ParentID"];
                    
                }
                reader.Close();             

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _nParentID;
        }
       
        //Written by Rifat Farhana: 18-May-2014
        public GeoLocation ParentDistrict
        {
            get
            {
                if (_oParentDistrict == null)
                {
                    _oParentDistrict = new GeoLocation();
                    _oParentDistrict.GeoLocationID = _nParentID;
                    _oParentDistrict.Refresh();

                }
                return _oParentDistrict;
            }
        }
        
        
        

        public void Add()
        {
            int nGeoLocationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX(GeoLocationID) FROM t_GeoLocation";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nGeoLocationID = 1;
                }
                else
                {
                    nGeoLocationID = Convert.ToInt32(maxID) + 1;
                }
                _nGeoLocationID = nGeoLocationID;

                sSql = "INSERT INTO t_GeoLocation(GeoLocationID,GeoLocationCode,GeoLocationName,GeoLocationType,ParentID,GeoLocationCategory) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.Parameters.AddWithValue("GeoLocationCode", _sGeoLocationCode);
                cmd.Parameters.AddWithValue("GeoLocationName", _sGeoLocationName);
                cmd.Parameters.AddWithValue("GeoLocationType", _nGeoLocationType);
                
                if (_nParentID != -1)
                {
                    cmd.Parameters.AddWithValue("ParentID", _nParentID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentID", null);
                }
                if (_sGeoLocationCategory != "-1")
                {
                    cmd.Parameters.AddWithValue("GeoLocationCategory", _sGeoLocationCategory);
                }
                else
                {
                    cmd.Parameters.AddWithValue("GeoLocationCategory", null);
                }

               

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Rifat Farhana
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_GeoLocation SET GeoLocationCode=?, GeoLocationName=?, GeoLocationType=?, ParentID=?,GeoLocationCategory=?"
                    + " WHERE GeoLocationID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("GeoLocationCode", _sGeoLocationCode);
                cmd.Parameters.AddWithValue("GeoLocationName", _sGeoLocationName);
                cmd.Parameters.AddWithValue("GeoLocationType", _nGeoLocationType);
                if (_nParentID != -1)
                {
                    cmd.Parameters.AddWithValue("ParentID", _nParentID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentID", null);
                }
                if (_sGeoLocationCategory != "-1")
                {
                    cmd.Parameters.AddWithValue("GeoLocationCategory", _sGeoLocationCategory);
                }
                else
                {
                    cmd.Parameters.AddWithValue("GeoLocationCategory", null);
                }
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
               
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Rifat Farhana
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_GeoLocation WHERE [GeoLocationID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        //Rifat Farhana
        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_GeoLocation where  GeoLocationID=?";
            cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _nGeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    _sGeoLocationCode = reader["GeoLocationCode"].ToString();
                    _sGeoLocationName = reader["GeoLocationName"].ToString();
                    _nGeoLocationType = Convert.ToInt32(reader["GeoLocationType"].ToString());
                    if (reader["ParentID"] != DBNull.Value)
                        _nParentID = int.Parse(reader["ParentID"].ToString());
                    _sGeoLocationCategory = reader["GeoLocationCategory"].ToString();
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
    public class GeoLocations : CollectionBase
    {

        public GeoLocation this[int i]
        {
            get { return (GeoLocation)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nGeoLocationID)
        {
            int i = 0;
            foreach (GeoLocation oGeoLocation in this)
            {
                if (oGeoLocation.GeoLocationID == nGeoLocationID)
                    return i;
                i++;
            }
            return -1;
        }


        public void Add(GeoLocation oGeoLocation)
        {
            InnerList.Add(oGeoLocation);
        }

        public void GetDistrict()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_GeoLocation where ParentID is null";           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GeoLocation oGeoLocation = new GeoLocation();

                    oGeoLocation.GeoLocationID = (int)reader["GeoLocationID"];
                    oGeoLocation.GeoLocationName = (string)reader["GeoLocationName"];

                    InnerList.Add(oGeoLocation);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetThana(int nGeoLocationID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_GeoLocation where ParentID =?";
            cmd.Parameters.AddWithValue("ParentID", nGeoLocationID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GeoLocation oGeoLocation = new GeoLocation();

                    oGeoLocation.GeoLocationID = (int)reader["GeoLocationID"];
                    oGeoLocation.GeoLocationName = (string)reader["GeoLocationName"];
                    oGeoLocation.ParentID = (int)reader["ParentID"];

                    InnerList.Add(oGeoLocation);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllDistrict()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            GeoLocation oGeoLocation;
            string sSql = "SELECT * FROM t_GeoLocation where ParentID is null";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oGeoLocation = new GeoLocation();

                    oGeoLocation.GeoLocationID = (int)reader["GeoLocationID"];
                    oGeoLocation.GeoLocationName = (string)reader["GeoLocationName"];

                    InnerList.Add(oGeoLocation);
                }
                reader.Close();
                oGeoLocation = new GeoLocation();
                oGeoLocation.GeoLocationID = -1;
                oGeoLocation.GeoLocationName = "ALL";

                InnerList.Add(oGeoLocation);
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllThana()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            GeoLocation oGeoLocation;
            string sSql = "SELECT * FROM t_GeoLocation ";
         
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oGeoLocation = new GeoLocation();

                    oGeoLocation.GeoLocationID = (int)reader["GeoLocationID"];
                    oGeoLocation.GeoLocationName = (string)reader["GeoLocationName"];
                 
                    InnerList.Add(oGeoLocation);
                }
                reader.Close();
                oGeoLocation = new GeoLocation();

                oGeoLocation.GeoLocationID = -1;
                oGeoLocation.GeoLocationName = "ALL";            

                InnerList.Add(oGeoLocation);
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForSearch(String txtThanaCode, String txtThana, String txtDistrict)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql =   "Select Tha.GeoLocationID ThanaID, Tha.GeoLocationCode ThanaCode, Tha.GeoLocationName ThanaName, " +
                            "Dis.GeoLocationCode DistrictCode, Dis.GeoLocationName DistrictName " +
                            "from (Select * from t_GeoLocation Where GeoLocationType=2)Tha " +
                            "INNER JOIN (Select * from t_GeoLocation Where GeoLocationType=1)Dis " +
                            "ON Dis.GeoLocationID=Tha.ParentID";

            if (txtThanaCode != "")
            {
                txtThanaCode = "%" + txtThanaCode + "%";
                sSql = sSql + " AND Tha.GeoLocationCode LIKE '" + txtThanaCode + "'";
            }
            if (txtThana != "")
            {
                txtThana = "%" + txtThana + "%";
                sSql = sSql + " AND Tha.GeoLocationName LIKE '" + txtThana + "'";
            }
            if (txtDistrict != "")
            {
                txtDistrict = "%" + txtDistrict + "%";
                sSql = sSql + " AND Dis.GeoLocationName LIKE '" + txtDistrict + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GeoLocation oGeoLocation = new GeoLocation();


                    oGeoLocation.GeoLocationID = (int)reader["ThanaID"];
                    oGeoLocation.GeoLocationCode = (string)reader["ThanaCode"];
                    oGeoLocation.GeoLocationName = (string)reader["ThanaName"];
                    oGeoLocation.DistrictCode = (string)reader["DistrictCode"];
                    oGeoLocation.DistrictName = (string)reader["DistrictName"];

                    InnerList.Add(oGeoLocation);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDistrict()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            GeoLocation oGeoLocation;
            string sSql = "SELECT * FROM t_GeoLocation where ParentID is null ORDER BY GeoLocationName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oGeoLocation = new GeoLocation();

                    oGeoLocation.GeoLocationID = (int)reader["GeoLocationID"];
                    oGeoLocation.GeoLocationName = (string)reader["GeoLocationName"];

                    InnerList.Add(oGeoLocation);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Rifat Farhana
        public void Refresh(int nGeoLocationType)
        {
            GeoLocation oGeoLocation;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_GeoLocation WHERE GeoLocationType=?";
            cmd.Parameters.AddWithValue("GeoLocationType", nGeoLocationType);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oGeoLocation = new GeoLocation();
                    oGeoLocation.GeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    oGeoLocation.GeoLocationCode = reader["GeoLocationCode"].ToString();
                    oGeoLocation.GeoLocationName = reader["GeoLocationName"].ToString();
                    oGeoLocation.GeoLocationType = int.Parse(reader["GeoLocationType"].ToString());
                    if (reader["ParentID"] != DBNull.Value)
                        oGeoLocation.ParentID = int.Parse(reader["ParentID"].ToString());
                    oGeoLocation.GeoLocationCategory = reader["GeoLocationCategory"].ToString(); ;

                    InnerList.Add(oGeoLocation);
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
        public void RefreshCompanyWise(string sCompany,int nGeoLocationType)
        {
            GeoLocation oGeoLocation;
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From  " +
                        "(  " +
                        "SELECT a.*,'TEL' as Company FROM TELSYSDB.DBO.t_GeoLocation a   " +
                        "Union All  " +
                        "SELECT b.*,'BlL' as Company FROM BLLSYSDB.DBO.t_GeoLocation b   " +
                        "Union All  " +
                        "SELECT c.*,'TML' as Company FROM TMLSYSDB.DBO.t_GeoLocation c  " +
                        ") a where Company='" + sCompany + "' and GeoLocationType=" + nGeoLocationType + "";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oGeoLocation = new GeoLocation();
                    oGeoLocation.GeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    oGeoLocation.GeoLocationCode = reader["GeoLocationCode"].ToString();
                    oGeoLocation.GeoLocationName = reader["GeoLocationName"].ToString();
                    oGeoLocation.GeoLocationType = int.Parse(reader["GeoLocationType"].ToString());
                    if (reader["ParentID"] != DBNull.Value)
                        oGeoLocation.ParentID = int.Parse(reader["ParentID"].ToString());
                    oGeoLocation.GeoLocationCategory = reader["GeoLocationCategory"].ToString(); ;

                    InnerList.Add(oGeoLocation);
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
        public void GetParentID()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT GeoLocationID,GeoLocationName FROM t_GeoLocation  ";
            GeoLocation oGeoLocation;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    oGeoLocation = new GeoLocation();
                    oGeoLocation.GeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    oGeoLocation.GeoLocationName = reader["GeoLocationName"].ToString();
                    InnerList.Add(oGeoLocation);
                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetByParentID(int nParentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT GeoLocationID,GeoLocationName FROM t_GeoLocation where ParentID=" + nParentID + "  ORDER BY GeoLocationName";
            GeoLocation oGeoLocation;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    oGeoLocation = new GeoLocation();
                    oGeoLocation.GeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    oGeoLocation.GeoLocationName = reader["GeoLocationName"].ToString();
                    InnerList.Add(oGeoLocation);
                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
