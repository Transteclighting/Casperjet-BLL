// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 07, 2011
// Time : 12.00 PM
// Description: Class for IT Equipment Type and Feature.
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
  
    public class ITEquipmentFeature
    {
        private int _TypeID;
        private string _FeatureName;
        private string _DataType;


        /// <summary>
        /// Get set property for TypeID
        /// </summary>
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        /// <summary>
        /// Get set property for FeatureName
        /// </summary>
        public string FeatureName
        {
            get { return _FeatureName; }
            set { _FeatureName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for DataType
        /// </summary>
        public string DataType
        {
            get { return _DataType; }
            set { _DataType = value.Trim(); }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ITEquipmentFeature VALUES(?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EquipmentID", _TypeID);
                cmd.Parameters.AddWithValue("FeatureName", _FeatureName);
                cmd.Parameters.AddWithValue("FeatureValue", null);


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

            try
            {
                cmd.CommandText = "Delete from  t_ITEquipmentFeature Where TypeID=? ";
                cmd.Parameters.AddWithValue("EquipmentID", _TypeID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class ITEquipmentFeatures : CollectionBase
    {
        public ITEquipmentFeature this[int i]
        {
            get { return (ITEquipmentFeature)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ITEquipmentFeature oITEquipmentFeature)
        {
            InnerList.Add(oITEquipmentFeature);
        }

        public void GetITEquipmentFeature(int nTypeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ITEquipmentFeature where TypeID=? ";
                cmd.Parameters.AddWithValue("TypeID", nTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITEquipmentFeature oITEquipmentFeature = new ITEquipmentFeature();
                    oITEquipmentFeature.FeatureName = reader["FeatureName"].ToString();

                    InnerList.Add(oITEquipmentFeature);
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

    public class ITEquipmentType
    {
        private int _TypeID;
        private string _TypeCode;
        private string _TypeName;
        private string _MISStoreQty;
        private string _UserEndQty;
        private string _DefectiveQty;
        private string _RepairQty;


        /// <summary>
        /// Get set property for TypeID
        /// </summary>
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        /// <summary>
        /// Get set property for TypeCode
        /// </summary>
        public string TypeCode
        {
            get { return _TypeCode; }
            set { _TypeCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TypeName
        /// </summary>
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MISStoreQty
        /// </summary>
        public string MISStoreQty
        {
            get { return _MISStoreQty; }
            set { _MISStoreQty = value.Trim(); }
        }

        /// <summary>
        /// Get set property for UserEndQty
        /// </summary>
        public string UserEndQty
        {
            get { return _UserEndQty; }
            set { _UserEndQty = value.Trim(); }
        }

        /// <summary>
        /// Get set property for DefectiveQty
        /// </summary>
        public string DefectiveQty
        {
            get { return _DefectiveQty; }
            set { _DefectiveQty = value.Trim(); }
        }

        /// <summary>
        /// Get set property for RepairQty
        /// </summary>
        public string RepairQty
        {
            get { return _RepairQty; }
            set { _RepairQty = value.Trim(); }
        }

        public void GetITEquipmentTypeByTypeID()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ITEquipmentType where TypeID=?";
                cmd.Parameters.AddWithValue("TypeID", _TypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TypeName = reader["TypeName"].ToString();

                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class ITEquipmentTypeDetail : CollectionBase
    {
        public ITEquipmentType this[int i]
        {
            get { return (ITEquipmentType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ITEquipmentType oITEquipmentType)
        {
            InnerList.Add(oITEquipmentType);
        }
        public int GetIndexByID(int nTypeID)
        {
            int i = 0;
            foreach (ITEquipmentType oITEquipmentType in this)
            {
                if (oITEquipmentType.TypeID == nTypeID)
                    return i;
                i++;
            }
            return -1;
        }
       
        public void GetITEquipmentType(bool IsTrue)
        {
            ITEquipmentType oITEquipmentType;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ITEquipmentType";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oITEquipmentType = new ITEquipmentType();
                    oITEquipmentType.TypeName = reader["TypeName"].ToString();
                    oITEquipmentType.TypeID = int.Parse(reader["TypeID"].ToString());
                    InnerList.Add(oITEquipmentType);
                }

                reader.Close();
                if (IsTrue == true)
                {
                    oITEquipmentType = new ITEquipmentType();
                    oITEquipmentType.TypeName = "ALL";
                    oITEquipmentType.TypeID = -1;
                    InnerList.Add(oITEquipmentType);
                }
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }

    public class ITEquipmentValidTran
    {
        public int _nTranType;
        public int _nFromStock;
        public int _nToStock;
    }
    public class ITEquipmentValidTrans : CollectionBase
    {
        public ITEquipmentValidTran this[int i]
        {
            get { return (ITEquipmentValidTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ITEquipmentValidTran oITEquipmentValidTran)
        {
            InnerList.Add(oITEquipmentValidTran);
        }

        public void add()
        {
            InnerList.Clear();

            ITEquipmentValidTran oITEquipmentValidTran = new ITEquipmentValidTran();

            oITEquipmentValidTran._nTranType = 1;
            oITEquipmentValidTran._nFromStock = 0;
            oITEquipmentValidTran._nToStock = 1;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 1;
            oITEquipmentValidTran._nFromStock = 1;
            oITEquipmentValidTran._nToStock = 1;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 1;
            oITEquipmentValidTran._nFromStock = 3;
            oITEquipmentValidTran._nToStock = 1;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 1;
            oITEquipmentValidTran._nFromStock = 0;
            oITEquipmentValidTran._nToStock = 4;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 2;
            oITEquipmentValidTran._nFromStock = 1;
            oITEquipmentValidTran._nToStock = 0;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 2;
            oITEquipmentValidTran._nFromStock = 3;
            oITEquipmentValidTran._nToStock = 0;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 2;
            oITEquipmentValidTran._nFromStock = 4;
            oITEquipmentValidTran._nToStock = 0;

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 3;
            oITEquipmentValidTran._nFromStock = 0;
            oITEquipmentValidTran._nToStock = -1;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 4;
            oITEquipmentValidTran._nFromStock = -1;
            oITEquipmentValidTran._nToStock = 0;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 5;
            oITEquipmentValidTran._nFromStock = 0;
            oITEquipmentValidTran._nToStock = 2;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 5;
            oITEquipmentValidTran._nFromStock = 1;
            oITEquipmentValidTran._nToStock = 2;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 5;
            oITEquipmentValidTran._nFromStock = 3;
            oITEquipmentValidTran._nToStock = 2;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 6;
            oITEquipmentValidTran._nFromStock = 2;
            oITEquipmentValidTran._nToStock = 3;
            InnerList.Add(oITEquipmentValidTran);

            oITEquipmentValidTran = new ITEquipmentValidTran();
            oITEquipmentValidTran._nTranType = 7;
            oITEquipmentValidTran._nFromStock = 2;
            oITEquipmentValidTran._nToStock = -1;
            InnerList.Add(oITEquipmentValidTran);         
          
            InnerList.TrimToSize();
        }
    }
}
