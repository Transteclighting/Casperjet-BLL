using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;


namespace CJ.Win.CSD
{
    public partial class frmCSDHelpLine : Form
    {
        public frmCSDHelpLine()
        {
            InitializeComponent();
        }


        private void frmCSDHelpLine_Load(object sender, EventArgs e)
        {
            this.Text = "Edit CSD Help Line";
        }
        public void ShowDialog(CSDSMSHelpline oCSDSMSHelpline)
        {
            this.Tag = oCSDSMSHelpline;

            textName.Text = oCSDSMSHelpline.Name;
            textHelpline.Text = oCSDSMSHelpline.Helpline;
            textServiceTime.Text = oCSDSMSHelpline.ServiceTime;

            this.ShowDialog();
        }


        private void Save()
        {
            if (this.Tag != null)
            {
                CSDSMSHelpline oCSDSMSHelpline = (CSDSMSHelpline)this.Tag;
                oCSDSMSHelpline.Helpline = textHelpline.Text;
                oCSDSMSHelpline.ServiceTime = textServiceTime.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDSMSHelpline.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The CSD Helpline : " + oCSDSMSHelpline.Name, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }



        private bool validateUIInput()
        {
            #region Input Information Validation


            if (textHelpline.Text == "")
            {
                MessageBox.Show("Please Enter Helpline of CSD Helpline", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textHelpline.Focus();
                return false;
            }

            else if (textServiceTime.Text == "")
            {
                MessageBox.Show("Please Enter Service Time of CSD Helpline", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textServiceTime.Focus();
                return false;
            }


            #endregion

            return true;
        }

        private void btnCSDSMSHelplineSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //btnClear_Click(sender, e);
                this.Close();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
