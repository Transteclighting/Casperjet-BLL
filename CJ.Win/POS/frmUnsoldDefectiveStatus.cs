using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Class.DataTransfer;

namespace CJ.Win.POS
{
    public partial class frmUnsoldDefectiveStatus : Form
    {
        public bool _IsTrue = false;
        int _nUIControl = 0;
        UnsoldDefectiveProduct _oUnsoldDefectiveProduct;
        UnsoldDefectiveProducts _UnsoldDefectiveProducts;
        int nDefectiveID = 0;
        string sDefectiveNo = "";
        int nWarehouseID = 0;
        private void LoadCombos()
        {
            //Tech Recommandation
            cmbTechRecommandation.Items.Clear();
            cmbTechRecommandation.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.UnsouldDefectiveTechRecommandation)))
            {
                cmbTechRecommandation.Items.Add(Enum.GetName(typeof(Dictionary.UnsouldDefectiveTechRecommandation), GetEnum));
            }
            cmbTechRecommandation.SelectedIndex = 0;

            //Is Locally Repaired
            cmbIsLocallyRepaired.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsLocallyRepaired.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsLocallyRepaired.SelectedIndex = 1;

            //Locally Saleable
            cmbLocallySaleable.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbLocallySaleable.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbLocallySaleable.SelectedIndex = 0;


            //Defective Type
            cmbDefectiveType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsoldDefectiveProductType)))
            {
                cmbDefectiveType.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), GetEnum));
            }
            cmbDefectiveType.SelectedIndex = 0;

            //Defective Category
            cmbDefectiveCategory.Items.Clear();
            cmbDefectiveCategory.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.UnsouldDefectiveCategory)))
            {
                cmbDefectiveCategory.Items.Add(Enum.GetName(typeof(Dictionary.UnsouldDefectiveCategory), GetEnum));
            }
            cmbDefectiveCategory.SelectedIndex = 0;

            //Is Repairable
            cmbIsRepairable.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsRepairable.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsRepairable.SelectedIndex = 0;

            //Repair Status
            cmbIsPltyApplied.Items.Clear();
            cmbIsPltyApplied.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsPenaltyApplicable)))
            {
                cmbIsPltyApplied.Items.Add(Enum.GetName(typeof(Dictionary.IsPenaltyApplicable), GetEnum));
            }
            cmbIsPltyApplied.SelectedIndex = 0;
        }
        public frmUnsoldDefectiveStatus(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
            lblMargin.Visible = false;
            txtNetMargin.Visible = false;
        }
        private void frmUnsoldDefectiveStatus_Load(object sender, EventArgs e)
        {

        }


        public void ShowDialog1(UnsoldDefectiveProduct oUnsoldDefectiveProduct)
        {
            LoadCombos();
            nDefectiveID = 0;
            nDefectiveID = oUnsoldDefectiveProduct.DefectiveID;
            sDefectiveNo = "";
            sDefectiveNo = oUnsoldDefectiveProduct.DefectiveNo;
            nWarehouseID = 0;
            nWarehouseID = oUnsoldDefectiveProduct.WarehouseID;
            txtDefectiveNo.Text = sDefectiveNo;
            lblCreateDate.Text = Convert.ToDateTime(oUnsoldDefectiveProduct.CreateDate).ToString("dd-MMM-yyyy");
            lblOutletName.Text = oUnsoldDefectiveProduct.ShowroomCode;
            lblStatus.Text = Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), oUnsoldDefectiveProduct.Status);
            lblProductName.Text = '[' + oUnsoldDefectiveProduct.ProductCode + ']' + oUnsoldDefectiveProduct.ProductName;
            lblProductSerial.Text = oUnsoldDefectiveProduct.BarcodeSL;
            txtOriginalSL.Text = oUnsoldDefectiveProduct.OriginalSL;
            cmbDefectiveType.SelectedIndex = oUnsoldDefectiveProduct.DefectiveType - 1;
            lblFault.Text = oUnsoldDefectiveProduct.Fault;
            lblReason.Text = oUnsoldDefectiveProduct.Reason;
            if (oUnsoldDefectiveProduct.JobNo != "")
                txtJobNo.Text = oUnsoldDefectiveProduct.JobNo.ToString() + '[' + Convert.ToDateTime(oUnsoldDefectiveProduct.JobDate).ToString("dd-MMM-yyyy") + ']';
            if (oUnsoldDefectiveProduct.RefTranNo != "")
                txtRefTranNo.Text = oUnsoldDefectiveProduct.RefTranNo + '[' + Convert.ToDateTime(oUnsoldDefectiveProduct.RefTranDate).ToString("dd-MMM-yyyy") + ']';
            txtRemarks.Text = oUnsoldDefectiveProduct.Remarks.ToString();
            cmbDefectiveCategory.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.DefectiveCategory);//- 1;
            txtAssessmentFinding.Text = oUnsoldDefectiveProduct.AssessmentFindings.ToString();
            cmbTechRecommandation.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.TechRecommandation);// - 1;
            cmbIsRepairable.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.IsRepairable);
            cmbLocallySaleable.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.IsLocallySaleable);
            txtTechRemarks.Text = oUnsoldDefectiveProduct.TechRemarks.ToString();
            txtPaneltyAmount.Text = oUnsoldDefectiveProduct.PaneltyAmount.ToString();
            txtProposedAmt.Text = oUnsoldDefectiveProduct.ProposeDicAmount.ToString();
            txtApprovedAmt.Text = oUnsoldDefectiveProduct.ApproveDicAmount.ToString();
            txtAccessories.Text = oUnsoldDefectiveProduct.Accessories.ToString();
            if (oUnsoldDefectiveProduct.IsPenaltyApplicable != 0)
            {
                cmbIsPltyApplied.Text = Enum.GetName(typeof(Dictionary.IsPenaltyApplicable), oUnsoldDefectiveProduct.IsPenaltyApplicable);
            }
            else
            {
                cmbIsPltyApplied.SelectedIndex = 0;
            }
            cmbIsLocallyRepaired.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.IsLocallyRepaired);
            cmbIsLocallyRepaired.Enabled = true;
            if (oUnsoldDefectiveProduct.ExpSalesDate != null)
            {
                dtExpSalesDate.Value = Convert.ToDateTime(oUnsoldDefectiveProduct.ExpSalesDate);
                txtExpSalesDate.Text = Convert.ToDateTime(oUnsoldDefectiveProduct.ExpSalesDate).ToString("dd-MMM-yyyy");
            }
            else
            {
                dtExpSalesDate.Value = DateTime.Today;
                txtExpSalesDate.Text = "";
            }
            TELLib oTELLib = new TELLib();
            this.Tag = oUnsoldDefectiveProduct;
            DataTransfer oDataTransfer = new DataTransfer();
            double _SalesPromotion = oDataTransfer.GetPromoDiscountByProductCode(oUnsoldDefectiveProduct.ProductCode);

            txtCostprice.Text = oTELLib.TakaFormat(oUnsoldDefectiveProduct.CostPrice + (oUnsoldDefectiveProduct.CostPrice * oUnsoldDefectiveProduct.VAT));
            txtRSP.Text = oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP);
            txtSalePromotion.Text = oTELLib.TakaFormat(_SalesPromotion);
            txtNetMargin.Text = oTELLib.TakaFormat((Convert.ToDouble(txtRSP.Text) - Convert.ToDouble(txtSalePromotion.Text) - Convert.ToDouble(txtApprovedAmt.Text)) - Convert.ToDouble(txtCostprice.Text));


            this.Text = "Unsold Defective Product for Edit";
                //txtCostprice.Text = "RSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP) + "|VAT:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.VAT) + "";


            btnSave.Text = "Edit";
            btnAssignJob.Visible = false;
            btnSave.Visible = true;
            cmbDefectiveType.Enabled = true;
            txtPaneltyAmount.Enabled = true;
            txtProposedAmt.Enabled = true;
            txtApprovedAmt.Enabled = true;
            txtOriginalSL.ReadOnly = false;
            txtOriginalSL.BackColor = Color.White;


            this.ShowDialog();

        }

        public void ShowDialog(UnsoldDefectiveProduct oUnsoldDefectiveProduct)
        {
            LoadCombos();
            nDefectiveID = 0;
            nDefectiveID = oUnsoldDefectiveProduct.DefectiveID;
            sDefectiveNo = "";
            sDefectiveNo = oUnsoldDefectiveProduct.DefectiveNo;
            nWarehouseID = 0;
            nWarehouseID = oUnsoldDefectiveProduct.WarehouseID;
            txtDefectiveNo.Text = sDefectiveNo;
            lblCreateDate.Text = Convert.ToDateTime(oUnsoldDefectiveProduct.CreateDate).ToString("dd-MMM-yyyy");
            lblOutletName.Text = oUnsoldDefectiveProduct.ShowroomCode;
            lblStatus.Text = Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), oUnsoldDefectiveProduct.Status);
            lblProductName.Text = '[' + oUnsoldDefectiveProduct.ProductCode + ']' + oUnsoldDefectiveProduct.ProductName;
            lblProductSerial.Text = oUnsoldDefectiveProduct.BarcodeSL;
            txtOriginalSL.Text = oUnsoldDefectiveProduct.OriginalSL;
            cmbDefectiveType.SelectedIndex = oUnsoldDefectiveProduct.DefectiveType - 1;
            lblFault.Text = oUnsoldDefectiveProduct.Fault;
            lblReason.Text = oUnsoldDefectiveProduct.Reason;
            if (oUnsoldDefectiveProduct.JobNo != "")
                txtJobNo.Text = oUnsoldDefectiveProduct.JobNo.ToString() + '[' + Convert.ToDateTime(oUnsoldDefectiveProduct.JobDate).ToString("dd-MMM-yyyy") + ']';
            if (oUnsoldDefectiveProduct.RefTranNo != "")
                txtRefTranNo.Text = oUnsoldDefectiveProduct.RefTranNo + '[' + Convert.ToDateTime(oUnsoldDefectiveProduct.RefTranDate).ToString("dd-MMM-yyyy") + ']';
            txtRemarks.Text = oUnsoldDefectiveProduct.Remarks.ToString();
            cmbDefectiveCategory.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.DefectiveCategory);// - 1;
            txtAssessmentFinding.Text = oUnsoldDefectiveProduct.AssessmentFindings.ToString();
            cmbTechRecommandation.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.TechRecommandation);// - 1;
            cmbIsRepairable.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.IsRepairable);
            cmbLocallySaleable.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.IsLocallySaleable);
            txtTechRemarks.Text = oUnsoldDefectiveProduct.TechRemarks.ToString();
            txtPaneltyAmount.Text = oUnsoldDefectiveProduct.PaneltyAmount.ToString();
            txtProposedAmt.Text = oUnsoldDefectiveProduct.ProposeDicAmount.ToString();
            txtApprovedAmt.Text = oUnsoldDefectiveProduct.ApproveDicAmount.ToString();
            txtAccessories.Text = oUnsoldDefectiveProduct.Accessories.ToString();

            //if (oUnsoldDefectiveProduct.RepairStatus.ToString() != "")
            //{
            //    cmbIsPltyApplied.Text = oUnsoldDefectiveProduct.RepairStatus.ToString();
            //}
            if (oUnsoldDefectiveProduct.IsPenaltyApplicable != 0)
            {
                cmbIsPltyApplied.Text = Enum.GetName(typeof(Dictionary.IsPenaltyApplicable), oUnsoldDefectiveProduct.IsPenaltyApplicable);
            }
            else
            {
                cmbIsPltyApplied.SelectedIndex = 0;
            }
            cmbIsLocallyRepaired.SelectedIndex = Convert.ToInt32(oUnsoldDefectiveProduct.IsLocallyRepaired);
            TELLib oTELLib = new TELLib();
            //txtPrice.Text = "CP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.CostPrice) + "|NSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.NSP) + "|RSP:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP) + "|VAT:" + oTELLib.TakaFormat(oUnsoldDefectiveProduct.VAT) + "";
            this.Tag = oUnsoldDefectiveProduct;
            DataTransfer oDataTransfer = new DataTransfer();
            double _SalesPromotion = oDataTransfer.GetPromoDiscountByProductCode(oUnsoldDefectiveProduct.ProductCode);

            txtCostprice.Text = oTELLib.TakaFormat(oUnsoldDefectiveProduct.CostPrice + (oUnsoldDefectiveProduct.CostPrice * oUnsoldDefectiveProduct.VAT));
            txtRSP.Text = oTELLib.TakaFormat(oUnsoldDefectiveProduct.RSP);
            txtSalePromotion.Text = oTELLib.TakaFormat(_SalesPromotion);
            txtNetMargin.Text = oTELLib.TakaFormat((Convert.ToDouble(txtRSP.Text) - Convert.ToDouble(txtSalePromotion.Text) - Convert.ToDouble(txtApprovedAmt.Text)) - Convert.ToDouble(txtCostprice.Text));

            if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed)
            {
                this.Text = "Defective Product for Assessment";
                txtPaneltyAmount.Enabled = false;
                txtProposedAmt.Enabled = false;
                txtApprovedAmt.Enabled = false;
                btnSave.Text = "Assessed";
                //txtCostprice.Text = oTELLib.TakaFormat(oUnsoldDefectiveProduct.CostPrice + (oUnsoldDefectiveProduct.CostPrice * oUnsoldDefectiveProduct.VAT));
                txtNetMargin.Visible = false;
                lblMargin.Visible = false;

            }
            else if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Reject)
            {
                this.Text = "Defective Product for Reject";
                btnSave.Text = "Reject";
                //txtCostprice.Text = oTELLib.TakaFormat(oUnsoldDefectiveProduct.CostPrice + (oUnsoldDefectiveProduct.CostPrice * oUnsoldDefectiveProduct.VAT));
                lblMargin.Visible = false;
                txtNetMargin.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Discount_Approved)
            {
                this.Text = "Defective Product for Price Approval";
                btnSave.Text = "Approved";
                lblMargin.Visible = true;
                txtNetMargin.Visible = true;
            }
            else
            {
                this.Text = "Unsold Defective Product (Assign Job#)";
                // txtCostprice.Text = oTELLib.TakaFormat(oUnsoldDefectiveProduct.CostPrice + (oUnsoldDefectiveProduct.CostPrice * oUnsoldDefectiveProduct.VAT));
                lblMargin.Visible = false;
                txtNetMargin.Visible = false;
                txtJobNo.Text = "";
                txtJobNo.ReadOnly = false;
                lblJobNo.Text = "Job Number";
                btnSave.Visible = false;
                btnAssignJob.Visible = true;
                cmbDefectiveType.Enabled = false;
                cmbDefectiveCategory.Enabled = false;
                txtAssessmentFinding.Enabled = false;
                cmbIsRepairable.Enabled = false;
                txtAccessories.Enabled = false;
                cmbTechRecommandation.Enabled = false;
                cmbLocallySaleable.Enabled = false;
                txtTechRemarks.Enabled = false;
                txtPaneltyAmount.Enabled = false;
                txtProposedAmt.Enabled = false;
                txtApprovedAmt.Enabled = false;

                cmbIsPltyApplied.Enabled = false;
                cmbIsLocallyRepaired.Enabled = false;
                dtExpSalesDate.Enabled = false;
                lblMargin.Visible = false;
            }
            this.ShowDialog();

        }
        public bool UIValidation()
        {
            if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed)
            {
                if (txtAssessmentFinding.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter assessment finding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAssessmentFinding.Focus();
                    return false;
                }
                if (txtAccessories.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter accessories list", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccessories.Focus();
                    return false;
                }
            }
            if (btnSave.Text == "Edit")
            {

            }
            else
            {
                if (_nUIControl == 0)
                {
                    if (txtJobNo.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Job#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtJobNo.Focus();
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Edit")
            {
                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                        _oUnsoldDefectiveProduct.DefectiveType = cmbDefectiveType.SelectedIndex + 1;

                        if (_oUnsoldDefectiveProduct.DefectiveType == (int)Dictionary.POSUnsoldDefectiveProductType.Functional)
                        {
                            _oUnsoldDefectiveProduct.IsLocallyRepaired = cmbIsLocallyRepaired.SelectedIndex;
                            if (cmbIsPltyApplied.SelectedIndex == 1)
                            {
                                _oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)Dictionary.IsPenaltyApplicable.No;
                            }
                            else if(cmbIsPltyApplied.SelectedIndex == 2)
                            {
                                _oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)Dictionary.IsPenaltyApplicable.Yes;
                            }
                            //_oUnsoldDefectiveProduct.DefectiveCategory = -1;
                            //_oUnsoldDefectiveProduct.IsRepairable = -1;
                            //_oUnsoldDefectiveProduct.IsLocallySaleable = -1;

                        }
                        else
                        {
                            //_oUnsoldDefectiveProduct.IsLocallyRepaired = -1;
                            if (cmbDefectiveCategory.SelectedIndex != 0)
                            {
                                _oUnsoldDefectiveProduct.DefectiveCategory = cmbDefectiveCategory.SelectedIndex; //+ 1;
                            }
                            else
                            {
                                _oUnsoldDefectiveProduct.DefectiveCategory = "";
                            }
                            
                            _oUnsoldDefectiveProduct.IsRepairable = cmbIsRepairable.SelectedIndex;
                            _oUnsoldDefectiveProduct.IsLocallySaleable = cmbLocallySaleable.SelectedIndex;

                        }

                        _oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(txtProposedAmt.Text);
                        if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed)
                        {
                            _oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed;
                        }
                        else if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Discount_Approved)
                        {
                            _oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatus.Discount_Approved;
                            _oUnsoldDefectiveProduct.ApproveBy = Utility.UserId;
                            _oUnsoldDefectiveProduct.ApproveDate = DateTime.Now.Date;
                        }
                        else if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Reject)
                        {
                            _oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatus.Reject;
                        }
                        _oUnsoldDefectiveProduct.JobNo = txtJobNo.Text;
                        _oUnsoldDefectiveProduct.OriginalSL = txtOriginalSL.Text;
                        _oUnsoldDefectiveProduct.ApproveDicAmount = Convert.ToDouble(txtApprovedAmt.Text);

                        _oUnsoldDefectiveProduct.AssessmentFindings = txtAssessmentFinding.Text;

                        _oUnsoldDefectiveProduct.Accessories = txtAccessories.Text;
                        if (cmbTechRecommandation.SelectedIndex != 0)
                        {
                            _oUnsoldDefectiveProduct.TechRecommandation = cmbTechRecommandation.SelectedIndex; 
                        }
                        else
                        {
                            _oUnsoldDefectiveProduct.TechRecommandation = "";
                        }
                        // _oUnsoldDefectiveProduct.TechRecommandation = cmbTechRecommandation.SelectedIndex + 1;
                        _oUnsoldDefectiveProduct.TechRemarks = txtTechRemarks.Text;

                        _oUnsoldDefectiveProduct.PaneltyAmount = Convert.ToDouble(txtPaneltyAmount.Text);
                        _oUnsoldDefectiveProduct.DefectiveID = nDefectiveID;
                        _oUnsoldDefectiveProduct.WarehouseID = nWarehouseID;
                        if (cmbIsPltyApplied.SelectedIndex == 1)
                        {
                            _oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)Dictionary.IsPenaltyApplicable.No;
                        }
                        else if (cmbIsPltyApplied.SelectedIndex == 2)
                        {
                            _oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)Dictionary.IsPenaltyApplicable.Yes;
                        }
                        if(txtExpSalesDate.Text.Trim()!="")
                        {
                            _oUnsoldDefectiveProduct.ExpSalesDate = Convert.ToDateTime(txtExpSalesDate.Text);
                        }
                        else
                        {
                            _oUnsoldDefectiveProduct.ExpSalesDate = null;
                        }

                        _oUnsoldDefectiveProduct.UpdateCreateData();
                        DBController.Instance.CommitTransaction();

                        MessageBox.Show("Successfull Update Status DefectiveNo # " + sDefectiveNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _IsTrue = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                        _oUnsoldDefectiveProduct.DefectiveType = cmbDefectiveType.SelectedIndex + 1;

                        if (_oUnsoldDefectiveProduct.DefectiveType == (int)Dictionary.POSUnsoldDefectiveProductType.Functional)
                        {
                            _oUnsoldDefectiveProduct.IsLocallyRepaired = cmbIsLocallyRepaired.SelectedIndex;
                            if (cmbIsPltyApplied.SelectedIndex == 1)
                            {
                                _oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)Dictionary.IsPenaltyApplicable.No;
                            }
                            else if (cmbIsPltyApplied.SelectedIndex == 2)
                            {
                                _oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)Dictionary.IsPenaltyApplicable.Yes;
                            }
                            //_oUnsoldDefectiveProduct.DefectiveCategory = -1;
                            //_oUnsoldDefectiveProduct.IsRepairable = -1;
                            //_oUnsoldDefectiveProduct.IsLocallySaleable = -1;

                        }
                        else
                        {
                            //_oUnsoldDefectiveProduct.IsLocallyRepaired = -1;

                            if (cmbDefectiveCategory.SelectedIndex != 0)
                            {
                                _oUnsoldDefectiveProduct.DefectiveCategory = cmbDefectiveCategory.SelectedIndex; //+ 1;
                            }
                            else
                            {
                                _oUnsoldDefectiveProduct.DefectiveCategory = "";
                            }
                            _oUnsoldDefectiveProduct.IsRepairable = cmbIsRepairable.SelectedIndex;
                            _oUnsoldDefectiveProduct.IsLocallySaleable = cmbLocallySaleable.SelectedIndex;

                        }

                        _oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(txtProposedAmt.Text);
                        if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed)
                        {
                            _oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed;
                        }
                        else if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Discount_Approved)
                        {
                            _oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatus.Discount_Approved;
                            _oUnsoldDefectiveProduct.ApproveBy = Utility.UserId;
                            _oUnsoldDefectiveProduct.ApproveDate = DateTime.Now.Date;
                        }
                        else if (_nUIControl == (int)Dictionary.POSUnsouldDefectiveProductStatus.Reject)
                        {
                            _oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatus.Reject;
                        }
                        _oUnsoldDefectiveProduct.JobNo = txtJobNo.Text;
                        _oUnsoldDefectiveProduct.ApproveDicAmount = Convert.ToDouble(txtApprovedAmt.Text);

                        _oUnsoldDefectiveProduct.AssessmentFindings = txtAssessmentFinding.Text;

                        _oUnsoldDefectiveProduct.Accessories = txtAccessories.Text;
                        if (cmbTechRecommandation.SelectedIndex != 0)
                        {
                            _oUnsoldDefectiveProduct.TechRecommandation = cmbTechRecommandation.SelectedIndex;
                        }
                        else
                        {
                            _oUnsoldDefectiveProduct.TechRecommandation = "";
                        }
                        //_oUnsoldDefectiveProduct.TechRecommandation = cmbTechRecommandation.SelectedIndex + 1;
                        _oUnsoldDefectiveProduct.TechRemarks = txtTechRemarks.Text;

                        _oUnsoldDefectiveProduct.PaneltyAmount = Convert.ToDouble(txtPaneltyAmount.Text);
                        _oUnsoldDefectiveProduct.DefectiveID = nDefectiveID;
                        _oUnsoldDefectiveProduct.WarehouseID = nWarehouseID;
                        _oUnsoldDefectiveProduct.UpdateAssessmentData();
                        DBController.Instance.CommitTransaction();

                        MessageBox.Show("Successfull Update Status DefectiveNo # " + sDefectiveNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _IsTrue = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPaneltyAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPaneltyAmount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtPaneltyAmount.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPaneltyAmount.Text = "0.00";
                }

            }
        }
        private void txtProposedAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtProposedAmt.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtProposedAmt.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProposedAmt.Text = "0.00";
                }

            }
        }
        private void txtApprovedAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtApprovedAmt.Text.Trim() != "")
            {
                TELLib oTELLib = new TELLib();
                try
                {
                    double temp = Convert.ToDouble(txtApprovedAmt.Text);

                    txtNetMargin.Text = oTELLib.TakaFormat((Convert.ToDouble(txtRSP.Text) - Convert.ToDouble(txtSalePromotion.Text) - Convert.ToDouble(txtApprovedAmt.Text))- Convert.ToDouble(txtCostprice.Text));
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApprovedAmt.Text = "0.00";
                    txtNetMargin.Text = oTELLib.TakaFormat((Convert.ToDouble(txtRSP.Text) - Convert.ToDouble(txtSalePromotion.Text) - Convert.ToDouble(txtApprovedAmt.Text)) - Convert.ToDouble(txtCostprice.Text));
                }

            }
        }
        private void btnAssignJob_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    _oUnsoldDefectiveProduct.JobNo = txtJobNo.Text;
                    _oUnsoldDefectiveProduct.DefectiveID = nDefectiveID;
                    _oUnsoldDefectiveProduct.WarehouseID = nWarehouseID;
                    _oUnsoldDefectiveProduct.UpdateJobNo();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfull Update. DefectiveNo # " + sDefectiveNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _IsTrue = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmbDefectiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDefectiveType.SelectedIndex + 1 == (int)Dictionary.POSUnsoldDefectiveProductType.Functional)
            {
                cmbIsLocallyRepaired.Enabled = true;
                //cmbRepairStatus.Enabled = true;
                //cmbDefectiveCategory.Enabled = false;
                cmbIsRepairable.Enabled = false;
                cmbLocallySaleable.Enabled = false;
            }
            else
            {
                cmbIsLocallyRepaired.Enabled = false;
                //cmbRepairStatus.Enabled = false;
                cmbDefectiveCategory.Enabled = true;
                cmbIsRepairable.Enabled = true;
                cmbLocallySaleable.Enabled = true;
            }

        }
        private void cmbIsLocallyRepaired_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDefectiveType.SelectedIndex + 1 == (int)Dictionary.POSUnsoldDefectiveProductType.Functional)
            {
                if (cmbIsLocallyRepaired.SelectedIndex == (int)Dictionary.YesOrNoStatus.NO)
                {
                    //txtRepairstatus.Enabled = false;
                    //cmbTechRecommandation.SelectedIndex = 3;
                }
                else
                {
                    //cmbTechRecommandation.SelectedIndex = 0;
                }
            }
        }

        private void cmbIsRepairable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbLocallySaleable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtExpSalesDate_ValueChanged(object sender, EventArgs e)
        {
            txtExpSalesDate.Text = dtExpSalesDate.Value.ToString("dd-MMM-yyyy");
        }
    }
}