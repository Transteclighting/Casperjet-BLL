
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
using CJ.Class;
using CJ.Class.POS;

namespace CJ.POS.RT
{
    public partial class frmDatabaseBackup : Form
    {
        SystemInfo _oSystemInfo;
        public frmDatabaseBackup()
        {
            InitializeComponent();
        }

        private void btnBackupStart_Click(object sender, EventArgs e)
        {
            //pbDownload.Visible = true;
            pbDownload.Maximum = 100;
            pbDownload.Value = 0;
            int i = 0;

            DBController.Instance.OpenNewConnection();
            _oSystemInfo = new SystemInfo();
            _oSystemInfo.Refresh();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDBBackupPath = ConfigurationManager.AppSettings["DBBackupPath"];
            
            if (!Directory.Exists(sDBBackupPath)) 
            {
                Directory.CreateDirectory(sDBBackupPath);
            }
            string sSql = "";
            OleDbConnection _conn = DBController._conn;
            string db = _conn.Database;
            string sFileNameNpath = sDBBackupPath + "\\" + db + Convert.ToDateTime(_oSystemInfo.OperationDate).ToString("yyyyMMdd") + ".mdf";
            try
            {

                sSql = "backup database " + db + " to disk='" + sFileNameNpath + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                i = i + 20;
                pbDownload.Value = i;

                DBBackupLog oDBBackupLog = new DBBackupLog();
                oDBBackupLog.WarehouseID = _oSystemInfo.WarehouseID;
                oDBBackupLog.OperationDate = Convert.ToDateTime(_oSystemInfo.OperationDate);
                oDBBackupLog.BakcupDate = DateTime.Now;
                oDBBackupLog.FileName = sFileNameNpath + ".gz";
                oDBBackupLog.UploadDate = null;
                oDBBackupLog.Add();

                i = i + 20;
                pbDownload.Value = i;

                DataTran _oDataTran = new DataTran();
                _oDataTran.TableName = "t_DBBackupLog";
                _oDataTran.DataID = oDBBackupLog.BackupID;
                _oDataTran.WarehouseID = _oSystemInfo.WarehouseID;
                _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTran.BatchNo = 0;
                _oDataTran.CreateDate = Convert.ToDateTime(_oSystemInfo.OperationDate);
                _oDataTran.AddForTDPOS();

                DBBackupLogs oDBBackupLogs = new DBBackupLogs();
                DateTime dt = Convert.ToDateTime(_oSystemInfo.OperationDate);
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
                i = i + 20;
                pbDownload.Value = i;
                CompressFile(sFileNameNpath);
                i = i + 20;
                pbDownload.Value = i;
                if (File.Exists(sFileNameNpath))
                {
                    File.Delete(sFileNameNpath);
                }
                i = i + 20;
                pbDownload.Value = i;

                MessageBox.Show("Backup Successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();

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
        private void frmDatabaseBackup_Load(object sender, EventArgs e)
        {
            //pbDownload.Visible = false;
        }


    }
}