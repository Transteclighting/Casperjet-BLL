// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 05, 2014
// Time :  05:00 PM
// Description: Class for Product Accessories.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class ProductAccessory
    {
        private int _nAccessoriesID;
        private string _sCode;
        private string _sName;
        private double _PaidServiceCharge;
        private double _WarrantyServiceCharge;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        /// <summary>
        /// Get set property for AccessoriesID
        /// </summary>
        public int AccessoriesID
        {
            get { return _nAccessoriesID; }
            set { _nAccessoriesID = value; }
        }
        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
        }
        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        /// <summary>
        /// Get set property for PaidServiceCharge
        /// </summary>
        public double PaidServiceCharge
        {
            get { return _PaidServiceCharge; }
            set { _PaidServiceCharge = value; }
        }
        /// <summary>
        /// Get set property for WarrantyServiceCharge
        /// </summary>
        public double WarrantyServiceCharge
        {
            get { return _WarrantyServiceCharge; }
            set { _WarrantyServiceCharge = value; }
        }

        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        private void Add()
        { 
        
        }
        private void Edit()
        { 
        
        }
        public void RefreshByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select * from dbo.t_CSDProductAccessories Where AccessoriesID =?";
                cmd.Parameters.AddWithValue("AccessoriesID", _nAccessoriesID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   _nAccessoriesID = (int)reader["AccessoriesID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _PaidServiceCharge = Convert.ToDouble(reader["PaidServiceCharge"].ToString());
                    _WarrantyServiceCharge = Convert.ToDouble(reader["WarrantyServiceCharge"].ToString());
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
    public class ProductAccessories : CollectionBase
    {
        public ProductAccessory this[int i]
        {
            get { return (ProductAccessory)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductAccessory oProductAccessory)
        {
            InnerList.Add(oProductAccessory);
        }

        public int GetIndex(int nAccessoriesID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AccessoriesID == nAccessoriesID)
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

            string sSql = "select AccessoriesID, Code, Name, PaidServiceCharge, WarrantyServiceCharge from t_CSDproductAccessories Order by AccessoriesID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductAccessory oProductAccessory = new ProductAccessory();

                    oProductAccessory.AccessoriesID = (int)reader["AccessoriesID"];
                    oProductAccessory.Code = (string)reader["Code"];
                    oProductAccessory.Name = (string)reader["Name"];
                    oProductAccessory.PaidServiceCharge = Convert.ToDouble(reader["PaidServiceCharge"].ToString());
                    oProductAccessory.WarrantyServiceCharge = Convert.ToDouble(reader["WarrantyServiceCharge"].ToString());
                    
                    InnerList.Add(oProductAccessory);
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
