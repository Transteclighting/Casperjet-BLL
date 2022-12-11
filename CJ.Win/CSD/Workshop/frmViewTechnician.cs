using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;


namespace CJ.Win.CSD.Workshop
{
    public partial class frmViewTechnician : Form
    {
        public int nTechnicianID;

        Technicians _oTechnicians;
        Technician _oTechnician;
        Workshops _oWorkshops;

        public frmViewTechnician()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmViewTechnician_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            int nTechnicianID = 0;
            _oTechnicians = new Technicians();
            lvwTechnicians.Items.Clear();
            DBController.Instance.OpenNewConnection();

            if (cmbWorkshop.SelectedIndex > 0)
            {
               nTechnicianID = _oWorkshops[cmbWorkshop.SelectedIndex - 1].WorkshopTypeID;
            }

            _oTechnicians.GetTechnicianByWorkshop(nTechnicianID);

            foreach (Technician oTechnician in _oTechnicians)
            {
                ListViewItem oItem = lvwTechnicians.Items.Add(oTechnician.Code);
                oItem.SubItems.Add(oTechnician.Name);
                oItem.SubItems.Add(oTechnician.Workshop.Name);
                oItem.Tag = oTechnician;
            }

            this.Text = "Total " + lvwTechnicians.Items.Count.ToString();

            if (lvwTechnicians.Items.Count > 0)
            {
                lvwTechnicians.Items[0].Selected = true;
                lvwTechnicians.Focus();
            }
        }
        private void ReturnSelectedTechnician()
        {
            foreach (ListViewItem oItem in lvwTechnicians.SelectedItems)
            {
                _oTechnician = new Technician();
                _oTechnician = (Technician)lvwTechnicians.SelectedItems[0].Tag;
                nTechnicianID = _oTechnician.TechnicianID;

            }

        }

        private void lvwTechnicians_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ReturnSelectedTechnician();
                this.Close();
            }
        }

        private void lvwTechnicians_DoubleClick(object sender, EventArgs e)
        {
            ReturnSelectedTechnician();
            this.Close();
        }
        private void LoadCombo()
        {
            _oWorkshops = new Workshops();
            _oWorkshops.Refresh();

            cmbWorkshop.Items.Clear();
            cmbWorkshop.Items.Add("All");
            foreach (CJ.Class.Workshop oWorkshop in _oWorkshops)
            {
                cmbWorkshop.Items.Add(oWorkshop.Name);
            }
            cmbWorkshop.SelectedIndex = 0;
        }
    }
}