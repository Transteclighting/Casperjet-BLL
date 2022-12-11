// <summary>
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Oct 02, 2014
// Description: Forms for Serviceable Product/Item Groups (including Charges).
// Modify Person And Date:
// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmCSDProductGroups : Form
    {
        private CSDProductGroups _oCSDProductGroups;
 
        public frmCSDProductGroups()
        {
            InitializeComponent();
        }

        private void frmCSDProductGroups_Load(object sender, EventArgs e)
        {

            LoadData();
        }
        private void LoadData()
        {
            _oCSDProductGroups = new CSDProductGroups();
            
            lvwCSDProductGroups.Items.Clear();
            DBController.Instance.OpenNewConnection();


            _oCSDProductGroups.Refresh();

            this.Text = "Serviceable Product/Item Groups (including Charges)" + "[" + _oCSDProductGroups.Count + "]";
            
            foreach (CSDProductGroup oCSDProductGroup in _oCSDProductGroups)
            {
                ListViewItem oItem = lvwCSDProductGroups.Items.Add(oCSDProductGroup.CSDProductGroupID.ToString());
                oItem.SubItems.Add(oCSDProductGroup.CSDProductGroupName);
                oItem.Tag = oCSDProductGroup;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCSDProductGroup ofrmCSDProductGroup = new frmCSDProductGroup();
            ofrmCSDProductGroup.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCSDProductGroups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Serviceable Item Group to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDProductGroup oCSDProductGroup = (CSDProductGroup)lvwCSDProductGroups.SelectedItems[0].Tag;
            frmCSDProductGroup ofrmCSDProductGroup = new frmCSDProductGroup();
            ofrmCSDProductGroup.ShowDialog(oCSDProductGroup);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwCSDProductGroups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Serviceable Item Group to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDProductGroup oCSDProductGroup = (CSDProductGroup)lvwCSDProductGroups.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Serviceable Item Group : " + oCSDProductGroup.CSDProductGroupID + " ? ", "Confirm Geo Location Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDProductGroup.DeleteTechCharges();
                    oCSDProductGroup.DeleteServiceCharges();
                    oCSDProductGroup.Delete();
                    
                    
                    
                    
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}