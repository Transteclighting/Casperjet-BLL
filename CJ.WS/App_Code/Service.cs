using System;
using System.Web.Services;
using System.Collections;

using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Class.Web.UI.Class;
using CJ.Class.DataTransfer;
using CJ.Class.ANDROID;
using CJ.Class.DMS;
using CJ.Class.Promotion;
using CJ.Class.BEIL;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Service : System.Web.Services.WebService
{
    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }


    // Test Chat WEB Service
    static protected ArrayList arrUsers = new ArrayList();
    static protected ArrayList arrMessage = new ArrayList();   
    [WebMethod]
    public string GetUsers()
    {
        string strUser = string.Empty;
        for (int i = 0; i < arrUsers.Count; i++)
        {
            strUser = strUser + arrUsers[i].ToString() + "|";
        }
        return strUser;
    }

    [WebMethod]
    public void AddUser(string strUser)
    {
        bool bFlag = false;
        for (int i = 0; i < arrUsers.Count; i++)
        {
            if (arrUsers[i].ToString() == strUser)
                bFlag = true;
            else
                SendMessage("Ser@ver", arrUsers[i].ToString(), strUser + " has logged in.");
        }
        if (bFlag == false)
            arrUsers.Add(strUser);
    }

    [WebMethod]
    public void RemoveUser(string strUser)
    {
        for (int i = 0; i < arrUsers.Count; i++)
        {
            if (arrUsers[i].ToString() == strUser)
                arrUsers.RemoveAt(i);
        }
    }

    [WebMethod]
    public void SendMessage(string strFromUser, string strToUser, string strMess)
    {
        arrMessage.Add(strToUser + ":" + strFromUser + ":" + strMess);
    }

    [WebMethod]
    public string ReceiveMessage(string strUser)
    {
        string strMess = string.Empty;
        for (int i = 0; i < arrMessage.Count; i++)
        {
            string[] strTo = arrMessage[i].ToString().Split(':');
            if (strTo[0].ToString() == strUser)
            {
                for (int j = 1; j < strTo.Length; j++)
                {
                    strMess = strMess + strTo[j] + ":";
                }
                arrMessage.RemoveAt(i);
                break;
            }
        }
        return strMess;
    }
    /// END 




    [WebMethod]
    public bool A_TigerPart(string sName, string sAddress, DateTime dDateOfBirth)
    {
        bool bFlag = false;
        DataTransfer oDataTransfer = new DataTransfer();
        bFlag = oDataTransfer.InsertTest(sName, sAddress, dDateOfBirth);
        return bFlag;
    }

    [WebMethod]
    public bool IsAuthenticated(string sUserName, string sPassword)
    {
        //if (sUserName == "arifkhan" && sPassword == "Asdf1234")
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}


        User oUser = new User();

        DBController.Instance.OpenNewConnection();

        if (oUser.authenticate(sUserName) != false)
        {
            PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);

            string sHashValue = mph.CreateHash(sPassword, oUser.Salt);
            if (oUser.UserPassword.CompareTo(sHashValue) != 0)
            {
                return false;
            }
            else
            {
                ReportLog oReportLog = new ReportLog();
                oReportLog.ReportCode = "00001";
                oReportLog.ReportName = "SaleInfoTML(Android)";
                oReportLog.UserName = sUserName;
                oReportLog.InsertTMLDB();

                return true;

            }
        }
        else
        {
            return false;
        }

    }

    // User
    [WebMethod]
    public DSUser PosAuthenticate(DSUser oDSUser)
    {
        User oUser;
        oUser = new User();

        DBController.Instance.OpenNewConnection();
        oDSUser = oUser.PosAuthenticate(oDSUser);
        DBController.Instance.CloseConnection();

        return oDSUser;

    }
    [WebMethod]
    public DSPermission GetAllPermission(DSPermission oDSPermission, int nUserID)
    {
        Users oUsers;
        oUsers = new Users();

        DBController.Instance.OpenNewConnection();
        oDSPermission = oUsers.POSGetAllPermission(oDSPermission, nUserID);
        DBController.Instance.CloseConnection();

        return oDSPermission;

    }

    // Warehouse
    [WebMethod]
    public DSWarehouse GelAllWarehouse(DSWarehouse oDSWarehouse)
    {
        Warehouses oWarehouses;
        oWarehouses = new Warehouses();

        DBController.Instance.OpenNewConnection();
        oDSWarehouse = oWarehouses.POSGetAllWarehouse(oDSWarehouse);
        DBController.Instance.CloseConnection();

        return oDSWarehouse;

    }
    [WebMethod]
    public DSWarehouse FromWarehouse(DSWarehouse oDSWarehouse)
    {
        Warehouses oWarehouses;
        oWarehouses = new Warehouses();

        DBController.Instance.OpenNewConnection();
        oDSWarehouse = oWarehouses.POSGetWarehouse(oDSWarehouse);
        DBController.Instance.CloseConnection();

        return oDSWarehouse;

    }
    [WebMethod]
    public int GetParentWarehouse(int nWarehouseID)
    {
        Warehouse oWarehouse;
        oWarehouse = new Warehouse();

        DBController.Instance.OpenNewConnection();
        int _nWarehouseParentID = oWarehouse.POSGetParentWarehouse(nWarehouseID);
        DBController.Instance.CloseConnection();

        return _nWarehouseParentID;

    }
    [WebMethod]
    public DSWarehouse ToWarehouse(DSWarehouse oDSWarehouse, string sWarehouseID)
    {
        Warehouses oWarehouses;
        oWarehouses = new Warehouses();

        DBController.Instance.OpenNewConnection();
        oDSWarehouse = oWarehouses.POSGetToWarehouse(oDSWarehouse, sWarehouseID);
        DBController.Instance.CloseConnection();

        return oDSWarehouse;

    }

    // Stock
    [WebMethod]
    public DSStock GetCurrentStock(DSStock oDSStock, int nWarehouseID, int nProductID, bool IsAuthorize)
    {
        WUIUtility _oWUIUtility;
        _oWUIUtility = new WUIUtility();

        DBController.Instance.OpenNewConnection();
        oDSStock = _oWUIUtility.GetPOSCurrentStock(oDSStock, nWarehouseID, nProductID, IsAuthorize);
        DBController.Instance.CloseConnection();

        return oDSStock;

    }
    [WebMethod]
    public int GetYTDSalesQty(int nWarehouseID, int nProductID)
    {
        WUIUtility _oWUIUtility;
        _oWUIUtility = new WUIUtility();

        DBController.Instance.OpenNewConnection();
        int _YTDSalesQty = _oWUIUtility.GetPOSYTDSalesQty(nWarehouseID, nProductID);
        DBController.Instance.CloseConnection();

        return _YTDSalesQty;

    }

    /// Product   

    [WebMethod]
    public DSProductGroups GetAllProductGroup(DSProductGroups oDSProductGroups)
    {
        ProductGroups oProductGroups;
        oProductGroups = new ProductGroups();

        DBController.Instance.OpenNewConnection();
        oDSProductGroups = oProductGroups.POSGetAllProductGroup(oDSProductGroups);
        DBController.Instance.CloseConnection();

        return oDSProductGroups;
    }
    [WebMethod]
    public DSProduct GetAllProduct(DSProduct oDSProduct)
    {
        ProductDetails _oProductDetails;
        _oProductDetails = new ProductDetails();

        DBController.Instance.OpenNewConnection();
        oDSProduct = _oProductDetails.POSGetProductDetail(oDSProduct);
        DBController.Instance.CloseConnection();

        return oDSProduct;

    }
    [WebMethod]
    public DSProduct GetProductDetail(DSProduct oDSProduct, string sProductCode)
    {
        ProductDetail _oProductDetail;
        _oProductDetail = new ProductDetail();

        DBController.Instance.OpenNewConnection();
        oDSProduct = _oProductDetail.POSGetProductDetail(oDSProduct, sProductCode);
        DBController.Instance.CloseConnection();

        return oDSProduct;

    }
    [WebMethod]
    public DSBrand GetProductBarnd(DSBrand oDSBrand)
    {
        Brands oBrands;
        oBrands = new Brands();

        DBController.Instance.OpenNewConnection();
        oDSBrand = oBrands.POSGetBrand(oDSBrand);
        DBController.Instance.CloseConnection();

        return oDSBrand;

    }

    //Requisition
    [WebMethod]
    public DSRequisition InsertRequisition(DSRequisition oDSRequisition)
    {

        POSRequisition oPOSRequisition;
        oPOSRequisition = new POSRequisition();

        oDSRequisition = oPOSRequisition.POSInsert(oDSRequisition);

        return oDSRequisition;

    }
    [WebMethod]
    public DSRequisition UpdateRequisition(DSRequisition oDSRequisition)
    {

        POSRequisition oPOSRequisition;
        oPOSRequisition = new POSRequisition();

        oDSRequisition = oPOSRequisition.POSUpdate(oDSRequisition);

        return oDSRequisition;

    }
    [WebMethod]
    public DSRequisition DeleteRequisition(DSRequisition oDSRequisition)
    {

        POSRequisition oPOSRequisition;
        oPOSRequisition = new POSRequisition();

        oDSRequisition = oPOSRequisition.POSDelete(oDSRequisition);

        return oDSRequisition;

    }
    [WebMethod]
    public DSRequisition RequisitionRefresh(DSRequisition oDSRequisition, DSDataRange oDSDataRange, bool IsAuthrize, bool IsTransfer)
    {
        POSRequisitions oPOSRequisitions;
        oPOSRequisitions = new POSRequisitions();

        DBController.Instance.OpenNewConnection();
        oDSRequisition = oPOSRequisitions.POSRefresh(oDSRequisition, oDSDataRange, IsAuthrize, IsTransfer);
        DBController.Instance.CloseConnection();

        return oDSRequisition;
    }
    [WebMethod]
    public DSRequisition RequisitionRefreshItem(DSRequisition oDSRequisitionItem, int nRequisitionID)
    {
        POSRequisition oPOSRequisition;
        oPOSRequisition = new POSRequisition();

        DBController.Instance.OpenNewConnection();
        oDSRequisitionItem = oPOSRequisition.POSRefreshItem(oDSRequisitionItem, nRequisitionID);
        DBController.Instance.CloseConnection();

        return oDSRequisitionItem;
    }
    [WebMethod]
    public DSRequisition RequisitionAuthorize(DSRequisition oDSRequisition, int nUserID)
    {

        POSRequisition oPOSRequisition;
        oPOSRequisition = new POSRequisition();

        oDSRequisition = oPOSRequisition.POSAuthorize(oDSRequisition, nUserID);


        return oDSRequisition;

    }
    [WebMethod]
    public DSRequisition ProductStockTranInsert(DSRequisition oDSRequisition, DSRequisition oDSRequisitionItem, DSBarcodeDetail oDSBarcodeDetail, int nUserID, bool IsProductSerialSkip)
    {

        ProductTransaction oProductTransaction;
        oProductTransaction = new ProductTransaction();

        oDSRequisition = oProductTransaction.POSTransferOut(oDSRequisition, oDSRequisitionItem, oDSBarcodeDetail, nUserID, IsProductSerialSkip);

        return oDSRequisition;

    }
    [WebMethod]
    public DSRequisition GoodsReceived(DSRequisition oDSRequisition, DSRequisition oDSRequisitionItem, int nUserID)
    {
        ProductTransaction oProductTransaction;
        oProductTransaction = new ProductTransaction();

        oDSRequisition = oProductTransaction.POSGoodsReceived(oDSRequisition, oDSRequisitionItem, nUserID);

        return oDSRequisition;

    }
    [WebMethod]
    public DSRequisition GoodsRetrun(DSRequisition oDSRequisition)
    {
        ProductTransaction oProductTransaction;
        oProductTransaction = new ProductTransaction();
        oDSRequisition = oProductTransaction.POSGoodsRetrun(oDSRequisition);

        return oDSRequisition;

    }
    [WebMethod]
    public DSProductTransaction GetProductTransaction(DSProductTransaction oDSProductTransaction, int nTranID, int nEmployeeId)
    {
        ProductTransaction oProductTransaction;
        oProductTransaction = new ProductTransaction();
        DBController.Instance.OpenNewConnection();
        oDSProductTransaction = oProductTransaction.POSGetProductTransactionReport(oDSProductTransaction, nTranID, nEmployeeId);
        DBController.Instance.CloseConnection();

        return oDSProductTransaction;
    }
    [WebMethod]
    public DSRequisition AuthorizePrint(DSRequisition oDSRequisition)
    {

        POSRequisition oPOSRequisition;
        oPOSRequisition = new POSRequisition();
        DBController.Instance.OpenNewConnection();
        oDSRequisition = oPOSRequisition.POSAuthorizeReport(oDSRequisition);
        DBController.Instance.CloseConnection();
        return oDSRequisition;

    }

    // ISGM
    [WebMethod]
    public DSISGM InsertISGM(DSISGM oDSISGM, DSBarcode oDSBarcode)
    {
        ProductISGM oProductISGM;
        oProductISGM = new ProductISGM();
        oDSISGM = oProductISGM.POSInsert(oDSISGM, oDSBarcode);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM UpdateISGM(DSISGM oDSISGM, DSBarcode oDSBarcode, DSISGM oDSSelectedISGM)
    {
        ProductISGM oProductISGM;
        oProductISGM = new ProductISGM();
        oDSISGM = oProductISGM.POSUpdate(oDSISGM, oDSBarcode, oDSSelectedISGM);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM UpdateISGMStatus(DSISGM oDSISGM)
    {
        ProductISGM oProductISGM;
        oProductISGM = new ProductISGM();
        oDSISGM = oProductISGM.POSUpdateStatus(oDSISGM);
        return oDSISGM;
    }
    [WebMethod]
    public DSISGM UpdateISGMTransferStatus(DSISGM oDSISGM, DSISGM oDSSelectedISGM)
    {
        ProductISGM oProductISGM;
        oProductISGM = new ProductISGM();
        oDSISGM = oProductISGM.POSUpdateTransferStatus(oDSISGM, oDSSelectedISGM);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM DeleteISGM(DSISGM oDSISGM, DSISGM oDSSelectedISGM)
    {
        ProductISGM oProductISGM;
        oProductISGM = new ProductISGM();
        oDSISGM = oProductISGM.POSDelete(oDSISGM, oDSSelectedISGM);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM ISGMAuthorize(DSISGM oDSISGM, DSISGM oDSSelectedISGM, int nUserID)
    {
        ProductTransaction oProductTransaction;
        oProductTransaction = new ProductTransaction();
        oDSISGM = oProductTransaction.POSISGMAuthorize(oDSISGM, oDSSelectedISGM, nUserID);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM CancelAuthorizeISGM(DSProductTransaction oDSProductTransaction, DSISGM oDSISGM, int nUserID)
    {
        ProductTransaction oProductTransaction;
        oProductTransaction = new ProductTransaction();
        oDSISGM = oProductTransaction.POSCancelAuthorizeISGM(oDSProductTransaction, oDSISGM, nUserID);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM ISGMCancel(DSISGM oDSISGM, DSISGM oDSSelectedISGM, int nUserID)
    {
        ProductISGM oProductISGM;
        oProductISGM = new ProductISGM();
        oDSISGM = oProductISGM.POSISGMCancel(oDSISGM, oDSSelectedISGM, nUserID);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM ISGMRefresh(DSISGM oDSISGM, DSDataRange oDSDataRange, string sISGMNo, int nStatus, int nWarehouseID, bool IsAdmin)
    {
        ProductISGMList oProductISGMList;
        oProductISGMList = new ProductISGMList();
        oDSISGM = oProductISGMList.POSRefresh(oDSISGM, oDSDataRange, sISGMNo, nStatus, nWarehouseID, IsAdmin);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM ISGMRefreshForSendReceived(DSISGM oDSISGM, DSDataRange oDSDataRange, string sISGMNo, int nStatus, int nWarehouseID)
    {
        ProductISGMList oProductISGMList;
        oProductISGMList = new ProductISGMList();
        oDSISGM = oProductISGMList.POSRefreshForSendReceived(oDSISGM, oDSDataRange, sISGMNo, nStatus, nWarehouseID);

        return oDSISGM;
    }
    [WebMethod]
    public DSISGM ISGMItemRefresh(DSISGM oDSISGM, int nISGMID, int nWarehouseID)
    {
        ProductISGM oProductISGM;
        oProductISGM = new ProductISGM();
        DBController.Instance.OpenNewConnection();
        oDSISGM = oProductISGM.POSRefreshItem(oDSISGM, nISGMID, nWarehouseID);
        DBController.Instance.CloseConnection();
        return oDSISGM;
    }
    [WebMethod]
    public DSProductTransaction GetISGMProductTransaction(DSProductTransaction oDSProductTransaction, int nTranID)
    {
        ProductTransaction oProductTransaction;
        oProductTransaction = new ProductTransaction();
        DBController.Instance.OpenNewConnection();
        oDSProductTransaction = oProductTransaction.POSGetISGMProductTransaction(oDSProductTransaction, nTranID);
        DBController.Instance.CloseConnection();

        return oDSProductTransaction;
    }
    [WebMethod]
    public DSISGM ISGMPrint(DSISGM oDSISGM, int nISGMID, int nStatus)
    {
        ProductISGM oProductISGM;
        oProductISGM = new ProductISGM();
        DBController.Instance.OpenNewConnection();
        oDSISGM = oProductISGM.POSRefresh(oDSISGM, nISGMID, nStatus);
        DBController.Instance.CloseConnection();
        return oDSISGM;
    }

    //Barcode
    [WebMethod]
    public DSBarcodeDetail BarcodeValidation(DSBarcodeDetail oDSBarcodeDetail)
    {
        ProductBarcode oProductBarcode;
        oProductBarcode = new ProductBarcode();

        DBController.Instance.OpenNewConnection();
        oDSBarcodeDetail = oProductBarcode.POSBarcodeValidation(oDSBarcodeDetail);
        DBController.Instance.CloseConnection();

        return oDSBarcodeDetail;
    }

    #region Data Download
    [WebMethod]
    public DSRequisition DownloadStockRequisition(DSRequisition oDSRequisition, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSRequisition = oDataTransfer.GetDSRequisition(oDSRequisition, nWarehouseID);
        return oDSRequisition;
    }
    [WebMethod]
    public void UpdateStockRequisitionInfo(DSRequisition oDSRequisition, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateStockRequisitionInfo(oDSRequisition, nWarehouseID);
    }

    ///
    // Data Download
    //
    /// <summary>
    /// Receivable Data (for download list view)
    /// </summary> 

    [WebMethod]
    public DSReceivableData DownloadReceivableData(DSReceivableData oDSReceivableData, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSReceivableData = oDataTransfer.GetReceivableData(oDSReceivableData, nWarehouseID);
        return oDSReceivableData;
    }


    [WebMethod]
    public DSReceivableData DownloadReceivableDataFactory(DSReceivableData oDSReceivableData, int nLocationID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSReceivableData = oDataTransfer.GetReceivableDataFactory(oDSReceivableData, nLocationID);
        return oDSReceivableData;
    }
    /// <summary>
    /// Receivable Data group by (download loop)
    /// </summary> 

    [WebMethod]
    public DSReceivableData DownloadReceivableDataGroupBy(DSReceivableData oDSReceivableData, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSReceivableData = oDataTransfer.GetReceivableDataGroupBy(oDSReceivableData, nWarehouseID);
        return oDSReceivableData;
    }
    [WebMethod]
    public DSReceivableData DownloadReceivableFactoryDataGroupBy(DSReceivableData oDSReceivableData, int nLocationID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSReceivableData = oDataTransfer.GetReceivableFactoryDataGroupBy(oDSReceivableData, nLocationID);
        return oDSReceivableData;
    }
    /// <summary>
    /// Product Stock
    /// </summary> 

    [WebMethod]
    public DSStock DownloadDSStock(DSStock oDSStock, int nWHID, int nCentralWHID, int nAGID, int nASGID, int nMAGID, int nBrandID, string sProductCode, string sProductName)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSStock = oDataTransfer.GetDSStock(oDSStock, nWHID, nCentralWHID, nAGID, nASGID, nMAGID, nBrandID, sProductCode, sProductName);
        return oDSStock;
    }
    /// <summary>
    /// Product
    /// </summary> 

    [WebMethod]
    public DSProduct DownloadProduct(DSProduct oDSProduct, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSProduct = oDataTransfer.GetPtoduct(oDSProduct, nWarehouseID);
        return oDSProduct;
    }


    [WebMethod]
    public DSProduct DownloadProductFactory(DSProduct oDSProduct, int nLocationID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSProduct = oDataTransfer.GetPtoductFactory(oDSProduct, nLocationID);
        return oDSProduct;
    }


    [WebMethod]
    public DSProductComponent DownloadProductComponentFactory(DSProductComponent oDSProductComponent, int nLocationID,string sTableName)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSProductComponent = oDataSend.GetDataForFactory(oDSProductComponent, nLocationID, sTableName);
        return oDSProductComponent;
    }


    [WebMethod]
    public void UpdateProductComponentFactory(DSProductComponent oDSProductComponent, int nLocationID, string sTableName)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDataSend.UpdateFactoryDataTransfer(oDSProductComponent, nLocationID, sTableName);
    }

    /// <summary>
    /// Product
    /// </summary> 

    [WebMethod]
    public DSProduct DownloadProductFeatureType(DSProduct oDSProductFeatureType, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSProductFeatureType = oDataTransfer.GetProductFeatureType(oDSProductFeatureType, nWarehouseID);
        return oDSProductFeatureType;
    }

    [WebMethod]
    public DSBasicData DownloadNewVatActivation(DSBasicData oDSNewVatActivation, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSNewVatActivation = oDataTransfer.GetNewVatActivation(oDSNewVatActivation, nWarehouseID);
        return oDSNewVatActivation;
    }

    [WebMethod]
    public DSBank DownloadBankGuaranty(DSBank oDSBankGuaranty, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSBankGuaranty = oDataTransfer.GetBankGuaranty(oDSBankGuaranty, nWarehouseID);
        return oDSBankGuaranty;
    }
    [WebMethod]
    public DateTime GetServerDatetime()
    {
        DateTime dt = DateTime.Now;
        DataTransfer oDataTransfer = new DataTransfer();
        dt = oDataTransfer.GetServerDatetime();
        return dt;
    }

    [WebMethod]
    public int GetIsCheckServerDateTime(int nWarehouseID)
    {
        int dt = 0;
        DataTransfer oDataTransfer = new DataTransfer();
        dt = oDataTransfer.GetIsCheckServerDateTime(nWarehouseID);
        return dt;
    }

    [WebMethod]
    public DSCustomer DownloadCustomerAccount(DSCustomer oDSCustomerAccount, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomerAccount = oDataTransfer.GetCustomerAccount(oDSCustomerAccount, nWarehouseID);
        return oDSCustomerAccount;
    }

    [WebMethod]
    public DSBasicData DownloadTDActivation(DSBasicData oDSTDActivation, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSTDActivation = oDataTransfer.GetTDActivationData(oDSTDActivation, nWarehouseID);
        return oDSTDActivation;
    }
    [WebMethod]
    public DSBasicData DownloadPettyCashExpenseHead(DSBasicData oDSPettyCashExpenseHead, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPettyCashExpenseHead = oDataTransfer.GetPettyCashExpenseHead(oDSPettyCashExpenseHead, nWarehouseID);
        return oDSPettyCashExpenseHead;
    }
    [WebMethod]
    public void UpdateTDActivation(DSBasicData oDSTDActivation, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateTDActivationInfo(oDSTDActivation, nWarehouseID);
    }
    [WebMethod]
    public void UpdatePettyCashExpenseHead(DSBasicData oDSPettyCashExpenseHead, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateoDSPettyCashExpenseHeadInfo(oDSPettyCashExpenseHead, nWarehouseID);
    }
    [WebMethod]
    public DSBasicData DownloadPromoDiscountSpecialAuthority(DSBasicData oDSPromoDiscountSpecialAuthority, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromoDiscountSpecialAuthority = oDataTransfer.GetPromoDiscountSpecialAuthority(oDSPromoDiscountSpecialAuthority, nWarehouseID);
        return oDSPromoDiscountSpecialAuthority;
    }

    [WebMethod]
    public void UpdatePromoDiscountSpecialAuthority(DSBasicData oDSPromoDiscountSpecialAuthority, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePromoDiscountSpecialAuthority(oDSPromoDiscountSpecialAuthority, nWarehouseID);
    }


    [WebMethod]
    public DSOutletDisplayPosition DownloadOutletDisplayPositionRack(DSOutletDisplayPosition oDSOutletDisplayPositionRack, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSOutletDisplayPositionRack = oDataTransfer.GetOutletDisplayPositionRack(oDSOutletDisplayPositionRack, nWarehouseID);
        return oDSOutletDisplayPositionRack;
    }

    [WebMethod]
    public void UpdateOutletDisplayPositionRack(DSOutletDisplayPosition oDSOutletDisplayPositionRack, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateOutletDisplayPositionRack(oDSOutletDisplayPositionRack, nWarehouseID);
    }

    [WebMethod]
    public void UpdateProductTransferInfo(DSProduct oDSProduct, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateProductTransferInfo(oDSProduct, nWarehouseID);
    }

    [WebMethod]
    public void UpdateProductTransferInfoFactory(DSProduct oDSProduct, int nLocationID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateProductTransferInfoFactory(oDSProduct, nLocationID);
    }

    [WebMethod]
    public void UpdateProductFeatureTypeTransferInfo(DSProduct oDSProductFeatureType, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateProductFeatureTypeTransferInfo(oDSProductFeatureType, nWarehouseID);
    }

    [WebMethod]
    public void UpdateNewVatActivationInfo(DSBasicData oDSNewVatActivation, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateNewVatActivationInfo(oDSNewVatActivation, nWarehouseID);
    }
    [WebMethod]
    public void UpdateBankGuarantyInfo(DSBank oDSBankGuaranty, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateBankGuarentyInfo(oDSBankGuaranty, nWarehouseID);
    }

    [WebMethod]
    public void UpdateCustomerBalanceInfo(DSCustomer oDSCustomerAccount, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateCustomerAccountInfo(oDSCustomerAccount, nWarehouseID);
    }

    /// <summary>
    /// Employee
    /// </summary> 

    [WebMethod]
    public DSEmployee DownloadEmployee(DSEmployee oDSEmployee, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSEmployee = oDataTransfer.GetEmployee(oDSEmployee, nWarehouseID);
        return oDSEmployee;
    }
    [WebMethod]
    public void UpdateEmployeeTransferInfo(DSEmployee oDSEmployee, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateEmployeeTransferInfo(oDSEmployee, nWarehouseID);
    }

    /// <summary>
    /// Warehouse
    /// </summary> 

    [WebMethod]
    public DSWarehouse DownloadWarehouse(DSWarehouse oDSWarehouse, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSWarehouse = oDataTransfer.GetWarehouse(oDSWarehouse, nWarehouseID);
        return oDSWarehouse;
    }
    [WebMethod]
    public void UpdateWarehouseTransferInfo(DSWarehouse oDSWarehouse, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateWarehouseTransferInfo(oDSWarehouse, nWarehouseID);
    }
    /// <summary>
    /// Promotion TD
    /// </summary> 

    [WebMethod]
    public DSPromotion DownloadPromotion(DSPromotion oDSPromotion, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromotion = oDataTransfer.GetPromotion(oDSPromotion, nWarehouseID);
        return oDSPromotion;
    }

    [WebMethod]
    public DSPromotion DownloadSalesPromotionNew(DSPromotion oDSPromotion, int nWarehouseID,string sTableName)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromotion = oDataTransfer.GetSalesPromotionNew(oDSPromotion, nWarehouseID, sTableName);
        return oDSPromotion;
    }

    [WebMethod]
    public DSPromotion DownloadPromoDiscountAllData(DSPromotion oDSPromoDiscount, int nWarehouseID,string sTableName)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromoDiscount = oDataTransfer.GetPromoDiscountAllData(oDSPromoDiscount, nWarehouseID, sTableName);
        return oDSPromoDiscount;
    }
    [WebMethod]
    public void UpdatePromoDiscountAllData(DSPromotion oDSPromotion, int nWarehouseID,string sTableName)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePromoDiscountAllData(oDSPromotion, nWarehouseID, sTableName);
    }
    /// <summary>
    /// Promotion Other then TD
    /// </summary> 

    [WebMethod]
    public DSPromotion DownloadPromotionOtherThenTD(DSPromotion oDSPromotion, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromotion = oDataTransfer.GetPromotionOtherThenTD(oDSPromotion, nWarehouseID);
        return oDSPromotion;
    }

    [WebMethod]
    public void UpdatePromotionTransferInfo(DSPromotion oDSPromotion, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePromotionTransferInfo(oDSPromotion, nWarehouseID);
    }


    [WebMethod]
    public void UpdateSalesPromoTransferInfoNew(DSPromotion oDSPromotion, int nWarehouseID,string sTableName)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePromotionTransferInfoNew(oDSPromotion, nWarehouseID, sTableName, null);
    }

    /// <summary>
    /// Barcode
    /// </summary> 

    [WebMethod]
    public DSBarcode DownloadBarcode(DSBarcode oDSBarcode, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSBarcode = oDataTransfer.GetBarcode(oDSBarcode, nWarehouseID);
        return oDSBarcode;
    }
    /// <summary>
    /// Bank
    /// </summary> 

    [WebMethod]
    public DSBank DownloadBank(DSBank oDSBank, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSBank = oDataTransfer.GetBank(oDSBank, nWarehouseID);
        return oDSBank;
    }

    [WebMethod]
    public void UpdateBankTransferInfo(DSBank oDSBank, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateBankTransferInfo(oDSBank, nWarehouseID);
    }

    /// <summary>
    /// UnSold Defective Product
    /// </summary> 

    [WebMethod]
    public DSUnsoldDefectiveProduct DownloadUnsoldDefectiveProduct(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSUnsoldDefectiveProduct = oDataTransfer.GetUnsoldDefectiveProduct(oDSUnsoldDefectiveProduct, nWarehouseID);
        return oDSUnsoldDefectiveProduct;
    }
    /// <summary>
    /// UnSold Defective Product
    /// </summary> 

    [WebMethod]
    public DSUnsoldDefectiveProduct DownloadUnsoldDefectiveProductNew(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSUnsoldDefectiveProduct = oDataTransfer.GetUnsoldDefectiveProductNew(oDSUnsoldDefectiveProduct, nWarehouseID);
        return oDSUnsoldDefectiveProduct;
    }
    [WebMethod]
    public void UpdateUnsoldDefectiveProductInfo(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateUnsoldDefectiveInfo(oDSUnsoldDefectiveProduct, nWarehouseID);
    }
    [WebMethod]
    public void UpdateUnsoldDefectiveProductInfoNew(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateUnsoldDefectiveInfoNew(oDSUnsoldDefectiveProduct, nWarehouseID);
    }
    /// <summary>
    /// Showroom
    /// </summary> 

    [WebMethod]
    public DSShowroom DownloadShowroom(DSShowroom oDSShowroom, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSShowroom = oDataTransfer.GetShowroom(oDSShowroom, nWarehouseID);
        return oDSShowroom;
    }
    [WebMethod]
    public void UpdateShowroomTransferInfo(DSShowroom oDSShowroom, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateShowroomTransferInfo(oDSShowroom, nWarehouseID);
    }
    /// <summary>
    /// PaymentMode
    /// </summary> 

    [WebMethod]
    public DSPaymentMode DownloadPaymentMode(DSPaymentMode oDSPaymentMode, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPaymentMode = oDataTransfer.GetPaymentMode(oDSPaymentMode, nWarehouseID);
        return oDSPaymentMode;
    }
    [WebMethod]
    public void UpdatePaymentModeTransferInfo(DSPaymentMode oDSPaymentMode, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePaymentModeTransferInfo(oDSPaymentMode, nWarehouseID);
    }



    [WebMethod]
    public DSTargetvsActual DownloadMAGWeekPositionTargetvsActual(DSTargetvsActual oDSTargetvsActual, int nWarehouseID, int TMonth, int TYear, int WeekNo, string sSalesPersonCode, string sType)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSTargetvsActual = oDataTransfer.GetMAGWeekPositionTargetvsActual(oDSTargetvsActual, nWarehouseID, TMonth, TYear, WeekNo, sSalesPersonCode, sType);
        return oDSTargetvsActual;
    }

    /// <summary>
    /// Sales Promotion Type
    /// </summary> 


    [WebMethod]
    public DSPromoDiscount SendPromoDiscount(DSPromoDiscount oDSPromoDiscount, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromoDiscount = oDataTransfer.InsertPromoDiscount(oDSPromoDiscount, nWHID);
        return oDSPromoDiscount;

    }
    [WebMethod]
    public DSSalesPromotionType DownloadDSSalesPromotionType(DSSalesPromotionType oDSSalesPromotionType, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSalesPromotionType = oDataTransfer.GetSalesPromotionType(oDSSalesPromotionType, nWarehouseID);
        return oDSSalesPromotionType;
    }
    [WebMethod]
    public void UpdateSalesPromotionTypeInfo(DSSalesPromotionType oDSSalesPromotionType, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateSalesPromotionTransferInfo(oDSSalesPromotionType, nWarehouseID);
    }

    /// <summary>
    /// Discount Reason
    /// </summary> 

    [WebMethod]
    public DSDiscountReason DownloadDiscountReason(DSDiscountReason oDSDiscountReason, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSDiscountReason = oDataTransfer.GetDiscountReason(oDSDiscountReason, nWarehouseID);
        return oDSDiscountReason;
    }
    [WebMethod]
    public void UpdateDiscountReasonTransferInfo(DSDiscountReason oDSDiscountReason, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateDiscountReasonTransferInfo(oDSDiscountReason, nWarehouseID);
    }

    [WebMethod]
    public void UpdateBarcodeTransferInfo(DSBarcode oDSBarcode, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateBarcodeTransferInfo(oDSBarcode, nWarehouseID);
    }
    /// <summary>
    /// Warranty
    /// </summary> 

    [WebMethod]
    public DSWarranty DownloadWarranty(DSWarranty oDSWarranty, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSWarranty = oDataTransfer.GetWarranty(oDSWarranty, nWarehouseID);
        return oDSWarranty;
    }
    [WebMethod]
    public void UpdateWarrantyTransferInfo(DSWarranty oDSWarranty, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateWarrantyTransferInfo(oDSWarranty, nWarehouseID);
    }

    /// <summary>
    /// Retail Consumer
    /// </summary> 

    [WebMethod]
    public DSRetailConsumer DownloadRetailConsumer(DSRetailConsumer oDSRetailConsumer, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSRetailConsumer = oDataTransfer.GetRetailConsumer(oDSRetailConsumer, nWarehouseID);
        return oDSRetailConsumer;
    }
    [WebMethod]
    public void UpdateConsumerTransferInfo(DSRetailConsumer oDSRetailConsumer, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateConsumerTransferInfo(oDSRetailConsumer, nWarehouseID);
    }

    /// <summary>
    /// Product Group
    /// </summary> 

    [WebMethod]
    public DSProductGroups DownloadProductGroup(DSProductGroups oDSProductGroups, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSProductGroups = oDataTransfer.GetPtoductGroup(oDSProductGroups, nWarehouseID);
        return oDSProductGroups;
    }
    [WebMethod]
    public void UpdateProductGroupTransferInfo(DSProductGroups oDSProductGroups, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateProductGroupTransferInfo(oDSProductGroups, nWarehouseID);
    }

    /// <summary>
    /// Product Brand
    /// </summary> 

    [WebMethod]
    public DSBrand DownloadProductBrand(DSBrand oDSBrand, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSBrand = oDataTransfer.GetPtoductBrand(oDSBrand, nWarehouseID);
        return oDSBrand;
    }
    [WebMethod]
    public void UpdateProductBrandTransferInfo(DSBrand oDSBrand, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateProductBrandTransferInfo(oDSBrand, nWarehouseID);
    }

    /// <summary>
    /// This System
    /// </summary> 

    [WebMethod]
    public DSThisSystem DownloadThisSystem(DSThisSystem oDSThisSystem, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSThisSystem = oDataTransfer.GetThisSystem(oDSThisSystem, nWarehouseID);
        return oDSThisSystem;
    }
    [WebMethod]
    public void UpdateThisSystmeInfo(DSThisSystem oDSThisSystem, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateThisSystemInfo(oDSThisSystem, nWarehouseID);
    }
    /// <summary>
    /// CLP
    /// </summary> 
    [WebMethod]
    public DSCLP DownloadCLP(DSCLP oDSCLP, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCLP = oDataTransfer.GetCLP(oDSCLP, nWarehouseID);
        return oDSCLP;
    }

    /// <summary>
    /// Download Product stock tran Type
    /// </summary> 

    [WebMethod]
    public DSProductTransactionType DownloadProductTranType(DSProductTransactionType oDSProductTransactionType, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSProductTransactionType = oDataTransfer.GetProductStockTranType(oDSProductTransactionType, nWarehouseID);
        return oDSProductTransactionType;
    }
    [WebMethod]
    public void UpdateProductTranTypeTransferInfo(DSProductTransactionType oDSProductTransactionType, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateProductTranTypeInfo(oDSProductTransactionType, nWarehouseID);
    }



    [WebMethod]
    public DSBasicData DownloadTDDeliveryShipment(DSBasicData oDSTDDeliveryShipment, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSTDDeliveryShipment = oDataTransfer.GetTDDeliveryShipment(oDSTDDeliveryShipment, nWarehouseID);
        return oDSTDDeliveryShipment;
    }

    [WebMethod]
    public void UpdateTDDeliveryShipmentData(DSBasicData oDSTDDeliveryShipment, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateTDDeliveryShipmentInfo(oDSTDDeliveryShipment, nWarehouseID);
    }


    [WebMethod]
    public DSPettyCash DownloadPettyCashExpense(DSPettyCash oDSPettyCashExpense, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPettyCashExpense = oDataTransfer.GetPettyCashExpense(oDSPettyCashExpense, nWarehouseID);
        return oDSPettyCashExpense;
    }


    [WebMethod]
    public DSPromoExchangeOffer DownloadPromoExchgangeOffer(DSPromoExchangeOffer oDSPromoExchgangeOffer, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromoExchgangeOffer = oDataTransfer.GetPromoExchangeOffer(oDSPromoExchgangeOffer, nWarehouseID);
        return oDSPromoExchgangeOffer;
    }

    [WebMethod]
    public DSPromoWarranty DownloadPromoWarranty(DSPromoWarranty oDSPromoWarranty, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromoWarranty = oDataTransfer.GetPromoWarranty(oDSPromoWarranty, nWarehouseID);
        return oDSPromoWarranty;
    }

    [WebMethod]
    public DSSalesOrder DownloadDMSSalesOrder(DSSalesOrder oDSSalesOrder, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSalesOrder = oDataTransfer.GetDMSSalesOrder(oDSSalesOrder, nWarehouseID);
        return oDSSalesOrder;
    }
    [WebMethod]
    public void UpdateDMSSalesOrderData(DSSalesOrder oDSSalesOrder, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateDMSSalesOrder(oDSSalesOrder, nWarehouseID);
    }
    [WebMethod]
    public void UpdatePettyCashExpenseData(DSPettyCash oDSPettyCashExpense, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePettyCashExpenseInfo(oDSPettyCashExpense, nWarehouseID);
    }
    [WebMethod]
    public void UpdatePromoExchangeOfferData(DSPromoExchangeOffer oDSPromoExchangeOffer, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateExchangeOfferInfo(oDSPromoExchangeOffer, nWarehouseID);
    }
    [WebMethod]
    public void UpdatePromoWarranty(DSPromoWarranty oDSPromoWarranty, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePromoWarrantyInfo(oDSPromoWarranty, nWarehouseID);
    }

    /// <summary>
    /// Download Product stock tran
    /// </summary> 

    [WebMethod]
    public DSProductTransaction DownloadProductTran(DSProductTransaction oDSProductTransaction, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSProductTransaction = oDataTransfer.GetProductStockTran(oDSProductTransaction, nWarehouseID);
        return oDSProductTransaction;
    }
    /// <summary>
    /// Download Product stock tran with IMEI
    /// </summary> 

    [WebMethod]
    public DSProductTransaction DownloadProductTranWithIMEI(DSProductTransaction oDSProductTransaction, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSProductTransaction = oDataTransfer.GetProductStockTranWithIMEI(oDSProductTransaction, nWarehouseID);
        return oDSProductTransaction;
    }
    [WebMethod]
    public void UpdateProductTranTransferInfo(DSProductTransaction oDSProductTransaction, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateProductTranInfo(oDSProductTransaction, nWarehouseID);
    }

    /// <summary>
    /// Download User
    /// </summary> 

    [WebMethod]
    public DSUser DownloadUser(DSUser oDSUser, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSUser = oDataTransfer.GetUser(oDSUser, nWarehouseID);
        return oDSUser;
    }
    [WebMethod]
    public void UpdateUserTransferInfo(DSUser oDSUser, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateUserTransferInfo(oDSUser, nWarehouseID);
    }

    /// <summary>
    /// Download Product stock 
    /// </summary> 
    [WebMethod]
    public DSStock DownloadProductStock(DSStock oDSStock)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSStock = oDataTransfer.GetProductStock(oDSStock);
        return oDSStock;
    }
    /// <summary>
    /// Download Product stock 
    /// </summary> 
    [WebMethod]
    public DSStock DownloadProductStockAll(DSStock oDSStock)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSStock = oDataTransfer.GetProductStockAll(oDSStock);
        return oDSStock;
    }

    /// <summary>
    /// Download SBU
    /// </summary> 
    [WebMethod]
    public DSSBU DownloadSBU(DSSBU oDSSBU)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSBU = oDataTransfer.GetSBU(oDSSBU);
        return oDSSBU;
    }
    /// <summary>
    /// Download Channel
    /// </summary> 
    [WebMethod]
    public DSChannel DownloadChannel(DSChannel oDSChannel)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSChannel = oDataTransfer.GetChannel(oDSChannel);
        return oDSChannel;
    }
    /// <summary>
    /// Download Customer Type
    /// </summary> 
    [WebMethod]
    public DSCustomerType DownloadCustomerType(DSCustomerType oDSCustomerType,int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomerType = oDataTransfer.GetCustomerType(oDSCustomerType, nWHID);
        return oDSCustomerType;
    }
    /// <summary>
    /// Download Market Group
    /// </summary> 
    [WebMethod]
    public DSMarketGroup DownloadMarketGroup(DSMarketGroup oDSMarketGroup)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSMarketGroup = oDataTransfer.GetMarketGroup(oDSMarketGroup);
        return oDSMarketGroup;
    }
    /// <summary>
    /// Download Geo location
    /// </summary> 
    [WebMethod]
    public DSGeoLocation DownloadGeoLocation(DSGeoLocation oDSGeoLocation)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSGeoLocation = oDataTransfer.GetGeoLocation(oDSGeoLocation);
        return oDSGeoLocation;
    }
    /// <summary>
    /// Download Customer
    /// </summary> 
    [WebMethod]
    public DSCustomer DownloadCustomer(DSCustomer oDSCustomer, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomer = oDataTransfer.GetCustomer(oDSCustomer, nWarehouseID);
        return oDSCustomer;
    }
    [WebMethod]
    public void UpdateCustomerTransferInfo(DSCustomer oDSCustomer, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateCustomerInfo(oDSCustomer, nWarehouseID);
    }


    [WebMethod]
    public void UpdateCustomerTypeInfo(DSCustomerType oDSCustomerType, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateCustomerTypeInfo(oDSCustomerType, nWarehouseID);
    }

    /// <summary>
    /// Product Price
    /// </summary> 

    [WebMethod]
    public DSFinishedGoodsPrice DownloadProductPrice(DSFinishedGoodsPrice oDSFinishedGoodsPrice, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSFinishedGoodsPrice = oDataTransfer.GetPtoductPrice(oDSFinishedGoodsPrice, nWarehouseID);
        return oDSFinishedGoodsPrice;
    }
    [WebMethod]
    public void UpdateProductPriceTransferInfo(DSFinishedGoodsPrice oDSFinishedGoodsPrice, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateProductPriceTransferInfo(oDSFinishedGoodsPrice, nWarehouseID);
    }




    [WebMethod]
    public DSCustomer DownloadCustomerCreditLimit(DSCustomer DSCustomerCreditLimit, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        DSCustomerCreditLimit = oDataTransfer.GetCustomerCreditLimit(DSCustomerCreditLimit, nWarehouseID);
        return DSCustomerCreditLimit;
    }
    [WebMethod]
    public void UpdateCustomerCreditLimitInfo(DSCustomer DSCustomerCreditLimit, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateCustomerCreditLimit(DSCustomerCreditLimit, nWarehouseID);
    }


    /// <summary>
    /// Download Basic Data
    /// </summary> 
    [WebMethod]
    public DSBasicData DownloadBasicData(DSBasicData oDSBasicData, int nCustomerID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSBasicData = oDataTransfer.GetBasicData(oDSBasicData, nCustomerID);
        return oDSBasicData;
    }


    /// <summary>
    /// Download Customer Tran & Invoice Wise Payment
    /// </summary> 

    [WebMethod]
    public DSCustomerTransaction DownloadCustTranWithInvoWisePayment(DSCustomerTransaction oDSCustomerTransaction, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomerTransaction = oDataTransfer.GetCustomerTran(oDSCustomerTransaction, nWarehouseID);
        return oDSCustomerTransaction;
    }
    [WebMethod]
    public void UpdateCustomerTransactionInfo(DSCustomerTransaction oDSCustomerTransaction, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateCustomerTranInfo(oDSCustomerTransaction, nWarehouseID);
    }

    /// <summary>
    /// OfficeItem
    /// </summary> 

    [WebMethod]
    public DSOfficeItem DownloadOfficeItem(DSOfficeItem oDSOfficeItem, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSOfficeItem = oDataTransfer.GetDSOfficeItem(oDSOfficeItem, nWarehouseID);
        return oDSOfficeItem;
    }

    [WebMethod]
    public void UpdateOfficeItemInfo(DSOfficeItem oDSOfficeItem, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateOfficeItemTransferInfo(oDSOfficeItem, nWarehouseID);
    }

    /// <summary>
    /// TP Vat Product
    /// </summary> 
    [WebMethod]
    public DSTPVatProduct DownloadoTPVatProduct(DSTPVatProduct oDSTPVatProduct, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSTPVatProduct = oDataTransfer.GetTPVatPtoduct(oDSTPVatProduct, nWarehouseID);
        return oDSTPVatProduct;
    }
    [WebMethod]

    public void UpdateTPVatProductTransferInfo(DSTPVatProduct oDSTPVatProduct, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateTPVatProductTransferInfo(oDSTPVatProduct, nWarehouseID);
    }

    /// <summary>
    /// Get Pos Customer History
    /// </summary> 

    [WebMethod]
    public DSPosCustomerHostory DownloadPOSCustomerHistory(DSPosCustomerHostory oDSPosCustomerHostory, string sMobileNo)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPosCustomerHostory = oDataTransfer.GetPosCustomerHistory(oDSPosCustomerHostory, sMobileNo);
        return oDSPosCustomerHostory;

    }


    [WebMethod]
    public DSCustomer DownloadCustomerBalanceData(DSCustomer oDSCustomer, int nCustomerID,int nWarehouseID,DateTime dtOperationDate)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomer = oDataTransfer.GetCustomerBalanceData(oDSCustomer, nCustomerID, nWarehouseID, dtOperationDate);
        return oDSCustomer;

    }


    [WebMethod]
    public DSCustomer DownloadCustomerBalanceDataWithLocalBalance(DSCustomer oDSCustomer, int nCustomerID, int nWarehouseID, DateTime dtOperationDate, double _CurrentBalance, double _BankGuaranty, double _CreditLimit)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomer = oDataTransfer.GetCustomerBalanceDataWithLocalBalance(oDSCustomer, nCustomerID, nWarehouseID, dtOperationDate, _CurrentBalance, _BankGuaranty, _CreditLimit);
        return oDSCustomer;

    }

    [WebMethod]
    public DSBasicData DownloadBENoByProductSerial(DSBasicData oDSBasicData, string sProductSerialNo)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSBasicData = oDataTransfer.GETBENo(oDSBasicData, sProductSerialNo);
        return oDSBasicData;
    }


    /// <summary>
    /// Office Item Tran
    /// </summary> 

    [WebMethod]
    public DSOfficeItemTran DownloadOfficeItemTran(DSOfficeItemTran oDSOfficeItemTran, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSOfficeItemTran = oDataTransfer.GetDSOfficeItemTran(oDSOfficeItemTran, nWarehouseID);
        return oDSOfficeItemTran;
    }

    [WebMethod]
    public void UpdateOfficeItemTranInfo(DSOfficeItemTran oDSOfficeItemTran, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateOfficeItemTranDetailInfo(oDSOfficeItemTran, nWarehouseID);
    }
    /// <summary>
    /// Customer Credit Approval
    /// </summary> 

    [WebMethod]
    public DSCustmerCreditApprval DownloadCustomerCreditApproval(DSCustmerCreditApprval oDSCustmerCreditApprval, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustmerCreditApprval = oDataTransfer.GetDSCustmerCreditApprval(oDSCustmerCreditApprval, nWarehouseID);
        return oDSCustmerCreditApprval;
    }

    [WebMethod]
    public void UpdateCustomerCreditApprovalInfo(DSCustmerCreditApprval oDSCustmerCreditApprval, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateCreditApprovalInfo(oDSCustmerCreditApprval, nWarehouseID);
    }


    /// <summary>
    /// DownloadCalendarWeek
    /// </summary> 

    [WebMethod]
    public DSCalendarWeek DownloadCalendarWeek(DSCalendarWeek oDSCalendarWeek, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCalendarWeek = oDataTransfer.GetCalendarWeek(oDSCalendarWeek, nWarehouseID);
        return oDSCalendarWeek;
    }


    [WebMethod]
    public void UpdateCalendarWeekInfo(DSCalendarWeek oDSCalendarWeek, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateCalendarWeekInfo(oDSCalendarWeek, nWarehouseID);
    }


    /// <summary>
    /// DownloadPlanCustomerTarget
    /// </summary> 

    [WebMethod]
    public DSPlanCustomerTarget DownloadPlanCustomerTarget(DSPlanCustomerTarget oDSPlanCustomerTarget, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPlanCustomerTarget = oDataTransfer.GetPlanCustomerTarget(oDSPlanCustomerTarget, nWarehouseID);
        return oDSPlanCustomerTarget;
    }


    [WebMethod]
    public void UpdatePlanCustomerTargetInfo(DSPlanCustomerTarget oDSPlanCustomerTarget, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePlanCustomerTargetInfo(oDSPlanCustomerTarget, nWarehouseID);
    }

    /// <summary>
    /// DownloadPlanExecutiveWeekTarget
    /// </summary> 

    [WebMethod]
    public DSPlanExecutiveWeekTarget DownloadPlanExecutiveWeekTarget(DSPlanExecutiveWeekTarget oDSPlanExecutiveWeekTarget, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPlanExecutiveWeekTarget = oDataTransfer.GetPlanExecutiveWeekTarget(oDSPlanExecutiveWeekTarget, nWarehouseID);
        return oDSPlanExecutiveWeekTarget;
    }

    /// <summary>
    /// DownloadPlanExecutiveLeadTarget
    /// </summary> 

    [WebMethod]
    public DSPlanExecutiveWeekTarget DownloadPlanExecutiveLeadTarget(DSPlanExecutiveWeekTarget oDSPlanExecutiveLeadTarget, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPlanExecutiveLeadTarget = oDataTransfer.GetPlanExecutiveLeadTarget(oDSPlanExecutiveLeadTarget, nWarehouseID);
        return oDSPlanExecutiveLeadTarget;
    }
    [WebMethod]
    public void UpdatePlanExecutiveLeadTargetInfo(DSPlanExecutiveWeekTarget oDSPlanExecutiveLeadTarget, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePlanExecutiveLeadTargetInfo(oDSPlanExecutiveLeadTarget, nWarehouseID, null);
    }


    [WebMethod]
    public void UpdatePlanExecutiveWeekTargetInfo(DSPlanExecutiveWeekTarget oDSPlanExecutiveWeekTarget, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePlanExecutiveWeekTargetInfo(oDSPlanExecutiveWeekTarget, nWarehouseID);
    }

    /// <summary>
    /// DownloadPlanMAGWeekTargetQty
    /// </summary> 

    [WebMethod]
    public DSPlanMAGWeekTargetQty DownloadPlanMAGWeekTargetQty(DSPlanMAGWeekTargetQty oDSPlanMAGWeekTargetQty, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPlanMAGWeekTargetQty = oDataTransfer.GetPlanMAGWeekTargetQty(oDSPlanMAGWeekTargetQty, nWarehouseID);
        return oDSPlanMAGWeekTargetQty;
    }


    [WebMethod]
    public void UpdatePlanMAGWeekTargetQtyInfo(DSPlanMAGWeekTargetQty oDSPlanMAGWeekTargetQty, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdatePlanMAGWeekTargetInfo(oDSPlanMAGWeekTargetQty, nWarehouseID, null);
    }



    /// <summary>
    /// DownloadPlanMAGWeekTargetQty
    /// </summary> 

    [WebMethod]
    public DSOutletDisplayPosition DownloadDSOutletDisplayPosition(DSOutletDisplayPosition oDSOutletDisplayPosition, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSOutletDisplayPosition = oDataTransfer.GetOutletDisplayPosition(oDSOutletDisplayPosition, nWarehouseID);
        return oDSOutletDisplayPosition;
    }

    [WebMethod]
    public void UpdateOutletDisplayPositionInfo(DSOutletDisplayPosition oDSOutletDisplayPosition, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateOutletDisplayPositionInfo(oDSOutletDisplayPosition, nWHID);
    }

    [WebMethod]
    public DSCustomerTemp DownloadCustomerTemp(DSCustomerTemp oDSCustomerTemp, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomerTemp = oDataTransfer.GetCustomerTemp(oDSCustomerTemp, nWarehouseID);
        return oDSCustomerTemp;
    }
    [WebMethod]
    public void UpdateCustomerTempInfo(DSCustomerTemp oDSCustomerTemp, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateTempCustomerTran(oDSCustomerTemp, nWarehouseID);
    }

    [WebMethod]
    public DSInvoiceReverse DownloadInvoiceReverseData(DSInvoiceReverse oDSInvoiceReverse, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSInvoiceReverse = oDataTransfer.GetInvoiceReverseData(oDSInvoiceReverse, nWarehouseID);
        return oDSInvoiceReverse;
    }
    [WebMethod]
    public void UpdatInvoiceReverseInfo(DSInvoiceReverse oDSInvoiceReverse, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateInvoiceReverseTran(oDSInvoiceReverse, nWarehouseID);
    }

    [WebMethod]
    public DSExchangeOfferVender DownloadExchangeOfferVender(DSExchangeOfferVender oDSExchangeOfferVender, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSExchangeOfferVender = oDataTransfer.GetExchangeOfferVenderData(oDSExchangeOfferVender, nWarehouseID);
        return oDSExchangeOfferVender;
    }
    [WebMethod]
    public void UpdatExchangeOfferVenderInfo(DSExchangeOfferVender oDSExchangeOfferVender, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateExchangeOfferVender(oDSExchangeOfferVender, nWarehouseID);
    }


    [WebMethod]
    public DSSalesLead DownloadSalesLead(DSSalesLead oDSDSSalesLead, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSDSSalesLead = oDataTransfer.GetSalesLeadData(oDSDSSalesLead, nWarehouseID);
        return oDSDSSalesLead;
    }
    [WebMethod]
    public void UpdatSalesLeadInfo(DSSalesLead oDSSalesLead, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateSalesLeadInfo(oDSSalesLead, nWarehouseID);
    }

    [WebMethod]
    public DSSalesLead DownloadSalesLeadHistory(DSSalesLead oDSDSSalesLead, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSDSSalesLead = oDataTransfer.GetSalesLeadHistoryData(oDSDSSalesLead, nWarehouseID);
        return oDSDSSalesLead;
    }
    [WebMethod]
    public void UpdatSalesLeadHistory(DSSalesLead oDSSalesLead, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateSalesLeadHistoryInfo(oDSSalesLead, nWarehouseID);
    }

    [WebMethod]
    public DSExchangeOfferVenderTran DownloadExchangeOfferVenderTran(DSExchangeOfferVenderTran oDSExchangeOfferVenderTran, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSExchangeOfferVenderTran = oDataTransfer.GetExchangeOfferVenderTranData(oDSExchangeOfferVenderTran, nWarehouseID);
        return oDSExchangeOfferVenderTran;
    }
    [WebMethod]
    public void UpdatExchangeOfferVenderTranInfo(DSExchangeOfferVenderTran oDSExchangeOfferVenderTran, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateExchangeOfferVenderTran(oDSExchangeOfferVenderTran, nWarehouseID);
    }
    [WebMethod]
    public void UpdatEOMoneyReceiptInfo(DSExchangeOfferMR oDSExchangeOfferMR, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateExchangeOfferMRInfo(oDSExchangeOfferMR, nWarehouseID);
    }

    /// <summary>
    /// Exchange Offer Job
    /// </summary> 

    [WebMethod]
    public DSExchangeOfferJob DownloadExchangeOfferJob(DSExchangeOfferJob oDSExchangeOfferJob, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSExchangeOfferJob = oDataTransfer.GetExchangeOfferJob(oDSExchangeOfferJob, nWarehouseID);
        return oDSExchangeOfferJob;
    }

    [WebMethod]
    public void UpdateExchangeOfferJobInfo(DSExchangeOfferJob oDSExchangeOfferJob, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateExchangeOfferJobInfo(oDSExchangeOfferJob, nWarehouseID);
    }

    [WebMethod]
    public DSExchangeOfferMR DownloadExchangeOfferMRData(DSExchangeOfferMR oDSExchangeOfferMR, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSExchangeOfferMR = oDataTransfer.GetExchangeOfferMRData(oDSExchangeOfferMR, nWarehouseID);
        return oDSExchangeOfferMR;
    }

    [WebMethod]
    public DSSalesInvoiceEcommerce DownloadSalesInvoiceEcommerceData(DSSalesInvoiceEcommerce oDSSalesInvoiceEcommerce, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSalesInvoiceEcommerce = oDataTransfer.GetSalesInvoiceEcommerce(oDSSalesInvoiceEcommerce, nWarehouseID);
        return oDSSalesInvoiceEcommerce;
    }
    [WebMethod]
    public void UpdateSalesInvoiceEcommerceInfo(DSSalesInvoiceEcommerce oDSSalesInvoiceEcommerce, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateSalesInvoiceEcommerceInfo(oDSSalesInvoiceEcommerce, nWarehouseID);
    }
    [WebMethod]
    public int WarehouseWiseStock(string sWarehouseCode, string sProductCode)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        int nStock = oDataTransfer.GetWarehouseWiseStock(sWarehouseCode, sProductCode);
        return nStock;

    }
    #endregion
    [WebMethod]
    public DSPromotion DownloadScratchCardOffer(DSPromotion oDSPromotion, int nWarehouseID, string sTableName)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPromotion = oDataTransfer.GetScratchCardOffer(oDSPromotion, nWarehouseID, sTableName);
        return oDSPromotion;
    }
    
    #region Data Send

    /// <summary>
    /// Initial Transaction
    /// </summary> 
    /// 
    [WebMethod]
    public DSInitialTransaction SendInitialTransaction(DSInitialTransaction oDSInitialTransaction, int nWarehouseID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSInitialTransaction = oDataSend.InsertInitialTransaction(oDSInitialTransaction, nWarehouseID);
        return oDSInitialTransaction;
    }

    /// <summary>
    /// Stock Requsistion 
    /// </summary> 
    /// 
    [WebMethod]
    public DSRequisition SendStockRequisiton(DSRequisition oDSRequisition, int nWarehouseID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSRequisition = oDataSend.InsertStockRequisition(oDSRequisition, nWarehouseID);
        return oDSRequisition;
    }
    /// <summary>
    /// Retail Consumer 
    /// </summary> 
    /// 
    [WebMethod]//Should be deleted after implementing V9
    public DSRetailConsumer SendRetailConsumer(DSRetailConsumer oDSRetailConsumer)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSRetailConsumer = oDataTransfer.InsertConsumerForSend(oDSRetailConsumer);
        return oDSRetailConsumer;

    }
    /// <summary>
    /// Retail Consumer With Warehouse
    /// </summary> 
    /// 
    [WebMethod]
    public DSRetailConsumer SendRetailConsumers(DSRetailConsumer oDSRetailConsumer, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSRetailConsumer = oDataTransfer.InsertConsumerHOEnd(oDSRetailConsumer, nWHID);
        return oDSRetailConsumer;

    }

    /// <summary>
    /// Consumer Balance Tran
    /// </summary> 
    /// 
    [WebMethod]
    public DSConsumerBalanceTran SendConsumerBalanceTran(DSConsumerBalanceTran oDSConsumerBalanceTran, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSConsumerBalanceTran = oDataSend.InsertConsumerBalanceTran(oDSConsumerBalanceTran, nWHID);
        return oDSConsumerBalanceTran;
    }
    /// <summary>
    /// Day Start End Log 
    /// </summary> 
    /// 
    [WebMethod]
    public DSDayStartEndLog SendDayStartEndLog(DSDayStartEndLog oDSDayStartEndLog)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSDayStartEndLog = oDataTransfer.InsertDayStartEndLog(oDSDayStartEndLog);
        return oDSDayStartEndLog;

    }





    /// <summary>
    /// FactoryData
    /// </summary> 
    /// 
    [WebMethod]
    public DSProductComponent SendFactoryData(DSProductComponent oDSProductComponent,string sTableName,int nLocationID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSProductComponent = oDataTransfer.InsertFactoryData(oDSProductComponent, sTableName, nLocationID);
        return oDSProductComponent;

    }

    /// <summary>
    /// Database Backup Log
    /// </summary> 
    /// 
    [WebMethod]
    public DSDBBackupLog SendDSDBBackupLog(DSDBBackupLog oDSDBBackupLog)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSDBBackupLog = oDataTransfer.InsertDBBackupLog(oDSDBBackupLog);
        return oDSDBBackupLog;
    }
    /// <summary>
    /// Get Receivable Outlet Data Category
    /// </summary> 
    /// 
    [WebMethod]
    public DSReceivableOutletData GetReceivableOutletData(DSReceivableOutletData oDSReceivableOutletData, int nWarehouseID)
    {
        DBController.Instance.OpenNewConnection();
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSReceivableOutletData = oDataTransfer.GetReceivableOutletData(oDSReceivableOutletData, nWarehouseID);
        return oDSReceivableOutletData;
        DBController.Instance.CloseConnection();
    }
    /// <summary>
    /// DCS Tran
    /// </summary> 
    /// 
    [WebMethod]
    public DSDCSs SendDSDCSs(DSDCSs oDSDCSs, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSDCSs = oDataSend.InsertDCS(oDSDCSs, nWHID);
        return oDSDCSs;
    }
    /// <summary>
    /// Warranty Card Info
    /// </summary> 
    /// 
    [WebMethod]
    public DSWarranty SendWarrantyCard(DSWarranty oDSWarranty, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSWarranty = oDataSend.InsertWarrantyCard(oDSWarranty, nWHID);
        return oDSWarranty;
    }
    /// <summary>
    /// CLP Tran
    /// </summary> 
    /// 
    [WebMethod]
    public DSCLP SendCLPTran(DSCLP oDSCLP)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSCLP = oDataSend.SendCLPTran(oDSCLP);
        return oDSCLP;

    }
    /// <summary>
    /// Sales Invoice TD should be delete after deployee version-15
    /// </summary> 
    /// 
    [WebMethod]
    public DSSalesInvoice SendSalesInvoiceTD(DSSalesInvoice oDSSalesInvoice, int nChannel)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSSalesInvoice = oDataSend.SendSalesInvoiceTD(oDSSalesInvoice, nChannel);
        return oDSSalesInvoice;
    }

    [WebMethod]
    public DSSalesInvoice SendSalesInvoiceTDNewVat(DSSalesInvoice oDSSalesInvoice, int nChannel)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSSalesInvoice = oDataSend.SendSalesInvoiceTDNewVAT(oDSSalesInvoice, nChannel);
        return oDSSalesInvoice;
    }

    [WebMethod]
    public DSSalesInvoice SendSalesInvoiceNew(DSSalesInvoice oDSSalesInvoice, int nChannel)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSSalesInvoice = oDataSend.SendSalesInvoiceNew(oDSSalesInvoice, nChannel);
        return oDSSalesInvoice;
    }

    /// <summary>
    /// Sales Invoice 
    /// </summary> 
    /// 
    [WebMethod]
    public DSSalesInvoice SendSalesInvoice(DSSalesInvoice oDSSalesInvoice, int nChannel)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSSalesInvoice = oDataSend.SendSalesInvoice(oDSSalesInvoice, nChannel);
        return oDSSalesInvoice;
    }

    /// <summary>
    /// Product Stock Tran 
    /// </summary> 
    /// 
    [WebMethod]
    public DSProductTransaction SendStockTran(DSProductTransaction oDSProductTransaction, int nWarehouseID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSProductTransaction = oDataSend.SendProductStockTran(oDSProductTransaction, nWarehouseID);
        return oDSProductTransaction;
    }

    /// <summary>
    /// Customer Tran 
    /// </summary> 
    /// 
    [WebMethod]
    public DSCustomerTransaction SendCustomerTran(DSCustomerTransaction oDSCustomerTransaction, int nWarehouseID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSCustomerTransaction = oDataSend.SendCustomerTran(oDSCustomerTransaction, nWarehouseID);
        return oDSCustomerTransaction;
    }
    /// <summary>
    /// GET Central Retail Stock
    /// </summary> 
    /// 
    [WebMethod]
    public int GetCentralRetailStock(int nProductID)
    {
        int nStockQty = 0;
        StockTran oStockTran = new StockTran();
        DBController.Instance.OpenNewConnection();
        nStockQty = oStockTran.GetCentralRetailStock(nProductID);
        DBController.Instance.CloseConnection();
        return nStockQty;
    }
    /// <summary>
    /// Data Monitoring 
    /// </summary> 
    /// 
    [WebMethod]
    public void SendMonitoredData(DSDataMonitoring oDSDataMonitoring, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.InsertMonitoredData(oDSDataMonitoring, nWarehouseID);
    }

    /// <summary>
    /// Unsold Defective Product
    /// </summary> 
    /// 
    [WebMethod]
    public DSUnsoldDefectiveProduct SendUnsoldDefectiveProduct(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSUnsoldDefectiveProduct = oDataTransfer.InsertUnsoldDefectiveProduct(oDSUnsoldDefectiveProduct, nWHID);
        return oDSUnsoldDefectiveProduct;

    }

    /// <summary>
    /// Unsold Defective Product New
    /// </summary> 
    /// 
    [WebMethod]
    public DSUnsoldDefectiveProduct SendUnsoldDefectiveProductNew(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSUnsoldDefectiveProduct = oDataTransfer.InsertUnsoldDefectiveProductNew(oDSUnsoldDefectiveProduct, nWHID);
        return oDSUnsoldDefectiveProduct;

    }

    /// <summary>
    /// Customer Credit Approval Collection
    /// </summary> 
    /// 
    [WebMethod]
    public DSCustomerCreditApprovalCollection SendCustomerCreditApprovalCollection(DSCustomerCreditApprovalCollection oDSCustomerCreditApprovalCollection, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomerCreditApprovalCollection = oDataTransfer.InsertCustomerCreditCollection(oDSCustomerCreditApprovalCollection, nWHID);
        return oDSCustomerCreditApprovalCollection;

    }

    /// <summary>
    /// Office Item Tran
    /// </summary> 
    /// 
    [WebMethod]
    public DSOfficeItemTran SendOfficeItemTran(DSOfficeItemTran oDSOfficeItemTran, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSOfficeItemTran = oDataSend.InsertOfficeItemTran(oDSOfficeItemTran, nWHID);
        return oDSOfficeItemTran;

    }



    [WebMethod]
    public DSCustomerTransaction SendCustomerTransaction(DSCustomerTransaction oDSCustomerTransaction, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSCustomerTransaction = oDataSend.InsertCustomerTransaction(oDSCustomerTransaction, nWHID);
        return oDSCustomerTransaction;

    }

    [WebMethod]
    public DSDutyTranISGM SendDSDutyTranISGM(DSDutyTranISGM oDSDutyTranISGM, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSDutyTranISGM = oDataSend.InsertDutyTranISGM(oDSDutyTranISGM, nWHID);
        return oDSDutyTranISGM;

    }

    [WebMethod]
    public DSSalesOrder SendSalesOrder(DSSalesOrder oDSSalesOrder, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSSalesOrder = oDataSend.InsertDMSSalesOrder(oDSSalesOrder, nWHID);
        return oDSSalesOrder;

    }

    [WebMethod]
    public DSBasicData SendTDDeliveryShipment(DSBasicData oDSTDDeliveryShipment, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSTDDeliveryShipment = oDataSend.InsertTDDeliveryShipment(oDSTDDeliveryShipment, nWHID);
        return oDSTDDeliveryShipment;

    }

    [WebMethod]
    public DSPettyCash SendPettyCashExpense(DSPettyCash oDSPettyCash, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSPettyCash = oDataSend.InsertPettyCashExpence(oDSPettyCash, nWHID);
        return oDSPettyCash;

    }
    /// <summary>
    /// SalesLead, Should be deleted after deploy v 13
    /// </summary> 
    /// 
    [WebMethod]
    public DSSalesLead SendSalesLead(DSSalesLead oDSSalesLead, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSalesLead = oDataTransfer.InsertSalesLead(oDSSalesLead, nWHID);
        return oDSSalesLead;

    }
    /// <summary>
    /// SalesLead New
    /// </summary> 
    ///
    [WebMethod]
    public DSSalesLead SendSalesLead_new(DSSalesLead oDSSalesLead, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSalesLead = oDataTransfer.InsertSalesLead_new(oDSSalesLead, nWHID);
        return oDSSalesLead;

    }

    /// <summary>
    /// SalesLead New should be delete after deployment version-15
    /// </summary> 
    ///
    [WebMethod]
    public DSSalesLead SendSalesLead_new1(DSSalesLead oDSSalesLead, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSalesLead = oDataTransfer.InsertSalesLead_new1(oDSSalesLead, nWHID);
        return oDSSalesLead;

    }

    /// <summary>
    /// SalesLead New 2
    /// </summary> 
    ///
    [WebMethod]
    public DSSalesLead SendSalesLead_new2(DSSalesLead oDSSalesLead, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSalesLead = oDataTransfer.InsertSalesLead_new2(oDSSalesLead, nWHID);
        return oDSSalesLead;

    }

    [WebMethod]
    public DSSalesLead SendSalesLeadHistory(DSSalesLead oDSSalesLead, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSSalesLead = oDataTransfer.InsertSalesLeadHistory(oDSSalesLead, nWHID);
        return oDSSalesLead;

    }

    /// <summary>
    /// PotentialCustomer
    /// </summary> 
    /// 
    [WebMethod]
    public DSPotentialCustomer SendPotentialCustomer(DSPotentialCustomer oDSPotentialCustomer, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSPotentialCustomer = oDataTransfer.InsertPotentialCustomer(oDSPotentialCustomer, nWHID);
        return oDSPotentialCustomer;

    }

    /// <summary>
    /// OutletDisplayPosition
    /// </summary> 
    /// 
    [WebMethod]
    public DSOutletDisplayPosition SendOutletDisplayPosition(DSOutletDisplayPosition oDSOutletDisplayPosition, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSOutletDisplayPosition = oDataTransfer.UpdateOutletDisplayPosition(oDSOutletDisplayPosition, nWHID);
        return oDSOutletDisplayPosition;

    }

    /// <summary>
    /// OutletDisplayPositionHistory
    /// </summary> 
    /// 
    [WebMethod]
    public DSOutletDisplayPosition SendOutletDisplayPositionHistory(DSOutletDisplayPosition oDSOutletDisplayPositionHistory)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSOutletDisplayPositionHistory = oDataTransfer.InsertOutletDisplayPositionHistory(oDSOutletDisplayPositionHistory);
        return oDSOutletDisplayPositionHistory;

    }
    [WebMethod]
    public DSCustomerTemp SendCustomerTempData(DSCustomerTemp oDSCustomerTemp, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSCustomerTemp = oDataTransfer.InsertCustomerTemp(oDSCustomerTemp, nWHID);
        return oDSCustomerTemp;
    
    }

    [WebMethod]
    public DSInvoiceReverse SendInvoiceReverseData(DSInvoiceReverse oDSInvoiceReverse, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSInvoiceReverse = oDataTransfer.InsertDSInvoiceReverseData(oDSInvoiceReverse, nWHID);
        return oDSInvoiceReverse;

    }

    [WebMethod]
    public DSExchangeOfferMR SendExchangeOfferMRData(DSExchangeOfferMR oDSExchangeOfferMR, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSExchangeOfferMR = oDataTransfer.InsertExchangeOfferMRData(oDSExchangeOfferMR, nWHID);
        return oDSExchangeOfferMR;

    }

    [WebMethod]
    public DSExchangeOfferJob SendExchangeOfferJob(DSExchangeOfferJob oDSExchangeOfferJob, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSExchangeOfferJob = oDataTransfer.UpdateExchangeOfferJobPOS(oDSExchangeOfferJob, nWHID);
        return oDSExchangeOfferJob;

    }

    /// <summary>
    /// Outlet Attendance Info
    /// </summary> 
    /// 
    [WebMethod]
    public DSOutletAttendanceInfo SendOutletAttendanceInfo(DSOutletAttendanceInfo oDSOutletAttendanceInfo, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSOutletAttendanceInfo = oDataSend.InsertOutletAttendanceInfo(oDSOutletAttendanceInfo, nWHID);
        return oDSOutletAttendanceInfo;

    }
    /// <summary>
    /// Ecommercs Order
    /// </summary> 
    /// 
    [WebMethod]
    public DSEcommerceOrder SendEcommerceOrdereInfo(DSEcommerceOrder oDSOutletAttendanceInfo)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSOutletAttendanceInfo = oDataSend.InsertEcommerceOrder(oDSOutletAttendanceInfo);
        return oDSOutletAttendanceInfo;

    }
    [WebMethod]
    public DSSalesInvoiceEcommerce UpdateEcommerceOrdere(DSSalesInvoiceEcommerce oDSSalesInvoiceEcommerce, int nWHID)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSSalesInvoiceEcommerce = oDataSend.UpdateEcommerceOrder(oDSSalesInvoiceEcommerce, nWHID);
        return oDSSalesInvoiceEcommerce;

    }

    [WebMethod]
    public DSSalesInvoice SendSalesinvoicePaymentMode(DSSalesInvoice oDSSalesInvoicePaymentMode)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSSalesInvoicePaymentMode = oDataSend.SendSalesInvoicePaymentTD(oDSSalesInvoicePaymentMode);
        return oDSSalesInvoicePaymentMode;

    }

    [WebMethod]
    public DSProductTransaction SendVatPaidProductSerial(DSProductTransaction oDSVatPaidProductSerial)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSVatPaidProductSerial = oDataSend.SendVatPaidProductSerial(oDSVatPaidProductSerial);
        return oDSVatPaidProductSerial;

    }
    [WebMethod]
    public DSBasicData SendOutletDailyProjection(DSBasicData oDSOutletDailyProjection)
    {
        DataSend oDataSend;
        oDataSend = new DataSend();
        oDSOutletDailyProjection = oDataSend.SendOutletDailyProjection(oDSOutletDailyProjection);
        return oDSOutletDailyProjection;

    }

    [WebMethod]
    public bool EcommerceOrder(int nEComOrderID, int nOrderType, string sOrderNo, DateTime dtOrderDate, string sOutlet, double Amount, double DeliveryCharge, double Discount, string CopunNo, int ConsumerID, string sConsumerName, string sAddrress, string sDeliveryAddress, string sContactNo, string sEmail, string sRemarks, int nStatus, int nPaymentType, string sBankName, string sCardType, int nISEMI, int nNoOfInstallment, string sInstrumentNo, DateTime dtInstrumentDate, string sCardCategory, string sApprovalNo)
    {
        bool bFlag = false;
        DataTransfer oDataTransfer = new DataTransfer();
        if (oDataTransfer.CheckEcomOrderNo(nEComOrderID))
        {
            bFlag = oDataTransfer.InsertEcomOrder(nEComOrderID, nOrderType, sOrderNo, dtOrderDate, sOutlet, Amount, DeliveryCharge, Discount, CopunNo, ConsumerID, sConsumerName, sAddrress, sDeliveryAddress, sContactNo, sEmail, sRemarks, nStatus, nPaymentType, sBankName, sCardType, nISEMI, nNoOfInstallment, sInstrumentNo, dtInstrumentDate, sCardCategory, sApprovalNo);
        }
        else
        {
            bFlag = true;
        }
        return bFlag;
    }
    [WebMethod]
    public bool EcommerceOrderDetail(int EcomOrderID, string sProductCode, string sProductName, double _UnitPrice, double _DiscountAmount, int nQuantity, int nIsFreeQty)
    {
        bool bFlag = false;
        DataTransfer oDataTransfer = new DataTransfer();
        if (oDataTransfer.CheckEcomOrderDetailNo(EcomOrderID))
        {
            bFlag = oDataTransfer.InsertEcomOrderDetail(EcomOrderID, sProductCode, sProductName, _UnitPrice, _DiscountAmount, nQuantity, nIsFreeQty);
        }
        else
        {
            bFlag = true;
        }
        return bFlag;
    }


    [WebMethod]
    public int EcommerceLeadStatus(int nEcomOrderID)
    {
        int nStatus = 0;
        DataTransfer oDataTransfer = new DataTransfer();
        nStatus = oDataTransfer.GetEcomOrderStatus(nEcomOrderID);
        return nStatus;
    }

    [WebMethod]
    public double GetRSP(string sProductCode)
    {
        double _RSP = 0;
        DataTransfer oDataTransfer = new DataTransfer();
        _RSP = oDataTransfer.GetRSPByProductCode(sProductCode);
        return _RSP;
    }

    [WebMethod]
    public double GetPromoDiscount(string sProductCode)
    {
        double _Discount = 0;
        DataTransfer oDataTransfer = new DataTransfer();
        _Discount = oDataTransfer.GetPromoDiscountByProductCode(sProductCode);
        return _Discount;
    }

    [WebMethod]
    public bool InsertPotentialCustomerList(string sName,string sMobileNo,string sEmail,string sAddress, string sCompanyName,string sState,string sCity, string sCountry, string sEnquiryType, string sPreferredCategory ,string sEnquiry, int nType, DateTime dtVisitDate)
    {
        bool bFlag = false;
        DataTransfer oDataTransfer = new DataTransfer();
        bFlag = oDataTransfer.InsertPotentialCustomerList(sName, sMobileNo, sEmail, sAddress, sCompanyName, sState, sCity, sCountry, sEnquiryType, sPreferredCategory, sEnquiry, nType, dtVisitDate);
        return bFlag;
    }

   

    //[WebMethod]
    //public void UpdateExtendedWarrantyInfo(DSExtendedWarranty oDSExtendedWarranty, int nWarehouseID)
    //{
    //    DataTransfer oDataTransfer;
    //    oDataTransfer = new DataTransfer();
    //    oDataTransfer.UpdateExtendedWarranty(oDSExtendedWarranty, nWarehouseID);
    //}




    /// <summary>
    /// Stock Requsistion 
    /// </summary> 
    /// 
    [WebMethod]
    public DSExtendedWarranty SendExtendedWarranty(DSExtendedWarranty oDSExtendedWarranty, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.InsertExtendedWarranty(oDSExtendedWarranty, nWHID);
        return oDSExtendedWarranty;
    }

    /// <summary>
    /// ExtendedWarrantyItem
    /// </summary> 

    [WebMethod]
    public DSFinishedGoodsPrice DownloadExtendedWarrantyItem(DSFinishedGoodsPrice oDSExtendedWarrantyItem, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSExtendedWarrantyItem = oDataTransfer.GetExtendedWarrantyItem(oDSExtendedWarrantyItem, nWarehouseID);
        return oDSExtendedWarrantyItem;
    }

    [WebMethod]
    public void UpdateExtendedWarrantyItemInfo(DSFinishedGoodsPrice oDSExtendedWarrantyItem, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateExtendedWarrantyItemInfo(oDSExtendedWarrantyItem, nWarehouseID);
    }

    [WebMethod]
    public DSDayPlan SendDayPlanData(DSDayPlan oDSDayPlan, int nWHID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSDayPlan = oDataTransfer.InsertDSDayPlanData(oDSDayPlan, nWHID);
        return oDSDayPlan;

    }


    /// <summary>
    /// Day Plan Purpose
    /// </summary> 

    [WebMethod]
    public DSDayPlan DownloadDayPlanPurpose(DSDayPlan oDSDayPlan, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSDayPlan = oDataTransfer.GetDayPlanPurpose(oDSDayPlan, nWarehouseID);
        return oDSDayPlan;
    }


    [WebMethod]
    public void UpdateDayPlanPurposeInfo(DSDayPlan oDSDayPlan, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateDayPlanPurposeInfo(oDSDayPlan, nWarehouseID);
    }

    /// <summary>
    /// Visit Plan Type
    /// </summary> 

    [WebMethod]
    public DSDayPlan DownloadVisitPlanType(DSDayPlan oDSDayPlan, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDSDayPlan = oDataTransfer.GetDayVisitPlanType(oDSDayPlan, nWarehouseID);
        return oDSDayPlan;
    }


    [WebMethod]
    public void UpdateVisitPlanTypeInfo(DSDayPlan oDSDayPlan, int nWarehouseID)
    {
        DataTransfer oDataTransfer;
        oDataTransfer = new DataTransfer();
        oDataTransfer.UpdateVisitPlanTypeInfo(oDSDayPlan, nWarehouseID);
    }
    ///// <summary>
    ///// DMS Tran 
    ///// </summary> 
    ///// 
    //[WebMethod]
    //public DSSalesInvoice SendDMSStockTran(DSSalesInvoice oDSDMSStockTran)
    //{
    //    DataSend oDataSend;
    //    oDataSend = new DataSend();
    //    oDSDMSStockTran = oDataSend.SendDMSStockTran(oDSDMSStockTran);
    //    return oDSDMSStockTran;
    //}
    #endregion

    #region Android
    [WebMethod]
    public string ReadSaleInfoAndroidTML()
    {
        TELLib oTELLib = new TELLib();
        TML _oTML;
        _oTML = new TML();

        DBController.Instance.OpenNewConnection();
        string _SaleInfoAndroidTML = "Sales Value:"
                + "\nTD: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLDTDSalesValue())
                + "\nLD: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLLDSalesValue())
                + "\nMTD: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLMTDSalesValue())
                + "\nLM: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLLMSalesValue())
                + "\nYTD: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLYTDSalesValue())

                + "\n\nSales Qty:"
                + "\nTD: " + _oTML.GetTMLAGWiseSaleDTD()
                + "\nLD: " + _oTML.GetTMLAGWiseSaleLD()
            //+ "\nWTD: " + _oTML.GetTMLAGWiseSaleWTD()
                + "\nMTD: " + _oTML.GetTMLAGWiseSaleMTD()
            //+ "\nLM: " + _oTML.GetTMLAGWiseSaleLM()
            //+ "\nYTD: " + _oTML.GetTMLAGWiseSaleYTD()
                + "\n\nStock:"
                + "\nTotal: Qty=" + _oTML.GetTMLStockValue()
                + "\n\n" + _oTML.GetTMLAGWiseStock();
        //+ "\n\nReceivable:"
        //+ "\nTK. " + _oTML.GetTMLReceivable();


        DBController.Instance.CloseConnection();

        return _SaleInfoAndroidTML;

    }
    [WebMethod]
    public string ReadPriceTML()
    {
        TELLib oTELLib = new TELLib();
        TML _oTML;
        _oTML = new TML();

        DBController.Instance.OpenNewConnection();
        string _SaleInfoAndroidTML = "Sales Value:"
                + "\nTD: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLDTDSalesValue())
                + "\nLD: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLLDSalesValue())
                + "\nMTD: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLMTDSalesValue())
                + "\nLM: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLLMSalesValue())
                + "\nYTD: Tk. " + oTELLib.TakaFormat(_oTML.GetTMLYTDSalesValue())

                + "\n\nSales Qty:"
                + "\nTD: " + _oTML.GetTMLAGWiseSaleDTD()
                + "\nLD: " + _oTML.GetTMLAGWiseSaleLD()
                + "\nWTD: " + _oTML.GetTMLAGWiseSaleWTD()
                + "\nMTD: " + _oTML.GetTMLAGWiseSaleMTD()
                + "\nLM: " + _oTML.GetTMLAGWiseSaleLM()
                + "\nYTD: " + _oTML.GetTMLAGWiseSaleYTD()
                + "\n\nStock:"
                + "\nTotal: Qty=" + _oTML.GetTMLStockValue()
                + "\n\n" + _oTML.GetTMLAGWiseStock();
        //+ "\n\nReceivable:"
        //+ "\nTK. " + _oTML.GetTMLReceivable();


        DBController.Instance.CloseConnection();

        return _SaleInfoAndroidTML;

    }

    [WebMethod]
    public DSProductPrice GetProductPriceTML()
    {
        TML _oTML;
        _oTML = new TML();

        DBController.Instance.OpenNewConnection();
        DSProductPrice oDSProdPrice = _oTML.GetProductPrice();
        DBController.Instance.CloseConnection();
        return oDSProdPrice;
    }
    [WebMethod]
    public DSProductPrice GetProductPriceTEL(string sBrand, string sASGName, int nProductType)
    {
        TEL _oTEL;
        _oTEL = new TEL();

        DBController.Instance.OpenNewConnection();
        DSProductPrice oDSProdPriceTEL = _oTEL.GetProductPrice(sBrand, sASGName, nProductType);
        DBController.Instance.CloseConnection();
        return oDSProdPriceTEL;
    }
    [WebMethod]
    public DSProductStock GetProductStockTML()
    {
        TML _oTML;
        _oTML = new TML();

        DBController.Instance.OpenNewConnection();
        DSProductStock oDSProdStock = _oTML.GetProductStock();
        DBController.Instance.CloseConnection();
        return oDSProdStock;
    }
    [WebMethod]
    public DSProductStock GetProductStockTEL(string sBrand, string sASGName, int nProductType, string sSType)
    {
        TEL _oTEL;
        _oTEL = new TEL();

        DBController.Instance.OpenNewConnection();
        DSProductStock oDSProdStockTEL = _oTEL.GetProductStock(sBrand, sASGName, nProductType, sSType);
        DBController.Instance.CloseConnection();
        return oDSProdStockTEL;
    }
    [WebMethod]
    public DSPerformanceUI GetPerformanceTML()
    {
        TML _oTML;
        _oTML = new TML();

        int nChannelQty = 0;
        double nChannelAmt = 0;
        int nTargetQty = 0;
        int nLMQty = 0;
        double nLMAmt = 0;
        double nTargetAmt = 0;
        string sChannelName = "";

        DBController.Instance.OpenNewConnection();
        DSPerformanceTML oDSPerformance = _oTML.GetPerformance();
        DBController.Instance.CloseConnection();

        DSPerformanceUI oDSPerformanceUI = new DSPerformanceUI();
        DSPerformanceUI.PerformanceUIRow oPerformanceTTLAmt = oDSPerformanceUI.PerformanceUI.NewPerformanceUIRow(); ;
        DSPerformanceUI.PerformanceUIRow oPerformanceTTLQty = oDSPerformanceUI.PerformanceUI.NewPerformanceUIRow(); ;


        foreach (DSPerformanceTML.PerformanceRow oPerformanceRow in oDSPerformance.Performance)
        {
            if (sChannelName != oPerformanceRow.Channel)
            {
                if (sChannelName != "")
                {
                    /// For Total Qty & Value (previous channel)


                    oPerformanceTTLQty.Channel = sChannelName;
                    oPerformanceTTLQty.InfoType = "T Qty";
                    oPerformanceTTLQty.Target = nTargetQty.ToString();
                    oPerformanceTTLQty.MTD = nChannelQty.ToString();

                    if (nTargetQty != 0)
                    {
                        oPerformanceTTLQty.AchPercent = ((double)nChannelQty / nTargetQty).ToString("0.0%");
                    }
                    else
                    {
                        oPerformanceTTLQty.AchPercent = "-";
                    }
                    if (nLMQty != 0)
                    {
                        oPerformanceTTLQty.GrowthPercent = (((double)(nChannelQty - nLMQty) / nLMQty)).ToString("0.0%");
                    }
                    else
                    {
                        oPerformanceTTLQty.GrowthPercent = "-";
                    }

                    oPerformanceTTLAmt = oDSPerformanceUI.PerformanceUI.NewPerformanceUIRow();

                    oPerformanceTTLAmt.Channel = " ";
                    oPerformanceTTLAmt.InfoType = "T Amt";
                    oPerformanceTTLAmt.Target = nTargetAmt.ToString();
                    oPerformanceTTLAmt.MTD = nChannelAmt.ToString();

                    if (nTargetAmt != 0)
                    {
                        oPerformanceTTLAmt.AchPercent = ((double)nChannelAmt / nTargetAmt).ToString("0.0%");
                    }
                    else
                    {
                        oPerformanceTTLAmt.AchPercent = "-";
                    }
                    if (nLMAmt != 0)
                    {
                        oPerformanceTTLAmt.GrowthPercent = (((double)(nChannelAmt - nLMAmt) / nLMAmt)).ToString("0.0%");
                    }
                    else
                    {
                        oPerformanceTTLAmt.GrowthPercent = "-";
                    }

                    oDSPerformanceUI.PerformanceUI.AddPerformanceUIRow(oPerformanceTTLAmt);

                    nChannelQty = 0;
                    nChannelAmt = 0;
                    nTargetQty = 0;
                    nTargetAmt = 0;
                }

                oPerformanceTTLQty = oDSPerformanceUI.PerformanceUI.NewPerformanceUIRow();
                oDSPerformanceUI.PerformanceUI.AddPerformanceUIRow(oPerformanceTTLQty);
                //==============================

                // First Item for new Channel
                DSPerformanceUI.PerformanceUIRow oPerformanceUIRow = oDSPerformanceUI.PerformanceUI.NewPerformanceUIRow();

                oPerformanceUIRow.Channel = " ";
                oPerformanceUIRow.InfoType = oPerformanceRow.AGName;
                oPerformanceUIRow.Target = oPerformanceRow.TargetQty.ToString();
                oPerformanceUIRow.MTD = oPerformanceRow.MTDQty.ToString();
                if (oPerformanceRow.TargetQty != 0)
                {
                    oPerformanceUIRow.AchPercent = ((double)oPerformanceRow.MTDQty / oPerformanceRow.TargetQty).ToString("0.0%");
                }
                else
                {
                    oPerformanceUIRow.AchPercent = "-";
                }

                if (oPerformanceRow.LMTDQty != 0)
                {
                    oPerformanceUIRow.GrowthPercent = (((double)(oPerformanceRow.MTDQty - oPerformanceRow.LMTDQty) / oPerformanceRow.LMTDQty)).ToString("0.0%");
                }
                else
                {
                    oPerformanceUIRow.GrowthPercent = "-";
                }

                oDSPerformanceUI.PerformanceUI.AddPerformanceUIRow(oPerformanceUIRow);

                nChannelQty = nChannelQty + oPerformanceRow.MTDQty;
                nChannelAmt = nChannelAmt + oPerformanceRow.MTDValue;
                nTargetQty = nTargetQty + oPerformanceRow.TargetQty;
                nTargetAmt = nTargetAmt + oPerformanceRow.TargetValue;
                nLMQty = nLMQty + oPerformanceRow.LMTDQty;
                nLMAmt = nLMAmt + oPerformanceRow.LMTDValue;
                sChannelName = oPerformanceRow.Channel;
            }
            else
            {
                // 2nd & 3rd Item
                DSPerformanceUI.PerformanceUIRow oPerformanceUIRow = oDSPerformanceUI.PerformanceUI.NewPerformanceUIRow();

                oPerformanceUIRow.Channel = " ";
                oPerformanceUIRow.InfoType = oPerformanceRow.AGName;
                oPerformanceUIRow.Target = oPerformanceRow.TargetQty.ToString();
                oPerformanceUIRow.MTD = oPerformanceRow.MTDQty.ToString();
                if (oPerformanceRow.TargetQty != 0)
                {
                    oPerformanceUIRow.AchPercent = ((double)oPerformanceRow.MTDQty / oPerformanceRow.TargetQty).ToString("0.0%");
                }
                else
                {
                    oPerformanceUIRow.AchPercent = "-";
                }
                if (oPerformanceRow.LMTDQty != 0)
                {
                    oPerformanceUIRow.GrowthPercent = (((double)(oPerformanceRow.MTDQty - oPerformanceRow.LMTDQty) / oPerformanceRow.LMTDQty)).ToString("0.0%");
                }
                else
                {
                    oPerformanceUIRow.GrowthPercent = "-";
                }

                oDSPerformanceUI.PerformanceUI.AddPerformanceUIRow(oPerformanceUIRow);

                nChannelQty = nChannelQty + oPerformanceRow.MTDQty;
                nChannelAmt = nChannelAmt + oPerformanceRow.MTDValue;
                nTargetQty = nTargetQty + oPerformanceRow.TargetQty;
                nTargetAmt = nTargetAmt + oPerformanceRow.TargetValue;
                nLMQty = nLMQty + oPerformanceRow.LMTDQty;
                nLMAmt = nLMAmt + oPerformanceRow.LMTDValue;
                sChannelName = oPerformanceRow.Channel;

            }


        }

        /// For Total Qty & Value (Last channel)
        //DSPerformanceTML.PerformanceUIRow oPerformanceTTLQty1 = oDSPerformance.PerformanceUI.NewPerformanceUIRow();

        oPerformanceTTLQty.Channel = sChannelName;
        oPerformanceTTLQty.InfoType = "T Qty";
        oPerformanceTTLQty.Target = nTargetQty.ToString();
        oPerformanceTTLQty.MTD = nChannelQty.ToString();
        if (nTargetQty != 0)
        {
            oPerformanceTTLQty.AchPercent = ((double)nChannelQty / nTargetQty).ToString("0.0%");
        }
        else
        {
            oPerformanceTTLQty.AchPercent = "-";
        }
        if (nLMQty != 0)
        {
            oPerformanceTTLQty.GrowthPercent = (((double)(nChannelQty - nLMQty) / nLMQty)).ToString("0.0%");
        }
        else
        {
            oPerformanceTTLQty.GrowthPercent = "-";
        }

        //oDSPerformance.PerformanceUI.AddPerformanceUIRow(oPerformanceTTLQty1);


        oPerformanceTTLAmt = oDSPerformanceUI.PerformanceUI.NewPerformanceUIRow();

        oPerformanceTTLAmt.Channel = " ";
        oPerformanceTTLAmt.InfoType = "T Amt";
        oPerformanceTTLAmt.Target = nTargetAmt.ToString();
        oPerformanceTTLAmt.MTD = nChannelAmt.ToString();
        if (nTargetAmt != 0)
        {
            oPerformanceTTLAmt.AchPercent = ((double)nChannelAmt / nTargetAmt).ToString("0.0%");
        }
        else
        {
            oPerformanceTTLAmt.AchPercent = "-";
        }
        if (nLMAmt != 0)
        {
            oPerformanceTTLAmt.GrowthPercent = (((double)(nChannelAmt - nLMAmt) / nLMAmt)).ToString("0.0%");
        }
        else
        {
            oPerformanceTTLAmt.GrowthPercent = "-";
        }

        oDSPerformanceUI.PerformanceUI.AddPerformanceUIRow(oPerformanceTTLAmt);

        return oDSPerformanceUI;
    }

    [WebMethod]
    public string GetProductPriceStringTML()
    {
        string sResult = "";
        int i;
        TML _oTML;
        _oTML = new TML();

        DBController.Instance.OpenNewConnection();
        DSProductPrice oDSProdPrice = _oTML.GetProductPrice();
        foreach (DSProductPrice.ProductPriceRow oRow in oDSProdPrice.ProductPrice)
        {
            sResult = sResult + oRow[0].ToString().PadRight(5) + " "
                              + oRow[1].ToString().PadRight(20) + " "
                              + oRow[2].ToString().PadRight(12) + " "
                              + oRow[3].ToString().PadRight(4) + " "
                              + oRow[4].ToString().PadRight(4) + " "
                              + oRow[5].ToString().PadRight(4) + " ";
            sResult = sResult + "\n";
        }
        DBController.Instance.CloseConnection();
        return sResult;
    }
    [WebMethod]
    public string GetProductPriceStringTEL(string sBrand, string sASGName, int nProductType)
    {
        string sResult = "";
        int i;
        TEL _oTEL;
        _oTEL = new TEL();

        DBController.Instance.OpenNewConnection();
        DSProductPrice oDSProdPriceTEL = _oTEL.GetProductPrice(sBrand, sASGName, nProductType);
        foreach (DSProductPrice.ProductPriceRow oRow in oDSProdPriceTEL.ProductPrice)
        {
            sResult = sResult + oRow[0].ToString().PadRight(5) + " "
                              + oRow[1].ToString().PadRight(20) + " "
                              + oRow[2].ToString().PadRight(12) + " "
                              + oRow[3].ToString().PadRight(4) + " "
                              + oRow[4].ToString().PadRight(4) + " ";

            sResult = sResult + "\n";
        }
        DBController.Instance.CloseConnection();
        return sResult;
    }
    [WebMethod]
    public string GetProductStockStringTEL(string sBrand, string sASGName, int nProductType, string sSType)
    {
        string sResult = "";
        int i;
        TEL _oTEL;
        _oTEL = new TEL();

        DBController.Instance.OpenNewConnection();
        DSProductStock oDSProdStockTEL = _oTEL.GetProductStock(sBrand, sASGName, nProductType, sSType);
        foreach (DSProductStock.ProductStockRow oRow in oDSProdStockTEL.ProductStock)
        {
            sResult = sResult + oRow[0].ToString().PadRight(3) + " "
                              + oRow[1].ToString().PadRight(20) + " "
                              + oRow[2].ToString().PadRight(12) + " "
                              + oRow[3].ToString().PadRight(3) + " "
                              + oRow[4].ToString().PadRight(4) + " ";

            sResult = sResult + "\n";
        }
        DBController.Instance.CloseConnection();
        return sResult;
    }
    private string ExcludeDecimal(string sAmount)
    { 
        string sResult="";
        sResult = sAmount.Remove(sAmount.Length - 3);
        return sResult;
    }
    private string GetAreaZoneSales()
    {
        TELs oTELs = new TELs();
        oTELs.Refresh();

        Records oRecords = new Records();
        Record oAreaRecord = new Record();
        Record oZoneRecord;

        foreach (TEL oTEL in oTELs)
        {


            if (oAreaRecord.Name != oTEL.AreaName)
            {
                oAreaRecord = new Record();
                oRecords.Add(oAreaRecord);
                oAreaRecord.Name = oTEL.AreaName;
                oAreaRecord.Type = "Area";
            }

            oZoneRecord = new Record();
            oZoneRecord.Name = oTEL.TerritoryName;
            oZoneRecord.DTD = oTEL.DTD;
            oZoneRecord.LD = oTEL.LD;
            oZoneRecord.MTD = oTEL.MTD;
            oRecords.Add(oZoneRecord);

            oAreaRecord.DTD = oAreaRecord.DTD + oZoneRecord.DTD;
            oAreaRecord.LD = oAreaRecord.LD + oZoneRecord.LD;
            oAreaRecord.MTD = oAreaRecord.MTD + oZoneRecord.MTD;
        }
       return oRecords.GetResult();
    }
    private string GetOutletSales()
    {
        TELs oTELs = new TELs();
        //oTELs.RefreshOutlet();

        Records oRecords = new Records();
        Record oRecord = new Record();
        Record oRecordOutlet = new Record();
        foreach (TEL oTEL in oTELs)
        {
            if (oRecord.Name != oTEL.AreaName)
            {
                oRecord = new Record();
                oRecords.Add(oRecord);
                oRecord.Name = oTEL.AreaName;
                oRecord.Type = "Area";
                
            }
            oRecordOutlet = new Record();
            oRecordOutlet.Name = oTEL.Outlet;
            oRecordOutlet.DTD = oTEL.DTD;
            oRecordOutlet.LD = oTEL.LD;
            oRecordOutlet.MTD = oTEL.MTD;
            oRecords.Add(oRecordOutlet);
            oRecord.Name = oTEL.AreaName;
        }
        return oRecords.GetOutletResult();
    }
    [WebMethod]
    public string ReadSaleInfoAndroidTEL(int Param)
    {
        //TELLib oTELLib = new TELLib();
        //TEL _oTEL;
        //_oTEL = new TEL();

        string Result = "";
        //string sLastUpdateDate = "";
        //DBController.Instance.OpenNewConnection();
        //sLastUpdateDate = _oTEL.GetLastUpdateDate("TEL");
        //if (Param == 1)
        //{

        //    Result = "Last Update:" + sLastUpdateDate + "\n\nTEL Net Sales:"
        //    + "\nDTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTELDTDSalesValue()))
        //    + "\nMTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTELMTDSalesValue()))
        //    + "\nLM: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTELLMSalesValue()))
        //    + "\nYTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTELYTDSalesValue()))
        //    + "\nLD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTELLDSalesValue()))
        //    + "\n-----------------------------------------------------------------------"
        //    + "\n\nTranscom Digital:"
        //    + "\nMTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTranscomDigitalMTDSalesValue()))
        //    + "\nLM: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTranscomDigitalLMSalesValue()))
        //    + "\nYTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTranscomDigitalYTDSalesValue()))
        //    + "\nLD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTranscomDigitalLDSalesValue()))

        //     + "\n\nProject- CAC&E:"
        //    + "\nMTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetProjectMTDSalesValue()))
        //    + "\nLM: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetProjectLMSalesValue()))
        //    + "\nYTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetProjectYTDSalesValue()))
        //    + "\nLD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetProjectLDSalesValue()))
        //     + "\n-----------------------------------------------------------------------"
        //    + "\n\nTD Retail:"
        //    + "\nMTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTDRetailMTDSalesValue()))
        //    + "\nLM: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTDRetailLMSalesValue()))
        //    + "\nYTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTDRetailYTDSalesValue()))
        //    + "\nLD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetTDRetailLDSalesValue()))

        //    + "\n\nTD Dealer:"
        //    + "\nMTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetDealerMTDSalesValue()))
        //    + "\nLM: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetDealerLMSalesValue()))
        //    + "\nYTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetDealerYTDSalesValue()))
        //    + "\nLD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetDealerLDSalesValue()))

        //    + "\n\nTD Corporate:"
        //    + "\nMTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetCorporateMTDSalesValue()))
        //    + "\nLM: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetCorporateLMSalesValue()))
        //    + "\nYTD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetCorporateYTDSalesValue()))
        //    + "\nLD: Tk. " + ExcludeDecimal(oTELLib.TakaFormat(_oTEL.GetCorporateLDSalesValue()));
        //    //+ "\n-----------------------------------------------------------------------\n"
        //    //+ "Area & Zone Wise Sales [Format: DTD> LD> MTD]:\n\n"
        //    //+ GetAreaZoneSales()
        //    //+ "\n-----------------------------------------------------------------------\n"
        //    //+ "Outlet Wise Sales [Format: DTD> LD> MTD]:\n\n";
        //    //+ GetOutletSales();
        //}
        //if (Param == 2)
        //{
        //    Result = "MAG:"
        //    + "\n" + _oTEL.GetASGWiseSale();
        //}
        //if (Param == 3)
        //{
        //    Result = "\nReceivable\n"
        //    + _oTEL.GetTELChannelWiseReceivable() + " \n"
        //    + _oTEL.GetTELChannelWiseReceivableCorporate() + " \n"
        //    + "TD EPS / EzeeBuy \n " + " " + _oTEL.GetTELChannelWiseReceivableEPS() + " \n"
        //    + "Discount Outlet \n " + " " + _oTEL.GetTELChannelWiseReceivableDiscountOutlet() + " \n";
        //}
        //if (Param == 4)
        //{
        //    Result = GetAreaZoneSales();
        //}
        //if (Param == 5)
        //{
        //    Result = GetOutletSales();
        //}

        ////+ "\n\nSales Qty:"
        ////+ "\nDTD: " + _oTEL.GetTELASGWiseSaleDTD()
        ////+ "\nWTD: " + _oTEL.GetTELASGWiseSaleWTD()
        ////+ "\nMTD: " + _oTEL.GetTELASGWiseSaleMTD()
        ////+ "\nLM: " + _oTEL.GetTELASGWiseSaleLM()
        ////+ "\nYTD: " + _oTEL.GetTELASGWiseSaleYTD()
        ////+ "\n\nStock:"
        ////+ "\nTotal: Qty=" + _oTEL.GetTELStockValue()
        ////+ "\n\n" + _oTEL.GetTELASGWiseStock();
        ////+ "\n\nReceivable:"
        ////+ "\nTK. " + _oTEL.GetTELReceivable();

        //DBController.Instance.CloseConnection();

        return Result;

    }
    [WebMethod]
    public string ReadSaleInfoAndroidBLL()
    {
        TELLib oTELLib = new TELLib();
        BLL _oBLL;
        _oBLL = new BLL();

        DBController.Instance.OpenNewConnection();
        string _SaleInfoAndroidBLL = "Sales Value:"
                + "\nDTD: Tk. " + oTELLib.TakaFormat(_oBLL.GetBLLDTDSalesValue())
                + "\nMTD: Tk. " + oTELLib.TakaFormat(_oBLL.GetBLLMTDSalesValue())
                + "\nLM: Tk. " + oTELLib.TakaFormat(_oBLL.GetBLLLMSalesValue())
                + "\nYTD: Tk. " + oTELLib.TakaFormat(_oBLL.GetBLLYTDSalesValue())

                + "\n\nSales Qty:"
                + "\nDTD: " + _oBLL.GetBLLASGWiseSaleDTD()
                + "\nWTD: " + _oBLL.GetBLLASGWiseSaleWTD()
                + "\nMTD: " + _oBLL.GetBLLASGWiseSaleMTD()
                + "\nLM: " + _oBLL.GetBLLASGWiseSaleLM()
                + "\nYTD: " + _oBLL.GetBLLASGWiseSaleYTD()
                + "\n\nStock:"
                + "\nTotal: Qty=" + _oBLL.GetBLLStockValue()
                + "\n\n" + _oBLL.GetBLLASGWiseStock();
        //+ "\n\nReceivable:"
        //+ "\nTK. " + _oTEL.GetBLLReceivable();

        DBController.Instance.CloseConnection();

        return _SaleInfoAndroidBLL;

    }
    [WebMethod]
    public DSPTOBLL GetTOReportBLL()
    {
        BLL _oBLL;
        _oBLL = new BLL();

        DBController.Instance.OpenNewConnection();
        DSPTOBLL oDSPTOBLL = _oBLL.GetBLLTOReport();

        DBController.Instance.CloseConnection();
        return oDSPTOBLL;
    }
    [WebMethod]
    public DSPTerritorySalesTarget GetTerritorySalesAcheivementReportBLL(string sAreaName)
    {
        BLL _oBLL;
        _oBLL = new BLL();

        DBController.Instance.OpenNewConnection();
        DSPTerritorySalesTarget oDSPTerritorySalesTarget = _oBLL.GetTerritorySalesAcheivementReportBLL(sAreaName);
        DBController.Instance.CloseConnection();
        return oDSPTerritorySalesTarget;
    }
    [WebMethod]
    public DSPTerritorySalesTarget GetAreaTerritorySalesAcheivementReportBLL(string sAreaName, string sTerritoryName)
    {
        BLL _oBLL;
        _oBLL = new BLL();

        DBController.Instance.OpenNewConnection();
        DSPTerritorySalesTarget oDSPTerritorySalesTarget = _oBLL.GetAreaTerritorySalesAcheivementReportBLL(sAreaName, sTerritoryName);
        DBController.Instance.CloseConnection();
        return oDSPTerritorySalesTarget;
    }
    [WebMethod]
    public DSPSalesTarget GetSalesAcheivementReportBLL()
    {
        BLL _oBLL;
        _oBLL = new BLL();

        DBController.Instance.OpenNewConnection();
        DSPSalesTarget oDSPTOBLL = _oBLL.GetSalesAcheivementReportBLL();

        DBController.Instance.CloseConnection();
        return oDSPTOBLL;
    }
    [WebMethod]
    public DSPTerritorySalesTarget GetTerritorySalesAcheivementReportQtyBLL(string sAreaName)
    {
        BLL _oBLL;
        _oBLL = new BLL();

        //DBController.Instance.OpenNewConnection();
        //DSPTerritorySalesTarget oDSPTerritorySalesTarget = _oBLL.GetTerritorySalesAcheivementReportQtyBLL(sAreaName);
        //DBController.Instance.CloseConnection();

        DSPTerritorySalesTarget oDSPTerritorySalesTarget = new DSPTerritorySalesTarget();
        return oDSPTerritorySalesTarget;
    }
    [WebMethod]
    public DSPTerritorySalesTarget GetAreaTerritorySalesAcheivementReportQtyBLL(string sAreaName, string sTerritoryName)
    {
        BLL _oBLL;
        _oBLL = new BLL();

        //DBController.Instance.OpenNewConnection();
        //DSPTerritorySalesTarget oDSPTerritorySalesTarget = _oBLL.GetAreaTerritorySalesAcheivementReportQtyBLL(sAreaName,sTerritoryName);
        //DBController.Instance.CloseConnection();

        DSPTerritorySalesTarget oDSPTerritorySalesTarget = new DSPTerritorySalesTarget();

        return oDSPTerritorySalesTarget;
    }
    [WebMethod]
    public DSPSalesTarget GetSalesAcheivementReportQtyBLL()
    {
        BLL _oBLL;
        _oBLL = new BLL();

        //DBController.Instance.OpenNewConnection();
        //DSPSalesTarget oDSPTOBLL = _oBLL.GetSalesAcheivementReportQtyBLL();
        //DBController.Instance.CloseConnection();

        DSPSalesTarget oDSPTOBLL = new DSPSalesTarget();
        return oDSPTOBLL;
    }
    [WebMethod]
    public DSPBLLAndroidDashboard GetBLLAndroidDashboard(string sAreaName, string sTerritoryName)
    {
        BLL _oBLL;
        _oBLL = new BLL();

        DBController.Instance.OpenNewConnection();
        DSPBLLAndroidDashboard oDSPBLLAndroidDashboard = _oBLL.GetDSPBLLAndroidDashboard(sAreaName, sTerritoryName);
        DBController.Instance.CloseConnection();
        return oDSPBLLAndroidDashboard;
    }
    [WebMethod]
    public DSPBLLAreaWiseAndroidDashboard GetBLLAreaWiseAndroidDashboard()
    {
        BLL _oBLL;
        _oBLL = new BLL();

        DBController.Instance.OpenNewConnection();
        DSPBLLAreaWiseAndroidDashboard oDSPBLLAreaWiseAndroidDashboard = _oBLL.GetDSPBLLAreaWiseAndroidDashboard();
        DBController.Instance.CloseConnection();
        return oDSPBLLAreaWiseAndroidDashboard;
    }
    [WebMethod]
    public DSPBLLTerritoryWiseAndroidDashboard GetBLLTerritoryWiseAndroidDashboard(string sAreaName)
    {
        BLL _oBLL;
        _oBLL = new BLL();

        DBController.Instance.OpenNewConnection();
        DSPBLLTerritoryWiseAndroidDashboard oDSPBLLTerritoryWiseAndroidDashboard = _oBLL.GetDSPBLLTerritoryWiseAndroidDashboard(sAreaName);
        DBController.Instance.CloseConnection();
        return oDSPBLLTerritoryWiseAndroidDashboard;
    }
    [WebMethod]
    public void SimpleWrite()
    {
        Company oCompany = new Company();

        DBController.Instance.OpenNewConnection();
        oCompany.SimpleWrite();
        DBController.Instance.CloseConnection();

    }
    #endregion

    #region DMS
    [WebMethod]
    public bool Login(string sUsername, string sPassword)
    {


        DMSUser oDMSUser = new DMSUser();
        DBController.Instance.OpenNewConnection();
        bool bAuthenticated = oDMSUser.authenticate(sUsername);
        DBController.Instance.CloseConnection();

        if (bAuthenticated != false)
        {
            PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);

            string sHashValue = mph.CreateHash(sPassword, oDMSUser.Salt);
            if (oDMSUser.UserPassword.CompareTo(sHashValue) != 0)
            {
                return false;
            }
            else
            {

                return true;
            }
        }
        else
        {

            return false;
        }


    }
    [WebMethod]

    public string validateUIInput(string sUserID)
    {
        DMS oDMS = new DMS();
        DateTime dSelectLastOperationDate;
        DateTime _dStartDay;
        DateTime _dLastOperationDay = DateTime.Now;
        TimeSpan _dDiffDate;
        string sDate = "";
        try
        {
            DBController.Instance.OpenNewConnection();
            dSelectLastOperationDate = oDMS.SelectLastOperationDate(sUserID);
            _dStartDay = Convert.ToDateTime(DateTime.Now);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {

            throw (ex);
        }

        if (dSelectLastOperationDate != null)
        {
            _dLastOperationDay = Convert.ToDateTime(dSelectLastOperationDate);
            if (_dLastOperationDay > _dStartDay)
            {

                return "false";

            }
        }
        _dDiffDate = (_dStartDay - _dLastOperationDay);
        sDate = "You are " + _dDiffDate.Days.ToString() + " Days behind ";
        return sDate;
    }
    [WebMethod]
    public DSProductStockDMS GetProductStockDMS(string sdistributorid)
    {
        DMS _oDMS;
        _oDMS = new DMS();

        DBController.Instance.OpenNewConnection();
        DSProductStockDMS oDSProdStockDMS = _oDMS.GetProductStockDMS(sdistributorid);
        DBController.Instance.CloseConnection();
        return oDSProdStockDMS;
    }




    #endregion
}
