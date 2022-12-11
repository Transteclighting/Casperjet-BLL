// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Apr 11, 2012
// Time :  11:00 AM
// Description: Class for Secondary sales collection.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class.Light
{
  public class SecondarySalesColl
   {
       private int _nTranID;       
       private int _nProductID;        
       private int _nSaleQty;
       private double _NSP;      

      public int TranID
      {
          get { return _nTranID; }
          set { _nTranID = value; }
      }
      
      public int ProductID
      {
          get { return _nProductID; }
          set { _nProductID = value; }
      }
      public int SalesQty
      {
          get { return _nSaleQty; }
          set { _nSaleQty = value; }
      }
      public double NSP
      {
          get { return _NSP; }
          set { _NSP = value; }
      }

      //public bool Flag
      //{
      //    get { return _bFlag; }
      //    set { _bFlag = value; }
      //}
      

      public void Insert()
      {
          OleDbCommand cmd = DBController.Instance.GetCommand();
          string sSql = "";
          sSql = "INSERT INTO t_SecondarySalesDetails VALUES(?,?,?,?)";
          cmd.CommandText = sSql;
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("TranID",_nTranID);
          cmd.Parameters.AddWithValue("ProductID", _nProductID);
          cmd.Parameters.AddWithValue("SalesQty", _nSaleQty);          
          cmd.Parameters.AddWithValue("NSP", _NSP);          
          cmd.ExecuteNonQuery();
          cmd.Dispose();

      }



   }

    public class SecondarySales : CollectionBase
    {
        public SecondarySalesColl this[int i]
        {
            get { return (SecondarySalesColl)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SecondarySalesColl oSecondarySalesColl)
        {
            InnerList.Add(oSecondarySalesColl);
        }

        private int _nTranID;
        private DateTime _dTrandate;
        private int _nCustomerID;
        private int _nUserID;
        private bool _bFlag;

        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }
        public DateTime TranDate
        {
            get { return _dTrandate; }
            set { _dTrandate = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public void Add()
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_SecondarySales";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nMaxTranID;


                sSql = "INSERT INTO t_SecondarySales VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Trandate", _dTrandate);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SecondarySalesColl oSecondarySalesColl in this)
                {
                    oSecondarySalesColl.TranID = _nTranID;
                    oSecondarySalesColl.Insert();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                SecondarySales oItem = new SecondarySales();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = " select * from t_SecondarySales where TranID= ?  select * from t_SecondarySalesDetails where TranID= ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    
    }

    public class SecondarySaless : CollectionBaseCustom
    {
        public SecondarySales this[int i]
        {
            get { return (SecondarySales)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SecondarySales oSecondarySales)
        {
            InnerList.Add(oSecondarySales);
        }

        public int GetIndex(int nTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TranID == nTranID)
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
            string sSql = " SELECT * FROM t_SecondarySales";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecondarySales oSecondarySales = new SecondarySales();

                    oSecondarySales.TranID = (int)reader["TranID"];
                    oSecondarySales.CustomerID = (int)reader["CustomerID"];

                    if (reader["Trandate"] != DBNull.Value)
                        oSecondarySales.TranDate = Convert.ToDateTime(reader["Trandate"]);
                    else oSecondarySales.TranDate = Convert.ToDateTime(0);

                    oSecondarySales.UserID = (int)(reader["UserID"]);

                    InnerList.Add(oSecondarySales);
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
