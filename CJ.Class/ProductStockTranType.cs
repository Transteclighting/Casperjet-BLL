// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shahnoor Saeed
// Date: July 20, 2011
// Time :  09:30 AM
// Description: Class for Product Stock Tran Type.
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
    public class ProductStockTranType
    {
        private int _TranTypeID;
        private string _TranTypeCode;
        private string _TranTypeName;
        private Int16 _TransactionSide;
        private Int16 _IsSystem;
        private Int16 _Status;


        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public int TranTypeID
        {
            get { return _TranTypeID; }
            set { _TranTypeID = value; }
        }

        /// <summary>
        /// Get set property for TranTypeCode
        /// </summary>
        public string TranTypeCode
        {
            get { return _TranTypeCode; }
            set { _TranTypeCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TranTypeName
        /// </summary>
        public string TranTypeName
        {
            get { return _TranTypeName; }
            set { _TranTypeName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TransactionSide
        /// </summary>
        public Int16 TransactionSide
        {
            get { return _TransactionSide; }
            set { _TransactionSide = value; }
        }

        /// <summary>
        /// Get set property for IsSystem
        /// </summary>
        public Int16 IsSystem
        {
            get { return _IsSystem; }
            set { _IsSystem = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public Int16 Status
        {
            get { return _Status; }
            set { _Status = value; }
        } 

    }
    public class ProductStockTranTypes : CollectionBase
    {
        public ProductStockTranType this[int i]
        {
            get { return (ProductStockTranType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductStockTranType oProductStockTranType)
        {
            InnerList.Add(oProductStockTranType);
        }

        public int GetIndex(int nTranTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TranTypeID == nTranTypeID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void GetProductStockTranType()
        {
            ProductStockTranType oProductStockTranType;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_productstocktrantype order by trantypeName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductStockTranType = new ProductStockTranType();
                    oProductStockTranType.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oProductStockTranType.TranTypeCode = reader["TranTypeCode"].ToString();
                    oProductStockTranType.TranTypeName = reader["TranTypeName"].ToString();
                    oProductStockTranType.TransactionSide = Int16.Parse(reader["TransactionSide"].ToString());
                    oProductStockTranType.IsSystem = Int16.Parse(reader["IsSystem"].ToString());
                    oProductStockTranType.Status = Int16.Parse(reader["Status"].ToString());

                    InnerList.Add(oProductStockTranType);
                }

                reader.Close();

                oProductStockTranType = new ProductStockTranType();
                oProductStockTranType.TranTypeID = -1;
                oProductStockTranType.TranTypeName = "<ALL>";
                InnerList.Add(oProductStockTranType);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetStockTranTypeByTranSide(int nTranSide)
        {
            ProductStockTranType oProductStockTranType;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_productstocktrantype where  TransactionSide=" + nTranSide + " and IsSystem=2";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductStockTranType = new ProductStockTranType();
                    oProductStockTranType.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oProductStockTranType.TranTypeCode = reader["TranTypeCode"].ToString();
                    oProductStockTranType.TranTypeName = reader["TranTypeName"].ToString();
                    oProductStockTranType.TransactionSide = Int16.Parse(reader["TransactionSide"].ToString());
                    oProductStockTranType.IsSystem = Int16.Parse(reader["IsSystem"].ToString());
                    oProductStockTranType.Status = Int16.Parse(reader["Status"].ToString());

                    InnerList.Add(oProductStockTranType);
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
