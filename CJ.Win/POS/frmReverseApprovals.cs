using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.POS
{
    public partial class frmReverseApprovals : Form
    {
        Showrooms _oShowrooms;
        InvoiceReverses _oInvoiceReverses;
        bool IsCheck = false;

        public frmReverseApprovals()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Showroom 
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("<All>");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;

            // Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ReverseStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ReverseStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }

        public void DataLoadControl()
        {
            int nWarehouseID = 0;
            if (cmbShowroom.SelectedIndex == 0)
            {
                nWarehouseID = -1;
            }

            else
            {
                nWarehouseID = _oShowrooms[cmbShowroom.SelectedIndex - 1].WarehouseID;
            }

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            lvwInvoice.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oInvoiceReverses = new InvoiceReverses();

            _oInvoiceReverses.GetReverseAppalicationHO(dtFromDate.Value.Date, dtToDate.Value.Date, txtInvoiceNo.Text.Trim(),nWarehouseID,nStatus, IsCheck);

            foreach (InvoiceReverse oInvoiceReverse in _oInvoiceReverses)
            {
                ListViewItem lstItem = lvwInvoice.Items.Add(oInvoiceReverse.ShowroomCode.ToString());
                lstItem.SubItems.Add(oInvoiceReverse.InvoiceNo.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(oInvoiceReverse.CreateDate).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oInvoiceReverse.Reason.ToString());
                lstItem.SubItems.Add(oInvoiceReverse.Recommend.ToString());
                lstItem.SubItems.Add(oInvoiceReverse.ApprovedCommand.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ReverseStatus), oInvoiceReverse.Status));

                lstItem.Tag = oInvoiceReverse;

            }
            SetListViewRowColour();
            this.Text = "Invoice Reverse Appalications [" + _oInvoiceReverses.Count + "]";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void SetListViewRowColour()
        {
            if (lvwInvoice.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwInvoice.Items)
                {
                    if (oItem.SubItems[6].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[6].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;

                    }
                    else if (oItem.SubItems[6].Text == "Recommended")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[6].Text == "Approved")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[6].Text == "Reject")
                    {
                        oItem.BackColor = Color.Red;

                    }
                    else
                    {
                        oItem.BackColor = Color.Green;
                    }

                }
            }
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

        private void btnRecommend_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InvoiceReverse oInvoiceReverse = (InvoiceReverse)lvwInvoice.SelectedItems[0].Tag;
            if (oInvoiceReverse.Status == (int)Dictionary.ReverseStatus.Create)
            {
                frmReverseApproval oForm = new frmReverseApproval((int)Dictionary.ReverseStatus.Recommended);
                oForm.ShowDialog(oInvoiceReverse);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create Status can be Recommend", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InvoiceReverse oInvoiceReverse = (InvoiceReverse)lvwInvoice.SelectedItems[0].Tag;
            if (oInvoiceReverse.Status == (int)Dictionary.ReverseStatus.Recommended)
            {
                frmReverseApproval oForm = new frmReverseApproval((int)Dictionary.ReverseStatus.Approved);
                oForm.ShowDialog(oInvoiceReverse);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create Status can be Recommend", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void frmReverseApprovals_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please Select a Data to Update.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InvoiceReverse oInvoiceReverse = (InvoiceReverse)lvwInvoice.SelectedItems[0].Tag;
            if (oInvoiceReverse.Status == (int)Dictionary.ReverseStatus.Create)
            {
                frmReverseApproval oForm = new frmReverseApproval((int)Dictionary.ReverseStatus.Reject);
                oForm.ShowDialog(oInvoiceReverse);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show(@"Only Create Status can be Reject", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select a data.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InvoiceReverse oInvoiceReverse = (InvoiceReverse)lvwInvoice.SelectedItems[0].Tag;
            frmReverseRemarksUpdate oFrmReverseRemarksUpdate = new frmReverseRemarksUpdate();
            oFrmReverseRemarksUpdate.ShowDialog(oInvoiceReverse);
            DataLoadControl();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}