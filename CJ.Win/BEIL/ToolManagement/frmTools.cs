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
    public partial class frmTools : Form
    {
        Tools oTools;
        private Tools _oTools;
        private ToolTypes _oToolTypes;
        bool IsCheck = false;

        public frmTools()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadCombo()
        {
            _oToolTypes = new ToolTypes();

            DBController.Instance.OpenNewConnection();

            _oToolTypes.GetToolType();
            cmbToolType.Items.Add("-- Select --");
            foreach (ToolType oToolType in _oToolTypes)
            {
                cmbToolType.Items.Add(oToolType.ToolTypeName);
            }
            cmbToolType.SelectedIndex = 0;
        }

        private void LoadData()
        {
            oTools = new Tools();
            lvwTool.Items.Clear();

            DBController.Instance.OpenNewConnection();

            int toolTypeID = 0;

            if (cmbToolType.SelectedIndex == 0)
            {
                toolTypeID = -1;
            }
            else
            {
                toolTypeID = _oToolTypes[cmbToolType.SelectedIndex - 1].ToolTypeID;
            }

            oTools.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck, toolTypeID);

            foreach (Tool ooTool in oTools)
            {
                ListViewItem oItem = lvwTool.Items.Add(ooTool.ToolCode.ToString());
                oItem.SubItems.Add(ooTool.ToolName.ToString());
                oItem.SubItems.Add(ooTool.ToolTypeName.ToString());
                oItem.SubItems.Add(ooTool.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.Tag = ooTool;
            }
            this.Text = "Tool List-" + oTools.Count + "";
            SetListViewRowColour();
        }


        private void SetListViewRowColour()
        {
            if (lvwTool.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwTool.Items)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwTool.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tool _oTool = (Tool)lvwTool.SelectedItems[0].Tag;
            string currentForm = "Edit";
            frmTool ofrmTool = new frmTool((int)Dictionary.ToolManagement.Create, currentForm);

            ofrmTool.ShowDialog(_oTool);
            if (ofrmTool._bActionSave)
                LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string currentForm = "Add";

            frmTool ofrmTool = new frmTool((int)Dictionary.ToolManagement.Create, currentForm);
            ofrmTool.ShowDialog();
            if (ofrmTool._bActionSave)
                LoadData();
        }

        private void frmTools_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadData();
        }
    }
}
