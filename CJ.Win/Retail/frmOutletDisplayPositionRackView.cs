using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Report;

namespace CJ.Win.Retail
{
    public partial class frmOutletDisplayPositionRackView : Form
    {
        SystemInfo oSystemInfo;
        OutletDisplayPositions _oOutletDisplayPositions;
        OutletDisplayPosition oOutletDisplayPosition;
        Showrooms _oShowrooms;
        Showroom oShowroom;
        OutletDisplayPositions _oOutletDisplayPositionRack;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;

        int nWHID=0;
        public frmOutletDisplayPositionRackView()
        {
            InitializeComponent();
        }

        private void frmOutletDisplayPositionRackView_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {           
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            
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

            //Showroom
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Add("--All --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbOutlet.SelectedIndex = 0;
     
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ViewOutletDisplayPositionRack();
        }
        private void ViewOutletDisplayPositionRack()
        {
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nPGID = -1;
            if (cmbPG.SelectedIndex > 0) nPGID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;

            int nMAGID = -1;
            if (cmbMAG.SelectedIndex > 0) nMAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;

            int nASGID = -1;
            if (cmbASG.SelectedIndex > 0) nASGID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;

            int nAGID = -1;
            if (cmbAG.SelectedIndex > 0) nAGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;

            int nOutlet = 0;
            if (cmbOutlet.SelectedIndex == 0)
            {
                nOutlet = -1;
            }
            else
            {
                nOutlet = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
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

            OutletDisplayPositions oOutletDisplayPositions = new OutletDisplayPositions();
            oOutletDisplayPositions.ViewOutletDisplayPositionRackHead(ctlProduct1.txtCode.Text, nPGID, nMAGID, nASGID, nAGID, nOutlet, nRackID);
            rptOutletDisplayPositionRack oReport = new rptOutletDisplayPositionRack();
            oReport.SetDataSource(oOutletDisplayPositions);
            oReport.SetParameterValue("CompanyName", Utility.CompanyName);
            //oSystemInfo = new SystemInfo();
            //oSystemInfo.Refresh();
            //if (cmbOutlet.Text != "")
            //    oReport.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            //else oReport.SetParameterValue("Outlet", "All");            
            oReport.SetParameterValue("Outlet", " ");
            oReport.SetParameterValue("ReportName", "Outlet Display Position");
            oReport.SetParameterValue("UserName", Utility.Username);
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
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
    }
}
