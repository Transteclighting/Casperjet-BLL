using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;
using CJ.Win.Security;
using CJ.Report;

namespace CJ.Win.Basic
{
    public partial class frmOutletFeasibilitys : Form
    {
        bool IsCheck = false;
        public bool _Istrue = false;
        Brands oBrands;
        ProductGroups oProductGroups;
        Showrooms oShowrooms;
        OutletFeasibility _oOutletFeasibility;
        OutletFeasibilitys _oOutletFeasibilitys;
        int nSiteinfoID = 0;
        string SCode = "";
        public frmOutletFeasibilitys()
        {
            InitializeComponent();
        }

        public void ShowDialog(OutletSiteInfo oOutletSiteInfo)
        {
            this.Tag = oOutletSiteInfo;
            //LoadCombo();
            nSiteinfoID = oOutletSiteInfo.SiteID;
            SCode = oOutletSiteInfo.OutletCode;
            this.ShowDialog();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOutletFeasibility oForm = new frmOutletFeasibility(nSiteinfoID,(int)Dictionary.OutletFeasibilityStatus.Create);
            oForm.ShowDialog();
            if (oForm._Istrue == true);
                LoadData();
        }
        private void LoadCombo()
        {
            oShowrooms = new Showrooms();
            oShowrooms.Refresh();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("<All>");
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;

            oBrands = new Brands();
            oBrands.GetCACBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            oProductGroups = new ProductGroups();
            oProductGroups.GetMAG();
            cmbMag.Items.Clear();
            cmbMag.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in oProductGroups)
            {
                cmbMag.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMag.SelectedIndex = 0;
        }
        public void LoadData()
        {

            lvwData.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oOutletFeasibilitys = new OutletFeasibilitys();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //int nIsActive = 0;
            //if (cmbIsActive.SelectedIndex == 0)
            //{
            //    nIsActive = -1;
            //}
            //else
            //{
            //    nIsActive = cmbIsActive.SelectedIndex - 1;
            //}
            _oOutletFeasibilitys.RefreshOutletFeasibility(dtFromdate.Value.Date, dtTodate.Value.Date, cmbShowroom.Text,IsCheck);
            foreach (OutletFeasibility _oOutletFeasibility in _oOutletFeasibilitys)
            {
                ListViewItem oItem = lvwData.Items.Add(_oOutletFeasibility.ShowroomCode.ToString());
                oItem.SubItems.Add(_oOutletFeasibility.CreateDate.ToString("dd-MMM-yyyy"));
                if (_oOutletFeasibility.ShowroomOpeningDate == "") oItem.SubItems.Add("");
                else oItem.SubItems.Add(((DateTime)_oOutletFeasibility.ShowroomOpeningDate).ToString("dd-MMM-yyyy"));
                if (_oOutletFeasibility.EffectiveDate == "") oItem.SubItems.Add("");
                else oItem.SubItems.Add(((DateTime)_oOutletFeasibility.EffectiveDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oOutletFeasibility.InvestmentAmount.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.OutletFeasibilityStatus), _oOutletFeasibility.Status));
                oItem.SubItems.Add(_oOutletFeasibility.Remarks.ToString());
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), _oOutletFeasibility.IsActive));
                oItem.Tag = _oOutletFeasibility;
            }
            this.Text = "Total" + "[" + _oOutletFeasibilitys.Count + "]";

            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (lvwData.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwData.Items)
                {
                    if (oItem.SubItems[5].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[5].Text == "Create")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                }
            }
        }
        private void UpdateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M2.10.4.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M2.10.4.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M2.10.4.3" == sPermissionKey)
                    {
                        btnApprove.Enabled = true;
                    }
                    if ("M2.10.4.4" == sPermissionKey)
                    {
                        btnView.Enabled = true;
                    }
                    if ("M2.10.4.5" == sPermissionKey)
                    {
                        btnViewDataEntry.Enabled = true;
                    }
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutletFeasibility oOutletFeasibility = (OutletFeasibility)lvwData.SelectedItems[0].Tag;
            //frmOutletFeasibility oForm = new frmOutletFeasibility((int)Dictionary.OutletFeasibilityStatus.Create);
            //oForm.ShowDialog(oOutletFeasibility);
            //if (oForm._Istrue == true) ;
            //LoadData();
            if (oOutletFeasibility.Status != (int)Dictionary.OutletFeasibilityStatus.Approve)
            {
                frmOutletFeasibility oForm = new frmOutletFeasibility(nSiteinfoID,(int)Dictionary.OutletFeasibilityStatus.Create);
                oForm.ShowDialog(oOutletFeasibility);
                if (oForm._Istrue == true) ;
                LoadData();
            }
            else
            {
                MessageBox.Show("After approved can't be update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmOutletFeasibilitys_Load(object sender, EventArgs e)
        {
            LoadCombo();
            UpdateSecurity();
            //if (Utility.Username == "gaohor")
            //{
            //    btnApprove.Enabled = true;
            //}
            //else
            //{
            //    btnApprove.Enabled = false;
            //}
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item for Approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutletFeasibility oOutletFeasibility = (OutletFeasibility)lvwData.SelectedItems[0].Tag;
            if (oOutletFeasibility.Status == (int)Dictionary.OutletFeasibilityStatus.Create)
            {
                frmOutletFeasibility oForm = new frmOutletFeasibility(nSiteinfoID,(int)Dictionary.OutletFeasibilityStatus.Approve);
                //oForm.ShowDialog(oOutletFeasibility);
                oOutletFeasibility.Approve(oOutletFeasibility.OutletFeasibilityID);
                LoadData();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Successfully Approved item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewSalesProjection();
        }

        private void ViewSalesProjection()
        {
            this.Cursor = Cursors.WaitCursor;
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item for view report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutletFeasibility oOutletFeasibility = (OutletFeasibility)lvwData.SelectedItems[0].Tag;
            int nOutletFeasibilityID = oOutletFeasibility.OutletFeasibilityID;
            OutletFeasibilitys oOutletFeasibilitys = new OutletFeasibilitys();
            oOutletFeasibilitys.ViewFeasibilitySalesProjection(oOutletFeasibility.OutletFeasibilityID);

            rptOutletFeasibilitySalesProjection doc = new rptOutletFeasibilitySalesProjection();            
            doc.SetDataSource(oOutletFeasibilitys);
            doc.SetParameterValue("ReportName", "Outlet Feasibility Sales Projection for"+"-"+oOutletFeasibility.OutletFeasibilityTypeName);
            doc.SetParameterValue("Outlet", oOutletFeasibility.ShowroomCode+"-"+"Outlet");
            //doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));           
            doc.SetParameterValue("User", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }
        private void ViewDataEntry()
        {
            this.Cursor = Cursors.WaitCursor;
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item for view report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutletFeasibility oOutletFeasibility = (OutletFeasibility)lvwData.SelectedItems[0].Tag;
            OutletFeasibilitys oOutletFeasibilitys = new OutletFeasibilitys();
            int nOutletFeasibilityID = oOutletFeasibility.OutletFeasibilityID;
            oOutletFeasibilitys.ViewFeasibilityDataEntry(oOutletFeasibility.OutletFeasibilityID);

            rptOutletFeasibilityDataEntry doc = new rptOutletFeasibilityDataEntry();
            doc.SetDataSource(oOutletFeasibilitys);
            doc.SetParameterValue("ReportName", "Quarterly Sales Data");//+ ":" + oOutletFeasibility.OutletFeasibilityTypeName
            doc.SetParameterValue("Outlet", oOutletFeasibility.ShowroomCode + "-" + "Outlet");
            //doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));           
            doc.SetParameterValue("User", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }
        private void btnViewDataEntry_Click(object sender, EventArgs e)
        {
            ViewDataEntry();
        }
    }
}
