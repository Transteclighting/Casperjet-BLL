using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;


namespace TEL.SMS.UI.Win
{
    public partial class frmSMSMessagesIn : Form
    {
        private bool _bRefreshList;

        public frmSMSMessagesIn()
        {
            InitializeComponent();
        }


        private void frmSMSMessagesIn_Load(object sender, EventArgs e)
        {
            _bRefreshList = false;

            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today.AddDays(-15);
            _bRefreshList = true;
            refreshList();
            this.WindowState = FormWindowState.Maximized;
        }


        private void refreshList()
        {
            string sUserGroupName = Utility.GetUserGroupName();
            //Get All the mobiles.            
            DSSMSMessageIn oDSSMSMessageIN = new DSSMSMessageIn();            
            DASMSMessageIn oDASMSMessageIn = new DASMSMessageIn();
            DateMessageIn nDateType = DateMessageIn.DateMessageIn;
            DBController.Instance.OpenNewConnection();
            
            if (sUserGroupName == "All")
              
            {
                oDASMSMessageIn.GetSMSMessagesAllIn(oDSSMSMessageIN, dateTimePicker1.Value, dateTimePicker2.Value, nDateType);   
            }
        
            else
            {                    
                oDASMSMessageIn.GetSMSMessagesIn(oDSSMSMessageIN, sUserGroupName);                     
            }
               
           
            DBController.Instance.CloseConnection();

            //Clear and Populate list.
            lvwSMSMessage.Items.Clear();
            foreach (DSSMSMessageIn.SMSInMessageRow   oSMSMessageInRow in oDSSMSMessageIN.SMSInMessage)
            {
                ListViewItem oItem = lvwSMSMessage.Items.Add(oSMSMessageInRow.ReceiveDate.ToString());
                if (oSMSMessageInRow.MessageType == (long)SMSMessageType.Group)
                {
                    oItem.SubItems.Add("Group-> " + oSMSMessageInRow.SMSText);
                }
                else
                {
                    oItem.SubItems.Add(oSMSMessageInRow.MobileNo + "-> " + oSMSMessageInRow.SMSText);
                }
                oItem.SubItems.Add(((SMSMessageType)oSMSMessageInRow.MessageType).ToString());
                oItem.SubItems.Add(((SMSMessageStatus)oSMSMessageInRow.Status).ToString());                
                //oItem.SubItems.Add("S: " + oSMSMessageInRow.SuccessCount.ToString() + ", F: " + oSMSMessageRow.FailCount.ToString());
                oItem.Tag = oSMSMessageInRow;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (_bRefreshList)
            {
                refreshList();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (_bRefreshList)
            {
                refreshList();
            }
        }


    }
}