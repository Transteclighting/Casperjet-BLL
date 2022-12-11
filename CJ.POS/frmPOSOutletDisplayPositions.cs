using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Report.POS;

namespace CJ.POS
{
    public partial class frmPOSOutletDisplayPositions : Form
    {
        bool IsCheck = false;

        OutletDisplayPositions _oOutletDisplayPositions;
        OutletDisplayPosition oOutletDisplayPosition;
        Showrooms _oShowrooms;
        int nDisplayPositionID;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        Brands _oBrands;
        OutletDisplayPositions _oOutletDisplayPositionRack;
        public frmPOSOutletDisplayPositions()
        {
            InitializeComponent();
        }

        private void LoadCombo()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            //IsActive
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsActive)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.IsActive), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;


            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DisplayPositionStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.DisplayPositionStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //Load PG in combo
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;

            //Load Brand in combo
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);

            //Removing the [ALL] in the Brand Object ??!!
            _oBrands.RemoveAt(_oBrands.Count - 1);
            //
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;


            _oOutletDisplayPositionRack = new OutletDisplayPositions();
            _oOutletDisplayPositionRack.RefreshRack();
            cmbRackName.Items.Clear();
            cmbRackName.Items.Add("<All>");
            foreach (OutletDisplayPosition oOutletDisplayPositionRack in _oOutletDisplayPositionRack)
            {
                cmbRackName.Items.Add(oOutletDisplayPositionRack.RackName);
            }
            cmbRackName.SelectedIndex = 0;

        }
        private void SetListViewRowColour()
        {
            if (lvwOutletDisplayPositions.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOutletDisplayPositions.Items)
                {
                    if (oItem.SubItems[15].Text == "Fill")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }

                }
            }
        }
        private void DataLoadControl()
        {
            _oOutletDisplayPositions = new OutletDisplayPositions();
            lvwOutletDisplayPositions.Items.Clear();

            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }

            int nPGID = -1;
            if (cmbPG.SelectedIndex > 0) nPGID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;

            int nMAGID = -1;
            if (cmbMAG.SelectedIndex > 0) nMAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;

            int nASGID = -1;
            if (cmbASG.SelectedIndex > 0) nASGID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;

            int nAGID = -1;
            if (cmbAG.SelectedIndex > 0) nAGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;

            int nBrandID = -1;
            if (cmbBrand.SelectedIndex > 0) nBrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;

            int nRackID = 0;
            if (cmbRackName.SelectedIndex == 0)
            {
                nRackID = -1;
            }
            else
            {
                nRackID = _oOutletDisplayPositionRack[cmbRackName.SelectedIndex - 1].RackID;
            }

            bool bOpenForAll = false;
            if (cbOpenForAll.Checked)
            {
                bOpenForAll = true;
            }
            else
            {
                bOpenForAll = false;
            }

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oOutletDisplayPositions.RefreshDataPOSNew(dtFromdate.Value.Date, dtTodate.Value.Date, txtPositionCode.Text.Trim(), txtPositionName.Text.Trim(),txtProductModel.Text,nIsActive, nStatus,nBrandID,nPGID,nMAGID,nASGID,nAGID,txtForProduct.Text,txtAssignProduct.Text, IsCheck, nRackID, bOpenForAll);
            DBController.Instance.CloseConnection();

            foreach (OutletDisplayPosition oOutletDisplayPosition in _oOutletDisplayPositions)
            {
                ListViewItem oItem = lvwOutletDisplayPositions.Items.Add(oOutletDisplayPosition.ShowroomCode.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.PositionCode.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.PositionName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.RackName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ForProductDetail.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.AssignProductDetail.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ProductModel.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.AGName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ASGName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.MAGName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.PGName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.BrandDesc.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ProductSerialNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oOutletDisplayPosition.CreateDate).ToString("dd-MMM-yyyy"));
                if (oOutletDisplayPosition.AssignDate != null)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oOutletDisplayPosition.AssignDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.DisplayPositionStatus), oOutletDisplayPosition.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oOutletDisplayPosition.IsActive));
                oItem.SubItems.Add(oOutletDisplayPosition.OpenForAll.ToString());
                oItem.Tag = oOutletDisplayPosition;
            }
            SetListViewRowColour();
            this.Text = "Outlet Display Positions [" + _oOutletDisplayPositions.Count + "]";
        }
        private void btnADD_Click(object sender, EventArgs e)
        {
            if (lvwOutletDisplayPositions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Add.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OutletDisplayPosition oOutletDisplayPosition = (OutletDisplayPosition)lvwOutletDisplayPositions.SelectedItems[0].Tag;
            if (oOutletDisplayPosition.IsActive == (int)Dictionary.IsActive.Active)
            {
                frmPOSOutletDisplayPosition oForm = new frmPOSOutletDisplayPosition();
                oForm.ShowDialog(oOutletDisplayPosition);
                if (oForm._IsTrue == true)
                    DataLoadControl();
            }
            else
            {
                MessageBox.Show("InActive Display Position.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;

        }

        private void frmPOSOutletDisplayPositions_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwOutletDisplayPositions_DoubleClick(object sender, EventArgs e)
        {
            btnADD_Click(sender, e);
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbMAG.SelectedIndex == 0)
            {
                _oASG = null;
                cmbASG.Items.Clear();
                cmbASG.Items.Add("<All>");
                cmbASG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
            //Load ASG in combo
            _oASG = new ProductGroups();
            _oASG.Refresh(nParentID);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }

            cmbASG.SelectedIndex = 0;
        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbPG.SelectedIndex == 0)
            {
                _oMAG = null;
                cmbMAG.Items.Clear();
                cmbMAG.Items.Add("<All>");
                cmbMAG.SelectedIndex = 0;
                return;
            }
            int nParentID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;
            //Load MAG in combo
            _oMAG = new ProductGroups();
            _oMAG.Refresh(nParentID);
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;
        }

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbASG.SelectedIndex == 0)
            {
                _oAG = null;
                cmbAG.Items.Clear();
                cmbAG.Items.Add("<All>");
                cmbAG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;
            //Load AG in combo
            _oAG = new ProductGroups();
            _oAG.Refresh(nParentID);
            cmbAG.Items.Clear();
            cmbAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.SelectedIndex = 0;
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            frmOutletDisplayPositionRackView oFrom = new frmOutletDisplayPositionRackView();
            oFrom.ShowDialog();
        }
    }
}