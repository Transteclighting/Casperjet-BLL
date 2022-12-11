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

using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmSparePartsUploader : Form

    {
        SparePartsR oSparePartsR;
        private DataTable _oDT;
        int nCount = 0;
        int _nStatus = 0;
        public bool _Istrue = false;
        public frmSparePartsUploader()
        {
            InitializeComponent();
        }

        private void frmSparePartsUploader_Load(object sender, EventArgs e)
        {
            pbSpareParts.Visible = false;
            lblColumnHead.Text = "Excel Field:Code,Name,ModelNo,CostPrice,SalePrice,IsActive,ReorderLevel,LocationID,SPGroupID,AGID,BrandID,SupplierPartCode";
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
            pbSpareParts.Maximum = _oDT.Rows.Count;
            DBController.Instance.BeginNewTransaction();

            //oPlanBudgetTargetVersion = new PlanBudgetTargetVersion();
            //oPlanBudgetTargetVersion.VersionName = txtVersionName.Text;
            //oPlanBudgetTargetVersion.VersionDate = DateTime.Now.Date;
            //oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.PlanDealerMAGTarget;
            //if (_nStatus == (int)Dictionary.PlanVersionStatus.Submit)
            //{
            //    oPlanBudgetTargetVersion.Status = (int)Dictionary.PlanVersionStatus.Submit;
            //}
            //oPlanBudgetTargetVersion.Remarks = txtRemarks.Text;
            //oPlanBudgetTargetVersion.CreateUserID = Utility.UserId;
            //oPlanBudgetTargetVersion.CreateDate = DateTime.Now;
            //oPlanBudgetTargetVersion.Add();

            foreach (DataRow oRow in _oDT.Rows)
            {
                try
                {
                    pbSpareParts.Visible = true;
                    string sCode = oRow[0].ToString();
                    string sName = oRow[1].ToString();
                    string sModelNo = oRow[2].ToString();
                    double nCostprice = Convert.ToDouble(oRow[3].ToString());
                    double nSaleprice = Convert.ToDouble(oRow[4].ToString());
                    int nIsActive = Convert.ToInt32(oRow[5].ToString());
                    int nReorderLevel = Convert.ToInt32(oRow[6].ToString());
                    int nLocationID = Convert.ToInt32(oRow[7].ToString());
                    int nSPGroupID = Convert.ToInt32(oRow[8].ToString());
                    int nAGID = Convert.ToInt32(oRow[9].ToString());
                    int nBrandID = Convert.ToInt32(oRow[10].ToString());
                    string sSupplierPartCode = oRow[11].ToString();

                    SparePartsR oSparePartsR = new SparePartsR();
                    //oSparePartsR.VersionNo = sVersionNo;
                    oSparePartsR.Code = sCode;
                    oSparePartsR.Name = sName;
                    oSparePartsR.ModelNo = sModelNo;
                    oSparePartsR.CostPrice = nCostprice;
                    oSparePartsR.SalePrice = nSaleprice;
                    oSparePartsR.IsActive = nIsActive;
                    oSparePartsR.ReorderLevel = nReorderLevel;
                    oSparePartsR.LocationID = nLocationID;
                    oSparePartsR.SPGroupID = nSPGroupID;
                    oSparePartsR.AGID = nAGID;
                    oSparePartsR.BrandID = nBrandID;
                    oSparePartsR.CreateUserID = Utility.UserId;
                    oSparePartsR.CreateDate = DateTime.Now;
                    oSparePartsR.SupplierPartCode = sSupplierPartCode;

                    if (!oSparePartsR.RefreshBySparePartCode())
                    {
                        oSparePartsR.Add();
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    oDGVRow = dgvData.Rows[i];
                    oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    nCount++;

                    oDGVRow = dgvData.Rows[i];
                    oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;

                    dgvData.Refresh();

                    i = i + 1;
                    pbSpareParts.Value = i;
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
