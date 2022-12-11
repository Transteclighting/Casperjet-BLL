// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 2, 2011
// Time : 02.00 PM
// Description: Class for IT Equipment Management.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class;

namespace CJ.Class.IT
{
    public class ITEquipmentDetail
    {
        private int _nEquipmentID;      
        private string _sFeatureName;
        private string _sFeatureValue;
        private string _sDataType;


        /// <summary>
        /// Get set property for EquipmentID
        /// </summary>
        public int EquipmentID
        {
            get { return _nEquipmentID; }
            set { _nEquipmentID = value; }
        }      

        /// <summary>
        /// Get set property for FeatureName
        /// </summary>
        public string FeatureName
        {
            get { return _sFeatureName; }
            set { _sFeatureName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for FeatureValue
        /// </summary>
        public string FeatureValue
        {
            get { return _sFeatureValue; }
            set { _sFeatureValue = value.Trim(); }
        }

        /// <summary>
        /// Get set property for DataType
        /// </summary>
        public string DataType
        {
            get { return _sDataType; }
            set { _sDataType = value.Trim(); }
        }

        public void Insert(int nEquipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ITEquipmentDetails VALUES(?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EquipmentID", nEquipmentID);
                cmd.Parameters.AddWithValue("FeatureName", _sFeatureName);
                cmd.Parameters.AddWithValue("FeatureValue", _sFeatureValue);              
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nEquipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_ITEquipmentDetails Where EquipmentID=? ";
                cmd.Parameters.AddWithValue("EquipmentID", nEquipmentID);
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
    public class ITEquipment: CollectionBase
    {
        private int _nEquipmentID;
        private int _nTypeID;       
        private string _sBrand;
        private string _sModelNo;       
        private string _sProductNo;       
        private string _sRemarks;     
            

        /// <summary>
        /// Get set property for EquipmentID
        /// </summary>
        public int EquipmentID
        {
            get { return _nEquipmentID; }
            set { _nEquipmentID = value; }
        }

        /// <summary>
        /// Get set property for TypeID
        /// </summary>
        public int TypeID
        {
            get { return _nTypeID; }
            set { _nTypeID = value; }
        }       
      
        /// <summary>
        /// Get set property for Brand
        /// </summary>
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ModelNo
        /// </summary>
        public string ModelNo
        {
            get { return _sModelNo; }
            set { _sModelNo = value.Trim(); }
        }               

        /// <summary>
        /// Get set property for ProductNo
        /// </summary>
        public string ProductNo
        {
            get { return _sProductNo; }
            set { _sProductNo = value.Trim(); }
        }    

        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public ITEquipmentDetail this[int i]
        {
            get { return (ITEquipmentDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ITEquipmentDetail oITEquipmentDetail)
        {
            InnerList.Add(oITEquipmentDetail);
        }

        public void Insert()
        {
            int nMaxEquipmentID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([EquipmentID]) FROM t_ITEquipment";
                cmd.CommandText = sSql;
                object maxEquipmentID = cmd.ExecuteScalar();
                if (maxEquipmentID == DBNull.Value)
                {
                    nMaxEquipmentID = 1;
                }
                else
                {
                    nMaxEquipmentID = int.Parse(maxEquipmentID.ToString()) + 1;

                }
                _nEquipmentID = nMaxEquipmentID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ITEquipment VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EquipmentID", _nEquipmentID);
                cmd.Parameters.AddWithValue("TypeID", _nTypeID);               
                cmd.Parameters.AddWithValue("Brand", _sBrand);
                cmd.Parameters.AddWithValue("ModelNo", _sModelNo);               
                cmd.Parameters.AddWithValue("ProductNo", _sProductNo);              
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
            

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ITEquipmentDetail oItem in this)
                {
                    oItem.Insert(_nEquipmentID);
                }              
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update()
        {
            int nCount = 1;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update  t_ITEquipment set TypeID=?,Brand=?,ModelNo=?,ProductNo=?," +
                    "Remarks=? where EquipmentID=?";

                cmd.CommandType = CommandType.Text;

               
                cmd.Parameters.AddWithValue("TypeID", _nTypeID);             
                cmd.Parameters.AddWithValue("Brand", _sBrand);
                cmd.Parameters.AddWithValue("ModelNo", _sModelNo);
                cmd.Parameters.AddWithValue("ProductNo", _sProductNo);                           
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);              

                cmd.Parameters.AddWithValue("EquipmentID", _nEquipmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ITEquipmentDetail oItem in this)
                {
                    if (nCount == 1)
                    {
                        oItem.Delete(_nEquipmentID);
                        nCount++;
                    }
                    oItem.Insert(_nEquipmentID);
                }
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            ITEquipmentDetail oItem = new ITEquipmentDetail();
            oItem.Delete(_nEquipmentID);   

            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Delete from  t_ITEquipment Where EquipmentID=? ";                
                cmd.Parameters.AddWithValue("EquipmentID", _nEquipmentID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();                                 
                                   
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }   

        public void RefreshItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ITEquipmentDetails where EquipmentID=? ";
                cmd.Parameters.AddWithValue("EquipmentID", _nEquipmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITEquipmentDetail oItem = new ITEquipmentDetail();

                    oItem.EquipmentID = int.Parse(reader["EquipmentID"].ToString());
                    oItem.FeatureName = reader["FeatureName"].ToString();
                    oItem.FeatureValue = reader["FeatureValue"].ToString();                   
                   
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

        public void Refresh()
        {          

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ITEquipment where EquipmentID=?";
            cmd.Parameters.AddWithValue("EquipmentID", _nEquipmentID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                   

                    _nTypeID = int.Parse(reader["TypeID"].ToString());                    
                    _sBrand = reader["Brand"].ToString();
                    _sModelNo = reader["ModelNo"].ToString();                
                    _sProductNo = reader["ProductNo"].ToString();                  
                  
                }
                reader.Close();             

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    
    }

    /// <summary>
    /// 
    /// </summary>
    public class ITEquipments : CollectionBase
    {
        public ITEquipment this[int i]
        {
            get { return (ITEquipment)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ITEquipment oITEquipment)
        {
            InnerList.Add(oITEquipment);
        }
        public void Refresh(int nType,string sModel)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ITEquipment where TypeID='" + nType + "'";
            if (sModel != "")
            {
                sModel = "%" + sModel + "%";
                sSql = sSql + "and ModelNo like '" + sModel + "'";
            }
                      
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITEquipment oITEquipment = new ITEquipment();

                    oITEquipment.EquipmentID = int.Parse(reader["EquipmentID"].ToString());                  
                    oITEquipment.TypeID = int.Parse(reader["TypeID"].ToString());                   
                    oITEquipment.Brand = reader["Brand"].ToString();
                    oITEquipment.ModelNo = reader["ModelNo"].ToString();
                    oITEquipment.ProductNo = reader["ProductNo"].ToString();    
                    oITEquipment.Remarks = reader["Remarks"].ToString();                  

                    oITEquipment.RefreshItem();

                    InnerList.Add(oITEquipment);
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
