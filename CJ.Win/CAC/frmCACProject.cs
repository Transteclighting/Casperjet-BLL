using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;


namespace CJ.Win.CAC
{
    public partial class frmCACProject : Form
    {
        CACProject oCACProject;
        CACProjectSecurity oCACProjectSecurity;
        CACProjectTaskWeight oCACProjectTaskWeight;
        CACProjects oCACProjects;
        CACProjectTasks oCACProjectTasks;
        Brands oBrands;
        CACProjectDetail oCACProjectDetail;
        Suppliers oSuppliers;
        int nCustomerID = 0;
        int nSalesPersonID = 0;
        int nTechPersonID = 0;
        int _nStatus = 0;
        private bool IsAdjusting;
        public bool IsTrue = false;
        public frmCACProject(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(CACProject oCACProject)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oCACProject;
            //nCustomerID = 0;
            LoadCombo();
            ctlCustomer1.txtCode.Text = oCACProject.CustomerCode;
            ctlEmployee1.txtCode.Text= oCACProject.SalespersonCode;
            ctlEmployee2.txtCode.Text = oCACProject.TechCode;
            txtName.Text= oCACProject.ProjectName;
            txtQuotation.Text = oCACProject.QuotationNo;
            dtFromDate.Value = oCACProject.StartDate;
            dtTodate.Value= oCACProject.EndDate;
                        
            txtInstallationCharge.Text = oCACProject.InstallationCharge.ToString();
            txtOthersCharge.Text = oCACProject.OthersCharge.ToString();
            txtTotalProjectAmount.Text = oCACProject.TotalAmount.ToString();
            txtMISCExpAmount.Text = oCACProject.MISExpAmount.ToString();
            txtWarrantyProvisionAmount.Text = oCACProject.WarrantyProvisionAmount.ToString();
            dtCWStartDate.Value = oCACProject.ComWarrantyStartDate;
            dtCWEndDate.Value = oCACProject.ComWarrantyEndDate;
            dtSPWStartDate.Value = oCACProject.SPWarrantyStartDate;
            dtSPWEndDate.Value = oCACProject.SPWarrantyEndDate;
            dtSMWStartDate.Value = oCACProject.ServiceWarrantyStartDate;
            dtSMWEndDate.Value= oCACProject.ServiceWarrantyEndDate;
            txtTermsCondition.Text = oCACProject.TermsCondition;
            txtRemarks.Text = oCACProject.Remarks;
            cmbBrand.Text = oCACProject.BrandName;
            //cmbBrand.SelectedIndex = oCACProject.BrandID;
            //cmbBrand.SelectedIndex = oBrands.GetIndex(oCACProject.BrandID) +1;
            txtCapacity.Text = oCACProject.IndoorCapacityInTon.ToString();
            txtTon.Text = oCACProject.OutdoorCapacityInTon.ToString();

            CACProjects oCACProjects = new CACProjects();
            oCACProjects.RefreshByCACProjectDetails(oCACProject.ProjectID);
            foreach (CACProjectDetail oItem in oCACProjects)
            {                
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvProduct);
                    oRow.Cells[0].Value = oItem.ProductID.ToString();
                    oRow.Cells[1].Value = oItem.Code.ToString();
                    oRow.Cells[2].Value = oItem.ProductName.ToString();
                    oRow.Cells[3].Value = oItem.Qty.ToString();
                    oRow.Cells[4].Value = oItem.Amount.ToString();
                    dgvProduct.Rows.Add(oRow);               
            }
           
            oCACProjects.RefreshByCACProjectDetailsSupplier(oCACProject.ProjectID);
            foreach (CACProjectDetail oItem in oCACProjects)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvSupplier);
                oRow.Cells[0].Value = oItem.SupplierID.ToString();
                oRow.Cells[1].Value = oItem.SupplierName.ToString();
                oRow.Cells[2].Value = oItem.UnregisteredProductName.ToString();
                oRow.Cells[3].Value = oItem.Qty.ToString();
                oRow.Cells[4].Value = oItem.Amount.ToString();
                dgvSupplier.Rows.Add(oRow);
            }            
            CACProjectSecuritys oCACProjectSecuritys = new CACProjectSecuritys();
            oCACProjectSecuritys.Refresh(oCACProject.ProjectID);
            foreach (CACProjectSecurity oItem in oCACProjectSecuritys)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvSecurity);
                oRow.Cells[0].Value = Enum.GetName(typeof(Dictionary.CACProjectSecurity), oItem.SecurityID);
                oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.InstrumentType), oItem.InstrumentType);
                oRow.Cells[2].Value = oItem.ExpDate.ToString();
                oRow.Cells[3].Value = oItem.Amount.ToString();
                oRow.Cells[4].Value = oItem.SecurityID.ToString();
                oRow.Cells[5].Value = oItem.InstrumentType.ToString();
                dgvSecurity.Rows.Add(oRow);
            }
            GetTotal();
            GetTotalBySecurity();
            this.ShowDialog();
        }
        private void frmCACProject_Load(object sender, EventArgs e)
        {
            if (this.Tag == null || this.Tag == " ")
            {
                LoadCombo();
            }
            //GetTotal();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbSecurityDesc.Items.Clear();
            cmbSecurityDesc.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CACProjectSecurity)))
            {
                cmbSecurityDesc.Items.Add(Enum.GetName(typeof(Dictionary.CACProjectSecurity), GetEnum));
            }
            cmbSecurityDesc.SelectedIndex = 0;

            cmbInstrument.Items.Clear();
            //cmbInstrument.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrument.Items.Add(Enum.GetName(typeof(Dictionary.InstrumentType), GetEnum));
            }
            cmbInstrument.SelectedIndex = 0;

            oSuppliers = new Suppliers();
            oSuppliers.GetByCACSupplierName(); 
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("-- All--");
            foreach (Supplier oSupplier in oSuppliers)
            {
                cmbSupplier.Items.Add(oSupplier.SupplierName);
            }
            cmbSupplier.SelectedIndex = 0;

            oBrands = new Brands();
            oBrands.GetCACBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("-- All--");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearForproduct()
        {
            ctlProduct1.txtCode.Text = "";
            txtPQty.Text = "";
            txtProductValue.Text = "";
            txtTotalProjectAmount.Text = "";

        }
        private void ClearForSupply()
        {
            cmbSupplier.SelectedIndex = 0;
            txtSupQty.Text = "";
            txtSupValue.Text = "";
            txtUnrgisterproduct.Text = "";
            txtTotalProjectAmount.Text = "";

        }
        private void ClearForTask()
        {            
            //cmbTask.SelectedIndex = 0;
            //txtTaskWeight.Text = "";            
        }
        private void ClearForSecurity()
        {            
            cmbSecurityDesc.SelectedIndex = 0;
            cmbInstrument.SelectedIndex = 0;
            txtSecurityValue.Text = "";
            dtSecurityDate.Value = DateTime.Now;
        }
        private bool validateUIInput()
        {
            if (ctlCustomer1.txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            if (ctlEmployee1.txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Salesperson name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }
            if (ctlEmployee2.txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Techperson name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee2.txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please Input project name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtQuotation.Text.Trim()=="")
            {
                MessageBox.Show("Please Input Quotation Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuotation.Focus();
                return false;
            }
            if (cmbBrand.Text.Trim() == "-- All--")
            {
                MessageBox.Show("Please Input brand name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }
            if (Convert.ToDouble(txtTotalProjectAmount.Text.Trim()) <= 0)
            {
                MessageBox.Show("Please Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalProjectAmount.Focus();
                return false;
            }
            if (txtWarrantyProvisionAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Warranty Provision Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWarrantyProvisionAmount.Focus();
                return false;
            }
            try
            {
                Convert.ToInt32(txtWarrantyProvisionAmount.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Warranty Provision Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWarrantyProvisionAmount.Focus();
                return false;
            }
            if (txtMISCExpAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Input MISCExp Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMISCExpAmount.Focus();
                return false;
            }
            try
            {
                Convert.ToInt32(txtMISCExpAmount.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please Enter Valid MISCExp Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMISCExpAmount.Focus();
                return false;
            }
            if (txtTermsCondition.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Terms & Condition", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTermsCondition.Focus();
                return false;
            }
            //#region Transaction Details Information Validation

            //foreach (DataGridViewRow oItemRow in dgvCACCACProject.Rows)
            //{
            //    if (oItemRow.Index < dgvCACCACProject.Rows.Count - 1)
            //    {
            //        if (oItemRow.Cells[5].Value == null)
            //        {
            //            MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        //if (oItemRow.Cells[4].Value.ToString().Trim() == "")
            //        //{
            //        //    MessageBox.Show("Please Input Ton", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //    return false;
            //        //}
            //        if (oItemRow.Cells[7].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }
            //}
            //#endregion

            return true;
        }
        public CACProject GetUIData(CACProject oCACProject)
        {
            oCACProject.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            oCACProject.SalesPersonID= ctlEmployee1.SelectedEmployee.EmployeeID;
            oCACProject.TechPersonID = ctlEmployee2.SelectedEmployee.EmployeeID;
            oCACProject.ProjectName = txtName.Text;                       
            oCACProject.QuotationNo = txtQuotation.Text;
            oCACProject.StartDate = dtFromDate.Value;
            oCACProject.EndDate = dtTodate.Value;
            oCACProject.MISExpAmount = Convert.ToDouble(txtMISCExpAmount.Text.ToString());
            oCACProject.WarrantyProvisionAmount = Convert.ToDouble(txtWarrantyProvisionAmount.Text.ToString());
            oCACProject.InstallationCharge = Convert.ToDouble(txtInstallationCharge.Text.ToString());
            oCACProject.OthersCharge = Convert.ToDouble(txtOthersCharge.Text.ToString());            
            oCACProject.Remarks = txtRemarks.Text;
            oCACProject.TermsCondition = txtTermsCondition.Text;
            //oCACProject.CompleteTaskValue = 0;
            //oCACProject.InvoiceAmount = 0;
            //oCACProject.TotalOtherPayment = 0;
            if (_nStatus == (int)Dictionary.CACProjectStatus.Create)
            {
                oCACProject.Status = (int)Dictionary.CACProjectStatus.Create;
            }
            else if (_nStatus == (int)Dictionary.CACProjectStatus.Running)
            {
                oCACProject.Status = (int)Dictionary.CACProjectStatus.Running;
            }
            else if (_nStatus == (int)Dictionary.CACProjectStatus.Complete)
            {
                oCACProject.Status = (int)Dictionary.CACProjectStatus.Complete;
            }
            else if (_nStatus == (int)Dictionary.CACProjectStatus.Pending)
            {
                oCACProject.Status = (int)Dictionary.CACProjectStatus.Pending;
            }
            else if (_nStatus == (int)Dictionary.CACProjectStatus.Cancel)
            {
                oCACProject.Status = (int)Dictionary.CACProjectStatus.Cancel;
            }
            else if (_nStatus == (int)Dictionary.CACProjectStatus.Handover)
            {
                oCACProject.Status = (int)Dictionary.CACProjectStatus.Handover;
            }
            oCACProject.TotalAmount = Convert.ToDouble(txtTotalProjectAmount.Text.ToString());
            oCACProject.CreateUserID = Utility.UserId;
            oCACProject.CreateDate = DateTime.Now;
            oCACProject.ComWarrantyStartDate = dtCWStartDate.Value;
            oCACProject.ComWarrantyEndDate = dtCWEndDate.Value;
            oCACProject.SPWarrantyStartDate = dtSPWStartDate.Value;
            oCACProject.SPWarrantyEndDate = dtSPWEndDate.Value;
            oCACProject.ServiceWarrantyStartDate = dtSMWStartDate.Value;
            oCACProject.ServiceWarrantyEndDate = dtSMWEndDate.Value;
            //oCACProject.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            oCACProject.BrandID = oBrands[cmbBrand.SelectedIndex -1].BrandID;
            oCACProject.IndoorCapacityInTon = Convert.ToDouble(txtCapacity.Text);
            oCACProject.OutdoorCapacityInTon = Convert.ToDouble(txtTon.Text);
            // Details for product
            foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
            {
                if (oItemRow.Index < dgvProduct.Rows.Count)
                {
                    CACProjectDetail oCACProjectDetail = new CACProjectDetail();
                    oCACProjectDetail.ProductID = oItemRow.Cells[0].Value.ToString();
                    oCACProjectDetail.Type= (int)Dictionary.CACProjectType.Product;
                    oCACProjectDetail.Qty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    oCACProjectDetail.Amount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                    oCACProject.Add(oCACProjectDetail);

                }
            }
            // Details for Supplier
            foreach (DataGridViewRow oItemRow in dgvSupplier.Rows)
            {
                if (oItemRow.Index < dgvSupplier.Rows.Count)
                {
                    CACProjectDetail oCACProjectDetail = new CACProjectDetail();
                    oCACProjectDetail.SupplierID = oItemRow.Cells[0].Value.ToString();
                    oCACProjectDetail.UnregisteredProductName = oItemRow.Cells[2].Value.ToString();
                    oCACProjectDetail.Type = (int)Dictionary.CACProjectType.Supplier;
                    oCACProjectDetail.Qty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    oCACProjectDetail.Amount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                    oCACProjectDetail.OtherSales = 0;
                    oCACProjectDetail.OtherPayment = 0;
                    oCACProject.Add(oCACProjectDetail);

                }
            }
            return oCACProject;
        }
        private void Save()
        {
            if (this.Tag != null)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        CACProject oCACProject = (CACProject)this.Tag;
                        oCACProject = GetUIData(oCACProject);
                        oCACProject.UpdateUserID = Utility.UserId;
                        oCACProject.UpdateDate = DateTime.Now; 
                        oCACProject.Edit();
                        oCACProjectSecurity = new CACProjectSecurity();
                        oCACProjectSecurity.DeleteBySecurity(oCACProject.ProjectID);
                        ADDCACProjectSecurity(oCACProject);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update CACProject # " + oCACProject.ProjectCode.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {


                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oCACProject = new CACProject();
                        oCACProject = GetUIData(oCACProject);
                        oCACProject.Status = (int)Dictionary.CACProjectStatus.Create;
                        oCACProject.Add();
                        ADDCACProjectSecurity(oCACProject);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add CACProject # " + oCACProject.ProjectCode.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void ADDCACProjectTaskWeight(CACProject _oCACProjectTaskWeight)
        {           
            //foreach (DataGridViewRow oItemRow in dgvTask.Rows)
            //{
            //    if (oItemRow.Index < dgvTask.Rows.Count)
            //    {
            //        oCACProjectTaskWeight = new CACProjectTaskWeight();
            //        oCACProjectTaskWeight.ProjectID = _oCACProjectTaskWeight.ProjectID;
            //        oCACProjectTaskWeight.TaskID = int.Parse(oItemRow.Cells[2].Value.ToString());
            //        oCACProjectTaskWeight.Weight = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
            //        oCACProjectTaskWeight.Percentage = 0;
            //        oCACProjectTaskWeight.Add();

            //    }
            //}

        }
        private void ADDCACProjectSecurity(CACProject _oCACProjectSecurity)
        {
            foreach (DataGridViewRow oItemRow in dgvSecurity.Rows)
            {
                if (oItemRow.Index < dgvSecurity.Rows.Count)
                {
                    oCACProjectSecurity = new CACProjectSecurity();
                    oCACProjectSecurity.ProjectID = _oCACProjectSecurity.ProjectID;
                    oCACProjectSecurity.SecurityID = int.Parse(oItemRow.Cells[4].Value.ToString());
                    oCACProjectSecurity.InstrumentType = int.Parse(oItemRow.Cells[5].Value.ToString());
                    oCACProjectSecurity.ExpDate = Convert.ToDateTime(oItemRow.Cells[2].Value.ToString());
                    oCACProjectSecurity.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                    oCACProjectSecurity.Add();

                }
            }

        }
        private bool CheckUIGridViewProductWise()
        {
            if (ctlProduct1.txtCode.Text == "")
            {
                MessageBox.Show("Please Input Product Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }
            //if (cmbMag.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select MAG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbMag.Focus();
            //    return false;
            //}
            if (txtPQty.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPQty.Focus();
                return false;
            }            
            if (txtProductValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductValue.Focus();
                return false;
            }
            try
            {
                Convert.ToDouble(txtProductValue.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductValue.Focus();
                return false;
            }
            return true;
        }
        private bool CheckUIGridViewSupplierWise()
        {

            if (cmbSupplier.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return false;
            }
            if (txtSupQty.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupQty.Focus();
                return false;
            }
            if (txtSupValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupValue.Focus();
                return false;
            }
            try
            {
                Convert.ToDouble(txtSupValue.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupValue.Focus();
                return false;
            }
            return true;
        }
        private bool CheckUIGridViewSTaskWise()
        {

            //if (cmbTask.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Task", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbTask.Focus();
            //    return false;
            //}
            //if (txtTaskWeight.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Input task weight", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTaskWeight.Focus();
            //    return false;
            //}
            //try
            //{
            //    Convert.ToInt32(txtTaskWeight.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("Please Enter Valid task weight", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTaskWeight.Focus();
            //    return false;
            //}
            return true;
        }
        private bool CheckUIGridViewSecurityWise()
        {

            if (cmbSecurityDesc.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select desc", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSecurityDesc.Focus();
                return false;
            }
            if (cmbInstrument.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select InstrumentNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInstrument.Focus();
                return false;
            }
            if (txtSecurityValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSecurityValue.Focus();
                return false;
            }
            try
            {
                Convert.ToDouble(txtSecurityValue.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSecurityValue.Focus();
                return false;
            }
            return true;
        }
        private void AddProductList()
        {
            double nTotalQty = Convert.ToDouble(txtPQty.Text);
            double nTotalAmount = Convert.ToDouble(txtProductValue.Text);
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvProduct);
            oRow.Cells[0].Value = ctlProduct1.SelectedSerarchProduct.ProductID;
            oRow.Cells[1].Value = ctlProduct1.SelectedSerarchProduct.ProductCode;
            oRow.Cells[2].Value = ctlProduct1.SelectedSerarchProduct.ProductName;
            oRow.Cells[3].Value = txtPQty.Text;
            oRow.Cells[4].Value = nTotalQty* nTotalAmount;
            dgvProduct.Rows.Add(oRow);                      
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (CheckUIGridViewProductWise())
            {
                AddProductList();
                ClearForproduct();
                GetTotal();
            }
        }
        private void GetTotal()
        {
            txtRegisterQtyTotal.Text = "0";
            txtTotalRegisterAmount.Text = "0.00";
            txtUnregisterQtyTotal.Text = "0";
            txtTotalSupAmount.Text = "0.00";
            double nTotalAmount = 0.00;
            txtTotalProjectAmount.Text = "0.00";

            foreach (DataGridViewRow oRow in dgvProduct.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {

                    txtRegisterQtyTotal.Text = Convert.ToDouble(Convert.ToDouble(txtRegisterQtyTotal.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                    txtTotalRegisterAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalRegisterAmount.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();

                }
            }
            foreach (DataGridViewRow oRow in dgvSupplier.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {

                    txtUnregisterQtyTotal.Text = Convert.ToDouble(Convert.ToDouble(txtUnregisterQtyTotal.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                    txtTotalSupAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalSupAmount.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();

                }
            }
        }                      
        private void GetTotalBySecurity()
        {
            txtTotalSecurityAmount.Text = "0.00";
            
            foreach (DataGridViewRow oRow in dgvSecurity.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {

                    txtTotalSecurityAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalSecurityAmount.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();

                }
            }            
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            if (nColumnIndex == 3)
            {
                if (dgvProduct.Rows[nRowIndex].Cells[3].Value.ToString() != null)
                {
                    try
                    {
                        dgvProduct.Rows[nRowIndex].Cells[3].Value = Convert.ToDouble(dgvProduct.Rows[nRowIndex].Cells[3].Value.ToString());
                        dgvProduct.Rows[nRowIndex].Cells[4].Value = Convert.ToDouble(dgvProduct.Rows[nRowIndex].Cells[4].Value.ToString());
                    }
                    catch
                    {
                        //MessageBox.Show("");

                    }
                }
                
                else if (dgvSupplier.Rows[nRowIndex].Cells[3].Value.ToString() != null)
                {
                    try
                    {
                        dgvSupplier.Rows[nRowIndex].Cells[3].Value = Convert.ToDouble(dgvProduct.Rows[nRowIndex].Cells[3].Value.ToString());
                        dgvSupplier.Rows[nRowIndex].Cells[4].Value = Convert.ToDouble(dgvProduct.Rows[nRowIndex].Cells[4].Value.ToString());

                    }
                    catch
                    {
                        //MessageBox.Show("");

                    }
                }                
                else if (dgvSecurity.Rows[nRowIndex].Cells[3].Value.ToString() != null)
                {
                    try
                    {
                        dgvSecurity.Rows[nRowIndex].Cells[3].Value = Convert.ToDouble(dgvSecurity.Rows[nRowIndex].Cells[3].Value.ToString());

                    }
                    catch
                    {
                        //MessageBox.Show("");

                    }
                }
                GetTotal();
                GetTotalBySecurity();
            }
        }            

        private void AddSupplierList()
        {
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvSupplier);
            oRow.Cells[0].Value = oSuppliers[cmbSupplier.SelectedIndex - 1].SupplierID;
            oRow.Cells[1].Value = cmbSupplier.Text;
            oRow.Cells[2].Value = txtUnrgisterproduct.Text;
            oRow.Cells[3].Value = txtSupQty.Text;
            oRow.Cells[4].Value = txtSupValue.Text.ToString();
            dgvSupplier.Rows.Add(oRow);                      
        }
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (CheckUIGridViewSupplierWise())
            {
                AddSupplierList();
                ClearForSupply();
                GetTotal();
            }
        }
        private void GetNetCharge()
        {
            double nTotalRegisterAmount = Convert.ToDouble(txtTotalRegisterAmount.Text);
            double nTotalUnRegisterAmount = Convert.ToDouble(txtTotalSupAmount.Text);
            double nOtherCharge = Convert.ToDouble(txtOthersCharge.Text);
            double nInstallation = Convert.ToDouble(txtInstallationCharge.Text);
            double nNetCharge = nTotalRegisterAmount + nTotalUnRegisterAmount + nOtherCharge+ nInstallation;
            txtTotalProjectAmount.Text = nNetCharge.ToString();
        }
        private void AddTaskList()
        {
            //DataGridViewRow oRow = new DataGridViewRow();
            //oRow.CreateCells(dgvTask);
            //oRow.Cells[0].Value = oCACProjectTasks[cmbTask.SelectedIndex - 1].TaskName;           
            //oRow.Cells[1].Value = txtTaskWeight.Text;
            //oRow.Cells[2].Value = oCACProjectTasks[cmbTask.SelectedIndex - 1].TaskID;
            //dgvTask.Rows.Add(oRow);
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            //if (CheckUIGridViewSTaskWise())
            //{
            //    AddTaskList();
            //    ClearForTask();
            //    GetTotal();
            //    GetTotalBySecurity();
            //}
        }

        private void btnAddSecurity_Click(object sender, EventArgs e)
        {
            if (CheckUIGridViewSecurityWise())
            {
                AddSecurityList();
                ClearForSecurity();
                GetTotalBySecurity();
            }
        }
        private void AddSecurityList()
        {
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvSecurity);
            oRow.Cells[0].Value = cmbSecurityDesc.Text;
            oRow.Cells[1].Value = cmbInstrument.Text;
            oRow.Cells[2].Value = dtSecurityDate.Value;
            oRow.Cells[3].Value = txtSecurityValue.Text;
            oRow.Cells[4].Value = cmbSecurityDesc.SelectedIndex;
            oRow.Cells[5].Value = cmbInstrument.SelectedIndex;
            dgvSecurity.Rows.Add(oRow);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                ClearForproduct();
                ClearForSecurity();
                ClearForSupply();
                //ClearForTask();
            }
        }

        private void dgvProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
            GetTotal();
        }

        private void dgvSupplier_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvProduct_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private void dgvSupplier_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private void dgvSecurity_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalBySecurity();
        }

        private void dgvSecurity_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void txtTotalProjectAmount_TextChanged(object sender, EventArgs e)
        {
            //GetNetCharge();
        }

        private void txtTotalRegisterAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalSupAmount.Text.Trim() != string.Empty && txtTotalRegisterAmount.Text.Trim() != string.Empty)
            {
                GetNetCharge();
            }
            else
            {
                txtTotalSupAmount.Text = "0.00";
            }
        }

        private void txtTotalSupAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalRegisterAmount.Text.Trim() != string.Empty && txtTotalSupAmount.Text.Trim() != string.Empty)
            {
                GetNetCharge();
            }
            else
            {
                txtTotalRegisterAmount.Text = "0.00";
            }
        }

        private void txtInstallationCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtInstallationCharge.Text != string.Empty)
            {
                GetNetCharge();
            }
            else
            {
                txtInstallationCharge.Text = "0.00";
            }
        }

        private void txtOthersCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtOthersCharge.Text != string.Empty)
            {
                GetNetCharge();
            }
            else
            {
                txtOthersCharge.Text = "0.00";
            }
        }

        private void dgvTask_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //GetTotal();
        }
        
        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "")
            {
                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;

                DBController.Instance.OpenNewConnection();
                oProductPrice.RefreshByProductID();
                DBController.Instance.CloseConnection();                
                txtProductValue.Text = oProductPrice.RSP.ToString();                
            }
        }
        private void txtTermsCondition_TextChanged(object sender, EventArgs e)
        {
            if (txtTermsCondition.SelectionFont == null)
                return;

            bool isBold = (txtTermsCondition.SelectionFont.Style & FontStyle.Bold) == FontStyle.Bold;
            IsAdjusting = true;
            ckBold.Checked= isBold;
            IsAdjusting = false;
        }
        private void ckBold_CheckedChanged(object sender, EventArgs e)
        {
            if (IsAdjusting)
                return;
            SetBold(ckBold.Checked);
        }
        private void SetBold(bool bold)
        {
            if (txtTermsCondition.SelectionFont == null)
                return;

            FontStyle style = txtTermsCondition.SelectionFont.Style;
            style = bold ? style | FontStyle.Bold : style & ~FontStyle.Bold;
            txtTermsCondition.SelectionFont = new Font(txtTermsCondition.SelectionFont, style);
        }
    }
}
