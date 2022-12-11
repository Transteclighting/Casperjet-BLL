// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Jan 30, 2012
// Time :  10:00 AM
// Description: Class for CLP Ponit .
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.CLP
{
    public class CLPPointSlab
    {
        private int _nSlabID;
        private int _nPointID;
        private double _SlabAmount;
        private int _nPoint;

        public int SlabID
        {
            get { return _nSlabID; }
            set { _nSlabID = value; }
        }

        /// <summary>
        /// Get set property for PointID
        /// </summary>
        public int PointID
        {
            get { return _nPointID; }
            set { _nPointID = value; }
        }

        /// <summary>
        /// Get set property for SlabAmount
        /// </summary>
        public double SlabAmount
        {
            get { return _SlabAmount; }
            set { _SlabAmount = value; }
        }

        /// <summary>
        /// Get set property for Point
        /// </summary>
        public int Point
        {
            get { return _nPoint; }
            set { _nPoint = value; }
        }
        public void Insert()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SlabID]) FROM t_CLPPointSlab";
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
                _nSlabID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_CLPPointSlab VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("PointID", _nPointID);
                cmd.Parameters.AddWithValue("SlabAmount", _SlabAmount);
                cmd.Parameters.AddWithValue("Point", _nPoint);

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
                sSql = "DELETE FROM t_CLPPointSlab WHERE PointID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PointID", _nPointID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void DeleteAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CLPPointSlab ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
        
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
            string sSql = " select * from t_CLPPointSlab where  PointID=?";
            cmd.Parameters.AddWithValue("PointID", _nPointID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _SlabAmount = Convert.ToDouble(reader["SlabAmount"].ToString());
                    _nPointID = int.Parse(reader["Point"].ToString());
                }

                reader.Close();
              
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

    public class CLPPoint: CollectionBase
    {
        public CLPPointSlab this[int i]
        {
            get { return (CLPPointSlab)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CLPPointSlab oCLPPointSlab)
        {
            InnerList.Add(oCLPPointSlab);
        }

        private int _nPointID;
        private string _sDescription;
        private DateTime _dEffectDate;
        private int _nCreatedBy;
        private DateTime _dCreatedDate;


        /// <summary>
        /// Get set property for PointID
        /// </summary>
        public int PointID
        {
            get { return _nPointID; }
            set { _nPointID = value; }
        }

        /// <summary>
        /// Get set property for Description
        /// </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        /// <summary>
        /// Get set property for EffectDate
        /// </summary>
        public DateTime EffectDate
        {
            get { return _dEffectDate; }
            set { _dEffectDate = value; }
        }

        /// <summary>
        /// Get set property for CreatedBy
        /// </summary>
        public int CreatedBy
        {
            get { return _nCreatedBy; }
            set { _nCreatedBy = value; }
        }

        /// <summary>
        /// Get set property for CreatedDate
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _dCreatedDate; }
            set { _dCreatedDate = value; }
        }

        public void Insert()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([PointID]) FROM t_CLPPoint";
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
                _nPointID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_CLPPoint VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PointID", _nPointID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("EffectDate", _dEffectDate);
                cmd.Parameters.AddWithValue("CreatedBy", _nCreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", _dCreatedDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach(CLPPointSlab oCLPPointSlab in this)
                {
                    oCLPPointSlab.PointID = _nPointID;
                    oCLPPointSlab.Insert();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshSlab()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_CLPPointSlab where  PointID=?";
            cmd.Parameters.AddWithValue("PointID", _nPointID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CLPPointSlab oCLPPointSlab = new CLPPointSlab();
                    oCLPPointSlab.SlabID = int.Parse(reader["SlabID"].ToString());
                    oCLPPointSlab.PointID = int.Parse(reader["PointID"].ToString());
                    oCLPPointSlab.SlabAmount = Convert.ToDouble(reader["SlabAmount"].ToString());
                    oCLPPointSlab.Point = int.Parse(reader["Point"].ToString());

                    InnerList.Add(oCLPPointSlab);
                }

                reader.Close();
                InnerList.TrimToSize();
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
                sSql = "DELETE FROM t_CLPPoint WHERE PointID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PointID", _nPointID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void DeleteAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CLPPoint ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
           
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void GetCLPPoint()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_CLPPoint Where EffectDate <= ? ";

            cmd.Parameters.AddWithValue("EffectDate", _dEffectDate);         

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _nPointID = int.Parse(reader["PointID"].ToString());
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class CLPPointList : CollectionBase
    {
        public CLPPoint this[int i]
        {
            get { return (CLPPoint)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CLPPoint oCLPPoint)
        {
            InnerList.Add(oCLPPoint);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_CLPPoint ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CLPPoint oCLPPoint = new CLPPoint();
                    oCLPPoint.PointID = int.Parse(reader["PointID"].ToString());
                    oCLPPoint.Description = reader["Description"].ToString();
                    oCLPPoint.EffectDate = Convert.ToDateTime(reader["EffectDate"].ToString());
                    oCLPPoint.CreatedBy = int.Parse(reader["CreatedBy"].ToString());
                    oCLPPoint.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                    oCLPPoint.RefreshSlab();

                    InnerList.Add(oCLPPoint);
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
