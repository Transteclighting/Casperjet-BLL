using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.Basic
{

    public partial class frmOutletFeasibility : Form
    {
        public bool _Istrue = false;
        private bool IsClicked = false;
        OutletFeasibility _oOutletFeasibility;
        OutletFeasibilitys _oOutletFeasibilitys;
        OutletFeasibilityDetail _oOutletFeasibilityDetail;
        OutletFeasibilityTypes _oOutletFeasibilityTypes;
        Brands oBrands;
        ProductGroups oProductGroups;
        Showrooms oShowrooms;
        int nOutletFeasibility = 0;
        DateTime _dtDate;
        int _nstatus = 0;
        int _nIsUpdate = 0;
        int _nSiteID = 0;
        string _SCode = "";
        public frmOutletFeasibility(int nSiteID,int nStatus)
        {
            _nstatus = nStatus;
            _nSiteID = nSiteID;
            InitializeComponent();
            if (_nstatus == 1)
            {
                _oOutletFeasibility = new OutletFeasibility();
                txtCode.Text = _oOutletFeasibility.GenerateOutletFeasibilityCode();
            }
        }
        public void ShowDialog(OutletFeasibility oOutletFeasibility)
        {
            string sOpeningDate = "";
            string sEffectiveDate = "";
            _nIsUpdate = 1;
            DBController.Instance.OpenNewConnection();
            this.Tag = oOutletFeasibility;
            LoadCombo();
            nOutletFeasibility = oOutletFeasibility.OutletFeasibilityID;
            txtCode.Text = oOutletFeasibility.OutletFeasibilityCode;

            sOpeningDate = oOutletFeasibility.ShowroomOpeningDate.ToString();
            sEffectiveDate = oOutletFeasibility.EffectiveDate.ToString();
            //dtOpeningDate.Value =Convert.ToDateTime(oOutletFeasibility.ShowroomOpeningDate);
            if (sOpeningDate == "")
            {
                dtOpeningDate.Value = DateTime.Now;
            }
            else
            {
                dtOpeningDate.Value = Convert.ToDateTime(oOutletFeasibility.ShowroomOpeningDate);
            }
            if (sEffectiveDate == "")
            {
                dtEffectiveDate.Value = DateTime.Now;
            }
            else
            {
                dtEffectiveDate.Value = Convert.ToDateTime(oOutletFeasibility.EffectiveDate);
            }

            cmbShowroom.Text = oOutletFeasibility.ShowroomCode;
            if (oOutletFeasibility.IsCurrent == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsCurrent.Checked = true;
            }
            else
            {
                chkIsCurrent.Checked = false;
            }
            txtTotalAmount.Text = oOutletFeasibility.InvestmentAmount.ToString();
            txtRemarks.Text = oOutletFeasibility.Remarks;
            cmbOutletFeasibilityType.SelectedIndex = oOutletFeasibility.OutletFeasibilityTypeID;


            OutletFeasibilitys oOutletFeasibilitys = new OutletFeasibilitys();
            oOutletFeasibilitys.OutletFeasibilityDetail(oOutletFeasibility.OutletFeasibilityID);
            foreach (OutletFeasibilityDetail oItem in oOutletFeasibilitys)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvData);

                oRow.Cells[0].Value = oItem.PG;
                oRow.Cells[1].Value = oItem.Mag;
                oRow.Cells[2].Value = oItem.Brand;
                oRow.Cells[3].Value = oItem.YearNo.ToString();
                oRow.Cells[4].Value = oItem.Quantity.ToString();
                oRow.Cells[5].Value = oItem.ASP;
                oRow.Cells[6].Value = oItem.Value.ToString();
                oRow.Cells[7].Value = oItem.GMPercent.ToString();
                oRow.Cells[8].Value = oItem.MAGID.ToString();
                oRow.Cells[9].Value = oItem.BrandID.ToString();
                oRow.Cells[10].Value = oItem.MCRate.ToString();
                dgvData.Rows.Add(oRow);

            }

            foreach (DataGridViewRow oRow in dgvData.Rows)
            {
                oRow.Cells[0].ReadOnly = true;
                oRow.Cells[0].Style.BackColor = Color.Silver;
                oRow.Cells[1].ReadOnly = true;
                oRow.Cells[1].Style.BackColor = Color.Silver;
                oRow.Cells[2].ReadOnly = true;
                oRow.Cells[2].Style.BackColor = Color.Silver;
                oRow.Cells[3].ReadOnly = true;
                oRow.Cells[3].Style.BackColor = Color.Silver;
                oRow.Cells[4].ReadOnly = false;
                oRow.Cells[5].ReadOnly = false;


                oRow.Cells[6].ReadOnly = true;
                oRow.Cells[6].Style.BackColor = Color.Silver;
                oRow.Cells[7].ReadOnly = false;
                oRow.Cells[8].ReadOnly = true;
                oRow.Cells[8].Style.BackColor = Color.Silver;
                oRow.Cells[9].ReadOnly = true;
                // gaohor
                if (Utility.Username == "gaohor")
                {
                    oRow.Cells[10].ReadOnly = false;
                    oRow.Cells[10].Style.BackColor = Color.White;
                    oRow.Cells[7].ReadOnly = false;
                    oRow.Cells[7].Style.BackColor = Color.White;
                }
                else
                {
                    oRow.Cells[10].ReadOnly = true;
                    oRow.Cells[10].Style.BackColor = Color.Silver;
                    oRow.Cells[7].ReadOnly = true;
                    oRow.Cells[7].Style.BackColor = Color.Silver;
                }
            }

            OutletFeasibilityQuarters oOutletFeasibilityQuarters = new OutletFeasibilityQuarters();
            oOutletFeasibilityQuarters.Refresh(oOutletFeasibility.OutletFeasibilityID);

            if (oOutletFeasibilityQuarters.Count != 0)
            {
                IsClicked = true;
            }

            cmbShowroom.Enabled = false;
            this.ShowDialog();
        }
        private void frmOutletFeasibility_Load(object sender, EventArgs e)
        {
            if (this.Tag == null || this.Tag == " ")
            {
                LoadCombo();
                btnQuarter.Visible = false;
            }

            //OutletFeasibility oOutletFeasibility = (OutletFeasibility)this.Tag;
            //int id = 0;
            //if (_nIsUpdate != 0)
            //{
            //    id = oOutletFeasibility.OutletFeasibilityID;
            //}
            if (_nIsUpdate == 0)
                LoadMAGList(0, 0);

        }

        private void LoadMAGList(int nIsUpdate, int nOutletFeasibilityID)
        {
            OutletFeasibilityMAGLists oOutletFeasibilityMAGLists = new OutletFeasibilityMAGLists();
            oOutletFeasibilityMAGLists.Refresh(nIsUpdate, nOutletFeasibilityID);
            foreach (OutletFeasibilityMAGList oList in oOutletFeasibilityMAGLists)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvData);

                oRow.Cells[0].Value = oList.PG;
                oRow.Cells[1].Value = oList.Mag;
                oRow.Cells[8].Value = oList.MAGID;
                oRow.Cells[2].Value = oList.Brand;
                oRow.Cells[9].Value = oList.BrandID;
                oRow.Cells[3].Value = oList.TYear.ToString();
                oRow.Cells[7].Value = 0;
                oRow.Cells[10].Value = 0;
                dgvData.Rows.Add(oRow);
            }


            foreach (DataGridViewRow oRow in dgvData.Rows)
            {
                oRow.Cells[0].ReadOnly = true;
                oRow.Cells[0].Style.BackColor = Color.Silver;
                oRow.Cells[1].ReadOnly = true;
                oRow.Cells[1].Style.BackColor = Color.Silver;
                oRow.Cells[2].ReadOnly = true;
                oRow.Cells[2].Style.BackColor = Color.Silver;
                oRow.Cells[3].ReadOnly = true;
                oRow.Cells[3].Style.BackColor = Color.Silver;
                oRow.Cells[4].ReadOnly = false;
                oRow.Cells[5].ReadOnly = false;



                oRow.Cells[6].ReadOnly = true;
                oRow.Cells[6].Style.BackColor = Color.Silver;
                oRow.Cells[7].ReadOnly = true;
                oRow.Cells[7].Style.BackColor = Color.Silver;
                oRow.Cells[8].ReadOnly = true;
                oRow.Cells[8].Style.BackColor = Color.Silver;
                oRow.Cells[9].ReadOnly = true;
                oRow.Cells[10].ReadOnly = true;
                oRow.Cells[10].Style.BackColor = Color.Silver;
                //gaohor
                //if (Utility.Username == "gaohor")
                //{
                //    oRow.Cells[10].ReadOnly = false;
                //    oRow.Cells[10].Style.BackColor = Color.White;
                //    oRow.Cells[7].ReadOnly = false;
                //    oRow.Cells[7].Style.BackColor = Color.White;
                //}
                //else
                //{
                //    oRow.Cells[10].ReadOnly = true;
                //    oRow.Cells[10].Style.BackColor = Color.Silver;
                //    oRow.Cells[7].ReadOnly = true;
                //    oRow.Cells[7].Style.BackColor = Color.Silver;
                //}
            }
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
            //else if(cmbShowroom.Text!=_SCode)
            //{
            //    MessageBox.Show("Please Select Valid Showroom", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
               
            if (cmbOutletFeasibilityType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Outlet Feasibility Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOutletFeasibilityType.Focus();
                return false;
            }
            if (txtTotalAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Total Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalAmount.Focus();
                return false;
            }
            foreach (DataGridViewRow oRow in dgvData.Rows)
            {
                if (oRow.Cells[4].Value == null || oRow.Cells[5].Value == null || oRow.Cells[7].Value == null)
                {
                    MessageBox.Show("Please Input Quantity, ASP, GM% Properly OR Delete unwanted Rows.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Save()
        {
            if (this.Tag != null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    OutletFeasibility _oOutletFeasibility = (OutletFeasibility)this.Tag;
                    _oOutletFeasibility = GetUIData(_oOutletFeasibility);
                    _oOutletFeasibility.ShowroomOpeningDate = Convert.ToDateTime(dtOpeningDate.Value.Date);
                    _oOutletFeasibility.EffectiveDate = Convert.ToDateTime(dtEffectiveDate.Value.Date);
                    _oOutletFeasibility.UpdateBy = Utility.UserId;
                    _oOutletFeasibility.UpdateDate = DateTime.Now;
                    _oOutletFeasibility.Edit();
                    //ADDOutletFeasibilityHistory(_oOutletFeasibility);
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Update OutletFeasibility # " + _oOutletFeasibility.OutletFeasibilityCode.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    _oOutletFeasibility = new OutletFeasibility();
                    _oOutletFeasibility = GetUIData(_oOutletFeasibility);
                    _oOutletFeasibility.UpdateIscurrent(cmbShowroom.Text);
                    _oOutletFeasibility.Add();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Add OutletFeasibility # " + _oOutletFeasibility.OutletFeasibilityCode.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        public OutletFeasibility GetUIData(OutletFeasibility _oOutletFeasibility)
        {
            if (chkIsCurrent.Checked == true)
            {
                _oOutletFeasibility.IsCurrent = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                _oOutletFeasibility.IsCurrent = (int)Dictionary.YesOrNoStatus.NO;
            }
            if (_nstatus == (int)Dictionary.OutletFeasibilityStatus.Create)
            {
                _oOutletFeasibility.Status = (int)Dictionary.OutletFeasibilityStatus.Create;
            }
            else if (_nstatus == (int)Dictionary.OutletFeasibilityStatus.Approve)
            {
                _oOutletFeasibility.Status = (int)Dictionary.OutletFeasibilityStatus.Approve;
            }
            //_oOutletFeasibility.OutletFeasibilityCode = txtCode.Text;
            _oOutletFeasibility.SiteID = _nSiteID;
            _oOutletFeasibility.ShowroomCode = oShowrooms[cmbShowroom.SelectedIndex - 1].ShowroomCode;
            _oOutletFeasibility.InvestmentAmount = Convert.ToDouble(txtTotalAmount.Text.ToString());
            _oOutletFeasibility.CreateBy = Utility.UserId;
            _oOutletFeasibility.CreateDate = DateTime.Now;
            _oOutletFeasibility.Remarks = txtRemarks.Text;
            _oOutletFeasibility.OutletFeasibilityTypeID = cmbOutletFeasibilityType.SelectedIndex;//_oOutletFeasibilityTypes[cmbOutletFeasibilityType.SelectedIndex - 1].OutletFeasibilityTypeID;

            // Details

            foreach (DataGridViewRow oItemRow in dgvData.Rows)
            {

                if (oItemRow.Index < dgvData.Rows.Count)
                {
                    OutletFeasibilityDetail _oOutletFeasibilityDetail = new OutletFeasibilityDetail();
                    //_oOutletFeasibilityDetail.ShowroomCode = oItemRow.Cells[0].Value.ToString();
                    _oOutletFeasibilityDetail.MAGID = int.Parse(oItemRow.Cells[8].Value.ToString());
                    _oOutletFeasibilityDetail.BrandID = int.Parse(oItemRow.Cells[9].Value.ToString());
                    _oOutletFeasibilityDetail.YearNo = int.Parse(oItemRow.Cells[3].Value.ToString());
                    _oOutletFeasibilityDetail.Quantity = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oOutletFeasibilityDetail.ASP = double.Parse(oItemRow.Cells[5].Value.ToString());
                    _oOutletFeasibilityDetail.Value = Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                    _oOutletFeasibilityDetail.GMPercent = Convert.ToDouble(oItemRow.Cells[7].Value.ToString());
                    _oOutletFeasibilityDetail.MCRate = Convert.ToDouble(oItemRow.Cells[10].Value.ToString());
                    _oOutletFeasibility.Add(_oOutletFeasibilityDetail);
                }
            }
            return _oOutletFeasibility;
        }
        private void LoadCombo()
        {
            oShowrooms = new Showrooms();
            oShowrooms.Refresh();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("-- Select Showroom --");
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;

            _oOutletFeasibilityTypes = new OutletFeasibilityTypes();
            _oOutletFeasibilityTypes.Refresh();
            cmbOutletFeasibilityType.Items.Clear();
            cmbOutletFeasibilityType.Items.Add("-- Select Type --");
            foreach (OutletFeasibility oFeasibility in _oOutletFeasibilityTypes)
            {
                cmbOutletFeasibilityType.Items.Add(oFeasibility.OutletFeasibilityTypeName);
            }
            cmbOutletFeasibilityType.SelectedIndex = 0;

            //oBrands = new Brands();
            //oBrands.GetCACBrand();
            //cmbBrand.Items.Clear();
            //cmbBrand.Items.Add("-- Select Brand --");
            //foreach (Brand oBrand in oBrands)
            //{
            //    cmbBrand.Items.Add(oBrand.BrandDesc);
            //}
            //cmbBrand.SelectedIndex = 0;

            oProductGroups = new ProductGroups();
            oProductGroups.GetMAG();
            //cmbMag.Items.Clear();
            //cmbMag.Items.Add("-- Select MAG --");
            //foreach (ProductGroup oProductGroup in oProductGroups)
            //{
            //    cmbMag.Items.Add(oProductGroup.PdtGroupName);
            //}
            //cmbMag.SelectedIndex = 0;
        }
        private void Clear()
        {
            //cmbShowroom.SelectedIndex = 0;
            //cmbBrand.SelectedIndex = 0;
            //cmbMag.SelectedIndex = 0;
            //txtYear.Text = "";
            //txtQty.Text = "";
            //txtAmount.Text = "";
            //txtGMPercent.Text = "";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null && IsClicked == false)
            {
                MessageBox.Show("Please Click Add Quarter and Save Quarter value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (validateUIInput())
                {
                    Save();
                    Clear();
                }
            }
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            if (nColumnIndex == 4)
            {
                if (dgvData.Rows[nRowIndex].Cells[4].Value.ToString() != null)
                {
                    try
                    {
                        dgvData.Rows[nRowIndex].Cells[4].Value = Convert.ToDouble(dgvData.Rows[nRowIndex].Cells[4].Value.ToString());

                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valid amount");
                    }
                }
                GetTotal();
            }

        }
        private void GetTotal()
        {
            txtTotalAmount.Text = "0.00";

            //foreach (DataGridViewRow oRow in dgvData.Rows)
            //{
            //    if (oRow.Cells[4].Value != null)
            //    {

            //            txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();
            //    }
            //}
        }
        //private void AddOutletFeasibilityList()
        //{
        //    DataGridViewRow oRow = new DataGridViewRow();
        //    oRow.CreateCells(dgvData);
        //    oRow.Cells[0].Value = cmbMag.Text;
        //    oRow.Cells[1].Value = cmbBrand.Text;
        //    oRow.Cells[2].Value = txtYear.Text;
        //    oRow.Cells[3].Value = txtQty.Text;
        //    oRow.Cells[4].Value = txtAmount.Text;
        //    oRow.Cells[5].Value = txtGMPercent.Text.ToString();
        //    oRow.Cells[6].Value = oProductGroups[cmbMag.SelectedIndex - 1].PdtGroupID;
        //    oRow.Cells[7].Value = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
        //    dgvData.Rows.Add(oRow);
        //}

        //private void btnAddToList_Click(object sender, EventArgs e)
        //{
        //    if (CheckUIGridView())
        //    {
        //        //AddOutletFeasibilityList();
        //        Clear();
        //        GetTotal();
        //    }
        //}

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvData_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private void btnQuarter_Click(object sender, EventArgs e)
        {
            if (_nIsUpdate == 1)
            {
                IsClicked = true;
                _dtDate = dtOpeningDate.Value;
                frmOutletFeasibilityQuarter oForm = new frmOutletFeasibilityQuarter();
                oForm.ShowDialog(nOutletFeasibility, _dtDate);
            }
            else
            {
                MessageBox.Show("Please click Add Quarter when update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 4)
            {
                dgvData.Rows[e.RowIndex].Cells[6].Value = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells[5].Value) * Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells[4].Value);
            }
        }

        private void cmbShowroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_nIsUpdate == 0)
            {
                OutletFeasibility oOutletFeasibility = new OutletFeasibility();
                oOutletFeasibility.ShowroomCode = cmbShowroom.Text;
                oOutletFeasibility.RefreshByShowroomCode();

                dgvData.Rows.Clear();

                if (oOutletFeasibility.OutletFeasibilityID != 0)
                {

                    //LoadMAGList(1, oOutletFeasibility.OutletFeasibilityID);

                    OutletFeasibilitys oOutletFeasibilitys = new OutletFeasibilitys();
                    oOutletFeasibilitys.OutletFeasibilityDetail(oOutletFeasibility.OutletFeasibilityID);
                    foreach (OutletFeasibilityDetail oItem in oOutletFeasibilitys)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvData);

                        oRow.Cells[0].Value = oItem.PG;
                        oRow.Cells[1].Value = oItem.Mag;
                        oRow.Cells[2].Value = oItem.Brand;
                        oRow.Cells[3].Value = oItem.YearNo.ToString();
                        oRow.Cells[4].Value = oItem.Quantity.ToString();
                        oRow.Cells[5].Value = oItem.ASP;
                        oRow.Cells[6].Value = oItem.Value.ToString();
                        oRow.Cells[7].Value = oItem.GMPercent.ToString();
                        oRow.Cells[8].Value = oItem.MAGID.ToString();
                        oRow.Cells[9].Value = oItem.BrandID.ToString();
                        oRow.Cells[10].Value = oItem.MCRate.ToString();
                        dgvData.Rows.Add(oRow);

                    }


                    foreach (DataGridViewRow oRow in dgvData.Rows)
                    {
                        oRow.Cells[0].ReadOnly = true;
                        oRow.Cells[0].Style.BackColor = Color.Silver;
                        oRow.Cells[1].ReadOnly = true;
                        oRow.Cells[1].Style.BackColor = Color.Silver;
                        oRow.Cells[2].ReadOnly = true;
                        oRow.Cells[2].Style.BackColor = Color.Silver;
                        oRow.Cells[3].ReadOnly = true;
                        oRow.Cells[3].Style.BackColor = Color.Silver;
                        oRow.Cells[4].ReadOnly = false;
                        oRow.Cells[5].ReadOnly = false;


                        oRow.Cells[6].ReadOnly = true;
                        oRow.Cells[6].Style.BackColor = Color.Silver;
                        oRow.Cells[7].ReadOnly = false;
                        oRow.Cells[8].ReadOnly = true;
                        oRow.Cells[8].Style.BackColor = Color.Silver;
                        oRow.Cells[9].ReadOnly = true;
                        // gaohor
                        if (Utility.Username == "gaohor")
                        {
                            oRow.Cells[10].ReadOnly = false;
                            oRow.Cells[10].Style.BackColor = Color.White;
                            oRow.Cells[7].ReadOnly = false;
                            oRow.Cells[7].Style.BackColor = Color.White;
                        }
                        else
                        {
                            oRow.Cells[10].ReadOnly = true;
                            oRow.Cells[10].Style.BackColor = Color.Silver;
                            oRow.Cells[7].ReadOnly = true;
                            oRow.Cells[7].Style.BackColor = Color.Silver;
                        }
                    }

                    LoadMAGList(1, oOutletFeasibility.OutletFeasibilityID);
                }
                else
                {
                    LoadMAGList(0, 0);
                }

            }
        }
    }
}
