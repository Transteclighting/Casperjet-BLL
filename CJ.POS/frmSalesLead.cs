using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Control;

namespace CJ.POS
{
    public partial class frmSalesLead : Form
    {
        ProductGroups _oMAG;
        Brands _oBrands;
        SalesLead _oSalesLead;
        int nLeadID = 0;
        string sLeadNo = "";
        SystemInfo _oSystemInfo;
        Employees oEmployees;
        int nWarehouseID = 0;
        int nTerminal = 0;
        int nStatus = 1;
        string sCompanyName = "";
        string sCustName = "";
        string sAge = "";
        string sAddress = "";
        string sEmail = "";
        string sContact = "";
        string sProfession = "";
        string sIncom = "";
        SalesLeads _oActivations;
        int nCustomerType = 0;
        RetailConsumer oRetailConsumer;
        int nConsumerID = 0;
        int _nType = 0;

        string _sPCustomerName = "";
        string _sPMobileNo = "";
        string _sPEmail = "";
        string _sPCompany = "";
        string _sPAddress = "";
        int _nPWHID = 0;
        int _nPotentialID = 0;
        public bool _IsTrue = false;
        GeoLocations oDistrict;
        GeoLocations oThana;
        public frmSalesLead(int nType,string sCustomerName,string sMobileNo,string sEmail,string sCompany,string sAddress,int nWHID,int nPotentialID)
        {
            InitializeComponent();
            _nType = nType;
            _sPCustomerName = sCustomerName;
            _sPMobileNo = sMobileNo;
            _sPEmail = sEmail;
            _sPCompany = sCompany;
            _sPAddress = sAddress;
            _nPWHID = nWHID;
            _nPotentialID = nPotentialID;
        }

        private void SalesLead_Load(object sender, EventArgs e)
        {
            txtLeadNo.Enabled = false;
            btnPicker.Enabled = false;
            btnPaste.Enabled = false;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oSystemInfo = new SystemInfo();
            _oSystemInfo.Refresh();
            if (this.Tag == null)
            {
                this.Text = "Add New SalesLead";
                DBController.Instance.OpenNewConnection();
                LoadCombos();
                rdoNewConsumer.Checked = true;
                lblActivationName.Visible = false;
                cmbActivation.Visible = false;

                if (_nType == 2)
                {
                    txtName.Text = _sPCustomerName;
                    txtAddress.Text = _sPAddress;
                    txtContact.Text = _sPMobileNo;
                    txtEmail.Text = _sPEmail;
                    txtCompany.Text = _sPCompany;

                }

            }
            else
            {
                this.Text = "Edit SalesLead";
            }


        }

        private void LoadCombos()
        {

            //Customer Type 
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CustomerTypeSalesLead)))
            {
                cmbCustomerType.Items.Add(Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), GetEnum));
            }
            cmbCustomerType.SelectedIndex = 0;

            //Conversion Possibility
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeadConversionPossibility)))
            {
                cmbConversionPossibility.Items.Add(Enum.GetName(typeof(Dictionary.LeadConversionPossibility), GetEnum));
            }
            cmbConversionPossibility.SelectedIndex = 0;

            ////MAG 
            //_oMAG = new ProductGroups();
            //_oMAG.Refresh(Dictionary.ProductGroupType.MAG);
            //cmbMAG.Items.Clear();
            //cmbMAG.Items.Add("<Select MAG>");
            //foreach (ProductGroup oProductGroup in _oMAG)
            //{
            //    cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            //}
            //cmbMAG.SelectedIndex = 0;

            ////Brand 
            //_oBrands = new Brands();
            //_oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            //cmbBrand.Items.Clear();
            //cmbBrand.Items.Add("<Select Brand>");
            //foreach (Brand oBrand in _oBrands)
            //{
            //    cmbBrand.Items.Add(oBrand.BrandDesc);
            //}
            //cmbBrand.SelectedIndex = 0;

            //Sales Person
            oEmployees = new Employees();
            cmbSalesPerson.Items.Clear();
            oEmployees.GetShowroomSalesPerson();
            cmbSalesPerson.Items.Add("<Select Sales Person>");
            foreach (Employee oEmployee in oEmployees)
            {
                cmbSalesPerson.Items.Add(oEmployee.EmployeeName);
            }
            if (oEmployees.Count > 0)
                cmbSalesPerson.SelectedIndex = 0;


            //Lead Source
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeadSource)))
            {
                cmbLeadSource.Items.Add(Enum.GetName(typeof(Dictionary.LeadSource), GetEnum));
            }
            cmbLeadSource.SelectedIndex = 0;

            //Get Activation 
            _oActivations = new SalesLeads();
            cmbActivation.Items.Clear();
            cmbActivation.Items.Add("<Select Activation>");
            _oActivations.GetActivation();
            foreach (SalesLead oActivation in _oActivations)
            {
                cmbActivation.Items.Add(oActivation.ActivationName);
            }
            cmbActivation.SelectedIndex = 0;


            //District
            oDistrict = new GeoLocations();
            oDistrict.RefreshDistrict();
            cmbDistrict.Items.Clear();
            cmbDistrict.Items.Add("<Select a District>");
            foreach (GeoLocation oDistricts in oDistrict)
            {
                cmbDistrict.Items.Add(oDistricts.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _IsTrue = false;
            this.Close();
        }

        private bool UIValidation()
        {
            #region ValidInput
            if (ctlProduct1.txtCode.Text == "")
            {
                MessageBox.Show("Please enter valid product code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }
            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please enter valid product code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtDescription.Focus();
                return false;
            }

            if (cmbSalesPerson.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Sales Person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSalesPerson.Focus();
                return false;
            }


            if (cmbDistrict.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a District", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDistrict.Focus();
                return false;
            }

            if (cmbThana.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Thana", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbThana.Focus();
                return false;
            }
            //if (cmbMAG.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select MAG ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbMAG.Focus();
            //    return false;
            //}
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtContact.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Contact No ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            else
            {
                double tempAmt = 0;
                try
                {
                    tempAmt = Convert.ToDouble(txtAmount.Text);

                }
                catch
                {
                    tempAmt = 0;
                }
                if (tempAmt <= 0)
                {
                    MessageBox.Show("Lead amount must be >0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return false;
                }
            }

            if (txtQty.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
                return false;
            }
            else
            {
                int tempQty = 0;
                try
                {
                    tempQty = Convert.ToInt32(txtQty.Text);
                }
                catch
                {
                    tempQty = 0;
                }
                if (tempQty <= 0)
                {
                    MessageBox.Show("Lead qty must be >0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQty.Focus();
                    return false;
                }
            }

            if (rdoExistingConsumer.Checked == true)
            {
                if (txtLeadCustName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Existing Lead No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLeadNo.Focus();
                    return false;
                }
            }


            if (cmbLeadSource.SelectedIndex != 0)
            {
                if (cmbActivation.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Activation Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbActivation.Focus();
                    return false;
                }
            }
            #endregion
            return true;

        }

        public void ShowDialog(SalesLead oSalesLead)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oSalesLead;
            nTerminal = oSalesLead.Terminal;
            nCustomerType = oSalesLead.CustomerType;
            LoadCombos();
            nLeadID = 0;
            nLeadID = oSalesLead.LeadID;
            nWarehouseID = oSalesLead.WarehouseID;
            sLeadNo = "";
            sLeadNo = oSalesLead.LeadNo;
            nStatus = oSalesLead.Status;
            dtLeadDate.Enabled = false;
            if (oSalesLead.Terminal == (int)Dictionary.Terminal.Head_Office)
            {
                txtLeadNo.Enabled = false;
                btnPicker.Enabled = false;
                rdoExistingConsumer.Enabled = false;
                rdoNewConsumer.Enabled = false;
                txtCompany.Enabled = false;
                txtName.Enabled = false;
                txtAGE.Enabled = false;
                txtAddress.Enabled = false;
                txtEmail.Enabled = false;
                txtContact.Enabled = false;
                txtProfession.Enabled = false;
                txtIncomLevel.Enabled = false;
                cmbCustomerType.Enabled = false;
            }
            if (oSalesLead.IsExistingConsumer == (int)Dictionary.YesOrNoStatus.YES)
            {
                rdoExistingConsumer.Checked = true;
                rdoNewConsumer.Checked = false;
                txtLeadNo.Text = oSalesLead.RefLeadNo;
            }
            else
            {
                rdoExistingConsumer.Checked = false;
                rdoNewConsumer.Checked = true;
            }
            ctlProduct1.txtCode.Text = oSalesLead.ProductCode;

            txtCompany.Text = oSalesLead.CompanyName;
            txtName.Text = oSalesLead.Name;
            txtAddress.Text = oSalesLead.Address;
            txtContact.Text = oSalesLead.ContactNo;
            txtEmail.Text = oSalesLead.Email;
            txtProfession.Text = oSalesLead.Profession;
            txtAGE.Text = oSalesLead.AgeLevel;
            txtIncomLevel.Text = oSalesLead.IncomLevel;
            //txtModel.Text = oSalesLead.ModelName;
            txtAmount.Text = oSalesLead.LeadAmount.ToString();
            txtRemarks.Text = oSalesLead.Remarks;
            dtLeadDate.Value = oSalesLead.LeadDate;
            dtFollowUpdate.Value = oSalesLead.NextFollowUpDate;
            dtExpExcDate.Value = oSalesLead.ExpExecuteDate;
            txtQty.Text = oSalesLead.Qty.ToString();
            cmbCustomerType.SelectedIndex = nCustomerType - 1;
            int nConversionPos = oSalesLead.ConversionPossibility;
            cmbConversionPossibility.SelectedIndex = nConversionPos - 1;
            //int nBrandIndex = 0;
            //nBrandIndex = _oBrands.GetIndex(oSalesLead.BrandID);
            //cmbBrand.SelectedIndex = nBrandIndex + 1;
            //int nMAGIndex = 0;
            //nMAGIndex = _oMAG.GetIndex(oSalesLead.MAGID);
            //cmbMAG.SelectedIndex = nMAGIndex + 1;
            if (oSalesLead.DistrictID != -1)
                cmbDistrict.SelectedIndex = oDistrict.GetIndexByID(oSalesLead.DistrictID) + 1;
            if (oSalesLead.ThanaID != -1)
                cmbThana.SelectedIndex = oThana.GetIndexByID(oSalesLead.ThanaID) + 1;

            int nSalesPerson = 0;
            nSalesPerson = oEmployees.GetIndex(oSalesLead.SalesPersonID);
            cmbSalesPerson.SelectedIndex = nSalesPerson + 1;
            cmbLeadSource.SelectedIndex = oSalesLead.LeadSource;
            if (oSalesLead.LeadSource == (int)Dictionary.LeadSource.General)
            {

                lblActivationName.Visible = false;
                cmbActivation.Visible = false;
            }
            else
            {
                lblActivationName.Visible = true;
                cmbActivation.Visible = true;
                if (oSalesLead.ActivationID != -1)
                {
                    int nActivation = 0;
                    nActivation = _oActivations.GetActivationIndex(oSalesLead.ActivationID);
                    cmbActivation.SelectedIndex = nActivation + 1;
                }
                else
                {
                    cmbActivation.SelectedIndex = 0;
                }
            }

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oSalesLead = new SalesLead();
                        _oSalesLead.LeadID = nLeadID;
                        _oSalesLead.LeadNo = sLeadNo;
                        _oSalesLead.WarehouseID = nWarehouseID;
                        _oSalesLead.LeadDate = dtLeadDate.Value.Date;
                        _oSalesLead.ExpExecuteDate = dtExpExcDate.Value.Date;
                        _oSalesLead.CustomerType = cmbCustomerType.SelectedIndex + 1;
                        _oSalesLead.ConversionPossibility = cmbConversionPossibility.SelectedIndex + 1;
                        _oSalesLead.CompanyName = txtCompany.Text;
                        _oSalesLead.Name = txtName.Text;
                        _oSalesLead.Address = txtAddress.Text;
                        _oSalesLead.ContactNo = txtContact.Text;
                        _oSalesLead.Email = txtEmail.Text;
                        _oSalesLead.Profession = txtProfession.Text;
                        _oSalesLead.AgeLevel = txtAGE.Text;
                        _oSalesLead.IncomLevel = txtIncomLevel.Text;
                        //_oSalesLead.MAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
                        //_oSalesLead.BrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                        _oSalesLead.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                        _oSalesLead.MAGID = ctlProduct1.SelectedSerarchProduct.MAGID;
                        _oSalesLead.BrandID = ctlProduct1.SelectedSerarchProduct.BrandID;
                        if (ctlProduct1.SelectedSerarchProduct.ProductModel != "")
                            _oSalesLead.ModelName = ctlProduct1.SelectedSerarchProduct.ProductModel;
                        else _oSalesLead.ModelName = ctlProduct1.SelectedSerarchProduct.ProductName;


                        _oSalesLead.LeadAmount = Convert.ToDouble(txtAmount.Text);
                        _oSalesLead.Remarks = txtRemarks.Text;
                        _oSalesLead.NextFollowUpDate = dtFollowUpdate.Value.Date;
                        _oSalesLead.Terminal = nTerminal;
                        _oSalesLead.SalesPersonID = oEmployees[cmbSalesPerson.SelectedIndex - 1].EmployeeID;
                        _oSalesLead.Status = nStatus;
                        if (cmbLeadSource.SelectedIndex != 0)
                        {
                            _oSalesLead.LeadSource = cmbLeadSource.SelectedIndex;
                            _oSalesLead.ActivationID = _oActivations[cmbActivation.SelectedIndex - 1].ActivationID;
                        }
                        else
                        {
                            _oSalesLead.LeadSource = cmbLeadSource.SelectedIndex;
                            _oSalesLead.ActivationID = -1;
                        }
                        _oSalesLead.Qty = Convert.ToInt32(txtQty.Text);
                        if (rdoExistingConsumer.Checked == true)
                        {
                            _oSalesLead.IsExistingConsumer = (int)Dictionary.YesOrNoStatus.YES;
                            _oSalesLead.RefLeadNo = txtLeadNo.Text;
                        }
                        else
                        {
                            _oSalesLead.IsExistingConsumer = (int)Dictionary.YesOrNoStatus.NO;
                            _oSalesLead.RefLeadNo = "";
                        }
                        _oSalesLead.ConsumerID = nConsumerID;

                        _oSalesLead.ThanaID = oThana[cmbThana.SelectedIndex - 1].GeoLocationID;

                        _oSalesLead.EditForPOS();
                        _oSalesLead.AddHistory();
                        _IsTrue = true;
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update SalesLead. SalesLead# " + sLeadNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbCustomerType.SelectedIndex = 0;
                        cmbConversionPossibility.SelectedIndex = 0;
                        dtLeadDate.Value = DateTime.Now.Date;
                        dtExpExcDate.Value = DateTime.Now.Date;
                        txtCompany.Text = "";
                        txtName.Text = "";
                        txtAGE.Text = "";
                        txtEmail.Text = "";
                        txtAddress.Text = "";
                        txtContact.Text = "";
                        txtProfession.Text = "";
                        txtIncomLevel.Text = "";
                        //cmbBrand.SelectedIndex = 0;
                        //cmbMAG.SelectedIndex = 0;
                        //txtModel.Text = "";
                        txtAmount.Text = "";
                        txtQty.Text = "";
                        dtFollowUpdate.Value = DateTime.Now.Date;
                        cmbSalesPerson.SelectedIndex = 0;
                        txtRemarks.Text = "";
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


                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oSalesLead = new SalesLead();
                        _oSystemInfo = new SystemInfo();
                        _oSystemInfo.Refresh();
                        _oSalesLead.WarehouseID = _oSystemInfo.WarehouseID;
                        _oSalesLead.LeadDate = dtLeadDate.Value.Date;
                        _oSalesLead.ExpExecuteDate = dtExpExcDate.Value.Date;
                        _oSalesLead.CustomerType = cmbCustomerType.SelectedIndex + 1;
                        _oSalesLead.ConversionPossibility = cmbConversionPossibility.SelectedIndex + 1;
                        _oSalesLead.CompanyName = txtCompany.Text;
                        _oSalesLead.Name = txtName.Text;
                        _oSalesLead.Address = txtAddress.Text;
                        _oSalesLead.ContactNo = txtContact.Text;
                        _oSalesLead.Email = txtEmail.Text;
                        _oSalesLead.Profession = txtProfession.Text;
                        _oSalesLead.AgeLevel = txtAGE.Text;
                        _oSalesLead.IncomLevel = txtIncomLevel.Text;
                        //_oSalesLead.MAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
                        //_oSalesLead.BrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                        _oSalesLead.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                        _oSalesLead.MAGID = ctlProduct1.SelectedSerarchProduct.MAGID;
                        _oSalesLead.BrandID = ctlProduct1.SelectedSerarchProduct.BrandID;
                        if (ctlProduct1.SelectedSerarchProduct.ProductModel != "")
                            _oSalesLead.ModelName = ctlProduct1.SelectedSerarchProduct.ProductModel;
                        else _oSalesLead.ModelName = ctlProduct1.SelectedSerarchProduct.ProductName;
                        _oSalesLead.NextFollowUpDate = dtFollowUpdate.Value.Date;
                        _oSalesLead.LeadAmount = Convert.ToDouble(txtAmount.Text);
                        _oSalesLead.Status = (int)Dictionary.SalesLeadStatusPOS.Create;
                        _oSalesLead.Remarks = txtRemarks.Text;
                        _oSalesLead.CreateDate = DateTime.Now.Date;
                        _oSalesLead.CreateUserID = Utility.UserId;
                        _oSalesLead.Terminal = (int)Dictionary.Terminal.Branch_Office;
                        _oSalesLead.SalesPersonID = oEmployees[cmbSalesPerson.SelectedIndex - 1].EmployeeID;
                        _oSalesLead.Qty = Convert.ToInt32(txtQty.Text);
                        _oSalesLead.ThanaID = oThana[cmbThana.SelectedIndex - 1].GeoLocationID;

                        if (cmbLeadSource.SelectedIndex != 0)
                        {
                            _oSalesLead.LeadSource = cmbLeadSource.SelectedIndex;
                            _oSalesLead.ActivationID = _oActivations[cmbActivation.SelectedIndex - 1].ActivationID;
                        }
                        else
                        {
                            _oSalesLead.LeadSource = cmbLeadSource.SelectedIndex;
                            _oSalesLead.ActivationID = -1;
                        }

                        if (rdoExistingConsumer.Checked == true)
                        {
                            _oSalesLead.IsExistingConsumer = (int)Dictionary.YesOrNoStatus.YES;
                            _oSalesLead.RefLeadNo = txtLeadNo.Text;
                        }
                        else
                        {
                            _oSalesLead.IsExistingConsumer = (int)Dictionary.YesOrNoStatus.NO;
                            _oSalesLead.RefLeadNo = "";

                        }
                        _oSalesLead.ConsumerID = nConsumerID;
                        _oSalesLead.InsertForPOS();
                        _oSalesLead.AddHistory();
                        if (_nType == 2)
                        {
                            _oSalesLead.UpdatePotentialData(_nPotentialID, _nPWHID);
                        }
                        _IsTrue = true;
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add SalesLead. SalesLead# " + _oSalesLead.LeadNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                        cmbCustomerType.SelectedIndex = 0;
                        cmbConversionPossibility.SelectedIndex = 0;
                        dtLeadDate.Value = DateTime.Now.Date;
                        dtExpExcDate.Value = DateTime.Now.Date;
                        txtCompany.Text = "";
                        txtName.Text = "";
                        txtAGE.Text = "";
                        txtEmail.Text = "";
                        txtAddress.Text = "";
                        txtContact.Text = "";
                        txtProfession.Text = "";
                        txtIncomLevel.Text = "";
                        //cmbBrand.SelectedIndex = 0;
                        //cmbMAG.SelectedIndex = 0;
                        txtAmount.Text = "";
                        txtQty.Text = "";
                        dtFollowUpdate.Value = DateTime.Now.Date;
                        cmbSalesPerson.SelectedIndex = 0;
                        txtRemarks.Text = "";

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLeadNo.Text = "";
            if (cmbCustomerType.SelectedIndex + 1 == (int)Dictionary.CustomerTypeSalesLead.Retail)
            {
                txtCompany.Enabled = false;
            }
            else if (cmbCustomerType.SelectedIndex + 1 == (int)Dictionary.CustomerTypeSalesLead.EStore)
            {
                txtCompany.Enabled = false;
            }
            else
            {
                txtCompany.Enabled = true;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            sCompanyName = txtCompany.Text;
            sCustName = txtName.Text;
            sAge = txtAGE.Text;
            sAddress = txtAddress.Text;
            sEmail = txtEmail.Text;
            sContact = txtContact.Text;
            sProfession = txtProfession.Text;
            sIncom = txtIncomLevel.Text;
            btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            txtCompany.Text = sCompanyName;
            txtName.Text = sCustName;
            txtAGE.Text = sAge;
            txtAddress.Text = sAddress;
            txtEmail.Text = sEmail;
            txtContact.Text = sContact;
            txtProfession.Text = sProfession;
            txtIncomLevel.Text = sIncom;
        }

        private void rdoExistingConsumer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (nTerminal == (int)Dictionary.Terminal.Head_Office)
                {
                    txtLeadNo.Enabled = false;
                    btnPicker.Enabled = false;
                    rdoExistingConsumer.Enabled = false;
                    rdoNewConsumer.Enabled = false;
                    txtCompany.Enabled = false;
                    txtName.Enabled = false;
                    txtAGE.Enabled = false;
                    txtAddress.Enabled = false;
                    txtEmail.Enabled = false;
                    txtContact.Enabled = false;
                    txtProfession.Enabled = false;
                    txtIncomLevel.Enabled = false;
                    cmbCustomerType.Enabled = false;
                }
                else
                {
                    txtLeadNo.Enabled = true;
                    btnPicker.Enabled = true;

                    txtCompany.Enabled = false;
                    txtName.Enabled = false;
                    txtAGE.Enabled = false;
                    txtAddress.Enabled = false;
                    txtEmail.Enabled = false;
                    txtContact.Enabled = false;
                    txtProfession.Enabled = false;
                    txtIncomLevel.Enabled = false;
                    cmbCustomerType.Enabled = false;

                }
            }
            else
            {
                txtLeadNo.Enabled = true;
                btnPicker.Enabled = true;

                txtCompany.Enabled = false;
                txtName.Enabled = false;
                txtAGE.Enabled = false;
                txtAddress.Enabled = false;
                txtEmail.Enabled = false;
                txtContact.Enabled = false;
                txtProfession.Enabled = false;
                txtIncomLevel.Enabled = false;
                cmbCustomerType.Enabled = false;
            }

            //}

        }

        private void rdoNewConsumer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (nTerminal == (int)Dictionary.Terminal.Head_Office)
                {
                    txtLeadNo.Enabled = false;
                    btnPicker.Enabled = false;
                    rdoExistingConsumer.Enabled = false;
                    rdoNewConsumer.Enabled = false;
                    txtCompany.Enabled = false;
                    txtName.Enabled = false;
                    txtAGE.Enabled = false;
                    txtAddress.Enabled = false;
                    txtEmail.Enabled = false;
                    txtContact.Enabled = false;
                    txtProfession.Enabled = false;
                    txtIncomLevel.Enabled = false;
                    cmbCustomerType.Enabled = false;
                }
                else
                {
                    txtLeadNo.Enabled = false;
                    btnPicker.Enabled = false;
                    txtCompany.Enabled = true;
                    txtName.Enabled = true;
                    txtAGE.Enabled = true;
                    txtAddress.Enabled = true;
                    txtEmail.Enabled = true;
                    txtContact.Enabled = true;
                    txtProfession.Enabled = true;
                    txtIncomLevel.Enabled = true;
                    cmbCustomerType.Enabled = true;
                    cmbCustomerType.SelectedIndex = 0;
                    txtLeadNo.Text = "";
                    txtLeadCustName.Text = "";
                    txtCompany.Text = "";
                    txtName.Text = "";
                    txtAGE.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtContact.Text = "";
                    txtProfession.Text = "";
                    txtIncomLevel.Text = "";
                }
            }
            else
            {
                txtLeadNo.Enabled = false;
                btnPicker.Enabled = false;
                txtCompany.Enabled = true;
                txtName.Enabled = true;
                txtAGE.Enabled = true;
                txtAddress.Enabled = true;
                txtEmail.Enabled = true;
                txtContact.Enabled = true;
                txtProfession.Enabled = true;
                txtIncomLevel.Enabled = true;
                cmbCustomerType.Enabled = true;
                cmbCustomerType.SelectedIndex = 0;
                txtLeadNo.Text = "";
                txtLeadCustName.Text = "";
                txtCompany.Text = "";
                txtName.Text = "";
                txtAGE.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtContact.Text = "";
                txtProfession.Text = "";
                txtIncomLevel.Text = "";
            }
            //}

        }

        private void txtLeadNo_TextChanged(object sender, EventArgs e)
        {
            if (rdoExistingConsumer.Checked == true)
            {
                SalesLead _oSalesLead = new SalesLead();
                _oSalesLead.LeadNo = txtLeadNo.Text;
                txtLeadNo.ForeColor = System.Drawing.Color.Red;
                txtLeadCustName.Text = "";
                DBController.Instance.OpenNewConnection();
                _oSalesLead.GetCustomerByLeadNo();
                if (_oSalesLead.Name == null)
                {
                    _oSalesLead = null;
                    AppLogger.LogFatal("There is no data.");
                    txtCompany.Text = "";
                    txtName.Text = "";
                    txtAGE.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtContact.Text = "";
                    txtProfession.Text = "";
                    txtIncomLevel.Text = "";
                    return;
                }
                else
                {
                    txtLeadCustName.Text = _oSalesLead.Name;
                    txtCompany.Text = _oSalesLead.CompanyName;
                    txtName.Text = _oSalesLead.Name;
                    txtAGE.Text = _oSalesLead.AgeLevel;
                    txtAddress.Text = _oSalesLead.Address;
                    txtEmail.Text = _oSalesLead.Email;
                    txtContact.Text = _oSalesLead.ContactNo;
                    txtProfession.Text = _oSalesLead.Profession;
                    txtIncomLevel.Text = _oSalesLead.IncomLevel;
                    int nCustomerType = _oSalesLead.CustomerType;
                    cmbCustomerType.SelectedIndex = nCustomerType - 1;

                    txtLeadNo.SelectionStart = 0;
                    txtLeadNo.SelectionLength = txtLeadNo.Text.Length;
                    txtLeadNo.ForeColor = System.Drawing.Color.Empty;
                    //txtLeadNo.Enabled = false;
                    //btnPicker.Enabled = false;

                }
            }
            else if (rdoExistingFromConsumer.Checked == true)
            {

                oRetailConsumer = new RetailConsumer();
                txtLeadNo.ForeColor = System.Drawing.Color.Red;
                txtLeadCustName.Text = "";
                //if (txtConsumerCode.Text.Length >= 1 && txtConsumerCode.Text.Length <= 25)
                //{
                oRetailConsumer.ConsumerCode = txtLeadNo.Text;
                oRetailConsumer.RefreshConsumerByType(cmbCustomerType.SelectedIndex + 1);

                if (oRetailConsumer.ConsumerName == null)
                {
                    txtCompany.Text = "";
                    txtName.Text = "";
                    txtAGE.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtContact.Text = "";
                    txtProfession.Text = "";
                    txtIncomLevel.Text = "";

                    oRetailConsumer = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    nConsumerID = oRetailConsumer.ConsumerID;
                    txtLeadCustName.Text = oRetailConsumer.ConsumerName;
                    txtCompany.Text = "";
                    txtName.Text = oRetailConsumer.ConsumerName;
                    txtAGE.Text = "";
                    txtAddress.Text = oRetailConsumer.Address;
                    txtEmail.Text = oRetailConsumer.Email;
                    txtContact.Text = oRetailConsumer.CellNo;
                    txtProfession.Text = "";
                    txtIncomLevel.Text = "";

                    txtLeadNo.SelectionStart = 0;
                    txtLeadNo.SelectionLength = txtLeadNo.Text.Length;
                    txtLeadNo.ForeColor = System.Drawing.Color.Empty;
                    //txtLeadNo.Enabled = false;
                    //btnPicker.Enabled = false;
                }
                //}
                //else
                //{
                //    txtCustomerName.Text = "";
                //    txtCustomerAddress.Text = "";
                //    txtDeliveryAddress.Text = "";
                //    txtEmail.Text = "";
                //    txtCell.Text = "";
                //    txtTelePhone.Text = "";
                //    txtEmployeeNo.Text = "";
                //    txtNationalID.Text = "";
                //    txtVatRegNo.Text = "";
                //    //ctlCustomer1.txtCode.Text = "";
                //    txtCtlCustCode.Text = oRetailConsumer.CustomerCode.ToString();

                //    btnEmailVerification.Text = "Invalid Email";
                //    btnEmailVerification.ForeColor = Color.Red;
                //    btnEmailVerification.Enabled = true;
                //    txtEmail.Enabled = true;
                //}
            }

        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            if (rdoExistingConsumer.Checked == true)
            {
                SalesLead oSalesLead = new SalesLead();
                frmSalesLeadConsumerSarch oObj = new frmSalesLeadConsumerSarch(-1); //All
                oObj.ShowDialog(oSalesLead);
                if (oSalesLead.LeadNo != null)
                {
                    txtLeadNo.Text = oSalesLead.LeadNo.ToString();
                    txtLeadCustName.Text = oSalesLead.Name.ToString();
                }
            }
            else if (rdoExistingFromConsumer.Checked == true)
            {
                oRetailConsumer = new RetailConsumer();
                frmReatilConsumerSearch oObj = new frmReatilConsumerSearch(cmbCustomerType.SelectedIndex + 1,(int)Dictionary.Terminal.Branch_Office, _oSystemInfo.WarehouseID);
                oObj.ShowDialog(oRetailConsumer);
                if (oRetailConsumer.ConsumerCode != null)
                {
                    nConsumerID = oRetailConsumer.ConsumerID;
                    txtLeadNo.Text = oRetailConsumer.ConsumerCode;
                    //txtLeadNo.Enabled = false;
                    //btnPicker.Enabled = false;
                }
            }

        }

        private void cmbLeadSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLeadSource.SelectedIndex == 0)
            {
                cmbActivation.Visible = false;
                lblActivationName.Visible = false;
            }
            else
            {
                cmbActivation.Visible = true;
                lblActivationName.Visible = true;
            }
        }

        private void rdoExistingFromConsumer_CheckedChanged(object sender, EventArgs e)
        {
            cmbCustomerType.Enabled = true;
            cmbCustomerType.SelectedIndex = 0;
            txtLeadNo.Text = "";
            txtLeadCustName.Text = "";
            txtCompany.Text = "";
            txtName.Text = "";
            txtAGE.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtProfession.Text = "";
            txtIncomLevel.Text = "";
            txtLeadNo.Enabled = true;
            btnPicker.Enabled = true;
            txtCompany.Enabled = true;
            txtName.Enabled = false;
            txtAGE.Enabled = true;
            txtAddress.Enabled = false;
            txtEmail.Enabled = false;
            txtContact.Enabled = false;
            txtProfession.Enabled = true;
            txtIncomLevel.Enabled = true;
            cmbCustomerType.Enabled = true;

        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            TELLib oTELLib = new TELLib();
            if (ctlProduct1.txtDescription.Text != "")
            {
                txtAmount.Text = oTELLib.TakaFormat(ctlProduct1.SelectedSerarchProduct.RSP);
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text.Trim() != "")
            {
                try
                {
                    int temp = Convert.ToInt32(txtQty.Text);
                    TELLib oTELLib = new TELLib();
                    if (ctlProduct1.txtDescription.Text != "")
                        txtAmount.Text = oTELLib.TakaFormat(Convert.ToDouble(ctlProduct1.SelectedSerarchProduct.RSP * temp));

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Lead Qty ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Text = "0.00";
                    txtQty.Text = "0";
                    txtQty.Focus();
                }

            }

            
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtAmount.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Text = "0.00";
                    txtAmount.Focus();
                }

            }
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistrict.SelectedIndex != 0)
            {
                oThana = new GeoLocations();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                oThana.GetByParentID(oDistrict[cmbDistrict.SelectedIndex - 1].GeoLocationID);
                cmbThana.Items.Clear();
                cmbThana.Items.Add("<Select a Thana>");
                foreach (GeoLocation oThanas in oThana)
                {
                    cmbThana.Items.Add(oThanas.GeoLocationName);
                }
                cmbThana.SelectedIndex = 0;
            }
            else
            {
                cmbThana.Items.Clear();
                cmbThana.Items.Add("<Select a Thana>");
                cmbThana.SelectedIndex = 0;
            }
        }
    }
}