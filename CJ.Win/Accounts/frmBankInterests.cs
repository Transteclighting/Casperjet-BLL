using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.BasicData;

namespace CJ.Win.Accounts
{
    public partial class frmBankInterests : Form
    {
        BankIst _oBankIst;
        BankIsts _oBankIsts;
        Banks _oBanks;

        public frmBankInterests()
        {
            _oBankIst = new BankIst();
            _oBankIsts = new BankIsts();
            _oBanks = new Banks();
            InitializeComponent();
        }

        private void frmBankInterests_Load_1(object sender, EventArgs e)
        {
            LoadCombo();
            LoadData();
            this.Text = "Bank Interests " + "[" + _oBankIsts.Count + "]";
            
        }

        private void LoadData()
        {
            _oBankIsts = new BankIsts();
            lvwBankInterests.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nBankID = -1 ;
            if (cmbBankList.SelectedIndex != 0)
            {
                nBankID = _oBanks[cmbBankList.SelectedIndex - 1].BankID;
            }

            _oBankIsts.Refreshs(nBankID);

            foreach (BankIst oBankIst in _oBankIsts)
            {
                ListViewItem oItem = lvwBankInterests.Items.Add(oBankIst.BankName);
                oItem.SubItems.Add(oBankIst.EMINo.ToString());
                oItem.SubItems.Add(oBankIst.InsRate.ToString());
                oItem.Tag = oBankIst;
            }
        }

        private void LoadCombo()
        {
            //Bank Name
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBankList.Items.Add("<ALL>");
            foreach (Bank oBank in _oBanks)
            {
                cmbBankList.Items.Add(oBank.Name);
            }
            cmbBankList.SelectedIndex = 0;
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmBankInterest oForm = new frmBankInterest();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(lvwBankInterests.SelectedItems.Count==0)
            {
                MessageBox.Show("Please Select an Bank Interest to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oBankIst = (BankIst)lvwBankInterests.SelectedItems[0].Tag;
            frmBankInterest oForm = new frmBankInterest();
            oForm.ShowDialog(_oBankIst);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lvwBankInterests.SelectedItems.Count==0)
            {
                MessageBox.Show("Please Select a Bank Name to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oBankIst = (BankIst)lvwBankInterests.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Bank: " + _oBankIst.InsRate + " ? ", "Confirm Bank Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oBankIst.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbBankList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadCombo();
            LoadData();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lvwBankInterests_DoubleClick(object sender, EventArgs e)
        {
            if (lvwBankInterests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Bank Name edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BankIst oBankIst = (BankIst)lvwBankInterests.SelectedItems[0].Tag;
            frmBankInterest oForm = new frmBankInterest();
            oForm.ShowDialog(oBankIst);
            LoadData();
        }   

    }
}