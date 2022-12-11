// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jan 19, 2016
// Time : 12:34 PM
// Description: Class for ProductionLotDeliveryItem.
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
    public class ProductionLotDeliveryItem
    {
        private int _nID;
        private int _nProductID;
        private int _nType;
        private int _nChallanQty;
        private double _UnitPrice;
        private string _sProductCode;
        private string _sProductName;
        private int _nQCPassQty;


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
        // Get set property for QCPassQty
        // </summary>
        public int QCPassQty
        {
            get { return _nQCPassQty; }
            set { _nQCPassQty = value; }
        }

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
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
        // Get set property for UnitPrice
        // </summary>

        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ProductionLotDeliveryItem (ID, ProductID, Type, ChallanQty, UnitPrice) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("ChallanQty", _nChallanQty);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);

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
                sSql = "UPDATE t_ProductionLotDeliveryItem SET ProductID = ?, Type = ?, ChallanQty = ?, UnitPrice = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("ChallanQty", _nChallanQty);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_ProductionLotDeliveryItem WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_ProductionLotDeliveryItem where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProductID = (int)reader["ProductID"];
                    _nType = (int)reader["Type"];
                    _nChallanQty = (int)reader["ChallanQty"];
                    _UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
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
    public class ProductionLotDelivery : CollectionBase
    {
        public ProductionLotDeliveryItem this[int i]
        {
            get { return (ProductionLotDeliveryItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductionLotDeliveryItem oProductionLotDeliveryItem)
        {
            InnerList.Add(oProductionLotDeliveryItem);
        }
        private int _nID;
        private string _sChallanNo;
        private DateTime _dChallanDate;
        private int _nChallanType;
        private int _nCustomerID;
        private double _ChallanAmount;
        private double _Discount;
        private string _sRemarks;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private int _nStatus;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nChallanQty;

        // <summary>
        // Get set property for ChallanQty
        // </summary>
        public int ChallanQty
        {
            get { return _nChallanQty; }
            set { _nChallanQty = value; }
        }

        // <summary>
        // Get set property for CustomerCode
        // </summary>
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        // <summary>
        // Get set property for CustomerName
        // </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        // <summary>
        // Get set property for ChallanNo
        // </summary>
        public string ChallanNo
        {
            get { return _sChallanNo; }
            set { _sChallanNo = value.Trim(); }
        }
        // <summary>
        // Get set property for ChallanDate
        // </summary>
        public DateTime ChallanDate
        {
            get { return _dChallanDate; }
            set { _dChallanDate = value; }
        }
        // <summary>
        // Get set property for ChallanType
        // </summary>
        public int ChallanType
        {
            get { return _nChallanType; }
            set { _nChallanType = value; }
        }
        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        // <summary>
        // Get set property for ChallanAmount
        // </summary>
        public double ChallanAmount
        {
            get { return _ChallanAmount; }
            set { _ChallanAmount = value; }
        }

        // <summary>
        // Get set property for Discount
        // </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
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
            int nMaxID = 0;
            int nChallanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_ProductionLotDelivery";
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

                string sChallanNo = "";
                DateTime dToday = DateTime.Today;
                sChallanNo = "Challan" + "-" + dToday.ToString("yy") + _nID.ToString("000");
                _sChallanNo = sChallanNo;

                sSql = "INSERT INTO t_ProductionLotDelivery (ID, ChallanNo, ChallanDate, ChallanType, CustomerID, ChallanAmount, Discount, Remarks, CreateDate, CreateUserID, Status, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ChallanNo", _sChallanNo);
                cmd.Parameters.AddWithValue("ChallanDate", _dChallanDate);
                cmd.Parameters.AddWithValue("ChallanType", _nChallanType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ChallanAmount", _ChallanAmount);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (ProductionLotDeliveryItem oItem in this)
                {
                    oItem.ID = _nID;
                    oItem.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ProductionLotDelivery SET ChallanDate = ?,ChallanAmount = ?, Discount = ?, Remarks = ?,  UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChallanDate", _dChallanDate);
                cmd.Parameters.AddWithValue("ChallanAmount", _ChallanAmount);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("ID", nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                ProductionLotDeliveryItem oItems = new ProductionLotDeliveryItem();
                oItems.ID = nID;
                oItems.Delete();

                foreach (ProductionLotDeliveryItem oItem in this)
                {
                    oItem.ID = nID;
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
                sSql = "DELETE FROM t_ProductionLotDelivery WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_ProductionLotDelivery where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sChallanNo = (string)reader["ChallanNo"];
                    _dChallanDate = Convert.ToDateTime(reader["ChallanDate"].ToString());
                    _nChallanType = (int)reader["ChallanType"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _ChallanAmount = Convert.ToDouble(reader["ChallanAmount"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nStatus = (int)reader["Status"];
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

        public void GetChallanItem(int nID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "  Select * From (Select ID,x.ProductID,ProductCode,ProductName,CostPrice,(QCPassQty+ChallanQty) QCPassQty,ChallanQty From  "+
                                  "  (Select a.ID,b.ProductID,ProductCode,ProductName,CostPrice,ChallanQty     "+
                                  "  from t_ProductionLotDelivery a, t_ProductionLotDeliveryItem b,v_ProductDetails c      "+
                                  "  where a.ID=b.ID and b.ProductID=c.ProductID) x   "+
                                  "  Left outer Join    "+
                                  "  (Select * From (Select ProductID,(QCPassQty-ChallanQty) as QCPassQty From   "+
                                  "  (Select x.*,isnull(ChallanQty,0) ChallanQty From      "+
                                  "  (Select * From (Select a.ProductID,sum(QCPassQty) QCPassQty    "+
                                  "  From t_ProductionLotItemActual a,t_ProductionLotItemPlan b   "+
                                  "  where a.LotPlanID=b.LotPlanID and a.ProductID=b.ProductID   "+
                                  "  group by a.ProductID) a)  x      "+
                                  "  Left Outer Join      "+
                                  "  (Select ProductID,sum (ChallanQty) ChallanQty      "+
                                  "  From t_ProductionLotDeliveryItem group by ProductID) y      "+
                                  " on x.ProductID=y.ProductID) xx) yy where QCPassQty>0) y    " +
                                  "  on x.ProductID=y.ProductID) x where ID = ? ";

                cmd.Parameters.AddWithValue("ID", nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLotDeliveryItem oItem = new ProductionLotDeliveryItem();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oItem.QCPassQty = int.Parse(reader["QCPassQty"].ToString());
                    oItem.ChallanQty = int.Parse(reader["ChallanQty"].ToString());

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
    public class ProductionLotDeliverys : CollectionBase
    {
        public ProductionLotDelivery this[int i]
        {
            get { return (ProductionLotDelivery)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductionLotDelivery oProductionLotDelivery)
        {
            InnerList.Add(oProductionLotDelivery);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, int nStatus, string sChallanNo, string sCustomerName, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select * From (Select a.*,isnull(ChallanQty,0) ChallanQty From  "+
                       " (SELECT ID,ChallanNo,ChallanDate,ChallanType,a.CustomerID,CustomerCode,CustomerName,ChallanAmount,  "+
                       " Discount,Status FROM t_ProductionLotDelivery a,v_CustomerDetails b where a.CustomerID=b.CustomerID) a  "+
                       " Left Outer Join   "+
                       " (Select ID,sum(ChallanQty) ChallanQty From t_ProductionLotDeliveryItem group by ID) b  " +
                       " on a.ID=b.ID) xx where 1=1";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND ChallanDate between '" + dFromDate + "' and '" + dToDate + "' and ChallanDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sChallanNo != "")
            {
                sSql = sSql + " AND ChallanNo like '%" + sChallanNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }

            sSql = sSql + " Order by ID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLotDelivery oProductionLotDelivery = new ProductionLotDelivery();
                    oProductionLotDelivery.ID = (int)reader["ID"];
                    oProductionLotDelivery.ChallanNo = (string)reader["ChallanNo"];
                    oProductionLotDelivery.ChallanDate = Convert.ToDateTime(reader["ChallanDate"].ToString());
                    oProductionLotDelivery.ChallanType = (int)reader["ChallanType"];
                    oProductionLotDelivery.CustomerID = (int)reader["CustomerID"];
                    oProductionLotDelivery.CustomerCode = (string)reader["CustomerCode"];
                    oProductionLotDelivery.CustomerName = (string)reader["CustomerName"];
                    oProductionLotDelivery.ChallanAmount = Convert.ToDouble(reader["ChallanAmount"].ToString());
                    oProductionLotDelivery.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oProductionLotDelivery.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oProductionLotDelivery.Status = (int)reader["Status"];
                    oProductionLotDelivery.ChallanQty = (int)reader["ChallanQty"];
                    InnerList.Add(oProductionLotDelivery);
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
