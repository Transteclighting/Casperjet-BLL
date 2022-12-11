// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jul 01, 2014
// Time :  12:17 PM
// Description: Class for SCM Sales Plan
// Modify Person And Date: 
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;

namespace CJ.Class.SupplyChain
{
    public class SCMSalesPlanItem
    { 
        private int _nSCMSalesPlanID;
        private int _nProductID;
        private int _nQty;
        private string _sProductCode;
        private string _sProductName;
        private double _RSP;

        private string _sInnerCode;
        private string _sOuterCode;
        private double _InnerQty;
        private double _OuterQty;

        public string InnerCode
        {
            get { return _sInnerCode; }
            set { _sInnerCode = value; }
        }

        public string OuterCode
        {
            get { return _sOuterCode; }
            set { _sOuterCode = value; }
        }

        public double InnerQty
        {
            get { return _InnerQty; }
            set { _InnerQty = value; }
        }

        public double OuterQty
        {
            get { return _OuterQty; }
            set { _OuterQty = value; }
        }

        /// <summary>
        /// Get set property for SCmSalesPlanID
        /// </summary>
        public int SCMSalesPlanID
        {
            get { return _nSCMSalesPlanID; }
            set { _nSCMSalesPlanID = value; }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }

        private int _TranID;
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        private DateTime _dDate;
        public DateTime DDate
        {
            get { return _dDate; }
            set { _dDate = value; }
        }

        public void Add(int nSCMSalesPlanID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_SCMSalesPlanItem(SCmSalesPlanID, ProductID,Qty) VALUES(?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SCmSalesPlanID", nSCMSalesPlanID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nSCMSalesPlanID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "Delete from t_SCMSalesPlanItem Where SCmSalesPlanID=? ";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("SCmSalesPlanID", nSCMSalesPlanID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /* Functions For Uploader 
         * Shakil Imtiaj
         * 20 Sep 2021 */

        public void AddSales()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_scmrm(TranID,ProductID,RMDate,Qty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", TranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("RMDate", DDate);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteSalesPlan()
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                cmd.CommandText = "Delete  from  t_scmpipeline";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteSales()
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                cmd.CommandText = "Delete  from    t_scmrm";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddPlan()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_scmpipeline(TranID,ProductID,EstimatedDoD,Qty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", TranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("EstimitedDoD", DDate);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddSalesPack()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_FGCodewisePackingCode(TranID,FGCode,PackDate,InnerCode,InnerQty,OuterCode,OuterQty) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", TranID);
                cmd.Parameters.AddWithValue("FGCode", _sProductCode);
                cmd.Parameters.AddWithValue("PackDate", DDate);
                cmd.Parameters.AddWithValue("InnerCode", _sInnerCode);
                cmd.Parameters.AddWithValue("InnerQty", _InnerQty);
                cmd.Parameters.AddWithValue("OuterCode", _sOuterCode);
                cmd.Parameters.AddWithValue("OuterQty", _OuterQty);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteSalesPack()
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                cmd.CommandText = "Delete  from    t_FGCodewisePackingCode ";
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
    public class SCMSalesPlan : CollectionBase
    {
        private int _nSCMSalesPlanID;
        private DateTime _dPlanMonth;
        private int _nASGID;
        private int _nBrandID;
        private int _nPlanQty;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        


        /// <summary>
        /// Get set property for SCmSalesPlanID
        /// </summary>
        public int SCMSalesPlanID
        {
            get { return _nSCMSalesPlanID; }
            set { _nSCMSalesPlanID = value; }
        }
        /// <summary>
        /// Get set property for PlanMonth
        /// </summary>
        public DateTime PlanMonth
        {
            get { return _dPlanMonth; }
            set { _dPlanMonth = value; }
        }
        /// <summary>
        /// Get set property for ASGID
        /// </summary>
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        /// <summary>
        /// Get set property for BrandID
        /// </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        /// <summary>
        /// Get set property for PlanQty
        /// </summary>
        public int PlanQty
        {
            get { return _nPlanQty; }
            set { _nPlanQty = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
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

        private string _sASGname;
        public string ASGname
        {
            get { return _sASGname; }
            set { _sASGname = value; }
        }
        private string _sBrand;
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value; }
        }


        public SCMSalesPlanItem this[int i]
        {
            get { return (SCMSalesPlanItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMSalesPlanItem oSCMSalesPlanItem)
        {
            InnerList.Add(oSCMSalesPlanItem);
        }

        public void Add()
        {
            int nMaxSCMSalesPlanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SCMSalesPlanID]) FROM t_SCMSalesPlan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSCMSalesPlanID = 1;
                }
                else
                {
                    nMaxSCMSalesPlanID = Convert.ToInt32(maxID) + 1;
                }
                _nSCMSalesPlanID = nMaxSCMSalesPlanID;


                sSql = "INSERT INTO t_SCMSalesPlan(SCmSalesPlanID,PlanMonth,ASGID, BrandID,PlanQty,Status,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SCmSalesPlanID", _nSCMSalesPlanID);
                cmd.Parameters.AddWithValue("PlanMonth", _dPlanMonth);
                cmd.Parameters.AddWithValue("ASGID", _nASGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("PlanQty", _nPlanQty);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                SCMSalesPlanItem oSCMSalesPlanItem = new SCMSalesPlanItem();
                oSCMSalesPlanItem.Delete(_nSCMSalesPlanID);

                foreach (SCMSalesPlanItem oItem in this)
                {
                    oItem.Add(_nSCMSalesPlanID);
                }
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

                cmd.CommandText = "Delete from t_SCMSalesPlan Where SCmSalesPlanID=? ";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("SCmSalesPlanID", _nSCMSalesPlanID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nASGID, int nBrandID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ProductID, ProductCode,ProductName,IsNull(RSP,0)RSP from v_ProductDetails Where ASGID=" + nASGID + " and BrandID=" + nBrandID + " Order By ProductName Desc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SCMSalesPlanItem oSCMSalesPlanItem = new SCMSalesPlanItem();

                    oSCMSalesPlanItem.ProductID = (int)reader["ProductID"];
                    oSCMSalesPlanItem.ProductCode = (string)reader["ProductCode"];
                    oSCMSalesPlanItem.ProductName = (string)reader["ProductName"];
                    oSCMSalesPlanItem.RSP = Convert.ToDouble(reader["RSP"].ToString());

                    InnerList.Add(oSCMSalesPlanItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetExistingProduct(int nASGID, int nBrandID, int nSCMSalesPlanID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ProductID, ProductCode,ProductName,Qty, IsNull(RSP,0)RSP from "+
                           " ( "+
                           " Select ProductID, ProductCode,ProductName,0 as Qty,RSP from v_ProductDetails where "+
                           " ASGID=" + nASGID + " and BrandID=" + nBrandID + " and productID Not IN ( " +
                           " select ProductID from t_SCMSalesPlanItem Where SCMSalesPlanID=" + nSCMSalesPlanID + ") " +
                           " UNION ALL "+
                           " Select a.ProductID, ProductCode, ProductName, Qty, RSP from  "+
                           " (select * from t_SCMSalesPlanItem Where SCMSalesPlanID=" + nSCMSalesPlanID + ")a,  " +
                           " (Select ProductID,ProductCode,ProductName, RSP from v_ProductDetails) b Where a.ProductID=b.productID "+
                           " )a Order by ProductName Desc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SCMSalesPlanItem oSCMSalesPlanItem = new SCMSalesPlanItem();

                    oSCMSalesPlanItem.ProductID = (int)reader["ProductID"];
                    oSCMSalesPlanItem.ProductCode = (string)reader["ProductCode"];
                    oSCMSalesPlanItem.ProductName = (string)reader["ProductName"];
                    oSCMSalesPlanItem.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    oSCMSalesPlanItem.Qty = (int)reader["Qty"];

                    InnerList.Add(oSCMSalesPlanItem);
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
    public class SCMSalesPlans : CollectionBase
    {

        public SCMSalesPlan this[int i]
        {
            get { return (SCMSalesPlan)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SCMSalesPlan oSCMSalesPlan)
        {
            InnerList.Add(oSCMSalesPlan);
        }
        public int GetIndex(int nSCMSalesPlanIDD)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SCMSalesPlanID == nSCMSalesPlanIDD)
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

            string sSql = " Select a.*,ASGName,BrandDesc from t_SCMSalesPlan a,  " +
                        "(Select PdtGroupID as ASGID, PdtGroupName as ASGName from t_ProductGroup where PdtGroupType=3)b, " +
                        "(Select BrandID, BrandDesc from t_Brand Where Brandlevel=1)c " +
                        "Where a.BrandID=c.BrandID and a.ASGID=b.ASGID ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SCMSalesPlan oSCMSalesPlan = new SCMSalesPlan();

                    oSCMSalesPlan.SCMSalesPlanID = (int)reader["SCMSalesPlanID"];
                    oSCMSalesPlan.PlanMonth = Convert.ToDateTime(reader["PlanMonth"].ToString());
                    oSCMSalesPlan.Brand = (string)reader["BrandDesc"];
                    oSCMSalesPlan.ASGname = (string)reader["ASGName"];
                    oSCMSalesPlan.ASGID = (int)reader["ASGID"];
                    oSCMSalesPlan.BrandID = (int)reader["BrandID"];
                    oSCMSalesPlan.PlanQty = (int)reader["PlanQty"];

                    InnerList.Add(oSCMSalesPlan);
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
