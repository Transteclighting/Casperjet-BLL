using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class DMSProductStockSerial
    {
        private int _TranID;
        private int _ProductID;
        private string _ProductSerial;
        //private int _Status;
        //private string _OriginalSerial;

        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string ProductSerial
        {
            get { return _ProductSerial; }
            set { _ProductSerial = value; }
        }
        //public int Status
        //{
        //    get { return _Status; }
        //    set { _Status = value; }
        //}
        //public string OriginalSerial
        //{
        //    get { return _OriginalSerial; }
        //    set { _OriginalSerial = value; }
        //}
       
        public void Add(int _TranID, int _ProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                //sSql = "SELECT MAX(TranID) FROM t_DMSProductStockSerial where ProductID=" + _ProductID + " and ProductSerial='"+ _ProductSerial+"'";
                //cmd.CommandText = sSql;
                //object nTranID = cmd.ExecuteScalar();

                //if (nTranID == DBNull.Value)
                //{
                    sSql = "INSERT INTO t_DMSProductStockSerial (TranID,	ProductID,	ProductSerial,	Status,	OriginalSerial) VALUES(?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("TranID", _TranID);
                    cmd.Parameters.AddWithValue("ProductID", _ProductID);
                    cmd.Parameters.AddWithValue("ProductSerial", _ProductSerial);
                    cmd.Parameters.AddWithValue("Status", 1);
                    cmd.Parameters.AddWithValue("OriginalSerial", null);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                //}
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

     

    }

    public class DMSProductStockTranItem:CollectionBase
    {
        public DMSProductStockSerial this[int i]
        {
            get { return (DMSProductStockSerial)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSProductStockSerial oDMSProductStockSerial)
        {
            InnerList.Add(oDMSProductStockSerial);
        }

        private int _TranID;
        private int _ProductID;
        private int _Qty;
        private double _CostPrice;
        private double _SalesPrice;

        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }
        public double SalesPrice
        {
            get { return _SalesPrice; }
            set { _SalesPrice = value; }
        }
        
        public void Add(int _TranID, int _DistributorID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
               
                sSql = "INSERT INTO t_DMSProductStockTranItem (TranID,	ProductID,	Qty,	CostPrice,	SalesPrice) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("SalesPrice", _SalesPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DMSProductStockSerial oDMSProductStockSerial in this)
                {
                    oDMSProductStockSerial.Add(_TranID,_ProductID);
                }

                UpdateDMSProductStock( _ProductID,  _DistributorID, _Qty);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void UpdateDMSProductStock(int _ProductID, int _DistributorID, int _Qty)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = String.Format(@"
                                            if(exists(select * from t_DMSProductStock Where ProductID={0} and DistributorID={1}))
                                            begin
                                            Update  t_DMSProductStock set CurrentStock=CurrentStock +{2} Where ProductID={0} and DistributorID={1}
                                            end
                                            else
                                            begin
                                            insert into  t_DMSProductStock (ProductID,DistributorID, CurrentStock) values ({0},{1},{2})
                                            end
                                            ", _ProductID, _DistributorID, _Qty);
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("ProductID", _ProductID);
                //cmd.Parameters.AddWithValue("DistributorID", _DistributorID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }

    public class DMSProductStockTran : CollectionBase
    {

        public DMSProductStockTranItem this[int i]
        {
            get { return (DMSProductStockTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSProductStockTranItem oDMSProductStockTranItem)
        {
            InnerList.Add(oDMSProductStockTranItem);
        }



        private int _TranID;
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        private string _TranNo;
        private DateTime _TranDate;
        private int _ToCustomerID;
        private string _Remarks;

        // <summary>
        // Get set property for BarcodeSL
        // </summary>
        public string TranNo
        {
            get { return _TranNo; }
            set { _TranNo = value.Trim(); }
        }

        public int ToCustomerID
        {
            get { return _ToCustomerID; }
            set { _ToCustomerID = value; }
        }
        
        public DateTime TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }


        public void Insert()
        {
            int nMaxPlanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSProductStockTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPlanID = 1;
                }
                else
                {
                    nMaxPlanID = Convert.ToInt32(maxID) + 1;
                }
                _TranID = nMaxPlanID;
                //_TranNo = "Init-" + nMaxPlanID;
                sSql = "INSERT INTO t_DMSProductStockTran (TranID,	TranNo,	TranDate,	TranType,	TranSide,	FromCustomerID,	ToCustomerID,	Remarks,	CreateDate,	RefInvoiceId,	InvoiceAmount,	DiscountAmount) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranType", 1);
                cmd.Parameters.AddWithValue("TranSide", 1);
                cmd.Parameters.AddWithValue("FromCustomerID", 1);
                cmd.Parameters.AddWithValue("ToCustomerID", _ToCustomerID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("RefInvoiceId", null);
                cmd.Parameters.AddWithValue("InvoiceAmount", null);
                cmd.Parameters.AddWithValue("DiscountAmount", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DMSProductStockTranItem oDMSProductStockTranItem in this)
                {
                    oDMSProductStockTranItem.Add(_TranID, _ToCustomerID);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void Edit()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "UPDATE t_DMSProductStockTran SET EmployeeId = ?, LocationId = ?, Status = ?,UpdateUserId = ?, UpdateDate = ? WHERE PlanId = ?";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;


        //        cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
        //        cmd.Parameters.AddWithValue("LocationId", _nLocationId);
        //        cmd.Parameters.AddWithValue("Status", _nStatus);
        //        cmd.Parameters.AddWithValue("UpdateUserId", _nUpdateUserId);
        //        cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

        //        cmd.Parameters.AddWithValue("PlanId", _nPlanId);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();

        //        DMSProductStockTranItem oDPD = new DMSProductStockTranItem();
        //        oDPD.Delete(_nPlanId);


        //        foreach (DMSProductStockTranItem oDMSProductStockTranItem in this)
        //        {
        //            oDMSProductStockTranItem.Add(_nPlanId);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        
    
    }
    //public class DMSProductStockTrans : CollectionBase
    //{
    //    public DMSProductStockTran this[int i]
    //    {
    //        get { return (DMSProductStockTran)InnerList[i]; }
    //        set { InnerList[i] = value; }
    //    }
    //    public void Add(DMSProductStockTran oDMSProductStockTran)
    //    {
    //        InnerList.Add(oDMSProductStockTran);
    //    }
    //    public int GetIndex(int nPlanId)
    //    {
    //        int i;
    //        for (i = 0; i < this.Count; i++)
    //        {
    //            if (this[i].PlanId == nPlanId)
    //            {
    //                return i;
    //            }
    //        }
    //        return -1;
    //    }
    //    public void Refresh(string sDMSProductStockTranNo, int nEmployeeId, DateTime? dFromDate, DateTime? dToDate)
    //    {
    //        InnerList.Clear();
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "select distinct P.PlanId,PlanNo,P.EmployeeId,P.LocationId,P.Status,CreateUserId,CreateDate,EmployeeName,LocationName from t_DMSProductStockTran P left join t_DMSProductStockTranItem Q on P.PlanId=Q.PlanId left join t_Employee R on P.EmployeeId=R.EmployeeID WHERE 1=1";
    //        if(sDMSProductStockTranNo!="")
    //        {
    //            sSql = sSql + " and PlanNo='"+ sDMSProductStockTranNo + "' ";
    //        }
    //        if (nEmployeeId>0)
    //        {
    //            sSql = sSql + " and P.EmployeeId=" + nEmployeeId + " ";
    //        }
    //        if(dFromDate!=null&& dToDate!=null)
    //        {
    //            sSql = sSql + " and Q.PlanDate between '"+ dFromDate+"' and '"+dToDate+"'";
    //        }
    //        try
    //        {
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                DMSProductStockTran oDMSProductStockTran = new DMSProductStockTran();
    //                oDMSProductStockTran.PlanId = (int)reader["PlanId"];
    //                oDMSProductStockTran.PlanNo = (string)reader["PlanNo"];
    //                oDMSProductStockTran.EmployeeId = (int)reader["EmployeeId"];
    //                oDMSProductStockTran.LocationId = (int)reader["LocationId"];
    //                oDMSProductStockTran.Status = (int)reader["Status"];
    //                oDMSProductStockTran.CreateUserId = (int)reader["CreateUserId"];
    //                oDMSProductStockTran.CreateDate = (DateTime)reader["CreateDate"];
    //                oDMSProductStockTran.EmployeeName = (string)reader["EmployeeName"];
    //                oDMSProductStockTran.LocationName = (string)reader["LocationName"];

    //                InnerList.Add(oDMSProductStockTran);
    //            }
    //            reader.Close();
    //            InnerList.TrimToSize();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void GetVisitPlanType()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "SELECT * FROM t_VisitPlanType";
    //        try
    //        {
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                DMSProductStockTran oDMSProductStockTran = new DMSProductStockTran();
    //                oDMSProductStockTran.VisitPlanId = (int)reader["PlanId"];
    //                oDMSProductStockTran.PlanDescription = (string)reader["PlanDescription"];

    //                InnerList.Add(oDMSProductStockTran);
    //            }
    //            reader.Close();
    //            InnerList.TrimToSize();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void GetDMSProductStockTranPurpose()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "SELECT * FROM t_DMSProductStockTranPurpose where IsActive=1";
    //        try
    //        {
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                DMSProductStockTran oDMSProductStockTran = new DMSProductStockTran();
    //                oDMSProductStockTran.VisitPlanId = (int)reader["PurposeID"];
    //                oDMSProductStockTran.PlanDescription = (string)reader["Description"]; 

    //                InnerList.Add(oDMSProductStockTran);
    //            }
    //            reader.Close();
    //            InnerList.TrimToSize();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
        
    //}
}
