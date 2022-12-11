using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmShifts : Form
    {
        public frmShifts()
        {
            InitializeComponent();
        }

        private void frmShifts_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            Shifts oShifts = new Shifts();
            lvwShifts.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oShifts.Refresh();
            this.Text = "Shift " + "[" + oShifts.Count + "]";
            foreach (Shift oShift in oShifts)
            {
                ListViewItem oItem = lvwShifts.Items.Add(oShift.ShiftName);
                oItem.SubItems.Add(oShift.LoginTime.ToString("hh:mm tt") );
                oItem.SubItems.Add(oShift.LogoutTime.ToString("hh:mm tt"));
                oShift.ReadDB = true;
                oItem.SubItems.Add(oShift.Company.CompanyCode);
                oItem.Tag = oShift;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmShift oForm = new frmShift();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwShifts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Shift to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Shift oShift = (Shift)lvwShifts.SelectedItems[0].Tag;
            frmShift oForm = new frmShift();
            oForm.ShowDialog(oShift);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Shifts oShifts = new Shifts();
            //oShifts.Refresh();
            //rptShifts oReport = new rptShifts();
            //oReport.SetDataSource(oShifts);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwShifts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Shift to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Shift oShift = (Shift)lvwShifts.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Shift: " + oShift.ShiftName  + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oShift.Delete();
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
    }
}