// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jan 10, 2016
// Time : 12:25 PM
// Description: Class for ProductionLotItem.
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
    public class ProductionLotItem
    {
        private int _nLotPlanID;
        private int _nLotID;
        private int _nProductID;
        private int _nReceiveQty;
        private string _sProductCode;
        private string _sProductName;

        private int _nPlanQty;
        private int _nActualQty;
        private int _nQCPassQty;
        private int _nQCFailQty;
        private int _nPlanManHour;
        private DateTime _dPlanDate;
        private int _nActualManHour;

        private DateTime _dActualDate;

        private double _CostPrice;
        private int _nPlanManDay;
        private string _sPlanRemarks;
        private string _sLotNo;
        private string _sRefNo;

        // <summary>
        // Get set property for PlanRemarks
        // </summary>
        public string PlanRemarks
        {
            get { return _sPlanRemarks; }
            set { _sPlanRemarks = value.Trim(); }
        }



        // <summary>
        // Get set property for CostPrice
        // </summary>
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }



        // <summary>
        // Get set property for LotPlanID
        // </summary>
        public int LotPlanID
        {
            get { return _nLotPlanID; }
            set { _nLotPlanID = value; }
        }



        // <summary>
        // Get set property for ReceiveDate
        // </summary>
        public DateTime PlanDate
        {
            get { return _dPlanDate; }
            set { _dPlanDate = value; }
        }


        // <summary>
        // Get set property for ReceiveDate
        // </summary>
        public DateTime ActualDate
        {
            get { return _dActualDate; }
            set { _dActualDate = value; }
        }

        // <summary>
        // Get set property for ActualManHour
        // </summary>
        public int ActualManHour
        {
            get { return _nActualManHour; }
            set { _nActualManHour = value; }
        }



        // <summary>
        // Get set property for PlanQty
        // </summary>
        public int PlanQty
        {
            get { return _nPlanQty; }
            set { _nPlanQty = value; }
        }

        // <summary>
        // Get set property for ActualQty
        // </summary>
        public int ActualQty
        {
            get { return _nActualQty; }
            set { _nActualQty = value; }
        }

        // <summary>
        // Get set property for QCPassQty
        // </summary>
        public int QCPassQty
        {
            get { return _nQCPassQty; }
            set { _nQCPassQty = value; }
        }

        // <summary>
        // Get set property for QCFailQty
        // </summary>
        public int QCFailQty
        {
            get { return _nQCFailQty; }
            set { _nQCFailQty = value; }
        }



        // <summary>
        // Get set property for LotID
        // </summary>
        public int LotID
        {
            get { return _nLotID; }
            set { _nLotID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for ReceiveQty
        // </summary>
        public int ReceiveQty
        {
            get { return _nReceiveQty; }
            set { _nReceiveQty = value; }
        }

        // <summary>
        // Get set property for ReceiveQty
        // </summary>
        public int PlanManHour
        {
            get { return _nPlanManHour; }
            set { _nPlanManHour = value; }
        }


        // <summary>
        // Get set property for PlanManDay
        // </summary>
        public int PlanManDay
        {
            get { return _nPlanManDay; }
            set { _nPlanManDay = value; }
        }


        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string LotNo
        {
            get { return _sLotNo; }
            set { _sLotNo = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string RefNo
        {
            get { return _sRefNo; }
            set { _sRefNo = value.Trim(); }
        }



        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ProductionLotItem (LotID, ProductID, ReceiveQty) VALUES(?,?,?)";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("LotID", _nLotID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ReceiveQty", _nReceiveQty);

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
                sSql = "UPDATE t_ProductionLotItem SET ProductID = ?, ReceiveQty = ? WHERE LotID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ReceiveQty", _nReceiveQty);

                cmd.Parameters.AddWithValue("LotID", _nLotID);

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
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_ProductionLotItem WHERE [LotID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LotID", _nLotID);
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
                cmd.CommandText = "SELECT * FROM t_ProductionLotItem where LotID =?";
                cmd.Parameters.AddWithValue("LotID", _nLotID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLotID = (int)reader["LotID"];
                    _nProductID = (int)reader["ProductID"];
                    _nReceiveQty = (int)reader["ReceiveQty"];
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
    public class ProductionLot : CollectionBase
    {
        public ProductionLotItem this[int i]
        {
            get { return (ProductionLotItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductionLotItem oProductionLotItem)
        {
            InnerList.Add(oProductionLotItem);
        }
        private int _nLotID;
        private int _nLotType;
        private int _nWorkType;
        private string _sLotNo;
        private string _sRefNo;
        private DateTime _dReceiveDate;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nStatus;
        private string _sProductCode;
        private string _sProductName;
        private int _nReceiveQty;

        private int _nPlanQty;
        private int _nActualQty;
        private int _nQCPassQty;
        private int _nQCFailQty;
        private int _nProductID;
        private int _nChallanQty;

        private int _nAGID;
        private string _sAGName;
        private int _nASGID;
        private string _sASGName;
        private int _nMAGID;
        private string _sMAGName;
        private int _nPGID;
        private string _sPGName;
        private int _nBrandID;
        private string _sBrandDesc;
        private int _nRefLotID;




        // <summary>
        // Get set property for AGID
        // </summary>
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        
        // <summary>
        // Get set property for AGName
        // </summary>
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }

        // <summary>
        // Get set property for ASGID
        // </summary>
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        // <summary>
        // Get set property for ASGName
        // </summary>
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }

        // <summary>
        // Get set property for MAGID
        // </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        // <summary>
        // Get set property for MAGName
        // </summary>
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }

        // <summary>
        // Get set property for PGID
        // </summary>
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }

        // <summary>
        // Get set property for PGName
        // </summary>
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        // <summary>
        // Get set property for BrandDesc
        // </summary>
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }




        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        // <summary>
        // Get set property for LotID
        // </summary>
        public int ReceiveQty
        {
            get { return _nReceiveQty; }
            set { _nReceiveQty = value; }
        }



        // <summary>
        // Get set property for PlanQty
        // </summary>
        public int PlanQty
        {
            get { return _nPlanQty; }
            set { _nPlanQty = value; }
        }

        // <summary>
        // Get set property for ActualQty
        // </summary>
        public int ActualQty
        {
            get { return _nActualQty; }
            set { _nActualQty = value; }
        }

        // <summary>
        // Get set property for QCPassQty
        // </summary>
        public int QCPassQty
        {
            get { return _nQCPassQty; }
            set { _nQCPassQty = value; }
        }

        // <summary>
        // Get set property for QCFailQty
        // </summary>
        public int QCFailQty
        {
            get { return _nQCFailQty; }
            set { _nQCFailQty = value; }
        }


        // <summary>
        // Get set property for ChallanQty
        // </summary>
        public int ChallanQty
        {
            get { return _nChallanQty; }
            set { _nChallanQty = value; }
        }




        // <summary>
        // Get set property for LotID
        // </summary>
        public int LotID
        {
            get { return _nLotID; }
            set { _nLotID = value; }
        }

        // <summary>
        // Get set property for LotType
        // </summary>
        public int LotType
        {
            get { return _nLotType; }
            set { _nLotType = value; }
        }

        // <summary>
        // Get set property for WorkType
        // </summary>
        public int WorkType
        {
            get { return _nWorkType; }
            set { _nWorkType = value; }
        }

        // <summary>
        // Get set property for LotNo
        // </summary>
        public string LotNo
        {
            get { return _sLotNo; }
            set { _sLotNo = value.Trim(); }
        }

        // <summary>
        // Get set property for RefNo
        // </summary>
        public string RefNo
        {
            get { return _sRefNo; }
            set { _sRefNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ReceiveDate
        // </summary>
        public DateTime ReceiveDate
        {
            get { return _dReceiveDate; }
            set { _dReceiveDate = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }


        // <summary>
        // Get set property for Status
        // </summary>
        public int RefLotID
        {
            get { return _nRefLotID; }
            set { _nRefLotID = value; }
        }

        public void Add1()
        {
            int nMaxLotID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LotID]) FROM t_ProductionLot";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLotID = 1;
                }
                else
                {
                    nMaxLotID = Convert.ToInt32(maxID) + 1;
                }
                _nLotID = nMaxLotID;
                sSql = "INSERT INTO t_ProductionLot (LotID, LotType, WorkType, LotNo, RefNo, ReceiveDate, Remarks, CreateUserID, CreateDate, UpdateUserID, UpdateDate, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LotID", _nLotID);
                cmd.Parameters.AddWithValue("LotType", _nLotType);
                cmd.Parameters.AddWithValue("WorkType", _nWorkType);
                cmd.Parameters.AddWithValue("LotNo", _sLotNo);
                cmd.Parameters.AddWithValue("RefNo", _sRefNo);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Add()
        {
            int nMaxID = 0;
            int nLotID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LotID]) FROM t_ProductionLot";
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
                _nLotID = nMaxID;

                string sLotNo = "";
                DateTime dToday = DateTime.Today;
                sLotNo = "Lot" + "-" + dToday.ToString("yy") + _nLotID.ToString("000");
                _sLotNo = sLotNo;

                sSql = "INSERT INTO t_ProductionLot (LotID, LotType, WorkType, LotNo, RefNo, ReceiveDate, Remarks, CreateUserID, CreateDate, UpdateUserID, UpdateDate, Status, RefLotID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LotID", _nLotID);
                cmd.Parameters.AddWithValue("LotType", _nLotType);
                cmd.Parameters.AddWithValue("WorkType", _nWorkType);
                cmd.Parameters.AddWithValue("LotNo", _sLotNo);
                cmd.Parameters.AddWithValue("RefNo", _sRefNo);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_nRefLotID == 0)
                {
                    cmd.Parameters.AddWithValue("RefLotID", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefLotID", _nRefLotID);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (ProductionLotItem oItem in this)
                {
                    oItem.LotID = _nLotID;
                    oItem.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit(int nLotID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ProductionLot SET LotType = ?, WorkType = ?, RefNo = ?, ReceiveDate = ?, Remarks = ?, UpdateUserID = ?, UpdateDate = ?, RefLotID = ? WHERE LotID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LotType", _nLotType);
                cmd.Parameters.AddWithValue("WorkType", _nWorkType);
                cmd.Parameters.AddWithValue("RefNo", _sRefNo);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                
                if (_nRefLotID == 0)
                {
                    cmd.Parameters.AddWithValue("RefLotID", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefLotID", _nRefLotID);
                }
                cmd.Parameters.AddWithValue("LotID", nLotID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();

                ProductionLotItem oItems = new ProductionLotItem();
                oItems.LotID = nLotID;
                oItems.Delete();

                foreach (ProductionLotItem oItem in this)
                {
                    oItem.LotID = nLotID;
                    oItem.Add();
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
                sSql = "DELETE FROM t_ProductionLot WHERE [LotID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LotID", _nLotID);
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
                cmd.CommandText = "SELECT * FROM t_ProductionLot where LotID =?";
                cmd.Parameters.AddWithValue("LotID", _nLotID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLotID = (int)reader["LotID"];
                    _nLotType = (int)reader["LotType"];
                    _nWorkType = (int)reader["WorkType"];
                    _sLotNo = (string)reader["LotNo"];
                    _sRefNo = (string)reader["RefNo"];
                    _dReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetLotItem(int nLotID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select a.LotID,b.ProductID,ProductCode,ProductName,ReceiveQty " +
                                  " from t_ProductionLot a, t_ProductionLotItem b,v_ProductDetails c  " +
                                  " where a.LotID=b.LotID and b.ProductID=c.ProductID and a.LotID= ?";

                cmd.Parameters.AddWithValue("LotID", nLotID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLotItem oItem = new ProductionLotItem();

                    oItem.LotID = int.Parse(reader["LotID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.ReceiveQty = int.Parse(reader["ReceiveQty"].ToString());
                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetLotItemForRework(int nLotID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From "+
                                " (Select a.LotID,LotNo,RefNo,ProductID,ProductCode,ProductName,QCFailQty From  "+
                                " (Select * From dbo.t_ProductionLot) a "+
                                " left outer Join  "+
                                " (Select LotID,a.ProductID,ProductCode,ProductName,sum(QCFailQty) QCFailQty "+
                                " From dbo.t_ProductionLotItemPlan a,t_ProductionLotItemActual b,v_ProductDetails c "+
                                " where a.LotPlanID=b.LotPlanID and a.ProductID=b.ProductID  "+
                                " and a.ProductID=c.ProductID and b.ProductID=c.ProductID "+
                                " and QCFailQty<>0 "+
                                " group by LotID,a.ProductID,ProductCode,ProductName) b " +
                                " on a.LotID=b.LotID) Main where LotID= ? ";

                cmd.Parameters.AddWithValue("LotID", nLotID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLotItem oItem = new ProductionLotItem();

                    oItem.LotID = int.Parse(reader["LotID"].ToString());
                    oItem.LotNo = (reader["LotNo"].ToString());
                    oItem.RefNo = (reader["RefNo"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.QCFailQty = int.Parse(reader["QCFailQty"].ToString());
                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetActualItem(int nLotID, int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "   Select * From  "+
                                  "  (Select a.*,isnull(ActualQty,0) ActualQty,  "+
                                  "  isnull(QCPassQty,0) QCPassQty ,isnull(QCFailQty,0) QCFailQty From   "+
                                  "  (Select LotPlanID,LotID,ProductID,PlanManDay,Plandate,PlanManHour,PlanQty   " +
                                  "  From dbo.t_ProductionLotItemPlan) a  "+
                                  "  Left Outer Join  "+
                                  "  (Select LotPlanID,ProductID,sum(ActualQty) ActualQty,  "+
                                  "  sum (QCPassQty) QCPassQty ,sum(QCFailQty) QCFailQty     "+
                                  "  From dbo.t_ProductionLotItemActual group by LotPlanID,ProductID) b  "+
                                  "  on a.LotPlanID=b.LotPlanID) XX Where ActualQty<>PlanQty and ProductID=" + nProductID + " and LotID=" + nLotID + "";

                //cmd.Parameters.AddWithValue("LotID", nLotID);
                //cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLotItem oItem = new ProductionLotItem();

                    oItem.LotPlanID = int.Parse(reader["LotPlanID"].ToString());
                    oItem.LotID = int.Parse(reader["LotID"].ToString());
                    oItem.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oItem.PlanDate = Convert.ToDateTime(reader["PlanDate"].ToString());
                    oItem.PlanManDay = int.Parse(reader["PlanManDay"].ToString());
                    oItem.PlanManHour = int.Parse(reader["PlanManHour"].ToString());
                    oItem.PlanQty = int.Parse(reader["PlanQty"].ToString());
                    oItem.ActualQty = int.Parse(reader["ActualQty"].ToString());
                    oItem.QCPassQty = int.Parse(reader["QCPassQty"].ToString());
                    oItem.QCFailQty = int.Parse(reader["QCFailQty"].ToString());
                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLotStatus(int nLotID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select LotID,Status From  "+
                                " (Select x.LotID,ReceiveQty,isnull(PlanQty,0) as PlanQty,isnull(ActualQty,0) ActualQty,    "+
                                " Status=Case when ReceiveQty=PlanQty and ActualQty=0 then 2     "+
                                " when ReceiveQty!=PlanQty and PlanQty>0 and ActualQty=0 then 3  "+
                                " when ReceiveQty=PlanQty and ActualQty>0 then 4    "+
                                " when ReceiveQty!=PlanQty and PlanQty>0 and ActualQty>0 then 5   "+
                                " else 1 end From     "+
                                " (Select * From (Select a.LotID,sum(ReceiveQty) ReceiveQty From t_ProductionLot a,t_ProductionLotItem b    "+
                                " where a.LotID=b.LotID group by a.LotID) a) x    "+
                                " Left Outer Join     "+
                                " (    "+
                                " Select LotID,sum(PlanQty) PlanQty,sum(ActualQty) ActualQty From     "+
                                " (Select a.*,isnull(ActualQty,0) ActualQty From     "+
                                " (Select LotID,LotPlanID,isnull(sum(PlanQty),0) PlanQty      "+
                                " From dbo.t_ProductionLotItemPlan group by LotID,LotPlanID) a    "+
                                " Left Outer Join    "+
                                " (Select LotPlanID,isnull(sum(ActualQty),0) ActualQty     "+
                                " From dbo.t_ProductionLotItemActual group by LotPlanID) b   "+
                                " on a.LotPlanID=b.LotPlanID) x group by LotID) y     " +
                                " on x.LotID=y.LotID ) xx where LotID = ? ";

                cmd.Parameters.AddWithValue("LotID", nLotID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLotID = (int)reader["LotID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ProductionLot SET Status = ? WHERE LotID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("LotID", _nLotID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetQCPassQty(int nTypeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select * From (Select ProductID,ProductCode,ProductName,CostPrice,(QCPassQty-ChallanQty) as QCPassQty From  "+ 
                                  " (Select x.*,isnull(ChallanQty,0) ChallanQty From     "+
                                  " (Select * From (Select a.ProductID,ProductCode,ProductName,CostPrice,sum(QCPassQty) QCPassQty   "+
                                  " From t_ProductionLotItemActual a,t_ProductionLotItemPlan b,v_productDetails c  "+
                                  " where a.LotPlanID=b.LotPlanID and a.ProductID=b.ProductID and a.ProductID=c.ProductID and LotType =" + nTypeID + " " +
                                  " group by a.ProductID,ProductCode,ProductName,CostPrice) a)  x    "+
                                  " Left Outer Join     "+
                                  " (Select ProductID,sum (ChallanQty) ChallanQty     "+
                                  " From t_ProductionLotDeliveryItem group by ProductID) y    " +
                                  " on x.ProductID=y.ProductID) xx) yy where QCPassQty>0  ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLotItem oItem = new ProductionLotItem();

                    oItem.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oItem.QCPassQty = int.Parse(reader["QCPassQty"].ToString());
                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPlan(int nLotID, int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select LotPlanID,LotID,ProductID,PlanQty,PlanManHour,PlanManDay,PlanDate,isnull(PlanRemarks,'') PlanRemarks From t_ProductionLotItemPlan where LotID = ? and ProductID = ? ";

                cmd.Parameters.AddWithValue("LotID", nLotID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLotItem oItem = new ProductionLotItem();

                    oItem.LotPlanID = int.Parse(reader["LotPlanID"].ToString());
                    oItem.LotID = int.Parse(reader["LotID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.PlanQty = int.Parse(reader["PlanQty"].ToString());
                    oItem.PlanManHour = int.Parse(reader["PlanManHour"].ToString());
                    oItem.PlanManDay = int.Parse(reader["PlanManDay"].ToString());
                    oItem.PlanDate = Convert.ToDateTime(reader["PlanDate"].ToString());
                    oItem.PlanRemarks = (reader["PlanRemarks"].ToString());

                    InnerList.Add(oItem);
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
    public class ProductionLots : CollectionBase
    {
        public ProductionLot this[int i]
        {
            get { return (ProductionLot)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductionLot oProductionLot)
        {
            InnerList.Add(oProductionLot);
        }
        public int GetIndex(int nLotID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LotID == nLotID)
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
            string sSql = "SELECT * FROM t_ProductionLot";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLot oProductionLot = new ProductionLot();
                    oProductionLot.LotID = (int)reader["LotID"];
                    oProductionLot.LotType = (int)reader["LotType"];
                    oProductionLot.WorkType = (int)reader["WorkType"];
                    oProductionLot.LotNo = (string)reader["LotNo"];
                    oProductionLot.RefNo = (string)reader["RefNo"];
                    oProductionLot.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    oProductionLot.Remarks = (string)reader["Remarks"];
                    oProductionLot.CreateUserID = (int)reader["CreateUserID"];
                    oProductionLot.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oProductionLot.UpdateUserID = (int)reader["UpdateUserID"];
                    oProductionLot.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oProductionLot.Status = (int)reader["Status"];
                    InnerList.Add(oProductionLot);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshLot(DateTime dFromDate, DateTime dToDate, int nStatus,int nLotType,int nWorkType, string sLotNo, string sRefNo, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From dbo.t_ProductionLot where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND ReceiveDate between '" + dFromDate + "' and '" + dToDate + "' and ReceiveDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }

            if (nLotType != -1)
            {
                sSql = sSql + " AND LotType=" + nLotType + "";
            }

            if (nWorkType != -1)
            {
                sSql = sSql + " AND Status=" + nWorkType + "";
            }

            if (sLotNo != "")
            {
                sSql = sSql + " AND LotNo like '%" + sLotNo + "%'";
            }

            if (sRefNo != "")
            {
                sSql = sSql + " AND RefNo like '%" + sRefNo + "%'";
            }

            sSql = sSql + " Order by LotID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLot oProductionLot = new ProductionLot();
                    oProductionLot.LotID = (int)reader["LotID"];
                    oProductionLot.LotType = (int)reader["LotType"];
                    oProductionLot.WorkType = (int)reader["WorkType"];
                    oProductionLot.LotNo = (string)reader["LotNo"];
                    oProductionLot.RefNo = (string)reader["RefNo"];
                    oProductionLot.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        oProductionLot.Remarks = (string)reader["Remarks"];
                    else oProductionLot.Remarks = "";

                    oProductionLot.CreateUserID = (int)reader["CreateUserID"];
                    oProductionLot.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oProductionLot.Status = (int)reader["Status"];
                    if (reader["RefLotID"] != DBNull.Value)
                        oProductionLot.RefLotID = (int)reader["RefLotID"];
                    else oProductionLot.RefLotID = 0;
                    InnerList.Add(oProductionLot);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshLotForPlan(DateTime dFromDate, DateTime dToDate, int nLotType, int nWorkType, string sLotNo, string sRefNo,string sCode,string sPName, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From " +
                       " (Select a.*,Isnull(PlanQty,0) as PlanQty,isnull (ActualQty,0) as ActualQty,    " +
                       " Isnull(QCPassQty,0) as QCPassQty,isnull (QCFailQty,0) as QCFailQty From     " +
                       " (Select * From (Select a.LotID,LotType,WorkType,LotNo,RefNo,ReceiveDate,Remarks,CreateUserID,CreateDate,   " +
                       " b.ProductID,ProductCode,ProductName,ReceiveQty,Status    " +
                       " From t_ProductionLot a,t_ProductionLotItem b,v_productDetails c    " +
                       " where a.LotID=b.LotID and b.ProductID=c.ProductID) x) a    " +
                       " Left Outer Join     " +
                       " (Select LotID,ProductID,sum (PlanQty) PlanQty,sum (ActualQty) ActualQty, " +
                       " sum(QCPassQty) QCPassQty,sum(QCFailQty) QCFailQty From  " +
                       " (Select LotID,a.LotPlanID,a.ProductID,PlanQty,isnull(ActualQty,0) ActualQty,      " +
                       " isnull(QCPassQty,0) QCPassQty ,isnull(QCFailQty,0) QCFailQty From  " +
                       " (Select LotID,LotPlanID,ProductID,isnull(sum(PlanQty),0) PlanQty " +
                       " From dbo.t_ProductionLotItemPlan group by LotID,LotPlanID,ProductID) a " +
                       " Left Outer Join " +
                       " (Select LotPlanID,ProductID,isnull(sum(ActualQty),0) ActualQty,      " +
                       " isnull(sum (QCPassQty),0) QCPassQty ,isnull(sum(QCFailQty),0) QCFailQty     " +
                       " From dbo.t_ProductionLotItemActual group by LotPlanID,ProductID) b " +
                       " on a.LotPlanID=b.LotPlanID) xxx " +
                       " group by LotID,ProductID) b   " +
                       " on a.LotID=b.LotID and a.ProductID=b.ProductID) x where 1=1 ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND ReceiveDate between '" + dFromDate + "' and '" + dToDate + "' and ReceiveDate<'" + dToDate + "' ";
            }

            //if (nStatus != -1)
            //{
            //    sSql = sSql + " AND Status=" + nStatus + "";
            //}

            if (nLotType != -1)
            {
                sSql = sSql + " AND LotType=" + nLotType + "";
            }

            if (nWorkType != -1)
            {
                sSql = sSql + " AND WorkType=" + nWorkType + "";
            }

            if (sLotNo != "")
            {
                sSql = sSql + " AND LotNo like '%" + sLotNo + "%'";
            }

            if (sRefNo != "")
            {
                sSql = sSql + " AND RefNo like '%" + sRefNo + "%'";
            }

            if (sCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sCode + "%'";
            }

            if (sPName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sPName + "%'";
            }

            sSql = sSql + " Order by LotID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLot oProductionLot = new ProductionLot();
                    oProductionLot.LotID = (int)reader["LotID"];
                    oProductionLot.ProductID = (int)reader["ProductID"];
                    oProductionLot.LotType = (int)reader["LotType"];
                    oProductionLot.WorkType = (int)reader["WorkType"];
                    oProductionLot.LotNo = (string)reader["LotNo"];
                    oProductionLot.RefNo = (string)reader["RefNo"];
                    oProductionLot.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        oProductionLot.Remarks = (string)reader["Remarks"];
                    else oProductionLot.Remarks = "";

                    oProductionLot.CreateUserID = (int)reader["CreateUserID"];
                    oProductionLot.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oProductionLot.ProductCode = (string)reader["ProductCode"];
                    oProductionLot.ProductName = (string)reader["ProductName"];
                    oProductionLot.ReceiveQty = (int)reader["ReceiveQty"];
                    if (reader["PlanQty"] != DBNull.Value)
                        oProductionLot.PlanQty = (int)reader["PlanQty"];
                    else oProductionLot.PlanQty = 0;
                    if (reader["ActualQty"] != DBNull.Value)
                        oProductionLot.ActualQty = (int)reader["ActualQty"];
                    else oProductionLot.ActualQty = 0;
                    if (reader["QCPassQty"] != DBNull.Value)
                        oProductionLot.QCPassQty = (int)reader["QCPassQty"];
                    else oProductionLot.QCPassQty = 0;
                    if (reader["QCFailQty"] != DBNull.Value)
                        oProductionLot.QCFailQty = (int)reader["QCFailQty"];
                    else oProductionLot.QCFailQty = 0;
                    oProductionLot.Status = (int)reader["Status"];
                    InnerList.Add(oProductionLot);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetSummary(DateTime dFromDate, DateTime dToDate, int nAGID, int nASGID, int nMAGID, int nBrandID, string sProductCode, string sProductName)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "  Select * From  "+
                       " (Select a.ProductID,ProductCode,ProductName,AGID,AGName,ASGID,ASGName,MAGID,MAGName,PGID,PGName,BrandID,BrandDesc,isnull(ReceiveQty,0) ReceiveQty,isnull(PlanQty,0) PlanQty,  "+
                       " isnull(ActualQty,0) ActualQty,isnull(QCPassQty,0) QCPassQty,isnull(QCFailQty,0) QCFailQty,isnull(ChallanQty,0) ChallanQty From   "+
                       " (Select * From v_ProductDetails) a  "+
                       " left Outer Join   "+
                       " (Select ProductID,sum (ReceiveQty) ReceiveQty From dbo.t_ProductionLot a,dbo.t_ProductionLotItem b  "+
                       " where a.LotID=b.LotID and ReceiveDate between '" + dFromDate + "' and '" + dToDate + "' and ReceiveDate<'" + dToDate + "' group by ProductID) b  " +
                       " on a.ProductID=b.ProductID  "+
                       " left Outer Join   "+
                       " (Select ProductID,sum(ActualQty) ActualQty,sum(QCPassQty) QCPassQty,sum(QCFailQty) QCFailQty  "+
                       " From dbo.t_ProductionLotItemActual where ActualDate between '" + dFromDate + "' and '" + dToDate + "' and ActualDate<'" + dToDate + "' group by ProductID) c  " +
                       " on a.ProductID=c.ProductID  "+
                       " left Outer Join  "+
                       " (Select ProductID,sum(PlanQty) PlanQty  "+
                       " From dbo.t_ProductionLotItemPlan where PlanDate between '" + dFromDate + "' and '" + dToDate + "' and PlanDate<'" + dToDate + "' group by ProductID) d  " +
                       " on a.ProductID=d.ProductID  "+
                       " Left Outer Join   "+
                       " (Select ProductID,Sum(ChallanQty) ChallanQty From dbo.t_ProductionLotDelivery a,dbo.t_ProductionLotDeliveryItem b  "+
                       " where a.ID=b.ID and ChallanDate between '" + dFromDate + "' and '" + dToDate + "' and ChallanDate<'" + dToDate + "' group by ProductID) e  " +
                       " on a.ProductID=e.ProductID) xx where (ReceiveQty+PlanQty+ActualQty+ QCPassQty+QCFailQty+ChallanQty)<>0 and 1=1";
            
            }
            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID =" + nAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }
            //if (nPGID != -1)
            //{
            //    sSql = sSql + " AND PGID=" + nPGID + "";
            //}
            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }

            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }

            try
            {

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLot oProductionLot = new ProductionLot();
                    oProductionLot.ProductID = (int)reader["ProductID"];
                    oProductionLot.ProductCode = (string)reader["ProductCode"];
                    oProductionLot.ProductName = (string)reader["ProductName"];
                    oProductionLot.AGID = (int)reader["AGID"];
                    oProductionLot.AGName = (string)reader["AGName"];
                    oProductionLot.ASGID = (int)reader["ASGID"];
                    oProductionLot.ASGName = (string)reader["ASGName"];
                    oProductionLot.MAGID = (int)reader["MAGID"];
                    oProductionLot.MAGName = (string)reader["MAGName"];
                    oProductionLot.PGID = (int)reader["PGID"];
                    oProductionLot.PGName = (string)reader["PGName"];
                    oProductionLot.BrandID = (int)reader["BrandID"];
                    oProductionLot.BrandDesc = (string)reader["BrandDesc"];
                    oProductionLot.ReceiveQty = (int)reader["ReceiveQty"];
                    oProductionLot.PlanQty = (int)reader["PlanQty"];
                    oProductionLot.ActualQty = (int)reader["ActualQty"];
                    oProductionLot.QCPassQty = (int)reader["QCPassQty"];
                    oProductionLot.QCFailQty = (int)reader["QCFailQty"];
                    oProductionLot.ChallanQty = (int)reader["ChallanQty"];


                    InnerList.Add(oProductionLot);

                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLotForRework()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql =" Select a.LotID,LotNo,RefNo From dbo.t_ProductionLot a,t_ProductionLotItemPlan b,t_ProductionLotItemActual c "+
                         " where a.LotID=b.LotID and b.LotPlanID=c.LotPlanID and b.ProductID=c.ProductID and QCFailQty<>0 and a.LotID not in  " +
                         " (Select RefLotID From t_ProductionLot where RefLotID is not null) group by a.LotID,LotNo,RefNo"; 

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLot oProductionLot = new ProductionLot();

                    oProductionLot.LotID = (int)reader["LotID"];
                    oProductionLot.LotNo = (string)reader["LotNo"];
                    oProductionLot.RefNo = (string)reader["RefNo"];
                    InnerList.Add(oProductionLot);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLotForReworkEdit(int nRefLotID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * From  " +
                        " (Select a.LotID,LotNo,RefNo From dbo.t_ProductionLot a,t_ProductionLotItemPlan b,t_ProductionLotItemActual c    " +
                        " where a.LotID=b.LotID and b.LotPlanID=c.LotPlanID and b.ProductID=c.ProductID   " +
                        " and QCFailQty<>0 and a.LotID not in   " +
                        " (Select RefLotID From t_ProductionLot where RefLotID is not null)   " +
                        " group by a.LotID,LotNo,RefNo  " +
                        " Union All  " +
                        " Select a.LotID,LotNo,RefNo From dbo.t_ProductionLot a,t_ProductionLotItemPlan b,t_ProductionLotItemActual c    " +
                        " where a.LotID=b.LotID and b.LotPlanID=c.LotPlanID and b.ProductID=c.ProductID   " +
                        " and QCFailQty<>0 and a.LotID = " + nRefLotID + "  " +
                        " group by a.LotID,LotNo,RefNo) A where 1=1";
                            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLot oProductionLot = new ProductionLot();

                    oProductionLot.LotID = (int)reader["LotID"];
                    oProductionLot.LotNo = (string)reader["LotNo"];
                    oProductionLot.RefNo = (string)reader["RefNo"];
                    InnerList.Add(oProductionLot);
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
