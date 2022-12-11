using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win
{
    public partial class frmInquirys : Form
    {
        private Districts _oDistricts;

        public frmInquirys()
        {
            InitializeComponent();
        }
        private void frmInquirys_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            LoadCombos();
        }
        private void LoadCombos()
        {
            cmbIsWebQuery.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsWEBQuery)))
            {
                cmbIsWebQuery.Items.Add(Enum.GetName(typeof(Dictionary.IsWEBQuery), GetEnum));
            }
            cmbIsWebQuery.SelectedIndex = 0;
        }

        private void DataLoadControl()
        {
            Inquirys oInquirys = new Inquirys();

            lvwInquirys.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {
                if (All.Checked == false)
                {
                    oInquirys.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtInquiryNo.Text, txtName.Text, txtContactNo.Text, txtReceiveBy.Text, cmbIsWebQuery.SelectedIndex - 1);
                }
                else
                {
                    oInquirys.RefreshAll(txtInquiryNo.Text, txtName.Text, txtContactNo.Text, txtReceiveBy.Text, cmbIsWebQuery.SelectedIndex - 1);

                }
            }
            this.Text = "InquiryID " + "[" + oInquirys.Count + "]";
            foreach (Inquiry oInquiry in oInquirys)
            {
                ListViewItem oItem = lvwInquirys.Items.Add(oInquiry.InquiryID.ToString());
                oItem.SubItems.Add(oInquiry.CreateDate.ToString());
                oItem.SubItems.Add(oInquiry.InqName);
                oItem.SubItems.Add(oInquiry.ContactNo);
                oItem.SubItems.Add(oInquiry.User.Username.ToString());
                oItem.SubItems.Add(oInquiry.OutletCode.ToString());
                oItem.SubItems.Add(oInquiry.CommuStat.ToString());
                oItem.SubItems.Add(oInquiry.SolveBy.ToString());
                if (oInquiry.IsWEBQuery == (int)Dictionary.IsWEBQuery.Yes)
                {
                    oItem.SubItems.Add("Yes");
                }
                else
                {
                    oItem.SubItems.Add("No");
                }
                oItem.SubItems.Add(oInquiry.WEBTrackNo.ToString());
                oItem.Tag = oInquiry;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmInquiry oForm = new frmInquiry();
            oForm.ShowDialog();
            DataLoadControl();
        }

 

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }
 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwInquirys.SelectedItems.Count != 0)
            {
                Inquiry oInquiry = (Inquiry)lvwInquirys.SelectedItems[0].Tag;

                frmInquiry oForm = new frmInquiry();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oInquiry);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void lvwInquirys_DoubleClick(object sender, EventArgs e)
        {
            if (lvwInquirys.SelectedItems.Count != 0)
            {
                Inquiry oInquiry = (Inquiry)lvwInquirys.SelectedItems[0].Tag;

                frmInquiry oForm = new frmInquiry();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oInquiry);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwInquirys.SelectedItems.Count != 0)
            {
                Inquiry oInquiry = (Inquiry)lvwInquirys.SelectedItems[0].Tag;
                //if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                DialogResult oResult = MessageBox.Show("Are you sure You want to delete the Inquiry: " + oInquiry.InquiryID + " ? ", "Confirm Inquiry Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                //if (MessageBox.Show("Do you want to Delete Complain?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oInquiry.Delete();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show(" Successfully Delete The Inquiry No : " + oInquiry.InquiryID, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControl();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    //DataLoadControl();
                }
                else
                {
                    DataLoadControl();
                    //MessageBox.Show("Please Change Status as CANCELED and Then Delete it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnInqCommunication_Click(object sender, EventArgs e)
        {
            if (lvwInquirys.SelectedItems.Count != 0)
            {
                Inquiry oInquiry = (Inquiry)lvwInquirys.SelectedItems[0].Tag;

                frmInquiryCommunication oForm = new frmInquiryCommunication();
               oForm.ShowDialog(oInquiry);
               DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }

        }
  


    }

}