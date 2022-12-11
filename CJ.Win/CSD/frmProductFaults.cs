using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmProductFaults : Form
    {
        ProductFaults _oProductFaults;
        ProductFaults _oProductFaultsForCmb;
        public frmProductFaults()
        {
            InitializeComponent();
        }

        private void frmProductFaults_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oProductFaults = new ProductFaults();
            DBController.Instance.OpenNewConnection();
            int nParentFaultID = 0;
            if(cmbParentFault.SelectedIndex != 0)
            {
                nParentFaultID =_oProductFaultsForCmb[cmbParentFault.SelectedIndex - 1].FaultID;
            }
            _oProductFaults.RefreshAll(txtFaultDescription.Text.Trim(), nParentFaultID);
            this.Text = "Product Faults | Total: " + "[" + _oProductFaults.Count + "]";
            lvwProductFaults.Items.Clear();
            foreach (ProductFault oProductFault in _oProductFaults)
            {
                ListViewItem oItem = lvwProductFaults.Items.Add(oProductFault.FaultDescription);
                if (oProductFault.FaultLevel == 1)
                {
                    oItem.SubItems.Add("Parent");
                }
                else
                {
                    oItem.SubItems.Add("Sub");
                }
                if (oProductFault.ParentFaultName != string.Empty)
                {
                    oItem.SubItems.Add(oProductFault.ParentFaultName);
                }
                else
                {
                    oItem.SubItems.Add("None");
                }

                oItem.SubItems.Add(oProductFault.CreateUserName);
                oItem.Tag = oProductFault;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductFault oForm = new frmProductFault();
            oForm.ShowDialog();
            if (oForm._bIsAnyActivityDone)
            {
                DataLoadControl();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductFaults.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductFault oProductFault = (ProductFault)lvwProductFaults.SelectedItems[0].Tag;
            frmProductFault oForm = new frmProductFault();
            oForm.ShowDialog(oProductFault);
            if (oForm._bIsAnyActivityDone)
            {
                DataLoadControl();
            }
        }

        //private void Close_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void LoadCombo()
        {
            //Combo Product Fault Type
            _oProductFaultsForCmb = new ProductFaults();
            _oProductFaultsForCmb.GetData(-1);
            cmbParentFault.Items.Clear();
            cmbParentFault.Items.Add("-- Select --");
            foreach (ProductFault oProductFault in _oProductFaultsForCmb)
            {
                cmbParentFault.Items.Add(oProductFault.FaultDescription);
            }
            cmbParentFault.SelectedIndex = 0;         

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}