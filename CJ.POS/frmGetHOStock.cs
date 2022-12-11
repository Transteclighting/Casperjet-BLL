using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using CJ.POS.TELWEBSERVER;
using CJ.Class;

namespace CJ.POS
{
    public partial class frmGetHOStock : Form
    {
        CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.POS.DSStock _oDSStock;
        CJ.Class.DataTransfer.DataTransfer oDataTransfer;

        Service oSerivce;
        DSStock oDSStock;
        public frmGetHOStock()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int Desc;
            if (Utility.InternetGetConnectedState(out Desc, 0))
            {
                //if (Utility.CheckTELWEBServer())
                //{
                    try
                    {

                        oSerivce = new Service();

                        DateTime dtCurrentDate = DateTime.Now.Date;

                        _oDSStock = new CJ.Class.POS.DSStock();
                        oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

                        oDSStock = oSerivce.DownloadProductStockAll(oDSStock);


                        _oDSStock.Merge(oDSStock);
                        _oDSStock.AcceptChanges();

                        CJ.Class.DBController.Instance.BeginNewTransaction();

                        if (_oDSStock.ProductStock.Count > 0)
                        {

                            pbProgress.Visible = true;
                            pbProgress.Maximum = _oDSStock.ProductStock.Count;
                            pbProgress.Value = 0;
                            int i = 0;
                            int nCount=0;
                            foreach (CJ.Class.POS.DSStock.ProductStockRow oProductStockRow in _oDSStock.ProductStock)
                            {

                                ProductStock oProductStock = new ProductStock();

                                oProductStock.ProductID = oProductStockRow.ProductID;
                                oProductStock.WarehouseID = oProductStockRow.WarehouseID;
                                oProductStock.ChannelID = oProductStockRow.ChannelID;

                                oProductStock.Quantity = oProductStockRow.CurrentStock;
                                oProductStock.CurrentStockValue = oProductStockRow.CurrentStockValue;
                                oProductStock.BookingStock = oProductStockRow.BookingStock;
                                
                                if (oProductStock.CheckProductStock())
                                {
                                    oProductStock.Update();
                                }
                                else
                                {
                                    oProductStock.Insert();
                                    oProductStock.Update();
                                }

                                i = i + 1;
                                pbProgress.Value = i;
                                nCount++;
                            }
                            foreach (CJ.Class.POS.DSStock.HOStockUpdateDateRow oHOStockUpdateDateRow in _oDSStock.HOStockUpdateDate)
                            {
                                dtCurrentDate = oHOStockUpdateDateRow.Date;
                            }
                            OleDbCommand cmd = DBController.Instance.GetCommand();
                            cmd.CommandText = "Update t_ThisSystem SET HOStockUpdateDate='" + dtCurrentDate + "'";
                            cmd.CommandType = CommandType.Text;

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                            lblLastUpdateDate.Text = Convert.ToDateTime(dtCurrentDate).ToString("dd-MMM-yyyy hh:mm tt");
                            lblLastUpdateDate.Refresh();
                            CJ.Class.DBController.Instance.CommitTransaction();
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Updated HO Stock");
                            }
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Successfully Updated HO Stock \n\nNo of Product: " + nCount + "\nLast Update Date: " + Convert.ToDateTime(dtCurrentDate).ToString("dd-MMM-yyyy hh:mm tt") + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        
                        }

                    }
                    catch (Exception ex)
                    {
                        CJ.Class.DBController.Instance.RollbackTransaction();
                        AppLogger.LogError("Error Updating HO Stock /" + ex.Message);
                        MessageBox.Show("An error occurred during updating stock please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                //}
                //else
                //{
                //    MessageBox.Show("HO Server down!!! \n\nPlease try again later or contact concern person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.Close();
                //}
            }
            else
            {
                MessageBox.Show("Please Check Internet Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGetHOStock_Load(object sender, EventArgs e)
        {

            oSystemInfo = new CJ.Class.POS.SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            DBController.Instance.CloseConnection();

            lblBranchName.Text =  oSystemInfo.Shortcode;
            if (oSystemInfo.HOStockUpdateDate != null)
                lblLastUpdateDate.Text = Convert.ToDateTime(oSystemInfo.HOStockUpdateDate).ToString("dd-MMM-yyyy hh:mm tt");
            else lblLastUpdateDate.Text = "N/A";
        }
    }
}