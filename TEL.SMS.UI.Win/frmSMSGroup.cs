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
    public partial class frmSMSGroup : Form
    {
        public frmSMSGroup()
        {
            InitializeComponent();
        }
        public void ShowDialog(DSSMSGroup oDSSMSGroup)
        {
            DASMSGroup oDASMSGroup = new DASMSGroup();
            oDASMSGroup.GetSMSGroup(oDSSMSGroup);

            this.Tag = oDSSMSGroup;
            this.txtSMSGroupName.Text = oDSSMSGroup.SMSGroup[0].SMSGroupName;
            this.ShowDialog();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Check whether add new or modify
            if (this.Tag == null)
            {
                //Add new SMSGroup
                DSSMSGroup oDSSMSGroup = new DSSMSGroup();
                DSSMSGroup.SMSGroupRow oSMSGroup = oDSSMSGroup.SMSGroup.NewSMSGroupRow();

                oSMSGroup.SMSGroupName = this.txtSMSGroupName.Text;

                oDSSMSGroup.SMSGroup.AddSMSGroupRow(oSMSGroup);
                oDSSMSGroup.AcceptChanges();

                DASMSGroup oDASMSGroup = new DASMSGroup();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDASMSGroup.Insert(oDSSMSGroup);
                    DBController.Instance.CommitTransaction();
                    //if (oDSSMSGroup.HasErrors)
                    //{
                    //    setError(oDSSMSGroup.SMSGroup);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                //Modify SMSGroup
                DSSMSGroup oDSSMSGroup = (DSSMSGroup)this.Tag;
                oDSSMSGroup.SMSGroup[0].SMSGroupName = this.txtSMSGroupName.Text;
                oDSSMSGroup.AcceptChanges();

                DASMSGroup oDASMSGroup = new DASMSGroup();
                DBController.Instance.BeginNewTransaction();
                oDASMSGroup.Update(oDSSMSGroup);
                DBController.Instance.CommitTransaction();
            }
            this.Close();
        }

        private void frmSMSGroup_Load(object sender, EventArgs e)
        {
            //Check whether add new or modify
            if (this.Tag == null)
            {
                this.Text = "Add new SMSGroup";
            }
            else
            {
                this.Text = "Modify SMSGroup";
            }
        }

        private void txtSMSGroupName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSMSGroupCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSMSGroupCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='\b')
            {
                return;

            }
            
            
            else if (char.IsNumber(e.KeyChar) == false)
            {
                e.Handled = true;
            }
            
        }

        private void txtSMSGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar =='\b')
            {
                return;

            }
            
            
            
            else if (char.IsNumber(e.KeyChar)== true )
            {
                e.Handled = true;
            }
            

        
        }
    }
}