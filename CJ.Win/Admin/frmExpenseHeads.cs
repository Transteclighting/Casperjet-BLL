using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Class.Admin;

namespace CJ.Win.Admin
{
    public partial class frmExpenseHeads : Form
    {
        public frmExpenseHeads()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            VehicleExpenseHeads oVehicleExpenseHeads = new VehicleExpenseHeads();
            lvwExpanseHead.Items.Clear();           
            DBController.Instance.OpenNewConnection();
            oVehicleExpenseHeads.Refresh();
            this.Text = " VehicleExpenseHeads " + "[" + oVehicleExpenseHeads.Count + "]";
            foreach (VehicleExpenseHead oVehicleExpenseHead in oVehicleExpenseHeads)
            {
                ListViewItem oItem = lvwExpanseHead.Items.Add(oVehicleExpenseHead.ExpenseHeadCode);
                oItem.SubItems.Add(oVehicleExpenseHead.ExpenseHeadName);
                oItem.Tag = oVehicleExpenseHead;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExpenseHead oFrom = new frmExpenseHead();
            oFrom.ShowDialog();
            DataLoadControl();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwExpanseHead.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Expanse Name to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VehicleExpenseHead oVehicleExpenseHead = (VehicleExpenseHead)lvwExpanseHead.SelectedItems[0].Tag;
            frmExpenseHead oForm = new frmExpenseHead();
            oForm.ShowDialog(oVehicleExpenseHead);
            DataLoadControl();  

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwExpanseHead.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an  Head Name to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            VehicleExpenseHead oVehicleExpenseHead = (VehicleExpenseHead)lvwExpanseHead.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to Delete Expanse Head Name: " + oVehicleExpenseHead.ExpenseHeadCode + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleExpenseHead.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
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

        private void frmExpenseHeads_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}