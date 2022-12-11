// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 14, 2013
// Time :  04:23 PM
// Description: Class for Product Component.
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
    public class ProductComponent
    {      
        private int _nProductComponentID;
        private int _nProductID;
        private int _nSetID;
        private string _sProductSerial;
        private string _sPanelSerial;
        private string _sSSBSerial;
        private string _sPSUSerial;
        private string _sBarcodeSerial;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sCBSerial;
        private string _sCompressorSerial;
        private string _sACIndoorBarcode;
        private int _nComponentID;
        private string _sComponentName;
        private int _nStatus;
        private string _sRemarks;

        private int _nDefectiveID;
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int SetID
        {
            get { return _nSetID; }
            set { _nSetID = value; }
        }
        public int ComponentID
        {
            get { return _nComponentID; }
            set { _nComponentID = value; }
        }
        public string ComponentName
        {
            get { return _sComponentName; }
            set { _sComponentName = value; }
        }
        public string ACIndoorBarcode
        {
            get { return _sACIndoorBarcode; }
            set { _sACIndoorBarcode = value; }
        }
        private string _sPCBSerial;
        public string PCBSerial
        {
            get { return _sPCBSerial; }
            set { _sPCBSerial = value; }
        }
        private string _sACIndoorPCBSerial;
        public int _nLocationID;
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }
        public string ACIndoorPCBSerial
        {
            get { return _sACIndoorPCBSerial; }
            set { _sACIndoorPCBSerial = value; }
        }
        private int _nIsIndoorItem;
        public int IsIndoorItem
        {
            get { return _nIsIndoorItem; }
            set { _nIsIndoorItem = value; }
        }
        private int _nProductionType;
        public int ProductionType
        {
            get { return _nProductionType; }
            set { _nProductionType = value; }
        }
        private string _sProductCode;
        private string _sProductName;

        private string _sBrandDesc;
        private string _sAGName;
        private string _sASGName;
        private string _sMAGName;
        private string _sPGName;
        private object _dtInvoiceDate;
        private string _sInvoiceNo;

        public object InvoiceDate
        {
            get { return _dtInvoiceDate; }
            set { _dtInvoiceDate = value; }
        }

        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }



        /// <summary>
        /// Get set property for ProductComponentID
        /// </summary>
        public int ProductComponentID
        {
            get { return _nProductComponentID; }
            set { _nProductComponentID = value; }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for ProductSerial
        /// </summary>
        public string ProductSerial
        {
            get { return _sProductSerial; }
            set { _sProductSerial = value; }
        }
        /// <summary>
        /// Get set property for PanelSerial
        /// </summary>
        public string PanelSerial
        {
            get { return _sPanelSerial; }
            set { _sPanelSerial = value; }
        }
        /// <summary>
        /// Get set property for SSBSerial
        /// </summary>
        public string SSBSerial
        {
            get { return _sSSBSerial; }
            set { _sSSBSerial = value; }
        }
        /// <summary>
        /// Get set property for PSUSerial
        /// </summary>
        public string PSUSerial
        {
            get { return _sPSUSerial; }
            set { _sPSUSerial = value; }
        }
        /// <summary>
        /// Get set property for BarcodeSerial
        /// </summary>
        public string BarcodeSerial
        {
            get { return _sBarcodeSerial; }
            set { _sBarcodeSerial = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        /// 


        private int _nProductComponentUniversalID;
        public int ProductComponentUniversalID
        {
            get { return _nProductComponentUniversalID; }
            set { _nProductComponentUniversalID = value; }
        }
        private int _nSort;
        public int Sort
        {
            get { return _nSort; }
            set { _nSort = value; }
        }
        private int _nIsActive;
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        private string _sCreateUser;
        public string CreateUser
        {
            get { return _sCreateUser; }
            set { _sCreateUser = value; }
        }
        private int _nASGID;

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
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
        private string _sProductModel;
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value; }
        }

        /// <summary>
        /// Get set property for BrandDesc
        /// </summary>
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }

        /// <summary>
        /// Get set property for AGName
        /// </summary>
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }
        /// <summary>
        /// Get set property for ASGName
        /// </summary>
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        /// <summary>
        /// Get set property for MAGName
        /// </summary>
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        /// <summary>
        /// Get set property for PGName
        /// </summary>
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }

        public string CBSerial
        {
            get { return _sCBSerial; }
            set { _sCBSerial = value; }
        }
        public string CompressorSerial
        {
            get { return _sCompressorSerial; }
            set { _sCompressorSerial = value; }
        }

        private string _sQcRemarks;
        public string QcRemarks
        {
            get { return _sQcRemarks; }
            set { _sQcRemarks = value; }
        }

        private int _nQCStatus;
        public int QCStatus
        {
            get { return _nQCStatus; }
            set { _nQCStatus = value; }
        }

        private int _nSymtom;
        public int Symtom
        {
            get { return _nSymtom; }
            set { _nSymtom = value; }
        }
        private int _nRootcause;
        public int Rootcause
        {
            get { return _nRootcause; }
            set { _nRootcause = value; }
        }

        private int _nDefectID;
        public int DefectID
        {
            get { return _nDefectID; }
            set { _nDefectID = value; }
        }

        private string _sDefectName;
        public string DefectName
        {
            get { return _sDefectName; }
            set { _sDefectName = value; }
        }

        public int DefectiveID
        {
            get { return _nDefectiveID; }
            set { _nDefectiveID = value; }
        }

        private int _TargetQty;
        public int TargetQty
        {
            get { return _TargetQty; }
            set { _TargetQty = value; }
        }

        public void Add()
        {
            int nMaxProductComponentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ProductComponentID]) FROM t_ProductComponent";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductComponentID = 1;
                }
                else
                {
                    nMaxProductComponentID = Convert.ToInt32(maxID) + 1;
                }
                _nProductComponentID = nMaxProductComponentID;


                sSql = "INSERT INTO t_ProductComponent(ProductComponentID, ProductID, ProductSerial, PanelSerial, SSBSerial, PSUSerial, " +
                                    "BarcodeSerial, CreateUserID,CreateDate,CBSerial, CompressorSerial, IsIndoorItem) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductComponentID", _nProductComponentID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerial", _sProductSerial);
                cmd.Parameters.AddWithValue("PanelSerial", _sPanelSerial);
                cmd.Parameters.AddWithValue("SSBSerial", _sSSBSerial);
                cmd.Parameters.AddWithValue("PSUSerial", _sPSUSerial);
                cmd.Parameters.AddWithValue("BarcodeSerial", _sBarcodeSerial);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CBSerial", _sCBSerial);
                cmd.Parameters.AddWithValue("CompressorSerial", _sCompressorSerial);
                cmd.Parameters.AddWithValue("IsIndoorItem", _nIsIndoorItem);



                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddDefect()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_ProductComponentSerialUniversal (SetID, ProductID, ComponentID, SerialNo, CreateDate, CreateUserID,UpdateDate,UpdateUserID,ProductionType,IsIndoorItem,LocationID,Status,Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SetID", _nSetID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                cmd.Parameters.AddWithValue("SerialNo", _sBarcodeSerial);
               
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ProductionType", _nProductionType);
                cmd.Parameters.AddWithValue("IsIndoorItem", _nIsIndoorItem);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForTelFactory(string sTableName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxProductComponentID = 0;
            string sID = "";


            if (sTableName == "t_ProductComponent")
            {
                sID = "ProductComponentID";
            }
            //else if (sTableName == "t_ProductComponentSerialUniversal")
            //{
            //    sID = "SetID";
            //}
            else if (sTableName == "t_ProductComponentUniversal")
            {
                sID = "ProductComponentUniversalID";
            }

            try
            {
                if (sTableName == "t_ProductComponentUniversal" || sTableName == "t_ProductComponent")
                {
                    sSql = "SELECT MAX([" + sID + "]) FROM " + sTableName + "";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxProductComponentID = 1;
                    }
                    else
                    {
                        nMaxProductComponentID = Convert.ToInt32(maxID) + 1;
                    }
                }
                
                if (sTableName == "t_ProductComponent")
                {
                    sSql = "INSERT INTO t_ProductComponent(ProductComponentID, ProductID, ProductSerial, PanelSerial, SSBSerial, PSUSerial, " +
                                        "BarcodeSerial, CreateUserID,CreateDate,CBSerial, CompressorSerial, IsIndoorItem, ACIndoorPCBSerial,UpdateDate,UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("ProductComponentID", nMaxProductComponentID);
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("ProductSerial", _sProductSerial);
                    cmd.Parameters.AddWithValue("PanelSerial", _sPanelSerial);
                    cmd.Parameters.AddWithValue("SSBSerial", _sSSBSerial);
                    cmd.Parameters.AddWithValue("PSUSerial", _sPSUSerial);
                    cmd.Parameters.AddWithValue("BarcodeSerial", _sBarcodeSerial);
                    cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                    cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                    cmd.Parameters.AddWithValue("CBSerial", _sCBSerial);
                    cmd.Parameters.AddWithValue("CompressorSerial", _sCompressorSerial);
                    cmd.Parameters.AddWithValue("IsIndoorItem", _nIsIndoorItem);
                    cmd.Parameters.AddWithValue("ACIndoorPCBSerial", _sACIndoorPCBSerial);
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                }
                else if (sTableName == "t_ProductComponentSerialUniversal")
                {


                    sSql = "INSERT INTO[dbo].[t_ProductComponentSerialUniversal] ([SetID],[ProductID],[ComponentID],[SerialNo],[CreateDate],[CreateUserID],[UpdateDate],[UpdateUserID],[ProductionType],[IsIndoorItem],[LocationID],[Status],[Remarks]) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";

                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("SetID", _nSetID);
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                    cmd.Parameters.AddWithValue("SerialNo", _sBarcodeSerial);
                    cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                    cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                    cmd.Parameters.AddWithValue("ProductionType", _nProductionType);
                    cmd.Parameters.AddWithValue("IsIndoorItem", _nIsIndoorItem);
                    cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                    cmd.Parameters.AddWithValue("Status", _nStatus);
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);


                }
                else if (sTableName == "t_ProductComponentUniversal")
                {
                    sSql = "INSERT INTO[dbo].[t_ProductComponentUniversal] ([ProductComponentUniversalID],[ComponentID],[ASGID],[ComponentName],[CreateUserID],[CreateDate],[IsActive],[UpdateUserID],[UpdateDate],[Sort],[ProductionType],[IsIndoorItem]) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";

                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("ProductComponentUniversalID", nMaxProductComponentID);
                    cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                    cmd.Parameters.AddWithValue("ASGID", _nASGID);
                    cmd.Parameters.AddWithValue("ComponentName", _sComponentName);
                    cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                    cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                    cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                    cmd.Parameters.AddWithValue("Sort", _nSort);
                    cmd.Parameters.AddWithValue("ProductionType", _nProductionType);
                    cmd.Parameters.AddWithValue("IsIndoorItem", _nIsIndoorItem);
                }

                else if (sTableName == "t_SKDDefectiveComponent")
                {


                    sSql = "INSERT INTO[dbo].[t_SKDDefectiveComponent] ([DefectiveID],[SetID],[ComponentID],[SerialNo],[CreateDate],[CreateUserID],[Status],[Remarks],[Symtom],[Rootcause],[LocationID]) VALUES(?,?,?,?,?,?,?,?,?,?,?)";

                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                    cmd.Parameters.AddWithValue("SetID", _nSetID);
                    cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                    cmd.Parameters.AddWithValue("SerialNo", _sBarcodeSerial);
                    cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                    cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                    cmd.Parameters.AddWithValue("Status", _nStatus);
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                    cmd.Parameters.AddWithValue("Symtom", _nSymtom);
                    cmd.Parameters.AddWithValue("Rootcause", _nRootcause);
                    cmd.Parameters.AddWithValue("LocationID", _nLocationID);


                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddComponentSerialUniversal(int _nType,int nLocationID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_ProductComponentSerialUniversal (SetID, ProductID, ComponentID, SerialNo, CreateDate, CreateUserID, UpdateDate, UpdateUserID,ProductionType,IsIndoorItem,LocationID,Status,Remarks) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SetID", _nSetID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                cmd.Parameters.AddWithValue("SerialNo", _sBarcodeSerial);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                if (_nType == 1)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                }
                cmd.Parameters.AddWithValue("ProductionType", _nProductionType);
                cmd.Parameters.AddWithValue("IsIndoorItem", _nIsIndoorItem);
                cmd.Parameters.AddWithValue("LocationID", nLocationID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateFGSerial(int nIsFGSerial)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
               
                cmd.CommandText = "UPDATE t_ProductComponentSerialUniversal set SerialNo=?,CreateDate=?,CreateUserID=? where SetID=? and LocationID=? and ComponentID=7";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SerialNo", _sBarcodeSerial);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                
                cmd.Parameters.AddWithValue("SetID", _nSetID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddACIndoor()
        {
            int nMaxProductComponentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ProductComponentID]) FROM t_ProductComponent";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductComponentID = 1;
                }
                else
                {
                    nMaxProductComponentID = Convert.ToInt32(maxID) + 1;
                }
                _nProductComponentID = nMaxProductComponentID;


                sSql = "INSERT INTO t_ProductComponent(ProductComponentID, ProductID, ProductSerial, ACIndoorPCBSerial, BarcodeSerial, CreateUserID, CreateDate, IsIndoorItem) VALUES(?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductComponentID", _nProductComponentID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerial", _sProductSerial);
                cmd.Parameters.AddWithValue("ACIndoorPCBSerial", _sPCBSerial);
                cmd.Parameters.AddWithValue("BarcodeSerial", _sBarcodeSerial);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("IsIndoorItem", _nIsIndoorItem);

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

                cmd.CommandText = "UPDATE t_ProductComponent SET ProductID=?, ProductSerial=?, PanelSerial=?, SSBSerial=?, PSUSerial=?, "+
                    "BarcodeSerial=?, UpdateUserID=?,UpdateDate=?, CBSerial =?, CompressorSerial=? Where ProductComponentID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerial", _sProductSerial);
                cmd.Parameters.AddWithValue("PanelSerial", _sPanelSerial);
                cmd.Parameters.AddWithValue("SSBSerial", _sSSBSerial);
                cmd.Parameters.AddWithValue("PSUSerial", _sPSUSerial);
                cmd.Parameters.AddWithValue("BarcodeSerial", _sBarcodeSerial);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CBSerial", _sCBSerial);
                cmd.Parameters.AddWithValue("CompressorSerial", _sCompressorSerial);

                cmd.Parameters.AddWithValue("ProductComponentID", _nProductComponentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditACIndoor()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_ProductComponent SET ProductID=?, ProductSerial=?, ACIndoorPCBSerial=?, BarcodeSerial=?, UpdateUserID=?, UpdateDate=? Where ProductComponentID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerial", _sProductSerial);
                cmd.Parameters.AddWithValue("ACIndoorPCBSerial", _sPCBSerial);
                cmd.Parameters.AddWithValue("BarcodeSerial", _sBarcodeSerial);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ProductComponentID", _nProductComponentID);


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
                sSql = "DELETE FROM t_ProductComponent WHERE [ProductComponentID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductComponentID", _nProductComponentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void DeleteDefect()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_ProductComponentSerialUniversal WHERE [SetID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SetID", _nSetID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public int GetDefectiveSetID(int nID)
        {
            int nSetID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select distinct SETID From t_ProductComponentSerialUniversal where Status=0 and SetID=" + nID + "";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nSetID = (int)reader["SetID"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nSetID;
        }

        public void DeleteFactorySerialUniversal()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                //sSql = "Delete From t_ProductComponentSerialUniversal where SerialNo='" + _sBarcodeSerial + "' and ProductID=" + _nProductID + " and SetID=" + _nSetID + " and LocationID=" + _nLocationID + " and ComponentID=" + _nComponentID + "";

                sSql = "Delete From t_ProductComponentSerialUniversal where ProductID=" + _nProductID + " and SetID=" + _nSetID + " and LocationID=" + _nLocationID + " and ComponentID=" + _nComponentID + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("SerialNo", _sBarcodeSerial);
                //cmd.Parameters.AddWithValue("ProductID", _nProductID);
                //cmd.Parameters.AddWithValue("SetID", _nSetID);
                //cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                //cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void DeleteProductComponent(int nSetID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Delete From t_ProductComponentSerialUniversal where SetID = ?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SetID", nSetID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void RefreshByID(int nProductComponentID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ProductComponentID, P.ProductID,ProductCode, ProductName, ProductSerial, PanelSerial, SSBSerial, PSUSerial, " +
                            "BarcodeSerial, CBSerial, CompressorSerial, CreateUserID,CreateDate from t_ProductComponent PC INNER JOIN t_Product P ON P.ProductID=PC.ProductID " +
                            "Where ProductComponentID=? ";

            cmd.Parameters.AddWithValue("ProductComponentID", nProductComponentID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductComponentID = (int)reader["ProductComponentID"];
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductSerial = (string)reader["ProductSerial"];
                    _sPanelSerial = (string)reader["PanelSerial"];
                    _sSSBSerial = (string)reader["SSBSerial"];
                    _sPSUSerial = (string)reader["PSUSerial"];
                    _sBarcodeSerial = (string)reader["BarcodeSerial"];
                    if (reader["CBSerial"] != DBNull.Value)
                    {
                        _sCBSerial = (string)reader["CBSerial"];
                    }
                    else
                    {
                        _sCBSerial = "";
                    }
                    if (reader["CompressorSerial"] != DBNull.Value)
                    {
                        _sCompressorSerial = (string)reader["CompressorSerial"];
                    }
                    else
                    {
                        _sCompressorSerial = "";
                    }

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        
        public bool CheckProductSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductComponent where ProductSerial=? ";

            cmd.Parameters.AddWithValue("ProductSerial", _sProductSerial);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheckPanelSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductComponent where PanelSerial=? ";

            cmd.Parameters.AddWithValue("PanelSerial", _sPanelSerial);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheckSSBSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductComponent where SSBSerial=? ";

            cmd.Parameters.AddWithValue("SSBSerial", _sSSBSerial);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheckPSUSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductComponent where PSUSerial=? ";

            cmd.Parameters.AddWithValue("PSUSerial", _sPSUSerial);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheckBarcodeSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductComponent where BarcodeSerial=? ";

            cmd.Parameters.AddWithValue("BarcodeSerial", _sBarcodeSerial);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheckCBSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductComponent where CBSerial=? ";

            cmd.Parameters.AddWithValue("CBSerial", _sCBSerial);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheckCompressorSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductComponent where CompressorSerial=? ";

            cmd.Parameters.AddWithValue("CompressorSerial", _sCompressorSerial);

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
            if (nCount == 0)
                return true;
            else return false;
        }

        public int GetUniversalMAXID()
        {
            int nMAXSetID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select isnull(max(SetID), 0)+1 SetID From t_ProductComponentSerialUniversal";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nMAXSetID = (int)reader["SetID"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nMAXSetID;
        }

        public void AddDefectiveComponent()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DefectiveID]) FROM t_SKDDefectiveComponent";
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
                _nDefectiveID = nMaxID;

                sSql = "INSERT INTO t_SKDDefectiveComponent (DefectiveID, SetID, ComponentID, SerialNo, CreateUserID, CreateDate, Status, Remarks, Symtom, Rootcause,LocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("SetID", _nSetID);
                cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                cmd.Parameters.AddWithValue("SerialNo", _sBarcodeSerial);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", _nQCStatus);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sQcRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.Parameters.AddWithValue("Symtom", _nSymtom);
                cmd.Parameters.AddWithValue("Rootcause", _nRootcause);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddSKDTarget()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_SKDProductionTarget";
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
                _nComponentID = nMaxID;
                sSql = "INSERT INTO t_SKDProductionTarget (ID, ProductID, TargetDate, TargetQty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nComponentID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("TargetDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TargetQty", _TargetQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditSKDTarget()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SKDProductionTarget SET ProductID = ?, TargetDate = ?, TargetQty = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("TargetDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TargetQty", _TargetQty);

                cmd.Parameters.AddWithValue("ID", _nComponentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class ProductComponents : CollectionBase
    {

        public ProductComponent this[int i]
        {
            get { return (ProductComponent)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductComponent oProductComponent)
        {
            InnerList.Add(oProductComponent);
        }


        public void GetComponent(int nSetID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                //cmd.CommandText = "Select a.ID,ComponentID,  " +
                //                "ComponentName,SerialNo,a.CreateDate,a.CreateUserID,   " +
                //                "a.Status,isnull(a.Remarks,'') Remarks   " +
                //                "From t_ProductComponentSerialUniversal a,t_ProductComponentUniversal b   " +
                //                "where a.ID=b.ID and ChassisSerial='" + sChassisSerial + "'";

                cmd.CommandText = "Select a.SetID, a.ComponentID,ComponentName,SerialNo,a.CreateDate,a.CreateUserID,isnull(a.Status,0) Status,isnull(a.Remarks,'') Remarks  " +
                "From t_ProductComponentSerialUniversal a,t_ProductComponentUniversal b, t_Product c  " +
                "where a.ComponentID = b.ComponentID  and a.ProductID = c.ProductID and b.ASGID = c.ASGID and " +
                "SetID = '" + nSetID + "' and a.IsIndoorItem=b.IsIndoorItem and a.ProductionType=b.ProductionType and a.ProductionType=2 and b.IsActive=1 and a.LocationID=86 order by b.sort";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductComponent oItem = new ProductComponent();

                    oItem.SetID = int.Parse(reader["SetID"].ToString());//ID
                    oItem.ComponentID = int.Parse(reader["ComponentID"].ToString());
                    oItem.ComponentName = (reader["ComponentName"].ToString());
                    oItem.BarcodeSerial = (reader["SerialNo"].ToString());
                    oItem.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oItem.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oItem.Status = int.Parse(reader["Status"].ToString());
                    oItem.Remarks = (reader["Remarks"].ToString());
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

        public void Refresh(DateTime dFromDate, DateTime dToDate, String txtBracode, bool IsTrue, String txtPanelSL, String txtProductSL, String txtPSUSL, String txtSSBSL, int nBrandID, string sCBSerail, string sCompressorSerial, int nAG, int nASG, int nMAG, int nPG, string sCode, string sProductName, string sInvoiceNo)
        {
            InnerList.Clear();

            dToDate = dToDate.Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = " Select ProductComponentID, P.ProductID,ProductCode, ProductName,  "+
            //            " AGName,ASGName,MAGName,PGName,BrandDesc,ProductSerial, PanelSerial, SSBSerial, PSUSerial,   "+
            //            " BarcodeSerial, CreateUserID,CreateDate, CBSerial,CompressorSerial   " +
            //            " from t_ProductComponent PC INNER JOIN v_ProductDetails P ON P.ProductID=PC.ProductID ";

            string sSql = "Select * From  " +
                        "(Select a.*,isnull(InvoiceNo,'') InvoiceNo,InvoiceDate From     " +
                        "(Select * From   " +
                        "(Select ProductComponentID, P.ProductID,ProductCode, ProductName,     " +
                        "AGID, AGName,ASGID,ASGName,MAGID,MAGName,PGID,PGName,BrandID,BrandDesc,  " +
                        "isnull(ProductSerial,'') ProductSerial,isnull(PanelSerial,'') PanelSerial,isnull(SSBSerial,'') SSBSerial,  " +
                        "isnull(PSUSerial,'') PSUSerial,isnull(BarcodeSerial,'') BarcodeSerial,  " +
                        "isnull(CreateUserID,-1) CreateUserID,isnull(CreateDate,getdate()) CreateDate,  " +
                        "isnull(CBSerial,'') CBSerial,isnull(CompressorSerial,'') CompressorSerial,  " +
                        "isnull(IsIndoorItem,0) IsIndoorItem       " +
                        "from t_ProductComponent PC,v_ProductDetails p where  P.ProductID=PC.ProductID) a   " +
                        "where IsIndoorItem=0) a    " +
                        "Left Outer Join     " +
                        "(Select GRDNO,GRDSLQty,ProductID,Startbarcode,Endbarcode,TotalBarcode,InvoiceNo,InvoiceDate From     " +
                        "(select TranNo as GRDNO,Qty as GRDSLQty,b.PRoductID,a.Startbarcode,    " +
                        "a.Endbarcode,Barcode as TotalBarcode,isnull(InvoiceNo,'') as InvoiceNo,InvoiceDate from     " +
                        "(Select TranNo,ProductID,Qty,InitialBarcode as StartBarcode,InvoiceNo,InvoiceDate,    " +
                        "(InitialBarcode+Qty) as EndBarcode from dbo.t_ProductBarcode) a,    " +
                        "t_ProductBarCodeDetail b Where     " +
                        "cast(b.Barcode as varchar) between cast(a.StartBarcode as varchar) and     " +
                        "cast(a.EndBarcode as varchar) and a.ProductID=b.ProductID) a) b    " +
                        "on a.BarcodeSerial=b.TotalBarcode)  a where 1=1";

            if (IsTrue == true)
            {
                sSql = sSql + " AND ProductComponentID <>0";
            }
            else
            {
                sSql = sSql + "AND CreateDate between ? and ? and CreateDate < ?";
            }
            if (txtBracode.Trim() != "")
            {
                txtBracode = "%" + txtBracode + "%";
                sSql = sSql + " AND BarcodeSerial LIKE '" + txtBracode + "'";
            }
            if (txtPanelSL.Trim() != "")
            {
                txtPanelSL = "%" + txtPanelSL + "%";
                sSql = sSql + " AND PanelSerial LIKE '" + txtPanelSL + "'";
            }
            if (txtProductSL.Trim() != "")
            {
                txtProductSL = "%" + txtProductSL + "%";
                sSql = sSql + " AND ProductSerial LIKE '" + txtProductSL + "'";
            }
            if (txtPSUSL.Trim() != "")
            {
                txtPSUSL = "%" + txtPSUSL + "%";
                sSql = sSql + " AND PSUSerial LIKE '" + txtPSUSL + "'";
            }
            if (txtSSBSL.Trim() != "")
            {
                txtSSBSL = "%" + txtSSBSL + "%";
                sSql = sSql + " AND SSBSerial LIKE '" + txtSSBSL + "'";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID = " + nBrandID + "";
            }
            if (sCBSerail.Trim() != "")
            {
                sCBSerail = "%" + sCBSerail + "%";
                sSql = sSql + " AND CBSerial LIKE '" + sCBSerail + "'";
            }
            if (sCompressorSerial.Trim() != "")
            {
                sCompressorSerial = "%" + sCompressorSerial + "%";
                sSql = sSql + " AND CompressorSerial LIKE '" + sCompressorSerial + "'";
            }
            if (sInvoiceNo.Trim() != "")
            {
                sInvoiceNo = "%" + sInvoiceNo + "%";
                sSql = sSql + " AND InvoiceNo LIKE '" + sInvoiceNo + "'";
            }

            if (nAG != -1)
            {
                sSql = sSql + " AND AGID = " + nAG + "";
            }
            if (nASG != -1)
            {
                sSql = sSql + " AND ASGID = " + nASG + "";
            }
            if (nMAG != -1)
            {
                sSql = sSql + " AND MAGID = " + nMAG + "";
            }
            if (nPG != -1)
            {
                sSql = sSql + " AND PGID = " + nPG + "";
            }
            if (sCode.Trim() != "")
            {
                sCode = "%" + sCode + "%";
                sSql = sSql + " AND ProductCode LIKE '" + sCode + "'";
            }

            if (sProductName.Trim() != "")
            {
                sProductName = "%" + sProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + sProductName + "'";
            }

            sSql = sSql + " Order by CreateDate ASC ";

            cmd.Parameters.AddWithValue("CreateDate", dFromDate);
            cmd.Parameters.AddWithValue("CreateDate", dToDate);
            cmd.Parameters.AddWithValue("CreateDate", dToDate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    ProductComponent oProductComponent = new ProductComponent();

                    oProductComponent.ProductComponentID = (int)reader["ProductComponentID"];
                    oProductComponent.ProductID = (int)reader["ProductID"];
                    oProductComponent.ProductCode = (string)reader["ProductCode"];
                    oProductComponent.ProductName = (string)reader["ProductName"];
                    oProductComponent.BrandDesc = (string)reader["BrandDesc"];
                    oProductComponent.AGName = (string)reader["AGName"];
                    oProductComponent.ASGName = (string)reader["ASGName"];
                    oProductComponent.MAGName = (string)reader["MAGName"];
                    oProductComponent.PGName = (string)reader["PGName"];
                    oProductComponent.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                    {
                        oProductComponent.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    }
                    else
                    {
                        oProductComponent.InvoiceDate = null;
                    }
                    oProductComponent.ProductSerial = (string)reader["ProductSerial"];
                    oProductComponent.PanelSerial = (string)reader["PanelSerial"];
                    oProductComponent.SSBSerial = (string)reader["SSBSerial"];
                    if (reader["CBSerial"] != DBNull.Value)
                    {
                        oProductComponent.CBSerial = (string)reader["CBSerial"];
                    }
                    else
                    {
                        oProductComponent.CBSerial = "";
                    }
                    if (reader["CompressorSerial"] != DBNull.Value)
                    {
                        oProductComponent.CompressorSerial = (string)reader["CompressorSerial"];
                    }
                    else
                    {
                        oProductComponent.CompressorSerial = "";
                    }
                    oProductComponent.PSUSerial = (string)reader["PSUSerial"];
                    oProductComponent.BarcodeSerial = (string)reader["BarcodeSerial"];
                    oProductComponent.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oProductComponent.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetACIndoorComponent(DateTime dFromDate, DateTime dToDate, bool IsTrue, string txtProductSL, string txtBracode, string txtACIndoorPCBSerial, int nAG, int nASG, int nMAG, int nPG, int nBrandID, string sCode)
        {
            InnerList.Clear();

            dToDate = dToDate.Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ProductComponentID,a.ProductID,ProductCode,ProductName,AGName,ASGName, " +
                        "MAGName,PGName,BrandDesc as Brand,ProductSerial, " +
                        "BarcodeSerial,ACIndoorPCBSerial,CreateDate,CreateUserID  " +
                        "From dbo.t_ProductComponent a,v_ProductDetails b " +
                        "where IsIndoorItem=1 and a.ProductID=b.ProductID";

            if (IsTrue == true)
            {

            }
            else
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "'";
            }

            if (txtProductSL.Trim() != "")
            {
                txtProductSL = "%" + txtProductSL + "%";
                sSql = sSql + " AND ProductSerial LIKE '" + txtProductSL + "'";
            }
            if (txtBracode.Trim() != "")
            {
                txtBracode = "%" + txtBracode + "%";
                sSql = sSql + " AND BarcodeSerial LIKE '" + txtBracode + "'";
            }
            if (txtACIndoorPCBSerial.Trim() != "")
            {
                txtACIndoorPCBSerial = "%" + txtACIndoorPCBSerial + "%";
                sSql = sSql + " AND ACIndoorPCBSerial LIKE '" + txtACIndoorPCBSerial + "'";
            }
            if (nAG != -1)
            {
                sSql = sSql + " AND AGID = " + nAG + "";
            }
            if (nASG != -1)
            {
                sSql = sSql + " AND ASGID = " + nASG + "";
            }
            if (nMAG != -1)
            {
                sSql = sSql + " AND MAGID = " + nMAG + "";
            }
            if (nPG != -1)
            {
                sSql = sSql + " AND PGID = " + nPG + "";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID = " + nBrandID + "";
            }
            if (sCode.Trim() != "")
            {
                sCode = "%" + sCode + "%";
                sSql = sSql + " AND ProductCode LIKE '" + sCode + "'";
            }

            sSql = sSql + " Order by CreateDate ASC ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductComponent oProductComponent = new ProductComponent();

                    oProductComponent.ProductComponentID = (int)reader["ProductComponentID"];
                    oProductComponent.ProductID = (int)reader["ProductID"];
                    oProductComponent.ProductCode = (string)reader["ProductCode"];
                    oProductComponent.ProductName = (string)reader["ProductName"];
                    oProductComponent.BrandDesc = (string)reader["Brand"];
                    oProductComponent.AGName = (string)reader["AGName"];
                    oProductComponent.ASGName = (string)reader["ASGName"];
                    oProductComponent.MAGName = (string)reader["MAGName"];
                    oProductComponent.PGName = (string)reader["PGName"];
                    oProductComponent.ProductSerial = (string)reader["ProductSerial"];
                    oProductComponent.BarcodeSerial = (string)reader["BarcodeSerial"];
                    oProductComponent.PCBSerial = (string)reader["ACIndoorPCBSerial"];
                    oProductComponent.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oProductComponent.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshComponent(string sProductCode,int nSetID,int nProductionType,int nIsIndoorItem, int nLocationID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nSetID == -1)
            {
                sSql = "Select a.ComponentID,ComponentName,'' as SerialNo From [dbo].[t_ProductComponentUniversal] a,v_ProductDetails b " +
                              "where a.AsgID = b.ASGID and a.ProductionType=" + nProductionType + " and a.IsIndoorItem=" + nIsIndoorItem + " and ProductCode = '" + sProductCode + "' and a.IsActive=1 order by a.sort";
            }
            else
            {
                sSql = "Select a.ComponentID,ComponentName,SerialNo  " +
                    "From t_ProductComponentSerialUniversal a,t_ProductComponentUniversal b, v_ProductDetails c  " +
                    "where a.ComponentID = b.ComponentID  and a.ProductID = c.ProductID and b.ASGID = c.ASGID and  " +
                    "SetID = " + nSetID + " and a.IsIndoorItem=b.IsIndoorItem and a.ProductionType=b.ProductionType and a.IsIndoorItem=" + nIsIndoorItem + " and a.ProductionType=" + nProductionType + " and b.IsActive=1 and a.LocationID=" + nLocationID + " order by b.sort";
            }
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductComponent oProductComponent = new ProductComponent();
                    oProductComponent.ComponentID = (int)reader["ComponentID"];
                    oProductComponent.ComponentName = (string)reader["ComponentName"];
                    oProductComponent.ProductSerial = (string)reader["SerialNo"];


                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshComponentFactory(string sProductCode, int nSetID, int nProductionType, int nIsIndoorItem,int nLocationID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nSetID == -1)
            {
                sSql = "Select a.ComponentID,ComponentName,'' as SerialNo,getdate() as CreateDate From [dbo].[t_ProductComponentUniversal] a,t_Product b " +
                       "where a.AsgID = b.ASGID and a.ProductionType=" + nProductionType + " and a.IsIndoorItem=" + nIsIndoorItem + " and ProductCode = '" + sProductCode + "' and a.IsActive=1 order by a.sort";
            }
            else
            {
                sSql = "Select a.ComponentID,ComponentName,SerialNo,a.CreateDate  " +
                    "From t_ProductComponentSerialUniversal a,t_ProductComponentUniversal b, t_Product c  " +
                    "where a.ComponentID = b.ComponentID  and a.ProductID = c.ProductID and b.ASGID = c.ASGID   and  " +
                    "SetID = " + nSetID + " and a.IsIndoorItem=b.IsIndoorItem and a.ProductionType=b.ProductionType and a.IsIndoorItem=" + nIsIndoorItem + " and a.ProductionType=" + nProductionType + " and b.IsActive=1 and a.LocationID=" + nLocationID + " order by b.sort";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductComponent oProductComponent = new ProductComponent();
                    oProductComponent.ComponentID = (int)reader["ComponentID"];
                    oProductComponent.ComponentName = (string)reader["ComponentName"];
                    oProductComponent.ProductSerial = (string)reader["SerialNo"];
                    oProductComponent.CreateDate = (DateTime)reader["CreateDate"];


                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshComponentFactoryPrint(string sProductCode, int nSetID, int nProductionType, int nIsIndoorItem, int nLocationID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
           
            sSql = "Select a.ComponentID,ComponentName,SerialNo,a.CreateDate  " +
                "From t_ProductComponentSerialUniversal a,t_ProductComponentUniversal b, t_Product c  " +
                "where a.ComponentID = b.ComponentID  and a.ProductID = c.ProductID and b.ASGID = c.ASGID and a.ComponentID<>7  and  " +
                "SetID = " + nSetID + " and a.IsIndoorItem=b.IsIndoorItem and a.ProductionType=b.ProductionType and a.IsIndoorItem=" + nIsIndoorItem + " and a.ProductionType=" + nProductionType + " and b.IsActive=1 and a.LocationID=" + nLocationID + " order by b.sort";
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductComponent oProductComponent = new ProductComponent();
                    oProductComponent.ComponentID = (int)reader["ComponentID"];
                    oProductComponent.ComponentName = (string)reader["ComponentName"];
                    oProductComponent.ProductSerial = (string)reader["SerialNo"];
                    oProductComponent.CreateDate = (DateTime)reader["CreateDate"];


                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProductComponentUniversal(DateTime dFromDate, DateTime dToDate,int nPG, int nMAG, int nASG, int nAG, int nBrand, int nComponentID,string sSerialNo, string sProductCode,bool IsCheck,int nIsIndoorItem,int nProductionType)
        {
            InnerList.Clear();
            dToDate = dToDate.Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select SetID,c.ProductID,ProductCode,ProductName, " +
                    "isnull(ProductModel, '') ProductModel, " +
                    "AGName,a.ASGID,ASGName,MAGName,PGName,BrandDesc,c.ComponentID,ComponentName,  " +
                    "SerialNo,c.CreateDate,c.CreateUserID,Username as CreateUser,c.UpdateDate,c.UpdateUserID,isnull(c.LocationID,1) LocationID " +
                    "From t_ProductComponentUniversal a, v_ProductDetails b, " +
                    "t_ProductComponentSerialUniversal c, t_User d " +
                    "where a.ASGID = b.ASGID and b.ProductID = c.ProductID and a.IsIndoorItem=c.IsIndoorItem and a.ProductionType=c.ProductionType " +
                    "and a.ComponentID = c.ComponentID and c.CreateUserID = d.UserID and c.IsIndoorItem=" + nIsIndoorItem + " and c.ProductionType=" + nProductionType + "";

                //sSql = ";WITH cte AS(select ROW_NUMBER() OVER(PARTITION BY SetID ORDER BY SetID DESC) AS rn,SetID, c.ProductID,ProductCode,ProductName, " +
                //    "isnull(ProductModel, '') ProductModel, " +
                //    "AGName,a.ASGID,ASGName,MAGName,PGName,BrandDesc,c.ComponentID,ComponentName,  " +
                //    "SerialNo,c.CreateDate,c.CreateUserID,Username as CreateUser,c.UpdateDate,c.UpdateUserID " +
                //    "From t_ProductComponentUniversal a, v_ProductDetails b, " +
                //    "t_ProductComponentSerialUniversal c, t_User d " +
                //    "where a.ASGID = b.ASGID and b.ProductID = c.ProductID and a.IsIndoorItem=c.IsIndoorItem and a.ProductionType=c.ProductionType " +
                //    "and a.ComponentID = c.ComponentID and c.CreateUserID = d.UserID and c.IsIndoorItem=" + nIsIndoorItem + " and c.ProductionType=" + nProductionType + "";


                //sSql = "Select SetID,c.ProductID,ProductCode,ProductName, " +
                //    "isnull(ProductModel, '') ProductModel, " +
                //    "AGName,a.ASGID,ASGName,MAGName,PGName,BrandDesc,c.ComponentID,ComponentName,  " +
                //    "SerialNo,c.CreateDate,c.CreateUserID,Username as CreateUser,c.UpdateDate,c.UpdateUserID " +
                //    "From t_ProductComponentUniversal a, v_ProductDetails b, " +
                //    "t_ProductComponentSerialUniversal c, t_User d " +
                //    "where a.ASGID = b.ASGID and b.ProductID = c.ProductID and a.IsIndoorItem=c.IsIndoorItem and a.ProductionType=c.ProductionType " +
                //    "and a.ComponentID = c.ComponentID and c.CreateUserID = d.UserID and c.IsIndoorItem=" + nIsIndoorItem + " and c.ProductionType=" + nProductionType + "  and a.ComponentID=3 ";

            }
            if (IsCheck == false)
            {
                sSql = sSql + " and c.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and c.CreateDate<'" + dToDate + "' ";
            }

            if (nPG != -1)
            {
                sSql = sSql + " AND PGID = " + nPG + "";
            }
            if (nMAG != -1)
            {
                sSql = sSql + " AND MAGID = " + nMAG + "";
            }
            if (nASG != -1)
            {
                sSql = sSql + " AND a.ASGID = " + nASG + "";
            }
            if (nAG != -1)
            {
                sSql = sSql + " AND AGID = " + nAG + "";
            }
            if (nBrand != -1)
            {
                sSql = sSql + " AND b.BrandID = " + nBrand + "";
            }
            if (nComponentID != -1)
            {
                sSql = sSql + " AND c.ComponentID = " + nComponentID + "";
            }
            
            if (sSerialNo != "")
            {
                sSql = sSql + " AND SerialNo like '%" + sSerialNo + "%'";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '" + sProductCode + "'";
            }

            sSql = sSql + " Order by SetID";
            //sSql = sSql + " ) SELECT * FROM cte WHERE rn = 1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductComponent oProductComponent = new ProductComponent();

                    oProductComponent.SetID = (int)reader["SetID"];
                    oProductComponent.ProductID = (int)reader["ProductID"];
                    oProductComponent.ProductCode = (string)reader["ProductCode"];
                    oProductComponent.ProductName = (string)reader["ProductName"];
                    oProductComponent.ProductModel = (string)reader["ProductModel"];
                    oProductComponent.AGName = (string)reader["AGName"];
                    oProductComponent.ASGID = (int)reader["ASGID"];
                    oProductComponent.ASGName = (string)reader["ASGName"];
                    oProductComponent.MAGName = (string)reader["MAGName"];
                    oProductComponent.PGName = (string)reader["PGName"];
                    oProductComponent.BrandDesc = (string)reader["BrandDesc"];
                    oProductComponent.ComponentID = (int)reader["ComponentID"];
                    oProductComponent.ComponentName = (string)reader["ComponentName"];
                    oProductComponent.ProductSerial = (string)reader["SerialNo"];
                    oProductComponent.CreateUser = (string)reader["CreateUser"];
                    oProductComponent.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oProductComponent.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oProductComponent.LocationID = int.Parse(reader["LocationID"].ToString());

                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int RefreshForProductComponentUniversal(string sSerial)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nID = 0;
            try
            {
               
                cmd.CommandText = "SELECT ID FROM t_ProductComponentSerialUniversal where ComponentID in(1,3) and ProductionType=2 and SerialNo like case when Left(SerialNo,14)='" + sSerial + "' then '" + sSerial + "%' else '" + sSerial + "' end";// and Status=" + nStatus + "";
                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nID = (int)reader["ID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;
        }

        public void GetProductComponentUniversalFactory(DateTime dFromDate, DateTime dToDate, int nPG, int nMAG, int nASG, int nAG, int nBrand, int nComponentID, string sSerialNo, string sProductCode, bool IsCheck, int nIsIndoorItem, int nProductionType, int nIsDefective,int nSetID)
        {
            InnerList.Clear();
            dToDate = dToDate.Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
           

            string sSql = "";
            {
                sSql = "Select SetID,c.ProductID,ProductCode,ProductName, " +
                    "isnull(ProductModel, '') ProductModel, " +
                    "AGName,a.ASGID,ASGName,MAGName,PGName,BrandDesc,c.ComponentID,ComponentName,  " +
                    "SerialNo,c.CreateDate,c.CreateUserID,Username as CreateUser,c.UpdateDate,c.UpdateUserID,isnull(c.LocationID,1) LocationID,c.IsIndoorItem,c.ProductionType " +
                    "From t_ProductComponentUniversal a, t_Product b, " +
                    "t_ProductComponentSerialUniversal c, t_User d " +
                    "where a.ASGID = b.ASGID and b.ProductID = c.ProductID and a.IsIndoorItem=c.IsIndoorItem and a.ProductionType=c.ProductionType " +
                    "and a.ComponentID = c.ComponentID and c.CreateUserID = d.UserID ";

               
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and c.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and c.CreateDate<'" + dToDate + "' ";
            }

            if (nIsIndoorItem != -1)
            {
                sSql = sSql + " AND c.IsIndoorItem = " + nIsIndoorItem + "";
            }

            if (nPG != -1)
            {
                sSql = sSql + " AND PGID = " + nPG + "";
            }
            if (nMAG != -1)
            {
                sSql = sSql + " AND MAGID = " + nMAG + "";
            }
            if (nASG != -1)
            {
                sSql = sSql + " AND a.ASGID = " + nASG + "";
            }
            if (nAG != -1)
            {
                sSql = sSql + " AND AGID = " + nAG + "";
            }
            if (nBrand != -1)
            {
                sSql = sSql + " AND b.BrandID = " + nBrand + "";
            }
            if (nComponentID != -1)
            {
                sSql = sSql + " AND c.ComponentID = " + nComponentID + "";
            }

            if (sSerialNo != "")
            {
                sSql = sSql + " AND SerialNo like '%" + sSerialNo + "%'";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '" + sProductCode + "'";
            }

            
            if(nProductionType==3)
            {
                sSql = sSql + " and c.ProductionType = 2";
            }
            else
            {
                sSql = sSql + " and c.ProductionType=" + nProductionType + "";
            }
            if (nSetID != -1)
            {
                sSql = sSql + " and SETID ="+ nSetID + " ";
            }

            if (nIsDefective == 1)
            {
                sSql = sSql + " and SETID in(Select distinct SETID From t_ProductComponentSerialUniversal where Status=0)";
            }

            sSql = sSql + " Order by SetID desc";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductComponent oProductComponent = new ProductComponent();

                    oProductComponent.SetID = (int)reader["SetID"];
                    oProductComponent.ProductID = (int)reader["ProductID"];
                    oProductComponent.ProductCode = (string)reader["ProductCode"];
                    oProductComponent.ProductName = (string)reader["ProductName"];
                    oProductComponent.ProductModel = (string)reader["ProductModel"];
                    oProductComponent.AGName = (string)reader["AGName"];
                    oProductComponent.ASGID = (int)reader["ASGID"];
                    oProductComponent.ASGName = (string)reader["ASGName"];
                    oProductComponent.MAGName = (string)reader["MAGName"];
                    oProductComponent.PGName = (string)reader["PGName"];
                    oProductComponent.BrandDesc = (string)reader["BrandDesc"];
                    oProductComponent.ComponentID = (int)reader["ComponentID"];
                    oProductComponent.ComponentName = (string)reader["ComponentName"];
                    oProductComponent.ProductSerial = (string)reader["SerialNo"];
                    oProductComponent.CreateUser = (string)reader["CreateUser"];
                    oProductComponent.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oProductComponent.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oProductComponent.LocationID = int.Parse(reader["LocationID"].ToString());
                    oProductComponent.IsIndoorItem = int.Parse(reader["IsIndoorItem"].ToString());
                    oProductComponent.ProductionType = int.Parse(reader["ProductionType"].ToString());
                    //if (reader["Remarks"] == null)
                    //{
                    //    oProductComponent.Remarks = "";
                    //}
                    //else
                    //{
                    //    oProductComponent.Remarks = reader["Remarks"].ToString();
                    //}
                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshComponentForDefective(string sProductCode, int nSetID, int nProductionType, int nLocationID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select a.ComponentID,ComponentName,SerialNo,a.CreateDate, c.ProductCode, c.ProductName, a.Remarks,a.Status  " +
                "From t_ProductComponentSerialUniversal a,t_ProductComponentUniversal b, t_Product c  " +
                "where a.ComponentID = b.ComponentID  and a.ProductID = c.ProductID and b.ASGID = c.ASGID and " +
                "SetID = " + nSetID + " and a.IsIndoorItem=b.IsIndoorItem and a.ProductionType=b.ProductionType and a.ProductionType=" + nProductionType + " and b.IsActive=1 and a.LocationID=" + nLocationID + " order by b.sort";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductComponent oProductComponent = new ProductComponent();
                    oProductComponent.ComponentID = (int)reader["ComponentID"];
                    oProductComponent.ComponentName = (string)reader["ComponentName"];
                    oProductComponent.ProductSerial = (string)reader["SerialNo"];
                    oProductComponent.CreateDate = (DateTime)reader["CreateDate"];
                    oProductComponent.ProductCode = (string)reader["ProductCode"];
                    oProductComponent.ProductName = (string)reader["ProductName"];
                    oProductComponent.Status = (int)reader["Status"];
                    oProductComponent.Remarks = (string)reader["Remarks"];


                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDefect()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from dbo.t_SKDDefectList where IsActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductComponent oProductComponent = new ProductComponent();
                    oProductComponent.DefectID = (int)reader["DefectID"];
                    oProductComponent.DefectName = (string)reader["DefectName"];

                    InnerList.Add(oProductComponent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshSKDTarget(DateTime dFromDate, DateTime dToDate, bool IsCheck, int nProductID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select a.*,ProductCode,ProductName From t_SKDProductionTarget a,t_Product b where a.ProductID=b.ProductID";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " AND TargetDate between '" + dFromDate + "' and '" + dToDate + "' and TargetDate<'" + dToDate + "' ";
            }

            if (nProductID != -1)
            {
                sSql = sSql + " AND a.ProductID=" + nProductID + "";
            }
            sSql = sSql + " Order by TargetDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductComponent oProductComponent = new ProductComponent();
                    oProductComponent.ComponentID = (int)reader["ID"];
                    oProductComponent.TargetQty = Convert.ToInt32(reader["TargetQty"].ToString());
                    oProductComponent.ProductID = (int)reader["ProductID"];
                    oProductComponent.ProductCode = (string)reader["ProductCode"];
                    oProductComponent.ProductName = (string)reader["ProductName"];
                    oProductComponent.CreateDate = Convert.ToDateTime(reader["TargetDate"].ToString());

                    InnerList.Add(oProductComponent);
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




