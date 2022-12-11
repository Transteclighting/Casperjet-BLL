using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Plan;
using System.Data.OleDb;

namespace CJ.Win.Inventory
{
    public partial class frmProductSerialUpload : Form
    {
        private DataTable _oDT;
        int nCount = 0;
        ProductBarcode oProductBarcode;
        int _nWarehouseID = 0;
        string _sTranNo = "";
        int _nTranID = 0;
        public int _TotalGereratedQty = 0;
        public bool _IsTrue = false;

        public frmProductSerialUpload(int nWHID,string sTranNo,int nTranID)
        {
            InitializeComponent();
            _nWarehouseID = nWHID;
            _sTranNo = sTranNo;
            _nTranID = nTranID;
            txtRefTranNo.Text = _sTranNo.ToString();
        }

        private bool UIValidation()
        {

            if (_oDT.Rows.Count == 0)
            {
                MessageBox.Show("There is no Data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtRefTranNo.Text.Trim()=="")
            {
                MessageBox.Show("Please Input Ref. Tran No ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRefTranNo.Focus();
                return false;
            }

            return true;
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductSerialUpload_Load(object sender, EventArgs e)
        {
            pbInvoice.Visible = false;
            lblColumnHead.Text = "Excel Field: ProductID , ProductSerialNo";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            this.openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtBrowseData.Text = this.openFileDialogData.FileName.ToString();
                this.Text = this.openFileDialogData.DefaultExt.ToString();
            }

            LoadSheets();
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtBrowseData.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();
            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Raw$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            int nTotalQty = 0;
            this.dgvData.DataSource = _oDT.DefaultView;
            foreach (DataRow oRow in _oDT.Rows)
            {
                try
                {

                    nTotalQty = nTotalQty + Convert.ToInt32(oRow[1]);
                }
                catch
                {

                    nTotalQty = nTotalQty + 0;

                }
            }

                //lblTotal.Text = "Total Qty:" + nTotalQty.ToString();
                lblTotal.Text = "Total Qty:" + _oDT.Rows.Count.ToString();


            pbInvoice.Maximum = _oDT.Rows.Count;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

        }
        private void Save()
        {

            if (txtBENo.Text == "")
            {
                MessageBox.Show("Please input valied BE#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBENo.Focus();
                return;
            }
            int i = 0;
            int j = 0;
            string sSql = "";
            //DBController.Instance.OpenNewConnection();
            //OleDbCommand cmd = DBController.Instance.GetCommand();

            DataGridViewRow oDGVRow;

            //DBController.Instance.BeginNewTransaction();

            try
            {
                int _Count = 0;
                foreach (DataRow oRow in _oDT.Rows)
                {
                    oProductBarcode = new ProductBarcode();
                    oProductBarcode.WarehouseID = _nWarehouseID;
                    oProductBarcode.ProductId = Convert.ToInt32(oRow[0]);
                    oProductBarcode.ProductSerialNo = Convert.ToString(oRow[1]);
                    oProductBarcode.Status = 1;
                    oProductBarcode.IsActive = (int)Dictionary.IsActive.Active;
                    oProductBarcode.IsDownload = 1;
                    oProductBarcode.Company = Utility.CompanyInfo;
                    oProductBarcode.RefTranNo = _sTranNo.ToString();

                    oProductBarcode.BENo = txtBENo.Text;
                    oProductBarcode.BEDate = dtBEDate.Value.Date;

                    oProductBarcode.CheckProductSerial();

                    if (oProductBarcode.IsBarcodeCount == 0)
                    {
                        oProductBarcode.AddPSL(true);

                        _Count = _Count + 1;
                        oProductBarcode.TranId = _nTranID;
                        oProductBarcode.SerialNo = _Count;

                        oProductBarcode.InsertTELHQ(_nTranID);
                        oProductBarcode.DeleteFromHO();
                        oProductBarcode.InsertHOStockSerial(_nTranID, _nWarehouseID);
                        _TotalGereratedQty = _Count;
                        oDGVRow = dgvData.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {

                        oProductBarcode.UpdatePSL(true);


                        _Count = _Count + 1;
                        oProductBarcode.TranId = _nTranID;
                        oProductBarcode.SerialNo = _Count;

                        oProductBarcode.InsertTELHQ(_nTranID);
                        oProductBarcode.DeleteFromHO();
                        oProductBarcode.InsertHOStockSerial(_nTranID, _nWarehouseID);
                        _TotalGereratedQty = _Count;
                        oDGVRow = dgvData.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;


                        //MessageBox.Show(" Duplicate Product Serial " + oProductBarcode.ProductSerialNo + "");
                        //oDGVRow = dgvData.Rows[i];
                        //oDGVRow.DefaultCellStyle.BackColor = Color.Red;

                        //this.Close();
                    }
                    dgvData.Refresh();

                    i = i + 1;
                    pbInvoice.Value = i;
                    nCount++;
                    _IsTrue = true;
                }
            }
            catch (Exception ex)
            {
                _IsTrue = false;
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error Inserting Data: " + ex + "");
                throw (ex);
            }
            //DBController.Instance.CommitTransaction();
            btnSave.Enabled = false;
            MessageBox.Show(" Data save successfully \n Total Inserted Data " + nCount + "");
            
        }
    }
}