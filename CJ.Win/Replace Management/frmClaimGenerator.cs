using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Replace_Management
{
    public partial class frmClaimGenerator : Form
    {
        ProductGroups oProductGroups;

        public frmClaimGenerator()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool validateUIInput()
        {
            int nCount = 0;

            for (int i = 0; i < lvwMAG.Items.Count; i++)
            {
                ListViewItem itm = lvwMAG.Items[i];
                if (lvwMAG.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please select at least one sub claim no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    for (int i = 0; i < lvwMAG.Items.Count; i++)
                    {
                        ListViewItem itm = lvwMAG.Items[i];
                        if (lvwMAG.Items[i].Checked == true)
                        {
                            ProductGroup oProductGroup = (ProductGroup)lvwMAG.Items[i].Tag;
                            ReplaceClaim oReplaceClaim = new ReplaceClaim();
                            oReplaceClaim.ReplaceClaimNo = oProductGroup.ReplaceClaimNo;
                            oReplaceClaim.SubClaimNo = oProductGroup.SubClaimNumber;
                            oReplaceClaim.ClaimStatus = 0;
                            oReplaceClaim.InsertClaim();
                        }
                        
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Add Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
        public void Loadlvw()
        {
            DBController.Instance.OpenNewConnection();
            oProductGroups = new ProductGroups();
            oProductGroups.GetMAGForReplace(1, txtClaimNo.Text.Trim());
            lvwMAG.Items.Clear();
            foreach (ProductGroup oProductGroup in oProductGroups)
            {
                ListViewItem oItem = lvwMAG.Items.Add(oProductGroup.ReplaceClaimNo);
                oItem.SubItems.Add(oProductGroup.SubClaimNumber);
                oItem.Tag = oProductGroup;
            }
        }

        private void frmClaimGenerator_Load(object sender, EventArgs e)
        {
            txtClaimNo.Enabled = false;
            lvwExistingClaim.Enabled = false;
            Loadlvw();
        }

        private void chkPGAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPGAll.Checked == true)
            {
                for (int i = 0; i < lvwMAG.Items.Count; i++)
                {
                    lvwMAG.Items[i].Checked = true;
                }
                chkPGAll.Text = "Un-Check All";
            }
            else
            {
                for (int i = 0; i < lvwMAG.Items.Count; i++)
                {
                    lvwMAG.Items[i].Checked = false;
                }
                chkPGAll.Text = "Check All";
            }
        }

        private void rdoNewClaim_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNewClaim.Checked == true)
            {
                txtClaimNo.Enabled = false;
                lvwExistingClaim.Enabled = false;
                lvwExistingClaim.Items.Clear();
                lvwMAG.Items.Clear();
                txtClaimNo.Text = "";
                Loadlvw();
            }
            else
            {
                txtClaimNo.Enabled = true;
                lvwExistingClaim.Enabled = true;
                lvwExistingClaim.Items.Clear();
                lvwMAG.Items.Clear();
                txtClaimNo.Text = "";
            }
        }

        private void rdoExistingClaim_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExistingClaim.Checked == true)
            {
                txtClaimNo.Enabled = true;
                lvwExistingClaim.Enabled = true;
                lvwExistingClaim.Items.Clear();
                lvwMAG.Items.Clear();
                txtClaimNo.Text = "";

            }
            else
            {
                txtClaimNo.Enabled = false;
                lvwExistingClaim.Enabled = false;
                lvwExistingClaim.Items.Clear();
                lvwMAG.Items.Clear();
                txtClaimNo.Text = "";
                Loadlvw();
            }
        }

        private void txtClaimNo_TextChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            ReplaceClaims oReplaceClaims = new ReplaceClaims();
            oReplaceClaims.GetSubClaim(txtClaimNo.Text.Trim());
            lvwExistingClaim.Items.Clear();
            foreach (ReplaceClaim oReplaceClaim in oReplaceClaims)
            {
                ListViewItem oItem = lvwExistingClaim.Items.Add(oReplaceClaim.SubClaimNo);
                oItem.Tag = oReplaceClaim;
            }
            if (oReplaceClaims.Count > 0)
            {
                lvwExistingClaim.Enabled = false;
                oProductGroups = new ProductGroups();
                oProductGroups.GetMAGForReplace(2, txtClaimNo.Text.Trim());
                lvwMAG.Items.Clear();
                foreach (ProductGroup oProductGroup in oProductGroups)
                {
                    ListViewItem oItem = lvwMAG.Items.Add(oProductGroup.ReplaceClaimNo);
                    oItem.SubItems.Add(oProductGroup.SubClaimNumber);
                    oItem.Tag = oProductGroup;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}