// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jul 29, 2012
// Time :  11:43 AM
// Description: Class for Spare Parts From Cassandra.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Class
{
    public class SpareParts
    {

        private int _nID;
        private string _sCode;
        private string _sName;
        private string _sModelNo;
        private double _sCostPrice;
        private double _sSalePrice;
        private int _nParentID;
        private int _nStatus;
        private int _nReorderLevel;
        private int _nLocationID;
        private string _sLocationCode;
        private string _sLocationName;

        private int _nBrandID;
        private string _sBrandName;
        private bool _bFlag;

        private int _nJobID;
        private int _nPartsID;
        private double _UnitPrice;
        private int _nQty;
        private int _nCreateUserID;
        private DateTime _dCreateDate; 

        private string _sSpareCategoryName;

        // <summary>
        // Get set property for _sLocationName
        // </summary>
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value; }
        }
        // <summary>
        // Get set property for JobID
        // </summary>
        public string SpareCategoryName
        {
            get { return _sSpareCategoryName; }
            set { _sSpareCategoryName = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for PartsID
        // </summary>
        public int PartsID
        {
            get { return _nPartsID; }
            set { _nPartsID = value; }
        }

        // <summary>
        // Get set property for UnitPrice
        // </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        } 


        private User _oUser;

        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        /// Get set property for ModelNo
        /// </summary>
        public string ModelNo
        {
            get { return _sModelNo; }
            set { _sModelNo = value; }
        }
        /// <summary>
        /// Get set property for CostPrice
        /// </summary>
        public double CostPrice
        {
            get { return _sCostPrice; }
            set { _sCostPrice = value; }
        }
        /// <summary>
        /// Get set property for Contact SalePrice
        /// </summary>
        public double SalePrice
        {
            get { return _sSalePrice; }
            set { _sSalePrice = value; }
        }
        /// <summary>
        /// Get set property for ParentID
        /// </summary>
        public int ParentID
        {
            get { return _nParentID; }
            set { _nParentID = value; }
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
        /// Get set property for ReorderLevel
        /// </summary>
        public int ReorderLevel
        {
            get { return _nReorderLevel; }
            set { _nReorderLevel = value; }
        }
        /// <summary>
        /// Get set property for LocationID
        /// </summary>
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }
        /// <summary>
        /// Get set property for LocationCode
        /// </summary>
        public string LocationCode
        {
            get { return _sLocationCode; }
            set { _sLocationCode = value; }
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
        /// Get set property for BrandName
        /// </summary>
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
            }
        }

        private string _sCP;
        public string sCP
        {
            get { return _sCP; }
            set { _sCP = value; }
        }
        private string _sTotalCP;
        public string sTotalCP
        {
            get { return _sTotalCP; }
            set { _sTotalCP = value; }
        }
        private string _sSumCP;
        public string sSumCP
        {
            get { return _sSumCP; }
            set { _sSumCP = value; }
        }
        private string _sSumCPTotal;
        public string sSumCPTotal
        {
            get { return _sSumCPTotal; }
            set { _sSumCPTotal = value; }
        }
        private double _TotalCost;
        public double TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; }
        }

        public void AddEstimatedSpareParts()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_CSDEstimatedSpareParts (JobID, PartsID, UnitPrice, Qty, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("PartsID", _nPartsID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBySPCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from TELServiceDB.dbo.SpareParts where Code=?";

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    _nID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else _bFlag = false;
        }

        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_CSDSpareParts where Code=?";

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nID = (int)reader["SparePartID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else _bFlag = false;
        }
        public void RefreshBySPID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_CSDSpareParts where SparePartID=?";

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["SparePartID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _sCostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else _bFlag = false;
        }
        public void RefreshSpareParts()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Select * from TELServiceDB.dbo.SpareParts where ID=?";

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());

                    
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class SparePartss : CollectionBase
    {
        public SpareParts this[int i]
        {
            get { return (SpareParts)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SpareParts oSpareParts)
        {
            InnerList.Add(oSpareParts);
        }


        public void Refresh(String txtCode, String txtName, String txtModel,String txtBrand, String txtLocationCode)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ID, SP.Code SPCode, SP.Name SpareName, ModelNo, L.Code LocationCode, "+
                            "B.Name Brand, SalePrice from TELServiceDB.dbo.SpareParts SP " +
                            "INNER JOIN TELServiceDB.dbo.Brand B " +
                            "ON SP.BrandID=B.BrandID " +
                            "INNER JOIN TELServiceDB.dbo.SPLocation L " +
                            "ON L.SPLocationID=SP.LocationID ";


            if (txtCode != "")
            {
                txtCode = "%" + txtCode + "%";
                sSql = sSql + " AND SP.Code LIKE '" + txtCode + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND SP.Name LIKE '" + txtName + "'";
            }
            if (txtModel != "")
            {
                txtModel = "%" + txtModel + "%";
                sSql = sSql + " AND ModelNo LIKE '" + txtModel + "'";
            }
            if (txtBrand != "")
            {
                txtBrand = "%" + txtBrand + "%";
                sSql = sSql + " AND B.Name LIKE '" + txtBrand + "'";
            }
            if (txtLocationCode != "")
            {
                //txtLocationCode = "%" + txtLocationCode + "%";
                sSql = sSql + " AND L.Code LIKE '" + txtLocationCode + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SpareParts oSpareParts = new SpareParts();


                    oSpareParts.ID = (int)reader["ID"];
                    oSpareParts.Code = (string)reader["SPCode"];
                    oSpareParts.Name = (string)reader["SpareName"];
                    oSpareParts.ModelNo = (string)reader["ModelNo"];
                    oSpareParts.BrandName = (string)reader["Brand"];
                    oSpareParts.SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    oSpareParts.LocationCode = (string)reader["LocationCode"];

                    InnerList.Add(oSpareParts);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForStock(int nChildStoreID, int nParentStoreID, int nSpareCategoryID,int nSPLocationID, string sSpareCode, string sSpareName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select c.SparePartID,b.StoreID,c.SPGroupID,c.Code SPCode,SPLocationID, " +
                         "c.Name AS SpareName,c.ModelNo,d.Name SpareCategoryName,a.CurrentStockQty, "+
                         "c.CostPrice,c.SalePrice from dbo.t_CSDSparePartStock a "+
                         "LEFT JOIN t_CSDStore b ON a.StoreID = b.StoreID "+
                         "INNER JOIN t_CSDSpareParts c on a.SparePartID = c.SparePartID " +
                         "LEFT JOIN dbo.t_CSDSPGroup d ON c.SPGroupID= d.SPGroupID LEFT JOIN dbo.t_CSDSPLocation e ON c.LocationID= e.SPLocationID WHERE 1=1 ";

            if (nChildStoreID != 0)
            {
                sSql += " AND b.StoreID = " + nChildStoreID + " ";
            }
            if (nParentStoreID != 0)
            {
                sSql += " AND b.ParentID = " + nParentStoreID + " ";
            }
            if (nSpareCategoryID != 0)
            {
                sSql += " AND d.SPGroupID = " + nSpareCategoryID + " ";
            }
            if (nSPLocationID != 0)
            {
                sSql += " AND SPLocationID = " + nSPLocationID + " ";
            }
            if (sSpareCode != string.Empty)
            {
                sSql += " AND c.Code Like '%" + sSpareCode + "%' ";
            }
            if (sSpareName != string.Empty)
            {
                sSql += " AND c.Name Like '%" + sSpareName + "%' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SpareParts oSpareParts = new SpareParts();

                    oSpareParts.ID = (int)reader["SparePartID"];
                    oSpareParts.Code = (string)reader["SPCode"];
                    oSpareParts.Qty = (int)reader["CurrentStockQty"];
                    oSpareParts.Name = (string)reader["SpareName"];
                    oSpareParts.ModelNo = (string)reader["ModelNo"];
                    oSpareParts.SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    oSpareParts.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oSpareParts.SpareCategoryName = (string)reader["SpareCategoryName"];
                    InnerList.Add(oSpareParts);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshSP(String txtCode, String txtName, String txtModel, String txtBrand, String txtLocationCode)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SparePartID, SP.Code SPCode, SP.Name SpareName, ModelNo, L.LocationName LocationCode,  " +
                          "B.BrandDesc Brand, SalePrice from t_CSDSpareParts SP   " +
                          "INNER JOIN t_Brand B   " +
                          "ON SP.BrandID=B.BrandID   " +
                          "INNER JOIN  t_CSDSPLocation L   " +
                          "ON L.SPLocationID=SP.LocationID";


            if (txtCode != "")
            {
                txtCode = "%" + txtCode + "%";
                sSql = sSql + " AND SP.Code LIKE '" + txtCode + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND SP.Name LIKE '" + txtName + "'";
            }
            if (txtModel != "")
            {
                txtModel = "%" + txtModel + "%";
                sSql = sSql + " AND ModelNo LIKE '" + txtModel + "'";
            }
            if (txtBrand != "")
            {
                txtBrand = "%" + txtBrand + "%";
                sSql = sSql + " AND B.BrandDesc LIKE '" + txtBrand + "'";
            }
            if (txtLocationCode != "")
            {
                sSql = sSql + " AND L.LocationName LIKE '" + txtLocationCode + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SpareParts oSpareParts = new SpareParts();

                    oSpareParts.ID = (int)reader["SparePartID"];
                    oSpareParts.Code = (string)reader["SPCode"];
                    oSpareParts.Name = (string)reader["SpareName"];
                    oSpareParts.ModelNo = (string)reader["ModelNo"];
                    oSpareParts.BrandName = (string)reader["Brand"];
                    oSpareParts.SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    oSpareParts.LocationCode = (string)reader["LocationCode"];

                    InnerList.Add(oSpareParts);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetSPForStockPostion(int nSPID,int nStoreID,DateTime dtTranDate)
        {
            UserPermission oUserPermission = new UserPermission();
            bool _bFlag = oUserPermission.CheckPermission("M34.14.10.1", Utility.UserId);
            double _SumUnitCost = 0;
            double _SumTotalCost = 0;
            TELLib oTELLib = new TELLib();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSubstring = string.Empty;
            if (nSPID != -1)
            {
                sSubstring = " AND SparePartID = "+nSPID+" ";
            }
            string sSql = "Select f.*,sp.Code SpCode, sp.Name SPName,sp.ModelNo,pg.Name SPGroupName,l.LocationName,SP.CostPrice as CostPrice,(OpeningStock*CostPrice)as TotalCost from" 
                        +" (select SparePartID, ((Sum(CurrentStock) +Sum(StockOut))-Sum(StockIn)) as OpeningStock from("
                        +" select SparePartID, CurrentStock = 0, StockIn=0, b.Qty StockOut from dbo.t_CSDSPTran a"
                        + " INNER JOIN (select SPTranID, SparePartID, SUM(Qty) Qty from dbo.t_CSDSPTranItem WHERE 1=1 " + sSubstring + " "
                        + " Group BY SPTranID, SparePartID) b"
                        + " ON a.SPTranID = b.SPTranID WHERE TranDate between '" + dtTranDate + "' and '31-Mar-2060' "
                        + " and FromStoreID = " + nStoreID + " "
                        +" UNION ALL"
                        +" select SparePartID, CurrentStock = 0, b.Qty StockIn, StockOut=0 from dbo.t_CSDSPTran a "
                        + " INNER JOIN (select SPTranID,SparePartID, SUM(Qty) Qty from dbo.t_CSDSPTranItem WHERE 1=1 " + sSubstring + " "
                        +" Group BY SPTranID,SparePartID) b "
                        + " ON a.SPTranID = b.SPTranID WHERE TranDate between '" + dtTranDate + "' and '31-Mar-2060' "
                        + " and ToStoreID = " + nStoreID + ""
                        +" UNION ALL"
                        + " Select SparePartID, CurrentStockQty, 0 as StockIn, 0 as StockOut from t_CSDSparePartStock Where  StoreID = " + nStoreID + "  " + sSubstring + " "
                        +" ) x Group by SparePartID) f"
                        +" INNER JOIN t_CSDSpareParts sp ON f.SparePartID = sp.SparePartID"
                        +" INNER JOIN  dbo.t_CSDSPGroup pg ON pg.SPGroupID=sp.SPgroupID"
                        +" INNER JOIN t_CSDSPLocation l ON l.SPLocationID = sp.LocationID";

                       
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SpareParts oSpareParts = new SpareParts();

                    //oSpareParts.ID = (int)reader["SparePartID"];
                    oSpareParts.Code = (string)reader["SpCode"];
                    oSpareParts.Name = (string)reader["SPName"];
                    oSpareParts.LocationName = (string)reader["LocationName"];
                    oSpareParts.SpareCategoryName = (string)reader["SPGroupName"];
                    oSpareParts.ModelNo = (string)reader["ModelNo"];
                    oSpareParts.Qty = (int)reader["OpeningStock"];
                    oSpareParts.CostPrice = (double)reader["CostPrice"];
                    oSpareParts.TotalCost = (oSpareParts.Qty * oSpareParts.CostPrice);
                    _SumUnitCost += oSpareParts.CostPrice;
                    _SumTotalCost += oSpareParts.TotalCost;
                    if (_bFlag)
                    {
                        oSpareParts.sCP = oTELLib.TakaFormat(oSpareParts.CostPrice);
                        oSpareParts.sTotalCP = oTELLib.TakaFormat(oSpareParts.TotalCost);
                        oSpareParts.sSumCP = oTELLib.TakaFormat(_SumUnitCost);
                        oSpareParts.sSumCPTotal = oTELLib.TakaFormat(_SumTotalCost);
                    }
                    else
                    {
                        oSpareParts.sCP = "*****";
                        oSpareParts.sTotalCP = "*****";
                        oSpareParts.sSumCP = "*****";
                        oSpareParts.sSumCPTotal = "*****";
                    }
                    InnerList.Add(oSpareParts);
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


