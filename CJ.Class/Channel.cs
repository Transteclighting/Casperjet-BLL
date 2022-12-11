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
    public class Channel
    {
        private int _nChannelID;
        private string _sChannelCode;
        private string _sChannelDescription;
        private int _nIsActive;
        private int _nChannelType;
        private int _nSBUID;
        private int _nSortOrder;

        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }   
        public string ChannelCode
        {
            get { return _sChannelCode; }
            set { _sChannelCode = value.Trim(); }
        } 
        public string ChannelDescription
        {
            get { return _sChannelDescription; }
            set { _sChannelDescription = value.Trim(); }
        }       
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }      
        public int ChannelType
        {
            get { return _nChannelType; }
            set { _nChannelType = value; }
        }
        public int SBUID
        {
            get { return _nSBUID; }
            set { _nSBUID = value; }
        }
        public int SortOrder
        {
            get { return _nSortOrder; }
            set { _nSortOrder = value; }
        }

        //Uttam
        public void Add()
        {
            int nChannelID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ChannelID]) FROM t_Channel";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nChannelID = 1;
                }
                else
                {
                    nChannelID = Convert.ToInt32(maxID) + 1;
                }
                _nChannelID = nChannelID;

                sSql = "INSERT INTO t_Channel(ChannelID,ChannelCode,ChannelDescription,IsActive,ChannelType,SBUID,SortOrder) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("ChannelCode", _sChannelCode);
                cmd.Parameters.AddWithValue("ChannelDescription", _sChannelDescription);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("ChannelType", _nChannelType);
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);
                cmd.Parameters.AddWithValue("SortOrder", _nSortOrder);

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

                sSql = "UPDATE t_Channel SET ChannelCode=?, ChannelDescription=?, IsActive=?, ChannelType=?, SBUID=?, SortOrder = ?"
                    + " WHERE ChannelID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ChannelCode", _sChannelCode);
                cmd.Parameters.AddWithValue("ChannelDescription", _sChannelDescription);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("ChannelType", _nChannelType);
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);
                cmd.Parameters.AddWithValue("SortOrder", _nSortOrder);
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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_Channel WHERE [ChannelID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
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
        public void Refresh()
        {         
          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_Channel where  ChannelID=?";
            cmd.Parameters.AddWithValue("ChannelID", _nChannelID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _nChannelID = int.Parse(reader["ChannelID"].ToString());
                    _sChannelDescription = reader["ChannelDescription"].ToString();
                  
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
        public void RefreshByCode()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_Channel where  ChannelCode=?";
            cmd.Parameters.AddWithValue("ChannelCode", _sChannelCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _nChannelID = int.Parse(reader["ChannelID"].ToString());
                    _sChannelDescription = reader["ChannelDescription"].ToString();

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
    public class Channels : CollectionBase
    {
        public Channel this[int i]
        {
            get { return (Channel)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(Channel oChannel)
        {
            InnerList.Add(oChannel);
        }
        public void Refresh()
        {           
            Channel oChannel;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_Channel order by ChannelID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    oChannel = new Channel();
                    oChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oChannel.ChannelDescription = reader["ChannelDescription"].ToString();
                    oChannel.ChannelType = int.Parse(reader["ChannelType"].ToString());
                    oChannel.ChannelCode = reader["ChannelCode"].ToString();
                    oChannel.IsActive = int.Parse(reader["IsActive"].ToString());
                    if (reader["SBUID"] != DBNull.Value)
                    {
                        oChannel.SBUID = int.Parse(reader["SBUID"].ToString());
                    }
                    else
                    {
                        oChannel.SBUID = 0;
                    }

                    if (reader["SortOrder"] != DBNull.Value)
                    {
                        oChannel.SortOrder = int.Parse(reader["SortOrder"].ToString());
                    }
                    else
                    {
                        oChannel.SortOrder = 0;
                    }

                    InnerList.Add(oChannel);
                }

                reader.Close();

                //oChannel = new Channel();                
                //oChannel.ChannelID = -1;
                //oChannel.ChannelDescription = "ALL";
                //InnerList.Add(oChannel);
                //InnerList.TrimToSize();
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshCompanyWise(string sCompany)
        {
            Channel oChannel;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From " +
                        "( " +
                        "SELECT ChannelID,ChannelDescription,ChannelCode,IsActive,SBUID,'TEL' as Company FROM TELSYSDB.DBO.t_Channel a  " +
                        "Union All " +
                        "SELECT ChannelID,ChannelDescription,ChannelCode,IsActive,SBUID,'BLL' as Company FROM BLLDBSERVER01.BLLSYSDB.DBO.t_Channel b  " +
                        "Union All " +
                        "SELECT ChannelID,ChannelDescription,ChannelCode,IsActive,SBUID,'TML' as Company FROM TMLSYSDB.DBO.t_Channel c " +
                        ") a where Company='" + sCompany + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    oChannel = new Channel();
                    oChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oChannel.ChannelDescription = reader["ChannelDescription"].ToString();
                    oChannel.ChannelCode = reader["ChannelCode"].ToString();
                    oChannel.IsActive = int.Parse(reader["IsActive"].ToString());
                    if (reader["SBUID"] != DBNull.Value)
                    {
                        oChannel.SBUID = int.Parse(reader["SBUID"].ToString());
                    }
                    else
                    {
                        oChannel.SBUID = 0;
                    }
                    InnerList.Add(oChannel);
                }

                reader.Close();

            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int GetIndex(int nChannelID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ChannelID == nChannelID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetIndexByID(int nChannelID)
        {
            int i = 0;
            foreach (Channel oChannel in this)
            {
                if (oChannel.ChannelID == nChannelID)
                    return i;
                i++;
            }
            return -1;
        }

       /* public void GetChannelForSalesOrder()
        {
            Channel oChannel;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_Channel";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    oChannel = new Channel();
                    oChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oChannel.ChannelDescription = reader["ChannelDescription"].ToString();                    
                    InnerList.Add(oChannel);
                }              

                reader.Close();

                oChannel = new Channel();
                oChannel.ChannelID = -1;
                oChannel.ChannelDescription = " ";
                InnerList.Add(oChannel);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }*/

        public void GetChannel(int nUserID)
        {
            //DataSet oDS = new DataSet();
            
            Users oUsers = new Users();
            string sPermission = oUsers.GetDataID(nUserID, "Channel");
            if (sPermission == "")
                return;

            Channel oChannel;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_Channel where ChannelID in (" + sPermission + ")";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    oChannel = new Channel();
                    oChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oChannel.ChannelDescription = reader["ChannelDescription"].ToString();
                    InnerList.Add(oChannel);
                }

                reader.Close();

                oChannel = new Channel();
                oChannel.ChannelID = -1;
                oChannel.ChannelDescription = "ALL";
                InnerList.Add(oChannel);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAllChannel()
        {
            Channel oChannel;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_Channel ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    oChannel = new Channel();
                    oChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oChannel.ChannelDescription = reader["ChannelDescription"].ToString();
                    oChannel.ChannelCode = reader["ChannelCode"].ToString();
                    InnerList.Add(oChannel);
                }

                reader.Close();

                oChannel = new Channel();
                oChannel.ChannelID = -1;
                oChannel.ChannelDescription = "<Select Channel>";
                InnerList.Add(oChannel);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForPromotion()
        {
            Channel oChannel;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_Channel Where  ChannelID != ? order by ChannelDescription ";
            cmd.Parameters.AddWithValue("ChannelID", (int)Dictionary.SystemChannel.SYS_CHANNEL);     

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oChannel = new Channel();
                    oChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oChannel.ChannelDescription = reader["ChannelDescription"].ToString();
                    oChannel.ChannelCode = reader["ChannelCode"].ToString();
                    InnerList.Add(oChannel);
                }
                reader.Close();   
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetChannel()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT ChannelID, ChannelDescription from t_Channel";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Channel oChannel = new Channel();
                    oChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oChannel.ChannelDescription = reader["ChannelDescription"].ToString();
                    InnerList.Add(oChannel);
                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetChannelForGRD()
        {
            Channel oChannel;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_Channel where ChannelID in (2,3,4,5,6,7,8,9,10,12,14,15)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oChannel = new Channel();
                    oChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oChannel.ChannelCode = reader["ChannelCode"].ToString();
                    oChannel.ChannelDescription = reader["ChannelDescription"].ToString();
                    InnerList.Add(oChannel);
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
