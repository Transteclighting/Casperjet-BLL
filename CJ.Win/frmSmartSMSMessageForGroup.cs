using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TEL.SMS.BO;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;
//using GsmComm.PduConverter;
//using GsmComm.PduConverter.SmartMessaging;
//using GsmComm.GsmCommunication;
//using GsmComm.Interfaces;
//using GsmComm.Server;
using System.Collections.Generic;



namespace CJ.Win
{
    public partial class frmSmartSMSMessageForGroup : Form
    {
        //private GsmCommMain comm;
        public frmSmartSMSMessageForGroup()
        {
            InitializeComponent();
        }

        private void frmSmartSMSMessageForGroup_Load(object sender, EventArgs e)
        {
            if (this.Tag == null) { refreshList(); }
        }
        public void ShowDialog(DSSMSMessage oDSSMSMessage)
        {
            DASMSMessage oDASMSMessage = new DASMSMessage();
            oDASMSMessage.GetSMSMessage(oDSSMSMessage);

            this.Tag = oDSSMSMessage;
            this.txtSMSMessage.Text = oDSSMSMessage.SMSMessage[0].SMSText;
            this.dtpSubmitDate.Value = oDSSMSMessage.SMSMessage[0].RequestDate;

            refreshList();

            foreach (ListViewItem oItem in lvwSMSGroup.Items)
            {
                foreach (DSSMSMessage.SMSMessageGroupRow oRow in oDSSMSMessage.SMSMessageGroup)
                {
                    if (((DSSMSGroup.SMSGroupRow)oItem.Tag).SMSGroupID == oRow.SMSGroupID)
                    {
                        oItem.Checked = true;
                    }
                }
            }
            //Disable control
            this.dtpSubmitDate.Enabled = false;
            this.lvwSMSGroup.Enabled = false;

            this.ShowDialog();

        }

        private void refreshList()
        {
            //Get All the mobiles.
            DSSMSGroup oDSSMSGroup = new DSSMSGroup();
            DASMSGroup oDASMSGroup = new DASMSGroup();
            DBController.Instance.OpenNewConnection();
            oDASMSGroup.GetAllSMSGroups(oDSSMSGroup);
            DBController.Instance.CloseConnection();

            //Clear and Populate list.
            lvwSMSGroup.Items.Clear();
            foreach (DSSMSGroup.SMSGroupRow oSMSGroupRow in oDSSMSGroup.SMSGroup)
            {
                ListViewItem oItem = lvwSMSGroup.Items.Add(oSMSGroupRow.SMSGroupName);
                oItem.Tag = oSMSGroupRow;
            }

            //Select first item in the list.
            if (lvwSMSGroup.Items.Count > 0)
            {
                lvwSMSGroup.Items[0].Selected = true;
                lvwSMSGroup.Focus();
            }
        }

        private bool ValidateUI()
        {
            if (txtSMSMessage.TextLength <= 0)
            {
                MessageBox.Show("No message is written. Please write a message.", "Write a message");
                txtSMSMessage.Focus();
                return false;
            }

            if (lvwSMSGroup.CheckedItems.Count == 0)
            {
                MessageBox.Show("No SMS Group is selected. Please select any group.", "Select any group");
                lvwSMSGroup.Focus();
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            
                //UI Validation
                if (!ValidateUI()) { return; }

                //Check whether add new or modify
                if (this.Tag == null)
                {
                    //Add new SMS Message
                    DSSMSMessage oDSSMSMessage = new DSSMSMessage();

                    DSSMSMessage.SMSMessageRow oSMSMessage = oDSSMSMessage.SMSMessage.NewSMSMessageRow();

                    oSMSMessage.SMSText = this.txtSMSMessage.Text;
                    oSMSMessage.SMSType = (long)SMSMessageType.Group;
                    //oSMSMessage.SingleMobileNo = this.txtMobileNo.Text;
                    oSMSMessage.RequestDate = this.dtpSubmitDate.Value;
                    if (ConfigurationManager.AppSettings["AutoApproved"] == "true")
                    {
                        oSMSMessage.Status = (long)SMSMessageStatus.Approved;
                    }
                    else
                    {
                        oSMSMessage.Status = (long)SMSMessageStatus.Submitted;
                    }

                    oSMSMessage.SubmittedBy = (string)this.MdiParent.Tag;
                    oSMSMessage.UserGroupName = Utility.GetUserGroupName();
                    oDSSMSMessage.SMSMessage.AddSMSMessageRow(oSMSMessage);

                    //Add groups SMS Message
                    foreach (ListViewItem oItem in lvwSMSGroup.CheckedItems)
                    {
                        DSSMSMessage.SMSMessageGroupRow oSMSMessageGroupRow = oDSSMSMessage.SMSMessageGroup.NewSMSMessageGroupRow();

                        oSMSMessageGroupRow.SMSGroupID = ((DSSMSGroup.SMSGroupRow)oItem.Tag).SMSGroupID;
                        //oSMSMessageGroupRow.SMSMessageID = 1;
                        oDSSMSMessage.SMSMessageGroup.AddSMSMessageGroupRow(oSMSMessageGroupRow);
                    }

                    oDSSMSMessage.AcceptChanges();

                    DASMSMessage oDASMSMessage = new DASMSMessage();
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oDASMSMessage.Insert(oDSSMSMessage);
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("One group message request is successfully submmited.", "Success Message");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    DSSMSMessage oDSSMSMessage = (DSSMSMessage)this.Tag;
                    DSSMSMessage.SMSMessageRow oSMSMessage = oDSSMSMessage.SMSMessage[0];

                    oSMSMessage.SMSText = this.txtSMSMessage.Text;
                    //oSMSMessage.SMSType = (long)SMSMessageType.Individual;
                    //oSMSMessage.SingleMobileNo = this.txtMobileNo.Text;
                    //oSMSMessage.RequestDate = this.dtpSubmitDate.Value;
                    //oSMSMessage.Status = (long)SMSMessageStatus.Submitted;
                    //oSMSMessage.UserID = 1;
                    //oSMSMessage.SubmittedBy = (string)this.MdiParent.Tag;
                    //oDSSMSMessage.SMSMessage.AddSMSMessageRow(oSMSMessage);
                    oDSSMSMessage.AcceptChanges();

                    DASMSMessage oDASMSMessage = new DASMSMessage();
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oDASMSMessage.Update(oDSSMSMessage);
                        DBController.Instance.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }

                this.Close();
            }
        private void txtSMSMessage_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Message: " + txtSMSMessage.TextLength + "(1 Msg)";
        }
      
      }
  }
