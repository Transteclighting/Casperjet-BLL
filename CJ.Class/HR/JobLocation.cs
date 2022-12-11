// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: May 28, 2011
// Time :  12:00 PM
// Description: Class for JobLocation.
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.HR
{

    public class JobLocation
    {

        private int _nJobLocationID;
        private string _sJobLocationCode;
        private string _sJobLocationName;
        private string _sDescription;
        private int _nWarehouseID;
        //private bool _bIsActive;
        private int _nIsActive;

        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }

        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }

        }
        private int _nSort;
        public int Sort
        {
            get { return _nSort; }
            set { _nSort = value; }

        }
        private int _nTypeID;
        public int TypeID
        {
            get { return _nTypeID; }
            set { _nTypeID = value; }

        }
        private string _sTypeName;
        public string TypeName
        {
            get { return _sTypeName; }
            set { _sTypeName = value; }

        }
        public int JobLocationID
        {
            get { return _nJobLocationID; }
            set { _nJobLocationID = value; }

        }

        public string JobLocationCode
        {
            get { return _sJobLocationCode; }
            set { _sJobLocationCode = value; }

        }

        public string JobLocationName
        {
            get { return _sJobLocationName; }
            set { _sJobLocationName = value; }
        }
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }

        }
        //public bool IsActive
        //{
        //    get { return _bIsActive; }
        //    set { _bIsActive = value; }

        //}
        public void Add()
        {
            int nMaxJobLocationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([JobLocationID]) FROM t_JobLocation";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxJobLocationID = 1;
                }
                else
                {
                    nMaxJobLocationID = Convert.ToInt32(maxID) + 1;
                }
                _nJobLocationID = nMaxJobLocationID;

                sSql = "INSERT INTO t_JobLocation(JobLocationID,JobLocationCode,JobLocationName,Description,TypeID,Sort,IsActive) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobLocationID", _nJobLocationID);
                cmd.Parameters.AddWithValue("JobLocationCode", _sJobLocationCode);
                cmd.Parameters.AddWithValue("JobLocationName", _sJobLocationName);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("TypeID", _nTypeID);
                cmd.Parameters.AddWithValue("Sort", _nSort);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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

                sSql = "UPDATE t_JobLocation SET JobLocationCode=?, JobLocationName=?,Description=?,TypeID=?,Sort=?, IsActive=? WHERE JobLocationID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobLocationCode", _sJobLocationCode);
                cmd.Parameters.AddWithValue("JobLocationName", _sJobLocationName);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("TypeID", _nTypeID);
                cmd.Parameters.AddWithValue("Sort", _nSort);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("JobLocationID", _nJobLocationID);

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
                sSql = "DELETE FROM t_JobLocation WHERE [JobLocationID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobLocationID", _nJobLocationID);
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

            try
            {
                cmd.CommandText = "SELECT * FROM t_JobLocation where JobLocationID =?";
                cmd.Parameters.AddWithValue("JobLocationID", _nJobLocationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader != null && reader.Read())
                {
                    _nJobLocationID = (int)reader["JobLocationID"];
                    _sJobLocationCode = reader["JobLocationCode"].ToString();
                    _sJobLocationName = reader["JobLocationName"].ToString();
                    _sDescription = reader["Description"].ToString();
                }

                reader?.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshShowroomJoblocation(int nJoblocationID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select JoblocationID,WarehouseID From t_Joblocation a,t_Showroom b "+
                                  " where a.JoblocationID=b.LocationID and JoblocationID = ? and JoblocationID<>1";

                cmd.Parameters.AddWithValue("JobLocationID", nJoblocationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobLocationID = (int)reader["JoblocationID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
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


    public class JobLocations : CollectionBase
    {

        public JobLocation this[int i]
        {
            get { return (JobLocation)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(JobLocation oJobLocation)
        {
            InnerList.Add(oJobLocation);
        }

        public int GetIndex(int nJobLocationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].JobLocationID == nJobLocationID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetIndexType(int nTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TypeID == nTypeID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_JobLocation";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobLocation oJobLocation = new JobLocation();

                    oJobLocation.JobLocationID = (int)reader["JobLocationID"];
                    oJobLocation.JobLocationCode = (string)reader["JobLocationCode"];
                    oJobLocation.JobLocationName = (string)reader["JobLocationName"];
                    //oJobLocation.IsActive = Convert.ToBoolean(reader["IsActive"]);                  
                    InnerList.Add(oJobLocation);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshFactoryLocation()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_JobLocation where IsFactory=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobLocation oJobLocation = new JobLocation();

                    oJobLocation.JobLocationID = (int)reader["JobLocationID"];
                    oJobLocation.JobLocationCode = (string)reader["JobLocationCode"];
                    oJobLocation.JobLocationName = (string)reader["JobLocationName"];
               
                    InnerList.Add(oJobLocation);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetServiceCenters()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            const string sSql = @"SELECT * FROM t_JobLocation WHERE JobLocationID in (136,137,138) 
                                AND IsActive =1 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    JobLocation oJobLocation = new JobLocation
                    {
                        JobLocationID = (int) reader["JobLocationID"],
                        JobLocationCode = (string) reader["JobLocationCode"],
                        JobLocationName = (string) reader["JobLocationName"]
                    };

                    InnerList.Add(oJobLocation);

                }
                reader?.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Getdata(string sJobLocationCode,string sJobLocationName,string sDescription,int nTypeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,isnull(a.Description,'') Descriptions,b.Description as TypeName FROM t_JobLocation a,t_JobLocationType b where a.TypeID=b.TypeID";
            if (sJobLocationCode != "")
            {
                sSql = sSql + " and JobLocationCode like '%" + sJobLocationCode + "%'";
            }
            if (sJobLocationName != "")
            {
                sSql = sSql + " and JobLocationName like '%" + sJobLocationName + "%'";
            }
            if (sDescription != "")
            {
                sSql = sSql + " and a.Description like '%" + sDescription + "%'";
            }
            if (nTypeID != -1)
            {
                sSql = sSql + " and a.TypeID=" + nTypeID + "";
            }
            sSql = sSql + " order By Sort,a.TypeID";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobLocation oJobLocation = new JobLocation();

                    oJobLocation.JobLocationID = (int)reader["JobLocationID"];
                    oJobLocation.JobLocationCode = (string)reader["JobLocationCode"];
                    oJobLocation.JobLocationName = (string)reader["JobLocationName"];
                    oJobLocation.Description = (string)reader["Descriptions"];
                    oJobLocation.TypeName = (string)reader["TypeName"];
                    oJobLocation.TypeID = (int)reader["TypeID"];
                    oJobLocation.Sort = Convert.ToInt32(reader["Sort"]);
                    InnerList.Add(oJobLocation);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void JobLocationType()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_JobLocationType";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobLocation oJobLocation = new JobLocation();

                    oJobLocation.TypeID = (int)reader["TypeID"];
                    oJobLocation.TypeName = (string)reader["Description"];
                    InnerList.Add(oJobLocation);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByPermission(int nUserID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select JobLocationID, JobLocationCode, JobLocationName from t_JobLocation JL INNER JOIN "+
                            "t_UserPermissionData UPD ON JL.JobLocationID=UPD.DataID Where Datatype='JobLocation' AND UserID=?";
            cmd.Parameters.AddWithValue("UserID", nUserID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    JobLocation oJobLocation = new JobLocation();

                    oJobLocation.JobLocationID = (int)reader["JobLocationID"];
                    oJobLocation.JobLocationCode = reader["JobLocationCode"].ToString();
                    oJobLocation.JobLocationName = reader["JobLocationName"].ToString();

                    InnerList.Add(oJobLocation);
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


        public void GetJobLocation(int nJobCreateLocation)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_JobLocation Where JobLocationID=?";
            cmd.Parameters.AddWithValue("JobLocationID", nJobCreateLocation);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    JobLocation oJobLocation = new JobLocation
                    {
                        JobLocationID = (int)reader["JobLocationID"],
                        JobLocationCode = (string)reader["JobLocationCode"],
                        JobLocationName = (string)reader["JobLocationName"],
                        Description = (string)reader["Description"]
                };

                    InnerList.Add(oJobLocation);

                }
                reader?.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void GetJobLocation(int nJobCreateLocation)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "SELECT * FROM t_JobLocation Where JobLocationID=?";
        //    cmd.Parameters.AddWithValue("JobLocationID", nJobCreateLocation);

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();


        //        while (reader.Read())
        //        {
        //            JobLocation oJobLocation = new JobLocation();

        //            oJobLocation.JobLocationID = (int)reader["JobLocationID"];
        //            oJobLocation.JobLocationCode = reader["JobLocationCode"].ToString();
        //            oJobLocation.JobLocationName = reader["JobLocationName"].ToString();
        //            oJobLocation.Description = reader["Description"].ToString();

        //            InnerList.Add(oJobLocation);
        //        }

        //        reader.Close();
        //        InnerList.TrimToSize();

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }

        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void RefreshShowroomJoblocations()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            try
            {
                cmd.CommandText = "Select JoblocationID,JobLocationName From t_Joblocation a,t_Showroom b " +
                                  " where a.JoblocationID=b.LocationID and JoblocationID<>1";

                //cmd.Parameters.AddWithValue("JobLocationID", nJoblocationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobLocation oJobLocation = new JobLocation();
                    oJobLocation.JobLocationID = (int)reader["JoblocationID"];
                    oJobLocation.JobLocationName = reader["JobLocationName"].ToString();
                    //_nWarehouseID = (int)reader["WarehouseID"];

                    InnerList.Add(oJobLocation);
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
