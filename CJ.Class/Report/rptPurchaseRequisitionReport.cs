// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 19, 2011
// Time :  10:00 AM
// Description: Class for Purchase Requisition Report.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class.Report
{
    public class rptPurchaseRequisitionReport
    {
        private int _nPOID;
        private int _nEntryUserID;
        private int _nUpdateUserID;
        private string _sEntryUsername;
        private string _sUpdateUsername;
        private int _nStatus;
        private double _fLCValue;
        private int _nSupplierID;
        private string _sSupplierName;

        private string _sPONo;
        private string _sPINo;
        private string _sLCNo;
        private string _sLCInvoiceNo;   
        private string _sRemarks;

        private object _dEntryDate;
        private object _dUpdateDate;
        private object _dLCDate;
        private object _dLCInvoiceDate;
        private object _dETA;
        private object _dShipmentDate;
        private object _dExpiryDate;
        private object _dReceivedDate;
        private object _dApprovalDate;
        private object _dPortArrivalDate;

        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private long _lApprovedQty;
        private long _lLCQty;
        private long _lReceivedQty;
        private double _fUnitValue;

        private long _nYrTargetQty;
        private long _nYTDSalesQty;
        private long _nOnHandStock;
        private long _nTransitStock;

      
        public int POID
        {
            get { return _nPOID; }
            set { _nPOID = value; }
        }
        public int EntryUserID
        {
            get { return _nEntryUserID; }
            set { _nEntryUserID = value; }
        }
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        public string EntryUsername
        {
            get { return _sEntryUsername; }
            set { _sEntryUsername = value; }
        }
        public string UpdateUsername
        {
            get { return _sUpdateUsername; }
            set { _sUpdateUsername = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value; }
        }
        public double LCValue
        {
            get { return _fLCValue; }
            set { _fLCValue = value; }
        }
        public string PONo
        {
            get { return _sPONo; }
            set { _sPONo = value; }
        }
        public string PINo
        {
            get { return _sPINo; }
            set { _sPINo = value; }
        }
        public string LCNo
        {
            get { return _sLCNo; }
            set { _sLCNo = value; }
        }
        public string LCInvoiceNo
        {
            get { return _sLCInvoiceNo; }
            set { _sLCInvoiceNo = value; }
        }     
     
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public object EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        public object LCDate
        {
            get { return _dLCDate; }
            set { _dLCDate = value; }
        }
        public object LCInvoiceDate
        {
            get { return _dLCInvoiceDate; }
            set { _dLCInvoiceDate = value; }
        }
        public object ETA
        {
            get { return _dETA; }
            set { _dETA = value; }
        }
        public object ShipmentDate
        {
            get { return _dShipmentDate; }
            set { _dShipmentDate = value; }
        }
        public object ExpiryDate
        {
            get { return _dExpiryDate; }
            set { _dExpiryDate = value; }
        }
        public object ReceivedDate
        {
            get { return _dReceivedDate; }
            set { _dReceivedDate = value; }
        }
        public object ApprovalDate
        {
            get { return _dApprovalDate; }
            set { _dApprovalDate = value; }
        }
        public object PortArrivalDate
        {
            get { return _dPortArrivalDate; }
            set { _dPortArrivalDate = value; }
        }
      

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public long ApprovedQty
        {
            get { return _lApprovedQty; }
            set { _lApprovedQty = value; }
        }
        public long ReceivedQty
        {
            get { return _lReceivedQty; }
            set { _lReceivedQty = value; }
        }
        public long LCQty
        {
            get { return _lLCQty; }
            set { _lLCQty = value; }
        }
        public double UnitValue
        {
            get { return _fUnitValue; }
            set { _fUnitValue = value; }
        }
        public long YrTargetQty
        {
            get { return _nYrTargetQty; }
            set { _nYrTargetQty = value; }
        }
        public long YTDSalesQty
        {
            get { return _nYTDSalesQty; }
            set { _nYTDSalesQty = value; }
        }
        public long OnHandStock
        {
            get { return _nOnHandStock; }
            set { _nOnHandStock = value; }
        }
        public long TransitStock
        {
            get { return _nTransitStock; }
            set { _nTransitStock = value; }
        }

       
    }
    public class rptPurchaseRequisitionReports : CollectionBase
    {

        public rptPurchaseRequisitionReport this[int i]
        {
            get { return (rptPurchaseRequisitionReport)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptPurchaseRequisitionReport orptPurchaseRequisitionReport)
        {
            InnerList.Add(orptPurchaseRequisitionReport);
        }
        public void Report(int nPOID)
        {
            InnerList.Clear();
            DateTime dtpFrom = new DateTime();
            DateTime dtpTo = new DateTime();
            dtpFrom = Convert.ToDateTime("01-Jan-" + System.DateTime.Now.Year.ToString());
            dtpTo = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql =       "   select q1.POID, q1.pino, q1.PONo, q1.ETA, q1.supplierid, q1.entrydate, q1.entryuserid, q1.approvaldate, q1.lcdate, q1.lcno, q1.lcvalue, isnull(q1.UnitValue,0) as UnitValue, q1.shipmentdate, 	" +
                                "  	q1.portarrivaldate, q1.receiveddate, q1.status, q1.updateuserid, q1.updatedate, q1.remarks, q1.lcinvoiceno, q1.lcinvoicedate, q1.expirydate,  	" +
                                "  	q1.productid, q1.productcode, q1.productname, q1.suppliercode, q1.suppliername, q1.entryusername, q1.updateusername  	" +
                                "  	, isnull(q1.ApprovedQty,0) as ApprovedQty, isnull(q1.LCQty,0) as LCQty, isnull(q1.ReceivedQty,0) as ReceivedQty 	" +
                                "  	, isnull(q2.Target,0) as YrTargetQty, isnull(q3.SalesQty,0) as YTDSalesQty, isnull(q4.currentstock,0) as OnHandStock  	" +
                                "  	, isnull(q5.Transitstock,0) as TransitStock  	" +
                                "  	from 	" +
                                "  	(  	" +
                                "  	select q1.POID, q1.pino, q1.PONo, q1.ETA, q1.supplierid, q1.entrydate, q1.entryuserid, q1.approvaldate, q1.lcdate, q1.lcno, q1.lcvalue, q1.UnitValue, q1.shipmentdate, 	" +
                                "  	q1.portarrivaldate, q1.receiveddate, q1.status, q1.updateuserid, q1.updatedate, q1.remarks, q1.lcinvoiceno, q1.lcinvoicedate, q1.expirydate,  	" +
                                "  	q1.productid, q1.approvedqty, q1.lcqty, q1.receivedqty, q2.productcode, q2.productname, q3.suppliercode, q3.suppliername, q4.username as entryusername, q5.username as updateusername  	" +
                                "  	from 	" +
                                "  	(	" +
                                "  	select a.POID, a.PONo, a.pino, a.supplierid, a.entrydate, a.entryuserid, a.approvaldate, a.lcdate, a.lcno, a.lcvalue, a.shipmentdate, 	" +
                                "  	a.portarrivaldate, a.receiveddate, a.status, a.updateuserid, a.updatedate, a.remarks, a.lcinvoiceno, a.lcinvoicedate, a.expirydate,  	" +
                                "  	b.productid, b.approvedqty, b.lcqty, b.receivedqty, b.UnitValue, a.ETA    	" +
                                "  	from t_PurchaseRequisition a, t_PurchaseRequisitiondetail b 	" +
                                "  	where a.POID = b.POID and a.POID = '" + nPOID + "' 	" +
                                "  	) as q1 	" +
                                "  	left outer join 	" +
                                "  	(	" +
                                "  	select * from t_product 	" +
                                "  	) as q2 on q1.productid = q2.productid 	" +
                                "  	left outer join 	" +
                                "  	(	" +
                                "  	select * from t_supplier 	" +
                                "  	) as q3 on q1.supplierid = q3.supplierid  	" +
                                "  	left outer join 	" +
                                "  	(	" +
                                "  	select * from t_user  	" +
                                "  	) as q4 on q1.entryuserid = q4.userid  	" +
                                "  	left outer join 	" +
                                "  	(	" +
                                "  	select * from t_user  	" +
                                "  	) as q5 on q1.updateuserid = q5.userid  	" +
                                "  	group by q1.POID, q1.pino, q1.PONo, q1.ETA, q1.supplierid, q1.entrydate, q1.entryuserid, q1.approvaldate, q1.lcdate, q1.lcno, q1.lcvalue, q1.UnitValue, q1.shipmentdate, 	" +
                                "  	q1.portarrivaldate, q1.receiveddate, q1.status, q1.updateuserid, q1.updatedate, q1.remarks, q1.lcinvoiceno, q1.lcinvoicedate, q1.expirydate,  	" +
                                "  	q1.productid, q1.approvedqty, q1.lcqty, q1.receivedqty, q2.productcode, q2.productname, q3.suppliercode, q3.suppliername, q4.username, q5.username        	" +
                                "  	) as q1  	" +
                                "  	left outer join   	" +
                                "  	( 	" +
                                "  	select ProductGroupID as Productid , sum(isnull(Qty,0)) as Target 	" +
                                "  	from t_planbudgettarget   	" +
                                "  	where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  	" +
                                "  	and perioddate between '" + dtpFrom.ToShortDateString() + "' and '" + dtpTo.ToShortDateString() + "' 	" +
                                "  	group by  ProductGroupID   	" +
                                "  	) as q2 on q1.ProductID = q2.ProductID   	" +
                                "  	left outer join 	" +
                                "  	(  	" +
                                "  	select p2.ProductID, isnull(sum(p2.InvQty) - abs(sum(p2.RevQty)),0) as SalesQty      	" +
                                "  	from     	" +
                                "  	(     	" +
                                "  	select ProductID, sum(isnull(quantity,0)) as InvQty, 0 as RevQty 	" +
                                "  	from t_salesInvoice im,  t_salesInvoiceDetail cd    	" +
                                "  	where  im.InvoiceID = cd.InvoiceID and   	" +
                                "  	invoicedate between '" + dtpFrom.ToShortDateString() + "' and '" + dtpTo.AddDays(1).ToShortDateString() + "' and invoicedate< '" + dtpTo.AddDays(1).ToShortDateString() + "' and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)    	" +
                                "  	group by  ProductID    	" +
                                "  	union all     	" +
                                "  	select ProductID, 0 as InvQty, sum(isnull(quantity,0)) as RevQty      	" +
                                "  	from t_salesInvoice im,  t_salesInvoiceDetail cd    	" +
                                "  	where  im.InvoiceID = cd.InvoiceID and   	" +
                                "  	invoicedate between '" + dtpFrom.ToShortDateString() + "'  and '" + dtpTo.AddDays(1).ToShortDateString() + "' and invoicedate< '" + dtpTo.AddDays(1).ToShortDateString() + "' and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    	" +
                                "  	group by  ProductID     	" +
                                "  	) as p2   	" +
                                "  	group by p2.ProductID 	" +
                                "  	) as q3 on q1.ProductID = q3.ProductID  	" +
                                "  	left outer join 	" +
                                "  	(  	" +
                                "  	select productid, sum(currentstock) as currentstock  	" +
                                "  	from t_productstock 	" +
                                "  	where warehouseid not in (1,78,83,84,85,87,88,89,90,94,67,76,86,75) 	" +
                                "  	group by productid  	" +
                                "  	) as q4 on q1.ProductID = q4.ProductID  	" +
                                "  	left outer join 	" +
                                "  	(	" +
                                "  	select productid, sum(Transitstock) as Transitstock  	" +
                                "  	from t_productstock 	" +
                                "  	where warehouseid in (72) 	" +
                                "  	group by productid  	" +
                                "  	) as q5 on q1.ProductID = q5.ProductID  	" +
                                "  	group by q1.POID, q1.pino, q1.PONo, q1.ETA, q1.supplierid, q1.entrydate, q1.entryuserid, q1.approvaldate, q1.lcdate, q1.lcno, q1.lcvalue, q1.UnitValue, q1.shipmentdate, 	" +
                                "  	q1.portarrivaldate, q1.receiveddate, q1.status, q1.updateuserid, q1.updatedate, q1.remarks, q1.lcinvoiceno, q1.lcinvoicedate, q1.expirydate,  	" +
                                "  	q1.productid, q1.productcode, q1.productname, q1.suppliercode, q1.suppliername, q1.entryusername, q1.updateusername, 	" +
                                "  	q1.ApprovedQty, q1.LCQty, q1.ReceivedQty, q2.Target, q3.SalesQty, q4.currentstock, q5.Transitstock    	";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptPurchaseRequisitionReport orptPurchaseRequisitionReport = new rptPurchaseRequisitionReport();

                    orptPurchaseRequisitionReport.POID = int.Parse(reader["POID"].ToString());
                    orptPurchaseRequisitionReport.PONo = reader["PONo"].ToString();
                    orptPurchaseRequisitionReport.SupplierID = (int)reader["SupplierID"];
                    orptPurchaseRequisitionReport.Status = int.Parse(reader["Status"].ToString());
                    orptPurchaseRequisitionReport.Remarks = reader["Remarks"].ToString();

                    //orptPurchaseRequisitionReport.EntryUserID = (int)reader["EntryUserID"];
                    //orptPurchaseRequisitionReport.EntryUsername = reader["EntryUserName"].ToString();
                    //orptPurchaseRequisitionReport.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());

                    orptPurchaseRequisitionReport.ApprovalDate = (object)reader["ApprovalDate"];
                    orptPurchaseRequisitionReport.PortArrivalDate = (object)reader["PortArrivalDate"];
                    orptPurchaseRequisitionReport.ReceivedDate = (object)reader["ReceivedDate"];


                    orptPurchaseRequisitionReport.LCNo = reader["LCNo"].ToString();
                    orptPurchaseRequisitionReport.LCInvoiceNo = reader["LCInvoiceNo"].ToString();
                    orptPurchaseRequisitionReport.LCValue = Convert.ToDouble(reader["LCValue"].ToString());
                    orptPurchaseRequisitionReport.PINo = reader["LCInvoiceNo"].ToString();
                    orptPurchaseRequisitionReport.LCDate = (object)reader["LCDate"];
                    orptPurchaseRequisitionReport.LCInvoiceDate = (object)reader["LCInvoiceDate"];
                    orptPurchaseRequisitionReport.ETA = (object)reader["ETA"];
                    orptPurchaseRequisitionReport.ShipmentDate = (object)reader["ShipmentDate"];
                    orptPurchaseRequisitionReport.ExpiryDate = (object)reader["ExpiryDate"];

                    orptPurchaseRequisitionReport.ProductID = int.Parse(reader["ProductID"].ToString());
                    orptPurchaseRequisitionReport.ProductCode = (string)reader["ProductCode"];
                    orptPurchaseRequisitionReport.ProductName = (string)reader["ProductName"];

                    orptPurchaseRequisitionReport.ApprovedQty = Convert.ToInt64(reader["ApprovedQty"].ToString());
                    orptPurchaseRequisitionReport.LCQty = Convert.ToInt64(reader["LCQty"].ToString());
                    orptPurchaseRequisitionReport.ReceivedQty = Convert.ToInt64(reader["ReceivedQty"].ToString());
                    orptPurchaseRequisitionReport.UnitValue = Convert.ToDouble(reader["UnitValue"].ToString());

                    orptPurchaseRequisitionReport.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    orptPurchaseRequisitionReport.SupplierName = (string)reader["SupplierName"].ToString();

                    //orptPurchaseRequisitionReport.UpdateUserID = int.Parse(reader["UpdateUserID"].ToString());
                    //orptPurchaseRequisitionReport.UpdateUsername = reader["UpdateUserName"].ToString();
                    //orptPurchaseRequisitionReport.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());

                    orptPurchaseRequisitionReport.YrTargetQty = Convert.ToInt64(reader["YrTargetQty"].ToString());
                    orptPurchaseRequisitionReport.YTDSalesQty = Convert.ToInt64(reader["YTDSalesQty"].ToString());
                    orptPurchaseRequisitionReport.OnHandStock = Convert.ToInt64(reader["OnHandStock"].ToString());
                    orptPurchaseRequisitionReport.TransitStock = Convert.ToInt64(reader["TransitStock"].ToString());
                    InnerList.Add(orptPurchaseRequisitionReport);
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
