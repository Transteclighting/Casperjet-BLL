using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Win.CSD.Reception;

namespace CJ.Win.CSD.Reception
{
    public partial class frmTechnicalAssessment : Form
    {
        SparePartsRs _oSparePartsRs;
        CSDJob _oCSDJob;
        GeoLocation _oGeoLocation;
        public bool Istrue = false;

        CSDServiceCharge _oCSDServiceCharge;
        CSDServiceChargeCustomers _oCSDServiceChargeCustomers;
        CSDServiceChargeProduct _oCSDServiceChargeProduct;
        CSDJobBill _oCSDJobBill;

        CSDServiceChargeCustomer _oCSDServiceChargeCustomer;
        CSDEstimatedSparePartses _oCSDEstimatedSparePartses;

        CSDPendingSparePartss _oCSDPendingSparePartses;
        
         int _nProactiveCallID;
        int _nJobID=0;
        double _nTotalMaterialCost = 0;
        string _Status = "";
        public frmTechnicalAssessment()
        {
            InitializeComponent();
        }
        public void ShowDialog(int nJobID,string sJobNo,string sStatus, int nProactiveCallID)
        {
            if (sJobNo != "")
            {
                _nJobID = nJobID;
                _nProactiveCallID = nProactiveCallID;
                ctlCSDJob1.txtCode.Text = sJobNo;
                ctlCSDJob1.Enabled = false;
                _Status = sStatus;

            }
            this.ShowDialog();
        }
        private void frmTechnicalAssessment_Load(object sender, EventArgs e)
        {
            //ResetTextBox();
            LoadCombos();
            if (ctlCSDJob1.txtDescription.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                LoadAllTextBoxes();
                LoadIssuedSpareParts();
                this.Cursor = Cursors.Default;
            }

            cmbAccessories.Enabled = true;
            cmbFunctional.Enabled = false;
            cmbCarton.Enabled = false;
            cmbCorkSheet.Enabled = false;
            cmbMajorDent.Enabled = false;
            cmbMinorDent.Enabled = false;
            cmbMaScratch.Enabled = false;
            cmbMiScratch.Enabled = false;
            cmbBrokenIssue.Enabled = false;
        }
        private void LoadCombos()
        {
            //Jobs
            cmbAccessories.Items.Clear();
            cmbAccessories.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDAccessories)))
            {
                cmbAccessories.Items.Add(Enum.GetName(typeof(Dictionary.CSDAccessories), GetEnum));
            }
            cmbAccessories.SelectedIndex = 0;

            cmbFunctional.Items.Clear();
            cmbFunctional.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDFunctionalType)))
            {
                cmbFunctional.Items.Add(Enum.GetName(typeof(Dictionary.CSDFunctionalType), GetEnum));
            }
            cmbFunctional.SelectedIndex = 0;

            cmbCarton.Items.Clear();
            cmbCarton.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDCartonCorkSheetType)))
            {
                cmbCarton.Items.Add(Enum.GetName(typeof(Dictionary.CSDCartonCorkSheetType), GetEnum));
            }
            cmbCarton.SelectedIndex = 0;

            cmbCorkSheet.Items.Clear();
            cmbCorkSheet.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDCartonCorkSheetType)))
            {
                cmbCorkSheet.Items.Add(Enum.GetName(typeof(Dictionary.CSDCartonCorkSheetType), GetEnum));
            }
            cmbCorkSheet.SelectedIndex = 0;

            cmbMajorDent.Items.Clear();
            cmbMajorDent.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDYesOrNoStatus)))
            {
                cmbMajorDent.Items.Add(Enum.GetName(typeof(Dictionary.CSDYesOrNoStatus), GetEnum));
            }
            cmbMajorDent.SelectedIndex = 0;

            cmbMinorDent.Items.Clear();
            cmbMinorDent.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDYesOrNoStatus)))
            {
                cmbMinorDent.Items.Add(Enum.GetName(typeof(Dictionary.CSDYesOrNoStatus), GetEnum));
            }
            cmbMinorDent.SelectedIndex = 0;

            cmbMaScratch.Items.Clear();
            cmbMaScratch.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDYesOrNoStatus)))
            {
                cmbMaScratch.Items.Add(Enum.GetName(typeof(Dictionary.CSDYesOrNoStatus), GetEnum));
            }
            cmbMaScratch.SelectedIndex = 0;

            cmbMiScratch.Items.Clear();
            cmbMiScratch.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDYesOrNoStatus)))
            {
                cmbMiScratch.Items.Add(Enum.GetName(typeof(Dictionary.CSDYesOrNoStatus), GetEnum));
            }
            cmbMiScratch.SelectedIndex = 0;

            cmbBrokenIssue.Items.Clear();
            cmbBrokenIssue.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDYesOrNoStatus)))
            {
                cmbBrokenIssue.Items.Add(Enum.GetName(typeof(Dictionary.CSDYesOrNoStatus), GetEnum));
            }
            cmbBrokenIssue.SelectedIndex = 0;

            //cmbStock.Items.Clear();
            //cmbStock.Items.Add("--ALL--");
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDTechnicalReportStockType)))
            //{
            //    cmbStock.Items.Add(Enum.GetName(typeof(Dictionary.CSDTechnicalReportStockType), GetEnum));
            //}
            //cmbStock.SelectedIndex = 0;

            cmbIsPartsUsed.Items.Clear();
            cmbIsPartsUsed.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDYesOrNoStatus)))
            {
                cmbIsPartsUsed.Items.Add(Enum.GetName(typeof(Dictionary.CSDYesOrNoStatus), GetEnum));
            }
            cmbIsPartsUsed.SelectedIndex = 0;

        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (cmbAccessories.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Accessories", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAccessories.Focus();
                return false;
            }
            if (cmbFunctional.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Functional type ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFunctional.Focus();
                return false;
            }
            if (cmbCarton.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Carton type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCarton.Focus();
                return false;
            }
            if (cmbCorkSheet.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Cork Sheet type ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCorkSheet.Focus();
                return false;
            }
            if (cmbMajorDent.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Major Dent ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMajorDent.Focus();
                return false;
            }
            if (cmbMinorDent.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Minor Dent ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMinorDent.Focus();
                return false;
            }
            if (cmbMaScratch.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Major Scratch ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaScratch.Focus();
                return false;
            }
            if (cmbMiScratch.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Minor Scratch ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMiScratch.Focus();
                return false;
            }
            if (cmbBrokenIssue.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Broken Issue ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrokenIssue.Focus();
                return false;
            }
            //if (cmbStock.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select stock type ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbStock.Focus();
            //    return false;
            //}
            if (cmbIsPartsUsed.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select parts use ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbIsPartsUsed.Focus();
                return false;
            }
            #endregion

            return true;
        }
        private void LoadAllTextBoxes()
        {
            _oCSDJob = ctlCSDJob1.SelectedJob;
            //Load Job Info
            txtJobStatus.Text = Enum.GetName(typeof(Dictionary.JobStatus), _oCSDJob.Status);            
            if (_oCSDJob.InvoiceDate != null)
            {
                txtPurchaseDate.Text = Convert.ToDateTime(_oCSDJob.InvoiceDate).ToShortDateString();
            }
            txtSubStatus.Text = _oCSDJob.SubStatusName;
            txtStatusReason.Text = _oCSDJob.StatusReason;
            txtProductSL.Text = _oCSDJob.ProductSerialNo;
            txtCreateDate.Text = _oCSDJob.CreateDate.ToShortDateString();
            txtRemarks.Text = _oCSDJob.Remarks;
            txtBrand.Text = _oCSDJob.BrandName;
           
            txtCreateDate.Text = Convert.ToDateTime(_oCSDJob.CreateDate).ToShortDateString();
            txtDeliveryDate.Text = Convert.ToDateTime(_oCSDJob.DeliveryDate).ToShortDateString();

            ProductFault _oProductFault = new ProductFault();
            _oProductFault.RefreshByCSDTechnicalAssessment(_oCSDJob.PrimaryFaultID);
            txtProductFault.Text = _oProductFault.FaultDescription;
            txtActualFault.Text = _oProductFault.ActualFault;           
        }
        private void LoadIssuedSpareParts()
        {
            _oSparePartsRs = new SparePartsRs();
            _oSparePartsRs.GetPartsIssueAgaintsJob(ctlCSDJob1.SelectedJob.JobID);
            dgvIssuedSpareParts.Rows.Clear();
            double _payable_mat_cost = 0;
            foreach (SparePartsR oSparePartsR in _oSparePartsRs)
            {
                if (oSparePartsR.SPTranSide != 1)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvIssuedSpareParts);
                    oRow.Cells[1].Value = oSparePartsR.Code;
                    oRow.Cells[2].Value = oSparePartsR.Name;
                    oRow.Cells[3].Value = oSparePartsR.Qty;
                    oRow.Cells[4].Value = oSparePartsR.TotalPrice;
                    oRow.Cells[5].Value = oSparePartsR.SPtranID.ToString();
                    dgvIssuedSpareParts.Rows.Add(oRow);
                    if (oSparePartsR.IsWarantyValid == "Yes")
                    {
                        oRow.Cells[0].Value = true;
                        oRow.Cells[0].ReadOnly = true;
                        _payable_mat_cost += Convert.ToDouble(oSparePartsR.TotalPrice);
                    }
                    else
                    {
                        oRow.Cells[0].Value = false;
                        oRow.Cells[0].ReadOnly = false;
                    }
                    _nTotalMaterialCost += Convert.ToDouble(oSparePartsR.TotalPrice);
                }

            }
            //txtMatChargePayable.Text = (_nTotalMaterialCost - _payable_mat_cost).ToString();
            //txtMaterialTotalCharge.Text = _nTotalMaterialCost.ToString();
        }
        private void Save()
        {
            CSDTechnicalAssessment oCSDTechnicalAssessment = new CSDTechnicalAssessment();
            oCSDTechnicalAssessment.JobID = _nJobID;
            oCSDTechnicalAssessment.Accessories = cmbAccessories.Text;
            oCSDTechnicalAssessment.FunctionalCondition = cmbFunctional.Text;
            oCSDTechnicalAssessment.Carton = cmbCarton.Text;
            oCSDTechnicalAssessment.CorkSheet = cmbCorkSheet.Text;
            if (cmbMajorDent.SelectedIndex == 1)
            {
                oCSDTechnicalAssessment.MajorDent = (int)Dictionary.CSDYesOrNoStatus.YES;
            }
            else if (cmbMajorDent.SelectedIndex == 2)
            {
                oCSDTechnicalAssessment.MajorDent = (int)Dictionary.CSDYesOrNoStatus.No;
            }
            if (cmbMinorDent.SelectedIndex == 1)
            {
                oCSDTechnicalAssessment.MinorDent = (int)Dictionary.CSDYesOrNoStatus.YES;
            }
            else if (cmbMinorDent.SelectedIndex == 2)
            {
                oCSDTechnicalAssessment.MinorDent = (int)Dictionary.CSDYesOrNoStatus.No;
            }
            if (cmbMaScratch.SelectedIndex == 1)
            {
                oCSDTechnicalAssessment.MajorScratch = (int)Dictionary.CSDYesOrNoStatus.YES;
            }
            else if (cmbMaScratch.SelectedIndex == 2)
            {
                oCSDTechnicalAssessment.MajorScratch = (int)Dictionary.CSDYesOrNoStatus.No;
            }
            if (cmbMiScratch.SelectedIndex == 1)
            {
                oCSDTechnicalAssessment.MinorScratch = (int)Dictionary.CSDYesOrNoStatus.YES;
            }
            else if (cmbMiScratch.SelectedIndex == 2)
            {
                oCSDTechnicalAssessment.MinorScratch = (int)Dictionary.CSDYesOrNoStatus.No;
            }
            if (cmbBrokenIssue.SelectedIndex == 1)
            {
                oCSDTechnicalAssessment.BrokenIssue = (int)Dictionary.CSDYesOrNoStatus.YES;
            }
            else if (cmbBrokenIssue.SelectedIndex == 2)
            {
                oCSDTechnicalAssessment.BrokenIssue = (int)Dictionary.CSDYesOrNoStatus.No;
            }
            if (cmbIsPartsUsed.SelectedIndex == 1)
            {
                oCSDTechnicalAssessment.IsPartsUsed = (int)Dictionary.CSDYesOrNoStatus.YES;
            }
            else if (cmbIsPartsUsed.SelectedIndex == 2)
            {
                oCSDTechnicalAssessment.IsPartsUsed = (int)Dictionary.CSDYesOrNoStatus.No;
            }
            if (_Status != "Pending")
            {
                oCSDTechnicalAssessment.ProductCondition = txtProductCondition.Text;
            }
            else
            {
                oCSDTechnicalAssessment.ProductCondition = "Pending";
            }           
            oCSDTechnicalAssessment.CreateBY = Utility.UserId;
            oCSDTechnicalAssessment.CreateDate = DateTime.Now;
            oCSDTechnicalAssessment.Remarks = txtAssessmentRemarks.Text;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oCSDTechnicalAssessment.Add();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }         

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFunctional.Enabled = true;
            txtProductCondition.Text = "";

        }

        private void cmbFunctional_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCarton.Enabled = true;
            cmbFunctional.Enabled = false;
        }

        private void cmbCarton_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCorkSheet.Enabled = true;
            cmbCarton.Enabled = false;
        }

        private void cmbCorkSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMajorDent.Enabled = true;
            cmbCorkSheet.Enabled = false;

        }

        private void cmbMajorDent_SelectedIndexChanged(object sender, EventArgs e)
        { 
            cmbMinorDent.Enabled = true;
            cmbMajorDent.Enabled = false;
        }

        private void cmbMinorDent_SelectedIndexChanged(object sender, EventArgs e)
        {  
            cmbMaScratch.Enabled = true;
            cmbMinorDent.Enabled = false;
        }

        private void cmbMaScratch_SelectedIndexChanged(object sender, EventArgs e)
        {  
            cmbMiScratch.Enabled = true;
            cmbMaScratch.Enabled = false;
        }

        private void cmbMiScratch_SelectedIndexChanged(object sender, EventArgs e)
        { 
            cmbBrokenIssue.Enabled = true;
            cmbMiScratch.Enabled = false;
        }

        private void cmbBrokenIssue_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          if (cmbAccessories.SelectedIndex == 1 && cmbFunctional.SelectedIndex == 2 && cmbCarton.SelectedIndex == 1
                && cmbCorkSheet.SelectedIndex == 1
                && cmbMajorDent.SelectedIndex == 2 && cmbMinorDent.SelectedIndex == 2 && cmbMaScratch.SelectedIndex == 2
                && cmbMiScratch.SelectedIndex == 2 && cmbBrokenIssue.SelectedIndex == 2)
            {
                txtProductCondition.Text = "Scrap";
            }
            else if (cmbAccessories.SelectedIndex == 1 && cmbFunctional.SelectedIndex == 2 && cmbCarton.SelectedIndex == 2
                && cmbCorkSheet.SelectedIndex == 2
                && cmbMajorDent.SelectedIndex == 2 && cmbMinorDent.SelectedIndex == 2 && cmbMaScratch.SelectedIndex == 2
                && cmbMiScratch.SelectedIndex == 2 && cmbBrokenIssue.SelectedIndex == 2)
            {
                txtProductCondition.Text = "Scrap";
            }
            else if (cmbAccessories.SelectedIndex == 1 && cmbFunctional.SelectedIndex == 2 && cmbCarton.SelectedIndex == 1
                  && cmbCorkSheet.SelectedIndex == 2
                  && cmbMajorDent.SelectedIndex == 2 && cmbMinorDent.SelectedIndex == 2 && cmbMaScratch.SelectedIndex == 2
                  && cmbMiScratch.SelectedIndex == 2 && cmbBrokenIssue.SelectedIndex == 2)
            {
                txtProductCondition.Text = "Scrap";
            }
            else if (cmbAccessories.SelectedIndex == 1 && cmbFunctional.SelectedIndex == 2 && cmbCarton.SelectedIndex == 2
                  && cmbCorkSheet.SelectedIndex == 1
                  && cmbMajorDent.SelectedIndex == 2 && cmbMinorDent.SelectedIndex == 2 && cmbMaScratch.SelectedIndex == 2
                  && cmbMiScratch.SelectedIndex == 2 && cmbBrokenIssue.SelectedIndex == 2)
            {
                txtProductCondition.Text = "Scrap";
            }
            else
            if (cmbAccessories.SelectedIndex == 1 && cmbFunctional.SelectedIndex == 1 && cmbCarton.SelectedIndex == 1
                && cmbCorkSheet.SelectedIndex == 1
                && cmbMajorDent.SelectedIndex == 2 && cmbMinorDent.SelectedIndex == 2 && cmbMaScratch.SelectedIndex == 2
                && cmbMiScratch.SelectedIndex == 2 && cmbBrokenIssue.SelectedIndex == 2)
            {
                txtProductCondition.Text = "Stock";
            }
            else
            if (cmbAccessories.SelectedIndex == 1 && cmbFunctional.SelectedIndex == 1 && cmbCarton.SelectedIndex == 2
                && cmbCorkSheet.SelectedIndex == 2
                && cmbMajorDent.SelectedIndex == 2 && cmbMinorDent.SelectedIndex == 2 && cmbMaScratch.SelectedIndex == 2
                && cmbMiScratch.SelectedIndex == 2 && cmbBrokenIssue.SelectedIndex == 2)
            {
                txtProductCondition.Text = "Stock";
            }
            else
            if (cmbAccessories.SelectedIndex == 1 && cmbFunctional.SelectedIndex == 1 && cmbCarton.SelectedIndex == 1
                && cmbCorkSheet.SelectedIndex == 2
                && cmbMajorDent.SelectedIndex == 2 && cmbMinorDent.SelectedIndex == 2 && cmbMaScratch.SelectedIndex == 2
                && cmbMiScratch.SelectedIndex == 2 && cmbBrokenIssue.SelectedIndex == 2)
            {
                txtProductCondition.Text = "Stock";
            }
            else
            if (cmbAccessories.SelectedIndex == 1 && cmbFunctional.SelectedIndex == 1 && cmbCarton.SelectedIndex == 2
                && cmbCorkSheet.SelectedIndex == 1
                && cmbMajorDent.SelectedIndex == 2 && cmbMinorDent.SelectedIndex == 2 && cmbMaScratch.SelectedIndex == 2
                && cmbMiScratch.SelectedIndex == 2 && cmbBrokenIssue.SelectedIndex == 2)
            {
                txtProductCondition.Text = "Stock";
            }
            else
            {
                txtProductCondition.Text = "Discount";
            }
        }
        private void txtJobStatus_TextChanged(object sender, EventArgs e)
        {     
                   
        }
    }
}
