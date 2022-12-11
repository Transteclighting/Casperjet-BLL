using System;
using System.Collections;
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
    public partial class frmPersons : Form
    {
        public frmPersons()
        {
            InitializeComponent();
        }

        private void frmPersons_Load(object sender, EventArgs e)
        {
            refreshList();
        }

        private void refreshList()
        {

            //Get All the mobiles.***
            DSPerson oDSPerson = new DSPerson();
            DAPerson oDAPerson = new DAPerson();
            try
            {
                DBController.Instance.OpenNewConnection();
                oDAPerson.GetAllPersons(oDSPerson);
                DBController.Instance.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin.", "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clear and Populate list.
            lvwPerson.Items.Clear();
            //foreach (DSPerson.PersonRow oPersonRow in oDSPerson.Person)
            //{
            //    ListViewItem oItem = lvwPerson.Items.Add(oPersonRow.PersonCode);
            //    oItem.SubItems.Add(oPersonRow.PersonName);
            //    oItem.SubItems.Add(oPersonRow.MobileNo);
            //    oItem.Tag = oPersonRow;
            //}****
            string sQuery = string.Empty;
            if (txtPersonNameLike.Text.Trim() != "")
            {
                sQuery = "PersonName Like '%" + txtPersonNameLike.Text.Trim() + "%'";
            }
            else if (txtMobliNoLike.Text.Trim() != "")
            {
                sQuery = "MobileNo Like '%" + txtMobliNoLike.Text.Trim() + "%'";
            }
            else if(txtPersonNameLike.Text.Trim() != "" && txtMobliNoLike.Text.Trim() != "")
            {
                sQuery = "PersonName Like '%" + txtPersonNameLike.Text.Trim() + "%'" + "AND MobileNo Like '%" + txtMobliNoLike.Text.Trim() + "%'";
            }
             DataRow[] oFoundRow = oDSPerson.Person.Select(sQuery);//"PersonName Like '%" + txtPersonNameLike.Text.Trim() + "%'");
             
             //DSPerson oPerson = new DSPerson();
             //oPerson.Merge(oFoundRow);
             //oPerson.AcceptChanges();
            foreach (DSPerson.PersonRow oPersonRow in oFoundRow)
            {
                ListViewItem oItem = lvwPerson.Items.Add(oPersonRow["PersonCode"].ToString());
                oItem.SubItems.Add(oPersonRow["PersonName"].ToString());
                oItem.SubItems.Add(oPersonRow["MobileNo"].ToString());
                oItem.Tag = oPersonRow;
            }

            this.Text = "Persons " + lvwPerson.Items.Count.ToString();

            //Select first item in the list.
            if (lvwPerson.Items.Count > 0)
            {
                lvwPerson.Focus();
                //lvwPerson.Items[0].Selected = true;
            }
        
         this.lvwPerson.ColumnClick += new ColumnClickEventHandler(columnClick);
    }

        

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerson ofrmPerson = new frmPerson();
            ofrmPerson.ShowDialog();
            refreshList();
        }

        private void modifyPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If no item is selected from the list.
            if (lvwPerson.SelectedItems.Count == 0)
            {
                return;
            }

            DSPerson.PersonRow oSelectedPerson = (DSPerson.PersonRow)lvwPerson.SelectedItems[0].Tag;

            DSPerson oDSPerson = new DSPerson();
            DSPerson.PersonRow oRow = oDSPerson.Person.NewPersonRow();
            oRow.MobileID = oSelectedPerson.MobileID;
            oDSPerson.Person.AddPersonRow(oRow);
            oDSPerson.AcceptChanges();

            frmPerson ofrmPerson = new frmPerson();
            ofrmPerson.ShowDialog(oDSPerson);
            refreshList();		

        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwPerson.SelectedItems.Count == 0)
            {
                return;
            }

            DSPerson.PersonRow oSelectedPerson = (DSPerson.PersonRow)lvwPerson.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete " + oSelectedPerson.PersonCode  + "?", "Confirm Mobile SIM delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                DSPerson oDSPerson = new DSPerson();
                DAPerson oBOPerson = new DAPerson();
                DSPerson.PersonRow oRow = oDSPerson.Person.NewPersonRow();
                oRow.MobileID = oSelectedPerson.MobileID;
                oDSPerson.Person.AddPersonRow(oRow);
                oDSPerson.AcceptChanges();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBOPerson.Delete(oDSPerson);
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

        private void lvwPerson_DoubleClick(object sender, EventArgs e)
        {
            modifyPersonToolStripMenuItem_Click(sender, e);
        }

        private void lvwPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refreshList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPerson frmPerEnt = new frmPerson();
            frmPerEnt.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmPerEnt.MaximizeBox = false;
            frmPerEnt.ShowDialog();
            this.refreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPerson.SelectedItems.Count == 0)
            {
                return;
            }

            DSPerson.PersonRow oSelectedPerson = (DSPerson.PersonRow)lvwPerson.SelectedItems[0].Tag;

            DSPerson oDSPerson = new DSPerson();
            DSPerson.PersonRow oRow = oDSPerson.Person.NewPersonRow();
            oRow.MobileID = oSelectedPerson.MobileID;
            oDSPerson.Person.AddPersonRow(oRow);
            oDSPerson.AcceptChanges();

            frmPerson ofrmPerson = new frmPerson();
            ofrmPerson.ShowDialog(oDSPerson);
            refreshList();		

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwPerson.SelectedItems.Count == 0)
            {
                return;
            }

            DSPerson.PersonRow oSelectedPerson = (DSPerson.PersonRow)lvwPerson.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete " + oSelectedPerson.PersonCode + "?", "Confirm Mobile SIM delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                DSPerson oDSPerson = new DSPerson();
                DAPerson oBOPerson = new DAPerson();
                DSPerson.PersonRow oRow = oDSPerson.Person.NewPersonRow();
                oRow.MobileID = oSelectedPerson.MobileID;
                oDSPerson.Person.AddPersonRow(oRow);
                oDSPerson.AcceptChanges();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBOPerson.Delete(oDSPerson);
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

        private void txtBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwPerson_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lvwPerson.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }
        private void columnClick(object o, ColumnClickEventArgs e)
        {
            // Set the ListViewItemSorter property to a new ListViewItemComparer 
            // object. Setting this property immediately sorts the 
            // ListView using the ListViewItemComparer object.
            this.lvwPerson.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void txtPersonNameLike_TextChanged(object sender, EventArgs e)
        {
            refreshList();
            this.txtPersonNameLike.Focus();
        }

        private void txtMobliNoLike_TextChanged(object sender, EventArgs e)
        {
            refreshList();
            this.txtMobliNoLike.Focus();           
        }

        
    }
}