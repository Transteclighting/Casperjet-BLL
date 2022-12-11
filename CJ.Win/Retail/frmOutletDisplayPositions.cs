using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;


namespace CJ.Win.Retail
{
    public partial class frmOutletDisplayPositions : Form
    {
        bool IsCheck = false;
        OutletDisplayPositions _oOutletDisplayPositions;
        OutletDisplayPosition oOutletDisplayPosition;
        Showrooms _oShowrooms;

        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        Brands _oBrands;
        MarketGroups _oMarketGroupArea;
        MarketGroups _oMarketGroupTerritory;
        GeoLocations _oGeoLocationDistrict;
        GeoLocations _oGeoLocationsThana;
        OutletDisplayPositions _oOutletDisplayPositionRack;
        public frmOutletDisplayPositions()
        {
            InitializeComponent();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            frmOutletDisplayPosition oFrom = new frmOutletDisplayPosition();
            oFrom.ShowDialog();
            if (oFrom._Istrue == true)
                DataLoadControl();
        }
        private void SetListViewRowColour()
        {
            if (lvwOutletDisplayPositions.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOutletDisplayPositions.Items)
                {
                    if (oItem.SubItems[18].Text == "Fill")
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


            //Showroom
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Add("--All --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbOutlet.SelectedIndex = 0;

            /*************Market Area***********/
            _oMarketGroupArea = new MarketGroups();
            cmbArea.Items.Clear();
            _oMarketGroupArea.GetMarketGroupForTD((int)Dictionary.MarketGroupType.Area);
            cmbArea.Items.Add("<All>");
            foreach (MarketGroup oMarketGroup in _oMarketGroupArea)
            {
                cmbArea.Items.Add(oMarketGroup.MarketGroupDesc);
            }
            cmbArea.SelectedIndex = 0;

            /*************Market Territory***********/
            _oMarketGroupTerritory = new MarketGroups();
            cmbTerritory.Items.Clear();
            _oMarketGroupTerritory.GetMarketGroupForTD((int)Dictionary.MarketGroupType.Territory);
            cmbTerritory.Items.Add("<All>");
            foreach (MarketGroup oMarketGroup in _oMarketGroupTerritory)
            {
                cmbTerritory.Items.Add(oMarketGroup.MarketGroupDesc);
            }
            cmbTerritory.SelectedIndex = 0;



            ///Thana
            _oGeoLocationsThana = new GeoLocations();
            _oGeoLocationsThana.Refresh((int)Dictionary.GeoLocationType.Thana);
            cmbThana.Items.Clear();
            cmbThana.Items.Add("<All>");
            foreach (GeoLocation oGeoLocation in _oGeoLocationsThana)
            {
                cmbThana.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbThana.SelectedIndex = 0;

            /*********Select District***********/
            _oGeoLocationDistrict = new GeoLocations();
            cmbDistrict.Items.Clear();
            cmbDistrict.Items.Add("<All>");
            _oGeoLocationDistrict.Refresh((int)Dictionary.GeoLocationType.District);
            foreach (GeoLocation oGeoLocation in _oGeoLocationDistrict)
            {
                cmbDistrict.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;


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
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
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

            int nProductID = 0;
            if (ctlProduct1.txtCode.Text == "")
            {
                nProductID = -1;
            }
            else
            {
                nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
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

            int nOutlet = 0;
            if (cmbOutlet.SelectedIndex == 0)
            {
                nOutlet = -1;
            }
            else
            {
                nOutlet = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
            }
            int nArea = 0;
            if (cmbArea.SelectedIndex == 0)
            {
                nArea = -1;
            }
            else
            {
                nArea = _oMarketGroupArea[cmbArea.SelectedIndex - 1].MarketGroupID;
            }
            int nDistrict = 0;
            if (cmbDistrict.SelectedIndex == 0)
            {
                nDistrict = -1;
            }
            else
            {
                nDistrict = _oGeoLocationDistrict[cmbDistrict.SelectedIndex - 1].GeoLocationID;
            }

            int nTerritory = 0;
            if (cmbTerritory.SelectedIndex == 0)
            {
                nTerritory = -1;
            }
            else
            {
                nTerritory = _oMarketGroupTerritory[cmbTerritory.SelectedIndex - 1].MarketGroupID;
            }
            int nThana = 0;
            if (cmbThana.SelectedIndex == 0)
            {
                nThana = -1;
            }
            else
            {
                nThana = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
            }
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
            _oOutletDisplayPositions.RefreshDataHO(dtFromdate.Value.Date, dtTodate.Value.Date, txtPositionCode.Text, txtPositionName.Text, txtProductModel.Text, nIsActive, nStatus, nBrandID, nPGID, nMAGID, nASGID, nAGID, nArea, nTerritory, nDistrict, nThana, nOutlet, nProductID, IsCheck, nRackID, bOpenForAll);
            DBController.Instance.CloseConnection();
            foreach (OutletDisplayPosition oOutletDisplayPosition in _oOutletDisplayPositions)
            {
                ListViewItem oItem = lvwOutletDisplayPositions.Items.Add(oOutletDisplayPosition.ShowroomCode.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.AreaName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.TerritoryName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ThanaName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.DistrictName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.PositionCode.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.PositionName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oOutletDisplayPosition.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oOutletDisplayPosition.RackName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ProductCode.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ProductName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ProductModel.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.AGName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ASGName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.MAGName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.PGName.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.BrandDesc.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.ProductSerialNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.DisplayPositionStatus), oOutletDisplayPosition.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oOutletDisplayPosition.IsActive));
                oItem.SubItems.Add(oOutletDisplayPosition.AssignProductDetail.ToString());
                oItem.SubItems.Add(oOutletDisplayPosition.OpenForAll.ToString());
                oItem.Tag = oOutletDisplayPosition;
            }
            this.Text = "Outlet Display Position List: " + _oOutletDisplayPositions.Count + "";
            SetListViewRowColour();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwOutletDisplayPositions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OutletDisplayPosition oOutletDisplayPosition = (OutletDisplayPosition)lvwOutletDisplayPositions.SelectedItems[0].Tag;
            //if (oOutletDisplayPosition.Status == (int)Dictionary.DisplayPositionStatus.NotFill)
            //{
            frmOutletDisplayPosition oForm = new frmOutletDisplayPosition();
            oForm.ShowDialog(oOutletDisplayPosition);
            if (oForm._Istrue == true)
                DataLoadControl();
            //}
        }

        private void frmOutletDisplayPositions_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
             this.Close();
            //MessageBoxWithDetails oform = new MessageBoxWithDetails("Test Data","Test Form1","Error");
            //oform.ShowDialog();
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

        private void btnView_Click(object sender, EventArgs e)
        {
            frmOutletDisplayPositionRackView oFrom = new frmOutletDisplayPositionRackView();
            oFrom.ShowDialog();

            //if (oFrom._Istrue == true)
            //    DataLoadControl();
        }
    }
}