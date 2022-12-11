// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Aug 28, 2012
// Time :  11:00 AM
// Description: Class for ecommerce programmer stock.
// Modify Person And Date: Md. Abdul Hakim, 06-Mar-2013 04:00 PM
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Class
{
    public class ECProductStock
    {
        private string _PCode;
        private string _PName;
        private string _PCategory;
        private string _PSubCategory;
        private string _PBrand;
        private double _RetailPrice;
        private double _DiscountedPrice;
        private double _WebStock;
        private double _RSP;
        private double _TDStock;
        private double _HOStock;
        private double _Diff;
        private int _IsRead;
        private int _Status;
        private string _StatusName;


        /// <summary>
        /// Get set property for PCode
        /// </summary>
        public string PCode
        {
            get { return _PCode; }
            set { _PCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PName
        /// </summary>
        public string PName
        {
            get { return _PName; }
            set { _PName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PCategory
        /// </summary>
        public string PCategory
        {
            get { return _PCategory; }
            set { _PCategory = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PSubCategory
        /// </summary>
        public string PSubCategory
        {
            get { return _PSubCategory; }
            set { _PSubCategory = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PBrand
        /// </summary>
        public string PBrand
        {
            get { return _PBrand; }
            set { _PBrand = value.Trim(); }
        }
        /// <summary>
        /// Get set property for RetailPrice
        /// </summary>
        public double RetailPrice
        {
            get { return _RetailPrice; }
            set { _RetailPrice = value; }
        }
        /// <summary>
        /// Get set property for DiscountedPrice
        /// </summary>
        public double DiscountedPrice
        {
            get { return _DiscountedPrice; }
            set { _DiscountedPrice = value; }
        }
        /// <summary>
        /// Get set property for WebStock
        /// </summary>
        public double WebStock
        {
            get { return _WebStock; }
            set { _WebStock = value; }
        }
        /// <summary>
        /// Get set property for RSP
        /// </summary>
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
        /// <summary>
        /// Get set property for TDStock
        /// </summary>
        public double TDStock
        {
            get { return _TDStock; }
            set { _TDStock = value; }
        }
        /// <summary>
        /// Get set property for HOStock
        /// </summary>
        public double HOStock
        {
            get { return _HOStock; }
            set { _HOStock = value; }
        }
        /// <summary>
        /// Get set property for Diff
        /// </summary>
        public double Diff
        {
            get { return _Diff; }
            set { _Diff = value; }
        }
        /// <summary>
        /// Get set property for IsRead
        /// </summary>
        public int IsRead
        {
            get { return _IsRead; }
            set { _IsRead = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        /// <summary>
        /// Get set property for StatusName
        /// </summary>
        public string StatusName
        {
            get { return _StatusName; }
            set { _StatusName = value; }
        }

        public void Insert()
        {        
            OleDbCommand cmd = DBController.Instance.GetCommand();
          
            try
            {

                cmd.CommandText = "INSERT INTO t_ECProduct VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PCode", _PCode);
                cmd.Parameters.AddWithValue("PName", _PName);
                cmd.Parameters.AddWithValue("PCategory", _PCategory);
                cmd.Parameters.AddWithValue("PSubCategory", _PSubCategory);
                cmd.Parameters.AddWithValue("PBrand", _PBrand);
                cmd.Parameters.AddWithValue("RetailPrice", _RetailPrice);
                cmd.Parameters.AddWithValue("DiscountedPrice", _DiscountedPrice);
                cmd.Parameters.AddWithValue("WebStock", _WebStock);
                cmd.Parameters.AddWithValue("IsRead", (int)Dictionary.ECIsRead.No);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ECStatus.New);

                cmd.ExecuteNonQuery();
                cmd.Dispose();             
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {         
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update  t_ECProduct set PName=?,PCategory=?,PSubCategory=?,PBrand=?,RetailPrice=?, "+
                                    "DiscountedPrice=?,WebStock=?,IsRead=?,Status=? Where PCode=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PName", _PName);
                cmd.Parameters.AddWithValue("PCategory", _PCategory);
                cmd.Parameters.AddWithValue("PSubCategory", _PSubCategory);
                cmd.Parameters.AddWithValue("PBrand", _PBrand);
                cmd.Parameters.AddWithValue("RetailPrice", _RetailPrice);
                cmd.Parameters.AddWithValue("DiscountedPrice", _DiscountedPrice);
                cmd.Parameters.AddWithValue("WebStock", _WebStock);
                cmd.Parameters.AddWithValue("IsRead", _IsRead);
                cmd.Parameters.AddWithValue("Status", _Status);

                cmd.Parameters.AddWithValue("PCode", _PCode);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateReadUnread()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update t_ECProduct set IsRead=? Where PCode=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsRead", _IsRead);

                cmd.Parameters.AddWithValue("PCode", _PCode);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckPCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ECProduct where PCode=?";
            cmd.Parameters.AddWithValue("PCode", _PCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;
        }
        public bool CheckReadPermission(int nUserID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * from t_UserPermission Where PermissionKey='M1.68' AND UserID=?";
            cmd.Parameters.AddWithValue("UserID", nUserID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return false;
            else return true;


        }
    }
    public class ECProductStocks : CollectionBase
    {
        public ECProductStock this[int i]
        {
            get { return (ECProductStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ECProductStock oECProductStock)
        {
            InnerList.Add(oECProductStock);
        }
        public void Refresh(string sPCode, int nStatus, int nIsReadUnread)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select PCode,PName,PCategory,PSubCategory,PBrand,RetailPrice,DiscountedPrice, RSP,WebStock, " +
                           " TDStock,HOStock,Diff,IsRead, Status, StatusName=CASE When Status = 0 then 'New' When Status = 1 then 'Update' " +
                            "When Status = 2 then 'Delete' end from (select Prod.*,PD.RSP,TDOutlet.TDStock as TDStock,HO.HOStock as HOStock, " +
                            "((TDOutlet.TDStock+HO.HOStock)-Prod.WebStock) as Diff  from t_ECProduct Prod inner join v_ProductDetails PD " +
                            "ON Prod.PCode=PD.ProductCode left outer join (select B.Code as PCode,sum(SoundStock) as TDStock " +
                            "from Cassiopeia_HO.dbo.SRStock A inner join Cassiopeia_HO.dbo.Product B on A.ProductID=B.ProductID " +
                            "where not A.showroomID=1 group by B.Code) TDOutlet on Prod.PCode=TDOutlet.PCode left outer join " +
                            "(select B.ProductCode,CurrentStock as HOStock from t_ProductStock A inner join t_Product B  " +
                            "on A.ProductID=B.ProductID where WarehouseID=70) HO on Prod.PCode=HO.ProductCode) AA Where PCode <>0 ";
            if (sPCode != "")
            {
                sPCode = "%" + sPCode + "%";
                sSql = sSql + " AND PCode Like '" + sPCode + "' ";
            }
            if (nStatus > -1)
            {
                sSql = sSql + " AND Status ='" + nStatus + "'";
            }
            if (nIsReadUnread > -1)
            {
                sSql = sSql + " AND IsRead ='" + nIsReadUnread + "'";
            }
            sSql = sSql + "order by PCategory,PSubCategory,PBrand ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ECProductStock oECProductStock = new ECProductStock();

                    oECProductStock.PCode = (string)reader["PCode"];
                    oECProductStock.PName = (string)reader["PName"];
                    oECProductStock.PCategory = reader["PCategory"].ToString();
                    oECProductStock.PSubCategory = reader["PSubCategory"].ToString();
                    oECProductStock.PBrand = reader["PBrand"].ToString();
                    oECProductStock.RetailPrice = (double)reader["RetailPrice"];
                    oECProductStock.DiscountedPrice = (double)reader["DiscountedPrice"];
                    oECProductStock.WebStock = (double)reader["WebStock"];
                    oECProductStock.RSP = (double)reader["RSP"];
                    oECProductStock.TDStock = Convert.ToDouble(reader["TDStock"].ToString());
                    oECProductStock.HOStock = Convert.ToDouble(reader["HOStock"].ToString());
                    oECProductStock.Diff = Convert.ToDouble(reader["Diff"].ToString());
                    oECProductStock.IsRead = (int)reader["IsRead"];
                    oECProductStock.Status = (int)reader["Status"];
                    oECProductStock.StatusName = (string)reader["StatusName"];
                    
                    InnerList.Add(oECProductStock);
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

    public class ECProductAction
    {
        private string _sProductCode;
        private int _nActionID;

        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        /// <summary>
        /// Get set property for ActionID
        /// </summary>
        public int ActionID
        {
            get { return _nActionID; }
            set { _nActionID = value; }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_ECProductAction VALUES(?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PCode", _sProductCode);
                cmd.Parameters.AddWithValue("ActionID", _nActionID);
                
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
                Complain oItem = new Complain();

                cmd.CommandText = "DELETE FROM t_ECProductAction WHERE [PCode]=? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PCode", _sProductCode);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
    public class ECProductActions : CollectionBase
    {
        public ECProductAction this[int i]
        {
            get { return (ECProductAction)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ECProductAction oECProductAction)
        {
            InnerList.Add(oECProductAction);
        }
        public void Refresh(string sPCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select * from t_ECProductAction Where PCode=?";

            cmd.Parameters.AddWithValue("PCode", sPCode);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ECProductAction oECProductAction = new ECProductAction();

                    oECProductAction.ProductCode = (string)reader["PCode"];
                    oECProductAction.ActionID = (int)reader["ActionID"];

                    InnerList.Add(oECProductAction);
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
