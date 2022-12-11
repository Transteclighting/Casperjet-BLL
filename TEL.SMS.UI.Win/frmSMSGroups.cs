using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE ;
using TEL.SMS.BO.DA;


namespace TEL.SMS.UI.Win
{
    public partial class frmSMSGroups : Form
    {
        public frmSMSGroups()
        {
            InitializeComponent();
        }

        private void frmSMSGroups_Load(object sender, EventArgs e)
        {
            refreshList();
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

        private void addNewSMSGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSGroup ofrmSMSGroup = new frmSMSGroup();
            ofrmSMSGroup.ShowDialog();
            refreshList();
        }

        private void modifySMSGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If no item is selected from the list.
            if (lvwSMSGroup.SelectedItems.Count == 0)
            {
                return;
            }

            DSSMSGroup.SMSGroupRow oSelectedSMSGroup = (DSSMSGroup.SMSGroupRow)lvwSMSGroup.SelectedItems[0].Tag;

            DSSMSGroup oDSSMSGroup = new DSSMSGroup();
            DSSMSGroup.SMSGroupRow oRow = oDSSMSGroup.SMSGroup.NewSMSGroupRow();
            oRow.SMSGroupID = oSelectedSMSGroup.SMSGroupID;
            oDSSMSGroup.SMSGroup.AddSMSGroupRow(oRow);
            oDSSMSGroup.AcceptChanges();

            frmSMSGroup ofrmSMSGroup = new frmSMSGroup();
            ofrmSMSGroup.ShowDialog(oDSSMSGroup);
            refreshList();		

        }

        private void lvwSMSGroup_DoubleClick(object sender, EventArgs e)
        {
            addPersonsToolStripMenuItem_Click(sender, e);
        }

        private void addPersonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If no item is selected from the list.
            if (lvwSMSGroup.SelectedItems.Count == 0)
            {
                return;
            }

            DSSMSGroup.SMSGroupRow oSelectedSMSGroup = (DSSMSGroup.SMSGroupRow)lvwSMSGroup.SelectedItems[0].Tag;

            DSSMSGroup oDSSMSGroup = new DSSMSGroup();
            DSSMSGroup.SMSGroupRow oRow = oDSSMSGroup.SMSGroup.NewSMSGroupRow();
            oRow.SMSGroupID = oSelectedSMSGroup.SMSGroupID;
            oDSSMSGroup.SMSGroup.AddSMSGroupRow(oRow);
            oDSSMSGroup.AcceptChanges();

            frmSMSGroupPerson ofrmSMSGroup = new frmSMSGroupPerson();
            ofrmSMSGroup.ShowDialog(oDSSMSGroup);
        }

        private void deleteSMSGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwSMSGroup.SelectedItems.Count == 0)
            {
                return;
            }

            DSSMSGroup.SMSGroupRow oSelectedSMSGroup = (DSSMSGroup.SMSGroupRow)lvwSMSGroup.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete " + oSelectedSMSGroup.SMSGroupName  + "?", "Confirm Mobile SIM delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                DSSMSGroup oDSSMSGroup = new DSSMSGroup();
                DASMSGroup oBOSMSGroup = new DASMSGroup();
                DSSMSGroup.SMSGroupRow oRow = oDSSMSGroup.SMSGroup.NewSMSGroupRow();
                oRow.SMSGroupID = oSelectedSMSGroup.SMSGroupID;
                oDSSMSGroup.SMSGroup.AddSMSGroupRow(oRow);
                oDSSMSGroup.AcceptChanges();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBOSMSGroup.Delete(oDSSMSGroup);
                    DBController.Instance.CommitTransaction();
                    refreshList();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!");
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}