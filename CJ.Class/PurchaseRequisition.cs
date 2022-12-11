// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 11, 2011
// Time :  10:00 AM
// Description: Class for Purchase Requisition.
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

    public class PurchaseRequisitionItem
    {
        private int _nProductID;

        private ProductDetail _oProductDetail;
        private long _lApprovedQty;
        private long _lLCQty;
        private long _lReceivedQty;
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

        public void Insert(int nPOID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {                
                cmd.CommandText = "INSERT INTO t_PurchaseRequisitionDetail (POID, ProductID, ApprovedQty, LCQty, ReceivedQty, UnitValue) VALUES (?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("POID", nPOID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ApprovedQty", _lApprovedQty);
                cmd.Parameters.AddWithValue("LCQty", _lLCQty);
                cmd.Parameters.AddWithValue("ReceivedQty", _lReceivedQty);
                cmd.Parameters.AddWithValue("UnitValue", _fUnitValue);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void Delete(int nPOID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_PurchaseRequisitionDetail Where POID=? ";
                cmd.CommandType = CommandType.Text;              
                                
                cmd.Parameters.AddWithValue("POID", nPOID);               

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void Refresh(int nProductID, int nPOID)
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_PurchaseRequisitionDetail where ProductID=? and POID=?";
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("POID", nPOID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _lLCQty = Convert.ToInt64(reader["LCQty"].ToString());                    
                   
                }
                reader.Close();              

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }

    public class PurchaseRequisition:CollectionBase 
    {
        private int _nPOID;
        private int _nUserID;
        private int _nCount;
        private int _nStatus;
        private double _fLCValue;
        private double _fDocValue;
        private double _fDutyAmount;

        private int _nSupplierID;
        private Supplier _oSupplier;
        private User _oUser;

        private string _sPONo;
        private string _sPINo;
        private string _sLCNo;
        private string _sLCInvoiceNo;   
        private string _sRemarks;

        private object _dEntryDate;
        private object _dLCDate;
        private object _dLCInvoiceDate;
        private object _dDocDate;
        private object _dShipmentDate;
        private object _dDutyDate;
        private object _dReceivedDate;
        private object _dApprovalDate;
        private object _dPortArrivalDate;
        private object _dPIDate;

        private bool _bFlag;

        public int Count
        {
            get { return _nCount; }
            set { _nCount = value; }
        }
        public int POID
        {
            get { return _nPOID; }
            set { _nPOID = value; }
        }
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
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
        public Supplier Supplier
        {
            get
            {
                if (_oSupplier == null)
                {
                    _oSupplier = new Supplier();
                    _oSupplier.SupplierID = _nSupplierID;
                    _oSupplier.RefreshBySupplierID();
                }
                return _oSupplier;
            }
        }
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
            }
        }
        public double LCValue
        {
            get { return _fLCValue; }
            set { _fLCValue = value; }
        }
        public double DocValue
        {
            get { return _fDocValue; }
            set { _fDocValue = value; }
        }
        public double DutyAmount
        {
            get { return _fDutyAmount; }
            set { _fDutyAmount = value; }
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
        public object DocDate
        {
            get { return _dDocDate; }
            set { _dDocDate = value; }
        }
        public object ShipmentDate
        {
            get { return _dShipmentDate; }
            set { _dShipmentDate = value; }
        }
        public object DutyDate
        {
            get { return _dDutyDate; }
            set { _dDutyDate = value; }
        }
        public object PIDate
        {
            get { return _dPIDate; }
            set { _dPIDate = value; }
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
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public PurchaseRequisitionItem this[int i]
        {
            get { return (PurchaseRequisitionItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(PurchaseRequisitionItem oPurchaseRequisitionItem)
        {
            InnerList.Add(oPurchaseRequisitionItem);
        }

        public void Insert()
        {
            int nMaxPOID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([POID]) FROM t_PurchaseRequisition";
                cmd.CommandText = sSql;
                object maxPOID = cmd.ExecuteScalar();
                if (maxPOID == DBNull.Value)
                {
                    nMaxPOID = 1;
                }
                else
                {
                    nMaxPOID = Convert.ToInt16(maxPOID) + 1;

                }
                _nPOID = nMaxPOID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_PurchaseRequisition VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("POID", _nPOID);
                cmd.Parameters.AddWithValue("PONo", _sPONo);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);

                if(_dApprovalDate!=null) cmd.Parameters.AddWithValue("ApprovalDate", Convert.ToDateTime(_dApprovalDate));
                else cmd.Parameters.AddWithValue("ApprovalDate", null);

                if (_dLCDate != null) cmd.Parameters.AddWithValue("LCDate",Convert.ToDateTime( _dLCDate));
                else cmd.Parameters.AddWithValue("LCDate", null);

                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCValue", _fLCValue);

                if (_dShipmentDate != null) cmd.Parameters.AddWithValue("ShipmentDate",Convert.ToDateTime( _dShipmentDate));
                else cmd.Parameters.AddWithValue("ShipmentDate", null);

                if (_dPortArrivalDate != null) cmd.Parameters.AddWithValue("PortArrivalDate",Convert.ToDateTime( _dPortArrivalDate));
                else cmd.Parameters.AddWithValue("PortArrivalDate",null);

                if (_dReceivedDate != null) cmd.Parameters.AddWithValue("ReceivedDate",Convert.ToDateTime( _dReceivedDate));
                else  cmd.Parameters.AddWithValue("ReceivedDate", null);

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("LCInvoiceNo", _sLCInvoiceNo);

                if (_dLCInvoiceDate != null) cmd.Parameters.AddWithValue("LCInvoiceDate",Convert.ToDateTime( _dLCInvoiceDate));
                else cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                if (_dDocDate != null) cmd.Parameters.AddWithValue("DocDate", Convert.ToDateTime(_dDocDate));
                else cmd.Parameters.AddWithValue("DocDate", null);

                cmd.Parameters.AddWithValue("PINo", _sPINo);

                if (_dDutyDate != null) cmd.Parameters.AddWithValue("DutyDate", Convert.ToDateTime(_dDutyDate));
                else cmd.Parameters.AddWithValue("DutyDate", null);

                if (_dPIDate != null) cmd.Parameters.AddWithValue("PIDate", Convert.ToDateTime(_dPIDate));
                else cmd.Parameters.AddWithValue("PIDate", null);

                cmd.Parameters.AddWithValue("DocValue", _fDocValue);
                cmd.Parameters.AddWithValue("DutyAmount", _fDutyAmount);

                AppLogger.LogInfo("Inserting PurchaseRequisition Information.\n");
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach(PurchaseRequisitionItem oItem in this)
                {
                    oItem.Insert(_nPOID); 
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
                cmd.CommandText = "UPDATE t_PurchaseRequisition SET PONo = ?, SupplierID = ?, ApprovalDate = ?, LCDate = ?, LCNo = ?, " +
                    "LCValue = ?, ShipmentDate = ?, PortArrivalDate = ?, ReceivedDate = ?, Status = ?, UpdateUserID = ? , "+
                    " UpdateDate=?, Remarks=?, LCInvoiceNo =?, LCInvoiceDate=?, DocDate=?, PINo=?, DutyDate =?,PIDAte=?,DocValue=?,DutyAmount=? WHERE POID = ?";
              
                
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("PONo", _sPONo);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);               

                if (_dApprovalDate != null) cmd.Parameters.AddWithValue("ApprovalDate", Convert.ToDateTime(_dApprovalDate));
                else cmd.Parameters.AddWithValue("ApprovalDate", null);

                if (_dLCDate != null) cmd.Parameters.AddWithValue("LCDate", Convert.ToDateTime(_dLCDate));
                else cmd.Parameters.AddWithValue("LCDate", null);

                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCValue", _fLCValue);

                if (_dShipmentDate != null) cmd.Parameters.AddWithValue("ShipmentDate", Convert.ToDateTime(_dShipmentDate));
                else cmd.Parameters.AddWithValue("ShipmentDate", null);

                if (_dPortArrivalDate != null) cmd.Parameters.AddWithValue("PortArrivalDate", Convert.ToDateTime(_dPortArrivalDate));
                else cmd.Parameters.AddWithValue("PortArrivalDate", null);

                if (_dReceivedDate != null) cmd.Parameters.AddWithValue("ReceivedDate", Convert.ToDateTime(_dReceivedDate));
                else cmd.Parameters.AddWithValue("ReceivedDate", null);

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("LCInvoiceNo", _sLCInvoiceNo);

                if (_dLCInvoiceDate != null) cmd.Parameters.AddWithValue("LCInvoiceDate", Convert.ToDateTime(_dLCInvoiceDate));
                else cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                if (_dDocDate != null) cmd.Parameters.AddWithValue("DocDate", Convert.ToDateTime(_dDocDate));
                else cmd.Parameters.AddWithValue("DocDate", null);

                cmd.Parameters.AddWithValue("PINo", _sPINo);

                if (_dDutyDate != null) cmd.Parameters.AddWithValue("DutyDate", Convert.ToDateTime(_dDutyDate));
                else cmd.Parameters.AddWithValue("DutyDate", null);

                if (_dPIDate != null) cmd.Parameters.AddWithValue("PIDate", Convert.ToDateTime(_dPIDate));
                else cmd.Parameters.AddWithValue("PIDate", null);

                cmd.Parameters.AddWithValue("DocValue", _fDocValue);
                cmd.Parameters.AddWithValue("DutyAmount", _fDutyAmount);

                cmd.Parameters.AddWithValue("POID", _nPOID);
                AppLogger.LogInfo("Upadte PurchaseRequisition Information.\n");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
              
                foreach (PurchaseRequisitionItem oItem in this)
                {
                    if (nCount == 1)
                    {
                        oItem.Delete(_nPOID);
                        nCount++;
                    }
                    oItem.Insert(_nPOID);
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
                cmd.CommandText = "UPDATE t_PurchaseRequisition SET  Status = ? WHERE POID = ?";

                cmd.CommandType = CommandType.Text;              

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("POID", _nPOID);
             
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

            try
            {
                PurchaseRequisitionItem oItem = new PurchaseRequisitionItem();
                oItem.Delete(_nPOID);

                cmd.CommandText = "Delete from  t_PurchaseRequisition Where POID=? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("POID", _nPOID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
              
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "Delete from  t_CommercialInvoiceDetail Where POID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("POID", _nPOID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_CommercialInvoice Where POID=? ";
                cmd.CommandType = CommandType.Text;

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
            try
            {
                cmd.CommandText = "SELECT * FROM t_PurchaseRequisition where POID=? ";
                cmd.Parameters.AddWithValue("POID", _nPOID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sPONo = reader["PONo"].ToString();
                  
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
                cmd.CommandText = "SELECT * FROM t_PurchaseRequisitionDetail where POID=? ";
                cmd.Parameters.AddWithValue("POID", _nPOID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseRequisitionItem oItem = new PurchaseRequisitionItem();
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ApprovedQty = Convert.ToInt64(reader["ApprovedQty"].ToString());
                    oItem.LCQty = Convert.ToInt64(reader["LCQty"].ToString());
                    oItem.ReceivedQty = Convert.ToInt64(reader["ReceivedQty"].ToString());
                    oItem.UnitValue = Convert.ToDouble(reader["UnitValue"].ToString());                   
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
        public void RefreshForCommercialInvoice()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT LCQty,ProductID FROM t_PurchaseRequisitionDetail where POID=? ";
                cmd.Parameters.AddWithValue("POID", _nPOID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseRequisitionItem oItem = new PurchaseRequisitionItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.LCQty = Convert.ToInt64(reader["LCQty"].ToString());
                   
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

        public void RefreshSupplier()
        {
            Supplier.SupplierID = _nSupplierID;
            Supplier.RefreshBySupplierID();
        }

        public void RefreshUser()
        {
            User.UserId = _nUserID;
            User.RefreshByUserID();
        }

        public void CheackPONo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_PurchaseRequisition where PONo =?";
                cmd.Parameters.AddWithValue("PONo", _sPONo);
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
            if (nCount == 0) Flag = true;
            else Flag = false;
        }

        public void RefreshForCommercialInvoice(int nPOID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PurchaseRequisition WHERE POID=?";
            cmd.Parameters.AddWithValue("POID", nPOID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sPONo = reader["PONo"].ToString();
                    _nSupplierID = (int)reader["SupplierID"];

                    //_sRemarks = reader["Remarks"].ToString();
                    //_nUserID = (int)reader["EntryUserID"];
                    //_dEntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());

                    //_dApprovalDate = (object)reader["ApprovalDate"];
                    //_dPortArrivalDate = (object)reader["PortArrivalDate"];
                    //_dReceivedDate = (object)reader["ReceivedDate"];


                    _sLCNo = reader["LCNo"].ToString();
                    //_sLCInvoiceNo = reader["LCInvoiceNo"].ToString();
                    //_fLCValue = Convert.ToDouble(reader["LCValue"].ToString());
                    _sPINo = reader["PINo"].ToString();
                    //_dLCDate = (object)reader["LCDate"];
                    //_dLCInvoiceDate = (object)reader["LCInvoiceDate"];
                    //_dDocDate = (object)reader["DocDate"];
                    //_dShipmentDate = (object)reader["ShipmentDate"];
                    //_dDutyDate = (object)reader["DutyDate"];
                    //_dPIDate=(object)reader["PIDate"];

                    //if (reader["DocValue"] == DBNull.Value) _fDocValue = 0;
                    //else _fDocValue = Convert.ToDouble(reader["DocValue"].ToString());

                    //if (reader["DutyAmount"] == DBNull.Value) _fDutyAmount = 0;
                    //else _fDutyAmount= Convert.ToDouble(reader["DutyAmount"].ToString());                   


                    //RefreshForCommercialInvoice();
                    RefreshSupplier();
                    //RefreshUser();
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForGRD(int nPOID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PurchaseRequisition WHERE POID=?";
            cmd.Parameters.AddWithValue("POID", nPOID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nPOID = nPOID;
                    _nSupplierID = (int)reader["SupplierID"];
                    _sPONo = reader["PONo"].ToString();                  
                    _sLCNo = reader["LCNo"].ToString();               
                    _sPINo = reader["PINo"].ToString();
                    _dLCDate = (object)reader["LCDate"];
                    _dLCInvoiceDate = (object)reader["LCInvoiceDate"];
                   
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public int GetPONo(string sPONoType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nPONo = 0;
            string sSql = "SELECT count(PONo) FROM t_PurchaseRequisition where PONo like ";
            if (sPONoType == "Light") sSql = sSql + " 'L%'";
            if (sPONoType == "Electronics") sSql = sSql + "'E%'";
            if (sPONoType == "Mobile") sSql = sSql + "'M%'";

            try
            {
                cmd.CommandText = sSql;                
                cmd.CommandType = CommandType.Text;
                object PONo = cmd.ExecuteScalar();
                nPONo = Convert.ToInt16(PONo) + 1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

           
            return nPONo;
 
        }

    }

    public class PurchaseRequisitions : CollectionBase
    {

        public PurchaseRequisition this[int i]
        {
            get { return (PurchaseRequisition)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(PurchaseRequisition oPurchaseRequisition)
        {
            InnerList.Add(oPurchaseRequisition);
        }

        public void Refresh(DateTime dFromDate,DateTime dToDate, string sPOno, int nStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PurchaseRequisition WHERE EntryDate BETWEEN '" + dFromDate + "'AND '" + dToDate + "'";

            if (sPOno != "")
            {
                sPOno = "%" + sPOno + "%";
                sSql = sSql + "AND PONo like '" + sPOno + "'";
            }
            if (nStatus >-1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
          

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseRequisition oPurchaseRequisition = new PurchaseRequisition();

                    oPurchaseRequisition.POID = int.Parse(reader["POID"].ToString());
                    oPurchaseRequisition.PONo = reader["PONo"].ToString();                   
                    oPurchaseRequisition.SupplierID = (int)reader["SupplierID"];
                    oPurchaseRequisition.Status = int.Parse(reader["Status"].ToString());                    
                    oPurchaseRequisition.Remarks = reader["Remarks"].ToString();
                    oPurchaseRequisition.UserID = (int)reader["EntryUserID"];
                    oPurchaseRequisition.EntryDate = Convert.ToDateTime( reader["EntryDate"].ToString());

                    oPurchaseRequisition.ApprovalDate = (object)reader["ApprovalDate"];                   
                    oPurchaseRequisition.PortArrivalDate = (object)reader["PortArrivalDate"];
                    oPurchaseRequisition.ReceivedDate = (object)reader["ReceivedDate"];
                    

                    oPurchaseRequisition.LCNo = reader["LCNo"].ToString();
                    oPurchaseRequisition.LCInvoiceNo = reader["LCInvoiceNo"].ToString();
                    oPurchaseRequisition.LCValue = Convert.ToDouble( reader["LCValue"].ToString());                    
                    oPurchaseRequisition.LCDate = (object)reader["LCDate"];
                    oPurchaseRequisition.LCInvoiceDate = (object)reader["LCInvoiceDate"];
                    oPurchaseRequisition.DocDate = (object)reader["DocDate"];
                    oPurchaseRequisition.PINo = reader["PINo"].ToString();
                    oPurchaseRequisition.ShipmentDate = (object)reader["ShipmentDate"];
                    oPurchaseRequisition.DutyDate = (object)reader["DutyDate"];
                    oPurchaseRequisition.PIDate = (object)reader["PIDate"];

                    if (reader["DocValue"] == DBNull.Value) oPurchaseRequisition.DocValue = 0;
                    else oPurchaseRequisition.DocValue = Convert.ToDouble(reader["DocValue"].ToString());

                    if (reader["DutyAmount"] == DBNull.Value) oPurchaseRequisition.DutyAmount = 0;
                    else  oPurchaseRequisition.DutyAmount = Convert.ToDouble(reader["DutyAmount"].ToString());    

                    oPurchaseRequisition.RefreshItem();
                    oPurchaseRequisition.RefreshSupplier();
                    oPurchaseRequisition.RefreshUser();
                    
                    InnerList.Add(oPurchaseRequisition);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public PurchaseRequisitions RefreshForCommercialInvoice(DateTime dFromDate, DateTime dToDate, string sLCNo, int nStatus)
        {
             int nflag = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PurchaseRequisition WHERE EntryDate BETWEEN '" + dFromDate + "'AND '" + dToDate + "'";

            if (sLCNo != "")
            {
                sSql = sSql + "AND LCNo='" + sLCNo + "'";
            }
            if (nStatus != 7)
            {
                sSql = sSql + "AND Status='" + nStatus + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseRequisition oPurchaseRequisition = new PurchaseRequisition();

                    oPurchaseRequisition.POID = int.Parse(reader["POID"].ToString());
                    oPurchaseRequisition.PONo = reader["PONo"].ToString();
                    oPurchaseRequisition.SupplierID = (int)reader["SupplierID"];

                    sSql = "SELECT POID FROM t_CommercialInvoice WHERE POID='" + (int.Parse(reader["POID"].ToString()) + "'");
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader testreader = cmd.ExecuteReader();
                    while (testreader.Read())
                    {
                        nflag++;
                        oPurchaseRequisition.Count++;
                    }
                    if (nflag == 0)
                    {
                       oPurchaseRequisition.Status  = 0;
                       
                    }
                    else
                    {
                        oPurchaseRequisition.Status  = 1;
                        nflag = 0;
                    }

                    oPurchaseRequisition.Remarks = reader["Remarks"].ToString();
                    oPurchaseRequisition.UserID = (int)reader["EntryUserID"];
                    oPurchaseRequisition.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());

                    oPurchaseRequisition.ApprovalDate = (object)reader["ApprovalDate"];
                    oPurchaseRequisition.PortArrivalDate = (object)reader["PortArrivalDate"];
                    oPurchaseRequisition.ReceivedDate = (object)reader["ReceivedDate"];


                    oPurchaseRequisition.LCNo = reader["LCNo"].ToString();
                    oPurchaseRequisition.LCInvoiceNo = reader["LCInvoiceNo"].ToString();
                    oPurchaseRequisition.LCValue = Convert.ToDouble(reader["LCValue"].ToString());
                    oPurchaseRequisition.PINo = reader["PINo"].ToString();
                    oPurchaseRequisition.LCDate = (object)reader["LCDate"];
                    oPurchaseRequisition.LCInvoiceDate = (object)reader["LCInvoiceDate"];
                    oPurchaseRequisition.DocDate = (object)reader["DocDate"];
                    oPurchaseRequisition.PINo = reader["PINo"].ToString();
                    oPurchaseRequisition.ShipmentDate = (object)reader["ShipmentDate"];
                    oPurchaseRequisition.DutyDate = (object)reader["DutyDate"];
                    oPurchaseRequisition.PIDate = (object)reader["PIDate"];

                    if (reader["DocValue"] == DBNull.Value) oPurchaseRequisition.DocValue = 0;
                    else oPurchaseRequisition.DocValue = Convert.ToDouble(reader["DocValue"].ToString());

                    if (reader["DutyAmount"] == DBNull.Value) oPurchaseRequisition.DutyAmount = 0;
                    else oPurchaseRequisition.DutyAmount = Convert.ToDouble(reader["DutyAmount"].ToString());

                    oPurchaseRequisition.RefreshItem();
                    oPurchaseRequisition.RefreshSupplier();
                    oPurchaseRequisition.RefreshUser();

                    InnerList.Add(oPurchaseRequisition);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }
    
    }
}
