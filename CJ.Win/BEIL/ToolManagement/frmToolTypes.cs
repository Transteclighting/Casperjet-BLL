using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.BEIL;
using CJ.Win.Security;

namespace CJ.Win.BEIL.ToolManagement
{
    public partial class frmToolTypes : Form
    {
        ToolTypes oToolTypes;
        private ToolTypes _oToolTypes;
        bool IsCheck = false;
        public frmToolTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string currentForm = "Add";

            frmToolType ofrmToolType = new frmToolType((int)Dictionary.ToolManagement.Create, currentForm);
            ofrmToolType.ShowDialog();
            if (ofrmToolType._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (lvwToolType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToolType _oToolType = (ToolType)lvwToolType.SelectedItems[0].Tag;
            string currentForm = "Edit";
            frmToolType ofrmToolType = new frmToolType((int)Dictionary.ToolManagement.Create, currentForm);

            ofrmToolType.ShowDialog(_oToolType);
            if (ofrmToolType._bActionSave)
                LoadData();

        }

        private void LoadData()
        {
            oToolTypes = new ToolTypes();
            lvwToolType.Items.Clear();

            DBController.Instance.OpenNewConnection();


            oToolTypes.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck);

            foreach (ToolType ooToolType in oToolTypes)
            {
                ListViewItem oItem = lvwToolType.Items.Add(ooToolType.ToolTypeID.ToString());
                oItem.SubItems.Add(ooToolType.ToolTypeName.ToString());
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ToolManagementStatus), ooToolType.Status));
                oItem.SubItems.Add(ooToolType.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.Tag = ooToolType;
            }
            this.Text = "Tool Type List-" + oToolTypes.Count + "";
            SetListViewRowColour();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SetListViewRowColour()
        {
            if (lvwToolType.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwToolType.Items)
                {
                    if (oItem.SubItems[2].Text == "Create")
                    {
                        oItem.BackColor = Color.Pink;
                    }
                    else
                    {
                        oItem.BackColor = Color.Transparent;
                    }

                }
            }
        }

        private void frmToolTypes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }
    }
}
