/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: Oct 11, 2011
/// Time : 05:00 PM
/// Description: Main form.
/// Modify Person And Date: 
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Diagnostics;
using System.Security.Principal;
using System.Resources;
using System.Data.OleDb;
using System.Threading;

using CJ.POS.Security;
using CJ.Class;
using CJ.POS.Invoice;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using CJ.POS.TELWEBSERVER;



namespace CJ.POS
{
    public partial class frmMain : Form
    {
        //-----------------
        Service oSerivce;
        DSWarehouse oDSFromWarehouse;
        DSRetailConsumer oDSRetailConsumer;
        DSCLP oDSCLP;
        DSSalesInvoice oDSSalesInvoice;
        DSSalesInvoice oDSSalesInvoicePaymentMode;
        DSCustomerTransaction oDSCustomerTransaction;
        DSProductTransaction oDSProductTransaction;
        DSRequisition oDSRequisition;
        DSInitialTransaction oDSInitialTransaction;
        DSConsumerBalanceTran oDSConsumerBalanceTran;
        DSDCSs oDSDCSs;
        DSDayStartEndLog oDSDayStartEndLog;
        DSWarranty oDSWarranty;
        DSDataMonitoring oDSDataMonitoring;
        DSDBBackupLog oDSDBBackupLog;
        DSReceivableOutletData oDSReceivableOutletData;
        DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct;
        DSOfficeItemTran oDSOfficeItemTran;
        DSCustomerCreditApprovalCollection oDSCustomerCreditApprovalCollection;
        DSSalesLead oDSSalesLead;
        DSPotentialCustomer oDSPotentialCustomer;
        DSOutletDisplayPosition oDSOutletDisplayPosition;
        DSOutletDisplayPosition oDSOutletDisplayPositionHistory;
        DSCustomerTemp oDSCustomerTemp;
        DSInvoiceReverse oDSInvoiceReverse;
        DSExchangeOfferMR oDSExchangeOfferMR;
        DSExchangeOfferJob oDSExchangeOfferJob;
        DSOutletAttendanceInfo oDSOutletAttendanceInfo;
        DSSalesInvoiceEcommerce oDSSalesInvoiceEcommerce;
        DSProductTransaction oDSVatPaidProductSerial;
        DSBasicData oDSOutletDailyProjection;
        DSDutyTranISGM oDSDutyTranISGM;
        DSBasicData oDSDeliveryShipment;
        DSPromoDiscount oDSPromoDiscount;

        CJ.Class.DataTransfer.DataTransfer oDataTransfer;
        CJ.Class.DataTransfer.DataSend oDataSend;
        //CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.POS.DSRetailConsumer _oDSRetailConsumer;
        CJ.Class.POS.DSCLP _oDSCLP;
        CJ.Class.POS.DSSalesInvoice _oDSSalesInvoice;
        CJ.Class.POS.DSCustomerTransaction _oDSCustomerTransaction;
        CJ.Class.POS.DSProductTransaction _oDSProductTransaction;
        CJ.Class.POS.DSRequisition _oDSRequisition;
        CJ.Class.POS.DataTrans _oDataTrans;
        CJ.Class.POS.DSInitialTransaction _oDSInitialTransaction;
        CJ.Class.POS.DSConsumerBalanceTran _oDSConsumerBalanceTran;
        CJ.Class.POS.DSDCSs _oDSDCSs;
        CJ.Class.POS.DSDayStartEndLog _oDSDayStartEndLog;
        CJ.Class.POS.DSWarranty _oDSWarranty;
        CJ.Class.POS.DSDataMonitoring _oDSDataMonitoring;
        CJ.Class.POS.DSDBBackupLog _oDSDBBackupLog;
        CJ.Class.POS.DSReceivableOutletData _oDSReceivableOutletData;
        CJ.Class.POS.DSUnsoldDefectiveProduct _oDSUnsoldDefectiveProduct;
        CJ.Class.POS.DSOfficeItemTran _oDSOfficeItemTran;
        CJ.Class.POS.DSCustomerCreditApprovalCollection _oDSCustomerCreditApprovalCollection;
        CJ.Class.POS.DSSalesLead _oDSSalesLead;
        CJ.Class.POS.DSPotentialCustomer _oDSPotentialCustomer;
        CJ.Class.POS.DSOutletDisplayPosition _oDSOutletDisplayPosition;
        CJ.Class.POS.DSOutletDisplayPosition _oDSOutletDisplayPositionHistory;
        CJ.Class.POS.DSCustomerTemp _oDSCustomerTemp;
        CJ.Class.POS.DSInvoiceReverse _oDSInvoiceReverse;
        CJ.Class.POS.DSExchangeOfferMR _oDSExchangeOfferMR;
        CJ.Class.POS.DSExchangeOfferJob _oDSExchangeOfferJob;
        CJ.Class.POS.DSOutletAttendanceInfo _oDSOutletAttendanceInfo;
        CJ.Class.POS.DSSalesInvoiceEcommerce _oDSSalesInvoiceEcommerce;
        CJ.Class.POS.DSSalesInvoice _oDSSalesInvoicePaymentMode;
        CJ.Class.POS.DSProductTransaction _oDSVatPaidProductSerial;
        CJ.Class.POS.DSBasicData _oDSOutletDailyProjection;
        CJ.Class.POS.DSDutyTranISGM _oDSDutyTranISGM;
        CJ.Class.POS.DSBasicData _oDSDeliveryShipment;
        CJ.Class.Promotion.DSPromoDiscount _oDSPromoDiscount;



        //----------------
        CJ.Class.POS.SystemInfo oSystemInfo;
        ProductStocks oProductStocks;
        UserPermissions _oUserPermissions;
        public UserPermissions oUserPermissions;
        int nWHID = 0;
        int nCustomerID = 0;
        int nChannelID = 0;

        private static int nWarehouseID = 0;
        System.Timers.Timer timer = new System.Timers.Timer();
        public frmMain()
        {        
            InitializeComponent();
            MenuDisable();
            LeftImageMenu(false);
            Trimer();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            oSystemInfo = new CJ.Class.POS.SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();

            int nCount = 0;
            if (VersionCheck(oSystemInfo.POSVersionNo))
            {
                if (oSystemInfo.SystemDisableDate == null)
                {
                    DateTime dtsysDate;
                    if (oSystemInfo.OperationDate != null)
                    {
                        dtsysDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                        dtsysDate = dtsysDate.AddDays(5);
                    }
                    else
                    {
                        dtsysDate =Convert.ToDateTime(oSystemInfo.LastOperationDate);
                        dtsysDate = dtsysDate.AddDays(6);
                    }
                    oSystemInfo.SystemDisableDate = dtsysDate;
                    oSystemInfo.UpdateSystemDisableDate();
                }
                else
                {
                    if (oSystemInfo.OperationDate != null)
                    {
                        if (Convert.ToDateTime(oSystemInfo.OperationDate) > Convert.ToDateTime(oSystemInfo.SystemDisableDate))
                        {
                            nCount++;
                        }
                    }
                    else
                    {
                        if (Convert.ToDateTime(oSystemInfo.LastOperationDate) > Convert.ToDateTime(oSystemInfo.SystemDisableDate))
                        {
                            nCount++;
                        }
                    }
                }
                if (nCount > 0)
                {
                    MessageBox.Show("Your system has been locked!!!! \nPlease Contact with concern person Immediately", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                MessageBox.Show("TEL MIS & IT Launched a newest Version:" + oSystemInfo.POSVersionNo + " \nPlease Contact with concern person Immediately \nOtherwise system will be locked !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (oSystemInfo.SystemDisableDate != null)
                {
                    oSystemInfo.SystemDisableDate = null;
                    oSystemInfo.UpdateSystemDisableDate();
                }
            }
            DBController.Instance.CloseConnection();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            lblPOSVersion.Text = "CJ.POS Edge [" + version + "]";
            lblPOSVersion.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ED1B24");
            lblOutletName.Text = oSystemInfo.Shortcode + " - " + oSystemInfo.WarehouseName;
            lblOutletName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ED1B24");
            this.Text = oSystemInfo.WarehouseName + "-" + oSystemInfo.Shortcode + " [" + Utility.CompanyInfo + " POS Edge | Version: " + version + "]";
            label1.Text = "Logged in User: " + "None";
            label2.Text = "System Date: " + "None";


            //picNetworkSignal.Image = Image.FromFile("net2.jpg");
            nWHID = oSystemInfo.WarehouseID;
            nCustomerID = oSystemInfo.CustomerID;
            nChannelID = oSystemInfo.ChannelID;
        }    
        public void MenuDisable()
        {
            extendedWarrantyToolStripMenuItem.Enabled = false;
            mnuLogIn.Enabled = true;
            mnuLogOut.Enabled = false;
            mnuChangePassword.Enabled = false;
            mmuexit.Enabled = true;
            thisSystemToolStripMenuItem.Enabled = false;
            dayStartToolStripMenuItem.Enabled = false;
            dayEndToolStripMenuItem.Enabled = false;
            updateHOStockToolStripMenuItem.Enabled = false;
            //monthEndToolStripMenuItem.Enabled = false;
            //yearEndToolStripMenuItem.Enabled = false;
            currentEmployeeToolStripMenuItem.Enabled = false;
            productDetailsToolStripMenuItem.Enabled = false;
            runningCPToolStripMenuItem.Enabled = false;
            existingToolStripMenuItem.Enabled = false;
            requisitionCreationToolStripMenuItem.Enabled = false;
            aSGWiseSaleForAppsToolStripMenuItem.Enabled = false;


            iSGMToHOToolStripMenuItem.Enabled = false;
            iSGMToToolStripMenuItem.Enabled = false;
            goodsReceiveAgainstRequisitioToolStripMenuItem.Enabled = false;
            goodsReceiveFromOtherOutletToolStripMenuItem.Enabled = false;
            databaseBackupToolStripMenuItem.Enabled = false; 
            //requisitionAuthorizationToolStripMenuItem.Enabled = false;
            //goodsDeliveryAgainstRequisitionToolStripMenuItem.Enabled = false;
            //goodsReceivedFromHODepotToolStripMenuItem1.Enabled = false;
            //goodsReturnToHODepotToolStripMenuItem.Enabled = false;
            //stockAdjustmentToolStripMenuItem.Enabled = false;
            //goodsTransferToOtherOutletToolStripMenuItem1.Enabled = false;
            //iSGMAuthorizationToolStripMenuItem.Enabled = false;
            //goodsReceivedFromOtherOutletToolStripMenuItem1.Enabled = false;
            //iSGMReturnFromHODepotToolStripMenuItem.Enabled = false;
            retailInvoiceToolStripMenuItem.Enabled = false;      
            dealerInvoiceToolStripMenuItem.Enabled = false;
            retailInvoiceForHPAToolStripMenuItem.Enabled = false;
            corporateInvoiceB2CToolStripMenuItem.Enabled = false;
            corporateInvoiceB2BToolStripMenuItem.Enabled = false;
            modifyInvoicesToolStripMenuItem.Enabled = false;
            //giftVoucherReceiptToolStripMenuItem.Enabled = false;
            advancePaymentToolStripMenuItem.Enabled = false;
            //creditCollectionToolStripMenuItem.Enabled = false;
            //customerAdjustmentToolStripMenuItem.Enabled = false;
            dailyCollectionStatementToolStripMenuItem.Enabled = false;
            stockPositionToolStripMenuItem.Enabled = false;
            stockLedgerToolStripMenuItem.Enabled = false;
            stockMovementSummaryToolStripMenuItem.Enabled = false;
            serialToolStripMenuItem.Enabled = false;
            invoiceRegisterToolStripMenuItem.Enabled = false;
            salesStatementToolStripMenuItem.Enabled = false;
            salesQtyValueToolStripMenuItem.Enabled = false;
            vAT11KaToolStripMenuItem.Enabled = false;
            customerLedgerToolStripMenuItem.Enabled = false;           
            dataDownloadToolStripMenuItem.Enabled = false;
            dataTransferToolStripMenuItem.Enabled = false;
            dealerInvoiceEditableUnitPriceToolStripMenuItem.Enabled = false;
            dealerInvoiceWithoutIMEIToolStripMenuItem.Enabled = false;
            paymentReceiveDealerToolStripMenuItem.Enabled = false;

            stockPositionToolStripMenuItem.Enabled = false;
            stockLedgerToolStripMenuItem.Enabled = false;
            stockMovementSummaryToolStripMenuItem.Enabled = false;
            serialToolStripMenuItem.Enabled = false;
            invoiceRegisterToolStripMenuItem.Enabled = false;
            salesStatementToolStripMenuItem.Enabled = false;
            salesQtyValueToolStripMenuItem.Enabled = false;
            vAT11KaToolStripMenuItem.Enabled = false;
            customerLedgerToolStripMenuItem.Enabled = false;
            reprintToolStripMenuItem.Enabled = false;

            customerCreditApprovalToolStripMenuItem.Enabled = false;
            unsoldToolStripMenuItem.Enabled = false;
            OfficeItemtoolStripMenuItem1.Enabled = false;
            salesLeadToolStripMenuItem.Enabled = false;
            potentialCustomerToolStripMenuItem.Enabled = false;
            outletDisplayPositionToolStripMenuItem.Enabled = false;

            tGTvsAchToolStripMenuItem.Enabled = false;
            customerTGTVsAchievementByMonthToolStripMenuItem.Enabled=false;
            salesTrandReportToolStripMenuItem.Enabled = false;
            b2BCustomerEntryToolStripMenuItem.Enabled = false;
            reverseAppalicationToolStripMenuItem.Enabled = false;
            EcommerceOrderToolStripMenuItem.Enabled = false;
            //tsbLogIn.Enabled = true;
            //tsbLogOut.Enabled = false;
            dailyProjectionToolStripMenuItem.Enabled = false;
            deliveryShipmentToolStripMenuItem.Enabled = false;


            goodsRequisitionMovementToolStripMenuItem.Enabled = false;
            invoiceToolStripMenuItem.Enabled = false;
            executiveWiseLeadTargetVsActualToolStripMenuItem.Enabled = false;
            channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem.Enabled = false;
            executiveWiseWeeklyReportQtyValueToolStripMenuItem.Enabled = false;
            executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem.Enabled = false;
            attendanceToolStripMenuItem.Enabled = false;
            dashboardToolStripMenuItem1.Enabled = false;

            salesInvoiceToolStripMenuItem.Enabled = false;
            paymentToolStripMenuItem.Enabled = false;
            spacialDiscountApplicationToolStripMenuItem.Enabled = false;
            stockReportsToolStripMenuItem.Enabled = false;
            salesReportsToolStripMenuItem.Enabled = false;
            accountsReportToolStripMenuItem.Enabled = false;
            importXMLToolStripMenuItem.Enabled = false;
            dMSOrderToolStripMenuItem.Enabled = false;

            salesStatementToolStripMenuItem1.Enabled = false;
            salesTrendReportToolStripMenuItem1.Enabled = false;
            salesQuantityValueToolStripMenuItem1.Enabled = false;
            aSGWiseSaleForAppsToolStripMenuItem2.Enabled = false;
            invoiceRegisterToolStripMenuItem2.Enabled = false;
            executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem2.Enabled = false;
            executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem1.Enabled = false;
            channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem1.Enabled = false;
            executiveWiseLeadTargetVsActualToolStripMenuItem1.Enabled = false;
            salesTrendReportToolStripMenuItem.Enabled = false;
            salesQuantityValueToolStripMenuItem.Enabled = false;
            aSGWiseSaleForAppsToolStripMenuItem1.Enabled = false;
            invoiceRegisterToolStripMenuItem1.Enabled = false;
            
        }
        public void MenuEnable()
        {
            mnuLogIn.Enabled = false;
            mnuLogOut.Enabled = true;
            //tsbLogIn.Enabled = false;
            //tsbLogOut.Enabled = true;
            if (oSystemInfo.IsActiveSalesOrder == (int)Dictionary.IsActive.Active)
            {
                dMSOrderToolStripMenuItem.Enabled = true;
            }
            else
            {
                dMSOrderToolStripMenuItem.Enabled = false;
            }
            
            goodsRequisitionMovementToolStripMenuItem.Enabled = true;
            invoiceToolStripMenuItem.Enabled = true;
            attendanceToolStripMenuItem.Enabled = true;
            dashboardToolStripMenuItem1.Enabled = true;
            salesInvoiceToolStripMenuItem.Enabled = true;
            paymentToolStripMenuItem.Enabled = true;
            spacialDiscountApplicationToolStripMenuItem.Enabled = true;
            stockReportsToolStripMenuItem.Enabled = true;
            salesReportsToolStripMenuItem.Enabled = true;
            accountsReportToolStripMenuItem.Enabled = true;

            dataDownloadToolStripMenuItem.Enabled = true;
            _oUserPermissions = new UserPermissions();
            _oUserPermissions = _oUserPermissions.Refresh(_oUserPermissions, Utility.UserId);
            oUserPermissions = _oUserPermissions;
            updateHOStockToolStripMenuItem.Enabled = true;
            databaseBackupToolStripMenuItem.Enabled = true;

            //Admin
            //This System
            foreach (UserPermission oUserPermission in _oUserPermissions)
            {
                if (oUserPermission.UserPermissions == "M37.1.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        thisSystemToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                    
                }
                //Data Upload
                if (oUserPermission.UserPermissions == "M37.1.6")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        dataTransferToolStripMenuItem.Enabled = true;
                        nCount++;
                    }

                }
                //Basic Data
                //Current Employee
                if (oUserPermission.UserPermissions == "M38.1.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        currentEmployeeToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Current Employee
                if (oUserPermission.UserPermissions == "M38.1.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        productDetailsToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Running Consumer Promotion
                if (oUserPermission.UserPermissions == "M38.1.3")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        runningCPToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //CLP Registration
                //if (oUserPermission.UserPermissions == "M38.1.4")
                //{
                //    int nCount = 0;
                //    if (nCount == 0)
                //    {
                //        cLPCustomerRegistrationToolStripMenuItem.Enabled = true;
                //        nCount++;
                //    }
                //}
                //Existion Customer
                if (oUserPermission.UserPermissions == "M38.1.5")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        existingToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                //Activites
                //Goods Movement & Requisition
                //Requisition Creation
                if (oUserPermission.UserPermissions == "M39.1.1.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        requisitionCreationToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
 
                //Return to HO
                if (oUserPermission.UserPermissions == "M39.1.1.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        iSGMToHOToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //ISGM to other outlet
                if (oUserPermission.UserPermissions == "M39.1.1.3")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        iSGMToToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Goods Receive Against Requisition
                if (oUserPermission.UserPermissions == "M39.1.1.4")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        goodsReceiveAgainstRequisitioToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Goods Receive from other outlet
                if (oUserPermission.UserPermissions == "M39.1.1.5")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        goodsReceiveFromOtherOutletToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Retail Invoice
                if (oUserPermission.UserPermissions == "M39.1.2.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        retailInvoiceToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Dealer Invoice
                if (oUserPermission.UserPermissions == "M39.1.2.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        dealerInvoiceToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Dealer Invoice(Editable Unit Price)
                //if (oUserPermission.UserPermissions == "M39.1.2.3")
                //{
                //    int nCount = 0;
                //    if (nCount == 0)
                //    {
                //        dealerInvoiceEditableUnitPriceToolStripMenuItem.Enabled = true;
                //        nCount++;
                //    }
                //}
                //Daler Invoice (Without IMEI)
                //if (oUserPermission.UserPermissions == "M39.1.2.4")
                //{
                //    int nCount = 0;
                //    if (nCount == 0)
                //    {
                //        dealerInvoiceWithoutIMEIToolStripMenuItem.Enabled = true;
                //        nCount++;
                //    }
                //}
                //Corporate Invoice
                if (oUserPermission.UserPermissions == "M39.1.2.5")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        corporateInvoiceB2CToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Modify Invoices
                if (oUserPermission.UserPermissions == "M39.1.2.6")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        modifyInvoicesToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //HPA
                if (oUserPermission.UserPermissions == "M39.1.2.7")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                      retailInvoiceForHPAToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //B2B
                if (oUserPermission.UserPermissions == "M39.1.2.8")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        corporateInvoiceB2BToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Advance payment
                if (oUserPermission.UserPermissions == "M39.1.3.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        advancePaymentToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Daily Collection Statement (DCS)
                if (oUserPermission.UserPermissions == "M39.1.3.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        dailyCollectionStatementToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Payment Collection (Dealer)
                if (oUserPermission.UserPermissions == "M39.1.3.3")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        paymentReceiveDealerToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Stock Position
                if (oUserPermission.UserPermissions == "M40.1.1.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        stockPositionToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Stock Ledger
                if (oUserPermission.UserPermissions == "M40.1.1.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        stockLedgerToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Stock Movement
                if (oUserPermission.UserPermissions == "M40.1.1.3")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        stockMovementSummaryToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Product Serial
                if (oUserPermission.UserPermissions == "M40.1.1.4")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        serialToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Invoice Register
                if (oUserPermission.UserPermissions == "M40.1.2.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        invoiceRegisterToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                //Sales Statement
                if (oUserPermission.UserPermissions == "M40.1.2.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesStatementToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Sales Qty and Value
                if (oUserPermission.UserPermissions == "M40.1.2.3")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesQtyValueToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                //Emp TGT vs Ach
                if (oUserPermission.UserPermissions == "M40.1.2.4")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        tGTvsAchToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Customer TGT vs Ach
                if (oUserPermission.UserPermissions == "M40.1.2.5")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        customerTGTVsAchievementByMonthToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Sales Trand Report
                if (oUserPermission.UserPermissions == "M40.1.2.6")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesTrandReportToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Sales Trand Report
                if (oUserPermission.UserPermissions == "M40.1.2.7")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        executiveWiseLeadTargetVsActualToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Sales Trand Report
                if (oUserPermission.UserPermissions == "M40.1.2.8")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Sales Trand Report
                if (oUserPermission.UserPermissions == "M40.1.2.9")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        executiveWiseWeeklyReportQtyValueToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Sales Trand Report
                if (oUserPermission.UserPermissions == "M40.1.2.10")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                //VAT
                if (oUserPermission.UserPermissions == "M40.1.3.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        vAT11KaToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Customer Ledger
                if (oUserPermission.UserPermissions == "M40.1.3.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        customerLedgerToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Reprint
                if (oUserPermission.UserPermissions == "M40.1.4")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        reprintToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                //Sales Report Retail
                if (oUserPermission.UserPermissions == "M40.1.5.1.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        invoiceRegisterToolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.1.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        aSGWiseSaleForAppsToolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.1.3")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesQuantityValueToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.1.4")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesTrendReportToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.1.5")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        executiveWiseLeadTargetVsActualToolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.1.6")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.1.7")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.1.8")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem2.Enabled = true;
                        nCount++;
                    }
                }

                //Sales Report Dealer
                if (oUserPermission.UserPermissions == "M40.1.5.2.1")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        invoiceRegisterToolStripMenuItem2.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.2.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        aSGWiseSaleForAppsToolStripMenuItem2.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.2.3")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesQuantityValueToolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }
                if (oUserPermission.UserPermissions == "M40.1.5.2.4")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesTrendReportToolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }
                //Sales Statement
                if (oUserPermission.UserPermissions == "M40.1.5.3")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesStatementToolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }

                //Office Item Requisition
                if (oUserPermission.UserPermissions == "M39.1.1.6")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        OfficeItemtoolStripMenuItem1.Enabled = true;
                        nCount++;
                    }
                }
                //Customer Credit Approval
                if (oUserPermission.UserPermissions == "M39.1.3.4")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                      customerCreditApprovalToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Unsold Product Management
                if (oUserPermission.UserPermissions == "M39.1.4")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        unsoldToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Sales Lead
                if (oUserPermission.UserPermissions == "M39.1.5")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        salesLeadToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Potential Customer
                if (oUserPermission.UserPermissions == "M39.1.6")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        potentialCustomerToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Outlet Display Position 
                if (oUserPermission.UserPermissions == "M39.1.7")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        outletDisplayPositionToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                //B2B Customer Entry
                if (oUserPermission.UserPermissions == "M38.1.6")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        b2BCustomerEntryToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Reverse Application
                if (oUserPermission.UserPermissions == "M39.1.8")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        reverseAppalicationToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                if (oUserPermission.UserPermissions == "M39.1.9")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        dailyProjectionToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                if (oUserPermission.UserPermissions == "M39.1.10")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        deliveryShipmentToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                if (oUserPermission.UserPermissions == "M39.1.11")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        importXMLToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                if (oUserPermission.UserPermissions == "M39.1.12")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        extendedWarrantyToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                if (oUserPermission.UserPermissions == "M39.1.13")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        dayPlanManagementToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                if (oUserPermission.UserPermissions == "M39.1.2.9")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        EcommerceOrderToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }

                //
            }
            oSystemInfo = new CJ.Class.POS.SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            DBController.Instance.CloseConnection();
            if (oSystemInfo.OperationDate != null)
            {
                dayStartToolStripMenuItem.Enabled = false;
                dayEndToolStripMenuItem.Enabled = true;
                label1.Text = "Log in User: " + Utility.Username;
                label2.Text = "System Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy");
            }
            else
            {
                dayStartToolStripMenuItem.Enabled = true;
                dayEndToolStripMenuItem.Enabled =false;
              
            }
        }
        public void logOut(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to log out ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                MenuDisable();
                LeftImageMenu(false);
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                //picNetworkSignal.Image = Image.FromFile("net2.jpg");
                label1.Text = "Logged in User: " + "None";
                label2.Text = "System Date: " + "None";
            }
        }

        private void Login()
        {

            frmLogin frmLogin = new frmLogin();
            DialogResult oResult = frmLogin.ShowDialog();
            if (oResult == DialogResult.OK)
            {
                label1.Text = "Logged in User: " + Utility.Username;
                if (Utility.SystemDate == null)
                {
                    MenuEnable();
                    LeftImageMenu(true);
                }
                else
                {
                    if (Utility.IsCheckServerDateTime == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        if (Utility.ServerDatetime.Date == Convert.ToDateTime(Utility.SystemDate).Date)
                        {
                            MenuEnable();
                            LeftImageMenu(true);
                        }
                        else
                        {
                            dayEndToolStripMenuItem_Click(null, null);

                        }
                    }
                    else
                    {
                        MenuEnable();
                        LeftImageMenu(true);
                    }
                }

            }
            else
            {
                return;
            }
        }
        public void logIn(object sender, EventArgs e)
        {
            Login();

        }

        private void Exit()
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to Exit ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private bool VersionCheck(string sVersionNo)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            int nCount = 0;
            if (sVersionNo != version)
            {
                //OleDbCommand cmd = DBController.Instance.GetCommand();
                //cmd.CommandText = "

               
                nCount++;
            }
            if (nCount == 0)
                return false;
            else return true;
        
        }
        private void mmurequisition_Click(object sender, EventArgs e)
        {

        }

        private void goodsReturnToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goodsTransferToOtherOutletToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void requisitionCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create);

            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();



            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;

        }

        private void requisitionAuthorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRequisitions oFrom = new frmRequisitions((int)Dictionary.ProductRequisitionStatus.Authorized);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.ShowDialog();
        }

        private void goodsDeliveryAgainstRequisitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRequisitions oFrom = new frmRequisitions((int)Dictionary.ProductRequisitionStatus.Transfer_Out);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.ShowDialog();

        }

        private void goodsReceivedFromHODepotToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmRequisitions oFrom = new frmRequisitions((int)Dictionary.ProductRequisitionStatus.Transfer_Received);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.ShowDialog();

        }

        private void goodsReturnToHODepotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////frmRequisitions oFrom = new frmRequisitions(-1);
            ////oFrom.MdiParent = this;
            ////oFrom.WindowState = FormWindowState.Maximized;
            ////oFrom.ShowDialog();
        }

        private void dataDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmDataDownload ofrmDataDownload = new frmDataDownload();
            //ofrmDataDownload.MdiParent = this;
            ofrmDataDownload.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void retailInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetailInvoice ofrmRetailInvoice = new frmRetailInvoice((int)Dictionary.POSInvoiceUIControl.RetailInvoice, "");
            ofrmRetailInvoice.ShowDialog();
        }

        private void dataTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmDataSend ofrmDataSend = new frmDataSend();
            //ofrmDataSend.MdiParent = this;
            ofrmDataSend.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void goodsTransferToOtherOutletToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmISGMList oFrom = new frmISGMList((int)Dictionary.ProductISGMStatus.Submitted);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.ShowDialog();
        }

        private void iSGMAuthorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmISGMList oFrom = new frmISGMList((int)Dictionary.ProductISGMStatus.Authorized);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.ShowDialog();
        }

        private void goodsReceivedFromOtherOutletToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmSendReceiveISGM oFrom = new frmSendReceiveISGM((int)Dictionary.ProductISGMStatus.Authorized);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.ShowDialog();
        }

        private void iSGMReturnFromHODepotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSendReceiveISGM oFrom = new frmSendReceiveISGM((int)Dictionary.ProductISGMStatus.Send_By_FromWarehouse);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.ShowDialog();
        }

        private void thisSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSystemInfo ofrmSystemInfo = new frmSystemInfo();
            ofrmSystemInfo.MdiParent = this;
            ofrmSystemInfo.Show();
        }

        private void dayStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDayStart ofrmDayStart = new frmDayStart(this);
            ////ofrmDayStart.MdiParent = this;
            //ofrmDayStart.ShowDialog();
            frmOutletProjection oform = new frmOutletProjection(1,this);
            oform.ShowDialog();

            MenuDisable();
            LeftImageMenu(false);
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            label1.Text = "Logged in User: " + "None";
            label2.Text = "System Date: " + "None";
        }

        private void dayEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOutletProjection oform = new frmOutletProjection(2, this);
            oform.ShowDialog();
            MenuDisable();
            LeftImageMenu(false);
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            label1.Text = "Logged in User: " + "None";
            label2.Text = "System Date: " + "None";

        }

        private void stockPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReportFilter oForm = new frmStockReportFilter(1);
            oForm.ShowDialog();
        }

        private void existingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmConsumers oFrom = new frmConsumers();
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmConsumers o = new frmConsumers();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void productDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchProduct oFrom = new frmSearchProduct(1);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            oFrom.ShowDialog();
        }

        private void runningCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///frmSalesPromotion oFrom = new frmSalesPromotion();
            //frmCurrentPromotions oFrom = new frmCurrentPromotions();
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmCurrentPromotions o = new frmCurrentPromotions();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void currentEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeList oFrom = new frmEmployeeList();
            oFrom.ShowDialog();
        }

        private void mmuexit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void modifyInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRetailInvoices oFrom = new frmRetailInvoices(0);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmRetailInvoices o = new frmRetailInvoices(0);
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void reprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRetailInvoices oFrom = new frmRetailInvoices(1);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmRetailInvoices o = new frmRetailInvoices(1);
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void dealerInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetailInvoice ofrmRetailInvoice = new frmRetailInvoice((int)Dictionary.POSInvoiceUIControl.DealerInvoice, "");
            ofrmRetailInvoice.ShowDialog();
        }

        private void paymentReceiveDealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCustomerPaymentReceives oForm = new frmCustomerPaymentReceives();
            //oForm.MdiParent = this;
            //oForm.WindowState = FormWindowState.Maximized;
            //oForm.Show();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmCustomerPaymentReceives o = new frmCustomerPaymentReceives();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void dealerInvoiceEditableUnitPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDealerInvoice oForm = new frmDealerInvoice(2);
            //oForm.MdiParent = this;
            //oForm.MaximizeBox = false;
            //oForm.Show();
        }

        private void dealerInvoiceWithoutIMEIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDealerInvoice oForm = new frmDealerInvoice(3);
            //oForm.MdiParent = this;
            //oForm.MaximizeBox = false;
            //oForm.Show();
        }

        private void iSGMToHOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create);
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void iSGMToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.ISGM_Create);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();

            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.ISGM_Create);
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void sendToCSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Create);
            oFrom.MdiParent = this;
            oFrom.WindowState = FormWindowState.Maximized;
            oFrom.Show();
        }

        private void goodsReceiveAgainstRequisitioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();

            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive);
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void goodsReceiveFromOtherOutletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.ISGM_Receive);
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();


            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.ISGM_Receive);
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }
        
        private void corporateInvoiceB2CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetailInvoice ofrmRetailInvoice = new frmRetailInvoice((int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2C, "");
            ofrmRetailInvoice.ShowDialog();
        }

        private void corporateInvoiceB2BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetailInvoice ofrmRetailInvoice = new frmRetailInvoice((int)Dictionary.POSInvoiceUIControl.CorporateInvoice_B2B, "");
            ofrmRetailInvoice.ShowDialog();
        }
        private void retailInvoiceForHPAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetailInvoice ofrmRetailInvoice = new frmRetailInvoice((int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA, "");
            ofrmRetailInvoice.ShowDialog();
        }
        private void stockLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmStockLedger oForm = new frmStockLedger();
            //oForm.ShowDialog();
        }

        private void stockMovementSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockMovement oform = new frmStockMovement();
            oform.ShowDialog();
        }

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReportFilter oForm = new frmStockReportFilter(2);
            oForm.ShowDialog();
        }

        private void invoiceRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceRegister ofrom = new frmInvoiceRegister((int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_All);
            ofrom.ShowDialog();
        }

        private void salesStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesStatement ofrom = new frmSalesStatement();
            ofrom.ShowDialog();
        }

        private void salesQtyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleQtyNValue ofrom = new frmSaleQtyNValue((int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_All);
            ofrom.ShowDialog();
        }

        private void vAT11KaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVATLedgerPOS ofrmVATLedgerPOS = new frmVATLedgerPOS();
            ofrmVATLedgerPOS.ShowDialog();
        }

        private void customerLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout oform = new frmAbout();
            oform.ShowDialog();
        }
        private void network_signal(object network, EventArgs e)
        {
            if (label1.Text != "Log in User: None")
            {
                //Thread thread = new Thread(timer());
                //thread.Start();
                //timer();
                //ThreadStart threadDelegate = new ThreadStart(timer);
                //Thread newThread = new Thread(threadDelegate);
                //newThread.Start();

                Thread aThread = new Thread(new ThreadStart(networksignal));
                aThread.Start();
                networksignal();
            }
        }

        private void networksignal()
        {

            if (label1.Text != "Log in User: None")
            {
                if (Utility.CheckInternetConnection())
                {
                    picNetworkSignal.Image = Image.FromFile("net1.jpg");

                }
                else
                {
                    picNetworkSignal.Image = Image.FromFile("net2.jpg");
                }
            }
        }
        private void AutoSync(object AutoSync, EventArgs e)
        {
            if (label1.Text != "Log in User: None")
            {
                if (autoSyncToolStripMenuItem.Checked == true)
                {
                    if (Utility.CheckInternetConnection())
                    {
                        if (Utility.CheckTELWEBServer())
                        {
                            DBController.Instance.OpenNewConnection();
                            frmDataSend oform = new frmDataSend();
                            //oform.DataUploadTD(nWHID);

                            frmDataDownload oDownloadForm = new frmDataDownload();
                            oDownloadForm.DataDownloadTD(nWHID, nCustomerID);
                            DBController.Instance.CloseConnection();
                        }
                    }
                }
            }
        }
        private void autoSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoSyncToolStripMenuItem.Checked == false)
            {
                autoSyncToolStripMenuItem.Checked = true;
            }
            else
            {
                autoSyncToolStripMenuItem.Checked = false;
            }

        }

        private void advancePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAdvancePayments oForm = new frmAdvancePayments();
            //oForm.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmAdvancePayments o = new frmAdvancePayments();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void dailyCollectionStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDCSs oForm = new frmDCSs();
            //oForm.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmDCSs o = new frmDCSs();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void aSGWiseSaleForAppsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceRegister ofrom = new frmInvoiceRegister((int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_All);
            ofrom.ShowDialog();
        }

        private void updateHOStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGetHOStock oForm = new frmGetHOStock();
            oForm.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(Parent, "cj.chm");
            frmWebBrowser oform = new frmWebBrowser();
            oform.ShowDialog();
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseBackup oFrom = new frmDatabaseBackup();
            oFrom.ShowDialog();
        }

        private void OfficeItemtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmPOSOfficeItemTrans oFrom = new frmPOSOfficeItemTrans();
            //oFrom.ShowDialog();

            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmPOSOfficeItemTrans oFrom = new frmPOSOfficeItemTrans();
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;

        }

        private void customerCreditApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCustomerCredit oForm = new frmCustomerCredit();
            //oForm.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmCustomerCredit o = new frmCustomerCredit();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void unsoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmUnsoldDefectiveProducts oFrom = new frmUnsoldDefectiveProducts();
            //oFrom.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmUnsoldDefectiveProducts o = new frmUnsoldDefectiveProducts();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void salesLeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSalesLeads oFrom = new frmSalesLeads();
            //oFrom.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmSalesLeads o = new frmSalesLeads();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void potentialCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmPotentialCustomers oFrom = new frmPotentialCustomers();
            //oFrom.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmPotentialCustomers o = new frmPotentialCustomers();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void tGTvsAchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpTGTvsAchSearch oFrom = new frmEmpTGTvsAchSearch(1,"ALL");
            oFrom.ShowDialog();
        }

        private void customerTGTVsAchievementByMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerTGTvsACH oFrom = new frmCustomerTGTvsACH();
            oFrom.ShowDialog();
        }

        private void salesTrandReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesTrandReport oFrom = new frmSalesTrandReport((int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_All);
            oFrom.ShowDialog();
        }

        private void outletDisplayPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmPOSOutletDisplayPositions oFrom = new frmPOSOutletDisplayPositions();
            //oFrom.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmPOSOutletDisplayPositions o = new frmPOSOutletDisplayPositions();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void b2BCustomerEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCustomerTemps oFrom = new frmCustomerTemps();
            //oFrom.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmCustomerTemps o = new frmCustomerTemps();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void reverseAppalicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmInvoiceReverseApplys oFrom = new frmInvoiceReverseApplys();
            //oFrom.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmInvoiceReverseApplys o = new frmInvoiceReverseApplys();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void exchangeOfferMoneyReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExchangeOfferMoneyReceipts oFrom = new frmExchangeOfferMoneyReceipts();
            oFrom.ShowDialog();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmEmployeeAttendances oFrom = new frmEmployeeAttendances();
            //oFrom.Show();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmEmployeeAttendances o = new frmEmployeeAttendances();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void EcommerceOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmECommerceOrders oFrom = new frmECommerceOrders();
            //oFrom.MdiParent = this;
            //oFrom.WindowState = FormWindowState.Maximized;
            //oFrom.Show();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmECommerceOrders o = new frmECommerceOrders();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void executiveWiseLeadTargetVsActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpTGTvsAchSearch oFrom = new frmEmpTGTvsAchSearch(2, "ALL");
            oFrom.ShowDialog();
        }

        private void channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual(1,"ALL");
            oFrom.ShowDialog();
        }

        private void executiveWiseWeeklyReportQtyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /// frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual((int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty);
            //frmTargetView oFrom = new frmTargetView();
            //oFrom.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmTargetView o = new frmTargetView();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual((int)Dictionary.PlanVersionType.ExecutiveLeadTarget, "ALL");
            oFrom.ShowDialog();
        }
        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDashboard oFrom = new frmDashboard();
            oFrom.ShowDialog();
        }

        private void stockLedgerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStockLedger oForm = new frmStockLedger(0);
            oForm.ShowDialog();
        }

        private void musak17LedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockLedger oForm = new frmStockLedger(1);
            oForm.ShowDialog();
        }

        private void dailyProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOutletProjection oForm = new frmOutletProjection(3,this);
            oForm.ShowDialog();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmInvoice oForm = new frmInvoice((int)Dictionary.SalesType.Retail, "");
            ////oForm.MdiParent = this;
            ////oForm.WindowState = FormWindowState.Maximized;
            //oForm.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmInvoice o = new frmInvoice((int)Dictionary.SalesType.Retail, "", "", "", -1);
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void deliveryShipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmTDDeliveryShipments oForm = new frmTDDeliveryShipments();
            //oForm.ShowDialog();

            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmTDDeliveryShipments o = new frmTDDeliveryShipments();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void dMSOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmDMSSalesOrders o = new frmDMSSalesOrders();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void spacialDiscountApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSpecialDiscounts ofrmSpecialDiscounts = new frmSpecialDiscounts();
            //ofrmSpecialDiscounts.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmSpecialDiscounts o = new frmSpecialDiscounts();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pbLogin_Click(object sender, EventArgs e)
        {
            //frmLogin oform = new frmLogin();
            //oform.ShowDialog();
            //if (oform._bflag)
            //{
            //    MenuEnable();
            //    LeftImageMenu(true);
            //}
            Login();
        }

        private void CloseAllWindow()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            //home(false);
        }

        private void LeftImageMenu(bool _bFlag)
        {
            if (!_bFlag)
            {
                pbLogin.Visible = true;
                lblLogin.Text = "Login";


                pbExit.Visible = true;
                lblExit.Visible = true;
                lblExit.Text = "Exit";


                //lblExit.Visible = false;
                pbHome.Visible = false;
                pbDashboard.Visible = false;

                pbInvoice.Visible = false;
                lblInvoice.Visible = false;

                pbRequsition.Visible = false;
                lblRequsition.Visible = false;

                pbLead.Visible = false;
                lblLead.Visible = false;

                pbDCS.Visible = false;
                lblDCS.Visible = false;

                pbUpload.Visible = false;
                lblUpload.Visible = false;

                pbDownload.Visible = false;
                lblDownload.Visible = false;

                pbBackup.Visible = false;
                lblBackup.Visible = false;

                pbHelp.Visible = false;
                lblHelp.Visible = false;

                pbLogout.Visible = false;
                lblLogout.Visible = false;

                pbExit1.Visible = false;
                lblExit1.Visible = false;

            }
            else
            {
                pbLogin.Visible = false;
                pbExit.Visible = false;

                lblExit.Visible = true;
                pbHome.Visible = true;
                lblLogin.Text = "Home";
                pbDashboard.Visible = true;
                lblExit.Text = "Dashboard";

                pbInvoice.Visible = true;
                lblInvoice.Visible = true;

                pbRequsition.Visible = true;
                lblRequsition.Visible = true;

                pbLead.Visible = true;
                lblLead.Visible = true;

                pbDCS.Visible = true;
                lblDCS.Visible = true;

                pbUpload.Visible = true;
                lblUpload.Visible = true;

                pbDownload.Visible = true;
                lblDownload.Visible = true;

                pbBackup.Visible = true;
                lblBackup.Visible = true;

                pbHelp.Visible = true;
                lblHelp.Visible = true;

                pbLogout.Visible = true;
                lblLogout.Visible = true;

                pbExit1.Visible = true;
                lblExit1.Visible = true;
            }

        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            MenuDisable();
            LeftImageMenu(false);
            CloseAllWindow();
        }

        private void bpExit_Click(object sender, EventArgs e)
        {
            pbDashboard_Click(null, null);
            //Exit();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            gbVersion.BringToFront();
        }

        private void pbDashboard_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmPOSDashboard o = new frmPOSDashboard();
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pbExit1_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void pbInvoice_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmInvoice o = new frmInvoice((int)Dictionary.SalesType.Retail, "", "", "", -1);
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }


        public void ExecuteSalesOrder(int nSalesType,string sOrderNo, string sCustomerCode)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmInvoice o = new frmInvoice(nSalesType, "", sOrderNo, sCustomerCode, -1);
            o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pbRequsition_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductRequisitions oFrom = new frmProductRequisitions((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create);
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pbLead_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmSalesLeads o = new frmSalesLeads();
            o.MdiParent = this;
            o.MaximizeBox = false;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Icon = o.MdiParent.Icon;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pbDCS_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmDCSs o = new frmDCSs();
            o.MdiParent = this;
            o.MaximizeBox = false;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Icon = o.MdiParent.Icon;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pbUpload_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmDataSend o = new frmDataSend();
            //o.MdiParent = this;
            //o.MaximizeBox = false;
            //o.StartPosition = FormStartPosition.CenterScreen;
            //o.FormBorderStyle = FormBorderStyle.FixedDialog;
            //o.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            o.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void pbDownload_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmDataDownload o = new frmDataDownload();
            //o.MdiParent = this;
            //o.MaximizeBox = false;
            //o.StartPosition = FormStartPosition.CenterScreen;
            //o.FormBorderStyle = FormBorderStyle.FixedDialog;
            //o.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            o.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void pbBackup_Click(object sender, EventArgs e)
        {
            CloseAllWindow();

            this.Cursor = Cursors.WaitCursor;
            frmDatabaseBackup o = new frmDatabaseBackup();
            o.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void pbHelp_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
        }

        private void home(bool _bflag)
        {
            if (_bflag)
            {
                gbVersion.BringToFront();
            }
            else
            { 
                gbVersion.SendToBack();
            }
        }
        int nCount = 0;
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        private void Trimer()
        {
            
            try
            {
                //timer.Start();
                //timer.Interval = 5000;
                //timer.Elapsed += AutoExecute;
            }
            catch 
            {
                //throw ex;
            }
        }

        public void AutoExecuteThread()
        {
            nCount++;
            timer.Stop();
            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

                // do some simple processing for 10 seconds

                //if (LoadReceivableData() > 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblPOSVersion.Text = " Trigger Count:" + nCount.ToString();
                        lblPOSVersion.Refresh();
                    });
                    //frmDataSend oform = new frmDataSend();
                    //oform.DataUploadTD(nWHID, 0, 0, false);
                    //MessageBox.Show("Data Sending..: " + LoadReceivableData().ToString());
                }


                if (LoadReceivableData() > 0)
                {
                    //for (int i = 1; i <= LoadReceivableData(); i++)
                    //{
                    //    // report the progress in percent
                    //    b.ReportProgress(i/ LoadReceivableData() * 100);
                    //    Thread.Sleep(1000);
                    //}
                    frmDataSend oform = new frmDataSend();
                    oform.DataUploadTD(nWHID, 0, 0, false);
                }

            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate (object o, ProgressChangedEventArgs args)
            {
                lblOutletName.Text = string.Format("{0}% Completed", args.ProgressPercentage);
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {
                lblOutletName.Text = "Finished!";
            });

            bw.RunWorkerAsync();
            timer.Start();
        }


        private void AutoExecute(object sender, EventArgs e)
        {
            timer.Stop();
            int Desc;
           
            this.Invoke((MethodInvoker)delegate
            {

                if (InternetGetConnectedState(out Desc, 0))
                {
                    nCount++;
                    lblPOSVersion.Text = " Trigger Count:" + nCount.ToString();
                    lblPOSVersion.Refresh();

                    if (LoadReceivableData() > 0)
                    {
                        lblOutletName.Text = "Uploading...";
                        lblOutletName.Refresh();

                        DataUploadTD(nWHID);
                        lblOutletName.Text = "Finished";
                        lblOutletName.Refresh();

                        //frmDataSend oform = new frmDataSend();
                        //oform.DataUploadTD(nWHID, 0, 0, false);
                        //MessageBox.Show("Data Sending..: " + LoadReceivableData().ToString());
                    }
                }

            });
            //MessageBox.Show("Internet availability: " + InternetGetConnectedState(out Desc,0).ToString());
            timer.Start();
        }

        private int LoadReceivableData()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            
            CJ.Class.POS.DataTrans _oDataTrans = new CJ.Class.POS.DataTrans();
            _oDataTrans.Refesh(nWHID);           
            return _oDataTrans.Count;

        }

        public bool DataUploadTD(int nWHID)
        {
            nCount = 0;

            _oDataTrans = new CJ.Class.POS.DataTrans();
            nCount = _oDataTrans.RefeshGroupByData(nWHID);

            // UploadMonitoredData(nWHID, nDataCategory, nDataType, _bFlag);

            if (nCount > 0)
            {

                foreach (CJ.Class.POS.DataTran oDataTran in _oDataTrans)
                {

                    #region Day Start End Log
                    if (oDataTran.TableName == "t_DayStartEndLog")
                    {
                        try
                        {
                            //check Done

                            _oDSDayStartEndLog = new CJ.Class.POS.DSDayStartEndLog();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();

                            oDSDayStartEndLog = new DSDayStartEndLog();
                            _oDSDayStartEndLog = oDataSend.GetDSDayStartEndLog(_oDSDayStartEndLog, nWHID);

                            oDSDayStartEndLog.Merge(_oDSDayStartEndLog);
                            oDSDayStartEndLog.AcceptChanges();

                            oSerivce = new Service();
                            oDSDayStartEndLog = oSerivce.SendDayStartEndLog(oDSDayStartEndLog);

                            _oDSDayStartEndLog = new CJ.Class.POS.DSDayStartEndLog();
                            _oDSDayStartEndLog.Merge(oDSDayStartEndLog);
                            _oDSDayStartEndLog.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDayStartEndLogInfo(_oDSDayStartEndLog, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending DayStartEndLog Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Dabatase Backup Log
                    else if (oDataTran.TableName == "t_DBBackupLog")
                    {
                        try
                        {
                            //check Done

                            _oDSDBBackupLog = new CJ.Class.POS.DSDBBackupLog();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();

                            oDSDBBackupLog = new DSDBBackupLog();
                            _oDSDBBackupLog = oDataSend.GetDBBackupLog(_oDSDBBackupLog, nWHID);

                            oDSDBBackupLog.Merge(_oDSDBBackupLog);
                            oDSDBBackupLog.AcceptChanges();

                            oSerivce = new Service();
                            oDSDBBackupLog = oSerivce.SendDSDBBackupLog(oDSDBBackupLog);

                            _oDSDBBackupLog = new CJ.Class.POS.DSDBBackupLog();
                            _oDSDBBackupLog.Merge(oDSDBBackupLog);
                            _oDSDBBackupLog.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDatabaseBackupLogInfo(_oDSDBBackupLog, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Database Backup Log Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Requisition Transfer (HO/Others Outlet/CSD)
                    else if (oDataTran.TableName == "t_StockRequisition")
                    {

                        try
                        {
                            //check Done

                            _oDSRequisition = new CJ.Class.POS.DSRequisition();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSRequisition = new DSRequisition();

                            _oDSRequisition = oDataSend.GetStockRequisition(_oDSRequisition, nWHID);

                            oDSRequisition.Merge(_oDSRequisition);
                            oDSRequisition.AcceptChanges();

                            oSerivce = new Service();
                            oDSRequisition = oSerivce.SendStockRequisiton(oDSRequisition, nWHID);

                            _oDSRequisition = new CJ.Class.POS.DSRequisition();
                            _oDSRequisition.Merge(oDSRequisition);
                            _oDSRequisition.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateStockRequisitionSendInfo(_oDSRequisition, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Stock Requisition Segment /" + ex.Message);
                            return false;
                        }

                    }
                    #endregion

                    #region Retail Consumer
                    else if (oDataTran.TableName == "t_RetailConsumer")
                    {
                        try
                        {
                            //check Done

                            _oDSRetailConsumer = new CJ.Class.POS.DSRetailConsumer();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSRetailConsumer = new DSRetailConsumer();

                            _oDSRetailConsumer = oDataSend.GetRetailConsumer(_oDSRetailConsumer, nWHID);

                            oDSRetailConsumer.Merge(_oDSRetailConsumer);
                            oDSRetailConsumer.AcceptChanges();

                            oSerivce = new Service();
                            oDSRetailConsumer = oSerivce.SendRetailConsumers(oDSRetailConsumer, nWHID);


                            _oDSRetailConsumer = new CJ.Class.POS.DSRetailConsumer();
                            _oDSRetailConsumer.Merge(oDSRetailConsumer);
                            _oDSRetailConsumer.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateConsumerTransferInfo(_oDSRetailConsumer, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Retail Consumer Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Sales Invoice New
                    else if (oDataTran.TableName == "t_SalesInvoice")
                    {
                        try
                        {
                            //check Done
                            _oDSSalesInvoice = new CJ.Class.POS.DSSalesInvoice();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSSalesInvoice = new DSSalesInvoice();

                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }
                            _oDSSalesInvoice = oDataSend.GetSalesInvoiceTDNewInvoice(_oDSSalesInvoice, nWHID);
                            CJ.Class.DBController.Instance.CloseConnection();

                            oDSSalesInvoice.Merge(_oDSSalesInvoice);
                            oDSSalesInvoice.AcceptChanges();

                            oSerivce = new Service();
                            oDSSalesInvoice = oSerivce.SendSalesInvoiceNew(oDSSalesInvoice, nChannelID);

                            _oDSSalesInvoice = new CJ.Class.POS.DSSalesInvoice();
                            _oDSSalesInvoice.Merge(oDSSalesInvoice);
                            _oDSSalesInvoice.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateSalesInvoiceSendInfo(_oDSSalesInvoice, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {

                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Invoice Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Initial Transaction
                    else if (oDataTran.TableName == "InitialTransaction")
                    {
                        try
                        {
                            //check Done
                            _oDSInitialTransaction = new CJ.Class.POS.DSInitialTransaction();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSInitialTransaction = new DSInitialTransaction();

                            CJ.Class.DBController.Instance.OpenNewConnection();
                            _oDSInitialTransaction = oDataSend.GetInitialTransaction(_oDSInitialTransaction, nWHID);
                            CJ.Class.DBController.Instance.CloseConnection();

                            oDSInitialTransaction.Merge(_oDSInitialTransaction);
                            oDSInitialTransaction.AcceptChanges();

                            oSerivce = new Service();
                            oDSInitialTransaction = oSerivce.SendInitialTransaction(oDSInitialTransaction, nChannelID);

                            _oDSInitialTransaction = new CJ.Class.POS.DSInitialTransaction();
                            _oDSInitialTransaction.Merge(oDSInitialTransaction);
                            _oDSInitialTransaction.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateInitialTransactionSendInfo(_oDSInitialTransaction, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                            
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Initial Transaction Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Consumer Balance Tran
                    else if (oDataTran.TableName == "t_ConsumerBalanceTran")
                    {
                        try
                        {
                            //check Done
                            _oDSConsumerBalanceTran = new CJ.Class.POS.DSConsumerBalanceTran();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSConsumerBalanceTran = new DSConsumerBalanceTran();

                            _oDSConsumerBalanceTran = oDataSend.GetConsumerBalanceTran(_oDSConsumerBalanceTran, nWHID);

                            oDSConsumerBalanceTran.Merge(_oDSConsumerBalanceTran);
                            oDSConsumerBalanceTran.AcceptChanges();

                            oSerivce = new Service();
                            oDSConsumerBalanceTran = oSerivce.SendConsumerBalanceTran(oDSConsumerBalanceTran, nWHID);

                            _oDSConsumerBalanceTran = new CJ.Class.POS.DSConsumerBalanceTran();
                            _oDSConsumerBalanceTran.Merge(oDSConsumerBalanceTran);
                            _oDSConsumerBalanceTran.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateConsumerBalanceTransferInfo(_oDSConsumerBalanceTran, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Consumer Balance Tran Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region DCS
                    else if (oDataTran.TableName == "t_DCS")
                    {
                        try
                        {
                            //Check Done
                            _oDSDCSs = new CJ.Class.POS.DSDCSs();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSDCSs = new DSDCSs();

                            _oDSDCSs = oDataSend.GetDCSs(_oDSDCSs, nWHID);


                            oDSDCSs.Merge(_oDSDCSs);
                            oDSDCSs.AcceptChanges();

                            oSerivce = new Service();
                            oDSDCSs = oSerivce.SendDSDCSs(oDSDCSs, nWHID);


                            _oDSDCSs = new CJ.Class.POS.DSDCSs();
                            _oDSDCSs.Merge(oDSDCSs);
                            _oDSDCSs.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDCSInfo(_oDSDCSs, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending DCS Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region SalesInvoiceWarrantyCardNo
                    else if (oDataTran.TableName == "t_SalesInvoiceWarrantyCardNo")
                    {
                        try
                        {
                            //Check Done
                            _oDSWarranty = new CJ.Class.POS.DSWarranty();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();

                            oDSWarranty = new DSWarranty();

                            _oDSWarranty = oDataSend.GetWarrantyCard(_oDSWarranty, nWHID);

                            oDSWarranty.Merge(_oDSWarranty);
                            oDSWarranty.AcceptChanges();

                            oSerivce = new Service();
                            oDSWarranty = oSerivce.SendWarrantyCard(oDSWarranty, nWHID);


                            _oDSWarranty = new CJ.Class.POS.DSWarranty();
                            _oDSWarranty.Merge(oDSWarranty);
                            _oDSWarranty.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateWarrantyCardInfo(_oDSWarranty, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {

                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Warranty Card Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Unsold Defective Product
                    else if (oDataTran.TableName == "t_UnsoldDefectiveProduct")
                    {
                        try
                        {
                            //check Done

                            _oDSUnsoldDefectiveProduct = new CJ.Class.POS.DSUnsoldDefectiveProduct();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSUnsoldDefectiveProduct = new DSUnsoldDefectiveProduct();

                            _oDSUnsoldDefectiveProduct = oDataSend.GetDSUnsoldDefectiveProduct(_oDSUnsoldDefectiveProduct, nWHID);

                            oDSUnsoldDefectiveProduct.Merge(_oDSUnsoldDefectiveProduct);
                            oDSUnsoldDefectiveProduct.AcceptChanges();

                            oSerivce = new Service();
                            oDSUnsoldDefectiveProduct = oSerivce.SendUnsoldDefectiveProduct(oDSUnsoldDefectiveProduct, nWHID);


                            _oDSUnsoldDefectiveProduct = new CJ.Class.POS.DSUnsoldDefectiveProduct();
                            _oDSUnsoldDefectiveProduct.Merge(oDSUnsoldDefectiveProduct);
                            _oDSUnsoldDefectiveProduct.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateUnsoldDefectiveProduct(_oDSUnsoldDefectiveProduct, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Unsold Defective Product Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Office Item Tran
                    else if (oDataTran.TableName == "t_OfficeItemTran")
                    {

                        try
                        {
                            //check Done

                            _oDSOfficeItemTran = new CJ.Class.POS.DSOfficeItemTran();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSOfficeItemTran = new DSOfficeItemTran();

                            _oDSOfficeItemTran = oDataSend.GetOfficeItemTran(_oDSOfficeItemTran, nWHID);

                            oDSOfficeItemTran.Merge(_oDSOfficeItemTran);
                            oDSOfficeItemTran.AcceptChanges();

                            oSerivce = new Service();
                            oDSOfficeItemTran = oSerivce.SendOfficeItemTran(oDSOfficeItemTran, nWHID);

                            _oDSOfficeItemTran = new CJ.Class.POS.DSOfficeItemTran();
                            _oDSOfficeItemTran.Merge(oDSOfficeItemTran);
                            _oDSOfficeItemTran.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateOfficeItemTran(_oDSOfficeItemTran, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending OficeItem Tran Segment /" + ex.Message);
                            return false;
                        }

                    }
                    #endregion

                    #region CustomerCreditApprovalCollection
                    else if (oDataTran.TableName == "t_CustomerCreditApprovalCollection")
                    {
                        try
                        {
                            //check Done

                            _oDSCustomerCreditApprovalCollection = new CJ.Class.POS.DSCustomerCreditApprovalCollection();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSCustomerCreditApprovalCollection = new DSCustomerCreditApprovalCollection();

                            _oDSCustomerCreditApprovalCollection = oDataSend.GetCustomerCreditApprovalCollection(_oDSCustomerCreditApprovalCollection, nWHID);

                            oDSCustomerCreditApprovalCollection.Merge(_oDSCustomerCreditApprovalCollection);
                            oDSCustomerCreditApprovalCollection.AcceptChanges();

                            oSerivce = new Service();
                            oDSCustomerCreditApprovalCollection = oSerivce.SendCustomerCreditApprovalCollection(oDSCustomerCreditApprovalCollection, nWHID);


                            _oDSCustomerCreditApprovalCollection = new CJ.Class.POS.DSCustomerCreditApprovalCollection();
                            _oDSCustomerCreditApprovalCollection.Merge(oDSCustomerCreditApprovalCollection);
                            _oDSCustomerCreditApprovalCollection.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateCustomerCreditCollectionInfo(_oDSCustomerCreditApprovalCollection, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Customer Credit Collection Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region SalesLead
                    else if (oDataTran.TableName == "t_SalesLeadManagement")
                    {
                        try
                        {
                            //check Done

                            _oDSSalesLead = new CJ.Class.POS.DSSalesLead();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSSalesLead = new DSSalesLead();

                            _oDSSalesLead = oDataSend.GetSalesLeadNew(_oDSSalesLead, nWHID);

                            oDSSalesLead.Merge(_oDSSalesLead);
                            oDSSalesLead.AcceptChanges();

                            oSerivce = new Service();
                            oDSSalesLead = oSerivce.SendSalesLead_new2(oDSSalesLead, nWHID);


                            _oDSSalesLead = new CJ.Class.POS.DSSalesLead();
                            _oDSSalesLead.Merge(oDSSalesLead);
                            _oDSSalesLead.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateSalesLead(_oDSSalesLead, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Sales Lead Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region SalesLead History
                    else if (oDataTran.TableName == "t_SalesLeadManagementHistory")
                    {
                        try
                        {
                            //check Done

                            _oDSSalesLead = new CJ.Class.POS.DSSalesLead();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSSalesLead = new DSSalesLead();

                            _oDSSalesLead = oDataSend.GetSalesLeadHistory(_oDSSalesLead, nWHID);

                            oDSSalesLead.Merge(_oDSSalesLead);
                            oDSSalesLead.AcceptChanges();

                            oSerivce = new Service();
                            oDSSalesLead = oSerivce.SendSalesLeadHistory(oDSSalesLead, nWHID);


                            _oDSSalesLead = new CJ.Class.POS.DSSalesLead();
                            _oDSSalesLead.Merge(oDSSalesLead);
                            _oDSSalesLead.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateSalesLeadHistory(_oDSSalesLead, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Sales Lead History Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Potential Customer
                    else if (oDataTran.TableName == "t_PotentialCustomerList")
                    {
                        try
                        {
                            //check Done

                            _oDSPotentialCustomer = new CJ.Class.POS.DSPotentialCustomer();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSPotentialCustomer = new DSPotentialCustomer();

                            _oDSPotentialCustomer = oDataSend.GetPotentialCustomer(_oDSPotentialCustomer, nWHID);

                            oDSPotentialCustomer.Merge(_oDSPotentialCustomer);
                            oDSPotentialCustomer.AcceptChanges();

                            oSerivce = new Service();
                            oDSPotentialCustomer = oSerivce.SendPotentialCustomer(oDSPotentialCustomer, nWHID);


                            _oDSPotentialCustomer = new CJ.Class.POS.DSPotentialCustomer();
                            _oDSPotentialCustomer.Merge(oDSPotentialCustomer);
                            _oDSPotentialCustomer.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdatePotentialCustomer(_oDSPotentialCustomer, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Potential Customer Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Outlet Display Position
                    else if (oDataTran.TableName == "t_OutletDisplayPosition")
                    {
                        try
                        {
                            //check Done

                            _oDSOutletDisplayPosition = new CJ.Class.POS.DSOutletDisplayPosition();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSOutletDisplayPosition = new DSOutletDisplayPosition();

                            _oDSOutletDisplayPosition = oDataSend.GetOutletDisplayPosition(_oDSOutletDisplayPosition, nWHID);

                            oDSOutletDisplayPosition.Merge(_oDSOutletDisplayPosition);
                            oDSOutletDisplayPosition.AcceptChanges();

                            oSerivce = new Service();
                            oDSOutletDisplayPosition = oSerivce.SendOutletDisplayPosition(oDSOutletDisplayPosition, nWHID);


                            _oDSOutletDisplayPosition = new CJ.Class.POS.DSOutletDisplayPosition();
                            _oDSOutletDisplayPosition.Merge(oDSOutletDisplayPosition);
                            _oDSOutletDisplayPosition.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateOutletDisplayPosition(_oDSOutletDisplayPosition, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Outlet Display Position  Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Outlet Display Position
                    else if (oDataTran.TableName == "t_OutletDisplayPositionHistory")
                    {
                        try
                        {
                            //check Done

                            _oDSOutletDisplayPositionHistory = new CJ.Class.POS.DSOutletDisplayPosition();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSOutletDisplayPositionHistory = new DSOutletDisplayPosition();

                            _oDSOutletDisplayPositionHistory = oDataSend.GetOutletDisplayPositionHistory(_oDSOutletDisplayPositionHistory, nWHID);

                            oDSOutletDisplayPositionHistory.Merge(_oDSOutletDisplayPositionHistory);
                            oDSOutletDisplayPositionHistory.AcceptChanges();

                            oSerivce = new Service();
                            oDSOutletDisplayPositionHistory = oSerivce.SendOutletDisplayPositionHistory(oDSOutletDisplayPositionHistory);


                            _oDSOutletDisplayPositionHistory = new CJ.Class.POS.DSOutletDisplayPosition();
                            _oDSOutletDisplayPositionHistory.Merge(oDSOutletDisplayPositionHistory);
                            _oDSOutletDisplayPositionHistory.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDisplayPositionHistory(_oDSOutletDisplayPositionHistory, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Outlet Display Position History Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Customer Temp
                    else if (oDataTran.TableName == "t_CustomerTemp")
                    {
                        try
                        {
                            //check Done

                            _oDSCustomerTemp = new CJ.Class.POS.DSCustomerTemp();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSCustomerTemp = new DSCustomerTemp();

                            _oDSCustomerTemp = oDataSend.GetCustomerTemp(_oDSCustomerTemp, nWHID);

                            oDSCustomerTemp.Merge(_oDSCustomerTemp);
                            oDSCustomerTemp.AcceptChanges();

                            oSerivce = new Service();
                            oDSCustomerTemp = oSerivce.SendCustomerTempData(oDSCustomerTemp, nWHID);


                            _oDSCustomerTemp = new CJ.Class.POS.DSCustomerTemp();
                            _oDSCustomerTemp.Merge(oDSCustomerTemp);
                            _oDSCustomerTemp.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateCustomerTempTransferInfo(_oDSCustomerTemp, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Customer Temp Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Invoice Reverse Appalication
                    else if (oDataTran.TableName == "t_InvoiceReverse")
                    {
                        try
                        {
                            //check Done

                            _oDSInvoiceReverse = new CJ.Class.POS.DSInvoiceReverse();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSInvoiceReverse = new DSInvoiceReverse();

                            _oDSInvoiceReverse = oDataSend.GetInvoiceReverse(_oDSInvoiceReverse, nWHID);

                            oDSInvoiceReverse.Merge(_oDSInvoiceReverse);
                            oDSInvoiceReverse.AcceptChanges();

                            oSerivce = new Service();
                            oDSInvoiceReverse = oSerivce.SendInvoiceReverseData(oDSInvoiceReverse, nWHID);


                            _oDSInvoiceReverse = new CJ.Class.POS.DSInvoiceReverse();
                            _oDSInvoiceReverse.Merge(oDSInvoiceReverse);
                            _oDSInvoiceReverse.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateInvoiceReverseTransferInfo(_oDSInvoiceReverse, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Reverse Invoice Appalication Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Exchange Offer MR
                    else if (oDataTran.TableName == "t_ExchangeOfferMR")
                    {
                        try
                        {
                            //check Done

                            _oDSExchangeOfferMR = new CJ.Class.POS.DSExchangeOfferMR();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSExchangeOfferMR = new DSExchangeOfferMR();

                            _oDSExchangeOfferMR = oDataSend.GetExchangeOfferMR(_oDSExchangeOfferMR, nWHID);

                            oDSExchangeOfferMR.Merge(_oDSExchangeOfferMR);
                            oDSExchangeOfferMR.AcceptChanges();

                            oSerivce = new Service();
                            oDSExchangeOfferMR = oSerivce.SendExchangeOfferMRData(oDSExchangeOfferMR, nWHID);


                            _oDSExchangeOfferMR = new CJ.Class.POS.DSExchangeOfferMR();
                            _oDSExchangeOfferMR.Merge(oDSExchangeOfferMR);
                            _oDSExchangeOfferMR.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateExchangeOfferMRInfo(_oDSExchangeOfferMR, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Exchange Offer MR Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Exchange Offer Job
                    else if (oDataTran.TableName == "t_ExchangeOfferJob")
                    {
                        try
                        {
                            //check Done

                            _oDSExchangeOfferJob = new CJ.Class.POS.DSExchangeOfferJob();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSExchangeOfferJob = new DSExchangeOfferJob();

                            _oDSExchangeOfferJob = oDataSend.GetExchangeOfferJob(_oDSExchangeOfferJob, nWHID);

                            oDSExchangeOfferJob.Merge(_oDSExchangeOfferJob);
                            oDSExchangeOfferJob.AcceptChanges();

                            oSerivce = new Service();
                            oDSExchangeOfferJob = oSerivce.SendExchangeOfferJob(oDSExchangeOfferJob, nWHID);


                            _oDSExchangeOfferJob = new CJ.Class.POS.DSExchangeOfferJob();
                            _oDSExchangeOfferJob.Merge(oDSExchangeOfferJob);
                            _oDSExchangeOfferJob.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateExchangeOfferJobData(_oDSExchangeOfferJob, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Exchange Offer Job  Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Sales Invoice Ecommerce
                    else if (oDataTran.TableName == "t_SalesInvoiceEcommerce")
                    {
                        try
                        {
                            //check Done

                            _oDSSalesInvoiceEcommerce = new CJ.Class.POS.DSSalesInvoiceEcommerce();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSSalesInvoiceEcommerce = new DSSalesInvoiceEcommerce();

                            _oDSSalesInvoiceEcommerce = oDataSend.GetSalesInvoiceEcommerce(_oDSSalesInvoiceEcommerce, nWHID);

                            oDSSalesInvoiceEcommerce.Merge(_oDSSalesInvoiceEcommerce);
                            oDSSalesInvoiceEcommerce.AcceptChanges();

                            oSerivce = new Service();
                            oDSSalesInvoiceEcommerce = oSerivce.UpdateEcommerceOrdere(oDSSalesInvoiceEcommerce, nWHID);


                            _oDSSalesInvoiceEcommerce = new CJ.Class.POS.DSSalesInvoiceEcommerce();
                            _oDSSalesInvoiceEcommerce.Merge(oDSSalesInvoiceEcommerce);
                            _oDSSalesInvoiceEcommerce.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateEcommerceOrderData(_oDSSalesInvoiceEcommerce, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Sales Invoice Ecommerce  Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Sales Invoice Payment Mode
                    else if (oDataTran.TableName == "t_SalesInvoicePaymentMode")
                    {
                        try
                        {
                            //check Done

                            _oDSSalesInvoicePaymentMode = new CJ.Class.POS.DSSalesInvoice();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSSalesInvoicePaymentMode = new DSSalesInvoice();

                            _oDSSalesInvoicePaymentMode = oDataSend.GetSalesInvoicePaymentEcommerce(_oDSSalesInvoicePaymentMode, nWHID);

                            oDSSalesInvoicePaymentMode.Merge(_oDSSalesInvoicePaymentMode);
                            oDSSalesInvoicePaymentMode.AcceptChanges();

                            oSerivce = new Service();
                            oDSSalesInvoicePaymentMode = oSerivce.SendSalesinvoicePaymentMode(oDSSalesInvoicePaymentMode);


                            _oDSSalesInvoicePaymentMode = new CJ.Class.POS.DSSalesInvoice();
                            _oDSSalesInvoicePaymentMode.Merge(oDSSalesInvoicePaymentMode);
                            _oDSSalesInvoicePaymentMode.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateSalesInvoicePaymentModeInfo(_oDSSalesInvoicePaymentMode, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {

                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Invoice Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion

                    #region Outlet Attendance Info
                    else if (oDataTran.TableName == "t_OutletAttendanceInfo")
                    {

                        try
                        {
                            //check Done

                            _oDSOutletAttendanceInfo = new CJ.Class.POS.DSOutletAttendanceInfo();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSOutletAttendanceInfo = new DSOutletAttendanceInfo();

                            _oDSOutletAttendanceInfo = oDataSend.GetOutletAttendanceInfo(_oDSOutletAttendanceInfo, nWHID);

                            oDSOutletAttendanceInfo.Merge(_oDSOutletAttendanceInfo);
                            oDSOutletAttendanceInfo.AcceptChanges();

                            oSerivce = new Service();
                            // oDSOutletAttendanceInfo = oSerivce.SendOfficeItemTran(oDSOutletAttendanceInfo, nWHID);

                            _oDSOutletAttendanceInfo = new CJ.Class.POS.DSOutletAttendanceInfo();
                            _oDSOutletAttendanceInfo.Merge(oDSOutletAttendanceInfo);
                            _oDSOutletAttendanceInfo.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            //oDataSend.UpdateOfficeItemTran(_oDSOutletAttendanceInfo, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending OficeItem Tran Segment /" + ex.Message);
                            return false;
                        }

                    }
                    #endregion

                    #region VAT Paid Product Serial
                    else if (oDataTran.TableName == "t_ProductStockSerialVatPaid")
                    {

                        try
                        {
                            //check Done

                            _oDSVatPaidProductSerial = new CJ.Class.POS.DSProductTransaction();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSVatPaidProductSerial = new DSProductTransaction();

                            _oDSVatPaidProductSerial = oDataSend.GetVATPaidProductSerial(_oDSVatPaidProductSerial, nWHID);

                            oDSVatPaidProductSerial.Merge(_oDSVatPaidProductSerial);
                            oDSVatPaidProductSerial.AcceptChanges();

                            oSerivce = new Service();
                            oDSVatPaidProductSerial = oSerivce.SendVatPaidProductSerial(oDSVatPaidProductSerial);

                            _oDSVatPaidProductSerial = new CJ.Class.POS.DSProductTransaction();
                            _oDSVatPaidProductSerial.Merge(oDSVatPaidProductSerial);
                            _oDSVatPaidProductSerial.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateVatPaidProductSerial(_oDSVatPaidProductSerial, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Vat Paid Product Serial Segment /" + ex.Message);
                            return false;
                        }

                    }
                    #endregion

                    #region  Customer Tran
                    else if (oDataTran.TableName == "t_CustomerTran")
                    {

                        try
                        {
                            //check Done

                            _oDSCustomerTransaction = new CJ.Class.POS.DSCustomerTransaction();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSCustomerTransaction = new DSCustomerTransaction();

                            _oDSCustomerTransaction = oDataSend.GetCustomerTransaction(_oDSCustomerTransaction, nWHID);

                            oDSCustomerTransaction.Merge(_oDSCustomerTransaction);
                            oDSCustomerTransaction.AcceptChanges();

                            oSerivce = new Service();
                            oDSCustomerTransaction = oSerivce.SendCustomerTransaction(oDSCustomerTransaction, nWHID);

                            _oDSCustomerTransaction = new CJ.Class.POS.DSCustomerTransaction();
                            _oDSCustomerTransaction.Merge(oDSCustomerTransaction);
                            _oDSCustomerTransaction.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateCustomerTranSendInfo(_oDSCustomerTransaction, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Customer Tran Segment /" + ex.Message);
                            return false;
                        }

                    }
                    #endregion

                    #region Outlet Daily Projection
                    else if (oDataTran.TableName == "t_OutletDailyProjection")
                    {

                        try
                        {
                            //check Done

                            _oDSOutletDailyProjection = new CJ.Class.POS.DSBasicData();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSOutletDailyProjection = new DSBasicData();

                            _oDSOutletDailyProjection = oDataSend.GetOutletDailyProjection(_oDSOutletDailyProjection, nWHID);

                            oDSOutletDailyProjection.Merge(_oDSOutletDailyProjection);
                            oDSOutletDailyProjection.AcceptChanges();

                            oSerivce = new Service();
                            oDSOutletDailyProjection = oSerivce.SendOutletDailyProjection(oDSOutletDailyProjection);

                            _oDSOutletDailyProjection = new CJ.Class.POS.DSBasicData();
                            _oDSOutletDailyProjection.Merge(oDSOutletDailyProjection);
                            _oDSOutletDailyProjection.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDailyProjectionData(_oDSOutletDailyProjection, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Outlet Daily Projection Segment /" + ex.Message);
                            return false;
                        }

                    }

                    #endregion

                    #region  Duty Tran Outlet ISGM
                    else if (oDataTran.TableName == "t_DutyTranOutletISGM")
                    {

                        try
                        {
                            //check Done

                            _oDSDutyTranISGM = new CJ.Class.POS.DSDutyTranISGM();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSDutyTranISGM = new DSDutyTranISGM();

                            _oDSDutyTranISGM = oDataSend.GetDutyTranISGM(_oDSDutyTranISGM, nWHID);

                            oDSDutyTranISGM.Merge(_oDSDutyTranISGM);
                            oDSDutyTranISGM.AcceptChanges();

                            oSerivce = new Service();
                            oDSDutyTranISGM = oSerivce.SendDSDutyTranISGM(oDSDutyTranISGM, nWHID);

                            _oDSDutyTranISGM = new CJ.Class.POS.DSDutyTranISGM();
                            _oDSDutyTranISGM.Merge(oDSDutyTranISGM);
                            _oDSDutyTranISGM.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDutyTranISGMInfo(_oDSDutyTranISGM, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Duty Tran Outlet ISGM /" + ex.Message);
                            return false;
                        }

                    }
                    #endregion

                    #region  Delivery Shipment
                    else if (oDataTran.TableName == "t_TDDeliveryShipment")
                    {

                        try
                        {
                            //check Done

                            _oDSDeliveryShipment = new CJ.Class.POS.DSBasicData();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSDeliveryShipment = new DSBasicData();

                            _oDSDeliveryShipment = oDataSend.GetTDDeliveryShipment(_oDSDeliveryShipment, nWHID);

                            oDSDeliveryShipment.Merge(_oDSDeliveryShipment);
                            oDSDeliveryShipment.AcceptChanges();

                            oSerivce = new Service();
                            oDSDeliveryShipment = oSerivce.SendTDDeliveryShipment(oDSDeliveryShipment, nWHID);

                            _oDSDeliveryShipment = new CJ.Class.POS.DSBasicData();
                            _oDSDeliveryShipment.Merge(oDSDeliveryShipment);
                            _oDSDeliveryShipment.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateTDDeliveryShipment(_oDSDeliveryShipment, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error TD Delivery Shipment/" + ex.Message);
                            return false;
                        }

                    }
                    #endregion

                    #region Promo Discount Special
                    else if (oDataTran.TableName == "t_PromoDiscountSpecial")
                    {
                        try
                        {
                            _oDSPromoDiscount = new CJ.Class.Promotion.DSPromoDiscount();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSPromoDiscount = new DSPromoDiscount();
                            _oDSPromoDiscount = oDataSend.GetSpecialDiscount(_oDSPromoDiscount, nWHID);
                            oDSPromoDiscount.Merge(_oDSPromoDiscount);
                            oDSPromoDiscount.AcceptChanges();
                            oSerivce = new Service();
                            oDSPromoDiscount = oSerivce.SendPromoDiscount(oDSPromoDiscount, nWHID);
                            _oDSPromoDiscount = new CJ.Class.Promotion.DSPromoDiscount();
                            _oDSPromoDiscount.Merge(oDSPromoDiscount);
                            _oDSPromoDiscount.AcceptChanges();
                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdatePromoDiscountSpecialInfo(_oDSPromoDiscount, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Promo Discount Special Segment /" + ex.Message);
                            return false;
                        }
                    }
                    #endregion
                }
            }
            return true;
        }
        private bool UploadMonitoredData(int nWHID, int nDataCategory, int nDataType, bool _bFlag)
        {
            #region DataMonitoring
            try
            {
                _oDSDataMonitoring = new CJ.Class.POS.DSDataMonitoring();
                oDataSend = new CJ.Class.DataTransfer.DataSend();
                oDSDataMonitoring = new DSDataMonitoring();

                _oDSDataMonitoring = oDataSend.GetMonitoredData(_oDSDataMonitoring, nWHID, nDataCategory, nDataType);

                oDSDataMonitoring.Merge(_oDSDataMonitoring);
                oDSDataMonitoring.AcceptChanges();

                oSerivce = new Service();
                oSerivce.SendMonitoredData(oDSDataMonitoring, nWHID);
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Sending Monitored Data /" + ex.Message);
                return false;
            }

            #endregion
            return true;
        }

        private void goodsRequisitionMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goodsRequisitionMovementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void pettyCashExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmPettyCashExpenses ofrmPettyCashExpense = new frmPettyCashExpenses();
            //ofrmPettyCashExpense.ShowDialog();
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmPettyCashExpenses oFrom = new frmPettyCashExpenses();
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void importXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportXMLs oForm = new POS.frmImportXMLs();
            oForm.ShowDialog();
        }

        private void extendedWarrantyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmSmartWarrantys oFrom = new frmSmartWarrantys();
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;

        }

        private void dayPlanManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmDayPlans oFrom = new frmDayPlans();
            oFrom.MdiParent = this;
            oFrom.MaximizeBox = true;
            oFrom.StartPosition = FormStartPosition.CenterScreen;
            oFrom.FormBorderStyle = FormBorderStyle.FixedDialog;
            oFrom.WindowState = FormWindowState.Maximized;
            oFrom.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void invoiceRegisterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInvoiceRegister ofrom = new frmInvoiceRegister((int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Retail_Other);
            ofrom.ShowDialog();
        }

        private void invoiceRegisterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmInvoiceRegister ofrom = new frmInvoiceRegister((int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Dealer);
            ofrom.ShowDialog();
        }

        private void aSGWiseSaleForAppsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInvoiceRegister ofrom = new frmInvoiceRegister((int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Retail_Other);
            ofrom.ShowDialog();
        }

        private void aSGWiseSaleForAppsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmInvoiceRegister ofrom = new frmInvoiceRegister((int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Dealer);
            ofrom.ShowDialog();
        }

        private void salesQuantityValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleQtyNValue ofrom = new frmSaleQtyNValue((int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_Retail_Other);
            ofrom.ShowDialog();
        }

        private void salesQuantityValueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSaleQtyNValue ofrom = new frmSaleQtyNValue((int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_Dealer);
            ofrom.ShowDialog();
        }

        private void salesTrendReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesTrandReport oFrom = new frmSalesTrandReport((int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_Retail_Other);
            oFrom.ShowDialog();
        }

        private void salesTrendReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSalesTrandReport oFrom = new frmSalesTrandReport((int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_Dealer);
            oFrom.ShowDialog();
        }

        private void salesStatementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSalesStatement ofrom = new frmSalesStatement();
            ofrom.ShowDialog();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"D:\Program Files\Transcom Electronics Limited\My Corner\MyCorner.exe");
            //Application.Exit();
            
            //System.IO.Compression.zipFile

            frmDownloadVersion ofrom = new frmDownloadVersion();
            ofrom.ShowDialog();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual(1,"Retail");
            oFrom.ShowDialog();
        }

        private void executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual((int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty, "Retail");
            oFrom.ShowDialog();
        }

        private void executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual((int)Dictionary.PlanVersionType.ExecutiveLeadTarget, "Retail");
            oFrom.ShowDialog();
        }

        private void executiveWiseLeadTargetVsActualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmpTGTvsAchSearch oFrom = new frmEmpTGTvsAchSearch(2, "Retail");
            oFrom.ShowDialog();
        }

        private void mAGWeekPositionWiseTargetVsActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMAGWeekPositionTargetVsActual oFrom = new frmMAGWeekPositionTargetVsActual();
            oFrom.ShowDialog();
        }
    }
}