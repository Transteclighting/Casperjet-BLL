using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TEL.SMS.BO;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;
using TEL.SMS.UI.Win;

namespace CJ.Win
{
    public partial class frmSmartSMSForSingle : Form
    {
        public frmSmartSMSForSingle()
        {
            InitializeComponent();
        }
       
        public void ShowDialog(DSSMSMessage oDSSMSMessage)
        {
            TEL.SMS.BO.DA.DASMSMessage oDASMSMessage = new DASMSMessage();
            oDASMSMessage.GetSMSMessage(oDSSMSMessage);

            this.Tag = oDSSMSMessage;
            this.txtSMSMessage.Text = oDSSMSMessage.SMSMessage[0].SMSText;
            this.txtMobileNo.Text = oDSSMSMessage.SMSMessage[0].SingleMobileNo;
            this.dtpSubmitDate.Value = oDSSMSMessage.SMSMessage[0].RequestDate;

            //Disable control
            this.dtpSubmitDate.Enabled = false;

            this.ShowDialog();

        }
        private void FrmSmartSMSForSingle_Load(object sender, EventArgs e)
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

            if (txtMobileNo.TextLength <= 0)
            {
                MessageBox.Show("No Mobile number is entered. Please write the mobile number.", "Write mobile number");
                txtMobileNo.Focus();
                return false;
            }

            return true;
        }

       

        private void txtSMSMessage_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Message: " + txtSMSMessage.TextLength + " (1 Msg)";
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
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
                int t = oSMSMessage.SMSText.Length;
                oSMSMessage.SMSType = (long)SMSMessageType.Individual;
                oSMSMessage.SingleMobileNo = this.txtMobileNo.Text;
                oSMSMessage.RequestDate = this.dtpSubmitDate.Value;
                if (ConfigurationManager.AppSettings["AutoApproved"] == "true")
                {
                    oSMSMessage.Status = (long)SMSMessageStatus.Approved;
                }
                else
                {
                    oSMSMessage.Status = (long)SMSMessageStatus.Submitted;
                }
                oSMSMessage.SubmittedBy = this.txtSMSMessage.Text;
                oSMSMessage.UserGroupName = Utility.GetUserGroupName();
                oDSSMSMessage.SMSMessage.AddSMSMessageRow(oSMSMessage);
                oDSSMSMessage.AcceptChanges();

                DASMSMessage oDASMSMessage = new DASMSMessage();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDASMSMessage.Insert(oDSSMSMessage);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("One individual message request is successfully submmited.", "Success Message");
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
                oSMSMessage.SingleMobileNo = this.txtMobileNo.Text;
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
    }
}