using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.DMS;
using CJ.Win.Security;

using CJ.Class.Library;




namespace CJ.Win.Replace_Management
{
    public partial class frmTPorKPISettlement : Form
    {
        ClaimSettlements oClaimSettlements = new ClaimSettlements();
        ClaimSettlement ooClaimSettlement = new ClaimSettlement();
        private DataTable _oDT;
        int nCount = 0;
        int nErrorCount = 0;
       // Customer oCustomer;


        public frmTPorKPISettlement()
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

            if (cmbCustTranType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCustTranType.Focus();
                return false;
            }


            if (_oDT.Rows.Count == 0)
            {
                MessageBox.Show("There is no Data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }



        private void Save()
        {
            int i = 0;
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DataGridViewRow oDGVRow;

            DBController.Instance.BeginNewTransaction();

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                string sCustCode = "";
                sCustCode = oItemRow.Cells[3].Value.ToString();

                //oCustomer = new Customer();
                ooClaimSettlement = new ClaimSettlement();
                ooClaimSettlement.CustomerCode = sCustCode;
                ooClaimSettlement.RefreshByCode();

                oItemRow.Cells[3].Value = ooClaimSettlement.CustomerID.ToString();

            }
            try
                {
                    ClaimSettlement oClaimSettlement = new ClaimSettlement();
                    if (_oDT.Rows.Count > 0)
                    {
                        if (cmbCustTranType.SelectedIndex == (int)Dictionary.TPorKPISettlement.TP)
                            oClaimSettlement.ClaimType = (int)Dictionary.TPorKPISettlement.TP;
                        else if (cmbCustTranType.SelectedIndex == (int)Dictionary.TPorKPISettlement.KPI)
                            oClaimSettlement.ClaimType = (int)Dictionary.TPorKPISettlement.KPI;

                    }
                    foreach (DataRow oRow in _oDT.Rows)
                    {
                        if (cmbCustTranType.SelectedIndex == (int)Dictionary.TPorKPISettlement.TP)
                        {
                            string sRegionName = Convert.ToString(oRow[0]);
                            string sAreaName = Convert.ToString(oRow[1]);
                            string sTerritoryName = Convert.ToString(oRow[2]);
                            string sCustomerCode = Convert.ToString(oRow[3]);
                            string sCustomerName = Convert.ToString(oRow[4]);
                            string sCustomerTypeName = Convert.ToString(oRow[5]);
                            DateTime dClaimDate = Convert.ToDateTime(oRow[6]);
                            int nClaimType = Convert.ToInt32(oRow[7]);
                            DateTime dSettlementDate = Convert.ToDateTime(oRow[8]);
                            string sSettlementType = Convert.ToString(oRow[9]);
                            string sRemarks = Convert.ToString(oRow[10]);
                        int nInvoiceID = Convert.ToInt32(oRow[11]);


                        ClaimSettlement ooClaimSettlement = new ClaimSettlement();

                            ooClaimSettlement.RegionName = sRegionName;
                            ooClaimSettlement.AreaName = sAreaName;
                            ooClaimSettlement.TerritoryName = sTerritoryName;
                            ooClaimSettlement.CustomerCode = sCustomerCode;
                            ooClaimSettlement.CustomerName = sCustomerName;
                            ooClaimSettlement.CustomerTypeName = sCustomerTypeName;
                            ooClaimSettlement.ClaimDate = dClaimDate;
                            ooClaimSettlement.ClaimType = nClaimType;
                            ooClaimSettlement.SettlementDate = dSettlementDate;
                            ooClaimSettlement.SettlementType = sSettlementType;
                            ooClaimSettlement.Remarks = sRemarks;
                            ooClaimSettlement.InvoiceID = nInvoiceID;
                            ooClaimSettlement.Add(sCustomerCode);
                        }
                        else if (cmbCustTranType.SelectedIndex == (int)Dictionary.TPorKPISettlement.KPI)
                        {
                            string sRegionName = Convert.ToString(oRow[0]);
                            string sAreaName = Convert.ToString(oRow[1]);
                            string sTerritoryName = Convert.ToString(oRow[2]);
                            string sCustomerCode = Convert.ToString(oRow[3]);
                            string sCustomerName = Convert.ToString(oRow[4]);
                            string sCustomerTypeName = Convert.ToString(oRow[5]);
                            DateTime dClaimDate = Convert.ToDateTime(oRow[6]);
                            int nClaimType = Convert.ToInt32(oRow[7]);
                            DateTime dSettlementDate = Convert.ToDateTime(oRow[8]);
                            string sSettlementType = Convert.ToString(oRow[9]);
                            string sRemarks = Convert.ToString(oRow[10]);
                            int nInvoiceID = Convert.ToInt32(oRow[11]);

                        ClaimSettlement ooClaimSettlement = new ClaimSettlement();

                            ooClaimSettlement.RegionName = sRegionName;
                            ooClaimSettlement.AreaName = sAreaName;
                            ooClaimSettlement.TerritoryName = sTerritoryName;
                            ooClaimSettlement.CustomerCode = sCustomerCode;
                            ooClaimSettlement.CustomerName = sCustomerName;
                            ooClaimSettlement.CustomerTypeName = sCustomerTypeName;
                            ooClaimSettlement.ClaimDate = dClaimDate;
                            ooClaimSettlement.ClaimType = nClaimType;
                            ooClaimSettlement.SettlementDate = dSettlementDate;
                            ooClaimSettlement.SettlementType = sSettlementType;
                            ooClaimSettlement.Remarks = sRemarks;
                            ooClaimSettlement.InvoiceID = nInvoiceID;

                        ooClaimSettlement.Add(sCustomerCode);
                        }

                        oDGVRow = dgvLineItem.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;

                        dgvLineItem.Refresh();

                        i = i + 1;
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            //this.openFileDialogData.Filter = "Text File(*.txt;)|*.txt;| File(*.TXT;)|*.TXT;|All Files(*.*;)|*.*";
            this.openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtXLFilePath.Text = this.openFileDialogData.FileName.ToString();
                this.Text = this.openFileDialogData.DefaultExt.ToString();
            }

            LoadSheets();

        }

        private void LoadSheets()
        {
           

            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();
            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Raw$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);

            this.dgvLineItem.DataSource = _oDT.DefaultView;
            
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

        }

        private void RemoveColumn()
        {
            try
            {
                dgvLineItem.Columns.RemoveAt(5);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(4);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(3);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(2);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(1);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(0);
            }
            catch
            {
            }

        }

        public void LoadCombo()
        {
            cmbCustTranType.Items.Add("<Select Type>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.TPorKPISettlement)))
            {
                cmbCustTranType.Items.Add(Enum.GetName(typeof(Dictionary.TPorKPISettlement), GetEnum));
            }
            cmbCustTranType.SelectedIndex = 0;

            //oClaimSettlements = new ClaimSettlements();
            //oClaimSettlements.RefreshClaimType();
            //cmbCustTranType.Items.Add("-- Select --");
            //foreach (ClaimSettlement oClaimSettlement in oClaimSettlements)
            //{
            //    cmbCustTranType.Items.Add(oClaimSettlement.SettlementType);
            //}
            //cmbCustTranType.SelectedIndex = 0;
        }

        private void frmTPorKPISettlement_Load(object sender, EventArgs e)
        {
           // btnProcess.Enabled = false;
           // btnSave.Enabled = false;
            DBController.Instance.OpenNewConnection();
            LoadCombo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (cmbCustTranType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Tran Type ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AddColumnsProgrammatically();
            Process();
           // btnProcess.Enabled = false;
        }

        private void AddColumnsProgrammatically()
        {
            try
            {
                dgvLineItem.Columns.RemoveAt(4);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(3);
            }
            catch
            {
            }

            DataGridViewButtonColumn col3 = new DataGridViewButtonColumn();
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();

            col3.HeaderText = "Affected Invoices";
            col3.Name = "btnAffectedInvoices";

            col4.HeaderText = "Customer ID";
            col4.Name = "CustomerID";

            col5.HeaderText = "Remarks";
            col5.Name = "Remarks";

            //dgvLineItem.Columns.AddRange(new DataGridViewColumn[] { col3});
            //dgvLineItem.Columns.AddRange(new DataGridViewColumn[] { col3 });
            //dgvLineItem.Columns.AddRange(new DataGridViewColumn[] { col4 });

            dgvLineItem.Columns.Add(col3);
            dgvLineItem.Columns.Add(col4);
            dgvLineItem.Columns.Add(col5);

            dgvLineItem.Columns["CustomerID"].Visible = false;
            //dvgProduct.Rows[e.RowIndex].Cells[5].Value
        }

        private void Process()
        {
            nErrorCount = 0;
            int i = 0;
            DataGridViewRow oDGVRow;
            double _TotalAmount = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                string sCustCode = "";
                sCustCode = oItemRow.Cells[0].Value.ToString();

                //oCustomer = new Customer();
                ooClaimSettlement = new ClaimSettlement();
                ooClaimSettlement.CustomerCode = sCustCode;
                //ooClaimSettlement.RefreshByCode();

                oItemRow.Cells[4].Value = ooClaimSettlement.CustomerID.ToString();

                oDGVRow = dgvLineItem.Rows[i];
                if (ooClaimSettlement.CustomerID != 0)
                {
                    oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    oItemRow.Cells[5].Value = "Ok";

                    double _Amt;
                    try
                    {
                        _Amt = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        oItemRow.Cells[5].Value = "Ok";
                        int nTranSide = 0;
                        nTranSide = oClaimSettlements[cmbCustTranType.SelectedIndex - 1].InvoiceTypeID;
                        if (nTranSide == (int)Dictionary.TPorKPISettlement.TP)
                        {
                            oItemRow.Cells[3].Value = Convert.ToString(AutomaticSelection(ooClaimSettlement.CustomerID, _Amt));
                        }
                        else
                        {
                            oItemRow.Cells[3].Value = "N/A";
                        }
                    }
                    catch
                    {
                        _Amt = 0;

                        oDGVRow = dgvLineItem.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.Red;
                        oItemRow.Cells[5].Value = "Amount Not in a Correct Format!!";
                        oItemRow.Cells[3].Value = "0";
                        oItemRow.Cells[4].Value = "0";
                        nErrorCount++;
                    }
                    _TotalAmount = _TotalAmount + _Amt;
                }
                else
                {
                    oDGVRow.DefaultCellStyle.BackColor = Color.Red;
                    oItemRow.Cells[5].Value = "Customer Code Error!!";
                    oItemRow.Cells[3].Value = "0";
                    nErrorCount++;
                }

                dgvLineItem.Refresh();

                i = i + 1;
                pbInvoice.Value = i;

            }

            if (nErrorCount == 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                MessageBox.Show("Total: " + nErrorCount + " No(s): Error Founded!!\nPlease Check before save ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbCustTranType.Enabled = false;
        }

        private int AutomaticSelection(int nCustomerID, double _Amount)
        {
            int nCount = 0;
            SalesInvoices _oSalesInvoices = new SalesInvoices();
            _oSalesInvoices.GetDueAmountByCustomerID(nCustomerID);

            foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
            {
                if (_Amount > 0)
                {
                    if (oSalesInvoice.DueAmount > _Amount)
                    {
                        _Amount = 0;
                        nCount++;
                    }
                    else
                    {
                        _Amount = _Amount - oSalesInvoice.DueAmount;
                        nCount++;
                    }
                }
            }
            return nCount;
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbCustTranType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustTranType.SelectedIndex == (int)Dictionary.TPorKPISettlement.TP)
            {
                lblColumnHead.Text = "Excel Field: RegionName,	AreaName, TerritoryName,	CustomerCode,	CustomerName,	CustomerTypeName,ClaimDate,ClaimType,SettlementDate,	SettlementType,	Remarks";
                lblColumnHead.Refresh();

            }
            else if (cmbCustTranType.SelectedIndex == (int)Dictionary.TPorKPISettlement.KPI)
            {
                lblColumnHead.Text = "Excel Field: RegionName,	AreaName, TerritoryName,	CustomerCode,	CustomerName,	CustomerTypeName,ClaimDate,ClaimType,SettlementDate,	SettlementType,	Remarks";
                lblColumnHead.Refresh();

            }           
        }
    }
}
