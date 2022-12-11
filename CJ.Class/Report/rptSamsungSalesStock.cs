using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class.Report
{
    [Serializable]
    public class rptSamsungSalesStock
    {
        private string _sTDOutlet;
        private string _sASG;
        private string _sProductCode;
        private string _sProductName;
        private int _nCurrentStock;
        private int _nSalesQty;


        public string TDOutlet
        {
            get { return _sTDOutlet; }
            set { _sTDOutlet = value; }
        }
        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value; }
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
        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
    }

    public class rptSamsungSalesStocks : CollectionBaseCustom
    {
        public rptSamsungSalesStock this[Int32 Index]
        {
            get
            {
                return (rptSamsungSalesStock)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptSamsungSalesStock))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void Add(rptSamsungSalesStock orptSamsungSalesStock)
        {
            this.List.Add(orptSamsungSalesStock);
        }
        
        public void Refresh(DateTime _dStartDate, DateTime _dEndDate, string sOutletID, string sASGID, string sProdCode, string sProdName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();
            try
            {
            #region query

                sQueryStringMaster.Append(" select OutletID,tdoutlet,asgid,asg,productcode,productname,sum(currentstock)  currentstock,sum(SalesQty) as SalesQty from  ");
                sQueryStringMaster.Append(" (select OutletID,tdoutlet,asgid,asg,productcode,productname,currentstock,0 as SalesQty from  ");
                sQueryStringMaster.Append(" (select customerid as OutletID,warehousecode,telsysdb.dbo.t_ProductStock.warehouseid as warehouseid,ShortCode as TDOutlet,asgid,ASGname as ASG,cast(v_ProductDetails.ProductCode as int) ProductCode,  ");
                sQueryStringMaster.Append(" brandid, ProductName,productmodel,CurrentStock,CurrentStock * CostPrice as StockValue,rsp,warehouseparentid  ");
                sQueryStringMaster.Append(" from telsysdb.dbo.t_ProductStock  ");
                sQueryStringMaster.Append(" inner join telsysdb.dbo.v_ProductDetails  ");
                sQueryStringMaster.Append(" on t_ProductStock.ProductID=v_ProductDetails.ProductID  ");
                sQueryStringMaster.Append(" inner join telsysdb.dbo.t_Warehouse  ");
                sQueryStringMaster.Append(" on t_Warehouse.WarehouseID=t_ProductStock.WarehouseID ");
                sQueryStringMaster.Append(" left outer Join (select customerid,customername from v_customerdetails where customertypeid=5 and customerID Not IN (7,2170,789,2171)) pd  ");
                sQueryStringMaster.Append(" on  substring(pd.customername,1,3)= t_Warehouse.shortcode) A  ");
                sQueryStringMaster.Append(" WHERE WAREHOUSECODE  not in (0,2,6) and tdoutlet is not null and brandid=19 and currentstock<>0 and warehouseparentid=7  ");
                sQueryStringMaster.Append(" union all  ");
                sQueryStringMaster.Append(" select OutletID,tdoutlet,asgid,asg,productcode,productname,0 as currentstock, salesqty from  ");
                sQueryStringMaster.Append(" (select ProductID,convert(int,ProductCode) as ProductCode,ProductName,ProductModel,asgid,asgname as asg, rsp,areacode,areaname,  ");
                sQueryStringMaster.Append(" CustomerID,pd.CustomerCode,customerid OutletID, substring(CustomerName,1,3) TDOutlet,CustomerTypeName  ");
                sQueryStringMaster.Append(" from telsysdb.dbo.v_ProductDetails , telsysdb.dbo.v_CustomerDetails pd  ");
                sQueryStringMaster.Append(" where itemcategory=1 and brandid=19 and customertypeid=5  ");
                sQueryStringMaster.Append(" ) A  ");
                sQueryStringMaster.Append(" inner join  ");
                sQueryStringMaster.Append(" (select ProductID,CustomerID,invdate, isnull(sum(p2.CR) - abs(sum(p2.DR)),0) as SalesQty,isnull(sum(p2.FreeCR) - abs(sum(p2.FreeDR)),0) as FreeQty,  ");
                sQueryStringMaster.Append(" (isnull(sum(p2.CR) - abs(sum(p2.DR)),0)*unitprice) as value,unitprice   ");
                sQueryStringMaster.Append(" from  ");
                sQueryStringMaster.Append(" ( select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,CustomerID,    ");
                sQueryStringMaster.Append(" sum(Quantity) as CR, 0 as DR,sum(isnull(FreeQty,0)) as FreeCR, 0 as FreeDR,avg(unitprice)as unitprice     ");
                sQueryStringMaster.Append(" from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd     ");
                sQueryStringMaster.Append(" where  im.InvoiceID = cd.InvoiceID and    ");
                sQueryStringMaster.Append(" im.invoicetypeid in (1,2,3,4,5,15) and invoicestatus not in (3)     ");
                sQueryStringMaster.Append(" group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,CustomerID     ");
                sQueryStringMaster.Append(" union all      ");
                sQueryStringMaster.Append(" select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,CustomerID,    ");
                sQueryStringMaster.Append(" 0 as CR, sum(Quantity)  as DR,0 as FreeCR, sum(isnull(FreeQty,0)) as FreeDR,avg(unitprice)as unitprice     ");
                sQueryStringMaster.Append(" from telsysdb.dbo.t_salesInvoice im,   ");
                sQueryStringMaster.Append(" telsysdb.dbo.t_salesInvoiceDetail cd     ");
                sQueryStringMaster.Append(" where  im.InvoiceID = cd.InvoiceID and    ");
                sQueryStringMaster.Append(" im.invoicetypeid in (6,7,8,9,10,12,16) and invoicestatus not in (3)     ");
                sQueryStringMaster.Append(" group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,CustomerID )     ");
                sQueryStringMaster.Append(" as p2  ");
                sQueryStringMaster.Append(" where InvDate between ? and ?  ");
                sQueryStringMaster.Append(" group by InvDate,ProductID,CustomerID,unitprice  ");
                sQueryStringMaster.Append(" having isnull(sum(p2.CR) - abs(sum(p2.DR)),0)<>0) B  ");
                sQueryStringMaster.Append(" on A.ProductId=B.ProductID and A.CustomerID=B.CustomerID) m  Where 1=1 ");
                if (sOutletID != "-1")
                {
                    sQueryStringMaster.Append(" and OutletID=" + sOutletID + " ");
                }
                if (sASGID != "-1")
                {
                    sQueryStringMaster.Append(" and ASGID=" + sASGID + " ");
                }
                if (sProdCode.Trim() != "")
                {
                    sQueryStringMaster.Append(" and ProductCode=" + sProdCode.Trim() + " ");
                }
                if (sProdName.Trim() != "")
                {
                    sQueryStringMaster.Append(" and ProductName like '%" + sProdName.Trim() + "%' ");
                }

                sQueryStringMaster.Append(" group by OutletID,tdoutlet,asgid,asg,productcode,productname  ");


                #endregion
                OleDbCommand oCmd = DBController.Instance.GetCommand();
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sQueryStringMaster.ToString();
                oCmd.Parameters.AddWithValue("InvDate", _dStartDate); 
                oCmd.Parameters.AddWithValue("InvDate", _dEndDate);

                GetSamsungProductSalesStock(oCmd); 

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

        public void GetSamsungProductSalesStock(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSamsungSalesStock oqData = new rptSamsungSalesStock();

                    if (reader["TdOutlet"] != DBNull.Value)
                        oqData.TDOutlet = reader["TdOutlet"].ToString();
                    else oqData.TDOutlet  = "";

                    if (reader["ASG"] != DBNull.Value)
                        oqData.ASG = reader["ASG"].ToString();
                    else oqData.ASG = "";

                    if (reader["ProductCode"] != DBNull.Value)
                        oqData.ProductCode = reader["ProductCode"].ToString();
                    else oqData.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oqData.ProductName = reader["ProductName"].ToString();
                    else oqData.ProductName = "";

                    if (reader["CurrentStock"] != DBNull.Value)
                        oqData.CurrentStock = Convert.ToInt32(reader["CurrentStock"].ToString());
                    else oqData.CurrentStock = -1;

                    if (reader["SalesQty"] != DBNull.Value)
                        oqData.SalesQty = Convert.ToInt32(reader["SalesQty"].ToString());
                    else oqData.SalesQty = -1;


                    InnerList.Add(oqData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetSamsungProductSalesStock(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSamsungSalesStock oSamsungSalesStock = new rptSamsungSalesStock();


                    oSamsungSalesStock.TDOutlet = (string)oRow["TDOutlet"];
                    oSamsungSalesStock.ASG = (string)oRow["ASG"];
                    oSamsungSalesStock.ProductCode = (string)oRow["ProductCode"];
                    oSamsungSalesStock.ProductName = (string)oRow["ProductName"];
                    oSamsungSalesStock.CurrentStock = Convert.ToInt32(oRow["CurrentStock"]);
                    oSamsungSalesStock.SalesQty = Convert.ToInt32(oRow["SalesQty"]);

                    InnerList.Add(oSamsungSalesStock);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
