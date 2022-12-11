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

namespace CJ.Win
{
    public partial class frmSMSMessage : Form
    {
        public CSDSMS oCSDSMS;

        public frmSMSMessage()
        {
            InitializeComponent();
        }

        public void ShowDialog(CSDSMS oCSDSMS)
        {
            this.Tag = oCSDSMS;

            lblSMSCode.Text = oCSDSMS.SMSCode;
            lblSMSID.Text = oCSDSMS.SMSID.ToString();
            txtSMSText.Text = oCSDSMS.SMSText;
            txtMobile.Text = oCSDSMS.MobileNo;


            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation 

            if (txtSMSText.Text == "")
            {
                MessageBox.Show("SMS Should not Null", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("Please Enter Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (txtMobile.Text.Length != 11)
                {
                    MessageBox.Show("Please Enter a Valid Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtMobile.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Enter a Valid Mobile Number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            
            }
            //Important
            //------------------------------------------------------------------
            //if (txtMailID.Text != "")
            //{
            //    Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
            //    Match m = emailregex.Match(txtMailID.Text);
            //    if (!m.Success)
            //    {
            //        MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtMailID.Focus();
            //        return false;
            //    }
            //}
            //---------------------------------------------------------------------

        //         if (System.Text.RegularExpressions.Regex.IsMatch("[^0-9]", textBox1.Text))
        //{
        //    MessageBox.Show("Please enter only numbers.");
        //    textBox1.Text.Remove(textBox1.Text.Length - 1);
        //}


            //||txtMobile.Text != "^d*[0-9]*(|.\d*[0-9]|,\d*[0-9])?$"

            #endregion

            return true;
        }

        private void Save()
        {

            CSDSMS oCSDSMS = (CSDSMS)this.Tag;

            oCSDSMS.SMSText = txtSMSText.Text;
            oCSDSMS.MobileNo = txtMobile.Text;
            oCSDSMS.SMSCode = oCSDSMS.SMSCode;
            oCSDSMS.Status = oCSDSMS.Status;
            oCSDSMS.SMSID = oCSDSMS.SMSID;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oCSDSMS.Edit();

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Edit Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Refresh();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void txtSMSText_TextChanged(object sender, EventArgs e)
        {
            lblSMSLenth.Text = txtSMSText.Text.Length.ToString();

            if (txtSMSText.Text.Length <= 160)
            {
                lblSMSLenth.ForeColor = Color.Green;
            }
            else
            {
                lblSMSLenth.ForeColor = Color.Red;
            }
        }


    }
}