using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.IO.Compression;

using CJ.Class.POS;
using CJ.Class;
using CJ.POS.Security;


namespace CJ.POS
{
    public partial class frmDayEnd : Form
    {
        SystemInfo oSystemInfo;
        frmMain ofrmMain;
        DayStartEndLog _oDayStartEndLog;
        DataTran _oDataTran;
        public frmDayEnd(object _oFrmMain)
        {
            InitializeComponent();
            ofrmMain = (frmMain)_oFrmMain;
        }
        private void frmDayEnd_Load(object sender, EventArgs e)
        {
            oSystemInfo = new SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            DBController.Instance.CloseConnection();
            dtOperationDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            dtNextOperationDate.Value = dtOperationDate.Value.AddDays(1);
            dtNextOperationDate.Enabled = false;

            //if (oSystemInfo.NextOperationDate != null)
            //    dtNextOperationDate.Value = Convert.ToDateTime(oSystemInfo.NextOperationDate).Date;

            label1.Text = "Your are attempting to close Operation for the date " +
                Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy")
            + ".\n"+"Once you close the day, you are not allowed to do any"+"\n"+" transaction in this day or before this day.";

        }
        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(oSystemInfo.OperationDate).Date >= dtNextOperationDate.Value.Date)
                {
                    MessageBox.Show("Next probable operation date cannot prior to operation date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                oSystemInfo.LastOperationDate = dtOperationDate.Value.Date;
                oSystemInfo.NextOperationDate = dtNextOperationDate.Value.Date;

                _oDayStartEndLog = new DayStartEndLog();

                _oDayStartEndLog.WarehouseID = oSystemInfo.WarehouseID;
                _oDayStartEndLog.Type = (int)Dictionary.DayStartEndLogType.DayEnd;
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

                oSystemInfo.DayEnd();

                SystemInfo oInfo = new SystemInfo();
                oInfo.NewVatActive();

                DateTime dt = Convert.ToDateTime(oInfo.NewVatActivationDate);
                if (dtNextOperationDate.Value.Date == dt.Date)
                {

                    ProductBarcodes oProductBarcodes = new ProductBarcodes();
                    oProductBarcodes.GetStockSerial(oSystemInfo.WarehouseID);

                    ProductBarcode _oMAXID = new ProductBarcode();
                    int nID = _oMAXID.GetMaxID();
                    // Item Details
                    foreach (ProductBarcode oItem in oProductBarcodes)
                    {

                        ProductBarcode _oProductBarcode = new ProductBarcode();
                        _oProductBarcode.VatPaidID = nID;
                        _oProductBarcode.ProductId = oItem.ProductId;
                        _oProductBarcode.WarehouseID = oItem.WarehouseID;
                        _oProductBarcode.ProductSerialNo = oItem.ProductSerialNo;
                        _oProductBarcode.TranNo = oItem.TranNo;
                        _oProductBarcode.TranDate = oItem.TranDate;
                        _oProductBarcode.ProductSerialNo = oItem.ProductSerialNo;
                        _oProductBarcode.Status = 1;
                        _oProductBarcode.InsertVatPaidProductSerial();
                    }


                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_ProductStockSerialVatPaid";
                    oDataTran.DataID = Convert.ToInt32(nID);
                    oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }

                }
                DBController.Instance.CommitTransaction();
                DBBackup(_oDataTran.WarehouseID, _oDataTran.CreateDate);
                MessageBox.Show("You Have Successfully Save Day End ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuDisable();
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                this.Close();

                //frmMain ologin = new frmMain();
                //ologin.logIn(null,null);
                //ologin.Refresh();

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void DBBackup(int nWarehouseID, object dOperationDate )
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDBBackupPath = ConfigurationManager.AppSettings["DBBackupPath"];

            if (!Directory.Exists(sDBBackupPath))
            {
                Directory.CreateDirectory(sDBBackupPath);
            }
            string sSql = "";
            OleDbConnection _conn = DBController._conn;
            string db = _conn.Database;
            string sFileNameNpath = sDBBackupPath + "\\" + db + Convert.ToDateTime(dOperationDate).ToString("yyyyMMdd") + ".mdf";
            try
            {

                sSql = "backup database " + db + " to disk='" + sFileNameNpath + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                DBBackupLog oDBBackupLog = new DBBackupLog();
                oDBBackupLog.WarehouseID = nWarehouseID;
                oDBBackupLog.OperationDate = Convert.ToDateTime(dOperationDate);
                oDBBackupLog.BakcupDate = DateTime.Now;
                oDBBackupLog.FileName = sFileNameNpath + ".gz";
                oDBBackupLog.UploadDate = null;
                oDBBackupLog.Add();

                DataTran _oDataTran = new DataTran();
                _oDataTran.TableName = "t_DBBackupLog";
                _oDataTran.DataID = oDBBackupLog.BackupID;
                _oDataTran.WarehouseID = nWarehouseID;
                _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTran.BatchNo = 0;
                _oDataTran.CreateDate = Convert.ToDateTime(dOperationDate);
                _oDataTran.AddForTDPOS();

                DBBackupLogs oDBBackupLogs = new DBBackupLogs();
                DateTime dt = Convert.ToDateTime(dOperationDate);
                dt = dt.AddDays(-4);
                oDBBackupLogs.Refresh(dt);
                foreach (DBBackupLog oBackupLog in oDBBackupLogs)
                {
                    if (File.Exists(oBackupLog.FileName))
                    {
                        File.Delete(oBackupLog.FileName);
                    }
                }
                DBController.Instance.CloseConnection();

                CompressFile(sFileNameNpath);
                if (File.Exists(sFileNameNpath))
                {
                    File.Delete(sFileNameNpath);
                }

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }

        }

        public void CompressFile(string path)
        {
            FileStream sourceFile = File.OpenRead(path);
            FileStream destinationFile = File.Create(path + ".gz");

            byte[] buffer = new byte[sourceFile.Length];
            sourceFile.Read(buffer, 0, buffer.Length);

            using (GZipStream output = new GZipStream(destinationFile,
                CompressionMode.Compress))
            {
                Console.WriteLine("Compressing {0} to {1}.", sourceFile.Name,
                    destinationFile.Name, false);

                output.Write(buffer, 0, buffer.Length);
            }

            // Close the files.
            sourceFile.Close();
            destinationFile.Close();
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