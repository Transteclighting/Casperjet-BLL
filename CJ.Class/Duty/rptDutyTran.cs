// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 25, 2012
// Time :  02:20 PM
// Description: Class for report Duty transaction.
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Class.Duty
{
  
    public class rptDutyTran 
    {       

        private int _DutyTranID;
        private DateTime _DutyTranDate;
        private string _DutyTranNo;
        private int _WHID;
        private int _ChallanTypeID;
        private string _DocumentNo;
        private int _RefID;
        private int _DutyTypeID;
        private int _DutyTranTypeID;
        private string _Remarks;
        private double _Amount;
        private int _DutyAccountID;

        private int _CustomerID;
        private string _CustomerCode;
        private string _CustomerName;
        private string _CustomerAddress;
        private long _SBUID;
        private int _ChannelID;
        private int _WarehouseID;
        private int _InvoiceStatus;
        private int _InvoiceTypeID;


        /// <summary>
        /// Get set property for DutyTranID
        /// </summary>
        public int DutyTranID
        {
            get { return _DutyTranID; }
            set { _DutyTranID = value; }
        }

        /// <summary>
        /// Get set property for DutyTranDate
        /// </summary>
        public DateTime DutyTranDate
        {
            get { return _DutyTranDate; }
            set { _DutyTranDate = value; }
        }

        /// <summary>
        /// Get set property for DutyTranNo
        /// </summary>
        public string DutyTranNo
        {
            get { return _DutyTranNo; }
            set { _DutyTranNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for WHID
        /// </summary>
        public int WHID
        {
            get { return _WHID; }
            set { _WHID = value; }
        }

        /// <summary>
        /// Get set property for ChallanTypeID
        /// </summary>
        public int ChallanTypeID
        {
            get { return _ChallanTypeID; }
            set { _ChallanTypeID = value; }
        }

        /// <summary>
        /// Get set property for DocumentNo
        /// </summary>
        public string DocumentNo
        {
            get { return _DocumentNo; }
            set { _DocumentNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for RefID
        /// </summary>
        public int RefID
        {
            get { return _RefID; }
            set { _RefID = value; }
        }

        /// <summary>
        /// Get set property for DutyTypeID
        /// </summary>
        public int DutyTypeID
        {
            get { return _DutyTypeID; }
            set { _DutyTypeID = value; }
        }

        /// <summary>
        /// Get set property for DutyTranTypeID
        /// </summary>
        public int DutyTranTypeID
        {
            get { return _DutyTranTypeID; }
            set { _DutyTranTypeID = value; }
        }

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public int DutyAccountID
        {
            get { return _DutyAccountID; }
            set { _DutyAccountID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }
        public string CustomerAddress
        {
            get { return _CustomerAddress; }
            set { _CustomerAddress = value; }
        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }
        public int ChannelID
        {
            get { return _ChannelID; }
            set { _ChannelID = value; }
        }
        public int WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }
        public int InvoiceStatus
        {
            get { return _InvoiceStatus; }
            set { _InvoiceStatus = value; }
        }
        public int InvoiceTypeID
        {
            get { return _InvoiceTypeID; }
            set { _InvoiceTypeID = value; }
        }  
               
    }
    public class rptDutyTranReport : CollectionBaseCustom
    {

        public void Add(rptDutyTran orptDutyTran)
        {
            this.List.Add(orptDutyTran);
        }
        public rptDutyTran this[Int32 Index]
        {
            get
            {
                return (rptDutyTran)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptDutyTran))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }      

        public void Refresh(int nControl, DateTime dtFromDate, DateTime dtTodate, string sFromVatChallanNo, string sToVatChallanNo)
        {
            InnerList.Clear();
            dtTodate = dtTodate.AddDays(1);
            string sSql = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (nControl == 1)
            {
                sSql = "SELECT a.* FROM t_DutyTran a ,t_DutyTranType b where a.DutyTranTypeID=b.DutyTranTypeID and a.DutyTranTypeID not in(1,2) and DutyTranDate between ? and ? and DutyTranDate < ? ";
                cmd.Parameters.AddWithValue("DutyTranDate", dtFromDate);
                cmd.Parameters.AddWithValue("DutyTranDate", dtTodate);
                cmd.Parameters.AddWithValue("DutyTranDate", dtTodate);
            }
            else
            {
                sSql = "SELECT a.* FROM t_DutyTran a ,t_DutyTranType b where a.DutyTranTypeID=b.DutyTranTypeID and b.TranSide=2 and DutyTranNo between ? and ?  ";
                cmd.Parameters.AddWithValue("DutyTranNo", sFromVatChallanNo);
                cmd.Parameters.AddWithValue("DutyTranNo", sToVatChallanNo);
            }
            //sSql = "select * from t_dutytran where dutytrantypeid=1 and dutytrandate<'26-Jul-2012'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptDutyTran orptDutyTran = new rptDutyTran();

                    orptDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    orptDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    orptDutyTran.DutyTranTypeID = (int)reader["DutyTranTypeID"];
                    orptDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    orptDutyTran.RefID = (int)reader["RefID"];
                    orptDutyTran.DocumentNo = reader["DocumentNo"].ToString();
                    orptDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    orptDutyTran.WHID = (int)reader["WHID"];
                    orptDutyTran.Remarks = reader["Remarks"].ToString();
                    orptDutyTran.Amount = (double)reader["Amount"];
                    orptDutyTran.DutyAccountID = (int)reader["DutyAccountID"];

                    orptDutyTran.CustomerID = 0;
                    orptDutyTran.CustomerCode = "";
                    orptDutyTran.CustomerName = "";
                    orptDutyTran.CustomerAddress = "";
                    orptDutyTran.SBUID = 0;
                    orptDutyTran.ChannelID = 0;
                    orptDutyTran.WarehouseID = 0;
                    orptDutyTran.InvoiceStatus = 0;
                    orptDutyTran.InvoiceTypeID = 0;

                    InnerList.Add(orptDutyTran);
                }
                reader.Close();

                RefreshInvoice(nControl, dtFromDate, dtTodate, sFromVatChallanNo, sToVatChallanNo);
                RefreshTransfer(nControl, dtFromDate, dtTodate, sFromVatChallanNo, sToVatChallanNo);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
        public void RefreshInvoice(int nControl, DateTime dtFromDate, DateTime dtTodate, string sFromVatChallanNo, string sToVatChallanNo)
        {          
            dtTodate = dtTodate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
              if (nControl == 1)
              {
                  sSql = " select "
                          + " qq1.*,qq2.CustomerCode,qq2.CustomerName,qq2.CustomerAddress,qq2.SBUID,qq3.ChannelID "
                          + " from  "
                          + " ( "
                          + " select q1.*,q2.InvoiceStatus,InvoiceTypeID,q2.CustomerID,q2.WarehouseID "
                          + " from t_DutyTran q1,t_SalesInvoice q2 "
                          + " where DutyTranDate  BETWEEN  ? AND ? and DutyTranDate < ? and DutyTranTypeID=1 "
                          + " and q1.RefID=q2.InvoiceID  "
                          + " )  as qq1 "
                          + " inner join  "
                          + " ( "
                          + " select CustomerID,CustomerCode,CustomerName,CustomerAddress,SBUID from v_CustomerDetails "
                          + " ) as qq2 "
                          + " on qq1.CustomerID=qq2.CustomerID "
                          + " inner join  "
                          + " ( "
                          + " select WarehouseID,a.ChannelID as ChannelID from t_Warehouse a, "
                          + " t_Channel b where a.ChannelID=b.ChannelID "
                          + " ) as qq3 "
                          + " on qq1.WarehouseID=qq3.WarehouseID ";


                  cmd.Parameters.AddWithValue("DutyTranDate", dtFromDate);
                  cmd.Parameters.AddWithValue("DutyTranDate", dtTodate);
                  cmd.Parameters.AddWithValue("DutyTranDate", dtTodate);
              }
              else
              {
                  sSql = " select "
                          + " qq1.*,qq2.CustomerCode,qq2.CustomerName,qq2.CustomerAddress,qq2.SBUID,qq3.ChannelID "
                          + " from  "
                          + " ( "
                          + " select q1.*,q2.InvoiceStatus,InvoiceTypeID,q2.CustomerID,q2.WarehouseID "
                          + " from t_DutyTran q1,t_SalesInvoice q2 "
                          + " where DutyTranNo  BETWEEN  ? AND ? and DutyTranTypeID=1"
                          + " and q1.RefID=q2.InvoiceID  "
                          + " )  as qq1 "
                          + " inner join  "
                          + " ( "
                          + " select CustomerID,CustomerCode,CustomerName,CustomerAddress,SBUID from v_CustomerDetails "
                          + " ) as qq2 "
                          + " on qq1.CustomerID=qq2.CustomerID "
                          + " inner join  "
                          + " ( "
                          + " select WarehouseID,a.ChannelID as ChannelID from t_Warehouse a, "
                          + " t_Channel b where a.ChannelID=b.ChannelID "
                          + " ) as qq3 "
                          + " on qq1.WarehouseID=qq3.WarehouseID ";

                  cmd.Parameters.AddWithValue("DutyTranNo", sFromVatChallanNo);
                  cmd.Parameters.AddWithValue("DutyTranNo", sToVatChallanNo);
              }
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptDutyTran orptDutyTran = new rptDutyTran();

                    orptDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    orptDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    orptDutyTran.DutyTranTypeID = (int)reader["DutyTranTypeID"];
                    orptDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    orptDutyTran.RefID = (int)reader["RefID"];
                    orptDutyTran.DocumentNo = reader["DocumentNo"].ToString();
                    orptDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    orptDutyTran.WHID = (int)reader["WHID"];
                    orptDutyTran.Remarks = reader["Remarks"].ToString();
                    orptDutyTran.Amount = (double)reader["Amount"];
                    orptDutyTran.DutyAccountID = (int)reader["DutyAccountID"];

                    orptDutyTran.CustomerID = (int)reader["CustomerID"];
                    orptDutyTran.CustomerCode = (string)reader["CustomerCode"];
                    orptDutyTran.CustomerName = (string)reader["CustomerName"];
                    orptDutyTran.CustomerAddress = (string)reader["CustomerAddress"];
                    orptDutyTran.SBUID = (long)reader["SBUID"];
                    orptDutyTran.ChannelID = (int)reader["ChannelID"];
                    orptDutyTran.WarehouseID = (int)reader["WarehouseID"];
                    orptDutyTran.InvoiceStatus = (int)reader["InvoiceStatus"];
                    orptDutyTran.InvoiceTypeID = (int)reader["InvoiceTypeID"];

                    InnerList.Add(orptDutyTran);
                }
                reader.Close();             
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshTransfer(int nControl, DateTime dtFromDate, DateTime dtTodate, string sFromVatChallanNo, string sToVatChallanNo)
        {
          
            dtTodate = dtTodate.AddDays(1);
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (nControl == 1)
            {
                sSql = " select  "
                             + " qq1.*,qq3.ChannelID "
                             + "  from  "
                             + "  ( "
                             + "  select q1.*,q2.FromWHID,q2.ToWHID "
                             + "  from t_DutyTran q1,t_ProductStockTran q2 "
                             + "  where DutyTranDate  BETWEEN  ? AND ? and DutyTranDate < ? and DutyTranTypeID=2"
                             + "  and q1.RefID=q2.TranID  "
                             + "  )  as qq1 "
                             + "  inner join  "
                             + "  ( "
                             + "  select WarehouseID,a.ChannelID as ChannelID from t_Warehouse a, "
                             + "  t_Channel b where a.ChannelID=b.ChannelID "
                             + "  ) as qq3 "
                             + "  on qq1.FromWHID=qq3.WarehouseID ";

                cmd.Parameters.AddWithValue("DutyTranDate", dtFromDate);
                cmd.Parameters.AddWithValue("DutyTranDate", dtTodate);
                cmd.Parameters.AddWithValue("DutyTranDate", dtTodate);
            }
            else
            {
                sSql = " select  "
                             + " qq1.*,qq3.ChannelID "
                             + "  from  "
                             + "  ( "
                             + "  select q1.*,q2.FromWHID,q2.ToWHID "
                             + "  from t_DutyTran q1,t_ProductStockTran q2 "
                             + "  where DutyTranNo  BETWEEN  ? AND ? and DutyTranTypeID=2"
                             + "  and q1.RefID=q2.TranID  "
                             + "  )  as qq1 "
                             + "  inner join  "
                             + "  ( "
                             + "  select WarehouseID,a.ChannelID as ChannelID from t_Warehouse a, "
                             + "  t_Channel b where a.ChannelID=b.ChannelID "
                             + "  ) as qq3 "
                             + "  on qq1.FromWHID=qq3.WarehouseID ";

                cmd.Parameters.AddWithValue("DutyTranNo", sFromVatChallanNo);
                cmd.Parameters.AddWithValue("DutyTranNo", sToVatChallanNo);
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptDutyTran orptDutyTran = new rptDutyTran();

                    orptDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    orptDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    orptDutyTran.DutyTranTypeID = (int)reader["DutyTranTypeID"];
                    orptDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    orptDutyTran.RefID = (int)reader["RefID"];
                    orptDutyTran.DocumentNo = reader["DocumentNo"].ToString();
                    orptDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    orptDutyTran.WHID = (int)reader["WHID"];
                    orptDutyTran.Remarks = reader["Remarks"].ToString();
                    orptDutyTran.Amount = (double)reader["Amount"];
                    orptDutyTran.DutyAccountID = (int)reader["DutyAccountID"];

                    CustomerDetail oCustomerDetail = new CustomerDetail();
                    if (oCustomerDetail.GetOutlet((int)reader["ToWHID"]))
                    {
                        orptDutyTran.CustomerID = oCustomerDetail.CustomerID;
                        orptDutyTran.CustomerCode = oCustomerDetail.CustomerCode;
                        orptDutyTran.CustomerName = oCustomerDetail.CustomerName;
                        orptDutyTran.CustomerAddress = oCustomerDetail.CustomerAddress;
                        orptDutyTran.SBUID = oCustomerDetail.SBUID;
                    }
                    else
                    {
                        orptDutyTran.CustomerID = 0;
                        orptDutyTran.CustomerCode = "";
                        orptDutyTran.CustomerName = "";
                        orptDutyTran.CustomerAddress = "";
                        orptDutyTran.SBUID = 0;
                    }

                    orptDutyTran.ChannelID = (int)reader["ChannelID"];
                    orptDutyTran.WarehouseID = (int)reader["FromWHID"];
                    orptDutyTran.InvoiceStatus = 0;
                    orptDutyTran.InvoiceTypeID = 0;

                    InnerList.Add(orptDutyTran);
                }
                reader.Close();              

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DataSetToClass(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptDutyTran orptDutyTran = new rptDutyTran();

                    orptDutyTran.DutyTranID = (int)oRow["DutyTranID"];
                    orptDutyTran.DutyTranNo = (string)oRow["DutyTranNo"];
                    orptDutyTran.DutyTranTypeID = (int)oRow["DutyTranTypeID"];
                    orptDutyTran.DutyTranDate = (DateTime)oRow["DutyTranDate"];
                    orptDutyTran.DocumentNo = oRow["DocumentNo"].ToString();
                    orptDutyTran.ChallanTypeID = (int)oRow["ChallanTypeID"];
                    orptDutyTran.RefID = (int)oRow["RefID"];
                    orptDutyTran.WHID = (int)oRow["WHID"];
                    orptDutyTran.Remarks = oRow["Remarks"].ToString();
                    orptDutyTran.Amount = (double)oRow["Amount"];
                    orptDutyTran.DutyAccountID = (int)oRow["DutyAccountID"];
                    orptDutyTran.CustomerID = (int)oRow["CustomerID"];
                    orptDutyTran.CustomerCode = (string)oRow["CustomerCode"];
                    orptDutyTran.CustomerName = (string)oRow["CustomerName"];
                    orptDutyTran.CustomerAddress = (string)oRow["CustomerAddress"];
                    orptDutyTran.SBUID = (long)oRow["SBUID"];
                    orptDutyTran.ChannelID = (int)oRow["ChannelID"];
                    orptDutyTran.WarehouseID = (int)oRow["WarehouseID"];
                    orptDutyTran.InvoiceStatus = (int)oRow["InvoiceStatus"];
                    orptDutyTran.InvoiceTypeID = (int)oRow["InvoiceTypeID"];             
                               

                    InnerList.Add(orptDutyTran);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool Check(int nWarehouseID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_MapTDWarehouse where Warehouseid =? ";
            cmd.Parameters.AddWithValue("Warehouseid", nWarehouseID);
          
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
            if (nCount != 0)
                return true;
            else return false;
        }

      
    }
  
}
