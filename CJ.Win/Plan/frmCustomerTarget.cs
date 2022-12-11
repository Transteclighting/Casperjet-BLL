using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Plan;
using CJ.Class.Library;

namespace CJ.Win.Plan
{
    public partial class frmCustomerTarget : Form
    {
        private DataTable _oDT;
        int nCount = 0;
        TELLib _oTELLib;
        Showroom _oShowroom;

        public frmCustomerTarget()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }

        }
        private bool UIValidation()
        {
            if (txtVersionName.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Version Name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVersionName.Focus();
                return false;
            }
            if (_oDT.Rows.Count == 0)
            {
                MessageBox.Show("There is no Data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerTarget_Load(object sender, EventArgs e)
        {
            pbInvoice.Visible = false;
            lblColumnHead.Text = "Excel Field: TYear, TMonth, WeekNo, CustomerID, OldCustomer,NewCustomer";
            lblColumnHead.Refresh();
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
            this.dgvData.DataSource = _oDT.DefaultView;
            
            lblTotalNew.Text = "0";
            lblTotalOld.Text = "0";
            _oTELLib = new TELLib();

            foreach (DataRow oRow in _oDT.Rows)
            {
                lblTotalNew.Text = Convert.ToDouble(Convert.ToDouble(lblTotalNew.Text) + Convert.ToDouble(oRow[5])).ToString();
                lblTotalOld.Text = Convert.ToDouble(Convert.ToDouble(lblTotalOld.Text) + Convert.ToDouble(oRow[4])).ToString();
            }

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
            try
            {
                PlanBudgetTargetVersion oPlanBudgetTargetVersion = new PlanBudgetTargetVersion();
                if (_oDT.Rows.Count > 0)
                {
                    pbInvoice.Visible = true;
                    oPlanBudgetTargetVersion.VersionName = txtVersionName.Text.Trim();
                    oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.CustomerTargetQty;
                    oPlanBudgetTargetVersion.Status = (int)Dictionary.PlanVersionStatus.Submit;
                    oPlanBudgetTargetVersion.Remarks = txtRemarks.Text;
                    oPlanBudgetTargetVersion.VersionDate = DateTime.Now.Date;
                    oPlanBudgetTargetVersion.CreateDate = DateTime.Now;
                    oPlanBudgetTargetVersion.CreateUserID = Utility.UserId;
                    oPlanBudgetTargetVersion.Add();
                }
                foreach (DataRow oRow in _oDT.Rows)
                {

                    int nYear = Convert.ToInt32(oRow[0]);
                    int nMonth = Convert.ToInt32(oRow[1]);
                    int nWeekNo = Convert.ToInt32(oRow[2]);
                    string sShowroomCode = Convert.ToString(oRow[3]);
                    _oShowroom = new Showroom();
                    _oShowroom.GetShowroomByCode(sShowroomCode);
                    int nOldCustomer = Convert.ToInt32(oRow[4]);
                    int nNewCustomer = Convert.ToInt32(oRow[5]);

                    PlanCustomerTarget oPlanCustomerTarget = new PlanCustomerTarget();
                    oPlanCustomerTarget.TYear = nYear;
                    oPlanCustomerTarget.TMonth = nMonth;
                    oPlanCustomerTarget.WeekNo = nWeekNo;
                    oPlanCustomerTarget.CustomerID = _oShowroom.CustomerID;
                    oPlanCustomerTarget.OldCustomer = nOldCustomer;
                    oPlanCustomerTarget.NewCustomer = nNewCustomer;
                    oPlanCustomerTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                    oPlanCustomerTarget.Add();
                    oDGVRow = dgvData.Rows[i];
                    oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;

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