using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.POS.TELWEBSERVER;
using CJ.Class;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;


namespace CJ.POS
{
    public partial class frmDataDownload : Form
    {
        DSBasicData oDSNewVatActivation;
        Service oSerivce;
        DSProduct oDSProduct;
        DSProduct oDSProductFeatureType;
        DSFinishedGoodsPrice oDSFinishedGoodsPrice;
        DSEmployee oDSEmployee;
        DSWarehouse oDSFromWarehouse;
        DSWarehouse oDSWarehouse;
        DSPromotion oDSPromotion;
        DSBarcode oDSBarcode;
        DSWarranty oDSWarranty;
        DSRetailConsumer oDSRetailConsumer;
        DSProductGroups oDSProductGroups;
        DSBrand oDSBrand;
        DSCLP oDSCLP;
        DSProductTransactionType oDSProductTransactionType;
        DSProductTransaction oDSProductTransaction;
        DSStock oDSStock;
        DSUser oDSUser;
        DSSBU oDSSBU;
        DSChannel oDSChannel;
        DSCustomerType oDSCustomerType;
        DSMarketGroup oDSMarketGroup;
        DSGeoLocation oDSGeoLocation;
        DSCustomer oDSCustomer;
        DSBasicData oDSBasicData;
        DSCustomerTransaction oDSCustomerTransaction;
        DSRequisition oDSRequisition;
        DSBank oDSBank;
        DSPaymentMode oDSPaymentMode;
        DSReceivableData oDSReceivableData;
        DSDiscountReason oDSDiscountReason;
        DSShowroom oDSShowroom;
        DSThisSystem oDSThisSystem;
        DSSalesPromotionType oDSSalesPromotionType;
        DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct;
        DSOfficeItemTran oDSOfficeItemTran;
        DSOfficeItem oDSOfficeItem;
        DSCustmerCreditApprval oDSCustmerCreditApprval;
        DSCalendarWeek oDSCalendarWeek;
        DSPlanCustomerTarget oDSPlanCustomerTarget;
        DSPlanExecutiveWeekTarget oDSPlanExecutiveWeekTarget;
        DSPlanMAGWeekTargetQty oDSPlanMAGWeekTargetQty;
        DSOutletDisplayPosition oDSOutletDisplayPosition;
        DSOutletDisplayPosition oDSOutletDisplayPositionRack;
        DSTPVatProduct oDSTPVatProduct;
        DSCustomerTemp oDSCustomerTemp;
        DSInvoiceReverse oDSInvoiceReverse;
        DSExchangeOfferVender oDSExchangeOfferVender;
        DSExchangeOfferVenderTran oDSExchangeOfferVenderTran;
        DSExchangeOfferJob oDSExchangeOfferJob;
        DSExchangeOfferMR oDSExchangeOfferMR;
        DSSalesInvoiceEcommerce oDSSalesInvoiceEcommerce;
        DSPlanExecutiveWeekTarget oDSPlanExecutiveLeadTarget;
        DSSalesLead oDSSalesLead;
        DSBasicData oDSTDActivation;
        DSBasicData oDSTDDeliveryShipment;
        DSPromotion oDSPromoDiscount;
        DSBasicData oDSPromoDiscountSpecialAuthority;
        DSBasicData oDSPettyCashExpenseHead;
        //DSWarehouse oDSWarehouse;
        DSPettyCash oDSPettyCashExpense;
        DSCustomer oDSCustomerCreditLimit;
        DSSalesOrder oDSSalesOrder;
        DSExtendedWarranty oDSExtendedWarranty;
        DSFinishedGoodsPrice oDSExtendedWarratyItem;
        DSDayPlan oDSDayPlan;
        DSPromoExchgangeOffer oDSPromoExchgangeOffer;
        DSPromoWarranty oDSPromoWarranty;

        CJ.Class.DataTransfer.DataTransfer oDataTransfer;
        CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.POS.DSProduct _oDSProduct;
        CJ.Class.POS.DSFinishedGoodsPrice _oDSFinishedGoodsPrice;     
        CJ.Class.POS.DSEmployee _oDSEmployee;
        CJ.Class.POS.DSWarehouse _oDSWarehouse;
        CJ.Class.POS.DSPromotion _oDSPromotion;
        CJ.Class.POS.DSBarcode _oDSBarcode;
        CJ.Class.POS.DSWarranty _oDSWarranty;
        CJ.Class.POS.DSRetailConsumer _oDSRetailConsumer;
        CJ.Class.POS.DSProductGroups _oDSProductGroups;
        CJ.Class.POS.DSBrand _oDSBrand;
        CJ.Class.POS.DSCLP _oDSCLP;
        CJ.Class.POS.DSProductTransactionType _oDSProductTransactionType;
        CJ.Class.POS.DSProductTransaction _oDSProductTransaction;
        CJ.Class.POS.DSStock _oDSStock;
        CJ.Class.POS.DSUser _oDSUser;
        CJ.Class.POS.DSSBU _oDSSBU;
        CJ.Class.POS.DSChannel _oDSChannel;
        CJ.Class.POS.DSCustomerType _oDSCustomerType;
        CJ.Class.POS.DSMarketGroup _oDSMarketGroup;
        CJ.Class.POS.DSGeoLocation _oDSGeoLocation;
        CJ.Class.POS.DSCustomer _oDSCustomer;

        CJ.Class.POS.DSBasicData _oDSBasicData;
        CJ.Class.POS.DSCustomerTransaction _oDSCustomerTransaction;

        CJ.Class.POS.DSRequisition _oDSRequisition;
        CJ.Class.POS.DSBank _oDSBank;
        CJ.Class.POS.DSPaymentMode _oDSPaymentMode;
        CJ.Class.POS.DSReceivableData _oDSReceivableData;
        CJ.Class.POS.DSDiscountReason _oDSDiscountReason;
        CJ.Class.POS.DSShowroom _oDSShowroom;

        CJ.Class.POS.DataTrans _oDataTrans;
        CJ.Class.POS.DSThisSystem _oDSThisSystem;
        CJ.Class.POS.DSSalesPromotionType _oDSSalesPromotionType;
        CJ.Class.POS.DSOfficeItem _oDSOfficeItem;
        CJ.Class.POS.DSOfficeItemTran _oDSOfficeItemTran;
        CJ.Class.POS.DSUnsoldDefectiveProduct _oDSUnsoldDefectiveProduct;
        CJ.Class.POS.DSCustmerCreditApprval _oDSCustmerCreditApprval;

        CJ.Class.POS.DSCalendarWeek _oDSCalendarWeek;
        CJ.Class.POS.DSPlanCustomerTarget _oDSPlanCustomerTarget;
        CJ.Class.POS.DSPlanExecutiveWeekTarget _oDSPlanExecutiveWeekTarget;
        CJ.Class.POS.DSPlanMAGWeekTargetQty _oDSPlanMAGWeekTargetQty;
        CJ.Class.POS.DSOutletDisplayPosition _oDSOutletDisplayPosition;
        CJ.Class.POS.DSOutletDisplayPosition _oDSOutletDisplayPositionRack;
        CJ.Class.POS.DSTPVatProduct _oDSTPVatProduct;
        CJ.Class.POS.DSCustomerTemp _oDSCustomerTemp;
        CJ.Class.POS.DSInvoiceReverse _oDSInvoiceReverse;
        CJ.Class.POS.DSExchangeOfferVender _oDSExchangeOfferVender;
        CJ.Class.POS.DSExchangeOfferVenderTran _oDSExchangeOfferVenderTran;
        CJ.Class.POS.DSExchangeOfferJob _oDSExchangeOfferJob;
        CJ.Class.POS.DSExchangeOfferMR _oDSExchangeOfferMR;
        CJ.Class.POS.DSSalesInvoiceEcommerce _oDSSalesInvoiceEcommerce;
        CJ.Class.POS.DSPlanExecutiveWeekTarget _oDSPlanExecutiveLeadTarget;
        CJ.Class.POS.DSSalesLead _oDSSalesLead;
        CJ.Class.POS.DSProduct _oDSProductFeatureType;
        CJ.Class.POS.DSBasicData _oDSNewVatActivation;
        CJ.Class.POS.DSBasicData _oDSTDActivation;
        CJ.Class.POS.DSBasicData _oDSTDDeliveryShipment;
        CJ.Class.POS.DSPromotion _oDSPromoDiscount;
        CJ.Class.POS.DSBasicData _oDSPromoDiscountSpecialAuthority;

        CJ.Class.POS.DSBasicData _oDSPettyCashExpenseHead;
        CJ.Class.POS.DSPettyCash _oDSPettyCashExpense;
        CJ.Class.POS.DSSalesOrder _oDSSalesOrder;
        CJ.Class.POS.DSCustomer _oDSCustomerCreditLimit;
        CJ.Class.POS.DSExtendedWarranty _oDSExtendedWarranty;
        CJ.Class.POS.DSFinishedGoodsPrice _oDSExtendedWarratyItem;
        CJ.Class.POS.DSDayPlan _oDSDayPlan;

        CJ.Class.Promotion.DSPromoExchangeOffer _oDSPromoExchgangeOffer;
        Class.Promotion.DSPromoWarranty _oDSPromoWarranty;

        //CJ.Class.POS.DSWarehouse _oDSWarehouse;DSExchangeOfferVender oDSExchangeOfferVender;

        //int nWHID = 0;
        //int nCustomerID = 0;
        int nCount = 0;
        public frmDataDownload()
        {
            InitializeComponent();
        }
        private void frmDataDownload_Load(object sender, EventArgs e)
        {
            ////Loadcmb();


            ////System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

            ////config.AppSettings.Settings["CJ_POS_TELWEBSERVER_Service"].Value = "http://202.53.171.126/cj.ws.tml.r/service.asmx";
            ////config.Save(System.Configuration.ConfigurationSaveMode.Modified);

            //System.Configuration.Configuration configFile = System.Configuration.ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            //configFile.AppSettings.Settings["TELWEBServer"].Value = "http://202.53.171.126/cj.ws.tel.n/service.asmx";
            //configFile.Save();



            //oSystemInfo = new CJ.Class.POS.SystemInfo();
            //DBController.Instance.OpenNewConnection();
            //oSystemInfo.Refresh();
            //DBController.Instance.CloseConnection();
            ////nWHID = oSystemInfo.WarehouseID;
            ////nCustomerID = oSystemInfo.CustomerID;
            //lblBranchName.Text = oSystemInfo.WarehouseName;
            //nCount = 0;

            //if (Utility.CheckInternetConnection())
            //{
            //    if (Utility.CheckTELWEBServer())
            //    {
            //        nCount = LoadReceivableData(oSystemInfo.WarehouseID);

            //        if (nCount == 0)
            //        {
            //            btDownload.Enabled = false;
            //            lblMsg.Visible = true;
            //            lblMsg.Text = "There is no Downloadable data";
            //            lblMsg.ForeColor = Color.Red;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Server Or Network connectivity not available at this moment!!! \n\nPlease try again later or contact concern person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.Close();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please Check Internet Connection\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}

            oSystemInfo = new CJ.Class.POS.SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            DBController.Instance.CloseConnection();
            lblBranchName.Text = oSystemInfo.WarehouseName;
            nCount = 0;

            //if (Utility.CheckInternetConnection())
            //{
            //    if (Utility.CheckTELWEBServer())
            try
            {
                int Desc;
                if (Utility.InternetGetConnectedState(out Desc, 0))
                {
                    //if (Utility.PingHost("202.53.171.126"))
                    if (CheckRemoteServer())
                    {
                        nCount = LoadReceivableData(oSystemInfo.WarehouseID);

                        if (nCount == 0)
                        {
                            btDownload.Enabled = false;
                            lblMsg.Visible = true;
                            lblMsg.Text = "There is no Downloadable data";
                            lblMsg.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Server Or Network connectivity not available at this moment!!! \n\nPlease try again later or contact concern person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Internet Connection\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!!\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "\nError Detail:"+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public bool CheckRemoteServer()
        {
            bool connectionExists = false;
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send("202.53.171.126");

                if (reply.Status == IPStatus.Success)
                {
                    connectionExists = true;
                }

            }
            catch (PingException ex)
            {
                connectionExists = false;
            }
            return connectionExists;
        }
        private int LoadReceivableData(int nWHID)
        {
            _oDSReceivableData = new CJ.Class.POS.DSReceivableData();
            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

            oSerivce = new Service();
            oDSReceivableData = new DSReceivableData();

            _oDataTrans = new CJ.Class.POS.DataTrans();
            oDSReceivableData = oSerivce.DownloadReceivableData(oDSReceivableData, nWHID);

            _oDSReceivableData.Merge(oDSReceivableData);
            _oDSReceivableData.AcceptChanges();

            _oDataTrans = _oDataTrans.GetDataTrans(_oDataTrans, _oDSReceivableData, true);
            nCount = 0;
            if (_oDSReceivableData.ReceivableData.Count > 0)
            {

                lvwItemList.Items.Clear();
                this.Text = "Total  " + "[" + _oDSReceivableData.ReceivableData.Count + "]";
                foreach (CJ.Class.POS.DataTran oDataTran in _oDataTrans)
                {

                    ListViewItem oItem = lvwItemList.Items.Add(oDataTran.ID.ToString());
                    oItem.SubItems.Add(oDataTran.DataID.ToString());
                    oItem.SubItems.Add(oDataTran.TableName);
                    nCount++;
                }

            }
            return nCount;
        }
        
        private int LoadReceivableDataGroupBy(int nWHID)
        {
            _oDSReceivableData = new CJ.Class.POS.DSReceivableData();
            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

            oSerivce = new Service();
            oDSReceivableData = new DSReceivableData();

            _oDataTrans = new CJ.Class.POS.DataTrans();
            oDSReceivableData = oSerivce.DownloadReceivableDataGroupBy(oDSReceivableData, nWHID);

            _oDSReceivableData.Merge(oDSReceivableData);
            _oDSReceivableData.AcceptChanges();

            _oDataTrans = _oDataTrans.GetDataTrans(_oDataTrans, _oDSReceivableData, false);
            nCount = 0;
            if (_oDSReceivableData.ReceivableData.Count > 0)
            {
                foreach (CJ.Class.POS.DataTran oDataTran in _oDataTrans)
                {
                    nCount++;
                }
            }
            return nCount;
        }
        public void Loadcmb()
        {
            //cmbFromWarehouse.Items.Clear();
            //oDSFromWarehouse = new DSWarehouse();
            //oSerivce = new Service();
            //DSWarehouse.WarehouseRow oWarehouseRow = oDSFromWarehouse.Warehouse.NewWarehouseRow();
            //oWarehouseRow.UserID = CJ.Class.Utility.UserId.ToString();
            //oDSFromWarehouse.Warehouse.AddWarehouseRow(oWarehouseRow);
            //oDSFromWarehouse.AcceptChanges();

            //try
            //{
            //    oDSFromWarehouse = oSerivce.FromWarehouse(oDSFromWarehouse);
            //}
            //catch
            //{
            //    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (oDSFromWarehouse != null)
            //{
            //    cmbFromWarehouse.ValueMember = "WarehouseID";
            //    cmbFromWarehouse.DisplayMember = "WarehouseName";
            //    cmbFromWarehouse.DataSource = oDSFromWarehouse.Warehouse;

            //}
        }
        //private Uri GetAbsoluteUri(string redirectUrl)
        //{
        //    var redirectUri = new Uri(redirectUrl, UriKind.RelativeOrAbsolute);

        //    if (!redirectUri.IsAbsoluteUri)
        //    {
        //        redirectUri = new Uri(new Uri(Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath), redirectUri);
        //    }

        //    return redirectUri;
        //}
        private void btDownload_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //if (Utility.CheckInternetConnection())
            int Desc;
            if (Utility.InternetGetConnectedState(out Desc, 0))
            {
                //if (Utility.PingHost("http://tel.telmisdev.com"))
                {

                   
                    bool Istrue = DataDownloadTD(oSystemInfo.WarehouseID, oSystemInfo.CustomerID);
                    if (Istrue)
                    {
                        MessageBox.Show("Data Downloaded Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        pbDownload.Visible = false;
                    }
                }
                //else
                {
                    //MessageBox.Show("HO Server down!!! \n\nPlease try again later or contact concern person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Check Internet Connection\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            this.Cursor = Cursors.Default;
        }
        
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool DataDownloadTD(int nWHID, int nCustomerID)
        {
            nCount = 0;
            nCount = LoadReceivableDataGroupBy(nWHID);
            if (nCount > 0)
            {
                pbDownload.Visible = true;
                pbDownload.Maximum = _oDataTrans.Count;
                pbDownload.Value = 0;
                int i = 0;

                foreach (CJ.Class.POS.DataTran oDataTran in _oDataTrans)
                {

                    lblTableName.Visible = true;
                    string txt = "Download Data from: ";
                    lblTableName.Text = txt;
                    lblTableName.Refresh();

                    #region Bank
                    if (oDataTran.TableName == "t_Bank")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_Bank";
                            lblTableName.Refresh();

                            _oDSBank = new CJ.Class.POS.DSBank();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSBank = oSerivce.DownloadBank(oDSBank, nWHID);

                            _oDSBank.Merge(oDSBank);
                            _oDSBank.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSBank.Bank.Count > 0)
                                oDataTransfer.InsertBank(_oDSBank);

                            //pbtDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSBank.Bank.Count > 0)
                                oSerivce.UpdateBankTransferInfo(oDSBank, nWHID);
                            //pbtDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSBank.Bank.Count;
                            if (oDSBank.Bank.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Bank");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Bank /" + ex.Message);
                            MessageBox.Show("Please Cheak Bank segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #endregion

                    #region Bank Account
                    /*
                    if (oDataTran.TableName == "t_BankAccount")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_BankAccount";
                            lblTableName.Refresh();

                            //pbtDownload.Visible = true;
                            //pbtDownload.Minimum = 0;
                            //pbtDownload.Maximum = 3;
                            //pbtDownload.Step = 1;
                            //pbtDownload.Value = 0;

                            _oDSBank = new CJ.Class.POS.DSBank();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSBank = oSerivce.DownloadBank(oDSBank, nWHID);
                            //pbtDownload.PerformStep();

                            _oDSBank.Merge(oDSBank);
                            _oDSBank.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSBank.Bank.Count > 0)
                                oDataTransfer.InsertBank(_oDSBank);

                            //pbtDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSBank.Bank.Count > 0)
                                oSerivce.UpdateBankTransferInfo(oDSBank, nWHID);
                            //pbtDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSBank.Bank.Count;
                            if (oDSBank.Bank.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Bank Account");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Bank Account/" + ex.Message);
                            MessageBox.Show("Please Cheak Bank Account segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    */
                    #endregion

                    #region Showroom
                    else if (oDataTran.TableName == "t_Showroom")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_Showroom";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSShowroom = new CJ.Class.POS.DSShowroom();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSShowroom = oSerivce.DownloadShowroom(oDSShowroom, nWHID);
                            //pbDownload.PerformStep();

                            _oDSShowroom.Merge(oDSShowroom);
                            _oDSShowroom.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSShowroom.Showroom.Count > 0)
                                oDataTransfer.InsertShowroom(_oDSShowroom);

                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSShowroom.Showroom.Count > 0)
                                oSerivce.UpdateShowroomTransferInfo(oDSShowroom, nWHID);
                            pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSShowroom.Showroom.Count;
                            if (oDSShowroom.Showroom.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Showroom");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Showroom /" + ex.Message);
                            MessageBox.Show("Please Cheak Showroom segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #endregion

                    #region Discount Reason
                    else if (oDataTran.TableName == "t_DiscountReason")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_DiscountReaosn";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSDiscountReason = new CJ.Class.POS.DSDiscountReason();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSDiscountReason = oSerivce.DownloadDiscountReason(oDSDiscountReason, nWHID);
                            //pbDownload.PerformStep();

                            _oDSDiscountReason.Merge(oDSDiscountReason);
                            _oDSDiscountReason.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSDiscountReason.DiscountReason.Count > 0)
                                oDataTransfer.InsertDiscountReason(_oDSDiscountReason);

                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSDiscountReason.DiscountReason.Count > 0)
                                oSerivce.UpdateDiscountReasonTransferInfo(oDSDiscountReason, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSDiscountReason.DiscountReason.Count;
                            if (oDSDiscountReason.DiscountReason.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Discount Reason");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Discount Reason /" + ex.Message);
                            MessageBox.Show("Please Cheak Discount Reason segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Payment Mode
                    else if (oDataTran.TableName == "t_PaymentMode")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PaymentMode";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSPaymentMode = new CJ.Class.POS.DSPaymentMode();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSPaymentMode = oSerivce.DownloadPaymentMode(oDSPaymentMode, nWHID);
                            //pbDownload.PerformStep();

                            _oDSPaymentMode.Merge(oDSPaymentMode);
                            _oDSPaymentMode.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSPaymentMode.PaymentMode.Count > 0)
                                oDataTransfer.InsertPaymentMode(_oDSPaymentMode);

                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSPaymentMode.PaymentMode.Count > 0)
                                oSerivce.UpdatePaymentModeTransferInfo(oDSPaymentMode, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSPaymentMode.PaymentMode.Count;
                            if (oDSPaymentMode.PaymentMode.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded PaymentMode");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading PaymentMode /" + ex.Message);
                            MessageBox.Show("Please Cheak PaymentMode segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Customer Type
                    else if (oDataTran.TableName == "t_CustomerType")
                    {
                        try
                        {

                            lblTableName.Text = txt + "t_CustomerType";
                            lblTableName.Refresh();

                            pbDownload.Visible = true;
                            pbDownload.Minimum = 0;
                            pbDownload.Maximum = 2;
                            pbDownload.Step = 1;
                            pbDownload.Value = 0;

                            _oDSCustomerType = new CJ.Class.POS.DSCustomerType();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSCustomerType = oSerivce.DownloadCustomerType(oDSCustomerType, nWHID);
                            pbDownload.PerformStep();

                            _oDSCustomerType.Merge(oDSCustomerType);
                            _oDSCustomerType.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataTransfer.InsertCustomerType(_oDSCustomerType);


                            oSerivce = new Service();
                            if (oDSCustomerType.CustomerType.Count > 0)
                                oSerivce.UpdateCustomerTypeInfo(oDSCustomerType, nWHID);

                            pbDownload.PerformStep();
                            CJ.Class.DBController.Instance.CommitTransaction();

                            //pgbInsert.PerformStep();
                            AppLogger.LogInfo("Successfully Inserted Customer Type");

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Customer Type /" + ex.Message);
                            MessageBox.Show("Please Cheak Customer Type Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region TD Customer
                    else if (oDataTran.TableName == "t_Customer")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_Customer";
                            lblTableName.Refresh();


                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 2;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSCustomer = new CJ.Class.POS.DSCustomer();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSCustomer = oSerivce.DownloadCustomer(oDSCustomer, nWHID);
                            //pbDownload.PerformStep();

                            _oDSCustomer.Merge(oDSCustomer);
                            _oDSCustomer.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSCustomer.Customer.Count > 0)
                                oDataTransfer.InsertCustomer(_oDSCustomer);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSCustomer.Customer.Count > 0)
                                oSerivce.UpdateCustomerTransferInfo(oDSCustomer, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();

                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSCustomer.Customer.Count;
                            if (oDSCustomer.Customer.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Customer");
                            }
                            i = i + 1;
                            pbDownload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Customer /" + ex.Message);
                            MessageBox.Show("Please Cheak Customer segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    //========
                    #region Basic Data
                    /*
            try
            {
                #region lebel
                lblTableName.Text = txt + "t_Bank";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_BankBranch";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_company";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_CustomerCreditLimit";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_InvoiceType";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_customerTranType";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_CustomerTypeWisePriceSetting";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_CustomerAccount";
                lblTableName.Refresh();

                #endregion

                pbtDownload.Visible = true;
                pbtDownload.Minimum = 0;
                pbtDownload.Maximum = 2;
                pbtDownload.Step = 1;
                pbtDownload.Value = 0;

                _oDSBasicData = new CJ.Class.POS.DSBasicData();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                CJ.Class.DBController.Instance.OpenNewConnection();
                oSystemInfo = new CJ.Class.POS.SystemInfo();
                oSystemInfo.Refresh();
                CJ.Class.DBController.Instance.CloseConnection();
                oDSBasicData = oSerivce.DownloadBasicData(oDSBasicData, nCustomerID);
                pbtDownload.PerformStep();

                _oDSBasicData.Merge(oDSBasicData);
                _oDSBasicData.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oDataTransfer.InsertBasicData(_oDSBasicData);
                pbtDownload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();

                pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Basic Data");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Basic Data /" + ex.Message);
                MessageBox.Show("Please Cheak Basic Data Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
                    #endregion
                    //============


                    #region Product Group
                    else if (oDataTran.TableName == "t_ProductGroup")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_ProductGroup";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSProductGroups = new CJ.Class.POS.DSProductGroups();
                            _oDSBrand = new CJ.Class.POS.DSBrand();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSProductGroups = oSerivce.DownloadProductGroup(oDSProductGroups, nWHID);
                            //pbDownload.PerformStep();

                            _oDSProductGroups.Merge(oDSProductGroups);
                            _oDSProductGroups.AcceptChanges();


                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSProductGroups.ProductGroup.Count > 0)
                                oDataTransfer.InsertProductGroup(_oDSProductGroups);

                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSProductGroups.ProductGroup.Count > 0)
                                oSerivce.UpdateProductGroupTransferInfo(oDSProductGroups, nWHID);

                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSProductGroups.ProductGroup.Count;
                            if (oDSProductGroups.ProductGroup.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Download Product Group");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Product Group /" + ex.Message);
                            MessageBox.Show("Please Cheak Product Group segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Brand
                    else if (oDataTran.TableName == "t_Brand")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_Brand";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSProductGroups = new CJ.Class.POS.DSProductGroups();
                            _oDSBrand = new CJ.Class.POS.DSBrand();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSBrand = oSerivce.DownloadProductBrand(oDSBrand, nWHID);
                            //pbDownload.PerformStep();

                            _oDSBrand.Merge(oDSBrand);
                            _oDSBrand.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSBrand.Brand.Count > 0)
                                oDataTransfer.InsertProductBrand(_oDSBrand);

                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSBrand.Brand.Count > 0)
                                oSerivce.UpdateProductBrandTransferInfo(oDSBrand, nWHID);
                            pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSBrand.Brand.Count;
                            if (oDSBrand.Brand.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Brand");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Brand /" + ex.Message);
                            MessageBox.Show("Please Cheak Brand segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region product
                    else if (oDataTran.TableName == "t_Product")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_Product";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            oDSProduct = new DSProduct();
                            _oDSProduct = new CJ.Class.POS.DSProduct();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSProduct = oSerivce.DownloadProduct(oDSProduct, nWHID);
                            //pbDownload.PerformStep();

                            _oDSProduct.Merge(oDSProduct);
                            _oDSProduct.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSProduct.Product.Count > 0)
                                oDataTransfer.InsertProduct(_oDSProduct);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSProduct.Product.Count > 0)
                                oSerivce.UpdateProductTransferInfo(oDSProduct, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSProduct.Product.Count;
                            if (oDSProduct.Product.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Product");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Product /" + ex.Message);
                            MessageBox.Show("Please Cheak Product Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Product Price
                    else if (oDataTran.TableName == "t_FinishedGoodsPrice")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_FinishedGoodsPrice";
                            lblTableName.Refresh();

                            oDSFinishedGoodsPrice = new DSFinishedGoodsPrice();
                            _oDSFinishedGoodsPrice = new CJ.Class.POS.DSFinishedGoodsPrice();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSFinishedGoodsPrice = oSerivce.DownloadProductPrice(oDSFinishedGoodsPrice, nWHID);
                            //pbDownload.PerformStep();

                            _oDSFinishedGoodsPrice.Merge(oDSFinishedGoodsPrice);
                            _oDSFinishedGoodsPrice.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataTransfer.InsertProductPrice(_oDSFinishedGoodsPrice);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSFinishedGoodsPrice.Price.Count > 0)
                                oSerivce.UpdateProductPriceTransferInfo(oDSFinishedGoodsPrice, nWHID);
                            //pbDownload.PerformStep();
                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSFinishedGoodsPrice.Price.Count;
                            if (oDSFinishedGoodsPrice.Price.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Product Price");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Product Price /" + ex.Message);
                            MessageBox.Show("Please Cheak Product Price Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region EmployeeDetails
                    else if (oDataTran.TableName == "v_EmployeeDetails")
                    {
                        try
                        {
                            lblTableName.Text = txt + "v_EmployeeDetails";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSEmployee = new CJ.Class.POS.DSEmployee();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSEmployee = oSerivce.DownloadEmployee(oDSEmployee, nWHID);
                            //pbDownload.PerformStep();

                            _oDSEmployee.Merge(oDSEmployee);
                            _oDSEmployee.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSEmployee.Employee.Count > 0)
                                oDataTransfer.InsertEmployee(_oDSEmployee);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSEmployee.Employee.Count > 0)
                                oSerivce.UpdateEmployeeTransferInfo(oDSEmployee, nWHID);
                            //pbDownload.PerformStep();
                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();

                            nCount = nCount + oDSEmployee.Employee.Count;
                            if (oDSEmployee.Employee.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Inserted Employee");
                            }
                            i = i + 1;
                            pbDownload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Employee /" + ex.Message);
                            MessageBox.Show("Please Cheak Employee Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #endregion

                    #region User
                    else if (oDataTran.TableName == "t_user")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_User";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_UserPermission";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSUser = new CJ.Class.POS.DSUser();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();
                            oDSUser = oSerivce.DownloadUser(oDSUser, nWHID);
                            //pbDownload.PerformStep();

                            _oDSUser.Merge(oDSUser);
                            _oDSUser.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSUser.User.Count > 0)
                                oDataTransfer.InsertUser(_oDSUser);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSUser.User.Count > 0)
                                oSerivce.UpdateUserTransferInfo(oDSUser, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();

                            nCount = nCount + oDSUser.User.Count;
                            if (oDSUser.User.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Inserted User");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting User /" + ex.Message);
                            MessageBox.Show("Please Cheak User Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Sales Promotion Type
                    else if (oDataTran.TableName == "t_SalesPromotionType")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_SalesPromotionType";
                            lblTableName.Refresh();

                            _oDSSalesPromotionType = new CJ.Class.POS.DSSalesPromotionType();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSSalesPromotionType = oSerivce.DownloadDSSalesPromotionType(oDSSalesPromotionType, nWHID);


                            _oDSSalesPromotionType.Merge(oDSSalesPromotionType);
                            _oDSSalesPromotionType.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSSalesPromotionType.SalesPromotionType.Count > 0)
                                oDataTransfer.InsertSalesPromotionType(_oDSSalesPromotionType);

                            oSerivce = new Service();
                            if (oDSSalesPromotionType.SalesPromotionType.Count > 0)
                                oSerivce.UpdateSalesPromotionTypeInfo(oDSSalesPromotionType, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSSalesPromotionType.SalesPromotionType.Count;
                            if (oDSSalesPromotionType.SalesPromotionType.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Sales Promotion Type");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Sales Promotion Type /" + ex.Message);
                            MessageBox.Show("Please Cheak Sales Promotion Type segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Promotion
                    else if (oDataTran.TableName == "t_SalesPromo")
                    {
                        try
                        {

                            lblTableName.Text = txt + "t_SalesPromo";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesPromoProduct";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesPromoChannel";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesPromoWarehouse";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesPromoType";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesPromoDiscount";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesPromoSlab";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesPromoSlabRatio";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesPromoFreeProduct";
                            lblTableName.Refresh();

                            _oDSPromotion = new CJ.Class.POS.DSPromotion();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPromotion = oSerivce.DownloadPromotion(oDSPromotion, nWHID);

                            _oDSPromotion.Merge(oDSPromotion);
                            _oDSPromotion.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPromotion.SalesPromotion.Count > 0)
                                oDataTransfer.InsertPromotio(_oDSPromotion);

                            oSerivce = new Service();
                            if (oDSPromotion.SalesPromotion.Count > 0)
                                oSerivce.UpdatePromotionTransferInfo(oDSPromotion, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSPromotion.SalesPromotion.Count;
                            if (oDSPromotion.SalesPromotion.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Inserted Sales Promotion");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Sales Promotion /" + ex.Message);
                            MessageBox.Show("Please Cheak Sales Promotion Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #endregion

                    #region Warranty

                    else if (oDataTran.TableName == "t_WarrantyParam")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_WarrantyParam";
                            lblTableName.Refresh();

                            _oDSWarranty = new CJ.Class.POS.DSWarranty();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSWarranty = oSerivce.DownloadWarranty(oDSWarranty, nWHID);
                            //pbDownload.PerformStep();

                            _oDSWarranty.Merge(oDSWarranty);
                            _oDSWarranty.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSWarranty.WarrantyParam.Count > 0)
                                oDataTransfer.InsertWarranty(_oDSWarranty);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSWarranty.WarrantyParam.Count > 0)
                                oSerivce.UpdateWarrantyTransferInfo(oDSWarranty, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSWarranty.WarrantyParam.Count;
                            if (oDSWarranty.WarrantyParam.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Warranty Parameter");
                            }
                            i = i + 1;
                            pbDownload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Warranty Parameter /" + ex.Message);
                            MessageBox.Show("Please Cheak Warranty Parameter Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Retail Consumer
                    else if (oDataTran.TableName == "t_RetailConsumer")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_RetailConsumer";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSRetailConsumer = new CJ.Class.POS.DSRetailConsumer();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSRetailConsumer = oSerivce.DownloadRetailConsumer(oDSRetailConsumer, nWHID);
                            //pbDownload.PerformStep();

                            _oDSRetailConsumer.Merge(oDSRetailConsumer);
                            _oDSRetailConsumer.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSRetailConsumer.RetailConsumer.Count > 0)
                                oDataTransfer.InsertConsumer(_oDSRetailConsumer, nCustomerID);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSRetailConsumer.RetailConsumer.Count > 0)
                                oSerivce.UpdateConsumerTransferInfo(oDSRetailConsumer, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();

                            nCount = nCount + oDSRetailConsumer.RetailConsumer.Count;
                            if (oDSRetailConsumer.RetailConsumer.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Retail Consumer");
                            }
                            i = i + 1;
                            pbDownload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Retail Consumer /" + ex.Message);
                            MessageBox.Show("Please Cheak Retail Consumer Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region CLP
                    /*
                    else if (oDataTran.TableName == "t_CLPTran")
                    {
                        try
                        {
                            pbtDownload.Visible = true;
                            pbtDownload.Minimum = 0;
                            pbtDownload.Maximum = 2;
                            pbtDownload.Step = 1;
                            pbtDownload.Value = 0;

                            _oDSCLP = new CJ.Class.POS.DSCLP();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();
                            oDSCLP = oSerivce.DownloadCLP(oDSCLP, nWHID);
                            pbtDownload.PerformStep();

                            _oDSCLP.Merge(oDSCLP);
                            _oDSCLP.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (oDSCLP.CLPEligibility.Count > 0)
                                oDataTransfer.InsertCLP(_oDSCLP);
                            pbtDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            pgbInsert.PerformStep();
                            nCount = nCount + oDSRetailConsumer.RetailConsumer.Count;
                        }
                        catch
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Please Cheak CLP Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    */
                    #endregion

                    #region This System
                    else if (oDataTran.TableName == "t_ThisSystem")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_ThisSystem";
                            lblTableName.Refresh();

                            //pbDownload.Visible = true;
                            //pbDownload.Minimum = 0;
                            //pbDownload.Maximum = 3;
                            //pbDownload.Step = 1;
                            //pbDownload.Value = 0;

                            _oDSThisSystem = new CJ.Class.POS.DSThisSystem();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSThisSystem = oSerivce.DownloadThisSystem(oDSThisSystem, nWHID);
                            //pbDownload.PerformStep();

                            _oDSThisSystem.Merge(oDSThisSystem);
                            oDSThisSystem.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSThisSystem.ThisSystem.Count > 0)
                                oDataTransfer.UpdateThisSystem(_oDSThisSystem);

                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSThisSystem.ThisSystem.Count > 0)
                                oSerivce.UpdateThisSystmeInfo(oDSThisSystem, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSThisSystem.ThisSystem.Count;
                            if (oDSThisSystem.ThisSystem.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded This System info");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading This System info /" + ex.Message);
                            MessageBox.Show("Please Cheak System info Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Stock Requisition

                    else if (oDataTran.TableName == "t_StockRequisition")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_StockRequisition";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_StockRequisitionItem";
                            lblTableName.Refresh();

                            oSerivce = new Service();
                            _oDSRequisition = new CJ.Class.POS.DSRequisition();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSRequisition = new DSRequisition();

                            oDSRequisition = oSerivce.DownloadStockRequisition(oDSRequisition, nWHID);


                            _oDSRequisition.Merge(oDSRequisition);
                            _oDSRequisition.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSRequisition.StockRequisition.Count > 0)
                            {
                                //oDataTransfer.InsertStockRequisition(_oDSRequisition);
                                oDataTransfer.InsertStockRequisitionforNewVat(_oDSRequisition, nWHID);
                            }

                            oSerivce = new Service();
                            if (oDSRequisition.StockRequisition.Count > 0)
                            {
                                oSerivce.UpdateStockRequisitionInfo(oDSRequisition, nWHID);
                            }

                            CJ.Class.DBController.Instance.CommitTransaction();


                            nCount = nCount + oDSRequisition.StockRequisition.Count;
                            if (oDSRequisition.StockRequisition.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Inserted Stock Requisition");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Stock Requisition /" + ex.Message);
                            MessageBox.Show("Please Cheak Stock Requisition\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #endregion

                    #region Product Stock Tran
                    else if (oDataTran.TableName == "t_ProductStockTran")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_ProductStockTran";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_ProductStockTranItem";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_ProductTransferProductSerial";
                            lblTableName.Refresh();


                            _oDSProductTransaction = new CJ.Class.POS.DSProductTransaction();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();

                            oDSProductTransaction = oSerivce.DownloadProductTran(oDSProductTransaction, nWHID);


                            _oDSProductTransaction.Merge(oDSProductTransaction);
                            _oDSProductTransaction.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSProductTransaction.ProductStockTran.Count > 0)
                            {
                                oDataTransfer.InsertProductStockTran(_oDSProductTransaction);
                            }

                            oSerivce = new Service();
                            if (oDSProductTransaction.ProductStockTran.Count > 0)
                                oSerivce.UpdateProductTranTransferInfo(oDSProductTransaction, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();


                            nCount = nCount + oDSProductTransaction.ProductStockTran.Count;
                            if (oDSProductTransaction.ProductStockTran.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Inserted Product Stock Tran");
                            }

                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Product Stock Tran /" + ex.Message);
                            MessageBox.Show("Please Cheak Product Tran Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region UnsoldDefectiveProduct
                    if (oDataTran.TableName == "t_UnsoldDefectiveProduct")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_UnsoldDefectiveProduct";
                            lblTableName.Refresh();

                            _oDSUnsoldDefectiveProduct = new CJ.Class.POS.DSUnsoldDefectiveProduct();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSUnsoldDefectiveProduct = oSerivce.DownloadUnsoldDefectiveProduct(oDSUnsoldDefectiveProduct, nWHID);

                            _oDSUnsoldDefectiveProduct.Merge(oDSUnsoldDefectiveProduct);
                            _oDSUnsoldDefectiveProduct.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.Count > 0)
                                oDataTransfer.InsertUnsoldDefectiveProduct(_oDSUnsoldDefectiveProduct);

                            //pbtDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.Count > 0)
                                oSerivce.UpdateUnsoldDefectiveProductInfo(oDSUnsoldDefectiveProduct, nWHID);
                            //pbtDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.Count;
                            if (oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Unsold Defective Product");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Unsold Defective Product /" + ex.Message);
                            MessageBox.Show("Please Cheak Unsold Defective Product segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #endregion

                    #region UnsoldDefectiveProductNew
                    if (oDataTran.TableName == "t_UnsoldDefectiveProductNew")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_UnsoldDefectiveProductNew";
                            lblTableName.Refresh();

                            _oDSUnsoldDefectiveProduct = new CJ.Class.POS.DSUnsoldDefectiveProduct();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSUnsoldDefectiveProduct = oSerivce.DownloadUnsoldDefectiveProductNew(oDSUnsoldDefectiveProduct, nWHID);

                            _oDSUnsoldDefectiveProduct.Merge(oDSUnsoldDefectiveProduct);
                            _oDSUnsoldDefectiveProduct.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.Count > 0)
                                oDataTransfer.InsertUnsoldDefectiveProductNew(_oDSUnsoldDefectiveProduct);

                            //pbtDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.Count > 0)
                                oSerivce.UpdateUnsoldDefectiveProductInfoNew(oDSUnsoldDefectiveProduct, nWHID);
                            //pbtDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.Count;
                            if (oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Unsold Defective Product");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Unsold Defective Product /" + ex.Message);
                            MessageBox.Show("Please Cheak Unsold Defective Product segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #endregion

                    #region OfficeItem
                    else if (oDataTran.TableName == "t_OfficeItems")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_OfficeItems";
                            lblTableName.Refresh();

                            oDSOfficeItem = new DSOfficeItem();
                            _oDSOfficeItem = new CJ.Class.POS.DSOfficeItem();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSOfficeItem = oSerivce.DownloadOfficeItem(oDSOfficeItem, nWHID);
                            //pbDownload.PerformStep();

                            _oDSOfficeItem.Merge(oDSOfficeItem);
                            _oDSOfficeItem.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSOfficeItem.OfficeItem.Count > 0)
                                oDataTransfer.InsertOfficeItem(_oDSOfficeItem);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSOfficeItem.OfficeItem.Count > 0)
                                oSerivce.UpdateOfficeItemInfo(oDSOfficeItem, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSOfficeItem.OfficeItem.Count;
                            if (oDSOfficeItem.OfficeItem.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded OfficeItem");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading OfficeItem /" + ex.Message);
                            MessageBox.Show("Please Cheak OfficeItem Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Office Item Tran
                    else if (oDataTran.TableName == "t_OfficeItemTran")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_OfficeItemTran";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_OfficeItemTranDetail";
                            lblTableName.Refresh();

                            _oDSOfficeItemTran = new CJ.Class.POS.DSOfficeItemTran();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();

                            oDSOfficeItemTran = oSerivce.DownloadOfficeItemTran(oDSOfficeItemTran, nWHID);
                            _oDSOfficeItemTran.Merge(oDSOfficeItemTran);
                            _oDSOfficeItemTran.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSOfficeItemTran.OfficeItemTran.Count > 0)
                            {
                                oDataTransfer.UpdateOfficeItemTran(_oDSOfficeItemTran);
                            }
                            oSerivce = new Service();
                            if (oDSOfficeItemTran.OfficeItemTran.Count > 0)
                                oSerivce.UpdateOfficeItemTranInfo(oDSOfficeItemTran, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSOfficeItemTran.OfficeItemTran.Count;
                            if (oDSOfficeItemTran.OfficeItemTran.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Inserted Office Item Tran");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Office Item Tran /" + ex.Message);
                            MessageBox.Show("Please Cheak Office Item Tran Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Credit Approval
                    else if (oDataTran.TableName == "t_CustomerCreditApproval")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_CustomerCreditApproval";
                            lblTableName.Refresh();

                            oDSCustmerCreditApprval = new DSCustmerCreditApprval();
                            _oDSCustmerCreditApprval = new CJ.Class.POS.DSCustmerCreditApprval();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSCustmerCreditApprval = oSerivce.DownloadCustomerCreditApproval(oDSCustmerCreditApprval, nWHID);
                            //pbDownload.PerformStep();

                            _oDSCustmerCreditApprval.Merge(oDSCustmerCreditApprval);
                            _oDSCustmerCreditApprval.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSCustmerCreditApprval.CustomerCreditApproval.Count > 0)
                                oDataTransfer.InsertCreditApprovalData(_oDSCustmerCreditApprval);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSCustmerCreditApprval.CustomerCreditApproval.Count > 0)
                                oSerivce.UpdateCustomerCreditApprovalInfo(oDSCustmerCreditApprval, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSCustmerCreditApprval.CustomerCreditApproval.Count;
                            if (oDSCustmerCreditApprval.CustomerCreditApproval.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Credit Approval");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Credit Approval /" + ex.Message);
                            MessageBox.Show("Please Cheak Credit Approval Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region CalendarWeek
                    else if (oDataTran.TableName == "t_CalendarWeek")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_CalendarWeek";
                            lblTableName.Refresh();

                            oDSCalendarWeek = new DSCalendarWeek();
                            _oDSCalendarWeek = new CJ.Class.POS.DSCalendarWeek();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSCalendarWeek = oSerivce.DownloadCalendarWeek(oDSCalendarWeek, nWHID);

                            _oDSCalendarWeek.Merge(oDSCalendarWeek);
                            _oDSCalendarWeek.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSCalendarWeek.CalendarWeek.Count > 0)
                                oDataTransfer.InsertCalendarWeek(_oDSCalendarWeek);

                            oSerivce = new Service();
                            if (oDSCalendarWeek.CalendarWeek.Count > 0)
                                oSerivce.UpdateCalendarWeekInfo(oDSCalendarWeek, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSCalendarWeek.CalendarWeek.Count;
                            if (oDSCalendarWeek.CalendarWeek.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded CalendarWeek");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading CalendarWeek /" + ex.Message);
                            MessageBox.Show("Please Cheak CalendarWeek Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region PlanCustomerTarget
                    else if (oDataTran.TableName == "t_PlanCustomerTarget")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PlanCustomerTarget";
                            lblTableName.Refresh();

                            oDSPlanCustomerTarget = new DSPlanCustomerTarget();
                            _oDSPlanCustomerTarget = new CJ.Class.POS.DSPlanCustomerTarget();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPlanCustomerTarget = oSerivce.DownloadPlanCustomerTarget(oDSPlanCustomerTarget, nWHID);

                            _oDSPlanCustomerTarget.Merge(oDSPlanCustomerTarget);
                            _oDSPlanCustomerTarget.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPlanCustomerTarget.PlanCustomerTarget.Count > 0)
                                oDataTransfer.InsertPlanCustomerTargetNew(_oDSPlanCustomerTarget);

                            oSerivce = new Service();
                            if (oDSPlanCustomerTarget.PlanCustomerTarget.Count > 0)
                                oSerivce.UpdatePlanCustomerTargetInfo(oDSPlanCustomerTarget, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPlanCustomerTarget.PlanCustomerTarget.Count;
                            if (oDSPlanCustomerTarget.PlanCustomerTarget.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Customer Target");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Customer Target /" + ex.Message);
                            MessageBox.Show("Please Cheak Customer Target Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region PlanExecutiveWeekTarget
                    else if (oDataTran.TableName == "t_PlanExecutiveWeekTarget")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PlanExecutiveWeekTarget";
                            lblTableName.Refresh();

                            oDSPlanExecutiveWeekTarget = new DSPlanExecutiveWeekTarget();
                            _oDSPlanExecutiveWeekTarget = new CJ.Class.POS.DSPlanExecutiveWeekTarget();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPlanExecutiveWeekTarget = oSerivce.DownloadPlanExecutiveWeekTarget(oDSPlanExecutiveWeekTarget, nWHID);

                            _oDSPlanExecutiveWeekTarget.Merge(oDSPlanExecutiveWeekTarget);
                            _oDSPlanExecutiveWeekTarget.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPlanExecutiveWeekTarget.PlanExecutiveWeekTarget.Count > 0)
                                oDataTransfer.InsertPlanExecutiveWeekTargetNew(_oDSPlanExecutiveWeekTarget);

                            oSerivce = new Service();
                            if (oDSPlanExecutiveWeekTarget.PlanExecutiveWeekTarget.Count > 0)
                                oSerivce.UpdatePlanExecutiveWeekTargetInfo(oDSPlanExecutiveWeekTarget, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPlanExecutiveWeekTarget.PlanExecutiveWeekTarget.Count;
                            if (oDSPlanExecutiveWeekTarget.PlanExecutiveWeekTarget.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Plan ExecutiveWeek Target");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Plan ExecutiveWeek Target /" + ex.Message);
                            MessageBox.Show("Please Cheak Plan ExecutiveWeek Target Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region PlanMAGWeekTarget
                    else if (oDataTran.TableName == "t_PlanMAGWeekTargetQty")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PlanMAGWeekTargetQty";
                            lblTableName.Refresh();

                            oDSPlanMAGWeekTargetQty = new DSPlanMAGWeekTargetQty();
                            _oDSPlanMAGWeekTargetQty = new CJ.Class.POS.DSPlanMAGWeekTargetQty();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPlanMAGWeekTargetQty = oSerivce.DownloadPlanMAGWeekTargetQty(oDSPlanMAGWeekTargetQty, nWHID);

                            _oDSPlanMAGWeekTargetQty.Merge(oDSPlanMAGWeekTargetQty);
                            _oDSPlanMAGWeekTargetQty.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPlanMAGWeekTargetQty.PlanMAGWeekTargetQty.Count > 0)
                                oDataTransfer.InsertPlanMAGWeekTargetQtyNew(_oDSPlanMAGWeekTargetQty);

                            oSerivce = new Service();
                            if (oDSPlanMAGWeekTargetQty.PlanMAGWeekTargetQty.Count > 0)
                                oSerivce.UpdatePlanMAGWeekTargetQtyInfo(oDSPlanMAGWeekTargetQty, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPlanMAGWeekTargetQty.PlanMAGWeekTargetQty.Count;
                            if (oDSPlanMAGWeekTargetQty.PlanMAGWeekTargetQty.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Plan MAG Week Target Qty");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Plan MAG Week Target Qty /" + ex.Message);
                            MessageBox.Show("Please Cheak Plan MAG Week Target Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region OutletDisplay Position Rack
                    else if (oDataTran.TableName == "t_OutletDisplayPositionRack")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_OutletDisplayPositionRack";
                            lblTableName.Refresh();


                            _oDSOutletDisplayPositionRack = new CJ.Class.POS.DSOutletDisplayPosition();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSOutletDisplayPositionRack = oSerivce.DownloadOutletDisplayPositionRack(oDSOutletDisplayPositionRack, nWHID);

                            _oDSOutletDisplayPositionRack.Merge(oDSOutletDisplayPositionRack);
                            _oDSOutletDisplayPositionRack.AcceptChanges();
                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSOutletDisplayPositionRack.OutletDisplayPositionRack.Count > 0)
                                oDataTransfer.InsertOutletDisplayPositionRack(_oDSOutletDisplayPositionRack);
                            oSerivce = new Service();
                            if (oDSOutletDisplayPositionRack.OutletDisplayPositionRack.Count > 0)
                                oSerivce.UpdateOutletDisplayPositionRack(oDSOutletDisplayPositionRack, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSOutletDisplayPositionRack.OutletDisplayPositionRack.Count;
                            if (oDSOutletDisplayPositionRack.OutletDisplayPositionRack.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Display Position Rack");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Display Position Rack /" + ex.Message);
                            MessageBox.Show("Please Cheak Display Position Rack segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region OutletDisplayPosition
                    else if (oDataTran.TableName == "t_OutletDisplayPosition")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_OutletDisplayPosition";
                            lblTableName.Refresh();

                            oDSOutletDisplayPosition = new DSOutletDisplayPosition();
                            _oDSOutletDisplayPosition = new CJ.Class.POS.DSOutletDisplayPosition();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSOutletDisplayPosition = oSerivce.DownloadDSOutletDisplayPosition(oDSOutletDisplayPosition, nWHID);

                            _oDSOutletDisplayPosition.Merge(oDSOutletDisplayPosition);
                            _oDSOutletDisplayPosition.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSOutletDisplayPosition.OutletDisplayPosition.Count > 0)
                                oDataTransfer.InsertOutletDisplayPosition(_oDSOutletDisplayPosition);
                            oSerivce = new Service();
                            if (oDSOutletDisplayPosition.OutletDisplayPosition.Count > 0)
                                oSerivce.UpdateOutletDisplayPositionInfo(oDSOutletDisplayPosition, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSOutletDisplayPosition.OutletDisplayPosition.Count;
                            if (oDSOutletDisplayPosition.OutletDisplayPosition.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Display Position");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Display Position /" + ex.Message);
                            MessageBox.Show("Please Cheak Outlet Display Position Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region TPVatProduct
                    else if (oDataTran.TableName == "t_TPVatProduct")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_TPVatProduct";
                            lblTableName.Refresh();

                            oDSTPVatProduct = new DSTPVatProduct();
                            _oDSTPVatProduct = new CJ.Class.POS.DSTPVatProduct();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSTPVatProduct = oSerivce.DownloadoTPVatProduct(oDSTPVatProduct, nWHID);
                            //pbDownload.PerformStep();

                            _oDSTPVatProduct.Merge(oDSTPVatProduct);
                            _oDSTPVatProduct.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSTPVatProduct.TPVatProduct.Count > 0)
                                oDataTransfer.InsertTpVatProduct(_oDSTPVatProduct);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSTPVatProduct.TPVatProduct.Count > 0)
                                oSerivce.UpdateTPVatProductTransferInfo(oDSTPVatProduct, nWHID);
                            //pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSTPVatProduct.TPVatProduct.Count;
                            if (oDSTPVatProduct.TPVatProduct.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded TP Vat Product Info");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading TP Vat Product /" + ex.Message);
                            MessageBox.Show("Please Cheak TP Vat Product Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Temp Customer
                    else if (oDataTran.TableName == "t_CustomerTemp")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_CustomerTemp";
                            lblTableName.Refresh();

                            _oDSCustomerTemp = new CJ.Class.POS.DSCustomerTemp();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSCustomerTemp = oSerivce.DownloadCustomerTemp(oDSCustomerTemp, nWHID);


                            _oDSCustomerTemp.Merge(oDSCustomerTemp);
                            _oDSCustomerTemp.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSCustomerTemp.CustomerTemp.Count > 0)
                                oDataTransfer.UpdateStatusCustomerTemp(_oDSCustomerTemp, nWHID);

                            oSerivce = new Service();
                            if (oDSCustomerTemp.CustomerTemp.Count > 0)
                                oSerivce.UpdateCustomerTempInfo(oDSCustomerTemp, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSCustomerTemp.CustomerTemp.Count;
                            if (oDSCustomerTemp.CustomerTemp.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Temp Customer Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Temp Customer Data /" + ex.Message);
                            MessageBox.Show("Please Cheak Temp Customer segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Reverse Appalication
                    else if (oDataTran.TableName == "t_InvoiceReverse")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_InvoiceReverse";
                            lblTableName.Refresh();

                            _oDSInvoiceReverse = new CJ.Class.POS.DSInvoiceReverse();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSInvoiceReverse = oSerivce.DownloadInvoiceReverseData(oDSInvoiceReverse, nWHID);


                            _oDSInvoiceReverse.Merge(oDSInvoiceReverse);
                            _oDSInvoiceReverse.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSInvoiceReverse.InvoiceReverse.Count > 0)
                                oDataTransfer.UpdateStatusInvoiceReverse(_oDSInvoiceReverse, nWHID);

                            oSerivce = new Service();
                            if (oDSInvoiceReverse.InvoiceReverse.Count > 0)
                                oSerivce.UpdatInvoiceReverseInfo(oDSInvoiceReverse, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSInvoiceReverse.InvoiceReverse.Count;
                            if (oDSInvoiceReverse.InvoiceReverse.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Reverse Invoice Approval");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Reverse Invoice Appalication Data /" + ex.Message);
                            MessageBox.Show("Please Cheak Reverse Invoice Appalication segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Exchange Offer Vender
                    else if (oDataTran.TableName == "t_ExchangeOfferVender")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_ExchangeOfferVender";
                            lblTableName.Refresh();

                            _oDSExchangeOfferVender = new CJ.Class.POS.DSExchangeOfferVender();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSExchangeOfferVender = oSerivce.DownloadExchangeOfferVender(oDSExchangeOfferVender, nWHID);


                            _oDSExchangeOfferVender.Merge(oDSExchangeOfferVender);
                            _oDSExchangeOfferVender.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSExchangeOfferVender.ExchangeOfferVender.Count > 0)
                                oDataTransfer.InsertExchangeOfferVender(_oDSExchangeOfferVender);
                            //oDataTransfer.InsertExchangeOfferVenderAccount(_oDSExchangeOfferVender);

                            oSerivce = new Service();
                            if (oDSExchangeOfferVender.ExchangeOfferVender.Count > 0)
                                oSerivce.UpdatExchangeOfferVenderInfo(oDSExchangeOfferVender, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSExchangeOfferVender.ExchangeOfferVender.Count;
                            if (oDSExchangeOfferVender.ExchangeOfferVender.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Exchange Offer Vender");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Exchange Offer Vender Data /" + ex.Message);
                            MessageBox.Show("Please Cheak Exchange Offer Vender segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    //#region Exchange Offer Vender Tran
                    //else if (oDataTran.TableName == "t_ExchangeOfferVenderTran")
                    //{
                    //    try
                    //    {
                    //        lblTableName.Text = txt + "t_ExchangeOfferVenderTran";
                    //        lblTableName.Refresh();

                    //        _oDSExchangeOfferVenderTran = new CJ.Class.POS.DSExchangeOfferVenderTran();
                    //        oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                    //        oDSExchangeOfferVenderTran = oSerivce.DownloadExchangeOfferVenderTran(oDSExchangeOfferVenderTran, nWHID);


                    //        _oDSExchangeOfferVenderTran.Merge(oDSExchangeOfferVenderTran);
                    //        _oDSExchangeOfferVenderTran.AcceptChanges();

                    //        CJ.Class.DBController.Instance.BeginNewTransaction();

                    //        if (_oDSExchangeOfferVenderTran.ExchangeOfferVenderTran.Count > 0)
                    //            oDataTransfer.InsertExchangeOfferVenderTran(_oDSExchangeOfferVenderTran);
                    //        oDataTransfer.InsertExchangeOfferVenderTranAccount(_oDSExchangeOfferVenderTran);

                    //        oSerivce = new Service();
                    //        if (oDSExchangeOfferVenderTran.ExchangeOfferVenderTran.Count > 0)
                    //            oSerivce.UpdatExchangeOfferVenderTranInfo(oDSExchangeOfferVenderTran, nWHID);

                    //        CJ.Class.DBController.Instance.CommitTransaction();

                    //        nCount = nCount + oDSExchangeOfferVenderTran.ExchangeOfferVenderTran.Count;
                    //        if (oDSExchangeOfferVenderTran.ExchangeOfferVenderTran.Count > 0)
                    //        {
                    //            AppLogger.LogInfo("Successfully Downloaded Exchange Offer Vender Tran");
                    //        }
                    //        i = i + 1;
                    //        pbDownload.Value = i;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        CJ.Class.DBController.Instance.RollbackTransaction();
                    //        AppLogger.LogError("Error Downloading Exchange Offer Vender Tran Data /" + ex.Message);
                    //        MessageBox.Show("Please Cheak Exchange Offer Vender Tran segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return false;
                    //    }
                    //}
                    //#endregion

                    #region Exchange Offer Job
                    else if (oDataTran.TableName == "t_ExchangeOfferJob")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_ExchangeOfferJob";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_ExchangeOfferJobDetail";
                            lblTableName.Refresh();


                            _oDSExchangeOfferJob = new CJ.Class.POS.DSExchangeOfferJob();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();

                            oDSExchangeOfferJob = oSerivce.DownloadExchangeOfferJob(oDSExchangeOfferJob, nWHID);

                            _oDSExchangeOfferJob.Merge(oDSExchangeOfferJob);
                            _oDSExchangeOfferJob.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSExchangeOfferJob.ExchangeOfferJob.Count > 0)
                            {
                                oDataTransfer.InsertExchangeOfferJob(_oDSExchangeOfferJob);
                            }

                            oSerivce = new Service();
                            if (oDSExchangeOfferJob.ExchangeOfferJob.Count > 0)
                                oSerivce.UpdateExchangeOfferJobInfo(oDSExchangeOfferJob, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSExchangeOfferJob.ExchangeOfferJob.Count;
                            if (oDSExchangeOfferJob.ExchangeOfferJob.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Inserted Exchange Offer Job");
                            }

                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Exchange Offer Job /" + ex.Message);
                            MessageBox.Show("Please Cheak Exchange Offer Job Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Money Receipt Transfer
                    else if (oDataTran.TableName == "t_ExchangeOfferMR")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_ExchangeOfferMR";
                            lblTableName.Refresh();

                            _oDSExchangeOfferMR = new CJ.Class.POS.DSExchangeOfferMR();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSExchangeOfferMR = oSerivce.DownloadExchangeOfferMRData(oDSExchangeOfferMR, nWHID);


                            _oDSExchangeOfferMR.Merge(oDSExchangeOfferMR);
                            _oDSExchangeOfferMR.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSExchangeOfferMR.ExchangeOfferMR.Count > 0)
                                oDataTransfer.UpdateExchangeOfferMRData(_oDSExchangeOfferMR);

                            oSerivce = new Service();
                            if (oDSExchangeOfferMR.ExchangeOfferMR.Count > 0)
                                oSerivce.UpdatEOMoneyReceiptInfo(oDSExchangeOfferMR, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSExchangeOfferMR.ExchangeOfferMR.Count;
                            if (oDSExchangeOfferMR.ExchangeOfferMR.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Exchange Offer Money Receipt");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Exchange Offer Money Receipt Data /" + ex.Message);
                            MessageBox.Show("Please Cheak Exchange Offer Money Receipt segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Ecommerce Lead
                    else if (oDataTran.TableName == "t_SalesInvoiceEcommerce")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_SalesInvoiceEcommerce";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_SalesInvoiceEcommerceDetail";
                            lblTableName.Refresh();


                            _oDSSalesInvoiceEcommerce = new CJ.Class.POS.DSSalesInvoiceEcommerce();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();

                            oDSSalesInvoiceEcommerce = oSerivce.DownloadSalesInvoiceEcommerceData(oDSSalesInvoiceEcommerce, nWHID);

                            _oDSSalesInvoiceEcommerce.Merge(oDSSalesInvoiceEcommerce);
                            _oDSSalesInvoiceEcommerce.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSSalesInvoiceEcommerce.SalesInvoiceEcommerce.Count > 0)
                            {
                                oDataTransfer.InsertSalesInvoiceEcommerceLead(_oDSSalesInvoiceEcommerce);
                            }

                            oSerivce = new Service();
                            if (oDSSalesInvoiceEcommerce.SalesInvoiceEcommerce.Count > 0)
                                oSerivce.UpdateSalesInvoiceEcommerceInfo(oDSSalesInvoiceEcommerce, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSSalesInvoiceEcommerce.SalesInvoiceEcommerce.Count;
                            if (oDSSalesInvoiceEcommerce.SalesInvoiceEcommerce.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Inserted SalesInvoice Ecommerce");
                            }

                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting SalesInvoice Ecommerce /" + ex.Message);
                            MessageBox.Show("Please Cheak SalesInvoice Ecommerce Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region PlanExecutiveLeadTarget
                    else if (oDataTran.TableName == "t_PlanExecutiveLeadTarget")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PlanExecutiveLeadTarget";
                            lblTableName.Refresh();

                            oDSPlanExecutiveLeadTarget = new DSPlanExecutiveWeekTarget();
                            _oDSPlanExecutiveLeadTarget = new CJ.Class.POS.DSPlanExecutiveWeekTarget();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPlanExecutiveLeadTarget = oSerivce.DownloadPlanExecutiveLeadTarget(oDSPlanExecutiveLeadTarget, nWHID);

                            _oDSPlanExecutiveLeadTarget.Merge(oDSPlanExecutiveLeadTarget);
                            _oDSPlanExecutiveLeadTarget.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPlanExecutiveLeadTarget.PlanExecutiveWeekTarget.Count > 0)
                                oDataTransfer.InsertPlanExecutiveLeadTargetNew(_oDSPlanExecutiveLeadTarget);

                            oSerivce = new Service();
                            if (oDSPlanExecutiveLeadTarget.PlanExecutiveWeekTarget.Count > 0)
                                oSerivce.UpdatePlanExecutiveLeadTargetInfo(oDSPlanExecutiveLeadTarget, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPlanExecutiveLeadTarget.PlanExecutiveWeekTarget.Count;
                            if (oDSPlanExecutiveLeadTarget.PlanExecutiveWeekTarget.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Plan ExecutiveWeek Target");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Plan ExecutiveWeek Target /" + ex.Message);
                            MessageBox.Show("Please Cheak Plan ExecutiveWeek Target Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Sales Lead Management
                    else if (oDataTran.TableName == "t_SalesLeadManagement")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_SalesLeadManagement";
                            lblTableName.Refresh();

                            _oDSSalesLead = new CJ.Class.POS.DSSalesLead();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSSalesLead = oSerivce.DownloadSalesLead(oDSSalesLead, nWHID);


                            _oDSSalesLead.Merge(oDSSalesLead);
                            _oDSSalesLead.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSSalesLead.SalesLead.Count > 0)
                                oDataTransfer.InsertSalesLeadManagementWEB(_oDSSalesLead, nWHID);

                            oSerivce = new Service();
                            if (oDSSalesLead.SalesLead.Count > 0)
                                oSerivce.UpdatSalesLeadInfo(oDSSalesLead, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSSalesLead.SalesLead.Count;
                            if (oDSSalesLead.SalesLead.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Sales Lead");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Sales Lead Data /" + ex.Message);
                            MessageBox.Show("Please Cheak Sales Lead segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Sales Lead Management History
                    else if (oDataTran.TableName == "t_SalesLeadManagementHistory")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_SalesLeadManagementHistory";
                            lblTableName.Refresh();

                            _oDSSalesLead = new CJ.Class.POS.DSSalesLead();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                            oDSSalesLead = oSerivce.DownloadSalesLeadHistory(oDSSalesLead, nWHID);


                            _oDSSalesLead.Merge(oDSSalesLead);
                            _oDSSalesLead.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSSalesLead.SalesLead.Count > 0)
                                oDataTransfer.InsertSalesLeadManagementHistoryWEB(_oDSSalesLead, nWHID);

                            oSerivce = new Service();
                            if (oDSSalesLead.SalesLead.Count > 0)
                                oSerivce.UpdatSalesLeadHistory(oDSSalesLead, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSSalesLead.SalesLead.Count;
                            if (oDSSalesLead.SalesLead.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Sales Lead History");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Sales Lead History Data /" + ex.Message);
                            MessageBox.Show("Please Cheak Sales Lead History Sagment \nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Product Feature Type
                    else if (oDataTran.TableName == "t_ProductFeatureType")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_ProductFeatureType";
                            lblTableName.Refresh();

                            oDSProductFeatureType = new DSProduct();
                            _oDSProductFeatureType = new CJ.Class.POS.DSProduct();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSProductFeatureType = oSerivce.DownloadProductFeatureType(oDSProductFeatureType, nWHID);

                            _oDSProductFeatureType.Merge(oDSProductFeatureType);
                            _oDSProductFeatureType.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSProductFeatureType.ProductFeatureType.Count > 0)
                                oDataTransfer.InsertProductFeatureType(_oDSProductFeatureType);

                            oSerivce = new Service();
                            if (oDSProductFeatureType.ProductFeatureType.Count > 0)
                                oSerivce.UpdateProductFeatureTypeTransferInfo(oDSProductFeatureType, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSProductFeatureType.ProductFeatureType.Count;
                            if (oDSProductFeatureType.ProductFeatureType.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Product Feature Type");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Product Feature Type/" + ex.Message);
                            MessageBox.Show("Please Cheak Product Feature Type Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region New Vat Activation
                    else if (oDataTran.TableName == "t_NewVatActivation")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_NewVatActivation";
                            lblTableName.Refresh();

                            oDSNewVatActivation = new DSBasicData();
                            _oDSNewVatActivation = new CJ.Class.POS.DSBasicData();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSNewVatActivation = oSerivce.DownloadNewVatActivation(oDSNewVatActivation, nWHID);

                            _oDSNewVatActivation.Merge(oDSNewVatActivation);
                            _oDSNewVatActivation.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSNewVatActivation.NewVatActivation.Count > 0)
                                oDataTransfer.InsertNewVatActivation(_oDSNewVatActivation);

                            oSerivce = new Service();
                            if (oDSNewVatActivation.NewVatActivation.Count > 0)
                                oSerivce.UpdateNewVatActivationInfo(oDSNewVatActivation, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSNewVatActivation.NewVatActivation.Count;
                            if (oDSNewVatActivation.NewVatActivation.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded New Vat Activation Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading New Vat Activation Data/" + ex.Message);
                            MessageBox.Show("Please Cheak New Vat Activation Data Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Customer Bank Guaranty
                    else if (oDataTran.TableName == "t_CustomerBankGuaranty")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_CustomerBankGuaranty";
                            lblTableName.Refresh();

                            oDSBank = new DSBank();
                            _oDSBank = new CJ.Class.POS.DSBank();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSBank = oSerivce.DownloadBankGuaranty(oDSBank, nWHID);

                            _oDSBank.Merge(oDSBank);
                            _oDSBank.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSBank.BankGuaranty.Count > 0)
                                oDataTransfer.InsertBankGuarenty(_oDSBank);

                            oSerivce = new Service();
                            if (oDSBank.BankGuaranty.Count > 0)
                                oSerivce.UpdateBankGuarantyInfo(oDSBank, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSBank.BankGuaranty.Count;
                            if (oDSBank.BankGuaranty.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Customer Bank Guaranty Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading  Customer Bank Guaranty Data/" + ex.Message);
                            MessageBox.Show("Please Cheak Customer Bank Guaranty Data Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Customer Account
                    else if (oDataTran.TableName == "t_CustomerAccount")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_CustomerAccount";
                            lblTableName.Refresh();

                            oDSCustomer = new DSCustomer();
                            _oDSCustomer = new CJ.Class.POS.DSCustomer();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSCustomer = oSerivce.DownloadCustomerAccount(oDSCustomer, nWHID);

                            _oDSCustomer.Merge(oDSCustomer);
                            _oDSCustomer.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSCustomer.Customer.Count > 0)
                                oDataTransfer.InsertCustomerAccount(_oDSCustomer);

                            oSerivce = new Service();
                            if (oDSCustomer.Customer.Count > 0)
                                oSerivce.UpdateCustomerBalanceInfo(oDSCustomer, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSCustomer.Customer.Count;
                            if (oDSCustomer.Customer.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Customer Account Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Customer Account Data/" + ex.Message);
                            MessageBox.Show("Please Cheak Customer Account Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region TD Activation
                    else if (oDataTran.TableName == "t_TDActivation")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_TDActivation";
                            lblTableName.Refresh();

                            oDSTDActivation = new DSBasicData();
                            _oDSTDActivation = new CJ.Class.POS.DSBasicData();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSTDActivation = oSerivce.DownloadTDActivation(oDSTDActivation, nWHID);

                            _oDSTDActivation.Merge(oDSTDActivation);
                            _oDSTDActivation.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSTDActivation.TDActivation.Count > 0)
                                oDataTransfer.InsertTDActivation(_oDSTDActivation);

                            oSerivce = new Service();
                            if (oDSTDActivation.TDActivation.Count > 0)
                                oSerivce.UpdateTDActivation(oDSTDActivation, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSTDActivation.TDActivation.Count;
                            if (oDSTDActivation.TDActivation.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded TD Activation Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading TD Activation Data/" + ex.Message);
                            MessageBox.Show("Please Cheak TD Activation Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region TD Delivery Shipment
                    else if (oDataTran.TableName == "t_TDDeliveryShipment")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_TDDeliveryShipment";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_TDDeliveryShipmentItem";
                            lblTableName.Refresh();

                            _oDSTDDeliveryShipment = new CJ.Class.POS.DSBasicData();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();
                            oDSTDDeliveryShipment = oSerivce.DownloadTDDeliveryShipment(oDSTDDeliveryShipment, nWHID);
                            _oDSTDDeliveryShipment.Merge(oDSTDDeliveryShipment);
                            _oDSTDDeliveryShipment.AcceptChanges();
                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSTDDeliveryShipment.TDDeliveryShipment.Count > 0)
                            {
                                oDataTransfer.InsertTDDeliveryShipment(_oDSTDDeliveryShipment);
                            }
                            oSerivce = new Service();
                            if (oDSTDDeliveryShipment.TDDeliveryShipment.Count > 0)
                                oSerivce.UpdateTDDeliveryShipmentData(oDSTDDeliveryShipment, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSTDDeliveryShipment.TDDeliveryShipment.Count;
                            if (oDSTDDeliveryShipment.TDDeliveryShipment.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Download TD Delivery Shipment Data");
                            }

                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting TD Delivery Shipment Data/" + ex.Message);
                            MessageBox.Show("Please Cheak TD Delivery Shipment Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Promo Discount
                    else if (oDataTran.TableName == "t_PromoDiscountBank" || oDataTran.TableName == "t_PromoDiscountB2B" || oDataTran.TableName == "t_PromoDiscountASGBrandEMI" || oDataTran.TableName == "t_PromoDiscountMAGBrand" || oDataTran.TableName == "t_EMITenure" || oDataTran.TableName == "t_EMIExtendedCharge" || oDataTran.TableName == "t_EMIBankMapping" || oDataTran.TableName == "t_PromoDiscountSpecial" || oDataTran.TableName == "t_SalesInvoiceDiscountType" || oDataTran.TableName == "t_PromoDiscountContributor")
                    {
                        try
                        {
                            if (oDataTran.TableName == "t_PromoDiscountBank")
                            {
                                lblTableName.Text = txt + "t_PromoDiscountBank";
                                lblTableName.Refresh();
                                //lblTableName.Text = txt + "t_PromoDiscountBankContribution";
                                //lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_PromoDiscountB2B")
                            {
                                lblTableName.Text = txt + "t_PromoDiscountB2B";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_PromoDiscountASGBrandEMI")
                            {
                                lblTableName.Text = txt + "t_PromoDiscountASGBrandEMI";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_PromoDiscountMAGBrand")
                            {
                                lblTableName.Text = txt + "t_PromoDiscountMAGBrand";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_EMITenure")
                            {
                                lblTableName.Text = txt + "t_EMITenure";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_EMIExtendedCharge")
                            {
                                lblTableName.Text = txt + "t_EMIExtendedCharge";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_EMIBankMapping")
                            {
                                lblTableName.Text = txt + "t_EMIBankMapping";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_PromoDiscountSpecial")
                            {
                                lblTableName.Text = txt + "t_PromoDiscountSpecial";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_SalesInvoiceDiscountType")
                            {
                                lblTableName.Text = txt + "t_SalesInvoiceDiscountType";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_PromoDiscountContributor")
                            {
                                lblTableName.Text = txt + "t_PromoDiscountContributor";
                                lblTableName.Refresh();
                            }

                            oDSPromoDiscount = new DSPromotion();
                            _oDSPromoDiscount = new CJ.Class.POS.DSPromotion();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPromoDiscount = oSerivce.DownloadPromoDiscountAllData(oDSPromoDiscount, nWHID, oDataTran.TableName);

                            _oDSPromoDiscount.Merge(oDSPromoDiscount);
                            _oDSPromoDiscount.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPromoDiscount.PromoDiscount.Count > 0)
                                oDataTransfer.InsertPromoDiscountAllData(_oDSPromoDiscount, oDataTran.TableName, nWHID);

                            oSerivce = new Service();
                            if (oDSPromoDiscount.PromoDiscount.Count > 0)
                                oSerivce.UpdatePromoDiscountAllData(oDSPromoDiscount, nWHID, oDataTran.TableName);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPromoDiscount.PromoDiscount.Count;
                            if (oDSPromoDiscount.PromoDiscount.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Promo Discount Data (" + oDataTran.TableName + ")");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Promo Discount Data (" + oDataTran.TableName + ")/" + ex.Message);
                            MessageBox.Show("Please Cheak Promo Discount Data (" + oDataTran.TableName + ")\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region New Sales Promotion
                    else if (oDataTran.TableName == "t_PromoCP" || oDataTran.TableName == "t_PromoTP")
                    {
                        try
                        {
                            if (oDataTran.TableName == "t_PromoCP")
                            {
                                lblTableName.Text = txt + "t_PromoCP";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPProductFor";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPWarehouse";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPType";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPSalesType";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPSlab";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPSlabRatio";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPOffer";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPOfferDetail";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoCPDiscountContribution";
                                lblTableName.Refresh();
                            }
                            else if (oDataTran.TableName == "t_PromoTP")
                            {

                                lblTableName.Text = txt + "t_PromoTP";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPProductFor";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPWarehouse";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPType";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPSalesType";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPSlab";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPSlabRatio";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPOffer";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPOfferDetail";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_PromoTPDiscountContribution";
                                lblTableName.Refresh();
                            }


                            _oDSPromotion = new CJ.Class.POS.DSPromotion();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPromotion = oSerivce.DownloadSalesPromotionNew(oDSPromotion, nWHID, oDataTran.TableName);
                            _oDSPromotion.Merge(oDSPromotion);
                            _oDSPromotion.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPromotion.Promo.Count > 0)
                                oDataTransfer.InsertSalesPromotionNew(_oDSPromotion, oDataTran.TableName, nWHID);

                            oSerivce = new Service();
                            if (oDSPromotion.Promo.Count > 0)
                                oSerivce.UpdateSalesPromoTransferInfoNew(oDSPromotion, nWHID, oDataTran.TableName);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSPromotion.Promo.Count;
                            if (oDSPromotion.Promo.Count > 0)
                            {
                                if (oDataTran.TableName == "t_PromoCP")
                                {
                                    AppLogger.LogInfo("Successfully Inserted Promo CP");
                                }
                                else if (oDataTran.TableName == "t_PromoTP")
                                {
                                    AppLogger.LogInfo("Successfully Inserted Promo TP");
                                }
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            if (oDataTran.TableName == "t_PromoCP")
                            {
                                CJ.Class.DBController.Instance.RollbackTransaction();
                                AppLogger.LogError("Error Inserting Promo CP /" + ex.Message);
                                MessageBox.Show("Please Cheak Promo CP Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;

                            }
                            else if (oDataTran.TableName == "t_PromoTP")
                            {
                                CJ.Class.DBController.Instance.RollbackTransaction();
                                AppLogger.LogError("Error Inserting Promo TP /" + ex.Message);
                                MessageBox.Show("Please Cheak Promo TP Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                        }
                    }

                    #endregion

                    #region Promo Discount SpecialAuthority
                    else if (oDataTran.TableName == "t_PromoDiscountSpecialAuthority")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PromoDiscountSpecialAuthority";
                            lblTableName.Refresh();

                            oDSPromoDiscountSpecialAuthority = new DSBasicData();
                            _oDSPromoDiscountSpecialAuthority = new CJ.Class.POS.DSBasicData();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPromoDiscountSpecialAuthority = oSerivce.DownloadPromoDiscountSpecialAuthority(oDSPromoDiscountSpecialAuthority, nWHID);

                            _oDSPromoDiscountSpecialAuthority.Merge(oDSPromoDiscountSpecialAuthority);
                            _oDSPromoDiscountSpecialAuthority.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPromoDiscountSpecialAuthority.PromoDiscountSpecialAuthority.Count > 0)
                                oDataTransfer.InsertPromoDiscountSpecialAuthority(_oDSPromoDiscountSpecialAuthority);

                            oSerivce = new Service();
                            if (oDSPromoDiscountSpecialAuthority.PromoDiscountSpecialAuthority.Count > 0)
                                oSerivce.UpdatePromoDiscountSpecialAuthority(oDSPromoDiscountSpecialAuthority, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPromoDiscountSpecialAuthority.PromoDiscountSpecialAuthority.Count;
                            if (oDSPromoDiscountSpecialAuthority.PromoDiscountSpecialAuthority.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Promo Discount Special Authority");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Promo Discount Special Authority Data/" + ex.Message);
                            MessageBox.Show("Please Cheak Promo Discount Special Authority Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Warehouse
                    else if (oDataTran.TableName == "t_Warehouse")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_Warehouse";
                            lblTableName.Refresh();

                            oDSWarehouse = new DSWarehouse();
                            _oDSWarehouse = new CJ.Class.POS.DSWarehouse();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSWarehouse = oSerivce.DownloadWarehouse(oDSWarehouse, nWHID);

                            _oDSWarehouse.Merge(oDSWarehouse);
                            _oDSWarehouse.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSWarehouse.Warehouse.Count > 0)
                                oDataTransfer.InsertWarehouse(_oDSWarehouse);

                            oSerivce = new Service();
                            if (oDSWarehouse.Warehouse.Count > 0)
                                oSerivce.UpdateWarehouseTransferInfo(oDSWarehouse, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSWarehouse.Warehouse.Count;
                            if (oDSWarehouse.Warehouse.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Warehouse Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Warehouse Data/" + ex.Message);
                            MessageBox.Show("Please Cheak Warehouse Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region PettyCashExpenseHead
                    else if (oDataTran.TableName == "t_PettyCashExpenseHead")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PettyCashExpenseHead";
                            lblTableName.Refresh();

                            oDSPettyCashExpenseHead = new DSBasicData();
                            _oDSPettyCashExpenseHead = new CJ.Class.POS.DSBasicData();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPettyCashExpenseHead = oSerivce.DownloadPettyCashExpenseHead(oDSPettyCashExpenseHead, nWHID);

                            _oDSPettyCashExpenseHead.Merge(oDSPettyCashExpenseHead);
                            _oDSPettyCashExpenseHead.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPettyCashExpenseHead.PettyCashExpenseHead.Count > 0)
                                oDataTransfer.InsertPettyCashExpenseHead(_oDSPettyCashExpenseHead);

                            oSerivce = new Service();
                            if (oDSPettyCashExpenseHead.PettyCashExpenseHead.Count > 0)
                                oSerivce.UpdatePettyCashExpenseHead(oDSPettyCashExpenseHead, nWHID);


                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPettyCashExpenseHead.PettyCashExpenseHead.Count;
                            if (oDSPettyCashExpenseHead.PettyCashExpenseHead.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Petty Cash ExpenseHead Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Petty Cash Expense Head Data/" + ex.Message);
                            MessageBox.Show("Please Cheak Petty Cash Expense Head Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Petty Cash Expense
                    else if (oDataTran.TableName == "t_PettyCashExpense")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PettyCashExpense";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_PettyCashExpenseDetail";
                            lblTableName.Refresh();
                            oDSPettyCashExpense = new DSPettyCash();
                            _oDSPettyCashExpense = new CJ.Class.POS.DSPettyCash();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();
                            oDSPettyCashExpense = oSerivce.DownloadPettyCashExpense(oDSPettyCashExpense, nWHID);
                            _oDSPettyCashExpense.Merge(oDSPettyCashExpense);
                            _oDSPettyCashExpense.AcceptChanges();
                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPettyCashExpense.PettyCashExpense.Count > 0)
                            {
                                oDataTransfer.InsertPettyCashExpence(_oDSPettyCashExpense, nWHID);
                            }
                            // CJ.Class.DBController.Instance.CommitTransaction();
                            oSerivce = new Service();
                            if (oDSPettyCashExpense.PettyCashExpense.Count > 0)
                            {
                                //CJ.Class.DBController.Instance.BeginNewTransaction();
                                oSerivce.UpdatePettyCashExpenseData(oDSPettyCashExpense, nWHID);
                                //CJ.Class.DBController.Instance.CommitTransaction();
                            }
                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPettyCashExpense.PettyCashExpense.Count;
                            if (oDSPettyCashExpense.PettyCashExpense.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Download Petty Cash Expense Data");
                            }

                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Petty Cash Expense Data/" + ex.Message);
                            MessageBox.Show("Please Cheak Petty Cash Expense Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Customer Credit Limit
                    else if (oDataTran.TableName == "t_CustomerCreditLimit")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_CustomerCreditLimit";
                            lblTableName.Refresh();

                            oDSCustomerCreditLimit = new DSCustomer();
                            _oDSCustomerCreditLimit = new CJ.Class.POS.DSCustomer();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSCustomerCreditLimit = oSerivce.DownloadCustomerCreditLimit(oDSCustomerCreditLimit, nWHID);


                            _oDSCustomerCreditLimit.Merge(oDSCustomerCreditLimit);
                            _oDSCustomerCreditLimit.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataTransfer.InsertCustomerCreditLimit(_oDSCustomerCreditLimit);


                            oSerivce = new Service();
                            if (oDSCustomerCreditLimit.CustomerCreditLimit.Count > 0)
                                oSerivce.UpdateCustomerCreditLimitInfo(oDSCustomerCreditLimit, nWHID);

                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSCustomerCreditLimit.CustomerCreditLimit.Count;
                            if (oDSCustomerCreditLimit.CustomerCreditLimit.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Customer Credit Limit");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Customer Credit Limit /" + ex.Message);
                            MessageBox.Show("Please Cheak Customer Credit Limit Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region DMS Secondary Sales Order
                    else if (oDataTran.TableName == "t_DMSSecondarySalesOrder")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_DMSSecondarySalesOrder";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_DMSSecondarySalesOrderDetail";
                            lblTableName.Refresh();
                            oDSSalesOrder = new DSSalesOrder();
                            _oDSSalesOrder = new CJ.Class.POS.DSSalesOrder();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();
                            oDSSalesOrder = oSerivce.DownloadDMSSalesOrder(oDSSalesOrder, nWHID);
                            _oDSSalesOrder.Merge(oDSSalesOrder);
                            _oDSSalesOrder.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSSalesOrder.DMSSecondarySalesOrder.Count > 0)
                            {
                                oDataTransfer.InsertDMSSalesOrder(_oDSSalesOrder, nWHID);
                            }
                            oSerivce = new Service();
                            if (oDSSalesOrder.DMSSecondarySalesOrder.Count > 0)
                            {
                                oSerivce.UpdateDMSSalesOrderData(oDSSalesOrder, nWHID);
                            }
                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSSalesOrder.DMSSecondarySalesOrder.Count;
                            if (oDSSalesOrder.DMSSecondarySalesOrder.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Download DMS Sales Order Data");
                            }

                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting DMS Sales Order Data/" + ex.Message);
                            MessageBox.Show("Please Cheak DMS Sales Order Data Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Customer Tran & Invoice Wise Payment
                    else if (oDataTran.TableName == "t_CustomerTran")
                    {

                        try
                        {
                            lblTableName.Text = txt + "t_CustomerTran";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_InvoiceWisePayment";
                            lblTableName.Refresh();

                            pbDownload.Visible = true;
                            pbDownload.Minimum = 0;
                            pbDownload.Maximum = 3;
                            pbDownload.Step = 1;
                            pbDownload.Value = 0;

                            oDSCustomerTransaction = new DSCustomerTransaction();
                            _oDSCustomerTransaction = new CJ.Class.POS.DSCustomerTransaction();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();

                            oDSCustomerTransaction = oSerivce.DownloadCustTranWithInvoWisePayment(oDSCustomerTransaction, nWHID);

                            pbDownload.PerformStep();

                            _oDSCustomerTransaction.Merge(oDSCustomerTransaction);
                            _oDSCustomerTransaction.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSCustomerTransaction.CustomerTran.Count > 0)
                            {
                                oDataTransfer.InsertCustomerTran(_oDSCustomerTransaction, nWHID);
                            }
                            pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSCustomerTransaction.CustomerTran.Count > 0)
                                oSerivce.UpdateCustomerTransactionInfo(oDSCustomerTransaction, nWHID);
                            pbDownload.PerformStep();

                            CJ.Class.DBController.Instance.CommitTransaction();

                            //pgbInsert.PerformStep();
                            AppLogger.LogInfo("Successfully Inserted Customer Tran & Invoice Wise Payment");
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting Customer Tran & Invoice Wise Payment /" + ex.Message);
                            MessageBox.Show("Please Cheak Customer Tran & Invoice Wise Payment Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #endregion

                    #region Extended Warranty Item
                    else if (oDataTran.TableName == "t_ExtendedWarrantyItem")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_ExtendedWarrantyItem";
                            lblTableName.Refresh();

                            oDSExtendedWarratyItem = new DSFinishedGoodsPrice();
                            _oDSExtendedWarratyItem = new CJ.Class.POS.DSFinishedGoodsPrice();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSExtendedWarratyItem = oSerivce.DownloadExtendedWarrantyItem(oDSExtendedWarratyItem, nWHID);
                            //pbDownload.PerformStep();

                            _oDSExtendedWarratyItem.Merge(oDSExtendedWarratyItem);
                            _oDSExtendedWarratyItem.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataTransfer.InsertExtendedWarrantyItem(_oDSExtendedWarratyItem);
                            //pbDownload.PerformStep();

                            oSerivce = new Service();
                            if (oDSExtendedWarratyItem.Price.Count > 0)
                                oSerivce.UpdateExtendedWarrantyItemInfo(oDSExtendedWarratyItem, nWHID);
                            //pbDownload.PerformStep();
                            CJ.Class.DBController.Instance.CommitTransaction();
                            //pgbInsert.PerformStep();
                            nCount = nCount + oDSExtendedWarratyItem.Price.Count;
                            if (oDSExtendedWarratyItem.Price.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Extended Warranty Item");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Extended Warranty Item /" + ex.Message);
                            MessageBox.Show("Please Cheak Extended Warranty Item\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Day Plan Purpose
                    else if (oDataTran.TableName == "t_DayPlanPurpose")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_DayPlanPurpose";
                            lblTableName.Refresh();

                            oDSDayPlan = new DSDayPlan();
                            _oDSDayPlan = new CJ.Class.POS.DSDayPlan();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSDayPlan = oSerivce.DownloadDayPlanPurpose(oDSDayPlan, nWHID);
                            _oDSDayPlan.Merge(oDSDayPlan);
                            _oDSDayPlan.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataTransfer.InsertDayPlanPurpose(_oDSDayPlan);

                            oSerivce = new Service();
                            if (oDSDayPlan.DayPlanPurpose.Count > 0)
                                oSerivce.UpdateDayPlanPurposeInfo(oDSDayPlan, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSDayPlan.DayPlanPurpose.Count;
                            if (oDSDayPlan.DayPlanPurpose.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded Day Plan Purpose");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Day Plan Purpose /" + ex.Message);
                            MessageBox.Show("Please Cheak Day Plan Purpose\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Visit Plan Type
                    else if (oDataTran.TableName == "t_VisitPlanType")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_VisitPlanType";
                            lblTableName.Refresh();

                            oDSDayPlan = new DSDayPlan();
                            _oDSDayPlan = new CJ.Class.POS.DSDayPlan();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSDayPlan = oSerivce.DownloadVisitPlanType(oDSDayPlan, nWHID);
                            _oDSDayPlan.Merge(oDSDayPlan);
                            _oDSDayPlan.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataTransfer.InsertVisitPlanType(_oDSDayPlan);

                            oSerivce = new Service();
                            if (oDSDayPlan.VisitPlanType.Count > 0)
                            oSerivce.UpdateVisitPlanTypeInfo(oDSDayPlan, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();
                           

                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading Visit Plan Type /" + ex.Message);
                            MessageBox.Show("Please Cheak Visit Plan Type\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion
                    #region Scratch Card Discount
                    else if (oDataTran.TableName == "t_ScratchCardOffer")
                    {
                        try
                        {
                                lblTableName.Text = txt + "t_ScratchCardOffer";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_ScratchCardOfferProductFor";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_ScratchCardOfferWarehouse";
                                lblTableName.Refresh();
                                lblTableName.Text = txt + "t_ScratchCardOfferSalesType";
                                lblTableName.Refresh();
                            
                            

                            _oDSPromotion = new CJ.Class.POS.DSPromotion();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSPromotion = oSerivce.DownloadScratchCardOffer(oDSPromotion, nWHID, oDataTran.TableName);
                            _oDSPromotion.Merge(oDSPromotion);
                            _oDSPromotion.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSPromotion.Promo.Count > 0)
                                oDataTransfer.InsertScratchCardOffer(_oDSPromotion, oDataTran.TableName, nWHID);

                            oSerivce = new Service();
                            if (oDSPromotion.Promo.Count > 0)
                                oSerivce.UpdateSalesPromoTransferInfoNew(oDSPromotion, nWHID, oDataTran.TableName);

                            CJ.Class.DBController.Instance.CommitTransaction();

                            nCount = nCount + oDSPromotion.Promo.Count;
                            if (oDSPromotion.Promo.Count > 0)
                            {
                                if (oDataTran.TableName == "t_ScratchCardOffer")
                                {
                                    AppLogger.LogInfo("Successfully Inserted Scratch Card Offer");
                                }
                                
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            if (oDataTran.TableName == "t_ScratchCardOffer")
                            {
                                CJ.Class.DBController.Instance.RollbackTransaction();
                                AppLogger.LogError("Error Inserting Scratch Card Offer/" + ex.Message);
                                MessageBox.Show("Please Cheak Scratch Card Offer Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;

                            }
                          

                        }
                    }

                    #endregion

                    //========
                    #region Promo Exchange Offers Zahid
                    else if (oDataTran.TableName == "t_PromoExchangeOffers")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_PromoExchangeOffers";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_PromoExchangeOfferDetails";
                            lblTableName.Refresh();
                            oDSPromoExchgangeOffer = new DSPromoExchgangeOffer();
                            _oDSPromoExchgangeOffer = new CJ.Class.Promotion.DSPromoExchangeOffer();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();
                            oDSPromoExchgangeOffer = oSerivce.DownloadPromoExchgangeOffer(oDSPromoExchgangeOffer, nWHID);
                            _oDSPromoExchgangeOffer.Merge(oDSPromoExchgangeOffer);
                            _oDSPromoExchgangeOffer.AcceptChanges();
                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSPromoExchgangeOffer.PromoExchangeOffer.Count > 0)
                            {
                                oDataTransfer.InsertPromoExchnageOffers(_oDSPromoExchgangeOffer, nWHID);
                            }
                                oSerivce = new Service();
                            if (oDSPromoExchgangeOffer.PromoExchangeOffer.Count > 0)
                            {
                                oSerivce.UpdatePromoExchangeOfferData(oDSPromoExchgangeOffer, nWHID);
                            }
                            
                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPromoExchgangeOffer.PromoExchangeOffer.Count;
                            if (oDSPromoExchgangeOffer.PromoExchangeOffer.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Download Exchange Offer Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting  Exchange Offer Data/" + ex.Message);
                            MessageBox.Show("Please Cheak  Exchange Offer \nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion

                    #region Promo Warranty Zahid
                    else if (oDataTran.TableName == "t_PromoWarranty")
                    {
                        try
                        {
                            //= serch this to find where to change to finisha this function
                            lblTableName.Text = txt + "t_PromoWarranty";
                            lblTableName.Refresh();
                            lblTableName.Text = txt + "t_PromoWarrantyDetail";
                            lblTableName.Refresh();
                            oDSPromoWarranty = new DSPromoWarranty();
                            _oDSPromoWarranty = new Class.Promotion.DSPromoWarranty();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oSerivce = new Service();
                            oDSPromoWarranty = oSerivce.DownloadPromoWarranty(oDSPromoWarranty, nWHID);
                            _oDSPromoWarranty.Merge(oDSPromoWarranty);
                            _oDSPromoWarranty.AcceptChanges();
                            CJ.Class.DBController.Instance.BeginNewTransaction();

                            if (_oDSPromoWarranty.PromoWarranty.Count > 0)
                            {
                                oDataTransfer.InsertPromoWarranty(_oDSPromoWarranty, nWHID);
                            }
                            oSerivce = new Service();
                            if (oDSPromoWarranty.PromoWarranty.Count > 0)
                            {
                                oSerivce.UpdatePromoWarranty(oDSPromoWarranty, nWHID);
                            }

                            CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSPromoWarranty.PromoWarranty.Count;
                            if (oDSPromoWarranty.PromoWarranty.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Download Exchange Offer Data");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Inserting  Exchange Offer Data/" + ex.Message);
                            MessageBox.Show("Please Cheak  Exchange Offer \nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    #endregion
                    //========


                }
            }
            lblTableName.Visible = false;
            return true;
        }
        public bool DataDownload(int nWHID, int nCustomerID)
        {

            oSerivce = new Service();

            //pgbInsert.Visible = true;
            //pgbInsert.Minimum = 0;
            //pgbInsert.Maximum = 19;
            //pgbInsert.Step = 1;
            //pgbInsert.Value = 0;

            lblTableName.Visible = true;
            string txt = "Download Data from: ";
            lblTableName.Text = txt;
            lblTableName.Refresh();

            #region Geo location

            try
            {

                lblTableName.Visible = true;
                lblTableName.Text = txt + "t_GeoLocation";
                lblTableName.Refresh();
                
                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 2;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSGeoLocation = new CJ.Class.POS.DSGeoLocation();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oDSGeoLocation = oSerivce.DownloadGeoLocation(oDSGeoLocation);
                pbDownload.PerformStep();

                _oDSGeoLocation.Merge(oDSGeoLocation);
                _oDSGeoLocation.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oDataTransfer.InsertGeoLocation(_oDSGeoLocation);
                pbDownload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Geo Location");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Geo Location /" + ex.Message);
                MessageBox.Show("Please Cheak Geo Location Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region SBU

            try
            {
                lblTableName.Text = txt + "t_SBU";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 2;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSSBU = new CJ.Class.POS.DSSBU();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oDSSBU = oSerivce.DownloadSBU(oDSSBU);
                pbDownload.PerformStep();

                _oDSSBU.Merge(oDSSBU);
                _oDSSBU.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oDataTransfer.InsertSBU(_oDSSBU);
                pbDownload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted SBU");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting SBU /" + ex.Message);
                MessageBox.Show("Please Cheak SBU Segment", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Channel

            try
            {
                lblTableName.Text = txt + "t_Channel";
                lblTableName.Refresh();


                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 2;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSChannel = new CJ.Class.POS.DSChannel();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oDSChannel = oSerivce.DownloadChannel(oDSChannel);
                pbDownload.PerformStep();

                _oDSChannel.Merge(oDSChannel);
                _oDSChannel.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oDataTransfer.InsertChannel(_oDSChannel);
                pbDownload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Channel");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Channel /" + ex.Message);
                MessageBox.Show("Please Cheak Channel Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Customer Type

            try
            {

                lblTableName.Text = txt + "t_CustomerType";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 2;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSCustomerType = new CJ.Class.POS.DSCustomerType();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oDSCustomerType = oSerivce.DownloadCustomerType(oDSCustomerType, nWHID);
                pbDownload.PerformStep();

                _oDSCustomerType.Merge(oDSCustomerType);
                _oDSCustomerType.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oDataTransfer.InsertCustomerType(_oDSCustomerType);
                pbDownload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Customer Type");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Customer Type /" + ex.Message);
                MessageBox.Show("Please Cheak Customer Type Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Market Group

            try
            {
                lblTableName.Text = txt + "t_MarketGroup";
                lblTableName.Refresh();


                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 2;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSMarketGroup = new CJ.Class.POS.DSMarketGroup();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oDSMarketGroup = oSerivce.DownloadMarketGroup(oDSMarketGroup);
                pbDownload.PerformStep();

                _oDSMarketGroup.Merge(oDSMarketGroup);
                _oDSMarketGroup.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oDataTransfer.InsertMarketGroup(_oDSMarketGroup);
                pbDownload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Market Group");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Market Group /" + ex.Message);
                MessageBox.Show("Please Cheak Market Group Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            #endregion

            #region Customer

            try
            {
                lblTableName.Text = txt + "t_Customer";
                lblTableName.Refresh();


                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 2;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSCustomer = new CJ.Class.POS.DSCustomer();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                CJ.Class.DBController.Instance.OpenNewConnection();
                oSystemInfo = new CJ.Class.POS.SystemInfo();
                oSystemInfo.Refresh();
                CJ.Class.DBController.Instance.CloseConnection();
                oDSCustomer = oSerivce.DownloadCustomer(oDSCustomer, nCustomerID);
                pbDownload.PerformStep();

                _oDSCustomer.Merge(oDSCustomer);
                _oDSCustomer.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oDataTransfer.InsertCustomer(_oDSCustomer);
                pbDownload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Customer");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Customer /" + ex.Message);
                MessageBox.Show("Please Cheak Customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            #endregion

            #region Basic Data

            try
            {
                #region lebel
                lblTableName.Text = txt + "t_Bank";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_BankBranch";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_company";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_CustomerCreditLimit";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_InvoiceType";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_customerTranType";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_CustomerTypeWisePriceSetting";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_CustomerAccount";
                lblTableName.Refresh();

                #endregion

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 2;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSBasicData = new CJ.Class.POS.DSBasicData();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                CJ.Class.DBController.Instance.OpenNewConnection();
                oSystemInfo = new CJ.Class.POS.SystemInfo();
                oSystemInfo.Refresh();
                CJ.Class.DBController.Instance.CloseConnection();
                oDSBasicData = oSerivce.DownloadBasicData(oDSBasicData, nCustomerID);
                pbDownload.PerformStep();

                _oDSBasicData.Merge(oDSBasicData);
                _oDSBasicData.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oDataTransfer.InsertBasicData(_oDSBasicData);
                pbDownload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Basic Data");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Basic Data /" + ex.Message);
                MessageBox.Show("Please Cheak Basic Data Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            #endregion

            #region Product Group & Brand

            try
            {
                lblTableName.Text = txt + "t_ProductGroup";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_Brand";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 3;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSProductGroups = new CJ.Class.POS.DSProductGroups();
                _oDSBrand = new CJ.Class.POS.DSBrand();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oDSProductGroups = oSerivce.DownloadProductGroup(oDSProductGroups, nWHID);
                oDSBrand = oSerivce.DownloadProductBrand(oDSBrand, nWHID);
                pbDownload.PerformStep();

                _oDSProductGroups.Merge(oDSProductGroups);
                _oDSProductGroups.AcceptChanges();

                _oDSBrand.Merge(oDSBrand);
                _oDSBrand.AcceptChanges();
             
                CJ.Class.DBController.Instance.BeginNewTransaction();
                if (_oDSProductGroups.PGGroup.Count > 0)
                    oDataTransfer.InsertProductGroup(_oDSProductGroups);
                if (_oDSBrand.Brand.Count > 0)
                    oDataTransfer.InsertProductBrand(_oDSBrand);

                pbDownload.PerformStep();

                oSerivce = new Service();
                if (oDSProductGroups.PGGroup.Count > 0)
                    oSerivce.UpdateProductGroupTransferInfo(oDSProductGroups, nWHID);
                if (oDSBrand.Brand.Count > 0)
                    oSerivce.UpdateProductBrandTransferInfo(oDSBrand, nWHID);
                pbDownload.PerformStep();

                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Product Group & Brand");
            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Product Group & Brand /" + ex.Message);
                MessageBox.Show("Please Cheak Product Group segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region product
            try
            {
                lblTableName.Text = txt + "t_Product";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 3;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                oDSProduct = new DSProduct();
                _oDSProduct = new CJ.Class.POS.DSProduct();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                //oDSProduct = oSerivce.DownloadProduct(oDSProduct, int.Parse(cmbFromWarehouse.SelectedValue.ToString()));
                oDSProduct = oSerivce.DownloadProduct(oDSProduct, nWHID);
                pbDownload.PerformStep();

                _oDSProduct.Merge(oDSProduct);
                _oDSProduct.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                if (_oDSProduct.Product.Count > 0)
                    if (Utility.CompanyInfo == "TML")
                    {
                        oDataTransfer.InsertProductTML(_oDSProduct); 
                    }
                    else
                    {
                        oDataTransfer.InsertProduct(_oDSProduct); 
                    }
                                  
                pbDownload.PerformStep();

                oSerivce = new Service();
                if (oDSProduct.Product.Count > 0)
                    //oSerivce.UpdateProductTransferInfo(oDSProduct, int.Parse(cmbFromWarehouse.SelectedValue.ToString()));
                    oSerivce.UpdateProductTransferInfo(oDSProduct, nWHID);
                pbDownload.PerformStep();

                CJ.Class.DBController.Instance.CommitTransaction();
                //pgbInsert.PerformStep();

                AppLogger.LogInfo("Successfully Inserted Product");
            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Product /" + ex.Message);
                MessageBox.Show("Please Cheak Product Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region product Price
            try
            {
                lblTableName.Text = txt + "t_FinishedGoodsPrice";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 3;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                oDSFinishedGoodsPrice = new DSFinishedGoodsPrice();
                _oDSFinishedGoodsPrice = new CJ.Class.POS.DSFinishedGoodsPrice();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oDSFinishedGoodsPrice = oSerivce.DownloadProductPrice(oDSFinishedGoodsPrice, nWHID);
                pbDownload.PerformStep();

                _oDSFinishedGoodsPrice.Merge(oDSFinishedGoodsPrice);
                _oDSFinishedGoodsPrice.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                if (_oDSFinishedGoodsPrice.Price.Count > 0)
                    if (Utility.CompanyInfo == "TML")
                    {
                        oDataTransfer.InsertProductPriceTML(_oDSFinishedGoodsPrice);
                    }
                    else
                    {
                        oDataTransfer.InsertProductPrice(_oDSFinishedGoodsPrice);
                    }
                   
                pbDownload.PerformStep();

                oSerivce = new Service();
                if (oDSFinishedGoodsPrice.Price.Count > 0)
                    oSerivce.UpdateProductPriceTransferInfo(oDSFinishedGoodsPrice, nWHID);
                pbDownload.PerformStep();

                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Product Price");
            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Product Price /" + ex.Message);
                MessageBox.Show("Please Cheak Product Price Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Warehouse

            try
            {
                lblTableName.Text = txt + "t_Warehouse";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 3;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSWarehouse = new CJ.Class.POS.DSWarehouse();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oDSWarehouse = oSerivce.DownloadWarehouse(oDSWarehouse, nWHID);
                pbDownload.PerformStep();

                _oDSWarehouse.Merge(oDSWarehouse);
                _oDSWarehouse.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                if (_oDSWarehouse.Warehouse.Count > 0)
                    oDataTransfer.InsertWarehouse(_oDSWarehouse);            
                pbDownload.PerformStep();

                oSerivce = new Service();
                if (oDSWarehouse.Warehouse.Count > 0)
                    oSerivce.UpdateWarehouseTransferInfo(oDSWarehouse, nWHID);
                pbDownload.PerformStep();

                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Warehouse");

            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Warehouse /" + ex.Message);
                MessageBox.Show("Please Cheak Warehouse Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion
            
            #region Employee
            if (Utility.CompanyInfo == "TEL")
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 3;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSEmployee = new CJ.Class.POS.DSEmployee();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oDSEmployee = oSerivce.DownloadEmployee(oDSEmployee, nWHID);
                    pbDownload.PerformStep();

                    _oDSEmployee.Merge(oDSEmployee);
                    _oDSEmployee.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();
                    if (_oDSEmployee.Employee.Count > 0)
                        oDataTransfer.InsertEmployee(_oDSEmployee);
                    pbDownload.PerformStep();

                    oSerivce = new Service();
                    if (oDSEmployee.Employee.Count > 0)
                        oSerivce.UpdateEmployeeTransferInfo(oDSEmployee, nWHID);
                    pbDownload.PerformStep();

                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();
                    AppLogger.LogInfo("Successfully Inserted Employee");

                }
                catch (Exception ex)
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting Employee /" + ex.Message);
                    MessageBox.Show("Please Cheak Employee Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion

            #region User

            try
            {
                lblTableName.Text = txt + "t_User";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 3;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSUser = new CJ.Class.POS.DSUser();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oSerivce = new Service();
                oDSUser = oSerivce.DownloadUser(oDSUser, nWHID);
                pbDownload.PerformStep();

                _oDSUser.Merge(oDSUser);
                _oDSUser.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                if (_oDSUser.User.Count > 0)
                    oDataTransfer.InsertUser(_oDSUser);
                pbDownload.PerformStep();

                oSerivce = new Service();
                if (oDSUser.User.Count > 0)
                    oSerivce.UpdateUserTransferInfo(oDSUser, nWHID);
                pbDownload.PerformStep();

                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted User");
            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting User /" + ex.Message);
                MessageBox.Show("Please Cheak User Segment", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Promotion
            if (Utility.CompanyInfo == "TEL")
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 3;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSPromotion = new CJ.Class.POS.DSPromotion();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oDSPromotion = oSerivce.DownloadPromotion(oDSPromotion, nWHID);
                    pbDownload.PerformStep();

                    _oDSPromotion.Merge(oDSPromotion);
                    _oDSPromotion.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();
                    if (_oDSPromotion.SalesPromotion.Count > 0)
                        oDataTransfer.InsertPromotio(_oDSPromotion);
                    pbDownload.PerformStep();

                    oSerivce = new Service();
                    if (oDSPromotion.SalesPromotion.Count > 0)
                        oSerivce.UpdatePromotionTransferInfo(oDSPromotion, nWHID);
                    pbDownload.PerformStep();

                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();
                    AppLogger.LogInfo("Successfully Inserted Product Promotion");
                }
                catch (Exception ex)
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting Product Promotion /" + ex.Message);
                    MessageBox.Show("Please Cheak Promotion Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 3;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSPromotion = new CJ.Class.POS.DSPromotion();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oDSPromotion = oSerivce.DownloadPromotionOtherThenTD(oDSPromotion, nWHID);
                    pbDownload.PerformStep();

                    _oDSPromotion.Merge(oDSPromotion);
                    _oDSPromotion.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();
                    if (_oDSPromotion.SalesPromotion.Count > 0)
                        oDataTransfer.InsertPromotioOhterThenTD(_oDSPromotion);
                    pbDownload.PerformStep();

                    oSerivce = new Service();
                    if (oDSPromotion.SalesPromotion.Count > 0)
                        oSerivce.UpdatePromotionTransferInfo(oDSPromotion, nWHID);
                    pbDownload.PerformStep();

                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();
                    AppLogger.LogInfo("Successfully Inserted Product Promotion");
                }
                catch (Exception ex)
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting Product Promotion /" + ex.Message);
                    MessageBox.Show("Please Cheak Promotion Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion
            
            #region Barcode/IMEI
            
            if (Utility.CompanyInfo == "TEL")
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 3;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSBarcode = new CJ.Class.POS.DSBarcode();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oDSBarcode = oSerivce.DownloadBarcode(oDSBarcode, nWHID);
                    //oDSBarcode = oSerivce.DownloadBarcode(oDSBarcode, 39);
                    pbDownload.PerformStep();

                    _oDSBarcode.Merge(oDSBarcode);
                    _oDSBarcode.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();
                    if (_oDSBarcode.Barcode.Count > 0)
                        oDataTransfer.InsertBarcode(_oDSBarcode);
                    pbDownload.PerformStep();

                    oSerivce = new Service();
                    if (oDSBarcode.Barcode.Count > 0)
                        oSerivce.UpdateBarcodeTransferInfo(oDSBarcode, nWHID);
                    //oSerivce.UpdateBarcodeTransferInfo(oDSBarcode, 39);
                    pbDownload.PerformStep();

                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();
                    AppLogger.LogInfo("Successfully Inserted Product Promotion");

                }
                catch (Exception ex)
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting Product Promotion /" + ex.Message);
                    MessageBox.Show("Please Cheak Barcode Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion 
           
            #region Warranty
            
            if (Utility.CompanyInfo == "TEL")
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 3;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSWarranty = new CJ.Class.POS.DSWarranty();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oDSWarranty = oSerivce.DownloadWarranty(oDSWarranty, nWHID);
                    pbDownload.PerformStep();

                    _oDSWarranty.Merge(oDSWarranty);
                    _oDSWarranty.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();
                    if (_oDSWarranty.WarrantyCategory.Count > 0)
                        oDataTransfer.InsertWarranty(_oDSWarranty);
                    pbDownload.PerformStep();

                    oSerivce = new Service();
                    if (oDSWarranty.WarrantyCategory.Count > 0)
                        oSerivce.UpdateWarrantyTransferInfo(oDSWarranty, nWHID);
                    pbDownload.PerformStep();

                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();

                }
                catch
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Please Cheak Warranty Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion

            #region Consumer
            if (Utility.CompanyInfo == "TEL")
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 3;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSRetailConsumer = new CJ.Class.POS.DSRetailConsumer();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oDSRetailConsumer = oSerivce.DownloadRetailConsumer(oDSRetailConsumer, nWHID);
                    pbDownload.PerformStep();

                    _oDSRetailConsumer.Merge(oDSRetailConsumer);
                    _oDSRetailConsumer.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();
                    if (_oDSRetailConsumer.RetailConsumer.Count > 0)
                        oDataTransfer.InsertConsumer(_oDSRetailConsumer, nCustomerID);
                    pbDownload.PerformStep();

                    oSerivce = new Service();
                    if (oDSRetailConsumer.RetailConsumer.Count > 0)
                        oSerivce.UpdateConsumerTransferInfo(oDSRetailConsumer, nWHID);
                    pbDownload.PerformStep();

                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();

                }
                catch
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Please Cheak Customer Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion         

            #region CLP
            if (Utility.CompanyInfo == "TEL")
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 2;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSCLP = new CJ.Class.POS.DSCLP();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oSerivce = new Service();
                    oDSCLP = oSerivce.DownloadCLP(oDSCLP, nWHID);
                    pbDownload.PerformStep();

                    _oDSCLP.Merge(oDSCLP);
                    _oDSCLP.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();
                    oDataTransfer.InsertCLP(_oDSCLP);
                    pbDownload.PerformStep();

                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();
                }
                catch
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Please Cheak CLP Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
             
            #endregion

            #region Product Stock Tran Type
            if (Utility.CompanyInfo == "TML")
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 3;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSProductTransactionType = new CJ.Class.POS.DSProductTransactionType();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oSerivce = new Service();
                    oDSProductTransactionType = oSerivce.DownloadProductTranType(oDSProductTransactionType, nWHID);
                    pbDownload.PerformStep();

                    _oDSProductTransactionType.Merge(oDSProductTransactionType);
                    _oDSProductTransactionType.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();

                    if (_oDSProductTransactionType.ProductStockTranType.Count > 0)
                        oDataTransfer.InsertProductTranType(_oDSProductTransactionType);

                    pbDownload.PerformStep();

                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();
                    AppLogger.LogInfo("Successfully Inserted Product Stock Tran Type");
                }
                catch(Exception ex)
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting Product Stock Tran Type /" + ex.Message);
                    MessageBox.Show("Please Cheak Product Tran Type Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion
           
            #region Product Tran

            try
            {
                lblTableName.Text = txt + "t_ProductStockTran";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_ProductStockTranItem";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_ProductTransferProductSerial";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 3;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                _oDSProductTransaction = new CJ.Class.POS.DSProductTransaction();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oSerivce = new Service();
                if(Utility.CompanyInfo=="TML")
                {
                    oDSProductTransaction = oSerivce.DownloadProductTranWithIMEI(oDSProductTransaction, nWHID);
                }
                else
                {
                    oDSProductTransaction = oSerivce.DownloadProductTran(oDSProductTransaction, nWHID);
                }
                pbDownload.PerformStep();

                _oDSProductTransaction.Merge(oDSProductTransaction);
                _oDSProductTransaction.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();

                if (_oDSProductTransaction.ProductStockTran.Count > 0)
                    if (Utility.CompanyInfo == "TML")
                    {
                        oDataTransfer.InsertProductStockTranWithIMEI(_oDSProductTransaction);
                    }
                    else
                    {
                        oDataTransfer.InsertProductStockTran(_oDSProductTransaction); 
                    }
                       
            
                pbDownload.PerformStep();

                oSerivce = new Service();
                if (oDSProductTransaction.ProductStockTran.Count > 0)
                    oSerivce.UpdateProductTranTransferInfo(oDSProductTransaction, nWHID);
                pbDownload.PerformStep();

                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Product Tran");
            }
            catch(Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Product Tran /" + ex.Message);
                MessageBox.Show("Please Cheak Product Tran Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }           
            #endregion
            
            #region Product Stock
            if (Utility.CompanyInfo == "TEL")
            {
                try
                {
                    pbDownload.Visible = true;
                    pbDownload.Minimum = 0;
                    pbDownload.Maximum = 2;
                    pbDownload.Step = 1;
                    pbDownload.Value = 0;

                    _oDSStock = new CJ.Class.POS.DSStock();
                    oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                    oDSStock = oSerivce.DownloadProductStock(oDSStock);
                    pbDownload.PerformStep();

                    _oDSStock.Merge(oDSStock);
                    _oDSStock.AcceptChanges();

                    CJ.Class.DBController.Instance.BeginNewTransaction();
                    oDataTransfer.InsertProductStock(_oDSStock);
                    pbDownload.PerformStep();
                    CJ.Class.DBController.Instance.CommitTransaction();

                    //pgbInsert.PerformStep();
                    AppLogger.LogInfo("Successfully Inserted Product Stock");

                }
                catch (Exception ex)
                {
                    CJ.Class.DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting Product Stock /" + ex.Message);
                    MessageBox.Show("Please Cheak Product Stock Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            
            #endregion
             
            #region Customer Tran & Invoice Wise Payment
            
            try
            {
                lblTableName.Text = txt + "t_CustomerTran";
                lblTableName.Refresh();
                lblTableName.Text = txt + "t_InvoiceWisePayment";
                lblTableName.Refresh();

                pbDownload.Visible = true;
                pbDownload.Minimum = 0;
                pbDownload.Maximum = 3;
                pbDownload.Step = 1;
                pbDownload.Value = 0;

                oDSCustomerTransaction = new DSCustomerTransaction();
                _oDSCustomerTransaction = new CJ.Class.POS.DSCustomerTransaction();
                oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                oSerivce = new Service();

                oDSCustomerTransaction = oSerivce.DownloadCustTranWithInvoWisePayment(oDSCustomerTransaction, nWHID);

                pbDownload.PerformStep();

                _oDSCustomerTransaction.Merge(oDSCustomerTransaction);
                _oDSCustomerTransaction.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();

                if (_oDSCustomerTransaction.CustomerTran.Count > 0)
                {
                    oDataTransfer.InsertCustomerTran(_oDSCustomerTransaction, nWHID);
                }
                pbDownload.PerformStep();

                oSerivce = new Service();
                if (oDSCustomerTransaction.CustomerTran.Count > 0)
                    oSerivce.UpdateCustomerTransactionInfo(oDSCustomerTransaction, nWHID);
                pbDownload.PerformStep();

                CJ.Class.DBController.Instance.CommitTransaction();

                //pgbInsert.PerformStep();
                AppLogger.LogInfo("Successfully Inserted Customer Tran & Invoice Wise Payment");
            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Inserting Customer Tran & Invoice Wise Payment /" + ex.Message);
                MessageBox.Show("Please Cheak Customer Tran & Invoice Wise Payment Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
             
            #endregion

            lblTableName.Visible = false;
            return true;
        }
    }
}