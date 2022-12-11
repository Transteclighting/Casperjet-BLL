using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.POS.TELWEBSERVER;
using CJ.Class;


namespace CJ.POS
{
    public partial class frmDataSend : Form
    {
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
        DSPettyCash oDSPettyCash;
        DSSalesOrder oDSSalesOrder;
        DSExtendedWarranty oDSExtendedWarranty;
        DSDayPlan oDSDayPlan;


        CJ.Class.DataTransfer.DataTransfer oDataTransfer;
        CJ.Class.DataTransfer.DataSend oDataSend;
        CJ.Class.POS.SystemInfo oSystemInfo;
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
        CJ.Class.POS.DSPettyCash _oDSPettyCash;

        CJ.Class.POS.DSSalesOrder _oDSSalesOrder;
        CJ.Class.POS.DSExtendedWarranty _oDSExtendedWarranty;
        CJ.Class.POS.DSDayPlan _oDSDayPlan;


        //int nWHID = 0;
        int nChannelID = 0;
        int nCount = 0;
        int nReceivableDataCategory = 0;
        int nReceivableDataType = 0;

        public frmDataSend()
        {
            InitializeComponent();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDataSend_Load(object sender, EventArgs e)
        {
            //Loadcmb();

            oSystemInfo = new CJ.Class.POS.SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            nCount = LoadReceivableData();
            DBController.Instance.CloseConnection();
            //nWHID = oSystemInfo.WarehouseID;
            nChannelID = oSystemInfo.ChannelID;
            lblBranchName.Text = oSystemInfo.WarehouseName;
            if (nCount == 0)
            {
                btSend.Enabled = true;
                lblMsg.Visible = true;
                lblMsg.Text = "There is no Uploadable data\n But you can send System Monitored Data";
                lblMsg.ForeColor = Color.Red;
            }
            else
            {
                btSend.Enabled = true;
                btSend.AutoEllipsis = true;
            }


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
        private void btSend_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int Desc;
            if (Utility.InternetGetConnectedState(out Desc, 0))
            {
                //if (Utility.CheckTELWEBServer())
                {
                    DBController.Instance.OpenNewConnection();
                    LoadReceivableOutletData(oSystemInfo.WarehouseID);

                    bool IsTrue = DataUploadTD(oSystemInfo.WarehouseID, nReceivableDataCategory, nReceivableDataType, true);
                    if (IsTrue)
                    {
                        MessageBox.Show("Data Uploaded Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pbtUpload.Visible = false;
                        this.Close();
                    }
                    DBController.Instance.CloseConnection();
                }
                //else
                {
                    //MessageBox.Show("Server Or Network connectivity not available at this moment!!! \n\nPlease try again later or contact concern person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void LoadReceivableOutletData(int nWHID)
        {
            _oDSReceivableOutletData = new CJ.Class.POS.DSReceivableOutletData();

            oSerivce = new Service();
            oDSReceivableOutletData = new DSReceivableOutletData();

            oDSReceivableOutletData = oSerivce.GetReceivableOutletData(oDSReceivableOutletData, nWHID);

            _oDSReceivableOutletData.Merge(oDSReceivableOutletData);
            _oDSReceivableOutletData.AcceptChanges();

            foreach (CJ.Class.POS.DSReceivableOutletData.DataRow oRow in _oDSReceivableOutletData.Data)
            {
                nReceivableDataCategory = oRow.DataCategory;
                nReceivableDataType = oRow.DataType;

            }

        }
        private int LoadReceivableData()
        {
            _oDataTrans = new CJ.Class.POS.DataTrans();
            _oDataTrans.Refesh(oSystemInfo.WarehouseID);
            nCount = 0;

            if (_oDataTrans.Count > 0)
            {

                lvwItemList.Items.Clear();
                this.Text = "Total  " + "[" + _oDataTrans.Count + "]";
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
        public bool DataUploadTD(int nWHID, int nDataCategory, int nDataType, bool _bFlag)
        {
            nCount = 0;

            _oDataTrans = new CJ.Class.POS.DataTrans();
            nCount = _oDataTrans.RefeshGroupByData(nWHID);
            if(_bFlag)
            { 
                UploadMonitoredData(nWHID, nDataCategory, nDataType, _bFlag);
            }
            if (nCount == 0)
            {
                pbtUpload.Visible = true;
                pbtUpload.Maximum = 1;
                pbtUpload.Value = 0;
                int i = 0;

                i = i + 1;
                pbtUpload.Value = i;
            }

            if (nCount > 0)
            {
                pbtUpload.Visible = true;
                pbtUpload.Maximum = _oDataTrans.Count;
                pbtUpload.Value = 0;
                int i = 0;

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
                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending DayStartEndLog Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem DayStartEndLog  Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Database Backup Log Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Database Backup Log  Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Stock Requisition Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Stock Requisition Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateConsumerTransferInfo(_oDSRetailConsumer, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Retail Consumer Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Retail Consumer Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }
                    }
                    #endregion

                    #region Sales Invoice
                    //else if (oDataTran.TableName == "t_SalesInvoice")
                    //{
                    //    try
                    //    {
                    //        //check Done

                    //        _oDSSalesInvoice = new CJ.Class.POS.DSSalesInvoice();
                    //        oDataSend = new CJ.Class.DataTransfer.DataSend();
                    //        oDSSalesInvoice = new DSSalesInvoice();

                    //        CJ.Class.DBController.Instance.OpenNewConnection();
                    //        ////_oDSSalesInvoice = oDataSend.GetSalesInvoiceTD(_oDSSalesInvoice, nWHID); ----OLD
                    //        _oDSSalesInvoice = oDataSend.GetSalesInvoiceTDNew(_oDSSalesInvoice, nWHID);

                    //        CJ.Class.DBController.Instance.CloseConnection();

                    //        oDSSalesInvoice.Merge(_oDSSalesInvoice);
                    //        oDSSalesInvoice.AcceptChanges();

                    //        oSerivce = new Service();
                    //        ///oDSSalesInvoice = oSerivce.SendSalesInvoiceTD(oDSSalesInvoice, nChannelID);
                    //        oDSSalesInvoice = oSerivce.SendSalesInvoiceTDNewVat(oDSSalesInvoice, nChannelID);
                    //        ///SendSalesInvoiceTDNewVat

                    //        _oDSSalesInvoice = new CJ.Class.POS.DSSalesInvoice();
                    //        _oDSSalesInvoice.Merge(oDSSalesInvoice);
                    //        _oDSSalesInvoice.AcceptChanges();

                    //        CJ.Class.DBController.Instance.BeginNewTransaction();
                    //        oDataSend.UpdateSalesInvoiceSendInfo(_oDSSalesInvoice, nWHID);
                    //        CJ.Class.DBController.Instance.CommitTransaction();

                    //        i = i + 1;
                    //        pbtUpload.Value = i;

                    //    }
                    //    catch (Exception ex)
                    //    {

                    //        CJ.Class.DBController.Instance.RollbackTransaction();
                    //        AppLogger.LogError("Error Sending Invoice Segment /" + ex.Message);
                    //        MessageBox.Show("Problem Invoice Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return false;
                    //    }
                    //}
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

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {

                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Invoice Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Invoice Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }
                    }
                    #endregion

                    #region CLP Tran
                    /*
                    try
                    {
                        pbtDownload.Visible = true;
                        pbtDownload.Minimum = 0;
                        pbtDownload.Maximum = 3;
                        pbtDownload.Step = 1;
                        pbtDownload.Value = 0;

                        _oDSCLP = new CJ.Class.POS.DSCLP();
                        oDataSend = new CJ.Class.DataTransfer.DataSend();
                        oDSCLP = new DSCLP();

                        CJ.Class.DBController.Instance.OpenNewConnection();
                        _oDSCLP = oDataSend.GetCLPTran(_oDSCLP, nWHID);
                        pbtDownload.PerformStep();
                        CJ.Class.DBController.Instance.CloseConnection();

                        oDSCLP.Merge(_oDSCLP);
                        oDSCLP.AcceptChanges();

                        oSerivce = new Service();
                        oDSCLP = oSerivce.SendCLPTran(oDSCLP);
                        pbtDownload.PerformStep();

                        _oDSCLP = new CJ.Class.POS.DSCLP();
                        _oDSCLP.Merge(oDSCLP);
                        _oDSCLP.AcceptChanges();

                        CJ.Class.DBController.Instance.BeginNewTransaction();
                        oDataSend.UpdateCLPTranSendInfo(_oDSCLP, nWHID);
                        pbtDownload.PerformStep();
                        CJ.Class.DBController.Instance.CommitTransaction();

                        pgbInsert.PerformStep();
                    }
                    catch (Exception ex)
                    {
                        CJ.Class.DBController.Instance.RollbackTransaction();
                        AppLogger.LogError("Error Sending CLPTran Segment /" + ex.Message);
                        MessageBox.Show("Problem CLP Tran Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                     */
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
                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Initial Transaction Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Initial Transaction Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                           // CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateConsumerBalanceTransferInfo(_oDSConsumerBalanceTran, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Consumer Balance Tran Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Consumer Balance Tran  Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDCSInfo(_oDSDCSs, nWHID);
                           // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending DCS Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem DCS  Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateWarrantyCardInfo(_oDSWarranty, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {

                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Warranty Card Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Warranty Card  Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateUnsoldDefectiveProduct(_oDSUnsoldDefectiveProduct, nWHID);
                           // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Unsold Defective Product Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Unsold Defective Product Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }
                    }
                    #endregion

                    #region Unsold Defective Product New
                    else if (oDataTran.TableName == "t_UnsoldDefectiveProductNew")
                    {
                        try
                        {
                            //check Done

                            _oDSUnsoldDefectiveProduct = new CJ.Class.POS.DSUnsoldDefectiveProduct();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSUnsoldDefectiveProduct = new DSUnsoldDefectiveProduct();

                            _oDSUnsoldDefectiveProduct = oDataSend.GetDSUnsoldDefectiveProductNew(_oDSUnsoldDefectiveProduct, nWHID);

                            oDSUnsoldDefectiveProduct.Merge(_oDSUnsoldDefectiveProduct);
                            oDSUnsoldDefectiveProduct.AcceptChanges();

                            oSerivce = new Service();
                            oDSUnsoldDefectiveProduct = oSerivce.SendUnsoldDefectiveProductNew(oDSUnsoldDefectiveProduct, nWHID);


                            _oDSUnsoldDefectiveProduct = new CJ.Class.POS.DSUnsoldDefectiveProduct();
                            _oDSUnsoldDefectiveProduct.Merge(oDSUnsoldDefectiveProduct);
                            _oDSUnsoldDefectiveProduct.AcceptChanges();

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateUnsoldDefectiveProductNew(_oDSUnsoldDefectiveProduct, nWHID);
                            // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Unsold Defective Product Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Unsold Defective Product Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                           // CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateOfficeItemTran(_oDSOfficeItemTran, nWHID);
                           // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending OficeItem Tran Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem OficeItem Tran Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                           // CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateCustomerCreditCollectionInfo(_oDSCustomerCreditApprovalCollection, nWHID);
                           // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Customer Credit Collection Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Customer Credit Collection Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateSalesLead(_oDSSalesLead, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Sales Lead Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Sales Lead Segment \n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                           // CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateSalesLeadHistory(_oDSSalesLead, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Sales Lead History Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Sales Lead History Segment \n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdatePotentialCustomer(_oDSPotentialCustomer, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Potential Customer Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Potential Customer Segment \n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Outlet Display Position  Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Outlet Display Position Segment \n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }
                    }
                    #endregion

                    #region Outlet Display Position History
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
                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDSOutletDisplayPositionHistory = oSerivce.SendOutletDisplayPositionHistory(oDSOutletDisplayPositionHistory);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            _oDSOutletDisplayPositionHistory = new CJ.Class.POS.DSOutletDisplayPosition();
                            _oDSOutletDisplayPositionHistory.Merge(oDSOutletDisplayPositionHistory);
                            _oDSOutletDisplayPositionHistory.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDisplayPositionHistory(_oDSOutletDisplayPositionHistory, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Outlet Display Position History Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Outlet Display Position History Segment \n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateCustomerTempTransferInfo(_oDSCustomerTemp, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Customer Temp Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem CustomerTemp Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }
                            
                            _oDSInvoiceReverse = oDataSend.GetInvoiceReverse(_oDSInvoiceReverse, nWHID);

                            oDSInvoiceReverse.Merge(_oDSInvoiceReverse);
                            oDSInvoiceReverse.AcceptChanges();
                            CJ.Class.DBController.Instance.CloseConnection();

                            oSerivce = new Service();
                            oDSInvoiceReverse = oSerivce.SendInvoiceReverseData(oDSInvoiceReverse, nWHID);


                            _oDSInvoiceReverse = new CJ.Class.POS.DSInvoiceReverse();
                            _oDSInvoiceReverse.Merge(oDSInvoiceReverse);
                            _oDSInvoiceReverse.AcceptChanges();

                           // CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateInvoiceReverseTransferInfo(_oDSInvoiceReverse, nWHID);
                           // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Reverse Invoice Appalication Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Reverse Invoice Appalication Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                           // CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateExchangeOfferMRInfo(_oDSExchangeOfferMR, nWHID);
                           // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Exchange Offer MR Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Exchange Offer MR Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateExchangeOfferJobData(_oDSExchangeOfferJob, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Exchange Offer Job  Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Exchange Offer Job Segment \n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateEcommerceOrderData(_oDSSalesInvoiceEcommerce, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Sales Invoice Ecommerce  Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Exchange Sales Invoice Ecommerce  Segment \n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {

                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Invoice Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Invoice Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDSOutletAttendanceInfo = oSerivce.SendOutletAttendanceInfo(oDSOutletAttendanceInfo, nWHID);
                            _oDSOutletAttendanceInfo = new CJ.Class.POS.DSOutletAttendanceInfo();
                            _oDSOutletAttendanceInfo.Merge(oDSOutletAttendanceInfo);
                            _oDSOutletAttendanceInfo.AcceptChanges();
       
                            oDataSend.UpdateOutletAttendanceInfo(_oDSOutletAttendanceInfo, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Outlet Attendance Info /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Outlet Attendance Info\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateVatPaidProductSerial(_oDSVatPaidProductSerial, nWHID);
                            //CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Vat Paid Product Serial Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Vat Paid Product Serial Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Customer Tran Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Customer Tran Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            //CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDailyProjectionData(_oDSOutletDailyProjection, nWHID);
                           // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Outlet Daily Projection Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Outlet Daily Projection Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Duty Tran Outlet ISGM /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Duty Tran Outlet ISGM Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error TD Delivery Shipment/" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem TD Delivery Shipment Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                           // CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdatePromoDiscountSpecialInfo(_oDSPromoDiscount, nWHID);
                           // CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Promo Discount Special Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Promo Discount Special Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }
                    }
                    #endregion

                    #region  Petty Cash Expense
                    else if (oDataTran.TableName == "t_PettyCashExpense")
                    {

                        try
                        {
                            //check Done

                            _oDSPettyCash = new CJ.Class.POS.DSPettyCash();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSPettyCash = new DSPettyCash();

                            _oDSPettyCash = oDataSend.GetPettyCashExpense(_oDSPettyCash, nWHID);

                            oDSPettyCash.Merge(_oDSPettyCash);
                            oDSPettyCash.AcceptChanges();

                            oSerivce = new Service();
                            oDSPettyCash = oSerivce.SendPettyCashExpense(oDSPettyCash, nWHID);

                            _oDSPettyCash = new CJ.Class.POS.DSPettyCash();
                            _oDSPettyCash.Merge(oDSPettyCash);
                            _oDSPettyCash.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdatePettyCashExpense(_oDSPettyCash, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Petty Cash Expense/" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Petty Cash Expense Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }

                    }
                    #endregion

                    #region  Sales Order
                    else if (oDataTran.TableName == "t_DMSSecondarySalesOrder")
                    {

                        try
                        {
                            _oDSSalesOrder = new CJ.Class.POS.DSSalesOrder();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSSalesOrder = new DSSalesOrder();
                            _oDSSalesOrder = oDataSend.GetSalesOrder(_oDSSalesOrder, nWHID);
                            oDSSalesOrder.Merge(_oDSSalesOrder);
                            oDSSalesOrder.AcceptChanges();

                            oSerivce = new Service();
                            oDSSalesOrder = oSerivce.SendSalesOrder(oDSSalesOrder, nWHID);

                            _oDSSalesOrder = new CJ.Class.POS.DSSalesOrder();
                            _oDSSalesOrder.Merge(oDSSalesOrder);
                            _oDSSalesOrder.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateDMSSalesOrder(_oDSSalesOrder, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();

                            i = i + 1;
                            pbtUpload.Value = i;

                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error DMS Sales Order /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem DMS Sales Order Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }

                    }
                    #endregion
                    #region Extended Warrantey
                    else if (oDataTran.TableName == "t_ExtendedWarranty")
                    {
                        try
                        {
                            //check Done

                            _oDSExtendedWarranty = new CJ.Class.POS.DSExtendedWarranty();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSExtendedWarranty = new DSExtendedWarranty();
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }
                            _oDSExtendedWarranty = oDataSend.GetExtendedWarrantyData(_oDSExtendedWarranty, nWHID);

                            oDSExtendedWarranty.Merge(_oDSExtendedWarranty);
                            oDSExtendedWarranty.AcceptChanges();
                            CJ.Class.DBController.Instance.CloseConnection();

                            oSerivce = new Service();
                            oDSExtendedWarranty = oSerivce.SendExtendedWarranty(oDSExtendedWarranty, nWHID);


                            _oDSExtendedWarranty = new CJ.Class.POS.DSExtendedWarranty();
                            _oDSExtendedWarranty.Merge(oDSExtendedWarranty);
                            _oDSExtendedWarranty.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateExtendedWarranty(_oDSExtendedWarranty, nWHID);
                            CJ.Class.DBController.Instance.CommitTransaction();


                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Extended Warranty  Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Extended Warranty Segment \n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }
                    }
                    #endregion
                    #region Day Plan
                    else if (oDataTran.TableName == "t_DayPlan")
                    {
                        try
                        {
                            _oDSDayPlan = new CJ.Class.POS.DSDayPlan();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();
                            oDSDayPlan = new DSDayPlan();
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }

                            _oDSDayPlan = oDataSend.GetDayPlan(_oDSDayPlan, nWHID);

                            oDSDayPlan.Merge(_oDSDayPlan);
                            oDSDayPlan.AcceptChanges();
                            CJ.Class.DBController.Instance.CloseConnection();

                            oSerivce = new Service();
                            oDSDayPlan = oSerivce.SendDayPlanData(oDSDayPlan, nWHID);


                            _oDSDayPlan = new CJ.Class.POS.DSDayPlan();
                            _oDSDayPlan.Merge(oDSDayPlan);
                            _oDSDayPlan.AcceptChanges();
                            
                            oDataSend.UpdateDayPlanTransferInfo(_oDSDayPlan, nWHID);

                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending Day Plan Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem Day Plan Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                if (_bFlag)
                {
                    MessageBox.Show("Error Sending Monitored Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            #endregion
            return true;
        }
        public bool DataUpload(int nWHID)
        {
            #region Invoice
            try
            {

                ///
                // Sales Invoice with invoice detail, IMEI,Update stock
                ///

                pbtUpload.Visible = true;
                pbtUpload.Minimum = 0;
                pbtUpload.Maximum = 3;
                pbtUpload.Step = 1;
                pbtUpload.Value = 0;

                _oDSSalesInvoice = new CJ.Class.POS.DSSalesInvoice();
                oDataSend = new CJ.Class.DataTransfer.DataSend();
                oDSSalesInvoice = new DSSalesInvoice();

                CJ.Class.DBController.Instance.OpenNewConnection();
                _oDSSalesInvoice = oDataSend.GetSalesInvoice(_oDSSalesInvoice, nWHID);
                pbtUpload.PerformStep();
                CJ.Class.DBController.Instance.CloseConnection();

                oDSSalesInvoice.Merge(_oDSSalesInvoice);
                oDSSalesInvoice.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oSystemInfo = new CJ.Class.POS.SystemInfo();
                oSystemInfo.Refresh();
                oSerivce = new Service();
                oDSSalesInvoice = oSerivce.SendSalesInvoice(oDSSalesInvoice, oSystemInfo.ChannelID);
                pbtUpload.PerformStep();

                _oDSSalesInvoice = new CJ.Class.POS.DSSalesInvoice();
                _oDSSalesInvoice.Merge(oDSSalesInvoice);
                _oDSSalesInvoice.AcceptChanges();

                oDataSend.UpdateSalesInvoiceSendInfo(_oDSSalesInvoice, nWHID);
                pbtUpload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();


            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error Sending Invoice Segment /" + ex.Message);
                MessageBox.Show("Problem Invoice Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            #endregion
            #region Product Stock Tran
            try
            {
                ///
                // Customer Tran with Invoice Wise payment (if any), Update Customer Account
                ///

                pbtUpload.Visible = true;
                pbtUpload.Minimum = 0;
                pbtUpload.Maximum = 3;
                pbtUpload.Step = 1;
                pbtUpload.Value = 0;


                _oDSProductTransaction = new CJ.Class.POS.DSProductTransaction();
                oDataSend = new CJ.Class.DataTransfer.DataSend();
                oDSProductTransaction = new DSProductTransaction();

                CJ.Class.DBController.Instance.OpenNewConnection();
                _oDSProductTransaction = oDataSend.GetProductTransaction(_oDSProductTransaction, nWHID);
                pbtUpload.PerformStep();
                CJ.Class.DBController.Instance.CloseConnection();

                oDSProductTransaction.Merge(_oDSProductTransaction);
                oDSProductTransaction.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oSystemInfo = new CJ.Class.POS.SystemInfo();
                oSystemInfo.Refresh();
                oSerivce = new Service();
                oDSProductTransaction = oSerivce.SendStockTran(oDSProductTransaction, nWHID);
                pbtUpload.PerformStep();

                _oDSProductTransaction = new CJ.Class.POS.DSProductTransaction();
                _oDSProductTransaction.Merge(oDSProductTransaction);
                _oDSProductTransaction.AcceptChanges();

                oDataSend.UpdateStockTranSendInfo(_oDSProductTransaction, nWHID);
                pbtUpload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();


                AppLogger.LogInfo("Successfully Sending Stock Tran");
            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error sending Stock Tran /" + ex.Message);
                MessageBox.Show("Problem Stock Tran Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion
            #region Customer Tran
            try
            {
                ///
                // Customer Tran with Invoice Wise payment (if any), Update Customer Account
                ///

                pbtUpload.Visible = true;
                pbtUpload.Minimum = 0;
                pbtUpload.Maximum = 3;
                pbtUpload.Step = 1;
                pbtUpload.Value = 0;

                _oDSCustomerTransaction = new CJ.Class.POS.DSCustomerTransaction();
                oDataSend = new CJ.Class.DataTransfer.DataSend();
                oDSCustomerTransaction = new DSCustomerTransaction();

                CJ.Class.DBController.Instance.OpenNewConnection();
                _oDSCustomerTransaction = oDataSend.GetCustomerTran(_oDSCustomerTransaction, nWHID);
                pbtUpload.PerformStep();
                CJ.Class.DBController.Instance.CloseConnection();

                oDSCustomerTransaction.Merge(_oDSCustomerTransaction);
                oDSCustomerTransaction.AcceptChanges();

                CJ.Class.DBController.Instance.BeginNewTransaction();
                oSystemInfo = new CJ.Class.POS.SystemInfo();
                oSystemInfo.Refresh();
                oSerivce = new Service();
                oDSCustomerTransaction = oSerivce.SendCustomerTran(oDSCustomerTransaction, nWHID);
                pbtUpload.PerformStep();

                _oDSCustomerTransaction = new CJ.Class.POS.DSCustomerTransaction();
                _oDSCustomerTransaction.Merge(oDSCustomerTransaction);
                _oDSCustomerTransaction.AcceptChanges();

                oDataSend.UpdateCustomerTranSendInfo(_oDSCustomerTransaction, nWHID);
                pbtUpload.PerformStep();
                CJ.Class.DBController.Instance.CommitTransaction();


                AppLogger.LogInfo("Successfully Sending Customer Tran");
            }
            catch (Exception ex)
            {
                CJ.Class.DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Error sending Customer Tran /" + ex.Message);
                MessageBox.Show("Problem Customer Tran Segment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion
            return true;
        }


    }
}