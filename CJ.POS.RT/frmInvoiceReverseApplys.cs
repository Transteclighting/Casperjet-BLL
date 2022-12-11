using System;
using System.Drawing;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmInvoiceReverseApplys : Form
    {
        InvoiceReverses _oInvoiceReverses;
        bool IsCheck = false;


        public frmInvoiceReverseApplys()
        {
            InitializeComponent();
        }

        private void SetListViewRowColour()
        {
            if (lvwInvoice.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwInvoice.Items)
                {
                    if (oItem.SubItems[5].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[5].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;

                    }
                    else if (oItem.SubItems[5].Text == "Recommended")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[5].Text == "Approved")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[5].Text == "Reject")
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

        public void DataLoadControl()
        {
            lvwInvoice.Items.Clear();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oInvoiceReverses = new InvoiceReverses();

            _oInvoiceReverses.GetReverseAppalicationRT(dtFromDate.Value.Date, dtToDate.Value.Date, txtInvoiceNo.Text.Trim(), IsCheck);

            foreach (InvoiceReverse oInvoiceReverse in _oInvoiceReverses)
            {
                ListViewItem lstItem = lvwInvoice.Items.Add(oInvoiceReverse.InvoiceNo.ToString());
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

        private void btnReverseApply_Click(object sender, EventArgs e)
        {
            frmInvoiceReverseApply oFrom = new frmInvoiceReverseApply();
            oFrom.ShowDialog();
            DataLoadControl();
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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInvoiceReverseApplys_Load(object sender, EventArgs e)
        {
            TELLib oTELLib = new TELLib();
            dtFromDate.Value = oTELLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InvoiceReverse oInvoiceReverse = (InvoiceReverse)lvwInvoice.SelectedItems[0].Tag;
            if (oInvoiceReverse.Status == (int)Dictionary.ReverseStatus.Create)
            {
                frmInvoiceReverseApply oForm = new frmInvoiceReverseApply();
                oForm.ShowDialog(oInvoiceReverse);
                if (oForm._IsTrue)
                    DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create Status can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InvoiceReverse oInvoiceReverse = (InvoiceReverse)lvwInvoice.SelectedItems[0].Tag;

            if (oInvoiceReverse.Status == (int)Dictionary.ReverseStatus.Create)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to Delete Appalication. InvoiceNo: " + oInvoiceReverse.InvoiceNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        //Delete 
                        oInvoiceReverse.DeleteRT();
                        oInvoiceReverse.DeleteDetailRT();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControl();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("You Cannot Delete this Data", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
    }
}