/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: Oct 11, 2011
/// Time : 05:00 PM
/// Description: Main form.
/// Modify Person And Date: 
/// </summary>

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using CJ.POS.RT.Security;
using CJ.Class;
using CJ.POS.RT.Invoice;
using System.Runtime.InteropServices;




namespace CJ.POS.RT
{
    public partial class frmMain : Form
    {
        

        

        UserPermissions _oUserPermissions;
        public UserPermissions oUserPermissions;
        int nWHID = 0;
        int nCustomerID = 0;
        int nChannelID = 0;
        System.Timers.Timer timer = new System.Timers.Timer();
        public frmMain()
        {
            InitializeComponent();
            MenuEnable();
            LeftImageMenu(true);
            label1.Text = "Logged in User: " + Utility.Username;
            label1.Refresh();
            Trimer();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            lblPOSVersion.Text = "CJ.POS Edge [" + version + "]";
            lblPOSVersion.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ED1B24");
            lblOutletName.Text = Utility.ShowroomCode + " - " + Utility.WarehouseName;
            lblOutletName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ED1B24");
            this.Text = Utility.WarehouseName + "-" + Utility.ShowroomCode + " [" + Utility.CompanyInfo + " POS Edge | Version: " + version + "]";
            //label1.Text = "Logged in User: " + "None";
            //label2.Text = "System Date: " + "None";


            //picNetworkSignal.Image = Image.FromFile("net2.jpg");
            nWHID = Utility.WarehouseID;
            nCustomerID = Utility.CustomerID;
            nChannelID = Utility.ChannelID;
        }    
        public void MenuDisable()
        {
            extendedWarrantyToolStripMenuItem.Enabled = false;
            mnuLogOut.Enabled = false;
            mnuChangePassword.Enabled = false;
            mmuexit.Enabled = true;
            thisSystemToolStripMenuItem.Enabled = false;
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
            modifyInvoicesToolStripMenuItem.Enabled = false;
            advancePaymentToolStripMenuItem.Enabled = false;
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
            //importXMLToolStripMenuItem.Enabled = false;
            dMSOrderToolStripMenuItem.Enabled = false;
        }
        public void MenuEnable()
        {
            mnuLogOut.Enabled = true;
            dMSOrderToolStripMenuItem.Enabled = true;
            extendedWarrantyToolStripMenuItem.Enabled = true;
            goodsRequisitionMovementToolStripMenuItem.Enabled = true;
            invoiceToolStripMenuItem.Enabled = true;
            executiveWiseLeadTargetVsActualToolStripMenuItem.Enabled = true;
            channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem.Enabled = true;
            executiveWiseWeeklyReportQtyValueToolStripMenuItem.Enabled = true;
            executiveWiseWeeklyLeadReportQtyValueToolStripMenuItem.Enabled = true;
            attendanceToolStripMenuItem.Enabled = true;
            dashboardToolStripMenuItem1.Enabled = true;
            salesInvoiceToolStripMenuItem.Enabled = true;
            paymentToolStripMenuItem.Enabled = true;
            spacialDiscountApplicationToolStripMenuItem.Enabled = true;
            stockReportsToolStripMenuItem.Enabled = true;
            salesReportsToolStripMenuItem.Enabled = true;
            accountsReportToolStripMenuItem.Enabled = true;

            _oUserPermissions = new UserPermissions();
            _oUserPermissions = _oUserPermissions.Refresh(_oUserPermissions, Utility.UserId);
            oUserPermissions = _oUserPermissions;
            //importXMLToolStripMenuItem.Enabled = true;
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
                        //retailInvoiceToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //Dealer Invoice
                if (oUserPermission.UserPermissions == "M39.1.2.2")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                        //dealerInvoiceToolStripMenuItem.Enabled = true;
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
                        //corporateInvoiceB2CToolStripMenuItem.Enabled = true;
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
                     // retailInvoiceForHPAToolStripMenuItem.Enabled = true;
                        nCount++;
                    }
                }
                //B2B
                if (oUserPermission.UserPermissions == "M39.1.2.8")
                {
                    int nCount = 0;
                    if (nCount == 0)
                    {
                       // corporateInvoiceB2BToolStripMenuItem.Enabled = true;
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
                aSGWiseSaleForAppsToolStripMenuItem.Enabled = true;
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
            //oSystemInfo = new CJ.Class.POS.SystemInfo();
            //DBController.Instance.OpenNewConnection();
            //oSystemInfo.RefreshPOSRT();
            //DBController.Instance.CloseConnection();
            //if (oSystemInfo.OperationDate != null)
            //{
            //    dayStartToolStripMenuItem.Enabled = false;
            //    dayEndToolStripMenuItem.Enabled = true;
            //    label1.Text = "Log in User: " + "None";
            //    label2.Text = "System Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy");
            //}
            //else
            //{
            //    dayStartToolStripMenuItem.Enabled = true;
            //    dayEndToolStripMenuItem.Enabled =false;
              
            //}
        }
        public void logOut(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to log out ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                //MenuDisable();
                //LeftImageMenu(false);
                //foreach (Form childForm in MdiChildren)
                //{
                //    childForm.Close();
                //}
                //label1.Text = "Logged in User: " + "None";
                //label2.Text = "System Date: " + "None";
                this.Dispose();
                frmLogin ofrom = new frmLogin();
                ofrom.ShowDialog();
            }
        }
        public void logIn(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            DialogResult oResult = frmLogin.ShowDialog();
            if (oResult == DialogResult.OK)
            {
                MenuEnable();
                LeftImageMenu(true);
                label1.Text = "Logged in User: " + Utility.Username;
            }
            else
            {
                return;
            }
         
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
            frmEmpTGTvsAchSearch oFrom = new frmEmpTGTvsAchSearch(1);
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
            frmEmpTGTvsAchSearch oFrom = new frmEmpTGTvsAchSearch(2);
            oFrom.ShowDialog();
        }

        private void channelMAGBrandWiseWeekTGTVsActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual(1);
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
            frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual((int)Dictionary.PlanVersionType.ExecutiveLeadTarget);
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
            //frmInvoice o = new frmInvoice(1, "");
            //o.MdiParent = this;
            //o.MaximizeBox = false;
            //o.StartPosition = FormStartPosition.CenterScreen;
            //o.FormBorderStyle = FormBorderStyle.FixedDialog;
            //o.WindowState = FormWindowState.Maximized;
            //o.Icon = o.MdiParent.Icon;
            //o.Show();
            //ofrm.ShowDialog();
            frmLogin oform = new frmLogin();
            oform.ShowDialog();
            if (oform._bflag)
            {
                MenuEnable();
                LeftImageMenu(true);
            }
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
            //pbDashboard_Click(null, null);
            Exit();
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



        private void goodsRequisitionMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goodsRequisitionMovementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void pettyCashExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}