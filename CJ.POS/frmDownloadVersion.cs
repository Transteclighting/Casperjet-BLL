using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;

namespace CJ.POS
{
    public partial class frmDownloadVersion : Form
    {
        WebClient client;
        string _sFilePath = "";
        public frmDownloadVersion()
        {
            InitializeComponent();
        }



        //public static void Decompress(FileInfo fileToDecompress)
        //{
        //    using (FileStream originalFileStream = fileToDecompress.OpenRead())
        //    {
        //        string currentFileName = fileToDecompress.FullName;
        //        string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

        //        using (FileStream decompressedFileStream = File.Create(newFileName))
        //        {
        //            using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
        //            {
        //                decompressionStream.CopyTo(decompressedFileStream);
        //                Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
        //            }
        //        }
        //    }
        //}
        //public static byte[] Decompress(byte[] data)
        //{
        //    MemoryStream input = new MemoryStream();
        //    input.Write(data, 0, data.Length);
        //    input.Position = 0;

        //    GZipStream gzip = new GZipStream(input, CompressionMode.Decompress, true);

        //    MemoryStream output = new MemoryStream();

        //    byte[] buff = new byte[64];
        //    int read = -1;

        //    read = gzip.Read(buff, 0, buff.Length);

        //    while (read > 0)
        //    {
        //        output.Write(buff, 0, read);
        //        read = gzip.Read(buff, 0, buff.Length);
        //    }

        //    gzip.Close();

        //    return output.ToArray();
        //}

        public static void Decompress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Get original file extension, for example
                // "doc" from report.doc.gz.
                string curFile = fi.FullName;
                string origName = curFile.Remove(curFile.Length -
                        fi.Extension.Length);

                //Create the decompressed file.
                using (FileStream outFile = File.Create(origName))
                {
                    using (GZipStream Decompress = new GZipStream(inFile,
                            CompressionMode.Decompress))
                    {
                        // Copy the decompression stream 
                        // into the output file.
                        Decompress.CopyTo(outFile);

                        Console.WriteLine("Decompressed: {0}", fi.Name);

                    }
                }
            }
        }






        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[4096];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
        //public static void Decompress(DirectoryInfo directoryPath)
        //{
        //    foreach (FileInfo file in directoryPath.GetFiles())
        //    {
        //        var path = directoryPath.FullName;
        //        string zipPath = path + file.Name;
        //        string extractPath = Regex.Replace(path + file.Name, ".zip", "");

        //        ZipFile.ExtractToDirectory(zipPath, extractPath);
        //    }
        //}


        private void Update_bttn_Click(object sender, EventArgs e)
        {
            
            _sFilePath = "";
            string url = txtURL.Text;
            if (!string.IsNullOrEmpty(url))
            {
                Thread thread = new Thread(() =>
                {
                    Uri uri = new Uri(url);
                    string filename = System.IO.Path.GetFileName(uri.AbsolutePath);
                    string sFilePath = Application.StartupPath + "\\" + filename;
                    _sFilePath = sFilePath;
                    if (File.Exists(sFilePath))
                    {
                        File.Delete(sFilePath);
                    }

                    //client.DownloadFileAsync(uri, "D:\\Download File" + "/" + filename);
                    client.DownloadFileAsync(uri, Application.StartupPath + "/" + filename);
                });
                thread.Start();


                //ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }

        private void frmDownloadVersion_Load(object sender, EventArgs e)
        {
            client = new WebClient();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            //DirectoryInfo directorySelected = new DirectoryInfo(_sFilePath); 
            DirectoryInfo directorySelected = new DirectoryInfo(Application.StartupPath);
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.zip"))
            //foreach (FileInfo fileToDecompress in directorySelected.GetFiles(_sFilePath))
            {
                Decompress(fileToDecompress);
            }
            ////MessageBox.Show("Download File Completed");
            MessageBox.Show("Download File Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                progressBar1.Minimum = 0;
                double receive = double.Parse(e.BytesReceived.ToString());
                double Totalreceive = double.Parse(e.TotalBytesToReceive.ToString());
                double Percent = receive / Totalreceive * 100;

                lblDownloadStatus.Text = $"Downloded{string.Format("{0:0.##}", Percent)}%";
                progressBar1.Value = int.Parse(Math.Truncate(Percent).ToString());
            }));
        }
    }
}
