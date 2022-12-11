// <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana
// Date: May 5, 2014
// Description: Forms for Add/Edit of District/Thana.
// Modify Person And Date:
// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmShowrooms : Form
    {
        Showroom _oShowroom;
        Showrooms _oShowrooms;
        Showroom oShowroom;
        public frmShowrooms()
        {
           
            InitializeComponent();
            _oShowrooms = new Showrooms();
            _oShowroom = new Showroom();
        }
        private void LoadCombos()
        {           
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsActive)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.IsActive), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;

        }
        private void frmShowrooms_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCombos();
        }
        private void LoadData()
        {
            lvwShowrooms.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }

            _oShowrooms.GetShowroomByName(txtCode.Text, txtFind.Text);

            this.Text = "Showrooms " + "[" + _oShowrooms.Count + "]";


            foreach (Showroom oShowroom in _oShowrooms)
            {
                ListViewItem oItem = lvwShowrooms.Items.Add(oShowroom.ShowroomCode);
                oItem.SubItems.Add(oShowroom.ShowroomName);
                oItem.SubItems.Add(oShowroom.ShowroomAddress);
                oItem.SubItems.Add(oShowroom.MobileNo);
                oItem.SubItems.Add(oShowroom.WarehouseName);
                oItem.SubItems.Add(oShowroom.CustomerName);
                //  oItem.SubItems.Add(oGeoLocation.GeoLocationCategory.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ActiveOrInActiveStatus), oShowroom.IsActive));
                oItem.Tag = oShowroom;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmShowroom ofrmShowroom = new frmShowroom();
            ofrmShowroom.ShowDialog();
            LoadData();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwShowrooms.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Showroom to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oShowroom = (Showroom)lvwShowrooms.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Showromm: " + _oShowroom.ShowroomCode+ " ? ", "Confirm Showroom Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oShowroom.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwShowrooms.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Showroom Code to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oShowroom = (Showroom)lvwShowrooms.SelectedItems[0].Tag;
            frmShowroom oForm = new frmShowroom();
            oForm.ShowDialog(oShowroom);
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}