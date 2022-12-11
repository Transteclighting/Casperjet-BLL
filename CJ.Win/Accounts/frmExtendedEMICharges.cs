using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmExtendedEMICharges : Form
    {
        private EMIExtendedCharges _oEMIExtendedCharges;
        private EMIExtendedCharge _oEMIExtendedCharge;

        private EMITenures _oEMITenures;

        public frmExtendedEMICharges()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            _oEMIExtendedCharges = new EMIExtendedCharges();
            lvwExtendedEMICharge.Items.Clear();
            string emiTenure = null;

            DBController.Instance.OpenNewConnection();

            if (cmbTenure.SelectedIndex != 0)
            {
                emiTenure = _oEMITenures[cmbTenure.SelectedIndex - 1].Tenure.ToString();
            }

            _oEMIExtendedCharges.Refresh(emiTenure);

            foreach (EMIExtendedCharge oEMIExtendedCharge in _oEMIExtendedCharges)
            {
                ListViewItem oItem = lvwExtendedEMICharge.Items.Add(oEMIExtendedCharge.EMITenure.ToString());
                oItem.SubItems.Add(oEMIExtendedCharge.ChargePercent.ToString());
                oItem.SubItems.Add(oEMIExtendedCharge.BankName.ToString());
                oItem.Tag = oEMIExtendedCharge;
            }
            this.Text = "Extended EMI Charge List-" + _oEMIExtendedCharges.Count + "";

        }

        private void LoadCombo()
        {
            _oEMITenures = new EMITenures();

            DBController.Instance.OpenNewConnection();

            _oEMITenures.GetEMITenure();
            cmbTenure.Items.Add("ALL");
            foreach (EMITenure oEMITenure in _oEMITenures)
            {
                cmbTenure.Items.Add(oEMITenure.Tenure);
            }
            cmbTenure.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExtendedEMICharge oForm = new frmExtendedEMICharge();
            oForm.ShowDialog();
            if (oForm._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwExtendedEMICharge.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                EMIExtendedCharge oEMIExtendedCharge = (EMIExtendedCharge)lvwExtendedEMICharge.SelectedItems[0].Tag;

                frmExtendedEMICharge ofrmExtendedEMICharge = new frmExtendedEMICharge();
                ofrmExtendedEMICharge.ShowDialog(oEMIExtendedCharge);
                if (ofrmExtendedEMICharge._bActionSave)
                LoadData();

        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwExtendedEMICharge.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EMIExtendedCharge oEMIExtendedCharge = (EMIExtendedCharge)lvwExtendedEMICharge.SelectedItems[0].Tag;

            frmExtendedEMICharge ofrmExtendedEMICharge = new frmExtendedEMICharge();
            ofrmExtendedEMICharge.ShowDialog(oEMIExtendedCharge);
            if (ofrmExtendedEMICharge._bActionSave)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
               this.Close();
        }

        private void frmExtendedEMICharges_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
            LoadData();
        }
    }
}
