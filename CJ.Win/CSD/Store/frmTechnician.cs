using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmTechnician : Form
    {       
        Workshops _oWorkshops;
        TechnicalSupervisors _oTechnicalSupervisors;
        WorkshopLocations _oWorkshopLocations;
        Brands _oBrands;
        public bool _bAction = false;

        public frmTechnician()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //Workshop
            _oWorkshops = new Workshops();
            _oWorkshops.RefreshForCombo();
            cmbWorkshop.Items.Clear();
            cmbWorkshop.Items.Add("--Select--");
            foreach (Workshop oWorkshop in _oWorkshops)
            {
                cmbWorkshop.Items.Add(oWorkshop.Name);
            }
            if (this.Tag == null)
            {
                cmbWorkshop.SelectedIndex = 0;
            }
            else
            {
                Technician oTechnician = (Technician)this.Tag;
                cmbWorkshop.SelectedIndex = _oWorkshops.GetIndex(oTechnician.WorkshopTypeID) + 1;
            }

            //Workshop Location

            _oWorkshopLocations = new WorkshopLocations();
            _oWorkshopLocations.RefreshForCombo();
            cmbWorkshopLocation.Items.Clear();
            cmbWorkshopLocation.Items.Add("--Select---");
            foreach (WorkshopLocation oWorkshopLocation in _oWorkshopLocations)
            {
                cmbWorkshopLocation.Items.Add(oWorkshopLocation.Name);
            }
            if (this.Tag == null)
            {
                cmbWorkshopLocation.SelectedIndex = 0;
            }
            else
            {
                Technician oTechnician = (Technician)this.Tag;
                cmbWorkshopLocation.SelectedIndex = _oWorkshopLocations.GetIndex(oTechnician.WorkshopLocationID) + 1;
            }

            //Is Active
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCommunicationStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.InquiryCommunicationStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = (int)Dictionary.InquiryCommunicationStatus.True;

            _oTechnicalSupervisors = new TechnicalSupervisors();
            cmbSupervisor.Items.Add("--Select--");
            _oTechnicalSupervisors.RefreshAll();

            foreach (TechnicalSupervisor oTechnicalSupervisor in _oTechnicalSupervisors)
            {
                cmbSupervisor.Items.Add(oTechnicalSupervisor.Employee.EmployeeName);
            }
            if (this.Tag == null)
            {
                cmbSupervisor.SelectedIndex = 0;
            }
            else
            {
                Technician oTechnician = (Technician)this.Tag;
                cmbSupervisor.SelectedIndex = _oTechnicalSupervisors.GetIndex(oTechnician.SupervisorID) + 1;
            }            
        }
        public void ShowDialog(Technician oTechnician)
        {
            this.Tag = oTechnician;
            LoadCombos();
            btnSave.Text = "Edit";
            ctlInterService1.Enabled = false;
            if (oTechnician.ThirdPartyCode != string.Empty)
            {
                ctlInterService1.txtCode.Text = oTechnician.ThirdPartyCode;
            }
            txtTechnicianCode.Text = oTechnician.Code;
            txtTechnicianName.Text = oTechnician.Name;
            txtEmployeeCode.Text = oTechnician.EmployeeCode;
            txtMaxPayment.Text = oTechnician.MaxPay.ToString();
            txtMinPayment.Text = oTechnician.MinPay.ToString();
            txtMobileNo.Text = oTechnician.MobileNo;
            txtMobileNo1.Text = oTechnician.MobileNo1;
            cmbWorkshopLocation.SelectedIndex = _oWorkshopLocations.GetIndex(oTechnician.WorkshopLocation.WorkshopLocationID)+1;
            cmbIsActive.SelectedIndex = oTechnician.IsActive;
            txtTechnicianCode.Enabled = false;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtTechnicianCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Technician Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTechnicianCode.Focus();
                return false;
            }
            if (txtTechnicianName.Text == "")
            {
                MessageBox.Show("Please enter Technician Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTechnicianName.Focus();
                return false;
            }
            if (txtTechnicianName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Technician Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTechnicianName.Focus();
                return false;
            }
            if (cmbSupervisor.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Supervisor", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupervisor.Focus();
                return false;
            }
            if(txtMobileNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Entre Mobile No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
            }
            if (rdoThirdParty.Checked && ctlInterService1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Select Third Party Technician", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlInterService1.txtCode.Focus();
                return false;
            }
            if (cmbWorkshop.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Workshop", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWorkshop.Focus();
                return false;
            }
            if (cmbWorkshopLocation.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Workshop Location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWorkshopLocation.Focus();
                return false;
            }
            if (!IsTechnicianWorkTypeSelect())
            {
                MessageBox.Show("Please Enter Work Type For Technician", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvWorkType.Focus();
                return false;
            }
            if (!IsBrandSkillSelect())
            {
                MessageBox.Show("Please Enter Brand Skill For Technician", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvBrandSkill.Focus();
                return false;
            }
            
            #endregion

            return true;
        }

        private bool IsBrandSkillSelect()
        {
            int nNumOfBrandSkill = 0;
            foreach (DataGridViewRow oItemRow in dgvBrandSkill.Rows)
            {
                if (oItemRow.Index < dgvBrandSkill.Rows.Count)
                {
                    bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                    if (isSelect)
                    {
                        ++nNumOfBrandSkill;
                        break;
                    }
                }
            }
            if (chkAllBrand.Checked || nNumOfBrandSkill > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool IsTechnicianWorkTypeSelect()
        {
            int nNumOfWorkType = 0;
            foreach (DataGridViewRow oItemRow in dgvWorkType.Rows)
            {
                if (oItemRow.Index < dgvWorkType.Rows.Count)
                {
                    bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                    if (isSelect)
                    {
                        ++nNumOfWorkType;
                        break;
                    }
                }
            }
            if (nNumOfWorkType > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _bAction = true;
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                Technician oTechnician = new Technician();

                oTechnician.Code = txtTechnicianCode.Text;
                oTechnician.Name = txtTechnicianName.Text;
                oTechnician.EmployeeCode = txtEmployeeCode.Text;
                if (rdoOwn.Checked && rdoVariable.Checked)
                {
                    oTechnician.MaxPay = Convert.ToDouble(txtMaxPayment.Text.Trim());
                    oTechnician.MinPay = Convert.ToDouble(txtMinPayment.Text.Trim());
                    oTechnician.IsVariable = (int)Dictionary.CSDOwnTechnicianType.Variable;
                    oTechnician.TechnicianTypeID = (int)Dictionary.CSDTechnicianType.Own;
                }
                else if (rdoOwn.Checked && rdoNonVariable.Checked)
                {
                    oTechnician.IsVariable = (int)Dictionary.CSDOwnTechnicianType.NonVariable;
                    oTechnician.TechnicianTypeID = (int)Dictionary.CSDTechnicianType.Own;
                }
                if (rdoThirdParty.Checked)
                {
                    oTechnician.TechnicianTypeID = (int)Dictionary.CSDTechnicianType.ThirdParty;
                    oTechnician.ThirdPartyID = ctlInterService1.SelectedInterService.InterServiceID;
                }
                oTechnician.MobileNo = txtMobileNo.Text;
                oTechnician.MobileNo1 = txtMobileNo1.Text;
                oTechnician.SupervisorID = _oTechnicalSupervisors[cmbSupervisor.SelectedIndex-1].SupervisorID;
                oTechnician.WorkshopTypeID = _oWorkshops[cmbWorkshop.SelectedIndex-1].WorkshopTypeID;
                oTechnician.WorkshopLocationID = _oWorkshopLocations[cmbWorkshopLocation.SelectedIndex-1].WorkshopLocationID;
                oTechnician.IsActive = cmbIsActive.SelectedIndex;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oTechnician.CheckByTechnicianCode())
                    {
                        oTechnician.Add();
                        AddTechnicianWorkTypeSkill();
                        AddTechnicianBrandSkill();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Technician oTechnician = (Technician)this.Tag;

                {
                    oTechnician.Code = txtTechnicianCode.Text;
                    oTechnician.Name = txtTechnicianName.Text;
                    oTechnician.EmployeeCode = txtEmployeeCode.Text;
                    if (rdoOwn.Checked && rdoVariable.Checked)
                    {
                        oTechnician.MaxPay = Convert.ToDouble(txtMaxPayment.Text.Trim());
                        oTechnician.MinPay = Convert.ToDouble(txtMinPayment.Text.Trim());
                        oTechnician.IsVariable = (int)Dictionary.CSDOwnTechnicianType.Variable;
                        oTechnician.TechnicianTypeID = (int)Dictionary.CSDTechnicianType.Own;
                    }
                    else if (rdoOwn.Checked && rdoNonVariable.Checked)
                    {
                        oTechnician.IsVariable = (int)Dictionary.CSDOwnTechnicianType.NonVariable;
                        oTechnician.TechnicianTypeID = (int)Dictionary.CSDTechnicianType.Own;
                    }
                    if (rdoThirdParty.Checked)
                    {
                        oTechnician.TechnicianTypeID = (int)Dictionary.CSDTechnicianType.ThirdParty;
                        oTechnician.ThirdPartyID = ctlInterService1.SelectedInterService.InterServiceID;
                    }

                    oTechnician.WorkshopTypeID = _oWorkshops[cmbWorkshop.SelectedIndex-1].WorkshopTypeID;
                    oTechnician.WorkshopLocationID = _oWorkshopLocations[cmbWorkshopLocation.SelectedIndex-1].WorkshopLocationID;
                    oTechnician.IsActive = cmbIsActive.SelectedIndex;

                    oTechnician.MobileNo = txtMobileNo.Text;
                    oTechnician.MobileNo1 = txtMobileNo1.Text;
                    oTechnician.SupervisorID = _oTechnicalSupervisors[cmbSupervisor.SelectedIndex - 1].SupervisorID;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        oTechnician.Edit();
                        CSDTechnicianSkill oCSDTechnicianSkill = new CSDTechnicianSkill();
                        oCSDTechnicianSkill.TechnicianID = oTechnician.TechnicianID;
                        oCSDTechnicianSkill.Delete();
                        AddTechnicianWorkTypeSkill();
                        AddTechnicianBrandSkill();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }
        private void AddTechnicianWorkTypeSkill()
        {
            Technician aTechnician = new Technician();
            string TechnicianCode = txtTechnicianCode.Text;
            int nTechnicianID = aTechnician.GetTechnicianIDByCode(TechnicianCode.Trim());

            CSDTechnicianSkill oCSDTechnicianWorkSkill;

            foreach (DataGridViewRow oItemRow in dgvWorkType.Rows)
            {
                if (oItemRow.Index < dgvWorkType.Rows.Count)
                {
                    bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                    if (isSelect)
                    {
                        oCSDTechnicianWorkSkill = new CSDTechnicianSkill();
                        oCSDTechnicianWorkSkill.TechnicianID = nTechnicianID;
                        oCSDTechnicianWorkSkill.SkillType = (int)Dictionary.CSDTechnicianSkillType.WorkTypeSkill;
                        oCSDTechnicianWorkSkill.WorkTypeID = int.Parse(oItemRow.Cells[1].Value.ToString());
                        oCSDTechnicianWorkSkill.Add();
                    }
                }
            }



        }
        private void AddTechnicianBrandSkill()
        {
            Technician aTechnician = new Technician();
            string TechnicianCode = txtTechnicianCode.Text;
            int nTechnicianID = aTechnician.GetTechnicianIDByCode(TechnicianCode.Trim());

            CSDTechnicianSkill oCSDTechnicianBrandSkill;
            if (chkAllBrand.Checked)
            {
                oCSDTechnicianBrandSkill = new CSDTechnicianSkill();
                oCSDTechnicianBrandSkill.TechnicianID = nTechnicianID;
                oCSDTechnicianBrandSkill.SkillType = (int)Dictionary.CSDTechnicianSkillType.BrandSkill;
                oCSDTechnicianBrandSkill.BrandID = -1;
                oCSDTechnicianBrandSkill.Add();
            }
            else
            {
                foreach (DataGridViewRow oItemRow in dgvBrandSkill.Rows)
                {
                    if (oItemRow.Index < dgvBrandSkill.Rows.Count)
                    {
                        bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                        //bool isSelect = bool.Parse(oItemRow.Cells[0].Value.ToString());
                        if (isSelect)
                        {
                            oCSDTechnicianBrandSkill = new CSDTechnicianSkill();
                            oCSDTechnicianBrandSkill.TechnicianID = nTechnicianID;
                            oCSDTechnicianBrandSkill.SkillType = (int)Dictionary.CSDTechnicianSkillType.BrandSkill;
                            oCSDTechnicianBrandSkill.BrandID = int.Parse(oItemRow.Cells[1].Value.ToString());
                            oCSDTechnicianBrandSkill.Add();
                        }
                    }
                }
            }

        }
        private void frmTechnician_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            if (this.Tag == null)
            {
                LoadCombos();
                rdoOwn.Checked = true;
                rdoVariable.Checked = true;
                ctlInterService1.Enabled = false;
                dgvBrandSkill.Enabled = true;
                lblThirdParty.Enabled = false;
            }
            else
            {
                Technician oTechnician = (Technician)this.Tag;
                CSDTechnicianSkills oCSDTechnicianSkills = new CSDTechnicianSkills();
                oCSDTechnicianSkills.GetTechnicianWiseSkill(oTechnician.TechnicianID);

                foreach (CSDTechnicianSkill oCSDTechnicianSkill in oCSDTechnicianSkills)
                {
                    if (oCSDTechnicianSkill.WorkTypeID !=0 && oCSDTechnicianSkill.SkillType == (int)Dictionary.CSDTechnicianSkillType.WorkTypeSkill)
                    {
                        foreach (DataGridViewRow oItemRow in dgvWorkType.Rows)
                        {
                            if (oItemRow.Index < dgvBrandSkill.Rows.Count)
                            {
                                if ((int)oItemRow.Cells[1].Value == oCSDTechnicianSkill.WorkTypeID)
                                {
                                    oItemRow.Cells[0].Value = true;
                                }                                
                            }
                        }
                    }
                }


                foreach (CSDTechnicianSkill oCSDTechnicianSkill in oCSDTechnicianSkills)
                {
                    if (oCSDTechnicianSkill.BrandID == -1)
                    {
                        chkAllBrand.Checked = true;
                        break;
                    }
                    if (oCSDTechnicianSkill.BrandID != 0 && oCSDTechnicianSkill.SkillType == (int)Dictionary.CSDTechnicianSkillType.BrandSkill)
                    {
                        foreach (DataGridViewRow oItemRow in dgvBrandSkill.Rows)
                        {
                            if (oItemRow.Index < dgvBrandSkill.Rows.Count)
                            {
                                if ((int)oItemRow.Cells[1].Value == oCSDTechnicianSkill.BrandID)
                                {
                                    oItemRow.Cells[0].Value = true;
                                }
                            }
                        }
                    }
                }


                if (oTechnician.TechnicianTypeID == (int)Dictionary.CSDTechnicianType.Own)
                {
                    rdoOwn.Checked = true;
                    ctlInterService1.Enabled = false;
                    lblThirdParty.Enabled = false;
                }
                else if (oTechnician.TechnicianTypeID == (int)Dictionary.CSDTechnicianType.ThirdParty)
                {
                    rdoThirdParty.Checked = true;                    
                }
                if (oTechnician.IsVariable == (int)Dictionary.CSDOwnTechnicianType.Variable)
                {
                    rdoVariable.Checked = true;
                }
                else if (oTechnician.IsVariable == (int)Dictionary.CSDOwnTechnicianType.NonVariable)
                {
                    rdoNonVariable.Checked = true;
                }

            }
        }
        private void DataLoadControl()
        {
            dgvBrandSkill.Rows.Clear();
            _oBrands = new Brands();
            DBController.Instance.OpenNewConnection();
            _oBrands.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            foreach (Brand oBrand in _oBrands)
            {
                int n = dgvBrandSkill.Rows.Add();
                dgvBrandSkill.Rows[n].Cells[1].Value = oBrand.BrandID;
                dgvBrandSkill.Rows[n].Cells[2].Value = oBrand.BrandDesc;
                dgvBrandSkill.Rows[n].ReadOnly = false;
            }


            dgvWorkType.Rows.Clear();

            int WorkTypeLen = Enum.GetNames(typeof(Dictionary.TechnicianWorkType)).Length;
            for (int i = 1; i <= WorkTypeLen; i++)
            {
                int n = dgvWorkType.Rows.Add();
                dgvWorkType.Rows[n].Cells[1].Value = i;
                dgvWorkType.Rows[n].Cells[2].Value = Enum.GetName(typeof(Dictionary.TechnicianWorkType), i);
            }
                       
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoOwn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOwn.Checked)
            {
                rdoVariable.Checked = true;
                rdoVariable.Enabled = true;
                rdoNonVariable.Enabled = true;

            }
            else
            {
                rdoVariable.Enabled = false;
                rdoNonVariable.Enabled = false;
            }
        }

        private void rdoVariable_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVariable.Checked)
            {
                txtMaxPayment.Enabled = true;
                txtMinPayment.Enabled = true;
                lblMaxPayment.Enabled = true;
                lblMinPayment.Enabled = true;
            }
            else
            {
                txtMaxPayment.Enabled = false;
                txtMinPayment.Enabled = false;
                lblMaxPayment.Enabled = false;
                lblMinPayment.Enabled = false;
            }
        }

        private void rdoThirdParty_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoThirdParty.Checked)
            {
                grbOwnType.Enabled = false;

                ctlInterService1.Enabled = true;
                lblThirdParty.Enabled = true;
                rdoVariable.Checked = false;
                rdoNonVariable.Checked = false;
                rdoVariable.Enabled = false;
                rdoNonVariable.Enabled = false;
                txtMaxPayment.Enabled = false;
                txtMinPayment.Enabled = false;
                lblMaxPayment.Enabled = false;
                lblMinPayment.Enabled = false;
            }
            else
            {
                grbOwnType.Enabled = true;

                ctlInterService1.Enabled = false;
                lblThirdParty.Enabled = false;
                rdoVariable.Checked = true;
                rdoNonVariable.Checked = true;
                rdoVariable.Enabled = true;
                rdoNonVariable.Enabled = true;
                txtMaxPayment.Enabled = true;
                txtMinPayment.Enabled = true;
                lblMaxPayment.Enabled = true;
                lblMinPayment.Enabled = true;

            }
        }

        private void rdoNonVariable_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNonVariable.Checked)
            {
                txtMaxPayment.Enabled = false;
                txtMinPayment.Enabled = false;
                lblMaxPayment.Enabled = false;
                lblMinPayment.Enabled = false;
            }
            else
            {
                txtMaxPayment.Enabled = true;
                txtMinPayment.Enabled = true;
                lblMaxPayment.Enabled = true;
                lblMinPayment.Enabled = true;
            }
        }

        private void chkAllBrand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllBrand.Checked)
            {
                //dgvBrandSkill.Enabled = false;

                foreach (DataGridViewRow oItemRow in dgvBrandSkill.Rows)
                {
                    if (oItemRow.Index < dgvBrandSkill.Rows.Count)
                    {
                        oItemRow.Cells[0].Value = true;
                        oItemRow.ReadOnly = true;
                    }
                }
            }
            else
            {
                //dgvBrandSkill.Enabled = true;
                foreach (DataGridViewRow oItemRow in dgvBrandSkill.Rows)
                {
                    if (oItemRow.Index < dgvBrandSkill.Rows.Count)
                    {
                        oItemRow.Cells[0].Value = false;
                        oItemRow.ReadOnly = false;
                    }
                }
            }
        }      
    }

}