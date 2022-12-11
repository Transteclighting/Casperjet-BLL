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
    public partial class frmTransactionalSerialUploader : Form
    {
        private DataTable _oDT;
        int nCount = 0;
        ProductBarcode oProductBarcode;
        Product oProduct;
        int nTranID = 0;


        public frmTransactionalSerialUploader()
        {
            InitializeComponent();
        }
        private bool UIValidation()
        {
            if (_oDT.Rows.Count == 0)
            {
                MessageBox.Show("There is no Data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtRefTranNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Ref. Tran No ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRefTranNo.Focus();
                return false;
            }

            if (txtRefTranNo.Text.Trim() != "")
            {
                DBController.Instance.OpenNewConnection();
                oProductBarcode = new ProductBarcode();
                oProductBarcode.CheckTranNo(txtRefTranNo.Text);
                nTranID = oProductBarcode.TranId;
                if (oProductBarcode.IsTranNoCount == 0)
                {
                    MessageBox.Show("Invalide Tran No ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRefTranNo.Focus();
                    return false;
                }
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
        private void frmTransactionalSerialUploader_Load(object sender, EventArgs e)
        {

            pbInvoice.Visible = false;
            lblColumnHead.Text = "Excel Field: ProductCode,ProductName,ProductSerialNo";
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

            lblTotal.Text = "Total Qty:" + _oDT.Rows.Count.ToString();
            pbInvoice.Maximum = _oDT.Rows.Count;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

        }
        private void Save()
        {
            int i = 0;
            int j = 0;
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DataGridViewRow oDGVRow;

            DBController.Instance.BeginNewTransaction();

            try
            {
                foreach (DataRow oRow in _oDT.Rows)
                {


                    oProductBarcode = new ProductBarcode();
                    oProduct = new Product();
                    oProduct.ProductCode = Convert.ToString(oRow[0]);
                    oProduct.Refresh();
                    oProductBarcode.TranId = nTranID;
                    oProductBarcode.ProductId = oProduct.ProductID;
                    oProductBarcode.ProductSerialNo = Convert.ToString(oRow[2]);
                    oProductBarcode.CheckProductSerialByTranID();

                    if (oProductBarcode.IsBarcodeCount == 0)
                    {
                        oProductBarcode.AddProductSerial(true);
                        oDGVRow = dgvData.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        MessageBox.Show(" Duplicate Product Serial " + oProductBarcode.ProductSerialNo + "");
                        oDGVRow = dgvData.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.Red;

                        this.Close();
                    }
                    dgvData.Refresh();

                    i = i + 1;
                    pbInvoice.Value = i;
                    nCount++;
                }
            }

            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error Inserting Data: " + ex + "");
                throw (ex);
            }
            DBController.Instance.CommitTransaction();
            btnSave.Enabled = false;
            MessageBox.Show(" Data save successfully \n Total Inserted Data " + nCount + "");
        }


    }
}