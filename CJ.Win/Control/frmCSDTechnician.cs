
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Win.CSD;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win.Control
{
    public partial class frmCSDTechnician : Form
    {
        CSDTechnicians _oCSDTechnicians;
        public CSDTechnician _oCSDTechnician;
        WorkshopLocations _oWorkshopLocations;

        public frmCSDTechnician()
        {
            InitializeComponent();
        }

        private void frmCSDTechnician_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void DataLoadControlForThirdParty()
        {
            int nThirdPartyID = -1;
            if (ctlInterService1.txtDescription.Text != string.Empty)
            {
                nThirdPartyID = ctlInterService1.SelectedInterService.InterServiceID;
            }
            _oCSDTechnicians = new CSDTechnicians();
            lvwThirdParty.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nThanaID = -1;

            _oCSDTechnicians.GetData(nThanaID, txtTechCode.Text, txtTechName.Text, nThirdPartyID);

            this.Text = "CSD Technician = " + "[" + _oCSDTechnicians.Count + "]";
            foreach (CSDTechnician oCSDTechnician in _oCSDTechnicians)
            {
                ListViewItem oItem = lvwThirdParty.Items.Add(oCSDTechnician.Code);
                oItem.SubItems.Add(oCSDTechnician.Name);
                oItem.SubItems.Add(oCSDTechnician.ThirdPartyName);
                oItem.SubItems.Add(oCSDTechnician.WorkshopTypeName);
                oItem.SubItems.Add(oCSDTechnician.Address);
                oItem.SubItems.Add(oCSDTechnician.Phone);
                oItem.SubItems.Add(oCSDTechnician.Mobile);
                oItem.SubItems.Add(oCSDTechnician.ThanaName);
                oItem.SubItems.Add(oCSDTechnician.DistictName);
                oItem.Tag = oCSDTechnician;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        public bool ShowDialog(CSDTechnician oCSDTechnician)
        {
            _oCSDTechnician = oCSDTechnician;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

              

        private void lvwCSDJobs_DoubleClick_1(object sender, EventArgs e)
        {
            
        }

        private void btnGetThirdPartyTech_Click(object sender, EventArgs e)
        {
            DataLoadControlForThirdParty();
        }
        private void SelectThirdPartyTech()
        {
            if (lvwThirdParty.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _oCSDTechnician = (CSDTechnician)lvwThirdParty.SelectedItems[0].Tag;

            }
            this.Close();
        }
        private void SelectOwnTech()
        {
            if (lvwOwnTech.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _oCSDTechnician = (CSDTechnician)lvwOwnTech.SelectedItems[0].Tag;

            }
            this.Close();
        }
        private void lvwThirdParty_DoubleClick(object sender, EventArgs e)
        {
            SelectThirdPartyTech();
        }

        private void tbOwnTechnician_Click(object sender, EventArgs e)
        {

        }

        private void btnViewJobsInHand_Click(object sender, EventArgs e)
        {
            if (lvwThirdParty.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CSDTechnician oTechnician = (CSDTechnician)lvwThirdParty.SelectedItems[0].Tag;
                frmCSDtechnicianJobsInHand oForm = new frmCSDtechnicianJobsInHand(DateTime.Today.Date);
                oForm.ShowDialog(oTechnician);
            }
        }

        private void btnGetOwnTech_Click(object sender, EventArgs e)
        {
            DataLoadControlForOwnTech();
        }
        private void LoadCombos()
        {
            //Workshop Location

            _oWorkshopLocations = new WorkshopLocations();
            _oWorkshopLocations.RefreshForCombo();
            cmbWorkshopLocation.Items.Clear();
            cmbWorkshopLocation.Items.Add("--Select---");
            foreach (WorkshopLocation oWorkshopLocation in _oWorkshopLocations)
            {
                cmbWorkshopLocation.Items.Add(oWorkshopLocation.Name);
            }
            cmbWorkshopLocation.SelectedIndex = 0;
        }

        private void DataLoadControlForOwnTech()
        {
          
            _oCSDTechnicians = new CSDTechnicians();
            lvwThirdParty.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nWorkshopLocationID = 0;
            if (cmbWorkshopLocation.SelectedIndex != 0)
            {
                nWorkshopLocationID = _oWorkshopLocations[cmbWorkshopLocation.SelectedIndex - 1].WorkshopLocationID;
            }
            _oCSDTechnicians.GetOwnTechnician(txtOwnTechCodeSearch.Text, txtOwnTechNameSearch.Text, nWorkshopLocationID);

            this.Text = "CSD Technician = " + "[" + _oCSDTechnicians.Count + "]";
            foreach (CSDTechnician oCSDTechnician in _oCSDTechnicians)
            {
                ListViewItem oItem = lvwOwnTech.Items.Add(oCSDTechnician.Code);
                oItem.SubItems.Add(oCSDTechnician.Name);                
                oItem.SubItems.Add(oCSDTechnician.WorkshopTypeName);
                oItem.SubItems.Add(oCSDTechnician.WorkshopLocationName);
                oItem.Tag = oCSDTechnician;
            }
        }

        private void lvwOwnTech_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectOwnTech();
        }
        

    }

}