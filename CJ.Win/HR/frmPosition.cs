using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmPosition : Form
    {
        Company _oCompany;
        HRPositionRoles _oHRPositionRaleType;
        HRPositionRoles _oHRPositionRale;
        Departments _oDepartments;
        HRPositions _oHRPositions;
        HRPosition _oHRPosition;
        HRPositions _oArea;
        HRPositions _oTerritory;
        HRPositions _oCustomer;
        public bool _bFlag;

        int nPositionID;
        int nCompanyID;
        string sPositionCode;
        string sPositionName;
        bool bIsAdd;
        string sDatabase = "x";
        int nAreaID;
        int nTerritoryID;
        int nCustomerID;

        public frmPosition(int PositionID, int CompanyID, string PositionCode, string PositionName, bool IsAdd)
        {
            nPositionID = PositionID;
            nCompanyID = CompanyID;
            sPositionCode = PositionCode;
            sPositionName = PositionName;
            bIsAdd = IsAdd;
            
            if (nCompanyID == (int)Dictionary.CompanyID.TEL)
            {
                sDatabase = "TELSysDB";
            }
            else if (nCompanyID == (int)Dictionary.CompanyID.BLL)
            {
                sDatabase = "BLLSysDB";
            }
            else if (nCompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                sDatabase = "BEILSysDB";
            }
            else
            {
                sDatabase = "TMLSysDB";
            }

            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _bFlag = false;
            this.Close();
        }

        private void frmHRPositionAdd_Load(object sender, EventArgs e)
        {
            lblParentPosition.Text = sPositionName + " [" + sPositionCode + "]";
            _oCompany = new Company();
            _oCompany.CompanyID = nCompanyID;
            _oCompany.Refresh();
            lblCompany.Text = _oCompany.CompanyName + " [" + _oCompany.CompanyCode + "]";

            if (bIsAdd)
            {
                this.Text = "Add HR Position";
                rdoHO.Checked = true;
                rdoArea.Checked = true;
                LoanCombo();
            }
            else
            {
                this.Text = "Edit HR Position";
            }
        }

        private void LoanCombo()
        {
            //Role Type
            _oHRPositionRaleType = new HRPositionRoles();
            _oHRPositionRaleType.Refresh(1);
            cmbRoleType.Items.Clear();
            foreach (HRPositionRole oHRPositionRole in _oHRPositionRaleType)
            {
                cmbRoleType.Items.Add(oHRPositionRole.Name);
            }
            cmbRoleType.SelectedIndex = 0;

            //Role
            _oHRPositionRale = new HRPositionRoles();
            _oHRPositionRale.Refresh(2);
            cmbRole.Items.Clear();
            foreach (HRPositionRole oHRPositionRole in _oHRPositionRale)
            {
                cmbRole.Items.Add(oHRPositionRole.Name);
            }
            cmbRole.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.Refresh();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("--Select--");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            
            //Area
            _oArea = new HRPositions();
            _oArea.GetMarketGroup("Area", 0, sDatabase);
            cmbArea.Items.Clear();
            cmbArea.Items.Add("NA");
            foreach (HRPosition oHRPosition in _oArea)
            {
                cmbArea.Items.Add(oHRPosition.MarketGroupDesc);
            }
            cmbArea.SelectedIndex = 0;

        }

        private void rdoHO_CheckedChanged(object sender, EventArgs e)
        {
            rdoArea.Checked = true;
            gbMarketGroup.Visible = false;
            
            cmbArea.Enabled = false;
            cmbTerritory.Enabled = false;
            cmbCustomer.Enabled = false;
        }

        private void rdoField_CheckedChanged(object sender, EventArgs e)
        {
            gbMarketGroup.Visible = true;
            cmbArea.Enabled = true;
        }

        private void rdoArea_CheckedChanged(object sender, EventArgs e)
        {
            cmbArea.Enabled = true;
            cmbTerritory.Enabled = false;
            cmbCustomer.Enabled = false;
        }

        private void rdoTerritory_CheckedChanged(object sender, EventArgs e)
        {
            cmbArea.Enabled = true;
            cmbTerritory.Enabled = true;
            cmbCustomer.Enabled = false;
            if (nAreaID != 0)
            {
                LoadTerritory();
            }
        }

        private void rdoDistributor_CheckedChanged(object sender, EventArgs e)
        {
            cmbArea.Enabled = true;
            cmbTerritory.Enabled = true;
            cmbCustomer.Enabled = true;

            if (nTerritoryID != 0)
            {
                LoadCustomer();
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex != 0)
            {
                nAreaID = _oArea[cmbArea.SelectedIndex - 1].MarketGroupID;
            }

            if (cmbArea.SelectedIndex != 0)
            {
                LoadTerritory();

            }
        }

        private void cmbTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTerritory.SelectedIndex != 0)
            {
                nTerritoryID = _oTerritory[cmbTerritory.SelectedIndex - 1].MarketGroupID;
            }

            if (cmbTerritory.SelectedIndex != 0)
            {
                LoadCustomer();
            }

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != 0)
            {
                nCustomerID = _oCustomer[cmbCustomer.SelectedIndex - 1].MarketGroupID;
            }
        }

        private void LoadTerritory()
        {
            _oTerritory = new HRPositions();
            _oTerritory.GetMarketGroup("Territory", nAreaID, sDatabase);
            cmbTerritory.Items.Clear();
            cmbTerritory.Items.Add("NA");
            foreach (HRPosition oHRPosition in _oTerritory)
            {
                cmbTerritory.Items.Add(oHRPosition.MarketGroupDesc);
            }
            cmbTerritory.SelectedIndex = 0;
        }

        private void LoadCustomer()
        {
            _oCustomer = new HRPositions();
            _oCustomer.GetMarketGroup("Customer", nTerritoryID, sDatabase);
            cmbCustomer.Items.Clear();
            cmbCustomer.Items.Add("NA");
            foreach (HRPosition oHRPosition in _oCustomer)
            {
                cmbCustomer.Items.Add(oHRPosition.MarketGroupDesc);
            }
            cmbCustomer.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void Save()
        {
            _oHRPosition = new HRPosition();
            _oHRPosition.PositionCode = txtPositionCode.Text;
            _oHRPosition.PositionName = txtPositionName.Text;
            _oHRPosition.CompanyID = nCompanyID;
            _oHRPosition.DepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            if (rdoHO.Checked == true)
            {
                _oHRPosition.BaseStationType = (int)Dictionary.HRBaseStationType.HeadOfficer;
            }
            else
            {
                _oHRPosition.BaseStationType = (int)Dictionary.HRBaseStationType.Field;
            }
            _oHRPosition.RoleType = _oHRPositionRaleType[cmbRoleType.SelectedIndex].ID;
            _oHRPosition.Role = _oHRPositionRale[cmbRole.SelectedIndex].ID;
            _oHRPosition.Sort = 1;
            _oHRPosition.ParentID = nPositionID;

            if (rdoHO.Checked == true)
            {
                _oHRPosition.MarketGroupType = -1;
                _oHRPosition.MarketGroupID = -1;
            }
            else
            {
                if (rdoArea.Checked == true)
                {
                    _oHRPosition.MarketGroupType = (int)Dictionary.HRPositionMarketGroup.Area;
                    _oHRPosition.MarketGroupID = nAreaID;
                }
                else if (rdoTerritory.Checked == true)
                {
                    _oHRPosition.MarketGroupType = (int)Dictionary.HRPositionMarketGroup.Territory;
                    _oHRPosition.MarketGroupID = nTerritoryID;
                }
                else
                {
                    _oHRPosition.MarketGroupType = (int)Dictionary.HRPositionMarketGroup.Customer;
                    _oHRPosition.MarketGroupID = nCustomerID;
                }
            }
            _oHRPosition.CreateUserID = Utility.UserId;
            _oHRPosition.CreateDate = DateTime.Now;
            _oHRPosition.UpdateUserID = Utility.UserId;
            _oHRPosition.UpdateDate = DateTime.Now;
            _oHRPosition.Remarks = txtRemarks.Text;

            try
            {
                DBController.Instance.BeginNewTransaction();
                if (bIsAdd)
                {
                    _oHRPosition.Add();
                }
                else
                {
                    _oHRPosition.Edit(nPositionID);
                }
                _bFlag = true;
                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully saved data", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("An Error occurred inserting data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void EditMode(DSPosition.PositionRow oSeletedItem)
        {

            LoanCombo();

            txtPositionCode.Text = oSeletedItem.PositionCode;
            txtPositionName.Text = oSeletedItem.PositionName;
            cmbDepartment.SelectedIndex = _oDepartments.GetIndex(oSeletedItem.DepartmentID) + 1;
            if (oSeletedItem.BaseStationType == (int)Dictionary.HRBaseStationType.HeadOfficer)
            {
                rdoHO.Checked = true;
            }
            else
            {
                rdoField.Checked = true;
            }
            cmbRoleType.SelectedIndex = _oHRPositionRaleType.GetIndex(oSeletedItem.RoleType);
            cmbRole.SelectedIndex = _oHRPositionRale.GetIndex(oSeletedItem.Role);

            if (oSeletedItem.BaseStationType == (int)Dictionary.HRBaseStationType.Field)
            {
                if (oSeletedItem.MarketGroupType == (int)Dictionary.HRPositionMarketGroup.Area)
                {
                    rdoArea.Checked = true;
                    cmbArea.SelectedIndex = _oArea.GetMarketGroupIndex(oSeletedItem.MarketGroupID) + 1;

                }
                else if (oSeletedItem.MarketGroupType == (int)Dictionary.HRPositionMarketGroup.Territory)
                {
                    rdoTerritory.Checked = true;
                    HRPosition oHRPosi = new HRPosition();
                    nAreaID = oHRPosi.GetMarketGroupID("Area", oSeletedItem.MarketGroupID, sDatabase);

                    LoadTerritory();
                    cmbArea.SelectedIndex = _oArea.GetMarketGroupIndex(nAreaID) + 1;
                    cmbTerritory.SelectedIndex = _oTerritory.GetMarketGroupIndex(oSeletedItem.MarketGroupID) + 1;

                }
                else
                {
                    rdoDistributor.Checked = true;
                    HRPosition oHRPosi = new HRPosition();
                    nTerritoryID = oHRPosi.GetMarketGroupID("Territory", oSeletedItem.MarketGroupID, sDatabase);
                    nAreaID = oHRPosi.GetMarketGroupID("Area", nTerritoryID, sDatabase);

                    cmbArea.SelectedIndex = _oArea.GetMarketGroupIndex(nAreaID) + 1;
                    cmbTerritory.SelectedIndex = _oTerritory.GetMarketGroupIndex(nTerritoryID) + 1;
                    LoadCustomer();
                    cmbCustomer.SelectedIndex = _oCustomer.GetMarketGroupIndex(oSeletedItem.MarketGroupID) + 1;
                }
            }
            txtRemarks.Text = oSeletedItem.Remarks;


            this.ShowDialog();
        }
    }
}