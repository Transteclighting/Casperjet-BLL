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
    public partial class frmPlanDealerMAGTarget : Form
    {
        PlanDealerMAGTarget oPlanDealerMAGTarget;
        PlanBudgetTargetVersion oPlanBudgetTargetVersion;
        private DataTable _oDT;
        int nCount = 0;
        int _nStatus = 0;
        public bool _Istrue = false;
        public frmPlanDealerMAGTarget(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }

        private void frmPlanDealerMAGTarget_Load(object sender, EventArgs e)
        {
            pbMAGTarget.Visible = false;
            lblColumnHead.Text = "Excel Field:TYear,TMonth,Week,ShowroomID,CustomerID,MAGID,BrandID,TargetQty,TargetValue";
            lblColumnHead.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UIValidation()
        {           
            if (_oDT.Rows.Count == 0)
            {
                MessageBox.Show("There is no Data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

        }
        private void Save()
        {            
            int i = 0;
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DataGridViewRow oDGVRow;
            pbMAGTarget.Maximum = _oDT.Rows.Count;
            DBController.Instance.BeginNewTransaction();

            oPlanBudgetTargetVersion = new PlanBudgetTargetVersion();
            oPlanBudgetTargetVersion.VersionName = txtVersionName.Text;
            oPlanBudgetTargetVersion.VersionDate = DateTime.Now.Date;
            oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.PlanDealerMAGTarget;
            if (_nStatus == (int)Dictionary.PlanVersionStatus.Submit)
            {
                oPlanBudgetTargetVersion.Status = (int)Dictionary.PlanVersionStatus.Submit;
            }
            oPlanBudgetTargetVersion.Remarks = txtRemarks.Text;
            oPlanBudgetTargetVersion.CreateUserID = Utility.UserId;
            oPlanBudgetTargetVersion.CreateDate = DateTime.Now;
            oPlanBudgetTargetVersion.Add();

            foreach (DataRow oRow in _oDT.Rows)
            {
                try
                {
                    pbMAGTarget.Visible = true;
                    //int sVersionNo = Convert.ToInt32(oRow[0].ToString());
                    int nTyear = Convert.ToInt32(oRow[0].ToString());
                    int nTMonth = Convert.ToInt32(oRow[1].ToString());
                    int nWeekno = Convert.ToInt32(oRow[2].ToString());
                    int nShowroomID = Convert.ToInt32(oRow[3].ToString());
                    int nCustomerID = Convert.ToInt32(oRow[4].ToString());
                    int nMAGID = Convert.ToInt32(oRow[5].ToString());
                    int nBrandID = Convert.ToInt32(oRow[6].ToString());
                    int nTGtQty = Convert.ToInt32(oRow[7].ToString());
                    double nAmount = Convert.ToDouble(oRow[8].ToString());

                    PlanDealerMAGTarget oPlanDealerMAGTarget = new PlanDealerMAGTarget();
                    //oPlanDealerMAGTarget.VersionNo = sVersionNo;
                    oPlanDealerMAGTarget.TYear= nTyear;
                    oPlanDealerMAGTarget.TMonth = nTMonth;
                    oPlanDealerMAGTarget.WeekNo = nWeekno;
                    oPlanDealerMAGTarget.ShowroomID = nShowroomID;
                    oPlanDealerMAGTarget.CustomerID = nCustomerID;
                    oPlanDealerMAGTarget.MAGID = nMAGID;
                    oPlanDealerMAGTarget.BrandID = nBrandID;
                    oPlanDealerMAGTarget.TargetQty = nTGtQty;
                    oPlanDealerMAGTarget.TargetValue = nAmount;

                    oPlanDealerMAGTarget.Add();
                    oDGVRow = dgvData.Rows[i];
                    oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    nCount++;

                    oDGVRow = dgvData.Rows[i];
                    oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;

                    dgvData.Refresh();

                    i = i + 1;
                    pbMAGTarget.Value = i;
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
    }
}
