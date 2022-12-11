using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;
using CJ.Report.CSD;
using CJ.Report;


namespace CJ.Win
{
    public partial class frmSMSMessages : Form
    {
        
        private int _nStatus;
        //Utilities _oUtilitys;

        //public ReplaceHistory oReplaceHistory;
        //public Product oProduct;
        public CSDSMS oCSDSMS;
        CSDSMSS oCSDSMSS;
        CSDSMS _oCSDSMS;

        public frmSMSMessages()
        {
            InitializeComponent();
        }

        private void frmSMSMessages_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
            pbtGenerate.Visible = false;
        }

        private void LoadCombos()
        {

            //Get SMS Status
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDSMSStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.CSDSMSStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = cmbStatus.Items.Count - 5;

            //Get SMS SvrStatus
            cmbSvrStatus.Items.Add("All");
            cmbSvrStatus.Items.Add("N/A");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDSMSSvrStatus)))
            {
                cmbSvrStatus.Items.Add(Enum.GetName(typeof(Dictionary.CSDSMSSvrStatus), GetEnum));
            }
            cmbSvrStatus.SelectedIndex = 0;

            //Get SMS Type
            cmbSMSType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDSMSType)))
            {
                cmbSMSType.Items.Add(Enum.GetName(typeof(Dictionary.CSDSMSType), GetEnum));
            }
            cmbSMSType.SelectedIndex = 0;

            //Get SMS Lenth
            cmbSMSLenth.Items.Add("All");
            cmbSMSLenth.Items.Add(">160");
            cmbSMSLenth.Items.Add("<=160");
            
            cmbSMSLenth.SelectedIndex = 0;


        }

        private void DataLoadControl()
        {

            //_nStatus = oUtility.SatusId;

            CSDSMSS oCSDSMSS = new CSDSMSS();

            lvwSMSMessage.Items.Clear();
            ckbSelect.Checked = false;
            DBController.Instance.OpenNewConnection();
            {
                if (All.Checked == false)
                {
                    oCSDSMSS.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtSMSID.Text, txtSMSCode.Text, txtMobileNo.Text, txtJobNo.Text, cmbStatus.SelectedIndex - 1, cmbSMSType.SelectedIndex - 1, cmbSMSLenth.SelectedIndex - 1, cmbSvrStatus.SelectedIndex - 1);
                }
                else
                {
                    oCSDSMSS.RefreshAll(txtSMSID.Text, txtSMSCode.Text, txtMobileNo.Text, txtJobNo.Text, cmbStatus.SelectedIndex - 1, cmbSMSType.SelectedIndex - 1, cmbSMSLenth.SelectedIndex - 1, cmbSvrStatus.SelectedIndex - 1);//, cmbSvrStatus.SelectedIndex - 1

                }
            }

            this.Text = "Total " + "[" + oCSDSMSS.Count + "]";
            foreach (CSDSMS oCSDSMS in oCSDSMSS)
            {
                ListViewItem oItem = lvwSMSMessage.Items.Add(oCSDSMS.SMSID.ToString());
                oItem.SubItems.Add(oCSDSMS.SMSCode);
                oItem.SubItems.Add(oCSDSMS.JobNo);
                oItem.SubItems.Add(oCSDSMS.MobileNo);
                oItem.SubItems.Add(oCSDSMS.StatusName);
                oItem.SubItems.Add(oCSDSMS.ServerStatus.ToString());
                oItem.SubItems.Add(oCSDSMS.SMSTypeName);
                oItem.SubItems.Add(oCSDSMS.CharCount.ToString());
                oItem.SubItems.Add(oCSDSMS.SMSText);
                oItem.SubItems.Add(oCSDSMS.CreateDate.ToString());
                oItem.SubItems.Add(oCSDSMS.SentBy.ToString());
                oItem.SubItems.Add(oCSDSMS.SendDate.ToString());
                oItem.SubItems.Add(oCSDSMS.ReSentBy.ToString());
                oItem.SubItems.Add(oCSDSMS.ReSentDate.ToString());
                oItem.SubItems.Add(oCSDSMS.EditedBy.ToString());
                oItem.SubItems.Add(oCSDSMS.ReGenReqBy.ToString());
                oItem.SubItems.Add(oCSDSMS.ReGenReqDate.ToString());
                oItem.SubItems.Add(oCSDSMS.ReGenReqReason.ToString());
                oItem.SubItems.Add(oCSDSMS.CancelledBy.ToString());
                oItem.SubItems.Add(oCSDSMS.CancelDate.ToString());
                oItem.SubItems.Add(oCSDSMS.CancelReason.ToString());

                oItem.Tag = oCSDSMS;
            }
            setListViewRowColour();
        }

        private void btnGenerateSMS_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
            _oCSDSMS = new CSDSMS();
            DBController.Instance.OpenNewConnection();

            pbtGenerate.Visible = true;
            pbtGenerate.Minimum = 0;
            pbtGenerate.Maximum = 3;
            pbtGenerate.Step = 1;
            pbtGenerate.Value = 0;

            //int percent = (int)(((double)pbtGenerate.Value / (double)pbtGenerate.Maximum) * 100);
            //pbtGenerate.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(pbtGenerate.Width / 2 - 10, pbtGenerate.Height / 2 - 7));

            _oCSDSMS.Add();
            pbtGenerate.PerformStep();
            _oCSDSMS.Add3();
            pbtGenerate.PerformStep();
            _oCSDSMS.Add2();
            pbtGenerate.PerformStep();
            _oCSDSMS.Add4();
            pbtGenerate.PerformStep();
            _oCSDSMS.Add1();
            pbtGenerate.PerformStep();
            _oCSDSMS.Add5();
            pbtGenerate.PerformStep();
            DBController.Instance.CommitTransaction();
            MessageBox.Show("SMS Generate Successfully. ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pbtGenerate.Visible = false;
            DataLoadControl();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");

            }
            this.Cursor = Cursors.Arrow;
            return;
        }

        private void btnSentToServer_Click(object sender, EventArgs e)
        {
            if (lvwSMSMessage.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwSMSMessage.Items.Count; i++)
                {
                    ListViewItem itm = lvwSMSMessage.Items[i];
                    if (lvwSMSMessage.Items[i].Checked == true)
                    {
                        CSDSMS oCSDSMS = (CSDSMS)lvwSMSMessage.Items[i].Tag;
                        if (oCSDSMS.Status == (int)Dictionary.CSDSMSStatus.UnSend && oCSDSMS.SMSText.Length <= 160)
                        {
                            oCSDSMS.SMSTextT = oCSDSMS.SMSText;
                            oCSDSMS.SingleMobileNo = oCSDSMS.MobileNo;
                            oCSDSMS.SMSCode = oCSDSMS.SMSCode;
                            oCSDSMS.Status = oCSDSMS.Status;
                            oCSDSMS.SubmittedBy = oCSDSMS.SMSID.ToString();

                            oCSDSMS.JobIDC = oCSDSMS.JobID;
                            oCSDSMS.CallRemarks = "Sent Auto SMS" + "/" + oCSDSMS.SMSID;
                            oCSDSMS.JobIDCom = oCSDSMS.JobID;
                            oCSDSMS.Remarks = "Sent Auto SMS" + "/" + oCSDSMS.SMSID;


                            if (oCSDSMS.MobileNo.ToString() == "")
                            {
                                MessageBox.Show("Please Enter Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                if (oCSDSMS.MobileNo.Length != 11)
                                {
                                    MessageBox.Show("Please Enter a Valid Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                Regex rgCell = new Regex("[0-9]");
                                if (rgCell.IsMatch(oCSDSMS.MobileNo.ToString()))
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Please Enter a Valid Mobile Number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                            }
                            //Sent Auto SMS
                            oCSDSMS.AddToServer();
                            oCSDSMS.Sent();
                            if (oCSDSMS.SMSType != (int)Dictionary.CSDSMSType.InterServicePaidJob_ScheduleDateTime)
                            {
                                oCSDSMS.AddCallCentJobList();
                                oCSDSMS.AddCommunication();
                            }
                            else
                            { 
                            }

                            if (oCSDSMS.SMSType == (int)Dictionary.CSDSMSType.InterServicePaidJob_ScheduleDateTime)
                            {
                                oCSDSMS.PaidJobID = oCSDSMS.JobID;
                                oCSDSMS.RemarksPJH = "Sent Auto SMS" + "/" + oCSDSMS.SMSID;
                                oCSDSMS.CommuRemarks = "Sent Auto SMS" + "/" + oCSDSMS.SMSID;
                                oCSDSMS.CommuRemarks = "Sent Auto SMS" + "/" + oCSDSMS.SMSID;
                                oCSDSMS.AddISVPaidJobHistory();
                                oCSDSMS.UpdateISVPaidJobComStatus();
                            }
                            else
                            { 
                            }
                        }
                        else
                        {
                            MessageBox.Show("Only UnSend SMS should send & SMS Length Must be '<=160'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }

                }
                MessageBox.Show("Sent Successfully ", "Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Check Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnReSent_Click(object sender, EventArgs e)
        {
            if (lvwSMSMessage.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwSMSMessage.Items.Count; i++)
                {

                    ListViewItem itm = lvwSMSMessage.Items[i];

                    if (lvwSMSMessage.Items[i].Checked == true)
                    {
                        CSDSMS oCSDSMS = (CSDSMS)lvwSMSMessage.Items[i].Tag;
                        if (oCSDSMS.Status == (int)Dictionary.CSDSMSStatus.Sent && oCSDSMS.SMSText.Length<=160)
                        {
                            oCSDSMS.SMSTextT = oCSDSMS.SMSText;
                            oCSDSMS.SingleMobileNo = oCSDSMS.MobileNo;
                            oCSDSMS.SMSCode = oCSDSMS.SMSCode;
                            oCSDSMS.Status = oCSDSMS.Status;
                            oCSDSMS.SubmittedBy = oCSDSMS.SMSID.ToString();

                            oCSDSMS.JobIDC = oCSDSMS.JobID;
                            oCSDSMS.CallRemarks = "Re-Sent Auto SMS" + "/" + oCSDSMS.SMSID;
                            oCSDSMS.JobIDCom = oCSDSMS.JobID;
                            oCSDSMS.Remarks = "Re-Sent Auto SMS" + "/" + oCSDSMS.SMSID;

                            if (oCSDSMS.MobileNo.ToString() == "")
                            {
                                MessageBox.Show("Please Enter Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                if (oCSDSMS.MobileNo.Length != 11)
                                {
                                    MessageBox.Show("Please Enter a Valid Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                Regex rgCell = new Regex("[0-9]");
                                if (rgCell.IsMatch(oCSDSMS.MobileNo.ToString()))
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Please Enter a Valid Mobile Number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                            }

                                oCSDSMS.AddToServer();
                                oCSDSMS.ReSent();
                                if (oCSDSMS.SMSType != (int)Dictionary.CSDSMSType.InterServicePaidJob_ScheduleDateTime)
                                {
                                    oCSDSMS.AddCallCentJobList();
                                    oCSDSMS.AddCommunication();
                                }
                                else
                                { 
                                }
                                if (oCSDSMS.SMSType == (int)Dictionary.CSDSMSType.InterServicePaidJob_ScheduleDateTime)
                                {
                                    oCSDSMS.PaidJobID = oCSDSMS.JobID;
                                    oCSDSMS.RemarksPJH = "Sent Auto SMS" + "/" + oCSDSMS.SMSID;
                                    oCSDSMS.AddISVPaidJobHistory();
                                }
                                else
                                { 
                                }
                        }
                        else
                        {
                            MessageBox.Show("Only Sent SMS should Re-Send & SMS Length Must be '<=160'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }

                }
                MessageBox.Show("Re-Sent Successfully ", "Re-Sent", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Check Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
     
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Arrow;
        }
    
        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwSMSMessage.Items.Count; i++)
                {
                    ListViewItem itm = lvwSMSMessage.Items[i];

                    lvwSMSMessage.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwSMSMessage.Items.Count; i++)
                {
                    ListViewItem itm = lvwSMSMessage.Items[i];

                    lvwSMSMessage.Items[i].Checked = false;

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setListViewRowColour()
        {
            if (lvwSMSMessage.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwSMSMessage.Items)
                {
                    if (oItem.SubItems[4].Text == Dictionary.CSDSMSStatus.UnSend.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[4].Text == Dictionary.CSDSMSStatus.Sent.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else if (oItem.SubItems[4].Text == Dictionary.CSDSMSStatus.ReSent.ToString())
                    {
                        oItem.BackColor = Color.LightSteelBlue;
                    }
                    else if (oItem.SubItems[4].Text == Dictionary.CSDSMSStatus.ReGenerate.ToString())
                    {
                        oItem.BackColor = Color.Thistle;
                    }
                    else
                    {
                        oItem.BackColor = Color.DarkGray;
                    }
                }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSMSMessage.SelectedItems.Count != 0)
            {
                CSDSMS oCSDSMS = (CSDSMS)lvwSMSMessage.SelectedItems[0].Tag;

                if (oCSDSMS.Status != (int)Dictionary.CSDSMSStatus.Cancel)
                {
                    frmSMSMessage oForm = new frmSMSMessage();

                    oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    oForm.MaximizeBox = false;
                    oForm.Text = "Edit SMS";
                    oForm.ShowDialog(oCSDSMS);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("Cancel SMS should not Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwSMSMessage_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSMSMessage.SelectedItems.Count != 0)
            {
                CSDSMS oCSDSMS = (CSDSMS)lvwSMSMessage.SelectedItems[0].Tag;
                if (oCSDSMS.Status != (int)Dictionary.CSDSMSStatus.Cancel)
                {

                    frmSMSMessage oForm = new frmSMSMessage();

                    oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    oForm.MaximizeBox = false;
                    oForm.Text = "Edit SMS";
                    oForm.ShowDialog(oCSDSMS);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("Cancel SMS should not Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwSMSMessage.SelectedItems.Count != 0)
            {
                CSDSMS oCSDSMS = (CSDSMS)lvwSMSMessage.SelectedItems[0].Tag;

                if (oCSDSMS.Status == (int)Dictionary.CSDSMSStatus.UnSend)
                {
                    frmSMSCancel oForm = new frmSMSCancel();

                    oForm.ShowDialog(oCSDSMS);
                    DataLoadControl();

                }
                else
                {
                    MessageBox.Show("Only UnSend SMS you Can Cancel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataLoadControl();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnReqReGen_Click(object sender, EventArgs e) //
        {
            if (lvwSMSMessage.SelectedItems.Count != 0)
            {
                CSDSMS oCSDSMS = (CSDSMS)lvwSMSMessage.SelectedItems[0].Tag;

                //if (oCSDSMS.Status == (int)Dictionary.CSDSMSStatus.UnSend)
                //{
                    frmSMSReGenerate oForm = new frmSMSReGenerate();

                    oForm.ShowDialog(oCSDSMS);
                    DataLoadControl();

                //}
                //else
                //{
                //    MessageBox.Show("Only UnSend SMS you Can Cancel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    DataLoadControl();
                //}
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }


    }

}