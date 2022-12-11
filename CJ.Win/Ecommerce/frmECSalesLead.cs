using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Win.Ecommerce
{
    public partial class frmECSalesLead : Form
    {
        public bool _IsTrue = false;
        //Districts _oDistricts;
        //Districts _oThanas;

        GeoLocations oDistrict;
        GeoLocations oThana;
        Brands _oBrands;
        ProductGroups _oMAG;
        Showrooms _oShowrooms;
        Employees oEmployees;
        SalesLead _oSalesLead;
        int nLeadID = 0;
        int nWarehouseID = 0;
        string sLeadNo = "";
        int _nType = 0;
        int nOutboundCallID = 0;
        SalesLeads _oActivations;

        string sCompanyName = "";
        string sCustName = "";
        string sAge = "";
        string sAddress = "";
        string sEmail = "";
        string sContact = "";
        string sProfession = "";
        string sIncom = "";
        string sRefLeadNo = "";
        int nIsExistingConsumer = 0;
        int nSalesPersonID = 0;
        int nTerminal = 0;
        int nStatus = 0;
        int _isHVACLead = 0;
        int _warehouseID = 0;

        public frmECSalesLead(int nType, int isHVACLead)
        {
            InitializeComponent();
            _nType = nType;
            _isHVACLead = isHVACLead;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _IsTrue = true;
                cmbLeadType.SelectedIndex = 0;
                cmbConversionPossibility.SelectedIndex = 0;
                dtLeadDate.Value = DateTime.Now.Date;
                dtExpExcDate.Value = DateTime.Now.Date;
                txtCompany.Text = "";
                txtName.Text = "";
                //txtAGE.Text = "";
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
                //cmbSalesPerson.SelectedIndex = 0;
                txtRemarks.Text = "";
            }
        }

        private bool UIValidation()
        {

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (txtContact.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Contact No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Lead Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            if (txtQty.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Lead Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
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
            if (ctlProducts1.txtCode.Text == "")
            {
                MessageBox.Show("Please enter valid product code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProducts1.txtCode.Focus();
                return false;
            }
            if (ctlProducts1.txtDescription.Text == "")
            {
                MessageBox.Show("Please enter valid product code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProducts1.txtDescription.Focus();
                return false;
            }
            //if (cmbMAG.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select MAG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbMAG.Focus();
            //    return false;
            //}

            //if (cmbBrand.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbBrand.Focus();
            //    return false;
            //}
            //if (cmbOutlet.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select a Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbOutlet.Focus();
            //    return false;
            //}
            //if (cmbSalesPerson.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select a Sales Person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbSalesPerson.Focus();
            //    return false;
            //}

            return true;
        }

        private void Save()
        {
            _oSalesLead = new SalesLead();
            _oSalesLead.CustomerType = cmbLeadType.SelectedIndex + 1;
            _oSalesLead.ConversionPossibility = cmbConversionPossibility.SelectedIndex + 1;
            _oSalesLead.LeadDate = dtLeadDate.Value.Date;
            _oSalesLead.ExpExecuteDate = dtExpExcDate.Value.Date;
            _oSalesLead.Name = txtName.Text;
            _oSalesLead.CompanyName = txtCompany.Text;
            _oSalesLead.Address = txtAddress.Text;
            _oSalesLead.Email = txtEmail.Text;
            _oSalesLead.ContactNo = txtContact.Text;
            _oSalesLead.Profession = txtProfession.Text;
            _oSalesLead.IncomLevel = txtIncomLevel.Text;

            _oSalesLead.ProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
            _oSalesLead.MAGID = ctlProducts1.SelectedSerarchProduct.MAGID;
            _oSalesLead.BrandID = ctlProducts1.SelectedSerarchProduct.BrandID;
            if (ctlProducts1.SelectedSerarchProduct.ProductModel != "")
                _oSalesLead.ModelName = ctlProducts1.SelectedSerarchProduct.ProductModel;
            else _oSalesLead.ModelName = ctlProducts1.SelectedSerarchProduct.ProductName;

            _oSalesLead.LeadAmount = Convert.ToDouble(txtAmount.Text);
            _oSalesLead.Qty = Convert.ToInt32(txtQty.Text);
            _oSalesLead.NextFollowUpDate = dtFollowUpdate.Value.Date;
            if (this.Tag == null)
            {
                _oSalesLead.WarehouseID = -1;
                _oSalesLead.SalesPersonID = -1;
                _oSalesLead.Terminal = (int)Dictionary.Terminal.Head_Office;
                _oSalesLead.Status = (int)Dictionary.SalesLeadStatusPOS.Create;
            }
            else
            {
                _oSalesLead.WarehouseID = nWarehouseID;
                _oSalesLead.SalesPersonID = nSalesPersonID;
                _oSalesLead.Terminal = nTerminal;
                _oSalesLead.Status = nStatus;
            }
            _oSalesLead.Remarks = txtRemarks.Text;
            _oSalesLead.CreateDate = DateTime.Now.Date;
            _oSalesLead.CreateUserID = Utility.UserId;
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
            if (this.Tag == null)
            {
                if (rdoExestingFromLead.Checked == true)
                {
                    _oSalesLead.IsExistingConsumer = (int)Dictionary.YesOrNoStatus.YES;
                    _oSalesLead.RefLeadNo = txtLeadNo.Text;
                }
                else
                {
                    _oSalesLead.IsExistingConsumer = (int)Dictionary.YesOrNoStatus.NO;
                    _oSalesLead.RefLeadNo = "";
                }
            }
            else
            {
                _oSalesLead.IsExistingConsumer = nIsExistingConsumer;
                _oSalesLead.RefLeadNo = sRefLeadNo;
            }

            _oSalesLead.ThanaID = oThana[cmbThana.SelectedIndex - 1].GeoLocationID;

            if (_isHVACLead == 1)
            {
                _oSalesLead.IsHVACLead = (int)Dictionary.IsHVACLead.Yes;
            }
            else {
                _oSalesLead.IsHVACLead = (int)Dictionary.IsHVACLead.No;
            }

            if (_nType == 1)
            {
                if (this.Tag == null)
                {

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oSalesLead.IsValidLead = 1;
                        _oSalesLead.Insert();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
                else
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oSalesLead.LeadID = nLeadID;
                        _oSalesLead.LeadNo = sLeadNo;
                        _oSalesLead.IsValidLead = cmbIsValidLead.SelectedIndex;
                        _oSalesLead.ThanaID = oThana[cmbThana.SelectedIndex - 1].GeoLocationID;
                        _oSalesLead.UpdateHOLead();

                        _oSalesLead.WarehouseID = nWarehouseID;
                        _oSalesLead.Remarks = txtRemarks.Text;
                        _oSalesLead.ExpExecuteDate = dtExpExcDate.Value.Date;
                        _oSalesLead.Status = nStatus;
                        _oSalesLead.AddHistory();

                        if (nWarehouseID != -1)
                        {
                            DataTran oDataTran = new DataTran();
                            oDataTran.TableName = "t_SalesLeadManagement";
                            oDataTran.DataID = Convert.ToInt32(nLeadID);
                            oDataTran.WarehouseID = Convert.ToInt32(nWarehouseID);
                            oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTran.BatchNo = 0;
                            if (oDataTran.CheckData())
                            {

                            }
                            else
                            {
                                oDataTran.AddForTDPOS();
                            }
                        }

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }


                }
            }
            else
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSalesLead.Insert();
                    PotentialCustomer oPotentialCustomer = new PotentialCustomer();
                    oPotentialCustomer.Status = (int)Dictionary.OutboundStatus.Convert_To_Lead;
                    oPotentialCustomer.OutboundCallID = nOutboundCallID;
                    oPotentialCustomer.UpdateOutboundStatus();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        public void ShowDialog(SalesLead oSalesLead)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oSalesLead;
            LoadCombos();
            if (_nType == 1)
            {
                nLeadID = 0;
                nLeadID = oSalesLead.LeadID;
                nWarehouseID = oSalesLead.WarehouseID;
                nSalesPersonID = oSalesLead.SalesPersonID;
                nTerminal = oSalesLead.Terminal;
                nStatus = oSalesLead.Status;
                _warehouseID = oSalesLead.WarehouseID;

                sLeadNo = "";
                sLeadNo = oSalesLead.LeadNo;
                txtLeadNo.Text = sLeadNo;


                int nConversionPos = oSalesLead.ConversionPossibility;
                cmbConversionPossibility.SelectedIndex = nConversionPos - 1;
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
                dtLeadDate.Value = oSalesLead.LeadDate;
                dtExpExcDate.Value = oSalesLead.ExpExecuteDate;

                if (oSalesLead.DistrictID != -1)
                    cmbDistrict.SelectedIndex = oDistrict.GetIndexByID(oSalesLead.DistrictID) + 1;

                if (oSalesLead.ThanaID != -1)
                    cmbThana.SelectedIndex = oThana.GetIndexByID(oSalesLead.ThanaID) + 1;
                try
                {
                    ctlProducts1.txtCode.Text = oSalesLead.ProductCode;
                }
                catch
                {
                    ctlProducts1.txtCode.Text = "";
                }
                //int nBrandIndex = 0;
                //nBrandIndex = _oBrands.GetIndex(oSalesLead.BrandID);
                //cmbBrand.SelectedIndex = nBrandIndex + 1;

                //int nMAGIndex = 0;
                //nMAGIndex = _oMAG.GetIndex(oSalesLead.MAGID);
                //cmbMAG.SelectedIndex = nMAGIndex + 1;

                //txtModel.Text = oSalesLead.ModelName;
                txtAmount.Text = oSalesLead.LeadAmount.ToString();
                txtQty.Text = oSalesLead.Qty.ToString();
                dtFollowUpdate.Value = oSalesLead.NextFollowUpDate;
                txtRemarks.Text = oSalesLead.Remarks;
                
                rdoNewConsumer.Enabled = false;
                rdoExestingFromLead.Enabled = false;
                btnPicker.Enabled = false;
                txtLeadNo.Enabled = false;
                cmbIsValidLead.Visible = true;
                lblIsValidLead.Visible = true;
                sRefLeadNo = oSalesLead.RefLeadNo;
                nIsExistingConsumer = oSalesLead.IsExistingConsumer;
                cmbIsValidLead.SelectedIndex = oSalesLead.IsValidLead;
            }
            ////int nSalesPerson = 0;
            ////nSalesPerson = oEmployees.GetIndex(oSalesLead.SalesPersonID);
            ////cmbSalesPerson.SelectedIndex = nSalesPerson + 1;

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmECSalesLead_Load(object sender, EventArgs e)
        {
            txtLeadNo.Enabled = false;
            btnPicker.Enabled = false;
            btnPaste.Enabled = false;



            if (this.Tag == null)
            {

                LoadCombos();
                rdoNewConsumer.Checked = true;
                lblActivationName.Visible = false;
                cmbActivation.Visible = false;
                this.Text = "Add New Sales Lead";
            }

            if (_isHVACLead == 1)
            {
                rdoNewConsumer.Enabled = false;
                rdoExestingFromLead.Enabled = false;

                cmbLeadType.SelectedIndex = ((int)Dictionary.CustomerTypeSalesLead.B2B)-1;
                cmbLeadType.Enabled = false;
            }

        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            //Customer Type 
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CustomerTypeSalesLead)))
            {
                cmbLeadType.Items.Add(Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), GetEnum));
            }
            cmbLeadType.SelectedIndex = 0;

            //Lead Conversion Possibility
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeadConversionPossibility)))
            {
                cmbConversionPossibility.Items.Add(Enum.GetName(typeof(Dictionary.LeadConversionPossibility), GetEnum));
            }
            cmbConversionPossibility.SelectedIndex = 0;

            //MAG 
            //_oMAG = new ProductGroups();
            //_oMAG.Refresh(Dictionary.ProductGroupType.MAG);
            //cmbMAG.Items.Clear();
            //cmbMAG.Items.Add("<All>");
            //foreach (ProductGroup oProductGroup in _oMAG)
            //{
            //    cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            //}
            //cmbMAG.SelectedIndex = 0;

            //MAG 
            //_oBrands = new Brands();
            //_oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            //cmbBrand.Items.Clear();
            //cmbBrand.Items.Add("<All>");
            //foreach (Brand oBrand in _oBrands)
            //{
            //    cmbBrand.Items.Add(oBrand.BrandDesc);
            //}
            //cmbBrand.SelectedIndex = 0;


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

            //IsValidLead 
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsValidLead)))
            {
                cmbIsValidLead.Items.Add(Enum.GetName(typeof(Dictionary.IsValidLead), GetEnum));
            }


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

        private void btnCopy_Click(object sender, EventArgs e)
        {
            sCompanyName = txtCompany.Text;
            sCustName = txtName.Text;
            //sAge = txtAGE.Text;
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
            //txtAGE.Text = sAge;
            txtAddress.Text = sAddress;
            txtEmail.Text = sEmail;
            txtContact.Text = sContact;
            txtProfession.Text = sProfession;
            txtIncomLevel.Text = sIncom;
        }

        private void txtLeadNo_TextChanged(object sender, EventArgs e)
        {
            //if (rdoExestingFromLead.Checked == true)
            //{
                SalesLead _oSalesLead = new SalesLead();
                _oSalesLead.LeadNo = txtLeadNo.Text;
                _oSalesLead.WarehouseID = _warehouseID;
                txtLeadNo.ForeColor = System.Drawing.Color.Red;
                txtLeadCustName.Text = "";
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                _oSalesLead.GetCustomerByLeadNo();
                if (_oSalesLead.Name == null)
                {
                    _oSalesLead = null;
                    AppLogger.LogFatal("There is no data.");
                    txtCompany.Text = "";
                    txtName.Text = "";
                    //txtAGE.Text = "";
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
                    //txtAGE.Text = _oSalesLead.AgeLevel;
                    txtAddress.Text = _oSalesLead.Address;
                    txtEmail.Text = _oSalesLead.Email;
                    txtContact.Text = _oSalesLead.ContactNo;
                    txtProfession.Text = _oSalesLead.Profession;
                    txtIncomLevel.Text = _oSalesLead.IncomLevel;
                    int nCustomerType = _oSalesLead.CustomerType;
                    cmbLeadType.SelectedIndex = nCustomerType - 1;
                    txtLeadNo.SelectionStart = 0;
                    txtLeadNo.SelectionLength = txtLeadNo.Text.Length;
                    txtLeadNo.ForeColor = System.Drawing.Color.Empty;
                    txtLeadNo.Enabled = false;
                    btnPicker.Enabled = false;

                }
            //}
            //else if (rdoExistingConsumer.Checked == true)
            //{

            //    //oRetailConsumer = new RetailConsumer();
            //    //txtLeadNo.ForeColor = System.Drawing.Color.Red;
            //    //txtLeadCustName.Text = "";
            //    ////if (txtConsumerCode.Text.Length >= 1 && txtConsumerCode.Text.Length <= 25)
            //    ////{
            //    //oRetailConsumer.ConsumerCode = txtLeadNo.Text;
            //    //oRetailConsumer.RefreshConsumerByType(cmbCustomerType.SelectedIndex + 1);

            //    //if (oRetailConsumer.ConsumerName == null)
            //    //{
            //    //    txtCompany.Text = "";
            //    //    txtName.Text = "";
            //    //    txtAGE.Text = "";
            //    //    txtAddress.Text = "";
            //    //    txtEmail.Text = "";
            //    //    txtContact.Text = "";
            //    //    txtProfession.Text = "";
            //    //    txtIncomLevel.Text = "";

            //    //    oRetailConsumer = null;
            //    //    AppLogger.LogFatal("There is no data.");
            //    //    return;
            //    //}
            //    //else
            //    //{
            //    //    nConsumerID = oRetailConsumer.ConsumerID;
            //    //    txtLeadCustName.Text = oRetailConsumer.ConsumerName;
            //    //    txtCompany.Text = "";
            //    //    txtName.Text = oRetailConsumer.ConsumerName;
            //    //    txtAGE.Text = "";
            //    //    txtAddress.Text = oRetailConsumer.Address;
            //    //    txtEmail.Text = oRetailConsumer.Email;
            //    //    txtContact.Text = oRetailConsumer.CellNo;
            //    //    txtProfession.Text = "";
            //    //    txtIncomLevel.Text = "";

            //    //    txtLeadNo.SelectionStart = 0;
            //    //    txtLeadNo.SelectionLength = txtLeadNo.Text.Length;
            //    //    txtLeadNo.ForeColor = System.Drawing.Color.Empty;
            //    //    //txtLeadNo.Enabled = false;
            //    //    //btnPicker.Enabled = false;
            //    //}
                
            //}

        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            SalesLead oSalesLead = new SalesLead();
            frmLeadConsumerSarch oObj = new frmLeadConsumerSarch(-1); //All
            oObj.ShowDialog(oSalesLead);
            if (oSalesLead.LeadNo != null)
            {
                txtLeadNo.Text = oSalesLead.LeadNo.ToString();
                txtLeadCustName.Text = oSalesLead.Name.ToString();
            }
        }

        private void rdoNewConsumer_CheckedChanged(object sender, EventArgs e)
        {
                    txtLeadNo.Enabled = false;
                    btnPicker.Enabled = false;
                    txtCompany.Enabled = true;
                    txtName.Enabled = true;
                    txtAddress.Enabled = true;
                    txtEmail.Enabled = true;
                    txtContact.Enabled = true;
                    txtProfession.Enabled = true;
                    txtIncomLevel.Enabled = true;
                    cmbLeadType.Enabled = true;
                    cmbLeadType.SelectedIndex = 0;
                    txtLeadNo.Text = "";
                    txtLeadCustName.Text = "";
                    txtCompany.Text = "";
                    txtName.Text = "";
                    //txtAGE.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtContact.Text = "";
                    txtProfession.Text = "";
                    txtIncomLevel.Text = "";
                
            
            
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

        private void cmbLeadType_SelectedIndexChanged(object sender, EventArgs e)
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

        private void rdoExestingFromLead_CheckedChanged(object sender, EventArgs e)
        {
            txtLeadNo.Enabled = true;
            btnPicker.Enabled = true;
            txtCompany.Enabled = false;
            txtName.Enabled = false;
            //txtAGE.Enabled = false;
            txtAddress.Enabled = false;
            txtEmail.Enabled = false;
            txtContact.Enabled = false;
            txtProfession.Enabled = false;
            txtIncomLevel.Enabled = false;
            cmbLeadType.Enabled = false;
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

        private void ctlProducts1_ChangeSelection(object sender, EventArgs e)
        {
            TELLib oTELLib = new TELLib();
            if (ctlProducts1.txtDescription.Text != "")
            {
                txtAmount.Text = oTELLib.TakaFormat(ctlProducts1.SelectedSerarchProduct.RSP);
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
                    if (ctlProducts1.txtDescription.Text != "")
                        txtAmount.Text = oTELLib.TakaFormat(Convert.ToDouble(ctlProducts1.SelectedSerarchProduct.RSP * temp));

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
    }
}