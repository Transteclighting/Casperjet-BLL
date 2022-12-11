using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.Accounts;
using CJ.Class;

namespace CJ.Win.Accounts
{
    public partial class frmEMITenures : Form
    {
        EMITenures oEMITenures;
        private EMITenures _oEMITenures;

        public frmEMITenures()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            oEMITenures = new EMITenures();
            lvwEMITenure.Items.Clear();

            string emiTenure = null;

            DBController.Instance.OpenNewConnection();
            if (cmbTenure.SelectedIndex != 0)
            {
                emiTenure = _oEMITenures[cmbTenure.SelectedIndex - 1].Tenure.ToString();
            }

            oEMITenures.Refresh(emiTenure);

            foreach (EMITenure oEMITenure in oEMITenures)
            {
                ListViewItem oItem = lvwEMITenure.Items.Add(oEMITenure.EMITenureID.ToString());
                oItem.SubItems.Add(oEMITenure.Tenure.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.EMITenureStatus), oEMITenure.Status));
                oItem.SubItems.Add(oEMITenure.CreateUserName.ToString());
                oItem.SubItems.Add(oEMITenure.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.Tag = oEMITenure;
            }
            this.Text = "EMI Tenure List-" + oEMITenures.Count + "";
            SetListViewRowColour();
        }

        private void LoadCombo()
        {
            _oEMITenures = new EMITenures();

            DBController.Instance.OpenNewConnection();

            _oEMITenures.GetEMITenure();
            cmbTenure.Items.Add("All");
            foreach (EMITenure oEMITenure in _oEMITenures)
            {
                cmbTenure.Items.Add(oEMITenure.Tenure);
            }
            cmbTenure.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEMITenure ofrmEMITenure = new frmEMITenure();
            ofrmEMITenure.Text = "Add EMI Tenure";
            ofrmEMITenure.ShowDialog();
            if (ofrmEMITenure._bActionSave)
                LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwEMITenure.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (lvwEMITenure.SelectedItems[0].SubItems[2].Text == "Approved")
            //{
            //    MessageBox.Show("Cann't approve as it has already approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            EMITenure oEMITenure = (EMITenure)lvwEMITenure.SelectedItems[0].Tag;
            if (oEMITenure.Status == ((int)Dictionary.EMITenureStatus.Create))
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Approved status can't be approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmEMITenure ofrmEMITenure = new frmEMITenure();
            ofrmEMITenure.Text = "Approve EMI Tenure";
            ofrmEMITenure.ShowDialog(oEMITenure);
            if (ofrmEMITenure._bActionSave)
                LoadData();

        }

        private void SetListViewRowColour()
        {
            if (lvwEMITenure.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwEMITenure.Items)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void frmEMITenures_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
            LoadData();
        }
    }
}
