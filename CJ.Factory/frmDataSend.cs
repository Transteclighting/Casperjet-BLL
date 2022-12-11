using System;
using System.Drawing;
using System.Windows.Forms;
using CJ.Factory.TELWEBSERVER;
using CJ.Class;



namespace CJ.Factory
{
    public partial class frmDataSend : Form
    {
        DSProductComponent oDSProductComponent;
        Service oSerivce;
        CJ.Class.BEIL.DSProductComponent _oDSProductComponent;
        CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.POS.DataTrans _oDataTrans;
        CJ.Class.DataTransfer.DataSend oDataSend;
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
            oSystemInfo.RefreshForFactory();
            nCount = LoadReceivableData();
            DBController.Instance.CloseConnection();

            lblBranchName.Text = oSystemInfo.LocationName;
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
        private void btSend_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int Desc;

            if (Utility.InternetGetConnectedState(out Desc, 0))
            {
                DBController.Instance.OpenNewConnection();
                bool IsTrue = DataUpload(oSystemInfo.LocationID, true);
                if (IsTrue)
                {
                    MessageBox.Show("Data Uploaded Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbtUpload.Visible = false;
                    this.Close();
                }
                DBController.Instance.CloseConnection();
            }
            else
            {
                MessageBox.Show("Please Check Internet Connection\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            this.Cursor = Cursors.Default;
        }
        private int LoadReceivableData()
        {
            _oDataTrans = new CJ.Class.POS.DataTrans();
            _oDataTrans.RefeshForFactory(oSystemInfo.LocationID);
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
        public bool DataUpload(int nLocationID, bool _bFlag)
        {
            nCount = 0;

            _oDataTrans = new CJ.Class.POS.DataTrans();
            nCount = _oDataTrans.RefeshGroupByDataFactory(nLocationID);
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

                    #region Factory Data Upload
                    if (oDataTran.TableName == "t_ProductComponentSerialUniversal")
                    {
                        try
                    {
                        _oDSProductComponent = new CJ.Class.BEIL.DSProductComponent();
                        oDataSend = new CJ.Class.DataTransfer.DataSend();

                        oDSProductComponent = new DSProductComponent();
                        _oDSProductComponent = oDataSend.GetDataForFactory(_oDSProductComponent, nLocationID, oDataTran.TableName);
                        oDSProductComponent.Merge(_oDSProductComponent);
                        oDSProductComponent.AcceptChanges();
                        oSerivce = new Service();
                        oDSProductComponent = oSerivce.SendFactoryData(oDSProductComponent, oDataTran.TableName, nLocationID);
                        _oDSProductComponent = new CJ.Class.BEIL.DSProductComponent();
                        _oDSProductComponent.Merge(oDSProductComponent);
                        _oDSProductComponent.AcceptChanges();

                        CJ.Class.DBController.Instance.BeginNewTransaction();
                        oDataSend.UpdateFactoryDataTransfer(_oDSProductComponent, nLocationID, oDataTran.TableName);
                        CJ.Class.DBController.Instance.CommitTransaction();
                        i = i + 1;
                        pbtUpload.Value = i;
                    }
                    catch (Exception ex)
                    {
                        CJ.Class.DBController.Instance.RollbackTransaction();
                        AppLogger.LogError("Error Sending " + oDataTran.TableName + " Segment /" + ex.Message);
                        if (_bFlag)
                        {
                            MessageBox.Show("Problem " + oDataTran.TableName + "  Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return false;
                        }
                    }
                    #endregion

                    #region Factory Defective Data Upload
                    if (oDataTran.TableName == "t_SKDDefectiveComponent")
                    {
                        try
                        {
                            _oDSProductComponent = new CJ.Class.BEIL.DSProductComponent();
                            oDataSend = new CJ.Class.DataTransfer.DataSend();

                            oDSProductComponent = new DSProductComponent();
                            _oDSProductComponent = oDataSend.GetDataForFactoryDefective(_oDSProductComponent, nLocationID, oDataTran.TableName);
                            oDSProductComponent.Merge(_oDSProductComponent);
                            oDSProductComponent.AcceptChanges();
                            oSerivce = new Service();
                            oDSProductComponent = oSerivce.SendFactoryData(oDSProductComponent, oDataTran.TableName, nLocationID);
                            _oDSProductComponent = new CJ.Class.BEIL.DSProductComponent();
                            _oDSProductComponent.Merge(oDSProductComponent);
                            _oDSProductComponent.AcceptChanges();

                            CJ.Class.DBController.Instance.BeginNewTransaction();
                            oDataSend.UpdateFactoryDataTransfer(_oDSProductComponent, nLocationID, oDataTran.TableName);
                            CJ.Class.DBController.Instance.CommitTransaction();
                            i = i + 1;
                            pbtUpload.Value = i;
                        }
                        catch (Exception ex)
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Sending " + oDataTran.TableName + " Segment /" + ex.Message);
                            if (_bFlag)
                            {
                                MessageBox.Show("Problem " + oDataTran.TableName + "  Segment\n\nPlease try again later or Contact concern Person\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return false;
                        }
                    }
                    #endregion

                }
            }
            return true;
        }

    }
}