using System;
using System.Drawing;
using System.Windows.Forms;

using CJ.Factory.TELWEBSERVER;
using CJ.Class;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;


namespace CJ.Factory
{
    public partial class frmDataDownload : Form
    {

        Service oSerivce;
        DSProduct oDSProduct;
        DSReceivableData oDSReceivableData;
        DSProductComponent oDSProductComponent;

        CJ.Class.DataTransfer.DataTransfer oDataTransfer;
        CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.POS.DSProduct _oDSProduct;
        CJ.Class.POS.DSReceivableData _oDSReceivableData;
        CJ.Class.POS.DataTrans _oDataTrans = new CJ.Class.POS.DataTrans();
        CJ.Class.BEIL.DSProductComponent _oDSProductComponent;

        int nCount = 0;
        public frmDataDownload()
        {
            InitializeComponent();
        }
        private void frmDataDownload_Load(object sender, EventArgs e)
        {

            oSystemInfo = new CJ.Class.POS.SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.RefreshForFactory();
            DBController.Instance.CloseConnection();
            lblBranchName.Text = oSystemInfo.LocationName;
            nCount = 0;
            try
            {
                int Desc;
                if (Utility.InternetGetConnectedState(out Desc, 0))
                {
                    if (CheckRemoteServer())
                    {
                        nCount = LoadReceivableData(oSystemInfo.LocationID);

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
                MessageBox.Show("Error!!\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "\nError Detail:" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private int LoadReceivableData(int nLocationID)
        {
            _oDSReceivableData = new CJ.Class.POS.DSReceivableData();
            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

            oSerivce = new Service();
            oDSReceivableData = new DSReceivableData();

            _oDataTrans = new CJ.Class.POS.DataTrans();
             oDSReceivableData = oSerivce.DownloadReceivableDataFactory(oDSReceivableData, nLocationID);

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

        private int LoadReceivableDataGroupBy(int nLocationID)
        {
            _oDSReceivableData = new CJ.Class.POS.DSReceivableData();
            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();

            oSerivce = new Service();
            oDSReceivableData = new DSReceivableData();

            _oDataTrans = new CJ.Class.POS.DataTrans();
            oDSReceivableData = oSerivce.DownloadReceivableFactoryDataGroupBy(oDSReceivableData, nLocationID);

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

        private void btDownload_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            int Desc;
            if (Utility.InternetGetConnectedState(out Desc, 0))
            {
                {


                    bool Istrue = DataDownloadTD(oSystemInfo.LocationID);
                    if (Istrue)
                    {
                        MessageBox.Show("Data Downloaded Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        pbDownload.Visible = false;
                    }
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
        public bool DataDownloadTD(int nLocationID)
        {
            nCount = 0;
            nCount = LoadReceivableDataGroupBy(nLocationID);
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

                    #region Services
                    if (oDataTran.TableName == "t_Product")
                    {
                        try
                        {
                            lblTableName.Text = txt + "t_Product";
                            lblTableName.Refresh();

                            oDSProduct = new DSProduct();
                            _oDSProduct = new CJ.Class.POS.DSProduct();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSProduct = oSerivce.DownloadProductFactory(oDSProduct, nLocationID);
                            int ncount = oDSProduct.Product.Count;
                            _oDSProduct.Merge(oDSProduct);
                            _oDSProduct.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (_oDSProduct.Product.Count > 0)
                                oDataTransfer.InsertProductFactory(_oDSProduct);

                            oSerivce = new Service();
                            if (oDSProduct.Product.Count > 0)
                                oSerivce.UpdateProductTransferInfoFactory(oDSProduct, nLocationID);

                            CJ.Class.DBController.Instance.CommitTransaction();
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
                    else
                    {
                        try
                        {
                            lblTableName.Text = txt + oDataTran.TableName;
                            lblTableName.Refresh();

                            oDSProductComponent = new DSProductComponent();
                            _oDSProductComponent = new CJ.Class.BEIL.DSProductComponent();
                            oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                            oDSProductComponent = oSerivce.DownloadProductComponentFactory(oDSProductComponent, nLocationID,oDataTran.TableName);
                            int ncount = oDSProductComponent.ProductComponent.Count;
                            _oDSProductComponent.Merge(oDSProductComponent);
                            _oDSProductComponent.AcceptChanges();
                            int DataCount = 0;
                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            if (oDataTran.TableName == "t_ProductComponent")
                            {
                                DataCount = 0;
                                DataCount = _oDSProductComponent.ProductComponent.Count;
                            }
                            else if (oDataTran.TableName == "t_ProductComponentSerialUniversal")
                            {
                                DataCount = 0;
                                DataCount = _oDSProductComponent.ProductComponentSerialUniversal.Count;
                            }
                            else if(oDataTran.TableName == "t_ProductComponentUniversal")
                            {
                                DataCount = 0;
                                DataCount = _oDSProductComponent.ProductComponentUniversal.Count;
                            }

                            if (DataCount > 0)
                                oDataTransfer.InsertFactoryData(_oDSProductComponent, oDataTran.TableName, nLocationID);


                            oSerivce = new Service();
                            if (DataCount > 0)
                                oSerivce.UpdateProductComponentFactory(oDSProductComponent, nLocationID, oDataTran.TableName);


                            if (oDataTran.TableName == "t_ProductComponent")
                            {
                                if (oDSProductComponent.ProductComponent.Count > 0)
                                    oSerivce.UpdateProductComponentFactory(oDSProductComponent, nLocationID, oDataTran.TableName);
                            }
                            else if (oDataTran.TableName == "t_ProductComponentSerialUniversal")
                            {
                                if (oDSProductComponent.ProductComponentSerialUniversal.Count > 0)
                                    oSerivce.UpdateProductComponentFactory(oDSProductComponent, nLocationID, oDataTran.TableName);
                            }
                            else if (oDataTran.TableName == "t_ProductComponentUniversal")
                            {
                                if (oDSProductComponent.ProductComponentUniversal.Count > 0)
                                    oSerivce.UpdateProductComponentFactory(oDSProductComponent, nLocationID, oDataTran.TableName);
                            }



                            

                                CJ.Class.DBController.Instance.CommitTransaction();
                            nCount = nCount + oDSProductComponent.ProductComponent.Count;
                            if (oDSProductComponent.ProductComponent.Count > 0)
                            {
                                AppLogger.LogInfo("Successfully Downloaded " + oDataTran.TableName + "");
                            }
                            i = i + 1;
                            pbDownload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Downloading " + oDataTran.TableName + " /" + ex.Message);
                            MessageBox.Show("Please Cheak " + oDataTran.TableName + " Segment\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                    #endregion

                }
            }
            lblTableName.Visible = false;
            return true;
        }

    }
}