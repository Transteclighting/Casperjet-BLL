using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    public class rptASGWiseNatioalSale
    {

        private string _sBrandName;
        private string _sASGName;
        private string _sProductCode;
        private string _sProductName;
        private int _nSalesQty;

        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
    }

    public class rptASGWiseNatioalSales : CollectionBase
    {

        public rptASGWiseNatioalSale this[int i]
        {
            get { return (rptASGWiseNatioalSale)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptASGWiseNatioalSale orptASGWiseNatioalSale)
        {
            InnerList.Add(orptASGWiseNatioalSale);
        }


        public rptASGWiseNatioalSales GetASWWiseNationalSale( string sBrandName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = @"select ProductCode, ProductName, ASGName, BrandDesc from v_Productdetails where BrandDesc=?";
                cmd.Parameters.AddWithValue("BrandDesc", sBrandName);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptASGWiseNatioalSale orptASGWiseNatioalSale = new rptASGWiseNatioalSale();

                    orptASGWiseNatioalSale.ProductCode = (string)reader["ProductCode"];
                    orptASGWiseNatioalSale.ProductName = (string)reader["ProductName"];
                    orptASGWiseNatioalSale.ASGName = (string)reader["ASGName"];

                    InnerList.Add(orptASGWiseNatioalSale);
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
