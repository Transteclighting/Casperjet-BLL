using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO;
using TEL.SMS.BO.BE ;
using TEL.SMS.BO.DA;


namespace TEL.SMS.UI.Win
{
    public partial class frmSMSMessages : Form
    {
        public frmSMSMessages()
        {
            InitializeComponent();
        }

        private void frmSMSMessages_Load(object sender, EventArgs e)
        {
            refreshComboStatus();
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today.AddDays(-15);
            this.WindowState = FormWindowState.Maximized;
        }

        private void refreshComboStatus()
        {
            //Clear and Populate combo.
            cboMessageStatus.Items.Clear();
            cboMessageStatus.Items.Add("<ALL Status>");

            foreach (string sStatus in Enum.GetNames(typeof(SMSMessageStatus)))
            {
                cboMessageStatus.Items.Add(sStatus);
            }
 
            //Select first item in the list.
            if (cboMessageStatus.Items.Count > 0)
            {
                cboMessageStatus.SelectedIndex = 1;

            }
        }

        private void refreshList()
        {
            string sUserGroupName = Utility.GetUserGroupName();
            //Get All the mobiles.
            DSSMSMessage oDSSMSMessage = new DSSMSMessage();
            DASMSMessage oDASMSMessage = new DASMSMessage();
            DateMessage nDateType = DateMessage.DateMessage;
            DBController.Instance.OpenNewConnection();
            if (cboMessageStatus.SelectedIndex == 0)
            {
                if (sUserGroupName == "All")
                {
                    oDASMSMessage.GetSMSMessagesAll(oDSSMSMessage,dateTimePicker1.Value,dateTimePicker2.Value,nDateType);
                }
                else
                {
                    oDASMSMessage.GetSMSMessages(oDSSMSMessage, sUserGroupName);
                }
            }
            else
            {
                if (sUserGroupName == "All")
                {
                    oDASMSMessage.GetSMSMessages(oDSSMSMessage, (SMSMessageStatus)cboMessageStatus.SelectedIndex - 1,dateTimePicker1.Value,dateTimePicker2.Value,nDateType);
                }
                else
                {
                    oDASMSMessage.GetSMSMessages(oDSSMSMessage, (SMSMessageStatus)cboMessageStatus.SelectedIndex - 1, sUserGroupName);
                }
            }

            DBController.Instance.CloseConnection();

            //Clear and Populate list.
            lvwSMSMessage.Items.Clear();
            foreach (DSSMSMessage.SMSMessageRow oSMSMessageRow in oDSSMSMessage.SMSMessage)
            {
                ListViewItem oItem = lvwSMSMessage.Items.Add(oSMSMessageRow.RequestDate.ToString() );
                if (oSMSMessageRow.SMSType == (long)SMSMessageType.Group)
                {
                    oItem.SubItems.Add("Group-> " + oSMSMessageRow.SMSText);
                }
                else 
                {
                    oItem.SubItems.Add(oSMSMessageRow.SingleMobileNo + "-> " + oSMSMessageRow.SMSText);
                }
                oItem.SubItems.Add(((SMSMessageType)oSMSMessageRow.SMSType).ToString());
                oItem.SubItems.Add(((SMSMessageStatus)oSMSMessageRow.Status).ToString());
                oItem.SubItems.Add(oSMSMessageRow.SubmittedBy);
                oItem.SubItems.Add("S: " + oSMSMessageRow.SuccessCount.ToString() + ", F: " + oSMSMessageRow.FailCount.ToString());
                oItem.Tag = oSMSMessageRow;
            }

            //Select first item in the list.
            //if (lvwSMSMessage.Items.Count > 0)
            //{
            //    lvwSMSMessage.Items[0].Selected = true;
            //    lvwSMSMessage.Focus();
            //}
        }

        private void cboMessageStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshList();
            btnApproved.Enabled = (cboMessageStatus.SelectedIndex == ((int)SMSMessageStatus.Submitted) + 1);
            btnCancelled.Enabled = btnApproved.Enabled; 
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            DASMSMessage oDASMSMessage = new DASMSMessage();
            try
            {
                foreach (ListViewItem oItem in lvwSMSMessage.CheckedItems)
                {

                    DBController.Instance.BeginNewTransaction();
                    oDASMSMessage.UpdateStatus(((DSSMSMessage.SMSMessageRow)oItem.Tag).SMSMessageID, SMSMessageStatus.Approved);
                    DBController.Instance.CommitTransaction();
                    refreshList();
                }
            }
            catch (Exception Ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Failed to update. " + Ex.Message);
            }
            

        }

        private void btnCancelled_Click(object sender, EventArgs e)
        {
            DASMSMessage oDASMSMessage = new DASMSMessage();
            try
            {
                foreach (ListViewItem oItem in lvwSMSMessage.CheckedItems)
                {

                    DBController.Instance.BeginNewTransaction();
                    oDASMSMessage.UpdateStatus(((DSSMSMessage.SMSMessageRow)oItem.Tag).SMSMessageID, SMSMessageStatus.Cancelled);
                    DBController.Instance.CommitTransaction();
                    refreshList();
                }
            }
            catch (Exception Ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Failed to update. " + Ex.Message);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //If no item is selected from the list.
            if (lvwSMSMessage.SelectedItems.Count == 0)
            {
                return;
            }

            DSSMSMessage.SMSMessageRow oSelectedMessage= (DSSMSMessage.SMSMessageRow)lvwSMSMessage.SelectedItems[0].Tag;

            DSSMSMessage oDSSMSMessage = new DSSMSMessage();
            DSSMSMessage.SMSMessageRow oRow = oDSSMSMessage.SMSMessage.NewSMSMessageRow();
            oRow.SMSMessageID= oSelectedMessage.SMSMessageID;
            oDSSMSMessage.SMSMessage.AddSMSMessageRow(oRow);
            oDSSMSMessage.AcceptChanges();

            switch ((SMSMessageType)oSelectedMessage.SMSType)
            {
                case SMSMessageType.Group:
                    frmSMSMessageForGroup ofrmMessageGroup = new frmSMSMessageForGroup();
                    ofrmMessageGroup.ShowDialog(oDSSMSMessage);
                    break;
                case SMSMessageType.Individual:
                    frmSMSMessageForSingle ofrmMessageSingle = new frmSMSMessageForSingle();
                    ofrmMessageSingle.ShowDialog(oDSSMSMessage);
                    break;
            }
            refreshList();		

        }

        private void tmrSMSMessages_Tick(object sender, EventArgs e)
        {
            refreshList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    short nSMSFormat=1;
        //    short nCommPort=1;
        //    string sCommSettings = "115200,n,8,1";
        //    string sDefaultPrefix="+88";
        //    int nRefreshSignalInterval=6000;
        //    string sServiceCenterNumber="0170000600";

        //    SMSGateway.set_SMSFormat(ref nSMSFormat);
        //    SMSGateway.set_CommPort(ref nCommPort);
        //    SMSGateway.set_CommSettings(ref sCommSettings);
        //    SMSGateway.set_DefaultPrefix(ref sDefaultPrefix);
        //    SMSGateway.set_RefreshSignalInterval(ref nRefreshSignalInterval);
        //    SMSGateway.set_ServiceCenterNumber(ref sServiceCenterNumber);

        //    SMSGateway.Connect();
        //    SMSGateway.IniGateway();
        //    SMSGateway.SendSMS("01711404598", "Hello TEL!");
        //    SMSGateway.Disconnect();
        //}
    }
}