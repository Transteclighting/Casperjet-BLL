// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 24, 2011
// Time :  10:00 AM
// Description: Class for Commercial Invoice.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;


namespace CJ.Class
{
    public class CommercialInvoiceItem
    {
        private int _nProductID;
        private ProductDetail _oProductDetail;
        private int _nCIID;
        private long _lQty;        
        private double _fUnitValue;

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public ProductDetail ProductDetail
        {
            get
            {
                if (_oProductDetail == null)
                {
                    _oProductDetail = new ProductDetail();
                }
                return _oProductDetail;
            }
        }

        public int CIID
        {
            get { return _nCIID; }
            set { _nCIID = value; }
        }
      
        public long Qty
        {
            get { return _lQty; }
            set { _lQty = value; }
        }
        public double UnitValue
        {
            get { return _fUnitValue; }
            set { _fUnitValue = value; }
        }

        public void Insert(int nCIID,int nPOID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_CommercialInvoiceDetail (CIID,POID, ProductID,Qty, UnitPrice) VALUES (?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CIID", nCIID);
                cmd.Parameters.AddWithValue("POID", nPOID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _lQty);
                cmd.Parameters.AddWithValue("UnitPrice", _fUnitValue);               

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void Delete(int nCIID, int nPOID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_CommercialInvoiceDetail Where POID=? and CIID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("POID", nPOID);
                cmd.Parameters.AddWithValue("CIID", nCIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }

    public class CommercialInvoice : CollectionBase
    {
        private int _nCIID;
        private int _nPOID;
        private string _sCINo;
        private int _nStatus;
        private object _dCIDate;
        private object _dSPortLeaveDate;
        private object _dRPortArrivalDate;
        private object _dReceviedDate;
        private string _sRemarks;
        private double _DocValue;
        private double _DutyAmount;
        private object _dDocDate;
        private object _dDutyDate;
        private double _InvoiceValue;
        private bool _bFlag;

        public CommercialInvoiceItem this[int i]
        {
            get { return (CommercialInvoiceItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CommercialInvoiceItem oCommercialInvoiceItem)
        {
            InnerList.Add(oCommercialInvoiceItem);
        }

        public int CIID
        {
            get { return _nCIID; }
            set { _nCIID = value; }
        }
        public int POID
        {
            get { return _nPOID; }
            set { _nPOID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public double InvoiceValue
        {
            get { return _InvoiceValue; }
            set { _InvoiceValue = value; }
        }
        public string CINo
        {
            get { return _sCINo; }
            set { _sCINo = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public object CIDate
        {
            get { return _dCIDate; }
            set { _dCIDate = value; }
        }
        public object SPortLeaveDate
        {
            get { return _dSPortLeaveDate; }
            set { _dSPortLeaveDate = value; }
        }
        public object RPortArrivalDate
        {
            get { return _dRPortArrivalDate; }
            set { _dRPortArrivalDate = value; }

        }
        public object ReceviedDate
        {
            get { return _dReceviedDate; }
            set { _dReceviedDate = value; }
        }
        public double DocValue
        {
            get { return _DocValue; }
            set { _DocValue = value; }
        }
        public double DutyAmount
        {
            get { return _DutyAmount; }
            set { _DutyAmount = value; }
        }
        public object DocDate
        {
            get { return _dDocDate; }
            set { _dDocDate = value; }
        }    
        public object DutyDate
        {
            get { return _dDutyDate; }
            set { _dDutyDate = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void Insert()
        {
            int nMaxCIID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([CIID]) FROM t_CommercialInvoice";
                cmd.CommandText = sSql;
                object maxCIID = cmd.ExecuteScalar();
                if (maxCIID == DBNull.Value)
                {
                    nMaxCIID = 1;
                }
                else
                {
                    nMaxCIID = Convert.ToInt16(maxCIID) + 1;

                }
                _nCIID = nMaxCIID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CommercialInvoice VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CIID", _nCIID);
                cmd.Parameters.AddWithValue("POID", _nPOID);
                cmd.Parameters.AddWithValue("CINo", _sCINo);

                if (_dCIDate != null) cmd.Parameters.AddWithValue("CIDate", Convert.ToDateTime(_dCIDate));
                else cmd.Parameters.AddWithValue("CIDate", null);

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("InvoiceValue", _InvoiceValue);

                if (_dSPortLeaveDate != null) cmd.Parameters.AddWithValue("SPortLeaveDate", Convert.ToDateTime(_dSPortLeaveDate));
                else cmd.Parameters.AddWithValue("SPortLeaveDate", null);

                if (_dRPortArrivalDate != null) cmd.Parameters.AddWithValue("RPortArrivalDate", Convert.ToDateTime(_dRPortArrivalDate));
                else cmd.Parameters.AddWithValue("RPortArrivalDate", null);

                if (_dReceviedDate != null) cmd.Parameters.AddWithValue("ReceviedDate", Convert.ToDateTime(_dReceviedDate));
                else cmd.Parameters.AddWithValue("ReceviedDate", null);

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                if (_dDocDate != null) cmd.Parameters.AddWithValue("DocDate", Convert.ToDateTime(_dDocDate));
                else cmd.Parameters.AddWithValue("DocDate", null);

                if (_dDutyDate != null) cmd.Parameters.AddWithValue("DutyDate", Convert.ToDateTime(_dDutyDate));
                else cmd.Parameters.AddWithValue("DutyDate", null);               

                cmd.Parameters.AddWithValue("DocValue", _DocValue);
                cmd.Parameters.AddWithValue("DutyAmount", _DutyAmount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (CommercialInvoiceItem oItem in this)
                {
                    oItem.Insert(_nCIID,_nPOID);
                }               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update()
        {
            int nCount = 1;
            OleDbCommand cmd = DBController.Instance.GetCommand();            
            try
            {
                cmd.CommandText = "UPDATE t_CommercialInvoice SET CINo = ?, CIDate = ?, Status = ?,InvoiceValue=?, SPortLeaveDate=?,RPortArrivalDate=?,ReceviedDate=?,Remarks=?,DocDate=?,DutyDate =?,DocValue=?,DutyAmount=? WHERE CIID =? and POID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CINo", _sCINo);

                if (_dCIDate != null) cmd.Parameters.AddWithValue("CIDate", Convert.ToDateTime(_dCIDate));
                else cmd.Parameters.AddWithValue("CIDate", null);

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("InvoiceValue", _InvoiceValue);

                if (_dSPortLeaveDate != null) cmd.Parameters.AddWithValue("SPortLeaveDate", Convert.ToDateTime(_dSPortLeaveDate));
                else cmd.Parameters.AddWithValue("SPortLeaveDate", null);

                if (_dRPortArrivalDate != null) cmd.Parameters.AddWithValue("RPortArrivalDate", Convert.ToDateTime(_dRPortArrivalDate));
                else cmd.Parameters.AddWithValue("RPortArrivalDate", null);

                if (_dReceviedDate != null) cmd.Parameters.AddWithValue("ReceviedDate", Convert.ToDateTime(_dReceviedDate));
                else cmd.Parameters.AddWithValue("ReceviedDate", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                
                if (_dDocDate != null) cmd.Parameters.AddWithValue("DocDate", Convert.ToDateTime(_dDocDate));
                else cmd.Parameters.AddWithValue("DocDate", null);

                if (_dDutyDate != null) cmd.Parameters.AddWithValue("DutyDate", Convert.ToDateTime(_dDutyDate));
                else cmd.Parameters.AddWithValue("DutyDate", null);

                cmd.Parameters.AddWithValue("DocValue", _DocValue);
                cmd.Parameters.AddWithValue("DutyAmount", _DutyAmount);

                cmd.Parameters.AddWithValue("CIID", _nCIID);
                cmd.Parameters.AddWithValue("POID", _nPOID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (CommercialInvoiceItem oItem in this)
                {
                    if (nCount == 1)
                    {
                        oItem.Delete(_nCIID,_nPOID);
                        nCount++;
                    }
                    oItem.Insert(_nCIID, _nPOID);
                }
              
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {          
            OleDbCommand cmd = DBController.Instance.GetCommand();
     
            try
            {
                cmd.CommandText = "UPDATE t_CommercialInvoice SET Status = ? WHERE CIID =? and POID = ?";
                cmd.CommandType = CommandType.Text;              

                cmd.Parameters.AddWithValue("Status", _nStatus);               

                cmd.Parameters.AddWithValue("CIID", _nCIID);
                cmd.Parameters.AddWithValue("POID", _nPOID);

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
            string sSql = "SELECT * FROM t_CommercialInvoice WHERE CIID = ?";
            cmd.Parameters.AddWithValue("CIID", _nCIID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                 
                    _nCIID = int.Parse(reader["CIID"].ToString());
                    _nPOID = int.Parse(reader["POID"].ToString());                
                 
                }
                reader.Close();
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_CommercialInvoiceDetail where CIID=? and POID=?";
                cmd.Parameters.AddWithValue("CIID", _nCIID);
                cmd.Parameters.AddWithValue("POID", _nPOID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CommercialInvoiceItem oItem = new CommercialInvoiceItem();
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());                    
                    oItem.Qty = Convert.ToInt64(reader["Qty"].ToString());                    
                    oItem.UnitValue = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oItem.ProductDetail.ProductID = oItem.ProductID;
                    oItem.ProductDetail.Refresh();
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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                CommercialInvoiceItem oItem = new CommercialInvoiceItem();
                oItem.Delete(_nCIID, _nPOID);
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_CommercialInvoice Where CIID=? and POID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CIID", _nCIID);
                cmd.Parameters.AddWithValue("POID", _nPOID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool CheckPOID(int nPOID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select * from  t_CommercialInvoice Where POID=? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("POID", nPOID);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheackCINo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CommercialInvoice where CINo =?";
                cmd.Parameters.AddWithValue("CINo", _sCINo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;
        }
    }

    public class CommercialInvoices : CollectionBase
    {

        public CommercialInvoice this[int i]
        {
            get { return (CommercialInvoice)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CommercialInvoice oCommercialInvoice)
        {
            InnerList.Add(oCommercialInvoice);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate,string sPONo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CommercialInvoice WHERE CIDate BETWEEN '" + dFromDate + "'AND '" + dToDate + "'";

            if (sPONo != "")
            {
                sPONo = "%" + sPONo + "%";
                sSql = sSql + "AND CINo LIKE '" + sPONo + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CommercialInvoice oCommercialInvoice = new CommercialInvoice();

                    oCommercialInvoice.CIID = int.Parse(reader["CIID"].ToString());
                    oCommercialInvoice.POID = int.Parse(reader["POID"].ToString());
                    oCommercialInvoice.CINo = (string)reader["CINo"];
                    oCommercialInvoice.CIDate = (object)reader["CIDate"];  
                    oCommercialInvoice.Status = int.Parse(reader["Status"].ToString());
                    oCommercialInvoice.Remarks = reader["Remarks"].ToString();

                    oCommercialInvoice.InvoiceValue = Convert.ToDouble(reader["InvoiceValue"].ToString());
                    oCommercialInvoice.SPortLeaveDate = (object)reader["SPortLeaveDate"];
                    oCommercialInvoice.RPortArrivalDate = (object)reader["RPortArrivalDate"];
                    oCommercialInvoice.ReceviedDate = (object)reader["ReceviedDate"];
                    oCommercialInvoice.DocDate = (object)reader["DocDate"];
                    oCommercialInvoice.DutyDate = (object)reader["DutyDate"];

                    if (reader["DocValue"] == DBNull.Value) oCommercialInvoice.DocValue = 0;
                    else oCommercialInvoice.DocValue = Convert.ToDouble(reader["DocValue"].ToString());

                    if (reader["DutyAmount"] == DBNull.Value) oCommercialInvoice.DutyAmount = 0;
                    else oCommercialInvoice.DutyAmount = Convert.ToDouble(reader["DutyAmount"].ToString()); 

                    //oCommercialInvoice.Refresh(); 
                    InnerList.Add(oCommercialInvoice);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public void RefreshFOrGRD()
        {
            InnerList.Clear();
            string sStatus = ((int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_PORT).ToString()+ "," + ((int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_WH_PARTIAL).ToString();
            CommercialInvoice oCommercialInvoice;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CommercialInvoice WHERE Status in (" + sStatus + ")";
           
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCommercialInvoice = new CommercialInvoice();
                    oCommercialInvoice.CIID = int.Parse(reader["CIID"].ToString());
                    oCommercialInvoice.POID = int.Parse(reader["POID"].ToString());
                    oCommercialInvoice.CINo = (string)reader["CINo"];
                    oCommercialInvoice.CIDate = (object)reader["CIDate"];                
                    InnerList.Add(oCommercialInvoice);
                }

                reader.Close();

                oCommercialInvoice = new CommercialInvoice();

                oCommercialInvoice.CIID = -1;               
                oCommercialInvoice.CINo = "<Select CI Number>";
            

                InnerList.Add(oCommercialInvoice);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
}
