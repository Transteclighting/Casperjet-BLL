using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

using CJ.Class.POS;
using CJ.Class;

namespace CJ.POS
{
    public partial class frmDayStart : Form
    {
        SystemInfo oSystemInfo;
        frmMain ofrmMain;
        DayStartEndLog _oDayStartEndLog;
        DataTran _oDataTran;

        public frmDayStart(object _oFrmMain)
        {
            InitializeComponent();
            ofrmMain = (frmMain)_oFrmMain;
        }

        private void frmDayStart_Load(object sender, EventArgs e)
        {
            oSystemInfo = new SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            dtOperationDate.Enabled = false;
            DBController.Instance.CloseConnection();
            if (oSystemInfo.NextOperationDate != null)
                dtOperationDate.Value = Convert.ToDateTime(oSystemInfo.NextOperationDate).Date;
            if (oSystemInfo.LastOperationDate != null)
                label1.Text = "Last operation date is " +
                    Convert.ToDateTime(oSystemInfo.LastOperationDate).ToString("dd-MMM-yyyy")
                + ". Starting date must be  " + "\n" + "greater than last operation date. If a day is started once you " + "\n" + " can not start or change again without run Day End process.";
            else
                label1.Text = "Last operation date is " +
                 "NA"
              + ". Starting date must be " + "\n" + "greater than last operation date. If a day is started once you " + "\n" + "can not start or change again without run Day End process.";

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSystemInfo.LastOperationDate != null)
                {
                    if (Convert.ToDateTime(oSystemInfo.LastOperationDate).Date >= dtOperationDate.Value.Date)
                    {
                        MessageBox.Show("Cannot start a new operation day which is prior to last operation date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                oSystemInfo.OperationDate = dtOperationDate.Value.Date;

                _oDayStartEndLog = new DayStartEndLog();

                _oDayStartEndLog.WarehouseID = oSystemInfo.WarehouseID;
                _oDayStartEndLog.Type = (int)Dictionary.DayStartEndLogType.DayStart;
                _oDayStartEndLog.OperationDate = dtOperationDate.Value.Date;
                _oDayStartEndLog.CreateUserID = Utility.UserId;

                DBController.Instance.BeginNewTransaction();

                _oDayStartEndLog.Add();

                _oDataTran = new DataTran();
                _oDataTran.TableName = "t_DayStartEndLog";
                _oDataTran.DataID = _oDayStartEndLog.LogID;
                _oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTran.BatchNo = 0;
                _oDataTran.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                _oDataTran.AddForTDPOS();

                oSystemInfo.DayStart();

                DateTime dLastOperationDate = Convert.ToDateTime(oSystemInfo.LastOperationDate);
                DateTime dOperationDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                int YearOfLastOperationDate = Convert.ToInt32(dLastOperationDate.Year);
                int YearOfOperationDate = Convert.ToInt32(dOperationDate.Year);

                int MonthOfLastOperationDate = Convert.ToInt32(dLastOperationDate.Month);
                int MonthOfOperationDate = Convert.ToInt32(dOperationDate.Month);
                OleDbCommand cmd = DBController.Instance.GetCommand();
                if (YearOfOperationDate > YearOfLastOperationDate)
                {
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "Update t_NextDocumentNo SET NextInvoiceNo=1,NextRequisitionNo=1,NextISGMNo=1,NextReturnNo=1,NextSendToCSDNo=1";
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "Update t_NextNo SET NextDCSNo=1";
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                if (MonthOfLastOperationDate == 6 && MonthOfOperationDate == 7)
                {
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "Update t_NextDocumentNo SET NextVatChallanNo=1, NextIVChallanNo=1,NextVatChallanNoISGM=1,NextIVChallanNoISGM=1";
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save Day Start ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuDisable();
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                this.Close();

                //frmMain ologin = new frmMain();
                //ologin.logIn(null, null);
                //ologin.Refresh();

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void MenuDisable()
        {
            ofrmMain.mnuLogIn.Enabled = true;
            ofrmMain.mnuLogOut.Enabled = false;
            ofrmMain.mnuChangePassword.Enabled = false;
            ofrmMain.mmuexit.Enabled = true;
            ofrmMain.thisSystemToolStripMenuItem.Enabled = false;
            ofrmMain.dayStartToolStripMenuItem.Enabled = false;
            ofrmMain.dayEndToolStripMenuItem.Enabled = false;
            ofrmMain.updateHOStockToolStripMenuItem.Enabled = false;

            ofrmMain.currentEmployeeToolStripMenuItem.Enabled = false;
            ofrmMain.productDetailsToolStripMenuItem.Enabled = false;
            ofrmMain.runningCPToolStripMenuItem.Enabled = false;
            ofrmMain.existingToolStripMenuItem.Enabled = false;
            ofrmMain.requisitionCreationToolStripMenuItem.Enabled = false;
            ofrmMain.aSGWiseSaleForAppsToolStripMenuItem.Enabled = false;


            ofrmMain.iSGMToHOToolStripMenuItem.Enabled = false;
            ofrmMain.iSGMToToolStripMenuItem.Enabled = false;
            ofrmMain.goodsReceiveAgainstRequisitioToolStripMenuItem.Enabled = false;
            ofrmMain.goodsReceiveFromOtherOutletToolStripMenuItem.Enabled = false;
            ofrmMain.databaseBackupToolStripMenuItem.Enabled = false;

            ofrmMain.retailInvoiceToolStripMenuItem.Enabled = false;
            ofrmMain.dealerInvoiceToolStripMenuItem.Enabled = false;
            ofrmMain.retailInvoiceForHPAToolStripMenuItem.Enabled = false;
            ofrmMain.corporateInvoiceB2CToolStripMenuItem.Enabled = false;
            ofrmMain.corporateInvoiceB2BToolStripMenuItem.Enabled = false;
            ofrmMain.modifyInvoicesToolStripMenuItem.Enabled = false;

            ofrmMain.advancePaymentToolStripMenuItem.Enabled = false;

            ofrmMain.dailyCollectionStatementToolStripMenuItem.Enabled = false;
            ofrmMain.stockPositionToolStripMenuItem.Enabled = false;
            ofrmMain.stockLedgerToolStripMenuItem.Enabled = false;
            ofrmMain.stockMovementSummaryToolStripMenuItem.Enabled = false;
            ofrmMain.serialToolStripMenuItem.Enabled = false;
            ofrmMain.invoiceRegisterToolStripMenuItem.Enabled = false;
            ofrmMain.salesStatementToolStripMenuItem.Enabled = false;
            ofrmMain.salesQtyValueToolStripMenuItem.Enabled = false;
            ofrmMain.vAT11KaToolStripMenuItem.Enabled = false;
            ofrmMain.customerLedgerToolStripMenuItem.Enabled = false;
            ofrmMain.dataDownloadToolStripMenuItem.Enabled = false;
            ofrmMain.dataTransferToolStripMenuItem.Enabled = false;
            ofrmMain.dealerInvoiceEditableUnitPriceToolStripMenuItem.Enabled = false;
            ofrmMain.dealerInvoiceWithoutIMEIToolStripMenuItem.Enabled = false;
            ofrmMain.paymentReceiveDealerToolStripMenuItem.Enabled = false;

            ofrmMain.stockPositionToolStripMenuItem.Enabled = false;
            ofrmMain.stockLedgerToolStripMenuItem.Enabled = false;
            ofrmMain.stockMovementSummaryToolStripMenuItem.Enabled = false;
            ofrmMain.serialToolStripMenuItem.Enabled = false;
            ofrmMain.invoiceRegisterToolStripMenuItem.Enabled = false;
            ofrmMain.salesStatementToolStripMenuItem.Enabled = false;
            ofrmMain.salesQtyValueToolStripMenuItem.Enabled = false;
            ofrmMain.vAT11KaToolStripMenuItem.Enabled = false;
            ofrmMain.customerLedgerToolStripMenuItem.Enabled = false;
            ofrmMain.reprintToolStripMenuItem.Enabled = false;
            //ofrmMain.tsbLogIn.Enabled = true;
            //ofrmMain.tsbLogOut.Enabled = false;

        }
    }
}