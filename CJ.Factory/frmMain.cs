using System;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace CJ.Factory
{
    public partial class frmMain : Form
    {
        SystemInfo oSystemInfo;
        int nLocationID = 0;
        public frmMain()
        {
            InitializeComponent();

            // MenuDisable();
            LeftImageMenu(false);
        }


        //public void MenuDisable()
        //{
        //    extendedWarrantyToolStripMenuItem.Enabled = false;
        //    mnuLogIn.Enabled = true;
        //    mnuLogOut.Enabled = false;
        //    mnuChangePassword.Enabled = false;
        //    mmuexit.Enabled = true;
        //    thisSystemToolStripMenuItem.Enabled = false;
        //    dayStartToolStripMenuItem.Enabled = false;
        //    dayEndToolStripMenuItem.Enabled = false;
        //    updateHOStockToolStripMenuItem.Enabled = false;
        //    //monthEndToolStripMenuItem.Enabled = false;
        //    //yearEndToolStripMenuItem.Enabled = false;
        //    currentEmployeeToolStripMenuItem.Enabled = false;
        //    productDetailsToolStripMenuItem.Enabled = false;
        //    runningCPToolStripMenuItem.Enabled = false;
        //    existingToolStripMenuItem.Enabled = false;
        //    requisitionCreationToolStripMenuItem.Enabled = false;
        //    aSGWiseSaleForAppsToolStripMenuItem.Enabled = false;


        //    iSGMToHOToolStripMenuItem.Enabled = false;
        //    iSGMToToolStripMenuItem.Enabled = false;
        //    goodsReceiveAgainstRequisitioToolStripMenuItem.Enabled = false;
        //    goodsReceiveFromOtherOutletToolStripMenuItem.Enabled = false;
        //    databaseBackupToolStripMenuItem.Enabled = false;
        //    //requisitionAuthorizationToolStripMenuItem.Enabled = false;
        //    //goodsDeliveryAgainstRequisitionToolStripMenuItem.Enabled = false;
        //    //goodsReceivedFromHODepotToolStripMenuItem1.Enabled = false;
        //    //goodsReturnToHODepotToolStripMenuItem.Enabled = false;
        //    //stockAdjustmentToolStripMenuItem.Enabled = false;
        //    //goodsTransferToOtherOutletToolStripMenuItem1.Enabled = false;
        //    //iSGMAuthorizationToolStripMenuItem.Enabled = false;
        //    //goodsReceivedFromOtherOutletToolStripMenuItem1.Enabled = false;
        //    //iSGMReturnFromHODepotToolStripMenuItem.Enabled = false;
        //    retailInvoiceToolStripMenuItem.Enabled = false;
        //    dealerInvoiceToolStripMenuItem.Enabled = false;
        //    retailInvoiceForHPAToolStripMenuItem.Enabled = false;
        //    corporateInvoiceB2CToolStripMenuItem.Enabled = false;
        //    corporateInvoiceB2BToolStripMenuItem.Enabled = false;
        //    modifyInvoicesToolStripMenuItem.Enabled = false;
        //    //giftVoucherReceiptToolStripMenuItem.Enabled = false;
        //    advancePaymentToolStripMenuItem.Enabled = false;
        //    //creditCollectionToolStripMenuItem.Enabled = false;
        //    //customerAdjustmentToolStripMenuItem.Enabled = false;
        //    dailyCollectionStatementToolStripMenuItem.Enabled = false;
        //    stockPositionToolStripMenuItem.Enabled = false;
        //    stockLedgerToolStripMenuItem.Enabled = false;
        //    stockMovementSummaryToolStripMenuItem.Enabled = false;
        //    serialToolStripMenuItem.Enabled = false;
        //    invoiceRegisterToolStripMenuItem.Enabled = false;
        //    salesStatementToolStripMenuItem.Enabled = false;
        //    salesQtyValueToolStripMenuItem.Enabled = false;
        //    vAT11KaToolStripMenuItem.Enabled = false;
        //    customerLedgerToolStripMenuItem.Enabled = false;
        //    dataDownloadToolStripMenuItem.Enabled = false;
        //    dataTransferToolStripMenuItem.Enabled = false;
        //    dealerInvoiceEditableUnitPriceToolStripMenuItem.Enabled = false;
        //    dealerInvoiceWithoutIMEIToolStripMenuItem.Enabled = false;
        //    paymentReceiveDealerToolStripMenuItem.Enabled = false;

        //    stockPositionToolStripMenuItem.Enabled = false;
        //    stockLedgerToolStripMenuItem.Enabled = false;
        //    stockMovementSummaryToolStripMenuItem.Enabled = false;
        //    serialToolStripMenuItem.Enabled = false;
        //    invoiceRegisterToolStripMenuItem.Enabled = false;
        //    salesStatementToolStripMenuItem.Enabled = false;
        //    salesQtyValueToolStripMenuItem.Enabled = false;
        //    vAT11KaToolStripMenuItem.Enabled = false;
        //    customerLedgerToolStripMenuItem.Enabled = false;
        //    reprintToolStripMenuItem.Enabled = false;

        //    customerCreditApprovalToolStripMenuItem.Enabled = false;
        //    unsoldToolStripMenuItem.Enabled = false;
        //    OfficeItemtoolStripMenuItem1.Enabled = false;
        //    salesLeadToolStripMenuItem.Enabled = false;
        //    potentialCustomerToolStripMenuItem.Enabled = false;
        //    outletDisplayPositionToolStripMenuItem.Enabled = false;

        //    tGTvsAchToolStripMenuItem.Enabled = false;
        //    customerTGTVsAchievementByMonthToolStripMenuItem.Enabled = false;
        //    salesTrandReportToolStripMenuItem.Enabled = false;
        //    b2BCustomerEntryToolStripMenuItem.Enabled = false;
        //    reverseAppalicationToolStripMenuItem.Enabled = false;
        //    EcommerceOrderToolStripMenuItem.Enabled = false;
        //    //tsbLogIn.Enabled = true;
        //    //tsbLogOut.Enabled = false;
        //    dailyProjectionToolStripMenuItem.Enabled = false;
        //    deliveryShipmentToolStripMenuItem.Enabled = false;


        //    goodsRequisitionMovementToolStripMenuItem.Enabled = false;
        //    invoiceToolStripMenuItem.Enabled = false;
        //    executiveWiseLeadTargetVsActualToolStripMenuItem.Enabled = false;
        //    channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem.Enabled = false;
        //    executiveWiseWeeklyReportQtyValueToolStripMenuItem.Enabled = false;
        //    executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem.Enabled = false;
        //    attendanceToolStripMenuItem.Enabled = false;
        //    dashboardToolStripMenuItem1.Enabled = false;

        //    salesInvoiceToolStripMenuItem.Enabled = false;
        //    paymentToolStripMenuItem.Enabled = false;
        //    spacialDiscountApplicationToolStripMenuItem.Enabled = false;
        //    stockReportsToolStripMenuItem.Enabled = false;
        //    salesReportsToolStripMenuItem.Enabled = false;
        //    accountsReportToolStripMenuItem.Enabled = false;
        //    importXMLToolStripMenuItem.Enabled = false;
        //    dMSOrderToolStripMenuItem.Enabled = false;
        //}
        //public void MenuEnable()
        //{
        //    mnuLogIn.Enabled = false;
        //    mnuLogOut.Enabled = true;
        //    //tsbLogIn.Enabled = false;
        //    //tsbLogOut.Enabled = true;
        //    if (oSystemInfo.IsActiveSalesOrder == (int)Dictionary.IsActive.Active)
        //    {
        //        dMSOrderToolStripMenuItem.Enabled = true;
        //    }
        //    else
        //    {
        //        dMSOrderToolStripMenuItem.Enabled = false;
        //    }
        //    extendedWarrantyToolStripMenuItem.Enabled = true;
        //    goodsRequisitionMovementToolStripMenuItem.Enabled = true;
        //    invoiceToolStripMenuItem.Enabled = true;
        //    executiveWiseLeadTargetVsActualToolStripMenuItem.Enabled = true;
        //    channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem.Enabled = true;
        //    executiveWiseWeeklyReportQtyValueToolStripMenuItem.Enabled = true;
        //    executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem.Enabled = true;
        //    attendanceToolStripMenuItem.Enabled = true;
        //    dashboardToolStripMenuItem1.Enabled = true;
        //    salesInvoiceToolStripMenuItem.Enabled = true;
        //    paymentToolStripMenuItem.Enabled = true;
        //    spacialDiscountApplicationToolStripMenuItem.Enabled = true;
        //    stockReportsToolStripMenuItem.Enabled = true;
        //    salesReportsToolStripMenuItem.Enabled = true;
        //    accountsReportToolStripMenuItem.Enabled = true;

        //    dataDownloadToolStripMenuItem.Enabled = true;
        //    _oUserPermissions = new UserPermissions();
        //    _oUserPermissions = _oUserPermissions.Refresh(_oUserPermissions, Utility.UserId);
        //    oUserPermissions = _oUserPermissions;
        //    updateHOStockToolStripMenuItem.Enabled = true;
        //    databaseBackupToolStripMenuItem.Enabled = true;
        //    importXMLToolStripMenuItem.Enabled = true;
        //    //Admin
        //    //This System
        //    foreach (UserPermission oUserPermission in _oUserPermissions)
        //    {
        //        if (oUserPermission.UserPermissions == "M37.1.1")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                thisSystemToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }

        //        }
        //        //Data Upload
        //        if (oUserPermission.UserPermissions == "M37.1.6")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                dataTransferToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }

        //        }
        //        //Basic Data
        //        //Current Employee
        //        if (oUserPermission.UserPermissions == "M38.1.1")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                currentEmployeeToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Current Employee
        //        if (oUserPermission.UserPermissions == "M38.1.2")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                productDetailsToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Running Consumer Promotion
        //        if (oUserPermission.UserPermissions == "M38.1.3")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                runningCPToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //CLP Registration
        //        //if (oUserPermission.UserPermissions == "M38.1.4")
        //        //{
        //        //    int nCount = 0;
        //        //    if (nCount == 0)
        //        //    {
        //        //        cLPCustomerRegistrationToolStripMenuItem.Enabled = true;
        //        //        nCount++;
        //        //    }
        //        //}
        //        //Existion Customer
        //        if (oUserPermission.UserPermissions == "M38.1.5")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                existingToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        //Activites
        //        //Goods Movement & Requisition
        //        //Requisition Creation
        //        if (oUserPermission.UserPermissions == "M39.1.1.1")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                requisitionCreationToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        //Return to HO
        //        if (oUserPermission.UserPermissions == "M39.1.1.2")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                iSGMToHOToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //ISGM to other outlet
        //        if (oUserPermission.UserPermissions == "M39.1.1.3")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                iSGMToToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Goods Receive Against Requisition
        //        if (oUserPermission.UserPermissions == "M39.1.1.4")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                goodsReceiveAgainstRequisitioToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Goods Receive from other outlet
        //        if (oUserPermission.UserPermissions == "M39.1.1.5")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                goodsReceiveFromOtherOutletToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Retail Invoice
        //        if (oUserPermission.UserPermissions == "M39.1.2.1")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                retailInvoiceToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Dealer Invoice
        //        if (oUserPermission.UserPermissions == "M39.1.2.2")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                dealerInvoiceToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Dealer Invoice(Editable Unit Price)
        //        //if (oUserPermission.UserPermissions == "M39.1.2.3")
        //        //{
        //        //    int nCount = 0;
        //        //    if (nCount == 0)
        //        //    {
        //        //        dealerInvoiceEditableUnitPriceToolStripMenuItem.Enabled = true;
        //        //        nCount++;
        //        //    }
        //        //}
        //        //Daler Invoice (Without IMEI)
        //        //if (oUserPermission.UserPermissions == "M39.1.2.4")
        //        //{
        //        //    int nCount = 0;
        //        //    if (nCount == 0)
        //        //    {
        //        //        dealerInvoiceWithoutIMEIToolStripMenuItem.Enabled = true;
        //        //        nCount++;
        //        //    }
        //        //}
        //        //Corporate Invoice
        //        if (oUserPermission.UserPermissions == "M39.1.2.5")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                corporateInvoiceB2CToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Modify Invoices
        //        if (oUserPermission.UserPermissions == "M39.1.2.6")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                modifyInvoicesToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //HPA
        //        if (oUserPermission.UserPermissions == "M39.1.2.7")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                retailInvoiceForHPAToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //B2B
        //        if (oUserPermission.UserPermissions == "M39.1.2.8")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                corporateInvoiceB2BToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Advance payment
        //        if (oUserPermission.UserPermissions == "M39.1.3.1")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                advancePaymentToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Daily Collection Statement (DCS)
        //        if (oUserPermission.UserPermissions == "M39.1.3.2")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                dailyCollectionStatementToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Payment Collection (Dealer)
        //        if (oUserPermission.UserPermissions == "M39.1.3.3")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                paymentReceiveDealerToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Stock Position
        //        if (oUserPermission.UserPermissions == "M40.1.1.1")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                stockPositionToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Stock Ledger
        //        if (oUserPermission.UserPermissions == "M40.1.1.2")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                stockLedgerToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Stock Movement
        //        if (oUserPermission.UserPermissions == "M40.1.1.3")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                stockMovementSummaryToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Product Serial
        //        if (oUserPermission.UserPermissions == "M40.1.1.4")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                serialToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Invoice Register
        //        if (oUserPermission.UserPermissions == "M40.1.2.1")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                invoiceRegisterToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        aSGWiseSaleForAppsToolStripMenuItem.Enabled = true;
        //        //Sales Statement
        //        if (oUserPermission.UserPermissions == "M40.1.2.2")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                salesStatementToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Sales Qty and Value
        //        if (oUserPermission.UserPermissions == "M40.1.2.3")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                salesQtyValueToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        //Emp TGT vs Ach
        //        if (oUserPermission.UserPermissions == "M40.1.2.4")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                tGTvsAchToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Customer TGT vs Ach
        //        if (oUserPermission.UserPermissions == "M40.1.2.5")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                customerTGTVsAchievementByMonthToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Sales Trand Report
        //        if (oUserPermission.UserPermissions == "M40.1.2.6")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                salesTrandReportToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        //VAT
        //        if (oUserPermission.UserPermissions == "M40.1.3.1")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                vAT11KaToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Customer Ledger
        //        if (oUserPermission.UserPermissions == "M40.1.3.2")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                customerLedgerToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Reprint
        //        if (oUserPermission.UserPermissions == "M40.1.4")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                reprintToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        //Office Item Requisition
        //        if (oUserPermission.UserPermissions == "M39.1.1.6")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                OfficeItemtoolStripMenuItem1.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Customer Credit Approval
        //        if (oUserPermission.UserPermissions == "M39.1.3.4")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                customerCreditApprovalToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Unsold Product Management
        //        if (oUserPermission.UserPermissions == "M39.1.4")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                unsoldToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Sales Lead
        //        if (oUserPermission.UserPermissions == "M39.1.5")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                salesLeadToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Potential Customer
        //        if (oUserPermission.UserPermissions == "M39.1.6")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                potentialCustomerToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Outlet Display Position 
        //        if (oUserPermission.UserPermissions == "M39.1.7")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                outletDisplayPositionToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        //B2B Customer Entry
        //        if (oUserPermission.UserPermissions == "M38.1.6")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                b2BCustomerEntryToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }
        //        //Reverse Application
        //        if (oUserPermission.UserPermissions == "M39.1.8")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                reverseAppalicationToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        if (oUserPermission.UserPermissions == "M39.1.9")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                dailyProjectionToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        if (oUserPermission.UserPermissions == "M39.1.10")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                deliveryShipmentToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        if (oUserPermission.UserPermissions == "M39.1.2.9")
        //        {
        //            int nCount = 0;
        //            if (nCount == 0)
        //            {
        //                EcommerceOrderToolStripMenuItem.Enabled = true;
        //                nCount++;
        //            }
        //        }

        //        //
        //    }
        //    oSystemInfo = new CJ.Class.POS.SystemInfo();
        //    DBController.Instance.OpenNewConnection();
        //    oSystemInfo.Refresh();
        //    DBController.Instance.CloseConnection();
        //    if (oSystemInfo.OperationDate != null)
        //    {
        //        dayStartToolStripMenuItem.Enabled = false;
        //        dayEndToolStripMenuItem.Enabled = true;
        //        label1.Text = "Log in User: " + "None";
        //        label2.Text = "System Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy");
        //    }
        //    else
        //    {
        //        dayStartToolStripMenuItem.Enabled = true;
        //        dayEndToolStripMenuItem.Enabled = false;

        //    }
        //}


        private void LeftImageMenu(bool _bFlag)
        {
            if (!_bFlag)
            {
                pbLogin.Visible = true;
                lblLogin.Text = "Login";

                pbHome.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;



                pbUpload.Visible = false;
                lblUpload.Visible = false;

                pbDownload.Visible = false;
                lblDownload.Visible = false;

                pbBackup.Visible = false;
                lblBackup.Visible = false;
                lblCBU.Visible = false;
                lblSKD.Visible = false;
                lblACIndoor.Visible = false;
                lblFG.Visible = false;
                lblRepair.Visible = false;
                lblProductionTarget.Visible = false;
                pbLogout.Visible = false;
                lblLogout.Visible = false;

                pbExit1.Visible = true;
                lblExit1.Visible = true;

            }
            else
            {
                pbLogin.Visible = false;
                pbHome.Visible = true;
                lblLogin.Text = "Home";
                pbUpload.Visible = true;
                lblUpload.Visible = true;
                pbDownload.Visible = true;
                lblDownload.Visible = true;
                pbBackup.Visible = true;
                lblBackup.Visible = true;
                pbLogout.Visible = true;
                lblLogout.Visible = true;
                pbExit1.Visible = true;
                lblExit1.Visible = true;
                pictureBox2.Visible = true;
                lblCBU.Visible = true;
                pictureBox3.Visible = true;
                lblSKD.Visible = true;
                pictureBox4.Visible = true;
                lblACIndoor.Visible = true;
                pictureBox5.Visible = true;
                lblFG.Visible = true;
                pictureBox6.Visible = true;
                lblRepair.Visible = true;
                pictureBox7.Visible = true;
                lblProductionTarget.Visible = true;


                //pictureBox3.Enabled = false;
                //lblSKD.Enabled = false;
                //pictureBox4.Enabled = false;
                //lblACIndoor.Enabled = false;
                //pictureBox5.Enabled = false;
                //lblFG.Enabled = false;
                //pictureBox6.Enabled = false;
                //lblRepair.Enabled = false;
                //pictureBox7.Enabled = false;
                //lblProductionTarget.Enabled = false;
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            oSystemInfo = new SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.RefreshForFactory();
            DBController.Instance.CloseConnection();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            lblPOSVersion.Text = "CJ.Manufacturing [" + version + "]";
            lblPOSVersion.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ED1B24");
            lblOutletName.Text = oSystemInfo.WarehouseAddress;
            lblOutletName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ED1B24");
            this.Text = oSystemInfo.Shortcode + " - " + oSystemInfo.WarehouseAddress + " [CJ.Factory | Version: " + version + "]";
            label1.Text = "Logged in User: " + "None";
            label2.Text = "System Date: " + DateTime.Now.Date.ToString("dd-MMM-yyyy") + "";
            nLocationID = oSystemInfo.LocationID;
        }
        private void CloseAllWindow()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void pbUpload_Click_1(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmDataSend o = new frmDataSend();
            o.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void pbDownload_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmDataDownload o = new frmDataDownload();
            o.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }


        private void pbBackup_Click(object sender, EventArgs e)
        {


            CloseAllWindow();

            this.Cursor = Cursors.WaitCursor;
            frmDatabaseBackup o = new frmDatabaseBackup();
            o.ShowDialog();
            this.Cursor = Cursors.Default;


            ////EncryptDecryptOperation  



            //    //string convert = "This is the string to be converted";

            //    //// From string to byte array
            //    //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(convert);

            //    //// From byte array to string
            //    //string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);


            //    string original = "Here is some data to encrypt!";

            //// Create a new instance of the Rijndael
            //// class.  This generates a new key and initialization
            //// vector (IV).
            //using (Rijndael myRijndael = Rijndael.Create())
            //{
            //    // Encrypt the string to an array of bytes.
            //    byte[] encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);


            //    string s = System.Text.Encoding.UTF8.GetString(encrypted, 0, encrypted.Length);


            //    //// Decrypt the bytes to a string.
            //    string roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

            //    ////Display the original data and the decrypted data.
            //    //Console.WriteLine("Original:   {0}", original);
            //    //Console.WriteLine("Round Trip: {0}", roundtrip);
            //}


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
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductComponentUniversals o = new frmProductComponentUniversals((int)Dictionary.ProductionType.CBU, (int)Dictionary.IsIndoorItem.No);
            // o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {


            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductComponentUniversals o = new frmProductComponentUniversals((int)Dictionary.ProductionType.SKD, (int)Dictionary.IsIndoorItem.No);
            // o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductComponentUniversals o = new frmProductComponentUniversals((int)Dictionary.ProductionType.SKD, (int)Dictionary.IsIndoorItem.Yes);
            //o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pbExit1_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to Exit ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            gbVersion.BringToFront();
        }

        private void pbLogin_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin(nLocationID);
            DialogResult oResult = frmLogin.ShowDialog();
            if (oResult == DialogResult.OK)
            {
                //MenuEnable();
                LeftImageMenu(true);
                label1.Text = "Logged in User: " + Utility.Username;
            }
            else
            {
                return;
            }
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to log out ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                //MenuDisable();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductComponentUniversals o = new frmProductComponentUniversals((int)Dictionary.ProductionType.FG, -1);
            // o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmProductComponentUniversals o = new frmProductComponentUniversals((int)Dictionary.ProductionType.Repair, -1);
            // o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;

            //CloseAllWindow();
            //this.Cursor = Cursors.WaitCursor;
            //frmSKDDefective o = new frmSKDDefective((int)Dictionary.LCMStatus.Stage_4);
            //// o.MdiParent = this;
            //o.MaximizeBox = true;
            //o.StartPosition = FormStartPosition.CenterScreen;
            //o.FormBorderStyle = FormBorderStyle.FixedDialog;
            //o.WindowState = FormWindowState.Maximized;
            //o.Show();
            //home(false);
            //this.Cursor = Cursors.Default;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
            this.Cursor = Cursors.WaitCursor;
            frmSKDTargets o = new frmSKDTargets();
            // o.MdiParent = this;
            o.MaximizeBox = true;
            o.StartPosition = FormStartPosition.CenterScreen;
            o.FormBorderStyle = FormBorderStyle.FixedDialog;
            o.WindowState = FormWindowState.Maximized;
            o.Show();
            home(false);
            this.Cursor = Cursors.Default;
        }
    }
}
