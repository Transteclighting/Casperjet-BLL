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
    public partial class frmBEILMaterialRequisitions : Form
    {

        BEILMaterialRequisitions _oBEILMaterialRequisitions;
        bool IsCheck;

        public frmBEILMaterialRequisitions()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBEILMaterialRequisition oFrom = new frmBEILMaterialRequisition((int)Dictionary.BEILMaterialRequisitionStatus.Create);
            oFrom.Show();
        }

        private void btnAuthorised_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BEILMaterialRequisition oBEILMaterialRequisition = (BEILMaterialRequisition)lvwStockList.SelectedItems[0].Tag;
            if (oBEILMaterialRequisition.Status == (int)Dictionary.BEILMaterialRequisitionStatus.Create)
            {
                frmBEILMaterialRequisition oForm = new frmBEILMaterialRequisition((int)Dictionary.BEILMaterialRequisitionStatus.Authorised);
                oForm.ShowDialog(oBEILMaterialRequisition);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Authorised.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BEILMaterialRequisition oBEILMaterialRequisition = (BEILMaterialRequisition)lvwStockList.SelectedItems[0].Tag;
            if (oBEILMaterialRequisition.Status == (int)Dictionary.BEILMaterialRequisitionStatus.Authorised)
            {
                frmBEILMaterialRequisition oForm = new frmBEILMaterialRequisition((int)Dictionary.BEILMaterialRequisitionStatus.Approved);
                oForm.ShowDialog(oBEILMaterialRequisition);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BEILMaterialRequisition oBEILMaterialRequisition = (BEILMaterialRequisition)lvwStockList.SelectedItems[0].Tag;
            if (oBEILMaterialRequisition.Status == (int)Dictionary.BEILMaterialRequisitionStatus.Approved)
            {
                frmBEILMaterialRequisition oForm = new frmBEILMaterialRequisition((int)Dictionary.BEILMaterialRequisitionStatus.Issued);
                oForm.ShowDialog(oBEILMaterialRequisition);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Issued.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BEILMaterialRequisition oBEILMaterialRequisition = (BEILMaterialRequisition)lvwStockList.SelectedItems[0].Tag;
            if (oBEILMaterialRequisition.Status == (int)Dictionary.BEILMaterialRequisitionStatus.Issued)
            {
                frmBEILMaterialRequisition oForm = new frmBEILMaterialRequisition((int)Dictionary.BEILMaterialRequisitionStatus.Received);
                oForm.ShowDialog(oBEILMaterialRequisition);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Received.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void SetListViewRowColour()
        {
            if (lvwStockList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwStockList.Items)
                {
                    if (oItem.SubItems[4].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[4].Text == "Authorised")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[4].Text == "Approved")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[4].Text == "Issued")
                    {
                        oItem.BackColor = Color.LightSkyBlue;

                    }

                    else
                    {
                        oItem.BackColor = Color.Green;
                    }

                }
            }
        }

        private void LoadCombos()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            // Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.BEILMaterialRequisitionStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.BEILMaterialRequisitionStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void DataLoadControl()
        {
            _oBEILMaterialRequisitions = new BEILMaterialRequisitions();
            lvwStockList.Items.Clear();

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oBEILMaterialRequisitions.GetData(dtFromdate.Value.Date, dtTodate.Value.Date, txtTranNo.Text.Trim(), nStatus, IsCheck);
            DBController.Instance.CloseConnection();

            foreach (BEILMaterialRequisition oBEILMaterialRequisition in _oBEILMaterialRequisitions)
            {
                ListViewItem oItem = lvwStockList.Items.Add(oBEILMaterialRequisition.RequisitionNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oBEILMaterialRequisition.RequisitionDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SCMBOMStockLocation), oBEILMaterialRequisition.FromLocation));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SCMBOMStockLocation), oBEILMaterialRequisition.ToLocation));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.BEILMaterialRequisitionStatus), oBEILMaterialRequisition.Status));
                oItem.SubItems.Add(oBEILMaterialRequisition.Remarks.ToString());

                oItem.Tag = oBEILMaterialRequisition;
            }
            this.Text = "Material Requisitions [" + _oBEILMaterialRequisitions.Count + "]";
            SetListViewRowColour();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
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

        private void frmBEILMaterialRequisitions_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}