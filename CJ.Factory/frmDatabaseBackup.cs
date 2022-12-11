
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Factory
{
    public partial class frmDatabaseBackup : Form
    {
        public frmDatabaseBackup()
        {
            InitializeComponent();
        }

        private void btnBackupStart_Click(object sender, EventArgs e)
        {
            pbDownload.Maximum = 100;
            pbDownload.Value = 0;
            int i = 0;

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
            string sFileNameNpath = sDBBackupPath + "\\" + db + Convert.ToDateTime(DateTime.Now.Date).ToString("yyyyMMdd") + ".mdf";
            try
            {

                sSql = "backup database " + db + " to disk='" + sFileNameNpath + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                i = i + 20;
                pbDownload.Value = i;
                DBController.Instance.CloseConnection();

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

            sourceFile.Close();
            destinationFile.Close();
        }
        private void frmDatabaseBackup_Load(object sender, EventArgs e)
        {

        }


    }
}