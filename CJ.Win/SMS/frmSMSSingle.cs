using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;


namespace CJ.Win.SMS
{
    public partial class frmSMSSingle : Form
    {
        SMSMaker _oSMSMaker;
        SMSMessageInividualHistory _oSMSMessageInividualHistory;

        public frmSMSSingle()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _oSMSMaker = new SMSMaker();
            
            this.Cursor = Cursors.WaitCursor;
            bool IsSend = _oSMSMaker.IntegrateWithAPI(1, txtMobileNo.Text, txtMessage.Text);

            if (IsSend)
            {
                MessageBox.Show("Successfully sent....!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ADDSMSHistory();
                Clear();
               

            }
            else
            {
                MessageBox.Show("Error sending message...!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
                
            }
            
            this.Cursor = Cursors.Default;
        }
        private void ADDSMSHistory()
        {
            _oSMSMessageInividualHistory = new SMSMessageInividualHistory();

            _oSMSMessageInividualHistory.Message = txtMessage.Text;
            _oSMSMessageInividualHistory.MobileNo = txtMobileNo.Text;
            _oSMSMessageInividualHistory.SendBy = Utility.UserId;
            _oSMSMessageInividualHistory.SendDate = DateTime.Now;
            _oSMSMessageInividualHistory.Add();
            
        }

        private void Clear()
        {
            txtMessage.Text = "";
            txtMobileNo.Text = "";
        }
    }
}