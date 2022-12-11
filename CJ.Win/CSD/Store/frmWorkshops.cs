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
    public partial class frmWorkshops : Form
    {
        public frmWorkshops()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {

            Workshops oWorkshops = new Workshops();

            lvwWorkshops.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oWorkshops.Refresh();

            this.Text = "Total " + "[" + oWorkshops.Count + "]";
            foreach (Workshop oWorkshop in oWorkshops)
            {
                ListViewItem oItem = lvwWorkshops.Items.Add(oWorkshop.WorkshopTypeID.ToString());
                oItem.SubItems.Add(oWorkshop.Name.ToString());
                if (oWorkshop.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
                {
                    oItem.SubItems.Add("True");
                }
                else
                {
                    oItem.SubItems.Add("False");
                }
                oItem.SubItems.Add(oWorkshop.User.Username.ToString());
                oItem.SubItems.Add(oWorkshop.CreateDate.ToString());

                oItem.Tag = oWorkshop;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmWorkshop oForm = new frmWorkshop();
            oForm.ShowDialog();
            DataLoadControl();
        
        }

        private void frmWorkshops_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwWorkshops.SelectedItems.Count != 0)
            {

                Workshop oWorkshop = (Workshop)lvwWorkshops.SelectedItems[0].Tag;

                frmWorkshop oForm = new frmWorkshop();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Workshop Type";
                oForm.ShowDialog(oWorkshop);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwWorkshops_DoubleClick(object sender, EventArgs e)
        {
            if (lvwWorkshops.SelectedItems.Count != 0)
            {

                Workshop oWorkshop = (Workshop)lvwWorkshops.SelectedItems[0].Tag;

                frmWorkshop oForm = new frmWorkshop();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Workshop Type";
                oForm.ShowDialog(oWorkshop);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        
    }
}