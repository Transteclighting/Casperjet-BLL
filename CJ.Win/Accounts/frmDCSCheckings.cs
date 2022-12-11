using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmDCSCheckings : Form
    {
        public frmDCSCheckings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombos()
        {
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DCSCheckingStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.DCSCheckingStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            cmbType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InstrumentType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.InstrumentType), GetEnum));
            }
            cmbType.SelectedIndex = 0;
        
        }
        private void DataLoadControl()
        {

            DCSCheckings oDCSCheckings = new DCSCheckings();
            
            lvwDCSCheckings.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oDCSCheckings.Refresh(dtFromDate.Value.Date, txtOutlet.Text, cmbStatus.SelectedIndex-1, cmbType.SelectedIndex-1);

            this.Text = "Total " + "[" + oDCSCheckings.Count + "]";
            foreach (DCSChecking oDCSChecking in oDCSCheckings)
            {
                ListViewItem oItem = lvwDCSCheckings.Items.Add(oDCSChecking.Outlet.ToString());
                if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.CASH)
                {
                    oItem.SubItems.Add("CASH");
                }
                else if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.CHEQUE)
                {
                    oItem.SubItems.Add("CHEQUE");
                }
                else if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.CREDIT_CARD)
                {
                    oItem.SubItems.Add("CREDIT_CARD");
                }
                else if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.DD)
                {
                    oItem.SubItems.Add("DD");
                }
                else if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.PAYORDER)
                {
                    oItem.SubItems.Add("PAYORDER");
                }
                else oItem.SubItems.Add("TT");
                oItem.SubItems.Add(oDCSChecking.InvoiceAmt.ToString());
                oItem.SubItems.Add(oDCSChecking.BankDepositAmt.ToString());
                if (oDCSChecking.Status == (int)Dictionary.DCSCheckingStatus.Checked)
                {
                    oItem.SubItems.Add("Checked");
                }
                else if (oDCSChecking.Status == (int)Dictionary.DCSCheckingStatus.Pending)
                {
                    oItem.SubItems.Add("Pending");
                }
                else if (oDCSChecking.Status == (int)Dictionary.DCSCheckingStatus.UnCheck)
                {
                    oItem.SubItems.Add("UnCheck");
                }
                else oItem.SubItems.Add("Cancel");
                oItem.SubItems.Add(oDCSChecking.Remarks.ToString());
                oItem.Tag = oDCSChecking;
            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwDCSCheckings.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwDCSCheckings.Items)
                {
                    if (oItem.SubItems[4].Text == Dictionary.DCSCheckingStatus.UnCheck.ToString())
                    {
                        oItem.BackColor = Color.Plum;
                    }
                    else if (oItem.SubItems[4].Text == Dictionary.DCSCheckingStatus.Checked.ToString())
                    {
                        oItem.BackColor = Color.Snow;
                    }
                    else if (oItem.SubItems[4].Text == Dictionary.DCSCheckingStatus.Pending.ToString())
                    {
                        oItem.BackColor = Color.IndianRed;
                    }
                    else
                        oItem.BackColor = Color.DarkGray;
                   

                }
            }
        }
        private void frmDCSCheckings_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            LoadCombos();
        }
        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (lvwDCSCheckings.SelectedItems.Count != 0)
            {

                DCSChecking oDCSChecking = (DCSChecking)lvwDCSCheckings.SelectedItems[0].Tag;

                frmDCSChecking oForm = new frmDCSChecking();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Status";
                oForm.ShowDialog(oDCSChecking);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwDCSCheckings_DoubleClick(object sender, EventArgs e)
        {
            if (lvwDCSCheckings.SelectedItems.Count != 0)
            {

                DCSChecking oDCSChecking = (DCSChecking)lvwDCSCheckings.SelectedItems[0].Tag;

                frmDCSChecking oForm = new frmDCSChecking();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Status";
                oForm.ShowDialog(oDCSChecking);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtOutlet_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }
}