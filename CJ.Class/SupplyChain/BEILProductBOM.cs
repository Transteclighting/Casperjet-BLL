using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.SupplyChain
{
    public class BEILProductBOMDetail : CollectionBase
    {
        private int _nID;
        private int _nBOMID;
        private int _nBOMGroupID;
        private string _nBOMGroupName;
        private string _sFMTCOMP;
        private string _sCOMPDESC;
        private int _nQty;
        private string _sUnit;
        private double _CostAllocationPercent;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for BOMID
        // </summary>
        public int BOMID
        {
            get { return _nBOMID; }
            set { _nBOMID = value; }
        }

        // <summary>
        // Get set property for BOMGroupID
        // </summary>
        public int BOMGroupID
        {
            get { return _nBOMGroupID; }
            set { _nBOMGroupID = value; }
        }

        public string BOMGroupName
        {
            get { return _nBOMGroupName; }
            set { _nBOMGroupName = value; }
        }

        // <summary>
        // Get set property for FMTCOMP
        // </summary>
        public string FMTCOMP
        {
            get { return _sFMTCOMP; }
            set { _sFMTCOMP = value.Trim(); }
        }

        // <summary>
        // Get set property for COMPDESC
        // </summary>
        public string COMPDESC
        {
            get { return _sCOMPDESC; }
            set { _sCOMPDESC = value.Trim(); }
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
        // Get set property for Unit
        // </summary>
        public string Unit
        {
            get { return _sUnit; }
            set { _sUnit = value.Trim(); }
        }

        // <summary>
        // Get set property for CostAllocationPercent
        // </summary>
        public double CostAllocationPercent
        {
            get { return _CostAllocationPercent; }
            set { _CostAllocationPercent = value; }
        }

        public void Add(int nBOMID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_BEILProductBOMDetail";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_BEILProductBOMDetail (ID, BOMID, BOMGroupID, FMTCOMP, COMPDESC, Qty, Unit, CostAllocationPercent) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("BOMID", nBOMID);
                cmd.Parameters.AddWithValue("BOMGroupID", _nBOMGroupID);
                cmd.Parameters.AddWithValue("FMTCOMP", _sFMTCOMP);
                cmd.Parameters.AddWithValue("COMPDESC", _sCOMPDESC);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Unit", _sUnit);
                cmd.Parameters.AddWithValue("CostAllocationPercent", _CostAllocationPercent);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_BEILProductBOMDetail SET BOMID = ?, BOMGroupID = ?, FMTCOMP = ?, COMPDESC = ?, Qty = ?, Unit = ?, CostAllocationPercent = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("BOMGroupID", _nBOMGroupID);
                cmd.Parameters.AddWithValue("FMTCOMP", _sFMTCOMP);
                cmd.Parameters.AddWithValue("COMPDESC", _sCOMPDESC);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Unit", _sUnit);
                cmd.Parameters.AddWithValue("CostAllocationPercent", _CostAllocationPercent);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nBOMID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_BEILProductBOMDetail WHERE [BOMID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BOMID", nBOMID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_BEILProductBOMDetail where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nBOMID = (int)reader["BOMID"];
                    _nBOMGroupID = (int)reader["BOMGroupID"];
                    _sFMTCOMP = (string)reader["FMTCOMP"];
                    _sCOMPDESC = (string)reader["COMPDESC"];
                    _nQty = (int)reader["Qty"];
                    _sUnit = (string)reader["Unit"];
                    _CostAllocationPercent = Convert.ToDouble(reader["CostAllocationPercent"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProductDetails(int productId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select  pd.ProductID,pd.ProductDesc as COMPDESC,  ps.CurrentStock as Qty, pd.SmallUnitOfMeasure as Unit from t_Product pd, t_ProductStock ps where pd.ProductId = ps.ProductId and CurrentStock != 0";


            if (productId != -1)
            {
                sSql += " AND  pd.ProductID = " + productId + " ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BEILProductBOMDetail oBEILProductBOMDetail = new BEILProductBOMDetail();
                    oBEILProductBOMDetail.COMPDESC = (string)reader["COMPDESC"];
                    oBEILProductBOMDetail.Qty = (int)reader["Qty"];
                    oBEILProductBOMDetail.Unit = (string)reader["Unit"];
                    InnerList.Add(oBEILProductBOMDetail);
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



    public class BEILProductBOM : CollectionBase
    {

        public BEILProductBOMDetail this[int i]
        {
            get { return (BEILProductBOMDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(BEILProductBOMDetail oBEILProductBOMDetail)
        {
            InnerList.Add(oBEILProductBOMDetail);
        }


        private int _nBOMID;
        private int _nProductID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private string _nProductCode;
        private string _nProductName;

        // <summary>
        // Get set property for BOMID
        // </summary>
        public int BOMID
        {
            get { return _nBOMID; }
            set { _nBOMID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public string ProductCode
        {
            get { return _nProductCode; }
            set { _nProductCode = value; }
        }

        public string ProductName
        {
            get { return _nProductName; }
            set { _nProductName = value; }
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

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxBOMID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BOMID]) FROM t_BEILProductBOM";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBOMID = 1;
                }
                else
                {
                    nMaxBOMID = Convert.ToInt32(maxID) + 1;
                }
                _nBOMID = nMaxBOMID;
                sSql = "INSERT INTO t_BEILProductBOM (BOMID, ProductID, CreateUserID, CreateDate) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (BEILProductBOMDetail _oBEILProductBOMDetail in this)
                {
                    _oBEILProductBOMDetail.Add(_nBOMID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_BEILProductBOM SET  UpdateUserID = ?, UpdateDate = ? WHERE BOMID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("BOMID", _nBOMID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                BEILProductBOMDetail _oObj = new BEILProductBOMDetail();
                _oObj.Delete(_nBOMID);

                foreach (BEILProductBOMDetail _oBEILProductBOMDetail in this)
                {
                    _oBEILProductBOMDetail.Add(_nBOMID);
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
                sSql = "DELETE FROM t_BEILProductBOM WHERE [BOMID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_BEILProductBOM where BOMID =?";
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBOMID = (int)reader["BOMID"];
                    _nProductID = (int)reader["ProductID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetBOMDetail()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT bd.BOMID, bd.BOMGroupID, pb.BOMDescription, bd.FMTCOMP, bd.COMPDESC, bd.Qty, bd.Unit, bd.CostAllocationPercent FROM t_BEILProductBOMDetail bd, t_PRoductBOM pb where bd.BOMGroupID = pb.BOMID and bd.BOMID = ?";
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BEILProductBOMDetail oBEILProductBOMDetail = new BEILProductBOMDetail();

                    oBEILProductBOMDetail.BOMID = (int)reader["BOMID"];
                    oBEILProductBOMDetail.BOMGroupID = (int)reader["BOMGroupID"];
                    oBEILProductBOMDetail.BOMGroupName = (string)reader["BOMDescription"];
                    oBEILProductBOMDetail.FMTCOMP = (string)reader["FMTCOMP"];
                    oBEILProductBOMDetail.COMPDESC = (string)reader["COMPDESC"];
                    oBEILProductBOMDetail.Qty = (int)reader["Qty"];
                    oBEILProductBOMDetail.Unit = (string)reader["Unit"];
                    oBEILProductBOMDetail.CostAllocationPercent = Convert.ToDouble(reader["CostAllocationPercent"]);

                    InnerList.Add(oBEILProductBOMDetail);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        
        public int RefreshByProductID(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_BEILProductBOM where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBOMID = (int)reader["BOMID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
            return _nBOMID;           
        }
    }
    public class BEILProductBOMs : CollectionBase
    {
        public BEILProductBOM this[int i]
        {
            get { return (BEILProductBOM)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(BEILProductBOM oBEILProductBOM)
        {
            InnerList.Add(oBEILProductBOM);
        }
        public int GetIndex(int nBOMID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BOMID == nBOMID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(int productId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT BOMID, bom.ProductID, p.ProductCode, p.ProductName  FROM t_BEILProductBOM bom, t_Product p where bom.ProductID = p.ProductID";

            if (productId != -1)
            {
                sSql += " AND  bom.ProductID = " + productId + " ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BEILProductBOM oBEILProductBOM = new BEILProductBOM();
                    oBEILProductBOM.BOMID = (int)reader["BOMID"];
                    oBEILProductBOM.ProductID = (int)reader["ProductID"];
                    oBEILProductBOM.ProductCode = (string)reader["ProductCode"];
                    oBEILProductBOM.ProductName = (string)reader["ProductName"];
                    InnerList.Add(oBEILProductBOM);
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

