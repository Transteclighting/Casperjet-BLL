using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class ProductPortfolio
    {
        private int _nOutletID;
        private string _sOutlet;
        private string _sProductCode;
        private int _nIsActive;
        private bool _nFlag;
        private string _sProductName;
        private string _sASGName;
        private int _nProductID;

        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public bool Flag
        {
            get { return _nFlag; }
            set { _nFlag = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public void Add(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Insert Into t_tdproductportfolio (CustomerID,ProductID,IsActive,UpdateDate) values(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", _nOutletID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.YesOrNoStatus.YES);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void CkeckStatus(int nProductID)
        {
            int nCounter = 0;
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSql = "select * from t_tdproductportfolio where CustomerID=? and ProductID=? and IsActive=?";

            cmd.Parameters.AddWithValue("CustomerID", _nOutletID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.YesOrNoStatus.YES);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nCounter++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (nCounter == 0)
            {
                _nFlag = true;
            }
            else
            {
                _nFlag = false;
            }

        }
        public void Delete(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "delete from t_TDProductPortfolio Where ProductID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateActive(int nIsActive,int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "update t_TDProductPortfolio set IsActive=? where ProductId=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        
    }

        public class ProductPortfolios : CollectionBase
        {

            public ProductPortfolio this[int i]
            {
                get { return (ProductPortfolio)InnerList[i]; }
                set { InnerList[i] = value; }
            }

            public void Add(ProductPortfolio oProductPortfolio)
            {
                InnerList.Add(oProductPortfolio);
            }

            public void GetTDOutlet()
            {
                string sSql = "";
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();


                sSql = "Select CustomerID,CustomerCode,CustomerName, left(CustomerName,3)as ShortCode " +
                               "from t_Customer Where CustTypeID=5 AND CustomerID Not IN (2170,789,2171) AND ISActive=1 Order by CustomerName ASC";

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        ProductPortfolio oProductPortfolio = new ProductPortfolio();

                        oProductPortfolio.OutletID = (int)reader["CustomerID"];
                        oProductPortfolio.Outlet = (string)reader["ShortCode"];

                        InnerList.Add(oProductPortfolio);
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

            public void GetPortfolioData(string sProductCode, string sProductName, string sASGName)
            {
                string sSql = "";
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();


                sSql = "Select b.ProductID,ProductCode,ProductName,ASGID, ASGName,a.IsActive from (select distinct ProductID,IsActive from t_tdproductportfolio) a " +
                        "INNER JOIN v_ProductDetails b " +
                        "ON a.ProductID=b.ProductID where 1=1";

                if (sProductCode != "")
                {
                    sSql = sSql + "and ProductCode like '%" + sProductCode + "%'";
                }
                if (sProductName != "")
                {
                    sSql = sSql + "and ProductName like '%" + sProductName + "%'";
                }
                if (sASGName != "")
                {
                    sSql = sSql + "and ASGName like '%" + sASGName + "%'";
                }

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        ProductPortfolio oProductPortfolio = new ProductPortfolio();

                        oProductPortfolio.ProductID = (int)reader["ProductID"];
                        oProductPortfolio.ProductCode = (string)reader["ProductCode"];
                        oProductPortfolio.ProductName = (string)reader["ProductName"];
                        oProductPortfolio.ASGName = (string)reader["ASGName"];
                        oProductPortfolio.IsActive = (int)reader["IsActive"];
                        InnerList.Add(oProductPortfolio);
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

