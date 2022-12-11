using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;


namespace CJ.Win.CSD.Reception
{
    public partial class frmCSDJobAssign : Form
    {
        public CSDTechnician _oCSDTechnician;
        CSDTechnicians _oCSDTechnicians;
        WorkshopLocations _oWorkshopLocations;
        //public int nTechID;
        //public string sTechName;
        //public int nTechType;
        DateTime _dFormDate;
        public frmCSDJobAssign(DateTime dFormDate)
        {
            InitializeComponent();
            _dFormDate = dFormDate;
        }
        public void ShowDialog(int nThanaID)
        {
            this.Tag = nThanaID;
            this.ShowDialog();
        }
        private void frmCSDJobAssign_Load(object sender, EventArgs e)
        {
            rdoSuggested.Checked = true;
            LoadCombos();
        }
        private void DataLoadControlForThirdParty()
        {
            int nThanaID;
            if (rdoSuggested.Checked)
            {
                nThanaID = (int)this.Tag;
            }
            else
            {
                nThanaID = -1;
            }
            string sTechCode = txtTechCode.Text;
            string sTechName = txtTechName.Text;
            int nThirdpartyID = -1;
            if (ctlInterService1.txtDescription.Text != string.Empty)
            {
                nThirdpartyID = ctlInterService1.SelectedInterService.InterServiceID;
            }


            DBController.Instance.OpenNewConnection();
            _oCSDTechnicians = new CSDTechnicians();
            lvwThirdParty.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCSDTechnicians.GetData(nThanaID, sTechCode, sTechName, nThirdpartyID);
            this.Text = "CSD Third Party Technician| Total: " + "[" + _oCSDTechnicians.Count + "]";
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

        private void tbThirdPartyTech_Click(object sender, EventArgs e)
        {

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControlForThirdParty();
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
        
        public void DataLoadControlForOwnTech()
        {
            DBController.Instance.OpenNewConnection();
            _oCSDTechnicians = new CSDTechnicians();
            lvwOwnTech.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nWorkshopLocationID = 0;
            if (cmbWorkshopLocation.SelectedIndex != 0)
            {
                nWorkshopLocationID = _oWorkshopLocations[cmbWorkshopLocation.SelectedIndex - 1].WorkshopLocationID;
            }
            _oCSDTechnicians.GetOwnTechnician(txtOwnTechCodeSearch.Text.Trim(), txtOwnTechNameSearch.Text.Trim(), nWorkshopLocationID);
            this.Text = "CSD Own Technician| Total: " + "[" + _oCSDTechnicians.Count + "]";
            foreach (CSDTechnician oCSDTechnician in _oCSDTechnicians)
            {
                ListViewItem oItem = lvwOwnTech.Items.Add(oCSDTechnician.Code);
                oItem.SubItems.Add(oCSDTechnician.Name);
                oItem.SubItems.Add(oCSDTechnician.WorkshopTypeName);
                oItem.SubItems.Add(oCSDTechnician.WorkshopLocationName);
                oItem.Tag = oCSDTechnician;
            }
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
                CSDTechnician oCSDTechnician = (CSDTechnician)lvwThirdParty.SelectedItems[0].Tag;
                //nTechID = oCSDTechnician.TechnicianID;
                //sTechName = oCSDTechnician.Name;
                //nTechType = oCSDTechnician.Type;
                _oCSDTechnician = new CSDTechnician();
                _oCSDTechnician = oCSDTechnician;

            }
            this.Close();
        }

        private void lvwThirdParty_DoubleClick(object sender, EventArgs e)
        {
            SelectThirdPartyTech();
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
                frmCSDtechnicianJobsInHand oForm = new frmCSDtechnicianJobsInHand(_dFormDate);
                oForm.ShowDialog(oTechnician);
            }
        }

        private void btnViewJob_OwnTech_Click(object sender, EventArgs e)
        {
            if (lvwOwnTech.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CSDTechnician oTechnician = (CSDTechnician)lvwOwnTech.SelectedItems[0].Tag;
                _oCSDTechnician = new CSDTechnician();
                _oCSDTechnician = oTechnician;
                frmCSDtechnicianJobsInHand oForm = new frmCSDtechnicianJobsInHand(_dFormDate);
                oForm.ShowDialog(oTechnician);
            }
        }

        private void lvwOwnTech_DoubleClick(object sender, EventArgs e)
        {
            SelectOwnTech();
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

                CSDTechnician oCSDTechnician = (CSDTechnician)lvwOwnTech.SelectedItems[0].Tag;
                _oCSDTechnician = new CSDTechnician();
                _oCSDTechnician = oCSDTechnician;
            }
            this.Close();
        }

        private void tbOwnTechnician_Click(object sender, EventArgs e)
        {

        }

        private void lvwOwnTech_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ctlInterService1_Load(object sender, EventArgs e)
        {

        }


    }
}