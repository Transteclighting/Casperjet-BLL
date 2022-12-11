using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmSMSReGenerate : Form
    {
        public CSDSMS oCSDSMS;

        public frmSMSReGenerate()
        {
            InitializeComponent();
        }

        public void ShowDialog(CSDSMS oCSDSMS)
        {
            this.Tag = oCSDSMS;
            lblSMSCode.Text = oCSDSMS.SMSCode;
            lblSMSID.Text = oCSDSMS.SMSID.ToString();
            txtReGenReason.Text = oCSDSMS.ReGenReqReason.ToString();
            
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation 

            if (txtReGenReason.Text == "")
            {
                MessageBox.Show("Should be entered Re-Generate Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {

            CSDSMS oCSDSMS = (CSDSMS)this.Tag;


            oCSDSMS.ReGenReqReason = txtReGenReason.Text;
            oCSDSMS.SMSID = oCSDSMS.SMSID;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oCSDSMS.ReGenerate();

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Re-Generate Request Accepted", "Re-Generate", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}