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

namespace CJ.Win.Plan
{
    public partial class frmPlanBudgetTragetUploader : Form
    {
        private DataTable _oDT;
        int nCount = 0;
        public frmPlanBudgetTragetUploader()
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
            if (cmbType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Type","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbType.Focus();
                return false;
            }
            if (txtVersionName.Text.Trim()=="")
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
        private void frmPlanBudgetTragetUploader_Load(object sender, EventArgs e)
        {
            LoadCombo();
            lblTotalQty.Visible = false;
            pbInvoice.Visible = false;
            lblColumnHead.Text = "";


            lblTotal.Visible = false;


            lblS1Qty.Visible = false;
            lblS1Value.Visible = false;
            lblS2Qty.Visible = false;
            lblS2Value.Visible = false;
            lblS3Qty.Visible = false;
            lblS3Value.Visible = false;


            lblSlab1Qty.Visible = false;
            lblSlab1Value.Visible = false;
            lblSlab2Qty.Visible = false;
            lblSlab2Value.Visible = false;
            lblSlab3Qty.Visible = false;
            lblSlab3Value.Visible = false;

        }
        private void LoadCombo()
        {
            cmbType.Items.Add("<Select>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PlanVersionType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.PlanVersionType), GetEnum));
            }
            cmbType.SelectedIndex = 0;
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
            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Raw$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            double _Amount = 0;
            int nTotalQty = 0;

            int _nS1Qty = 0;
            double _S1Value = 0;
            int _nS2Qty = 0;
            double _S2Value = 0;
            int _nS3Qty = 0;
            double _S3Value = 0;



            this.dgvData.DataSource = _oDT.DefaultView;
            foreach (DataRow oRow in _oDT.Rows)
            {
                try
                {
                    if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveWeekTarget)
                    {
                        _Amount = _Amount + Convert.ToDouble(oRow[6]);
                    }
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.PGWiseTargetValue)
                    {
                        _Amount = _Amount + Convert.ToDouble(oRow[4]);
                    }
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
                    {
                        nTotalQty = nTotalQty + Convert.ToInt32(oRow[6]);
                    }
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
                    {
                        _Amount = _Amount + Convert.ToDouble(oRow[8]);
                        nTotalQty = nTotalQty + Convert.ToInt32(oRow[7]);
                        lblTotalQty.Visible = true;
                    }
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
                    {
                        _Amount = _Amount + Convert.ToDouble(oRow[8]);
                        nTotalQty = nTotalQty + Convert.ToInt32(oRow[7]);
                        lblTotalQty.Visible = true;
                    }
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.OpportunityTarget)
                    {
                        _nS1Qty = _nS1Qty + Convert.ToInt32(oRow[5]);
                        _S1Value = _S1Value + Convert.ToDouble(oRow[6]);
                        _nS2Qty = _nS2Qty + Convert.ToInt32(oRow[7]);
                        _S2Value = _S2Value + Convert.ToDouble(oRow[8]);
                        _nS3Qty = _nS3Qty + Convert.ToInt32(oRow[9]);
                        _S3Value = _S3Value + Convert.ToDouble(oRow[10]);

                    }
                }
                catch
                {
                    if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
                    {
                        nTotalQty = nTotalQty + 0;
                    }
                    else
                    {
                        _Amount = _Amount + 0;
                    }
                }
            }
            if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
            {
                lblTotal.Text = "Total Qty:" + nTotalQty.ToString();
            }
            else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
            {
                lblTotalQty.Text = "Total Qty:" + nTotalQty.ToString();
                lblTotal.Text = "Total Amount:" + _Amount.ToString();
            }
            else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
            {
                lblTotalQty.Text = "Total Qty:" + nTotalQty.ToString();
                lblTotal.Text = "Total Amount:" + _Amount.ToString();
            }
            else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.OpportunityTarget)
            {
                lblSlab1Qty.Text = _nS1Qty.ToString();
                lblSlab1Value.Text = _S1Value.ToString();
                lblSlab2Qty.Text = _nS2Qty.ToString();
                lblSlab2Value.Text = _S2Value.ToString();
                lblSlab3Qty.Text = _nS3Qty.ToString();
                lblSlab3Value.Text = _S2Value.ToString();
            }
            else
            {
                lblTotal.Text = "Total Amount:" + _Amount.ToString();
            }
            pbInvoice.Maximum = _oDT.Rows.Count;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

        }
        private void Save()
        {
            int nTargetType=0;
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
                    if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveWeekTarget)
                        oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.ExecutiveWeekTarget;
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
                        oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.MAGWiseTargetQty;
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.PGWiseTargetValue)
                        oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.PGWiseTargetValue;
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
                        oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.ExecutiveLeadTarget;
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
                        oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty;
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.OpportunityTarget)
                        oPlanBudgetTargetVersion.Type = (int)Dictionary.PlanVersionType.OpportunityTarget;

                    nTargetType = oPlanBudgetTargetVersion.Type;
                    oPlanBudgetTargetVersion.Status = (int)Dictionary.PlanVersionStatus.Submit;
                    oPlanBudgetTargetVersion.Remarks = txtRemarks.Text;
                    oPlanBudgetTargetVersion.VersionDate = DateTime.Now.Date;
                    oPlanBudgetTargetVersion.CreateDate = DateTime.Now;
                    oPlanBudgetTargetVersion.CreateUserID = Utility.UserId;
                    oPlanBudgetTargetVersion.Add();
                    //SendSMS(oPlanBudgetTargetVersion.VersionName);
                }
                foreach (DataRow oRow in _oDT.Rows)
                {
                    if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveWeekTarget)
                    {
                        int nYear = Convert.ToInt32(oRow[0]);
                        int nMonth = Convert.ToInt32(oRow[1]);
                        int nWeek = Convert.ToInt32(oRow[2]);
                        int nCustomerID = Convert.ToInt32(oRow[3]);
                        int nSalesPersonID = Convert.ToInt32(oRow[4]);
                        string sCategory = Convert.ToString(oRow[5]);
                        double _TAmount = Convert.ToDouble(oRow[6]);

                        PlanExecutiveWeekTarget oPlanExecutiveWeekTarget = new PlanExecutiveWeekTarget();
                        oPlanExecutiveWeekTarget.TYear = nYear;
                        oPlanExecutiveWeekTarget.TMonth = nMonth;
                        oPlanExecutiveWeekTarget.WeekNo = nWeek;
                        oPlanExecutiveWeekTarget.CustomerID = nCustomerID;
                        oPlanExecutiveWeekTarget.SalesPersonID = nSalesPersonID;
                        oPlanExecutiveWeekTarget.Category = sCategory;
                        oPlanExecutiveWeekTarget.TargetAmount = _TAmount;

                        oPlanExecutiveWeekTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                        oPlanExecutiveWeekTarget.Add();
                    }
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
                    {
                        int nYear = Convert.ToInt32(oRow[0]);
                        int nMonth = Convert.ToInt32(oRow[1]);
                        int nWeek = Convert.ToInt32(oRow[2]);
                        int nCustomerID = Convert.ToInt32(oRow[3]);
                        int nMAGID = Convert.ToInt32(oRow[4]);
                        int nBrandID = Convert.ToInt32(oRow[5]);
                        int nTargetQty = Convert.ToInt32(oRow[6]);
                        double _TargetValue = Convert.ToDouble(oRow[7]);
                        string _sChannel = Convert.ToString(oRow[8]);

                        PlanMAGWeekQtyTarget oPlanMAGWeekQtyTarget = new PlanMAGWeekQtyTarget();

                        oPlanMAGWeekQtyTarget.TYear = nYear;
                        oPlanMAGWeekQtyTarget.TMonth = nMonth;
                        oPlanMAGWeekQtyTarget.WeekNo = nWeek;
                        oPlanMAGWeekQtyTarget.CustomerID = nCustomerID;
                        oPlanMAGWeekQtyTarget.MAGID = nMAGID;
                        oPlanMAGWeekQtyTarget.BrandID = nBrandID;
                        oPlanMAGWeekQtyTarget.TargetQty = nTargetQty;
                        oPlanMAGWeekQtyTarget.TargetValue = _TargetValue;
                        oPlanMAGWeekQtyTarget.Channel = _sChannel;
                        oPlanMAGWeekQtyTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                        oPlanMAGWeekQtyTarget.Add();
                    }
                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.PGWiseTargetValue)
                    {
                        int nYear = Convert.ToInt32(oRow[0]);
                        int nMonth = Convert.ToInt32(oRow[1]);
                        int nCustomerID = Convert.ToInt32(oRow[2]);
                        int nPGID = Convert.ToInt32(oRow[3]);
                        double _TAmount = Convert.ToDouble(oRow[4]);

                        PlanPGMonthValueTarget oPlanPGMonthValueTarget = new PlanPGMonthValueTarget();

                        oPlanPGMonthValueTarget.TYear = nYear;
                        oPlanPGMonthValueTarget.TMonth = nMonth;
                        oPlanPGMonthValueTarget.CustomerID = nCustomerID;
                        oPlanPGMonthValueTarget.PGID = nPGID;
                        oPlanPGMonthValueTarget.TargetAmount = _TAmount;

                        oPlanPGMonthValueTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                        oPlanPGMonthValueTarget.Add();
                    }

                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
                    {
                        int nYear = Convert.ToInt32(oRow[0]);
                        int nMonth = Convert.ToInt32(oRow[1]);
                        int nWeek = Convert.ToInt32(oRow[2]);
                        int nCustomerID = Convert.ToInt32(oRow[3]);
                        int nSalesPersonID = Convert.ToInt32(oRow[4]);

                        int nMAGID = Convert.ToInt32(oRow[5]);
                        int nBrandID = Convert.ToInt32(oRow[6]);
                        int nTargetQty = Convert.ToInt32(oRow[7]);
                        double _TAmount = Convert.ToDouble(oRow[8]);
                        int nChannel = Convert.ToInt32(oRow[9]);
                        

                        PlanExecutiveWeekTarget oPlanExecutiveWeekTarget = new PlanExecutiveWeekTarget();

                        oPlanExecutiveWeekTarget.TYear = nYear;
                        oPlanExecutiveWeekTarget.TMonth = nMonth;
                        oPlanExecutiveWeekTarget.WeekNo = nWeek;
                        oPlanExecutiveWeekTarget.CustomerID = nCustomerID;
                        oPlanExecutiveWeekTarget.SalesPersonID = nSalesPersonID;

                        oPlanExecutiveWeekTarget.MAGID = nMAGID;
                        oPlanExecutiveWeekTarget.BrandID = nBrandID;
                        oPlanExecutiveWeekTarget.TargetQty = nTargetQty;
                        oPlanExecutiveWeekTarget.TargetAmount = _TAmount;
                        oPlanExecutiveWeekTarget.ChannelID = nChannel;
                        oPlanExecutiveWeekTarget.TargetType = nTargetType;

                        oPlanExecutiveWeekTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                        oPlanExecutiveWeekTarget.AddLeadTarget();

                    }

                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
                    {
                        int nYear = Convert.ToInt32(oRow[0]);
                        int nMonth = Convert.ToInt32(oRow[1]);
                        int nWeek = Convert.ToInt32(oRow[2]);
                        int nCustomerID = Convert.ToInt32(oRow[3]);
                        int nSalesPersonID = Convert.ToInt32(oRow[4]);

                        int nMAGID = Convert.ToInt32(oRow[5]);
                        int nBrandID = Convert.ToInt32(oRow[6]);
                        int nTargetQty = Convert.ToInt32(oRow[7]);
                        double _TAmount = Convert.ToDouble(oRow[8]);
                        int nChannel = Convert.ToInt32(oRow[9]);


                        PlanExecutiveWeekTarget oPlanExecutiveWeekTarget = new PlanExecutiveWeekTarget();

                        oPlanExecutiveWeekTarget.TYear = nYear;
                        oPlanExecutiveWeekTarget.TMonth = nMonth;
                        oPlanExecutiveWeekTarget.WeekNo = nWeek;
                        oPlanExecutiveWeekTarget.CustomerID = nCustomerID;
                        oPlanExecutiveWeekTarget.SalesPersonID = nSalesPersonID;

                        oPlanExecutiveWeekTarget.MAGID = nMAGID;
                        oPlanExecutiveWeekTarget.BrandID = nBrandID;
                        oPlanExecutiveWeekTarget.TargetQty = nTargetQty;
                        oPlanExecutiveWeekTarget.TargetAmount = _TAmount;
                        oPlanExecutiveWeekTarget.ChannelID = nChannel;
                        oPlanExecutiveWeekTarget.TargetType = nTargetType;

                        oPlanExecutiveWeekTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                        oPlanExecutiveWeekTarget.AddLeadTarget();

                    }

                    else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.OpportunityTarget)
                    {

                        Showroom oShowroom = new Showroom();
                        oShowroom.GetShowroomByCode(oRow[2].ToString());

                        ProductGroup oMAG = new ProductGroup();
                        oMAG.GetByName(oRow[3].ToString(), (int)Dictionary.ProductGroupType.MAG);

                        Brand oBrand = new Brand();
                        oBrand.GetBrandByName(oRow[4].ToString());

                        PlanExecutiveWeekTarget oPlanOpportunityTarget = new PlanExecutiveWeekTarget();
                        oPlanOpportunityTarget.TYear = Convert.ToInt32(oRow[0]);
                        oPlanOpportunityTarget.TMonth = Convert.ToInt32(oRow[1]);
                        oPlanOpportunityTarget.CustomerID = oShowroom.CustomerID;
                        oPlanOpportunityTarget.MAGID = oMAG.PdtGroupID;
                        oPlanOpportunityTarget.BrandID = oBrand.BrandID;
                        oPlanOpportunityTarget.S1Qty = Convert.ToInt32(oRow[5]);
                        oPlanOpportunityTarget.S1Value = Convert.ToInt32(oRow[6]);
                        oPlanOpportunityTarget.S2Qty = Convert.ToInt32(oRow[7]);
                        oPlanOpportunityTarget.S2Value = Convert.ToInt32(oRow[8]);
                        oPlanOpportunityTarget.S3Qty = Convert.ToInt32(oRow[9]);
                        oPlanOpportunityTarget.S3Value = Convert.ToInt32(oRow[10]);
                        oPlanOpportunityTarget.VersionNo = oPlanBudgetTargetVersion.VersionNo;
                        oPlanOpportunityTarget.AddOpportunityTarget();

                    }
                    
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveWeekTarget)
            {
                lblColumnHead.Text = "Excel Field: TYear, TMonth, WeekNo, CustomerID, SalesPersonID,Category, Target Amount";
                lblColumnHead.Refresh();

                lblS1Qty.Visible = false;
                lblS1Value.Visible = false;
                lblS2Qty.Visible = false;
                lblS2Value.Visible = false;
                lblS3Qty.Visible = false;
                lblS3Value.Visible = false;


                lblSlab1Qty.Visible = false;
                lblSlab1Value.Visible = false;
                lblSlab2Qty.Visible = false;
                lblSlab2Value.Visible = false;
                lblSlab3Qty.Visible = false;
                lblSlab3Value.Visible = false;

            }
            else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.MAGWiseTargetQty)
            {
                lblColumnHead.Text = "Excel Field: TYear, TMonth, WeekNo, CustomerID, MAGID, BrandID, Target Qty, Target Value, Channel";
                lblColumnHead.Refresh();

                lblS1Qty.Visible = false;
                lblS1Value.Visible = false;
                lblS2Qty.Visible = false;
                lblS2Value.Visible = false;
                lblS3Qty.Visible = false;
                lblS3Value.Visible = false;


                lblSlab1Qty.Visible = false;
                lblSlab1Value.Visible = false;
                lblSlab2Qty.Visible = false;
                lblSlab2Value.Visible = false;
                lblSlab3Qty.Visible = false;
                lblSlab3Value.Visible = false;

            }
            else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
            {
                lblColumnHead.Text = "Excel Field: VersionNo,TYear, TMonth, WeekNo, CustomerID, SalesPersonID, MAGID, BrandID, TargetQty, TargetAmount, Channel";
                lblColumnHead.Refresh();

                lblS1Qty.Visible = false;
                lblS1Value.Visible = false;
                lblS2Qty.Visible = false;
                lblS2Value.Visible = false;
                lblS3Qty.Visible = false;
                lblS3Value.Visible = false;


                lblSlab1Qty.Visible = false;
                lblSlab1Value.Visible = false;
                lblSlab2Qty.Visible = false;
                lblSlab2Value.Visible = false;
                lblSlab3Qty.Visible = false;
                lblSlab3Value.Visible = false;

            }
            else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
            {
                lblColumnHead.Text = "Excel Field: VersionNo,TYear, TMonth, WeekNo, CustomerID, SalesPersonID, MAGID, BrandID, TargetQty, TargetAmount, Channel";
                lblColumnHead.Refresh();

                lblS1Qty.Visible = false;
                lblS1Value.Visible = false;
                lblS2Qty.Visible = false;
                lblS2Value.Visible = false;
                lblS3Qty.Visible = false;
                lblS3Value.Visible = false;


                lblSlab1Qty.Visible = false;
                lblSlab1Value.Visible = false;
                lblSlab2Qty.Visible = false;
                lblSlab2Value.Visible = false;
                lblSlab3Qty.Visible = false;
                lblSlab3Value.Visible = false;

            }
            else if (cmbType.SelectedIndex == (int)Dictionary.PlanVersionType.OpportunityTarget)
            {
                lblColumnHead.Text = "Excel Field: TYear, TMonth, ShowroomCode, MAG, Brand, Slab-1_Qty, Slab-1_Value, Slab-2_Qty, Slab-2_Value, Slab-3_Qty, Slab-3_Value";
                lblColumnHead.Refresh();

                lblS1Qty.Visible = true;
                lblS1Value.Visible = true;
                lblS2Qty.Visible = true;
                lblS2Value.Visible = true;
                lblS3Qty.Visible = true;
                lblS3Value.Visible = true;

                lblSlab1Qty.Visible = true;
                lblSlab1Value.Visible = true;
                lblSlab2Qty.Visible = true;
                lblSlab2Value.Visible = true;
                lblSlab3Qty.Visible = true;
                lblSlab3Value.Visible = true;

            }
            else
            {
                lblColumnHead.Text = "Excel Field: TYear, TMonth, CustomerID, PGID, Target Amount";
                lblColumnHead.Refresh();

                lblS1Qty.Visible = false;
                lblS1Value.Visible = false;
                lblS2Qty.Visible = false;
                lblS2Value.Visible = false;
                lblS3Qty.Visible = false;
                lblS3Value.Visible = false;


                lblSlab1Qty.Visible = false;
                lblSlab1Value.Visible = false;
                lblSlab2Qty.Visible = false;
                lblSlab2Value.Visible = false;
                lblSlab3Qty.Visible = false;
                lblSlab3Value.Visible = false;

            }
        }
        private void SendSMS(string sVersionName)
        {
            SMSMessages oSMSMessages = new SMSMessages();
            oSMSMessages.GetMobileNoByGroup(199);//199=TEL_SalesTargetUploadNitificationGroup

            foreach (SMSMessage oSMSMessage in oSMSMessages)
            {

                oSMSMessage.RequestDate = DateTime.Now;
                oSMSMessage.SMSText = sVersionName + " already uploaded!!";
                oSMSMessage.SMSType = 1;
                oSMSMessage.SendDate = DateTime.Now;
                oSMSMessage.Status = 1;
                oSMSMessage.SubmittedBy = Utility.Username;
                oSMSMessage.SuccessCount = 0;
                oSMSMessage.FailCount = 0;

                oSMSMessage.Add();
            }
        }

        //private void openFileDialogData_FileOk(object sender, CancelEventArgs e)
        //{

        //}
    }
}