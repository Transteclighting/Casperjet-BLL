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
    public partial class frmLCMTarget : Form
    {
        ProductGroups _oAG;
        LCMComponent oLCMComponent;
        int nID = 0;
        public frmLCMTarget()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(LCMComponent oLCMComponent)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oLCMComponent;
            LoadCombos();
            nID = 0;
            nID = oLCMComponent.ID;
            int nAG = 0;
            nAG = _oAG.GetIndex(oLCMComponent.AGID);
            cmbAG.SelectedIndex = nAG + 1;
            txtTargetQty.Text = oLCMComponent.TargetQty.ToString();
            dtTargetDate.Value = oLCMComponent.CreateDate.Date;
            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            oLCMComponent = new LCMComponent();
            oLCMComponent.AGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;
            oLCMComponent.CreateDate = dtTargetDate.Value.Date;
            oLCMComponent.TargetQty = Convert.ToInt32(txtTargetQty.Text);
            try
            {
                DBController.Instance.BeginNewTransaction();
                if (this.Tag == null)
                {
                    oLCMComponent.AddLCMTarget();
                }
                else
                {
                    oLCMComponent.ID = nID;
                    oLCMComponent.EditLCMTarget();
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add LCM Production Target Qty", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private bool validateUIInput()
        {

            if (cmbAG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an agname", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAG.Focus();
                return false;
            }
            return true;
        }


        private void frmLCMTarget_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
                this.Text = "Add LCM Production Target";
            }
            else
            {
                this.Text = "Edit LCM Production Target";
            }
        }
        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            dtTargetDate.Value = DateTime.Today;
            //AG Name
            _oAG = new ProductGroups();
            _oAG.Refresh(48);
            cmbAG.Items.Clear();
            cmbAG.Items.Add("<Select AG Name>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.SelectedIndex = 0;
        }
    }
}