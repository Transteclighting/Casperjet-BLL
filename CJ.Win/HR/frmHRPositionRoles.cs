using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRPositionRoles : Form
    {

        private HRPositionRoles _oHRPositionRoles;
        private HRPositionRole _oHRPositionRole;

        public frmHRPositionRoles()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _oHRPositionRoles = new HRPositionRoles();
            lvwHRPositionRole.Items.Clear();

            DBController.Instance.OpenNewConnection();
            int type = 2;

            _oHRPositionRoles.GetListData(txtRoleName.Text, type);

            foreach (HRPositionRole oHRPositionRole in _oHRPositionRoles)
            {
                ListViewItem oItem = lvwHRPositionRole.Items.Add(oHRPositionRole.Name.ToString());
                oItem.SubItems.Add(oHRPositionRole.IsActive.ToString());
                oItem.Tag = oHRPositionRole;
            }
            this.Text = "HR Position Role-" + _oHRPositionRoles.Count + "";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRPositionRole oForm = new frmHRPositionRole();
            oForm.ShowDialog();
            if (oForm._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwHRPositionRole.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPositionRole oHRPositionRole = (HRPositionRole)lvwHRPositionRole.SelectedItems[0].Tag;

            frmHRPositionRole ofrmHRPositionRole = new frmHRPositionRole();
            ofrmHRPositionRole.ShowDialog(oHRPositionRole);
            if (ofrmHRPositionRole._bActionSave)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHRPositionRoles_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwHRPositionRole.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPositionRole oHRPositionRole = (HRPositionRole)lvwHRPositionRole.SelectedItems[0].Tag;

            frmHRPositionRole ofrmHRPositionRole = new frmHRPositionRole();
            ofrmHRPositionRole.ShowDialog(oHRPositionRole);
            if (ofrmHRPositionRole._bActionSave)
                LoadData();
        }
    }
}
