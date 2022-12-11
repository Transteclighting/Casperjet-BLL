// <summary>
// Company: Transcom Electronics Limited
// Author: Akif Ahmed
// Date: Jun 23, 2019
// Time : 02:09 PM
// Description: Class for AutoIndent.
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
    public class AutoIndent
    {
        private int _nAutoIndentID;
        private DateTime _dOrderDate;
        private int _nCustomerID;
        private string _sDeliveryAddress;
        private int _nSalesPersonID;
        private DateTime _dConfirmDate;
        private int _nOrderStatus;
        private string _sRemarks;
        private int _nCreateUserID;
        private int _nWarehouseID;
        private int _nConfirmUserID;
        private double _Discount;
        private double _DDAmount;
        private DateTime _dDDDate;
        private string _sDDDetails;
        private int _nOrderTypeID;
        private int _nSalesPromotionID;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nStatus;


        private int _nOrderID;
        private int _nOrderNo;
        private string _sRegionShortName;
        private string _sAreaShortName;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nCustomerTypeID;
        private int _nProductID;
        private int _nMOQ;
        private double _NSP;
        private double _FinalReqQty;
        private double _Comm;
        private double _TP;
        private double _Rep;

        public string RegionShortName
        {
            get { return _sRegionShortName; }
            set { _sRegionShortName = value.Trim(); }
        }
        public string AreaShortName
        {
            get { return _sAreaShortName; }
            set { _sAreaShortName = value.Trim(); }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }


        public int CustomerTypeID
        {
            get { return _nCustomerTypeID; }
            set { _nCustomerTypeID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int OrderNo
        {
            get { return _nOrderNo; }
            set { _nOrderNo = value; }
        }
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        public int MOQ
        {
            get { return _nMOQ; }
            set { _nMOQ = value; }
        }


        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }
        public double FinalReqQty
        {
            get { return _FinalReqQty; }
            set { _FinalReqQty = value; }
        }
        public double Comm
        {
            get { return _Comm; }
            set { _Comm = value; }
        }
        public double TP
        {
            get { return _TP; }
            set { _TP = value; }
        }
        public double Rep
        {
            get { return _Rep; }
            set { _Rep = value; }
        }

        // <summary>
        // Get set property for AutoIndentID
        // </summary>
        public int AutoIndentID
        {
            get { return _nAutoIndentID; }
            set { _nAutoIndentID = value; }
        }

        // <summary>
        // Get set property for OrderDate
        // </summary>
        public DateTime OrderDate
        {
            get { return _dOrderDate; }
            set { _dOrderDate = value; }
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
        // Get set property for DeliveryAddress
        // </summary>
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for SalesPersonID
        // </summary>
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
        }

        // <summary>
        // Get set property for ConfirmDate
        // </summary>
        public DateTime ConfirmDate
        {
            get { return _dConfirmDate; }
            set { _dConfirmDate = value; }
        }

        // <summary>
        // Get set property for OrderStatus
        // </summary>
        public int OrderStatus
        {
            get { return _nOrderStatus; }
            set { _nOrderStatus = value; }
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
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for ConfirmUserID
        // </summary>
        public int ConfirmUserID
        {
            get { return _nConfirmUserID; }
            set { _nConfirmUserID = value; }
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
        // Get set property for DDAmount
        // </summary>
        public double DDAmount
        {
            get { return _DDAmount; }
            set { _DDAmount = value; }
        }

        // <summary>
        // Get set property for DDDate
        // </summary>
        public DateTime DDDate
        {
            get { return _dDDDate; }
            set { _dDDDate = value; }
        }

        // <summary>
        // Get set property for DDDetails
        // </summary>
        public string DDDetails
        {
            get { return _sDDDetails; }
            set { _sDDDetails = value.Trim(); }
        }

        // <summary>
        // Get set property for OrderTypeID
        // </summary>
        public int OrderTypeID
        {
            get { return _nOrderTypeID; }
            set { _nOrderTypeID = value; }
        }

        // <summary>
        // Get set property for SalesPromotionID
        // </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
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
            int nMaxAutoIndentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([AutoIndentID]) FROM t_AutoIndent";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxAutoIndentID = 1;
                }
                else
                {
                    nMaxAutoIndentID = Convert.ToInt32(maxID) + 1;
                }
                _nAutoIndentID = nMaxAutoIndentID;
                sSql = @"INSERT INTO t_AutoIndent (AutoIndentID, OrderDate, CustomerID, DeliveryAddress, SalesPersonID, ConfirmDate, OrderStatus, Remarks, CreateUserID, WarehouseID, ConfirmUserID, Discount, DDAmount, DDDate, DDDetails, OrderTypeID, SalesPromotionID, UpdateUserID, UpdateDate,status) VALUES
                    ("+_nAutoIndentID+",'"+ _dOrderDate + "',"+ _nCustomerID + ",'"+ _sDeliveryAddress + "',"+ _nSalesPersonID + ",'"+ _dConfirmDate + "',5,null,"+_nCreateUserID+","+ _nWarehouseID + 
                    @","+ _nConfirmUserID + ",0,null,null,null,0,0,null,null,0)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);
                //cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                //cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                //cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                //cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                //cmd.Parameters.AddWithValue("ConfirmDate", _dConfirmDate);
                //cmd.Parameters.AddWithValue("OrderStatus", 5);
                //cmd.Parameters.AddWithValue("Remarks", null);
                //cmd.Parameters.AddWithValue("CreateUserID", null);
                //cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                //cmd.Parameters.AddWithValue("ConfirmUserID", _nConfirmUserID);
                //cmd.Parameters.AddWithValue("Discount", _Discount);
                //cmd.Parameters.AddWithValue("DDAmount", null);
                //cmd.Parameters.AddWithValue("DDDate", null);
                //cmd.Parameters.AddWithValue("DDDetails", null);
                //cmd.Parameters.AddWithValue("OrderTypeID", _nOrderTypeID);
                //cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                //cmd.Parameters.AddWithValue("UpdateUserID", null);
                //cmd.Parameters.AddWithValue("UpdateDate", null);

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
                sSql = "UPDATE t_AutoIndent SET OrderDate = ?, CustomerID = ?, DeliveryAddress = ?, SalesPersonID = ?, ConfirmDate = ?, OrderStatus = ?, Remarks = ?, CreateUserID = ?, WarehouseID = ?, ConfirmUserID = ?, Discount = ?, DDAmount = ?, DDDate = ?, DDDetails = ?, OrderTypeID = ?, SalesPromotionID = ?, UpdateUserID = ?, UpdateDate = ? WHERE AutoIndentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("ConfirmDate", _dConfirmDate);
                cmd.Parameters.AddWithValue("OrderStatus", _nOrderStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ConfirmUserID", _nConfirmUserID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("DDAmount", _DDAmount);
                cmd.Parameters.AddWithValue("DDDate", _dDDDate);
                cmd.Parameters.AddWithValue("DDDetails", _sDDDetails);
                cmd.Parameters.AddWithValue("OrderTypeID", _nOrderTypeID);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusToSent()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_AutoIndent SET Status = ? WHERE AutoIndentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", 1);

                cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);

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
                sSql = "DELETE FROM t_AutoIndent WHERE [AutoIndentID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);
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
                cmd.CommandText = "SELECT * FROM t_AutoIndent where AutoIndentID =?";
                cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nAutoIndentID = (int)reader["AutoIndentID"];
                    _dOrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    _nCustomerID = (int)reader["CustomerID"];
                    _sDeliveryAddress = (string)reader["DeliveryAddress"];
                    _nSalesPersonID = (int)reader["SalesPersonID"];
                    _dConfirmDate = Convert.ToDateTime(reader["ConfirmDate"].ToString());
                    _nOrderStatus = (int)reader["OrderStatus"];
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nConfirmUserID = (int)reader["ConfirmUserID"];
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _DDAmount = Convert.ToDouble(reader["DDAmount"].ToString());
                    _dDDDate = Convert.ToDateTime(reader["DDDate"].ToString());
                    _sDDDetails = (string)reader["DDDetails"];
                    _nOrderTypeID = (int)reader["OrderTypeID"];
                    _nSalesPromotionID = (int)reader["SalesPromotionID"];
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
        public void addToSalesOrder()
        {
            int nMaxAutoIndentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_SalesOrder";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxAutoIndentID = 1;
                }
                else
                {
                    nMaxAutoIndentID = Convert.ToInt32(maxID) + 1;
                }
                _nOrderID = nMaxAutoIndentID;

                nMaxAutoIndentID = 0;
                sSql = "SELECT MAX([OrderNo]) FROM t_SalesOrder";
                cmd.CommandText = sSql;
                maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxAutoIndentID = 1;
                }
                else
                {
                    nMaxAutoIndentID = Convert.ToInt32(maxID) + 1;
                }
                _nOrderNo = nMaxAutoIndentID;

                sSql = @"INSERT INTO t_SalesOrder VALUES
                    (" + _nOrderID + ","+_nOrderNo+",'" + _dOrderDate + "'," + _nCustomerID + ",'" + _sDeliveryAddress + "'," + _nSalesPersonID + ",null,1,''," + _nCreateUserID + "," + _nWarehouseID +
                    @",null,0,0,null,'',1,null,null,null)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int getStatusByID(int id)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                string sSql = "SELECT status FROM t_AutoIndent where AutoIndentID ="+id;
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return Int32.Parse(reader["Status"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return 0;
        }
        public bool canInsert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                string sSql = "SELECT * FROM t_AutoIndent where CustomerID =" + _nCustomerID+ " and OrderDate between '"+DateTime.Now.ToString("dd-MMM-yyyy")+"' and '"+DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy") + "' and OrderDate<'"+ DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy") + "' ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if(nCount>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class AutoIndents : CollectionBase
    {
        public AutoIndent this[int i]
        {
            get { return (AutoIndent)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(AutoIndent oAutoIndent)
        {
            InnerList.Add(oAutoIndent);
        }
        public int GetIndex(int nAutoIndentID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AutoIndentID == nAutoIndentID)
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
            string sSql = "SELECT * FROM t_AutoIndent";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AutoIndent oAutoIndent = new AutoIndent();
                    oAutoIndent.AutoIndentID = (int)reader["AutoIndentID"];
                    oAutoIndent.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oAutoIndent.CustomerID = (int)reader["CustomerID"];
                    oAutoIndent.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oAutoIndent.SalesPersonID = (int)reader["SalesPersonID"];
                    oAutoIndent.ConfirmDate = Convert.ToDateTime(reader["ConfirmDate"].ToString());
                    oAutoIndent.OrderStatus = (int)reader["OrderStatus"];
                    oAutoIndent.Remarks = (string)reader["Remarks"];
                    oAutoIndent.CreateUserID = (int)reader["CreateUserID"];
                    oAutoIndent.WarehouseID = (int)reader["WarehouseID"];
                    oAutoIndent.ConfirmUserID = (int)reader["ConfirmUserID"];
                    oAutoIndent.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oAutoIndent.DDAmount = Convert.ToDouble(reader["DDAmount"].ToString());
                    oAutoIndent.DDDate = Convert.ToDateTime(reader["DDDate"].ToString());
                    oAutoIndent.DDDetails = (string)reader["DDDetails"];
                    oAutoIndent.OrderTypeID = (int)reader["OrderTypeID"];
                    oAutoIndent.SalesPromotionID = (int)reader["SalesPromotionID"];
                    oAutoIndent.UpdateUserID = (int)reader["UpdateUserID"];
                    oAutoIndent.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oAutoIndent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<AutoIndent> getProcessData()
        {
            List<AutoIndent> list = new List<AutoIndent>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"select RegionShortName,AreaShortName, CustomerID,CustomerCode,CustomerName,CustomerAddress,QMaster.CustomerTypeID,
                            ProductID,ProductName,ASGID,QMaster.BrandID,MOQ,NSP,FinalReqQty, Comm,TP,Rep  
                            from
                            (
                            select RegionShortName,AreaShortName, Main.CustomerID,CustomerCode,CustomerName,CustomerAddress,CustomerTypeID,
                            ProductID,ProductName,ASGID,BrandID,MOQ,NSP, (round(((isnull(FinalReq,0))/MOQ),0)* MOQ)as FinalReqQty  
                            from
                            (
                            ----------------Pri Sec Cur Stock ------
                            select CustomerID,SubMain.ProductID,ProductName,ASGID,BrandID,MOQ,NSP,ReqQty,CurrentStock,StandardStock, StkDev, 
                            FinalReq= case when StandardStock > CurrentStock then (ReqQty+(StandardStock-CurrentStock)) else 0 end 
                            from
                            (
                            select CustomerID,ProductID, (SecSlQty-PriSlQty)as ReqQty,CurrentStock,StandardStock, (StandardStock-CurrentStock) as StkDev
                            from
                            (
                            select CustomerID, ProductID, sum(PriSlQty)as PriSlQty, sum(SecSlQty)as SecSlQty, isnull(sum(CurrentStock),0)as CurrentStock, sum(BufferStock)as StandardStock   
                            from  
                            (  
                            select CustomerID,ProductID,0 PriSlQty,0 as SecSlQty,0 as CurrentStock,BufferStock  from t_BufferStock  
                            union all  

                            select Distributorid as CustomerID,ProductId, 0 as PriSlQty, 0 as SecSlQty, CurrentStock, 0 as BufferStock  from t_DMSProductStock   
                            union all   

                            select Distributorid as CustomerID, ProductID,0 as  PriSlQty, sum(Qty)as SecSlQty, 0 as CurrentStock, 0 as BufferStock   
                            from t_DMSProductTran a, t_DMSProductTranItem b   
                            where TranTypeID in (2) and a.TranID=b.TranID and Trandate between  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) and Trandate<  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)   
                            group by Distributorid, ProductID  

                            union all   

                            select CustomerID, ProductID, isnull (sum(QtySA)- sum(QtyRA),0) as PriSlQty, 0 as SecSlQty, 0 as CurrentStock,0 as BufferStock   
                            from  
                            (  
                            select CustomerID, ProductID, sum (Quantity) as QtySA, 0 as  QtyRA   
                            from t_salesinvoiceDetail b, t_salesinvoice c   
                            where b.InvoiceID = c.InvoiceID  and InvoicetypeID in (1,2,4,5) and invoiceStatus not in (3)   
                            and Invoicedate between  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) and Invoicedate< DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)   
                            group by CustomerID, ProductID   
                            union all   
                            select  CustomerID, ProductID,  0 as  QtySA,  sum(Quantity) as QtyRA   
                            from  t_salesinvoiceDetail b, t_salesinvoice c  
                            where b.InvoiceID = c.InvoiceID and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3)   
                            and Invoicedate between  DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) and Invoicedate< DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)   
                            group by  CustomerID, ProductID 
                            ) as b group by  CustomerID, ProductID   
                            )As Q1 group by CustomerID, ProductID  
                             )As PriSecStk 
                             )As SubMain
                            inner join ( select ProductID,ProductName,ASGID,BrandID,UomConversionFactor as MOQ,NSP from v_ProductDetails where NSP>0 )as Prod on SubMain.ProductID=Prod.ProductID
                            )As Main
                            ----------------Pri Sec Cur Stock END ------
                            inner join
                            (
                            select RegionShortName,AreaShortName, CustomerID,CustomerCode,CustomerName,CustomerAddress, CustomerTypeID 
                            from [BLLSysDB].[dbo].[v_CustomerDetails] a, t_DMSuser b
                            where a.CustomerID=b.DistributorID and b.Isactive=1
                            )As Cust on Main.CustomerID=Cust.CustomerID
                            )As QMaster
                            inner join 
                            (
                            select ProductGroupID,BrandID,CustomerTypeID,sum(Comm)as Comm, sum(TP)as TP, sum(Rep)as Rep
                            from
                            (
                            select ProductGroupID,BrandID,CustomerTypeID,ProvisionPercent as Comm, 0 as TP, 0 as Rep
                            from t_ProvisionParam 
                            where isactive=1 and ProvisionType=1
                            union all
                            select ProductGroupID,BrandID,CustomerTypeID,0 as Comm, ProvisionPercent as TP, 0 as Rep
                            from t_ProvisionParam 
                            where isactive=3 and ProvisionType=1
                            union all
                            select ProductGroupID,BrandID,CustomerTypeID,0 as Comm,0 as TP, ProvisionPercent as RP
                            from t_ProvisionParam 
                            where isactive=5 and ProvisionType=1
                            )As DBCom 
                            where CustomerTypeiD=229
                            group by ProductGroupID,BrandID,CustomerTypeID
                            )As DBcommi on QMaster.ASGID=DBcommi.ProductGroupID and QMaster.BrandID=DBcommi.BrandID and QMaster.CustomerTypeID=DBcommi.CustomerTypeID
                            where  FinalReqQty>0
                            order by RegionShortName,AreaShortName, CustomerID,CustomerCode,CustomerName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AutoIndent oAutoIndent = new AutoIndent();
                    oAutoIndent.RegionShortName = reader["RegionShortName"].ToString();
                    oAutoIndent.AreaShortName = reader["AreaShortName"].ToString();
                    oAutoIndent.CustomerID = (int)reader["CustomerID"];
                    oAutoIndent.CustomerCode = reader["CustomerCode"].ToString();
                    oAutoIndent.CustomerName = reader["CustomerName"].ToString();
                    oAutoIndent.DeliveryAddress = (string)reader["CustomerAddress"];
                    oAutoIndent.CustomerTypeID = (int)reader["CustomerTypeID"];
                    oAutoIndent.ProductID = (int)reader["ProductID"];
                    oAutoIndent.MOQ = Int32.Parse(reader["MOQ"].ToString());
                    oAutoIndent.NSP = Double.Parse(reader["NSP"].ToString());
                    oAutoIndent.FinalReqQty = Double.Parse(reader["FinalReqQty"].ToString());
                    oAutoIndent.Comm = Double.Parse(reader["Comm"].ToString());
                    oAutoIndent.TP = Double.Parse(reader["TP"].ToString());
                    oAutoIndent.Rep = Double.Parse(reader["Rep"].ToString());

                    InnerList.Add(oAutoIndent);
                    list.Add(oAutoIndent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
        public List<AutoIndent> viewDetail(string fromDate, string toDate,string CustomerCode, string CustomerName)
        {
            string str = "";
            if(!CustomerCode.Equals(""))
            {
                str += " and CustomerCode = " + CustomerCode.Trim();
            }
            if(!CustomerName.Equals(""))
            {
                str += " and CustomerName like '%" + CustomerName.Trim()+"%'";
            }
            List<AutoIndent> list = new List<AutoIndent>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"select  RegionShortName,AreaShortName, cust.CustomerID,CustomerCode,CustomerName,CustomerAddress, CustomerTypeID,AutoIndentID,
                            OrderDate, DeliveryAddress,SalesPersonID,ConfirmDate,OrderStatus,Remarks,CreateUserID,WarehouseID,ConfirmUserID,Discount,DDAmount,
                            DDDate,DDDetails,OrderTypeID,SalesPromotionID,UpdateUserID,UpdateDate,autoInd.Status
                            from
                            (
                            select * from t_AutoIndent
                            )as autoInd
                            left outer join
                            (
                            select RegionShortName,AreaShortName, CustomerID,CustomerCode,CustomerName,CustomerAddress, CustomerTypeID 
                            from [BLLSysDB].[dbo].[v_CustomerDetails] a, [BLLSysDB].[dbo].[t_DMSuser] b
                            where a.CustomerID=b.DistributorID and b.Isactive=1
                            ) as cust on autoInd.CustomerID = cust.CustomerID 
                            where OrderDate between '"+fromDate+"' and '"+toDate+"' and OrderDate<'"+toDate+"'" + str;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AutoIndent oAutoIndent = new AutoIndent();
                    if (!reader.IsDBNull(0))
                        oAutoIndent.RegionShortName = reader["RegionShortName"].ToString();
                    else
                        oAutoIndent.RegionShortName = "";
                    if (!reader.IsDBNull(1))
                        oAutoIndent.AreaShortName = reader["AreaShortName"].ToString();
                    else
                        oAutoIndent.AreaShortName = "";
                    if (!reader.IsDBNull(2))
                        oAutoIndent.CustomerID = (int)reader["CustomerID"];
                    else
                        oAutoIndent.CustomerID = 0;
                    if (!reader.IsDBNull(3))
                        oAutoIndent.CustomerCode = reader["CustomerCode"].ToString();
                    else
                        oAutoIndent.CustomerCode = "";
                    if (!reader.IsDBNull(4))
                        oAutoIndent.CustomerName = reader["CustomerName"].ToString();
                    else
                        oAutoIndent.CustomerName = "";
                    if (!reader.IsDBNull(5))
                        oAutoIndent.DeliveryAddress = (string)reader["CustomerAddress"];
                    else
                        oAutoIndent.DeliveryAddress = "";
                    if (!reader.IsDBNull(6))
                        oAutoIndent.CustomerTypeID = (int)reader["CustomerTypeID"];
                    else
                        oAutoIndent.CustomerTypeID = 0;
                    if (!reader.IsDBNull(7))
                        oAutoIndent.AutoIndentID = (int)reader["AutoIndentID"];
                    else
                        oAutoIndent.AutoIndentID = 0;
                    if (!reader.IsDBNull(8))
                        oAutoIndent.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                    else
                        oAutoIndent.OrderDate = default(DateTime);
                    //if (!reader.IsDBNull(9))
                    //    oAutoIndent.DeliveryAddress = (string)reader["CustomerAddress"];
                    //else
                    //    oAutoIndent.DeliveryAddress = "";
                    if (!reader.IsDBNull(10))
                        oAutoIndent.SalesPersonID = (int)reader["SalesPersonID"];
                    else
                        oAutoIndent.SalesPersonID = 0;
                    if (!reader.IsDBNull(11))
                        oAutoIndent.ConfirmDate = DateTime.Parse(reader["ConfirmDate"].ToString());
                    else
                        oAutoIndent.ConfirmDate = default(DateTime);
                    if (!reader.IsDBNull(12))
                        oAutoIndent.OrderStatus = (int)reader["OrderStatus"];
                    else
                        oAutoIndent.OrderStatus = 0;
                    if (!reader.IsDBNull(13))
                        oAutoIndent.Remarks = (string)reader["Remarks"];
                    else
                        oAutoIndent.Remarks = "";
                    if (!reader.IsDBNull(14))
                        oAutoIndent.CreateUserID = (int)reader["CreateUserID"];
                    else
                        oAutoIndent.CreateUserID = 0;
                    if (!reader.IsDBNull(15))
                        oAutoIndent.WarehouseID = (int)reader["WarehouseID"];
                    else
                        oAutoIndent.WarehouseID = 0;
                    if (!reader.IsDBNull(16))
                        oAutoIndent.ConfirmUserID = (int)reader["ConfirmUserID"];
                    else
                        oAutoIndent.ConfirmUserID = 0;
                    if (!reader.IsDBNull(17))
                        oAutoIndent.Discount = Double.Parse(reader["Discount"].ToString());
                    else
                        oAutoIndent.Discount = 0;
                    if (!reader.IsDBNull(18))
                        oAutoIndent.DDAmount = Double.Parse(reader["DDAmount"].ToString());
                    else
                        oAutoIndent.DDAmount = 0;
                    if (!reader.IsDBNull(19))
                        oAutoIndent.DDDate = DateTime.Parse(reader["DDDate"].ToString());
                    else
                        oAutoIndent.DDDate = default(DateTime);
                    if (!reader.IsDBNull(20))
                        oAutoIndent.DDDetails = (string)reader["DDDetails"];
                    else
                        oAutoIndent.DDDetails = "";
                    if (!reader.IsDBNull(21))
                        oAutoIndent.OrderTypeID = (int)reader["OrderTypeID"];
                    else
                        oAutoIndent.OrderTypeID = 0;
                    if (!reader.IsDBNull(22))
                        oAutoIndent.SalesPromotionID = (int)reader["SalesPromotionID"];
                    else
                        oAutoIndent.SalesPromotionID = 0;
                    if (!reader.IsDBNull(23))
                        oAutoIndent.UpdateUserID = (int)reader["UpdateUserID"];
                    else
                        oAutoIndent.UpdateUserID = 0;
                    if (!reader.IsDBNull(24))
                        oAutoIndent.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
                    else
                        oAutoIndent.UpdateDate = default(DateTime);
                    if (!reader.IsDBNull(25))
                        oAutoIndent.Status = (int)reader["Status"];
                    else
                        oAutoIndent.Status = 0;





                    InnerList.Add(oAutoIndent);
                    list.Add(oAutoIndent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
     
    }
}

