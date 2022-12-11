using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using System.Data.OleDb;
using System.Threading;

using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmInvoiceWiseClaimSupportExeclUploader : Form
    {
        private DataTable _oDT;

        public frmInvoiceWiseClaimSupportExeclUploader()
        {
            InitializeComponent();
        }

        private void frmMobileBillExeclUploader_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bool IsSelected = false;
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            this.openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtXLFilePath.Text = this.openFileDialogData.FileName.ToString();
                this.Text = this.openFileDialogData.DefaultExt.ToString();
                IsSelected = true;
            }

            if (IsSelected)
            {
                LoadSheets();
            }
            //GetTotalAmount();
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();

            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);

            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            dgvInvoiceWiseClaimSupport.DataSource = _oDT.DefaultView;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

            dgvInvoiceWiseClaimSupport.ReadOnly = true;
           
        }

       
        private bool validateUIInput()
        {
            if (dgvInvoiceWiseClaimSupport.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Save Bill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
            
        }
        private void Save()
        {
            string _CustomerCode = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
            try
            {
                DBController.Instance.BeginNewTransaction();
                foreach (DataGridViewRow oItemRow in dgvInvoiceWiseClaimSupport.Rows)
                {
                    InvoiceWiseClaimSupport oInvoiceWiseClaimSupport = new InvoiceWiseClaimSupport();
                        
                    oInvoiceWiseClaimSupport.InvoiceNo = oItemRow.Cells[0].Value.ToString();
                    oInvoiceWiseClaimSupport.ProductCode = oItemRow.Cells[1].Value.ToString();
                    oInvoiceWiseClaimSupport.SupportAmount = Convert.ToDouble(oItemRow.Cells[2].Value);
                    oInvoiceWiseClaimSupport.Remarks = oItemRow.Cells[3].Value.ToString();

                    oInvoiceWiseClaimSupport.Add();
                }

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Saved Successfully");
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
    }
}