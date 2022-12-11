using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;


namespace CJ.Win.Replace_Management
{
    public partial class frmReplacementClaims : Form
    {
        bool IsCheck = false;
        ReplaceClaims oReplaceClaims;

        private void LoadCombos()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ReplacementStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ReplacementStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        public frmReplacementClaims()
        {
            InitializeComponent();
        }
        private void DataLoadControl()
        {
            oReplaceClaims = new ReplaceClaims();
            lvwItemList.Items.Clear();

            DBController.Instance.OpenNewConnection();
            int nStatus = -1;
            if (cmbStatus.SelectedIndex != 0)
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            oReplaceClaims.RefreshSubClaim(dtFromDate.Value.Date, dtToDate.Value.Date, txtClaimNo.Text.Trim(), txtSubClaimNo.Text.Trim(), ctlCustomer1.txtCode.Text.Trim(), IsCheck, nStatus);
            this.Text = "Total  " + "[" + oReplaceClaims.Count + "]";

            foreach (ReplaceClaim oReplaceClaim in oReplaceClaims)
            {
                ListViewItem oItem = lvwItemList.Items.Add(oReplaceClaim.ReplaceClaimNo);
                oItem.SubItems.Add(oReplaceClaim.SubClaimNo);
                oItem.SubItems.Add(oReplaceClaim.CustomerName);
                oItem.SubItems.Add(oReplaceClaim.ClaimDate.ToString("dd-MMM-yyyy"));
                if (oReplaceClaim.ValidationDate != "")
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oReplaceClaim.ValidationDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ReplacementStatus), oReplaceClaim.SubClaimStatus));
                oItem.SubItems.Add(oReplaceClaim.EntryDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oReplaceClaim.UserName);

                oItem.Tag = oReplaceClaim;
            }
            setListViewRowColour();
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

        private void btGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void setListViewRowColour()
        {


            if (lvwItemList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwItemList.Items)
                {
                    if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_RECEIVE_AT_SERVICE")
                    {
                        oItem.BackColor = Color.LightCyan;
                    }
                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_RECEIVE_TEAM_REQUIRED")
                    {
                        oItem.BackColor = Color.Pink;
                    }
                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_RECEIVE_TO_BE_SEND")
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_PRODUCT_PHYSICALLY_RECEIVE")
                    {
                        oItem.BackColor = Color.MistyRose;
                    }
                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_SEND_TO_BLL")
                    {
                        oItem.BackColor = Color.Cyan;
                    }
                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_ASSESSMENT_COMPLETE")
                    {
                        oItem.BackColor = Color.Plum;
                    }
                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_ON_CHECKING_BY_ACCOUNT")
                    {
                        oItem.BackColor = Color.Tan;
                    }

                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_WAITING_FOR_APPROVAL")
                    {
                        oItem.BackColor = Color.YellowGreen;
                    }
                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_APPROVED")
                    {
                        oItem.BackColor = Color.MediumSpringGreen;
                    }

                    else if (oItem.SubItems[5].Text == "REPLACEMENT_CLAIM_REPLACED")
                    {
                        oItem.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        oItem.BackColor = Color.Silver;
                    }

                }
            }
        }

        private void btnGenerateClaimNo_Click(object sender, EventArgs e)
        {
            frmClaimGenerator ofrmClaimGenerator = new frmClaimGenerator();
            ofrmClaimGenerator.ShowDialog();
        }

        private void btnClaimReceive_Click(object sender, EventArgs e)
        {
            frmClaimReceive ofrmClaimReceive = new frmClaimReceive();
            ofrmClaimReceive.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTeamRequired_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_AT_SERVICE)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_TEAM_REQUIRED;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim receive at service status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                DataLoadControl();
            }
        }

        private void btnReceiveToBeSend_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_TEAM_REQUIRED)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_TO_BE_SEND;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim team required status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnPhysicallyReceive_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_TO_BE_SEND)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_PRODUCT_PHYSICALLY_RECEIVE;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim product physically receive status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnSendToBLL_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_PRODUCT_PHYSICALLY_RECEIVE)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_SEND_TO_BLL;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim send to bll status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnClaimAssess_Click(object sender, EventArgs e)
        {

            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.SelectedItems[0].Tag;

            if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_AT_SERVICE || oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_TEAM_REQUIRED || oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_TO_BE_SEND || oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_PRODUCT_PHYSICALLY_RECEIVE || oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_SEND_TO_BLL)
            {
                frmClaimAssess oForm = new frmClaimAssess();
                oForm.ShowDialog(oReplaceClaim);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only received status can be update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCheckingByAccount_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_ASSESSMENT_COMPLETE)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_ON_CHECKING_BY_ACCOUNT;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim assessment complete status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnWaitingForApproval_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_ON_CHECKING_BY_ACCOUNT)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_WAITING_FOR_APPROVAL;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim checked by account status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_WAITING_FOR_APPROVAL)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_APPROVED;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim waiting for approval status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnReplaced_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_APPROVED)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_REPLACED;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim approved status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to update status those selected claims ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < lvwItemList.Items.Count; i++)
                        {
                            ListViewItem itm = lvwItemList.Items[i];
                            if (lvwItemList.Items[i].Checked == true)
                            {
                                ReplaceClaim oReplaceClaim = (ReplaceClaim)lvwItemList.Items[i].Tag;
                                if (oReplaceClaim.SubClaimStatus == (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_AT_SERVICE)
                                {
                                    ReplaceClaim _oReplaceClaim = new ReplaceClaim();
                                    _oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_CANCEL;
                                    _oReplaceClaim.SubClaimNo = oReplaceClaim.SubClaimNo;
                                    DBController.Instance.BeginNewTransaction();
                                    _oReplaceClaim.UpdateClaimItemStatus();
                                    _oReplaceClaim.UpdateClaimNoStatusStatus();
                                    DBController.Instance.CommitTran();

                                }
                                else
                                {
                                    MessageBox.Show("Only claim received at service status can be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnChkAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btnChkAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwItemList.Items.Count; i++)
                {

                    ListViewItem itm = lvwItemList.Items[i];
                    lvwItemList.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btnChkAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwItemList.Items.Count; i++)
                {
                    ListViewItem itm = lvwItemList.Items[i];
                    lvwItemList.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btnChkAll.Text = "Checked All";
                }
            }
        }

        private void frmReplacementClaims_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }
    }
}