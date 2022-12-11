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

namespace CJ.Win.Basic
{
    public partial class frmOutletSiteInfo : Form
    {
        public bool _Istrue = false;
        int _nstatus = 0;
        Showrooms oShowrooms;
        OtletAreaTypes oOtletAreaTypes;
        OtletAreaTypes _oOtletAreaTypes;
        OutletSiteInfo _oOutletSiteInfo;
        int nSiteID = 0;
        string sCode = "";
        int _nIsUpdate = 0;
        public frmOutletSiteInfo()
        {
            InitializeComponent();
        }
        public void ShowDialog(OutletSiteInfo oOutletSiteInfo)
        {
            _nIsUpdate = 1;
            DBController.Instance.OpenNewConnection();
            this.Tag = oOutletSiteInfo;
            LoadCombo();
            nSiteID = oOutletSiteInfo.SiteID;
            txtName.Text = oOutletSiteInfo.SiteName;
            txtOwnerName.Text = oOutletSiteInfo.OwnersName;
            txtAddress.Text = oOutletSiteInfo.OwnersAddress;
            txtRentIncrement.Text = oOutletSiteInfo.RentalIncrement.ToString();
            txtadjustment.Text = oOutletSiteInfo.AdvanceAdjustment;
            txtGovtVatTax.Text = oOutletSiteInfo.GovtVatTax;
            dtEntryDate.Value = oOutletSiteInfo.EntryDate;
            txtCPeriod.Text = oOutletSiteInfo.ContactPeriod.ToString();
            dtEffectiveDate.Value = oOutletSiteInfo.EffectiveDate;
            txtELoad.Text = oOutletSiteInfo.ElectricityLoad.ToString();
            cmbShowroom.Text = oOutletSiteInfo.OutletCode;
            dtHandOverdate.Value= oOutletSiteInfo.HandOverDate;
            txtMobileNo.Text = oOutletSiteInfo.MobileNo;
            txtCHeight.Text = oOutletSiteInfo.CellingHeight;
            txtParking.Text = oOutletSiteInfo.Parking;
            txtBenchMark.Text = oOutletSiteInfo.OutletBenchMark;
            txtUCharge.Text = oOutletSiteInfo.UtilityCharges;
            txtLandLord.Text = oOutletSiteInfo.LandLordProvide;
            //cmbOutletSiteInfoType.SelectedIndex = oOutletSiteInfo.OutletSiteInfoTypeID;

            OutletSiteInfos oOutletSiteInfos = new OutletSiteInfos();
            oOutletSiteInfos.RefreshBySiteInfoDetail(nSiteID);
            //Detail
            foreach (OutletSiteInfoDetail oItem in oOutletSiteInfos)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDetail);
                oRow.Cells[1].Value = oItem.AreaType;
                oRow.Cells[2].Value = oItem.Area;
                oRow.Cells[3].Value = oItem.RentAmount.ToString();
                oRow.Cells[4].Value = oItem.AdvancedAmount.ToString();
                dgvDetail.Rows.Add(oRow);

            }
            //Others
            oOutletSiteInfos.RefreshBySiteInfoOther(nSiteID);
            foreach (OutletSiteInfoOther oItem in oOutletSiteInfos)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOther);
                oRow.Cells[1].Value = oItem.SignageType;
                oRow.Cells[2].Value = oItem.Size;
                oRow.Cells[3].Value = oItem.verticalSize;
                oRow.Cells[4].Value = oItem.CommercialPermission;
                dgvOther.Rows.Add(oRow);

            }

            this.ShowDialog();
        }
        private void frmOutletSiteInfo_Load(object sender, EventArgs e)
        {
            if (this.Tag == null || this.Tag == " ")
            {
                LoadCombo();
            }
            if (_nIsUpdate == 0)
                LoadArea();                        
        }
        private void LoadArea()
        {
            oOtletAreaTypes = new OtletAreaTypes();
            oOtletAreaTypes.Refresh();
            foreach (OtletAreaType oOtletAreaType in oOtletAreaTypes)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDetail);
                oRow.Cells[1].Value = oOtletAreaType.AreaType;
                oRow.Cells[5].Value = oOtletAreaType.ID;
                dgvDetail.Rows.Add(oRow);

            }
            _oOtletAreaTypes = new OtletAreaTypes();
            _oOtletAreaTypes.RefreshByOthers();
            foreach (OtletAreaType oOtletAreaType in _oOtletAreaTypes)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOther);
                oRow.Cells[1].Value = oOtletAreaType.AreaType;
                oRow.Cells[5].Value = oOtletAreaType.ID;
                dgvOther.Rows.Add(oRow);

            }


        }
        private void LoadCombo()
        {
            oShowrooms = new Showrooms();
            oShowrooms.Refresh();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("-- <All>--");
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            if (cmbShowroom.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Showroom", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbShowroom.Focus();
                return false;
            }
            //if (cmbOutletSiteInfoType.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Outlet Feasibility Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbOutletSiteInfoType.Focus();
            //    return false;
            //}
            //if (txtTotalAmount.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Input Total Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTotalAmount.Focus();
            //    return false;
            //}
            //foreach (DataGridViewRow oRow in dgvData.Rows)
            //{
            //    if (oRow.Cells[4].Value == null || oRow.Cells[5].Value == null || oRow.Cells[7].Value == null)
            //    {
            //        MessageBox.Show("Please Input Quantity, ASP, GM% Properly OR Delete unwanted Rows.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            //if (dgvData.Rows.Count == 0)
            //{
            //    MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            return true;
        }
        private void Save()
        {
            if (this.Tag != null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    OutletSiteInfo _oOutletSiteInfo = (OutletSiteInfo)this.Tag;
                    _oOutletSiteInfo = GetUIData(_oOutletSiteInfo);
                    _oOutletSiteInfo.Edit();
                    //ADDOutletSiteInfoHistory(_oOutletSiteInfo);
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Update OutletSiteInfo # " + _oOutletSiteInfo.SiteID.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletSiteInfo = new OutletSiteInfo();
                    _oOutletSiteInfo = GetUIData(_oOutletSiteInfo);
                    //_oOutletSiteInfo.UpdateIscurrent(cmbShowroom.Text);
                    _oOutletSiteInfo.Add();

                    // Others
                    foreach (DataGridViewRow oItemRow in dgvOther.Rows)
                    {
                        if (oItemRow.Index < dgvOther.Rows.Count)
                        {
                            OutletSiteInfoOther _oOutletSiteInfoOther = new OutletSiteInfoOther();
                            _oOutletSiteInfoOther.SignageType = Convert.ToInt32(oItemRow.Cells[5].Value);
                            _oOutletSiteInfoOther.Size = oItemRow.Cells[2].Value.ToString();
                            _oOutletSiteInfoOther.verticalSize = oItemRow.Cells[3].Value.ToString();
                            _oOutletSiteInfoOther.CommercialPermission = oItemRow.Cells[4].Value.ToString();
                            _oOutletSiteInfoOther.Add(_oOutletSiteInfo.SiteID);
                        }
                    }
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Add OutletSiteInfo # " + _oOutletSiteInfo.SiteID.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        public OutletSiteInfo GetUIData(OutletSiteInfo _oOutletSiteInfo)
        {            
            //_oOutletSiteInfo.OutletSiteInfoCode = txtCode.Text;
            _oOutletSiteInfo.OutletCode = oShowrooms[cmbShowroom.SelectedIndex - 1].ShowroomCode;
            _oOutletSiteInfo.SiteName= txtName.Text;
            _oOutletSiteInfo.EntryDate = dtEntryDate.Value;
            _oOutletSiteInfo.CreateBy = Utility.UserId;
            _oOutletSiteInfo.CreateDate = DateTime.Now;
            _oOutletSiteInfo.OwnersName = txtOwnerName.Text;
            _oOutletSiteInfo.OwnersAddress = txtAddress.Text;
            _oOutletSiteInfo.MobileNo = txtMobileNo.Text;
            _oOutletSiteInfo.RentalIncrement =Convert.ToDouble(txtRentIncrement.Text);
            _oOutletSiteInfo.ContactPeriod = Convert.ToDouble(txtCPeriod.Text);
            _oOutletSiteInfo.AdvanceAdjustment = txtadjustment.Text;
            _oOutletSiteInfo.ElectricityLoad =Convert.ToInt32(txtELoad.Text);
            _oOutletSiteInfo.EffectiveDate = dtEffectiveDate.Value;
            _oOutletSiteInfo.HandOverDate = dtHandOverdate.Value;
            _oOutletSiteInfo.CellingHeight = txtCHeight.Text;
            _oOutletSiteInfo.Parking = txtParking.Text;
            _oOutletSiteInfo.GovtVatTax = txtGovtVatTax.Text;
            _oOutletSiteInfo.UtilityCharges = txtUCharge.Text;
            _oOutletSiteInfo.LandLordProvide = txtLandLord.Text;
            _oOutletSiteInfo.OutletBenchMark = txtBenchMark.Text;
            // Details

            foreach (DataGridViewRow oItemRow in dgvDetail.Rows)
            {
                if (oItemRow.Index < dgvDetail.Rows.Count)
                {
                    OutletSiteInfoDetail _oOutletSiteInfoDetail = new OutletSiteInfoDetail();
                    _oOutletSiteInfoDetail.AreaType = Convert.ToInt32(oItemRow.Cells[5].Value);
                    _oOutletSiteInfoDetail.Area = Convert.ToInt32(oItemRow.Cells[2].Value);
                    _oOutletSiteInfoDetail.RentAmount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                    _oOutletSiteInfoDetail.AdvancedAmount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                    _oOutletSiteInfo.Add(_oOutletSiteInfoDetail);
                }
            }            
            return _oOutletSiteInfo;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
            }
        }
    }
}
