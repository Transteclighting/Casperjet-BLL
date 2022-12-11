// <summary>
// Compamy: Bangladesh Lamps Limited
// Author: Md. Humayun Rashid
// Date: Nov 26, 2017
// Time" :  
// Descriptio: VAT Reports
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    public class VATReports
    {
        private DateTime _dDutyTranDate;
        private double _nSales;
        private double _nVAT;
        private double _nTotalSales_VAT;

        private int _nASGID;
        private string _sASGname;
        private int _nBrandID;
        private int _nProductID;
        private string _sProductCode;
        private string _sproductName;
        private int _nMAGID;
        private string _sMAGName;

        private double _dSales_2017;
        private double _dVAT_2017;
        private double _dSales_2016;
        private double _dVAT_2016;

        public DateTime DutyTranDate
        {
            get { return _dDutyTranDate; }
            set { _dDutyTranDate = value; }
        }

        public double Sales
        {
            get { return _nSales; }
            set { _nSales = value; }
        }

        public double VAT
        {
            get { return _nVAT; }
            set { _nVAT = value; }
        }

        public double TotalSales_VAT
        {
            get { return _nTotalSales_VAT; }
            set { _nTotalSales_VAT = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        public string ASGname
        {
            get { return _sASGname; }
            set { _sASGname = value; }
        }

        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
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

        public string productName
        {
            get { return _sproductName; }
            set { _sproductName = value; }
        }

        public double Sales_2017
        {
            get { return _dSales_2017; }
            set { _dSales_2017 = value; }
        }

        public double VAT_2017
        {
            get { return _dVAT_2017; }
            set { _dVAT_2017 = value; }
        }

        public double Sales_2016
        {
            get { return _dSales_2016; }
            set { _dSales_2016 = value; }
        }

        public double VAT_2016
        {
            get { return _dVAT_2016; }
            set { _dVAT_2016 = value; }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }


    }

    public class VATReportsDetails : CollectionBaseCustom
    {
        public void Add(VATReports oVATReports)
        {
            this.List.Add(oVATReports);
        }

        public VATReports this[Int32 Index]
        {
            get
            {
                return (VATReports)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(VATReports))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        /// <summary>
        /// SALES & VAT (DAY Wise)
        /// </summary>

        public void VATReports(DateTime dYFromDate, DateTime dYToDate)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            //SALES & VAT (DAY Wise)

            
             //sQueryStringMaster.Append(" Select Convert(datetime,replace(convert(varchar, DutyTranDate,6),'','-'),1) as DutyTranDate , DocumentNo, ");
             //sQueryStringMaster.Append(" sum(Qty*DutyPrice) as Sales, sum (Qty*DutyPrice*DutyRate) as VAT, sum((Qty*DutyPrice)+(Qty*DutyPrice*DutyRate)) as TotalSales_VAT ");
             //sQueryStringMaster.Append(" from t_dutytran a, t_dutytrandetail b ");
             //sQueryStringMaster.Append(" where a.DutyTranID=b.DutyTranID and  DutyTranDate between '01-Nov-2017' and '01-Dec-2017' and DutyTranDate <'01-Dec-2017' ");
             //sQueryStringMaster.Append(" group by DutyTranDate, DocumentNo ");
             //sQueryStringMaster.Append(" order by DutyTranDate ");

            sQueryStringMaster.Append(" select DutyTranDate, sum(Sales)as Sales, sum(VAT)as VAT, sum(Sales+VAT)as TotalSales_VAT ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" Select CONVERT(datetime,Replace(CONVERT(VARCHAR(11), DutyTranDate, 106),' ', '-')) AS DutyTranDate,ASGID, ASGname,BrandID,b.ProductID,ProductCode,productName,sum(Qty*DutyPrice) as Sales, sum(Qty*DutyPrice*DutyRate) as VAT, sum((Qty*DutyPrice)+(Qty*DutyPrice*DutyRate)) as TotalSales_VAT ");
            sQueryStringMaster.Append(" from t_dutytran a, t_dutytrandetail b, v_ProductDetails c ");
            sQueryStringMaster.Append(" where a.DutyTranID=b.DutyTranID and b.ProductID=c.ProductID and DutyTranDate between '19-Nov-2017' and '22-Nov-2017' and DutyTranDate <'22-Nov-2017' ");
            sQueryStringMaster.Append(" group by DutyTranDate,ASGID, ASGname,BrandID,b.ProductID,ProductCode,productName ");
            sQueryStringMaster.Append(" )As Daywise group by DutyTranDate ");
            sQueryStringMaster.Append(" order by DutyTranDate ");





            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("DutyTranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("DutyTranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("DutyTranDate", dYToDate.Date.AddDays(1));
            getDataVATReports(oCmd);

        }

        private void getDataVATReports(OleDbCommand cmd)
        {
            int nCount = 0;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VATReports oItem = new VATReports();

                    if (reader["DutyTranDate"] != DBNull.Value)
                        oItem.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    else oItem.DutyTranDate = Convert.ToDateTime(" Null");

                    if (reader["Sales"] != DBNull.Value)
                        oItem.Sales = Convert.ToDouble(reader["Sales"]);
                    else oItem.Sales = -1;

                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = Convert.ToDouble(reader["VAT"]);
                    else oItem.VAT = -1;

                    if (reader["TotalSales_VAT"] != DBNull.Value)
                        oItem.TotalSales_VAT = Convert.ToDouble(reader["TotalSales_VAT"]);
                    else oItem.TotalSales_VAT = -1;

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

        public void FromDataSetVATReports(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    VATReports oItem = new VATReports();

                    oItem.DutyTranDate = (DateTime)oRow["DutyTranDate"];
                    oItem.Sales = (double)oRow["Sales"];
                    oItem.VAT = (double)oRow["VAT"];
                    oItem.TotalSales_VAT = (double)oRow["TotalSales_VAT"];


                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// SALES & VAT (Item Wise)
        /// </summary>


        public void VATItem(DateTime dYFromDate, DateTime dYToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


            sQueryStringMaster.Append(" Select MAGName,ASGname,ProductCode,productName,sum(Qty*DutyPrice) as Sales, sum(Qty*DutyPrice*DutyRate) as VAT, sum((Qty*DutyPrice)+(Qty*DutyPrice*DutyRate)) as ");
            sQueryStringMaster.Append(" TotalSales_VAT ");
            sQueryStringMaster.Append(" from t_dutytran a, t_dutytrandetail b, v_ProductDetails c ");
            sQueryStringMaster.Append(" where a.DutyTranID=b.DutyTranID and b.ProductID=c.ProductID and DutyTranDate between '19-Nov-2017' and '22-Nov-2017' and DutyTranDate <'22-Nov-2017' ");
            sQueryStringMaster.Append(" group by DutyTranDate,MAGID,MAGName,ASGID, ASGname,BrandID,b.ProductID,ProductCode,productName ");
            sQueryStringMaster.Append(" order by MAGName,ASGname,ProductCode,productName ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("DutyTranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("DutyTranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("DutyTranDate", dYToDate.Date.AddDays(1));

            getVATItem(oCmd);
 
        }

        private void getVATItem(OleDbCommand cmd)
        {
            int nCount = 0;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VATReports oItem = new VATReports();

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = reader["MAGName"].ToString();
                    else oItem.MAGName = "";

                        if (reader["ASGname"] != DBNull.Value)
                            oItem.ASGname = reader["ASGname"].ToString();
                        else oItem.ASGname = "";

                        if (reader["ProductCode"] != DBNull.Value)
                            oItem.ProductCode = reader["ProductCode"].ToString();
                        else oItem.ProductCode = "";

                        if (reader["productName"] != DBNull.Value)
                            oItem.productName = reader["productName"].ToString();
                        else oItem.productName = "";

                    if (reader["Sales"] != DBNull.Value)
                        oItem.Sales = Convert.ToDouble(reader["Sales"]);
                    else oItem.Sales = -1;

                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = Convert.ToDouble(reader["VAT"]);
                    else oItem.VAT = -1;

                    if (reader["TotalSales_VAT"] != DBNull.Value)
                        oItem.TotalSales_VAT = Convert.ToDouble(reader["TotalSales_VAT"]);
                    else oItem.TotalSales_VAT = -1;

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

        public void FromDataSetVATItem(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    VATReports oItem = new VATReports();

                    oItem.MAGName = oRow["MAGName"].ToString();
                    oItem.ASGname = oRow["ASGname"].ToString();
                    oItem.ProductCode = oRow["ProductCode"].ToString();
                    oItem.productName = oRow["productName"].ToString();

                    oItem.Sales = (double)oRow["Sales"];
                    oItem.VAT = (double)oRow["VAT"];
                    oItem.TotalSales_VAT = (double)oRow["TotalSales_VAT"];


                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        /// <summary>
        /// Sales & VAT ( Total )
        /// </summary>


        public void VATTotal(DateTime dYFromDate, DateTime dYToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append(" select  sum(Sales)as Sales, sum(VAT)as VAT, sum(Sales+VAT)as TotalSales_VAT ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" Select CONVERT(datetime,Replace(CONVERT(VARCHAR(11), DutyTranDate, 106),' ', '-')) AS DutyTranDate,ASGID, ASGname,BrandID,b.ProductID,ProductCode,productName,sum(Qty*DutyPrice) as Sales, sum(Qty*DutyPrice*DutyRate) as VAT, sum((Qty*DutyPrice)+(Qty*DutyPrice*DutyRate)) as TotalSales_VAT ");
            sQueryStringMaster.Append(" from t_dutytran a, t_dutytrandetail b, v_ProductDetails c ");
            sQueryStringMaster.Append(" where a.DutyTranID=b.DutyTranID and b.ProductID=c.ProductID and DutyTranDate between '19-Nov-2017' and '22-Nov-2017' and DutyTranDate <'22-Nov-2017' ");
            sQueryStringMaster.Append(" group by DutyTranDate,ASGID, ASGname,BrandID,b.ProductID,ProductCode,productName ");
            sQueryStringMaster.Append(" )As Daywise  ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("DutyTranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("DutyTranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("DutyTranDate", dYToDate.Date.AddDays(1));

            getVATTotal(oCmd);

        }

        private void getVATTotal(OleDbCommand cmd)
        {
            int nCount = 0;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VATReports oItem = new VATReports();

                    if (reader["Sales"] != DBNull.Value)
                        oItem.Sales = Convert.ToDouble(reader["Sales"]);
                    else oItem.Sales = -1;

                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = Convert.ToDouble(reader["VAT"]);
                    else oItem.VAT = -1;

                    if (reader["TotalSales_VAT"] != DBNull.Value)
                        oItem.TotalSales_VAT = Convert.ToDouble(reader["TotalSales_VAT"]);
                    else oItem.TotalSales_VAT = -1;

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

        public void FromDataSetVATTotal(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    VATReports oItem = new VATReports();

                    oItem.Sales = (double)oRow["Sales"];
                    oItem.VAT = (double)oRow["VAT"];
                    oItem.TotalSales_VAT = (double)oRow["TotalSales_VAT"];


                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        /// <summary>
        /// Sales & VAT ( Comparison Month Wise)
        /// </summary>


        public void VATComparison(DateTime dYFromDate, DateTime dYToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

                sQueryStringMaster.Append(" select  sum(Sales)as Sales_2017, sum(VAT)as VAT_2017,0 as Sales_2016, 0 as VAT_2016 ");
                sQueryStringMaster.Append(" from ");
                sQueryStringMaster.Append(" ( ");
                sQueryStringMaster.Append(" Select CONVERT(datetime,Replace(CONVERT(VARCHAR(11), DutyTranDate, 106),' ', '-')) AS DutyTranDate,ASGID, ASGname,BrandID,b.ProductID,ProductCode,productName,sum(Qty*DutyPrice) as Sales, sum(Qty*DutyPrice*DutyRate) as VAT, sum((Qty*DutyPrice)+(Qty*DutyPrice*DutyRate)) as TotalSales_VAT ");
                sQueryStringMaster.Append(" from t_dutytran a, t_dutytrandetail b, v_ProductDetails c ");
                sQueryStringMaster.Append(" where a.DutyTranID=b.DutyTranID and b.ProductID=c.ProductID and DutyTranDate between '19-Nov-2017' and '22-Nov-2017' and DutyTranDate <'22-Nov-2017' ");
                sQueryStringMaster.Append(" group by DutyTranDate,ASGID, ASGname,BrandID,b.ProductID,ProductCode,productName ");
                sQueryStringMaster.Append(" )As Daywise ");

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("DutyTranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("DutyTranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("DutyTranDate", dYToDate.Date.AddDays(1));

            getVATComparison(oCmd);

        }

        private void getVATComparison(OleDbCommand cmd)
        {
            int nCount = 0;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VATReports oItem = new VATReports();

                    if (reader["Sales_2017"] != DBNull.Value)
                        oItem.Sales_2017 = Convert.ToDouble(reader["Sales_2017"]);
                    else oItem.Sales_2017 = -1;

                    if (reader["VAT_2017"] != DBNull.Value)
                        oItem.VAT_2017 = Convert.ToDouble(reader["VAT_2017"]);
                    else oItem.VAT_2017 = -1;

                    if (reader["Sales_2016"] != DBNull.Value)
                        oItem.Sales_2016 = Convert.ToDouble(reader["Sales_2016"]);
                    else oItem.Sales_2016 = -1;

                    if (reader["VAT_2016"] != DBNull.Value)
                        oItem.VAT_2016 = Convert.ToDouble(reader["VAT_2016"]);
                    else oItem.VAT_2016 = -1;

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

        public void FromDataSetVATComparison(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    VATReports oItem = new VATReports();

                    oItem.Sales_2017 = (double)oRow["Sales_2017"];
                    oItem.VAT_2017 = (double)oRow["VAT_2017"];
                    oItem.Sales_2016 = (double)oRow["Sales_2016"];
                    oItem.VAT_2016 = (double)oRow["VAT_2016"];


                    InnerList.Add(oItem);
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
