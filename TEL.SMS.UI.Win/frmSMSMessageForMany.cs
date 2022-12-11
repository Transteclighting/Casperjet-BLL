using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TEL.SMS.BO;
using TEL.SMS.BO.BE ;
using TEL.SMS.BO.DA;
using System.Security.Principal;

namespace TEL.SMS.UI.Win
{
    public partial class frmSMSMessageForMany : Form
    {
        public frmSMSMessageForMany()
        {
            InitializeComponent();
        }

        private void frmSMSGroups_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateUI()
        {
            if (txtSMSMessage.TextLength <= 0)
            {
                MessageBox.Show("No message is written. Please write a message.", "Write a message");
                txtSMSMessage.Focus();
                return false;
            }

            if(txtSingleMobileNo.TextLength<=0)
            {
                MessageBox.Show("No Mobile No is entered. Please write the mobile number.","Write mobile number");
                txtSingleMobileNo.Focus();
                return false;
            }
            //if (txtSingleMobileNo.TextLength > 1)
            //{
            //    MessageBox.Show("You cannot enter more mobile number.", "Write only one mobile number");
            //    txtSingleMobileNo.Focus();
            //    return false;
            //}
 

            
            if (txtMobileNo.TextLength <= 0)
            {
                MessageBox.Show("No Mobile number is entered. Please write the mobile number.", "Write mobile number");
                txtMobileNo.Focus();
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //UI Validation
            if (!ValidateUI()) { return; }

            string[] sSplit = this.txtMobileNo.Text.Split(new Char[] {',' , ';' });
            string[] ToSplit = this.txtSingleMobileNo.Text.Split(new Char[] { ',', ';' });

            //Add new SMS Message
            DSSMSMessage oDSSMSMessage = new DSSMSMessage();

            foreach (string s in sSplit)
            {
                DSSMSMessage.SMSMessageRow oSMSMessage = oDSSMSMessage.SMSMessage.NewSMSMessageRow();

                oSMSMessage.SMSText = this.txtSMSMessage.Text;
                oSMSMessage.SMSType = (long)SMSMessageType.Individual;
                oSMSMessage.SingleMobileNo = s.Trim();
                oSMSMessage.RequestDate = this.dtpSubmitDate.Value;
                if (ConfigurationManager.AppSettings["AutoApproved"] == "true")
                {
                    oSMSMessage.Status = (long)SMSMessageStatus.Approved;
                }
                else
                {
                    oSMSMessage.Status = (long)SMSMessageStatus.Submitted;
                }
                oSMSMessage.SubmittedBy = WindowsIdentity.GetCurrent().Name;      
                oSMSMessage.UserGroupName = Utility.GetUserGroupName();
                oDSSMSMessage.SMSMessage.AddSMSMessageRow(oSMSMessage);
            }

            foreach (string s in ToSplit)
            {
                DSSMSMessage.SMSMessageRow oSMSMessage = oDSSMSMessage.SMSMessage.NewSMSMessageRow();

                oSMSMessage.SMSText = this.txtSMSMessage.Text;
                oSMSMessage.SMSType = (long)SMSMessageType.Individual;
                oSMSMessage.SingleMobileNo = s.Trim();
                oSMSMessage.RequestDate = this.dtpSubmitDate.Value;
                if (ConfigurationManager.AppSettings["AutoApproved"] == "true")
                {
                    oSMSMessage.Status = (long)SMSMessageStatus.Approved;
                }
                else
                {
                    oSMSMessage.Status = (long)SMSMessageStatus.Submitted;
                }
                oSMSMessage.SubmittedBy = WindowsIdentity.GetCurrent().Name; 
                oSMSMessage.UserGroupName = Utility.GetUserGroupName();
                oDSSMSMessage.SMSMessage.AddSMSMessageRow(oSMSMessage);
            }


            oDSSMSMessage.AcceptChanges();

            DASMSMessage oDASMSMessage = new DASMSMessage();
            try
            {
                DBController.Instance.BeginNewTransaction();
                oDASMSMessage.Insert(oDSSMSMessage);
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Message request for many is successfully submmited.", "Success Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
                DBController.Instance.RollbackTransaction();
            }
            this.Close();
        }

        private void txtSMSMessage_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Message: " + txtSMSMessage.TextLength + "/160 (1 Msg)";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}