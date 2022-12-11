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
    public partial class frmSMSGroupPerson : Form
    {
        //private DSPerson _oDSPerson;



        public frmSMSGroupPerson()
        {
            InitializeComponent();
        }
        public void ShowDialog(DSSMSGroup oDSSMSGroup)
        {
            DASMSGroup oDASMSGroup = new DASMSGroup();
            oDASMSGroup.GetSMSGroup(oDSSMSGroup);

            this.Tag = oDSSMSGroup;
            this.txtSMSGroupName.Text = oDSSMSGroup.SMSGroup[0].SMSGroupName;
            refreshList();
            this.ShowDialog();

        }

        private void refreshList()
        {
            refreshAvailableList();
            refreshSelectedList();
        }

        private void refreshAvailableList()
        {
            //Get All the mobiles.
            DSPerson oDSPerson = new DSPerson();
            DASMSGroup oDASMSGroup = new DASMSGroup();
            //DAPerson oDAPerson = new DAPerson();

            DBController.Instance.OpenNewConnection();
            oDASMSGroup.GetPersonsAvailable(oDSPerson, ((DSSMSGroup)this.Tag).SMSGroup[0].SMSGroupID);
            //oDAPerson.GetAllPersons(oDSPerson);
            DBController.Instance.CloseConnection();

            //Clear and Populate list.
            lvwPersonsAvailable.Items.Clear();

            DataRow[] oFoundRow = oDSPerson.Person.Select("PersonName Like '%" + txtPersonNameLike.Text.Trim() + "%'");

            foreach (DSPerson.PersonRow oPersonRow in oFoundRow)
                {
                    ListViewItem oItem = lvwPersonsAvailable.Items.Add(oPersonRow.PersonCode);
                    oItem.SubItems.Add(oPersonRow.PersonName);
                    oItem.SubItems.Add(oPersonRow.MobileNo);
                    oItem.Tag = oPersonRow;
                }


            //foreach (DSPerson.PersonRow oPersonRow in oDSPerson.Person)
            //{
            //    ListViewItem oItem = lvwPersonsAvailable.Items.Add(oPersonRow.PersonCode);
            //    oItem.SubItems.Add(oPersonRow.PersonName);
            //    oItem.SubItems.Add(oPersonRow.MobileNo);
            //    oItem.Tag = oPersonRow;
            //}

            label1.Text = "Persons Available (" + oDSPerson.Person.Count.ToString() + ")";
            label1.Refresh();
            ////Select first item in the list.
            //if (lvwPersonsAvailable.Items.Count > 0)
            //{
            //    lvwPersonsAvailable.Items[0].Selected = true;
            //    lvwPersonsAvailable.Focus();
            //}
        }

        private void refreshSelectedList()
        {
            //Get All the mobiles.
            DSPerson oDSPerson = new DSPerson();
            DASMSGroup oDASMSGroup = new DASMSGroup();

            DBController.Instance.OpenNewConnection();
            oDASMSGroup.GetPersonsSelected(oDSPerson, ((DSSMSGroup)this.Tag).SMSGroup[0].SMSGroupID);
            DBController.Instance.CloseConnection();

            //Clear and Populate list.
            lvwPersonsSelected.Items.Clear();
            foreach (DSPerson.PersonRow oPersonRow in oDSPerson.Person)
            {
                ListViewItem oItem = lvwPersonsSelected.Items.Add(oPersonRow.PersonCode);
                oItem.SubItems.Add(oPersonRow.PersonName);
                oItem.SubItems.Add(oPersonRow.MobileNo);
                oItem.Tag = oPersonRow;
            }
            label3.Text = "Persons Selected (" + oDSPerson.Person.Count.ToString() + ")";
            label3.Refresh();
            ////Select first item in the list.
            //if (lvwPersonsSelected.Items.Count > 0)
            //{
            //    lvwPersonsSelected.Items[0].Selected = true;
            //    lvwPersonsSelected.Focus();
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwPersonsAvailable.SelectedItems.Count <= 0) { return; }
            //Add new SMSGroup Person
            DSSMSGroup oDSSMSGroup = new DSSMSGroup();
            foreach (ListViewItem oItem in lvwPersonsAvailable.SelectedItems)
            {
                DSSMSGroup.SMSGroupPersonRow oSMSGroupPerson = oDSSMSGroup.SMSGroupPerson.NewSMSGroupPersonRow();
                oSMSGroupPerson.SMSGroupID = ((DSSMSGroup)this.Tag).SMSGroup[0].SMSGroupID;
                oSMSGroupPerson.PersonID = ((DSPerson.PersonRow)oItem.Tag).MobileID;
                oDSSMSGroup.SMSGroupPerson.AddSMSGroupPersonRow(oSMSGroupPerson);
            }
            oDSSMSGroup.AcceptChanges();

            DASMSGroup oDASMSGroup = new DASMSGroup();
            try
            {
                DBController.Instance.BeginNewTransaction();
                oDASMSGroup.AddPerson(oDSSMSGroup);
                DBController.Instance.CommitTransaction();
                refreshList();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvwPersonsSelected.SelectedItems.Count <= 0) { return; }

            //Remove Person from SMSGroup 
            DSSMSGroup oDSSMSGroup = new DSSMSGroup();
            foreach (ListViewItem oItem in lvwPersonsSelected.SelectedItems)
            {
                DSSMSGroup.SMSGroupPersonRow oSMSGroupPerson = oDSSMSGroup.SMSGroupPerson.NewSMSGroupPersonRow();
                oSMSGroupPerson.SMSGroupID = ((DSSMSGroup)this.Tag).SMSGroup[0].SMSGroupID;
                oSMSGroupPerson.PersonID = ((DSPerson.PersonRow)oItem.Tag).MobileID;
                oDSSMSGroup.SMSGroupPerson.AddSMSGroupPersonRow(oSMSGroupPerson);
            }
            oDSSMSGroup.AcceptChanges();

            DASMSGroup oDASMSGroup = new DASMSGroup();
            try
            {
                DBController.Instance.BeginNewTransaction();
                oDASMSGroup.RemovePerson(oDSSMSGroup);
                DBController.Instance.CommitTransaction();
                refreshList();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void frmSMSGroupPerson_Load(object sender, EventArgs e)
        {

        }

        private void txtPersonNameLike_TextChanged(object sender, EventArgs e)
        {
            refreshAvailableList();
            this.txtPersonNameLike.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DSPerson oDSPerson = new DSPerson();
            DASMSGroup oDASMSGroup = new DASMSGroup();

            DBController.Instance.OpenNewConnection();
            oDASMSGroup.GetPersonsAvailable(oDSPerson, ((DSSMSGroup)this.Tag).SMSGroup[0].SMSGroupID);
            DBController.Instance.CloseConnection();

            lvwPersonsSelected.Items.Clear();
            DataRow[] oFoundRow = oDSPerson.Person.Select("PersonName Like '%" + txtName.Text.Trim() + "%'");
            foreach (DSPerson.PersonRow oPersonRow in oFoundRow)
            {
                ListViewItem oItem = lvwPersonsSelected.Items.Add(oPersonRow.PersonCode);
                oItem.SubItems.Add(oPersonRow.PersonName);
                oItem.SubItems.Add(oPersonRow.MobileNo);
                oItem.Tag = oPersonRow;
            }
            label1.Text = "Persons Available (" + oDSPerson.Person.Count.ToString() + ")";
            label1.Refresh();
            this.txtName.Focus();
        }
     }
}