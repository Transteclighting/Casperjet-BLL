using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using System.Text.RegularExpressions;

namespace CJ.Win.CSD
{
    public partial class frmCSDSMSHistory : Form
    {
        CSDSMSHistorys _oCSDSMSHistorys;
        //CSDSMSModels _oCSDSMSModels;
        SMSMaker _oSMSMaker;
        CSDSMSHistory _oCSDSMSHistory;
        public frmCSDSMSHistory()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCSDSMSHistoryCreate oForm = new frmCSDSMSHistoryCreate();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {
            int nStatus = -1;
            if (cmbStatus.SelectedIndex != 0)
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            DBController.Instance.OpenNewConnection();
            _oCSDSMSHistorys = new CSDSMSHistorys();
            DBController.Instance.OpenNewConnection();
            _oCSDSMSHistorys.Getdata(txtJobNo.Text, txtMobileNo.Text, nStatus,cmbSMSLength.SelectedIndex);
            this.Text = "CSD SMS History | Total: " + "[" + _oCSDSMSHistorys.Count + "]";
            lvwCSDSMSHistory.Items.Clear();
            foreach (CSDSMSHistory oCSDSMSHistory in _oCSDSMSHistorys)
            {
                ListViewItem oItem = lvwCSDSMSHistory.Items.Add(oCSDSMSHistory.JobNo);
                oItem.SubItems.Add(oCSDSMSHistory.ServiceType);
                oItem.SubItems.Add(oCSDSMSHistory.SmsModelStatus);
                oItem.SubItems.Add(oCSDSMSHistory.SendTo);
                oItem.SubItems.Add(oCSDSMSHistory.SMSText);
                oItem.SubItems.Add(oCSDSMSHistory.SMSText.Length.ToString());
                oItem.SubItems.Add(oCSDSMSHistory.MobileNo);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDSMSStatus), oCSDSMSHistory.Status));
                oItem.SubItems.Add(oCSDSMSHistory.CreateUserName);
                oItem.SubItems.Add(Convert.ToDateTime(oCSDSMSHistory.CreateDate).ToString("dd-MM-yyyy h:mm tt"));
                if (oCSDSMSHistory.OriginalSMS != null)
                    oItem.SubItems.Add(Convert.ToString(oCSDSMSHistory.OriginalSMS));

                oItem.SubItems.Add(Convert.ToString(oCSDSMSHistory.UpdateUserName));
                if (oCSDSMSHistory.UpdateDate != null)
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDSMSHistory.UpdateDate).ToString("dd-MM-yyyy"));
                oItem.SubItems.Add(Convert.ToString(oCSDSMSHistory.CancelUserName));
                if (oCSDSMSHistory.CancelDate != null)
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDSMSHistory.CancelDate).ToString("dd-MM-yyyy"));
                oItem.SubItems.Add(Convert.ToString(oCSDSMSHistory.CancelReason));



                oItem.Tag = oCSDSMSHistory;
                if (oCSDSMSHistory.Status == (int)Dictionary.CSDSMSStatus.Sent)
                {
                    oItem.BackColor = Color.Green;
                }
                else if (oCSDSMSHistory.Status == (int)Dictionary.CSDSMSStatus.ReSent)
                {
                    oItem.BackColor = Color.LawnGreen;
                }
                else if (oCSDSMSHistory.Status == (int)Dictionary.CSDSMSStatus.Cancel)
                {
                    oItem.BackColor = Color.Gray;
                }
                else if (oCSDSMSHistory.Status == (int)Dictionary.CSDSMSStatus.UnSend)
                {
                    oItem.BackColor = Color.Red;
                }
                else if (oCSDSMSHistory.Status == (int)Dictionary.CSDSMSStatus.ReGenerate)
                {
                    oItem.BackColor = Color.Khaki;
                }
            }
        }

        private void frmCSDSMSHistory_Load(object sender, EventArgs e)
        {
            LoadCombo();

            lblSent.BackColor = Color.Green;
            lblResent.BackColor = Color.LawnGreen;
            lblCancel.BackColor = Color.Gray;
            lblUnsend.BackColor = Color.Red;
            lblRegenerate.BackColor = Color.Khaki;
        }
        private void LoadCombo()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.CSDSMSStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.CSDSMSStatus), getEnum));
            }
            cmbStatus.SelectedIndex = 0;

            cmbSMSLength.Items.Clear();
            cmbSMSLength.Items.Add("<All>");
            cmbSMSLength.Items.Add("<=160");
            cmbSMSLength.Items.Add(">160");
            cmbSMSLength.SelectedIndex = 0;

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCSDSMSHistory.Items.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDSMSHistory oCSDSMSHistory = (CSDSMSHistory)lvwCSDSMSHistory.SelectedItems[0].Tag;
            frmCSDSMSHistoryCreate oForm = new frmCSDSMSHistoryCreate();
            oForm.ShowDialog(oCSDSMSHistory);
            if (oForm._bIsAnyAtivityDone)
            {
                DataLoadControl();
            }
        }


        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwCSDSMSHistory.Items.Count; i++)
                {
                    ListViewItem itm = lvwCSDSMSHistory.Items[i];

                    lvwCSDSMSHistory.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwCSDSMSHistory.Items.Count; i++)
                {
                    ListViewItem itm = lvwCSDSMSHistory.Items[i];

                    lvwCSDSMSHistory.Items[i].Checked = false;

                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            int nStatus = 0;
            if (lvwCSDSMSHistory.CheckedItems.Count != 0)
            {
                for (int i = 0; i < lvwCSDSMSHistory.Items.Count; i++)
                {
                    ListViewItem itm = lvwCSDSMSHistory.Items[i];
                    if (lvwCSDSMSHistory.Items[i].Checked == true)
                    {
                        CSDSMSHistory oCSDSMSHistory = (CSDSMSHistory)lvwCSDSMSHistory.Items[i].Tag;
                        if (oCSDSMSHistory.SMSText.Length <= 310)
                        {


                            if (oCSDSMSHistory.MobileNo.ToString() == "")
                            {
                                MessageBox.Show("Please Enter Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                if (oCSDSMSHistory.MobileNo.Length != 11)
                                {
                                    MessageBox.Show("Please Enter a Valid Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                Regex rgCell = new Regex("[0-9]");
                                if (rgCell.IsMatch(oCSDSMSHistory.MobileNo.ToString()))
                                {
                                    if (oCSDSMSHistory.ServerType == (int)Dictionary.SMSServerType.OwnServer)
                                    {
                                        CSDSMS oCSDSMS = new CSDSMS();
                                        oCSDSMS.SMSTextT = oCSDSMSHistory.SMSText;
                                        oCSDSMS.SingleMobileNo = oCSDSMSHistory.MobileNo;
                                        oCSDSMS.SubmittedBy = Utility.UserId.ToString();
                                        oCSDSMS.AddToServer();

                                        if (oCSDSMSHistory.Status == (int)Dictionary.CSDSMSStatus.Sent)
                                        {
                                            nStatus = (int)Dictionary.CSDSMSStatus.ReSent;
                                        }
                                        else
                                        {
                                            nStatus = (int)Dictionary.CSDSMSStatus.Sent;
                                        }
                                        oCSDSMSHistory.StatusUpdate(nStatus);

                                        oCSDSMSHistory.SendUserID = Utility.UserId;
                                        oCSDSMSHistory.SendDate = DateTime.Now;
                                        oCSDSMSHistory.SendStatusUpdate();

                                        nCount++;
                                    }
                                    else if (oCSDSMSHistory.ServerType == (int)Dictionary.SMSServerType.ThirdPartyServer)
                                    {
                                        _oSMSMaker = new SMSMaker();

                                        bool IsSend = _oSMSMaker.IntegrateWithAPI(oCSDSMSHistory.ID, oCSDSMSHistory.MobileNo, oCSDSMSHistory.SMSText);
                                        if (IsSend)
                                        {
                                            if (oCSDSMSHistory.Status == (int)Dictionary.CSDSMSStatus.Sent)
                                            {
                                                nStatus = (int)Dictionary.CSDSMSStatus.ReSent;
                                            }
                                            else
                                            {
                                                nStatus = (int)Dictionary.CSDSMSStatus.Sent;
                                            }
                                            oCSDSMSHistory.StatusUpdate(nStatus);
                                            oCSDSMSHistory.SendUserID = Utility.UserId;
                                            oCSDSMSHistory.SendDate = DateTime.Now;
                                            oCSDSMSHistory.SendStatusUpdate();
                                        }
                                        else
                                        {
                                            MessageBox.Show("SMS fail to send!! Please check Mobile No..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        nCount++;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Enter a Valid Mobile Number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                            }

                        }
                        else
                        {
                            MessageBox.Show("SMS Length Must be '<=310'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }

                }
                if (nCount != 0)
                {
                    MessageBox.Show("Sent Successfully ", "Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }

            }
            else
            {
                MessageBox.Show("Please Check Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwCSDSMSHistory.Items.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CSDSMSHistory oCSDSMSHistory = (CSDSMSHistory)lvwCSDSMSHistory.SelectedItems[0].Tag;
            frmCSDSMSCancel oForm = new frmCSDSMSCancel();
            oForm.ShowDialog(oCSDSMSHistory);
            if (oForm._bIsAnyActivity)
            {
                DataLoadControl();
            }

        }


    }
}