using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class RptASWWiseNational
    {
        private string _sBrandName;
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

    }

    public class RptASWWiseNationalSales : CollectionBase
    {

        public RptASWWiseNational this[int i]
        {
            get { return (RptASWWiseNational)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(RptASWWiseNational oBrandName)
        {
            InnerList.Add(oBrandName);  
        }

        public RptASWWiseNationalSales GetDataBrandName()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();            
            string sSql = "select distinct BrandDesc from v_ProductDetails  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptASWWiseNational oBrandName = new RptASWWiseNational();
                    oBrandName.BrandName = (string)reader["BrandDesc"];                    
                    InnerList.Add(oBrandName);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }

        public RptASWWiseNationalSales GetDataASGName()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();           
            string sSql = "select distinct ASGname from v_ProductDetails  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptASWWiseNational oBrandName = new RptASWWiseNational();                   
                    oBrandName.ASGName = (string)reader["ASGName"];
                    InnerList.Add(oBrandName);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }       
    }
}
