using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.SupplyChain;
using CJ.Class.Accounts;
using System.Data.OleDb;
using System.Threading;


using CJ.Class;

namespace CJ.Win.SupplyChain
{
    public partial class frmUploaderforPackQty : Form
    {
        int nCount = 0;
        Companys _oCompanys;
        private DataTable _oDT;
        private int nArrayLen = 0;
        private string[] sProductBarcodeArr = null;
        SCMPurchaseOrder _oSCMPurchaseOrder;
        public frmUploaderforPackQty()
        {
            InitializeComponent();
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

        private bool validateUIInput()
        {
            if (dgvSCMPSIItem.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public void Save()
        {
            if (rbAddPlan.Checked == true)
            {
                SCMSalesPlanItem plan = new SCMSalesPlanItem();
                plan.DeleteSalesPack();

            }
            //else
            //{
            //    SCMSalesPlanItem plan = new SCMSalesPlanItem();
            //    plan.DeleteSales();

            //}

            int i = 0;
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DataGridViewRow oDGVRow;
            DBController.Instance.BeginNewTransaction();
            try
            {
                SCMSalesPlanItem plan = new SCMSalesPlanItem();

                foreach (DataGridViewRow oRow in dgvSCMPSIItem.Rows)
                {


                    plan.TranID = Convert.ToInt32(oRow.Cells[0].Value);
                    plan.ProductCode = oRow.Cells[1].Value.ToString();
                    plan.DDate = DateTime.Parse(oRow.Cells[2].Value.ToString());
                    plan.InnerCode= oRow.Cells[3].Value.ToString();
                    plan.InnerQty = Convert.ToInt32(oRow.Cells[4].Value);
                    plan.OuterCode = oRow.Cells[5].Value.ToString();
                    plan.OuterQty = Convert.ToInt32(oRow.Cells[6].Value);

                    //  plan.DDate = Convert.ToDateTime(oRow.Cells[2].Value);
                    


                    if (rbAddPlan.Checked == true)
                    {

                        plan.AddSalesPack();
                    }
                    //else
                    //{

                    //    plan.AddSales();
                    //}
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
            MessageBox.Show(" Data save successfully \n Total Inserted Data " + nCount + "");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //bool IsSelected = false;
            //this.openFileDialog1.FileName = "";
            //this.openFileDialog1.Multiselect = false;
            //this.openFileDialog1.Filter = "";
            //this.openFileDialog1.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls";
            //if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    this.txtXLFilePath.Text = this.openFileDialog1.FileName.ToString();
            ////    this.Text = this.openFileDialog1.DefaultExt.ToString();
            ////    IsSelected = true;
            //}

            //if (IsSelected)
            //{
            //    LoadSheets();
            //}
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();
            OleDbDataAdapter oDataAdapter;
            oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            dgvSCMPSIItem.DataSource = _oDT.DefaultView;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";
            dgvSCMPSIItem.ReadOnly = true;


        }

        private void dgvSCMPSIItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbAddPlan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAddPlan.Checked == true)
            {
                rbAddSales.Checked = false;
            }
        }

        private void txtXLFilePath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
