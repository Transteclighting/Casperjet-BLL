using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.BEIL
{
    public partial class frmLCMTargets : Form
    {
        bool IsCheck;
        LCMComponents _oLCMComponents;
        ProductGroups _AG;

        public frmLCMTargets()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLCMTarget oFrom = new frmLCMTarget();
            oFrom.ShowDialog();
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oLCMComponents = new LCMComponents();
            lvwLCMTarget.Items.Clear();
            int nAGID = 0;
            if (cmbAG.SelectedIndex == 0)
            {
                nAGID = -1;
            }
            else
            {
                nAGID = _AG[cmbAG.SelectedIndex - 1].PdtGroupID;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oLCMComponents.RefreshLCMTarget(dtFromdate.Value.Date, dtTodate.Value.Date, IsCheck, nAGID);
            DBController.Instance.CloseConnection();

            foreach (LCMComponent oLCMComponent in _oLCMComponents)
            {
                ListViewItem oItem = lvwLCMTarget.Items.Add(oLCMComponent.ID.ToString());
                oItem.SubItems.Add(oLCMComponent.AGName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oLCMComponent.CreateDate).ToString("dd-MMM-yyyy hh:mm tt"));
                oItem.SubItems.Add(Convert.ToInt32(oLCMComponent.TargetQty).ToString());

                oItem.Tag = oLCMComponent;
            }
            this.Text = "Total:[" + _oLCMComponents.Count + "]";
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
        private void LoadCombos()
        {

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            dtFromdate.Value = DateTime.Now.Date;
            dtTodate.Value = DateTime.Now.Date;

            //Load AG in combo
            _AG = new ProductGroups();
            _AG.GetHTVAG();
            cmbAG.Items.Clear();
            cmbAG.Items.Add("<ALL>");
            foreach (ProductGroup oProductGroup in _AG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmLCMTargets_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwLCMTarget.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LCMComponent oLCMComponent = (LCMComponent)lvwLCMTarget.SelectedItems[0].Tag;
            frmLCMTarget oForm = new frmLCMTarget();
            oForm.ShowDialog(oLCMComponent);
            DataLoadControl();

        }
    }
}