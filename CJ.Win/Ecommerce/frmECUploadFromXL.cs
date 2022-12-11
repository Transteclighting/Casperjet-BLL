using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Ecommerce
{
    public partial class frmECUploadFromXL : Form
    {
        private DataTable _oDT;
        int nCount = 0;
        public frmECUploadFromXL()
        {
            InitializeComponent();
        }

        private void frmECUploadFromXL_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            //this.openFileDialogData.Filter = "Text File(*.txt;)|*.txt;| File(*.TXT;)|*.TXT;|All Files(*.*;)|*.*";
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
            //OleDbConnection oConn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=" + txtBrowseData.Text + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1;\"");
            oConn.Open();
            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Raw_WEB$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);

            this.dgvData.DataSource = _oDT.DefaultView;
            pbInvoice.Maximum = _oDT.Rows.Count;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

        }
        private void Save()
        {
            int i = 0;
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DataGridViewRow oDGVRow;
            
            DBController.Instance.BeginNewTransaction();
            foreach (DataRow oRow in _oDT.Rows)
            {
                try
                {	
                    int nID = Convert.ToInt32(oRow[0]);
                    string sName = Convert.ToString(oRow[1]);
                    string sContactNo = Convert.ToString(oRow[2]);
                    string sDistrict = Convert.ToString(oRow[3]);
                    string sThana = Convert.ToString(oRow[4]);
                    string sAddress = Convert.ToString(oRow[5]);
                    string sEmail = Convert.ToString(oRow[6]);
                    string sProduct = Convert.ToString(oRow[7]);
                    string sBrand = Convert.ToString(oRow[8]);

                    ECSalesLead oECSalesLead = new ECSalesLead();
                    oECSalesLead.WebDataID = nID;
                    if (oECSalesLead.CheckWebID())
                    {
                        oDGVRow = dgvData.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightSalmon;

                        dgvData.Refresh();

                        i = i + 1;
                        pbInvoice.Value = i;
                    }
                    else
                    {
                        oECSalesLead.IsWebRequest = (int)Dictionary.IsWEBQuery.Yes;
                        

                        oECSalesLead.Name = sName;
                        oECSalesLead.ContactNo = sContactNo;
                        oECSalesLead.Email = sEmail;
                        oECSalesLead.Address = sAddress;
                        oECSalesLead.ProductModel = sProduct;
                        oECSalesLead.Brand = sBrand;
                        oECSalesLead.District = sDistrict;
                        oECSalesLead.Thana = sThana;
                        oECSalesLead.Remarks = "";
                        oECSalesLead.CreateDate = DateTime.Now;
                        oECSalesLead.Status = (int)Dictionary.SalesLeadStatus.Create;
                        oECSalesLead.CreateUserID = Utility.UserId;

                        oECSalesLead.Add();
                        nCount++;

                        oDGVRow = dgvData.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;

                        dgvData.Refresh();

                        i = i + 1;
                        pbInvoice.Value = i;
                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                btnSave.Visible = false;
            }
            DBController.Instance.CommitTransaction();
            MessageBox.Show(" Data save successfully \n Total Inserted Data " + nCount + "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}