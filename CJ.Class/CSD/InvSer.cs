
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Apr 25, 2012
// Time :  4:04 PM
// Description: Class for Invoice Search from Cassiopeia_HO Data.
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


namespace CJ.Class
{
    public class InvSer
    {
        private string _sInvoiceNo;
        private Object _dInvoiceDate;
        private string _sOutletCode;
        private string _sProductCode;
        private string _sProductName;
        private string _sASG;
        private string _sBrand;
        private Object _sBarCodeSL;
        private string _sSRCode;
        private Object _sCustomerName;
        private Object _sAddress;
        private Object _sMobileNo;

        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        /// <summary>
        /// Get set property for InvoiceDate
        /// </summary>
        public Object InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        /// <summary>
        /// Get set property for OutletCode
        /// </summary>
        public string OutletCode
        {
            get { return _sOutletCode; }
            set { _sOutletCode = value; }
        }
        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        /// <summary>
        /// Get set property for ASG
        /// </summary>
        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value; }
        }
        /// <summary>
        /// Get set property for Brand
        /// </summary>
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value; }
        }
        /// <summary>
        /// Get set property for BarCodeSL
        /// </summary>
        public Object BarCodeSL
        {
            get { return _sBarCodeSL; }
            set { _sBarCodeSL = value; }
        }
        /// <summary>
        /// Get set property for SRCode
        /// </summary>
        public string SRCode
        {
            get { return _sSRCode; }
            set { _sSRCode = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public Object CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        /// <summary>
        /// Get set property for Address
        /// </summary>
        public Object Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        /// <summary>
        /// Get set property for MobileNo
        /// </summary>
        public Object MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }

    }
    public class InvSers : CollectionBase
    {
        //public InvSer this[int i]
        //{
        //    get { return (InvSer)InnerList[i]; }
        //    set { InnerList[i] = value; }
        //}

        //public void Add(InvSer oInvSery)
        //{
        //    InnerList.Add(oInvSer);
        //}
        public void Refresh(DateTime dtFromDate, DateTime dtToDate, String txtBarcode, String txtContactNo, String txtProductName, String txtCustomer, String txtAddress, String txtInvoiceNo, String txtProductCode, String txtOutletcode)//String txtReplaceID
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select InvoiceNo, InvoiceDate, OutletCode, ProductCode, ProductName, BarCodeSL, CustomerName,Address,MobileNo " +
                    "From  " +
                    "( " +
                    "Select I.TranNo InvoiceNo,I.TranDate InvoiceDate, S.Code OutletCode," +
                    "P.Code ProductCode, P.Name ProductName," +
                    "II.BarCodeOrMSlNo BarCodeSL, C.Name CustomerName, C.Address Address, C.MobileNo MobileNo " +
                    "from Cassiopeia_HO.dbo.InvoiceItem II " +
                    "INNER JOIN Cassiopeia_HO.dbo.Product P " +
                    "ON P.ProductID=II.ProductID " +
                    "INNER JOIN (Select * from Cassiopeia_HO.dbo.Invoice Where CustomerTypeID IS NOT NULL) I " +
                    "ON I.InvoiceID=II.InvoiceID AND I.ShowroomID=II.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Showroom S " +
                    "ON S.ShowroomID=I.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Customer C " +
                    "ON C.ShowroomID=I.ShowroomID AND C.CustomerID=I.CustomerID " +

                    "Union All " +

                    "Select I.TranNo InvoiceNo,I.TranDate InvoiceDate, S.Code OutletCode, "+
                    "P.Code ProductCode, P.Name ProductName, "+
                    "II.BarCodeOrMSlNo BarCodeSL, C.Name CustomerName, C.Address Address, C.MobileNo MobileNo  "+
                    "from Cassiopeia_HO.dbo.InvoiceItem II  "+
                    "INNER JOIN Cassiopeia_HO.dbo.Product P  "+
                    "ON P.ProductID=II.ProductID  "+
                    "INNER JOIN (Select * from Cassiopeia_HO.dbo.Invoice Where CustomerTypeID IS NULL) I  "+
                    "ON I.InvoiceID=II.InvoiceID AND I.ShowroomID=II.ShowroomID  "+
                    "INNER JOIN Cassiopeia_HO.dbo.Showroom S  "+
                    "ON S.ShowroomID=I.ShowroomID  "+
                    "INNER JOIN Cassiopeia_HO.dbo.CLPCustomer C  "+
                    "ON C.ShowroomID=I.ShowroomID AND C.CLPCustomerID=I.CustomerID "+

                    "Union All " +

                    "Select I.TranNo InvoiceNo,I.TranDate InvoiceDate, S.Code OutletCode,P.Code ProductCode, P.Name ProductName," +
                    "II.BarCodeOrMSlNo BarCodeSL, C.Name CustomerName, C.Address, C.MobileNo " +
                    "from Cassiopeia_HO.dbo.InvoiceItem II " +
                    "INNER JOIN Cassiopeia_HO.dbo.Product P " +
                    "ON P.ProductID=II.ProductID " +
                    "INNER JOIN (Select * from Cassiopeia_HO.dbo.Invoice Where CustomerID IS NULL AND CLPCustomerID IS NOT NULL)I " +
                    "ON I.InvoiceID=II.InvoiceID AND I.ShowroomID=II.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Showroom S " +
                    "ON S.ShowroomID=I.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Customer C " +
                    "ON C.ShowroomID=I.ShowroomID AND C.CustomerID=I.CLPCustomerID " +

                    "UNION ALL " +

                    "Select I.TranNo InvoiceNo,I.TranDate InvoiceDate, S.Code OutletCode,P.Code ProductCode, P.Name ProductName," +
                    "II.BarCodeOrMSlNo BarCodeSL, C.Name CustomerName, C.Address, C.MobileNo " +
                    "from Cassiopeia_HO.dbo.InvoiceItem II " +
                    "INNER JOIN Cassiopeia_HO.dbo.Product P " +
                    "ON P.ProductID=II.ProductID " +
                    "INNER JOIN (Select * from Cassiopeia_HO.dbo.Invoice Where CustomerID IS NULL AND CLPCustomerID IS NULL)I " +
                    "ON I.InvoiceID=II.InvoiceID AND I.ShowroomID=II.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Showroom S " +
                    "ON S.ShowroomID=I.ShowroomID " +
                    "Left Outer JOIN Cassiopeia_HO.dbo.Customer C " +
                    "ON C.ShowroomID=I.ShowroomID AND C.CustomerID=I.CLPCustomerID " +
                    ")F Where InvoiceDate BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND InvoiceDate < '" + dtToDate + "'";


            if (txtBarcode != "")
            {
                txtBarcode = "%" + txtBarcode + "%";
                sSql = sSql + " AND BarCodeSL LIKE '" + txtBarcode + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND MobileNo LIKE '" + txtContactNo + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + txtProductName + "'";
            }
            if (txtCustomer != "")
            {
                txtCustomer = "%" + txtCustomer + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomer + "'";
            }
            if (txtAddress != "")
            {
                txtAddress = "%" + txtAddress + "%";
                sSql = sSql + " AND Address LIKE '" + txtAddress + "'";
            }
            if (txtInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo ='" + txtInvoiceNo + "'";
            }
            if (txtProductCode != "")
            {
                sSql = sSql + " AND ProductCode ='" + txtProductCode + "'";
            }
            if (txtOutletcode != "")
            {
                sSql = sSql + " AND OutletCode ='" + txtOutletcode + "'";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvSer oInvSer = new InvSer();
                    oInvSer.InvoiceNo = (string)reader["InvoiceNo"];
                    oInvSer.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oInvSer.OutletCode = (string)reader["OutletCode"];
                    oInvSer.ProductCode = (string)reader["ProductCode"];
                    oInvSer.ProductName = (string)reader["ProductName"];
                    oInvSer.BarCodeSL = (Object)reader["BarCodeSL"];
                    oInvSer.CustomerName = (Object)reader["CustomerName"];
                    oInvSer.Address = (Object)reader["Address"];
                    oInvSer.MobileNo = (Object)reader["MobileNo"];
                    //oInvSer.ASG = (string)reader["ASG"];
                    //oInvSer.Brand = (string)reader["Brand"];
                    
                    //oInvSer.SRCode = (string)reader["SRCode"];
                    //oInvSer.Address = (string)reader["Address"];
                    //oInvSer.MobileNo = (string)reader["MobileNo"];
                            
                    InnerList.Add(oInvSer);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(String txtBarcode, String txtContactNo, String txtProductName, String txtCustomer, String txtAddress, String txtInvoiceNo, String txtProductCode, String txtOutletcode)//String txtReplaceID
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceNo, InvoiceDate, OutletCode, ProductCode, ProductName, BarCodeSL, CustomerName,Address,MobileNo " +
                    "From  " +
                    "( " +
                    "Select I.TranNo InvoiceNo,I.TranDate InvoiceDate, S.Code OutletCode," +
                    "P.Code ProductCode, P.Name ProductName," +
                    "II.BarCodeOrMSlNo BarCodeSL, C.Name CustomerName, C.Address Address, C.MobileNo MobileNo " +
                    "from Cassiopeia_HO.dbo.InvoiceItem II " +
                    "INNER JOIN Cassiopeia_HO.dbo.Product P " +
                    "ON P.ProductID=II.ProductID " +
                    "INNER JOIN (Select * from Cassiopeia_HO.dbo.Invoice Where CustomerTypeID IS NOT NULL) I " +
                    "ON I.InvoiceID=II.InvoiceID AND I.ShowroomID=II.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Showroom S " +
                    "ON S.ShowroomID=I.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Customer C " +
                    "ON C.ShowroomID=I.ShowroomID AND C.CustomerID=I.CustomerID " +

                    "Union All " +

                    "Select I.TranNo InvoiceNo,I.TranDate InvoiceDate, S.Code OutletCode, " +
                    "P.Code ProductCode, P.Name ProductName, " +
                    "II.BarCodeOrMSlNo BarCodeSL, C.Name CustomerName, C.Address Address, C.MobileNo MobileNo  " +
                    "from Cassiopeia_HO.dbo.InvoiceItem II  " +
                    "INNER JOIN Cassiopeia_HO.dbo.Product P  " +
                    "ON P.ProductID=II.ProductID  " +
                    "INNER JOIN (Select * from Cassiopeia_HO.dbo.Invoice Where CustomerTypeID IS NULL) I  " +
                    "ON I.InvoiceID=II.InvoiceID AND I.ShowroomID=II.ShowroomID  " +
                    "INNER JOIN Cassiopeia_HO.dbo.Showroom S  " +
                    "ON S.ShowroomID=I.ShowroomID  " +
                    "INNER JOIN Cassiopeia_HO.dbo.CLPCustomer C  " +
                    "ON C.ShowroomID=I.ShowroomID AND C.CLPCustomerID=I.CustomerID " +

                    "Union All " +

                    "Select I.TranNo InvoiceNo,I.TranDate InvoiceDate, S.Code OutletCode,P.Code ProductCode, P.Name ProductName," +
                    "II.BarCodeOrMSlNo BarCodeSL, C.Name CustomerName, C.Address, C.MobileNo " +
                    "from Cassiopeia_HO.dbo.InvoiceItem II " +
                    "INNER JOIN Cassiopeia_HO.dbo.Product P " +
                    "ON P.ProductID=II.ProductID " +
                    "INNER JOIN (Select * from Cassiopeia_HO.dbo.Invoice Where CustomerID IS NULL AND CLPCustomerID IS NOT NULL)I " +
                    "ON I.InvoiceID=II.InvoiceID AND I.ShowroomID=II.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Showroom S " +
                    "ON S.ShowroomID=I.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Customer C " +
                    "ON C.ShowroomID=I.ShowroomID AND C.CustomerID=I.CLPCustomerID " +

                    "UNION ALL " +

                    "Select I.TranNo InvoiceNo,I.TranDate InvoiceDate, S.Code OutletCode,P.Code ProductCode, P.Name ProductName," +
                    "II.BarCodeOrMSlNo BarCodeSL, C.Name CustomerName, C.Address, C.MobileNo " +
                    "from Cassiopeia_HO.dbo.InvoiceItem II " +
                    "INNER JOIN Cassiopeia_HO.dbo.Product P " +
                    "ON P.ProductID=II.ProductID " +
                    "INNER JOIN (Select * from Cassiopeia_HO.dbo.Invoice Where CustomerID IS NULL AND CLPCustomerID IS NULL)I " +
                    "ON I.InvoiceID=II.InvoiceID AND I.ShowroomID=II.ShowroomID " +
                    "INNER JOIN Cassiopeia_HO.dbo.Showroom S " +
                    "ON S.ShowroomID=I.ShowroomID " +
                    "Left Outer JOIN Cassiopeia_HO.dbo.Customer C " +
                    "ON C.ShowroomID=I.ShowroomID AND C.CustomerID=I.CLPCustomerID " +
                    ")F Where InvoiceNo <> '' "; 

   
            if (txtBarcode != "")
            {
                txtBarcode = "%" + txtBarcode + "%";
                sSql = sSql + " AND BarCodeSL LIKE '" + txtBarcode + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND MobileNo LIKE '" + txtContactNo + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + txtProductName + "'";
            }
            if (txtCustomer != "")
            {
                txtCustomer = "%" + txtCustomer + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomer + "'";
            }
            if (txtAddress != "")
            {
                txtAddress = "%" + txtAddress + "%";
                sSql = sSql + " AND Address LIKE '" + txtAddress + "'";
            }
            if (txtInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo ='" + txtInvoiceNo + "'";
            }
            if (txtProductCode != "")
            {
                sSql = sSql + " AND ProductCode ='" + txtProductCode + "'";
            }
            if (txtOutletcode != "")
            {
                sSql = sSql + " AND OutletCode ='" + txtOutletcode + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvSer oInvSer = new InvSer();
                    oInvSer.InvoiceNo = (string)reader["InvoiceNo"];
                    oInvSer.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oInvSer.OutletCode = (string)reader["OutletCode"];
                    oInvSer.ProductCode = (string)reader["ProductCode"];
                    oInvSer.ProductName = (string)reader["ProductName"];
                    oInvSer.BarCodeSL = (Object)reader["BarCodeSL"];
                    oInvSer.CustomerName = (Object)reader["CustomerName"];
                    oInvSer.Address = (Object)reader["Address"];
                    oInvSer.MobileNo = (Object)reader["MobileNo"];
                    //oInvSer.ASG = (string)reader["ASG"];
                    //oInvSer.Brand = (string)reader["Brand"];

                    //oInvSer.SRCode = (string)reader["SRCode"];
                    //oInvSer.Address = (string)reader["Address"];
                    //oInvSer.MobileNo = (string)reader["MobileNo"];

                    InnerList.Add(oInvSer);
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
