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
    public partial class frmHRPositionRoleTypes : Form
    {
        private HRPositionRoles _oHRPositionRoles;
        private HRPositionRole _oHRPositionRole;

        public frmHRPositionRoleTypes()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            _oHRPositionRoles = new HRPositionRoles();
            lvwHRPositionRoleType.Items.Clear();

            DBController.Instance.OpenNewConnection();

            int type = 1;

            _oHRPositionRoles.GetListData(txtRoleTypeName.Text, type);

            foreach (HRPositionRole oHRPositionRole in _oHRPositionRoles)
            {
                ListViewItem oItem = lvwHRPositionRoleType.Items.Add(oHRPositionRole.Name.ToString());
                oItem.SubItems.Add(oHRPositionRole.IsActive.ToString());
                oItem.Tag = oHRPositionRole;
            }
            this.Text = "HR Position Role-" + _oHRPositionRoles.Count + "";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRPositionRoleType oForm = new frmHRPositionRoleType();
            oForm.ShowDialog();
            if (oForm._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwHRPositionRoleType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPositionRole oHRPositionRole = (HRPositionRole)lvwHRPositionRoleType.SelectedItems[0].Tag;

            frmHRPositionRoleType ofrmHRPositionRole = new frmHRPositionRoleType();
            ofrmHRPositionRole.ShowDialog(oHRPositionRole);
            if (ofrmHRPositionRole._bActionSave)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwHRPositionRoleType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPositionRole oHRPositionRole = (HRPositionRole)lvwHRPositionRoleType.SelectedItems[0].Tag;

            frmHRPositionRoleType ofrmHRPositionRole = new frmHRPositionRoleType();
            ofrmHRPositionRole.ShowDialog(oHRPositionRole);
            if (ofrmHRPositionRole._bActionSave)
                LoadData();
        }

        private void frmHRPositionRoleTypes_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
