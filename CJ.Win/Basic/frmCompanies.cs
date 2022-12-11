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
    public partial class frmCompanys : Form
    {
        public frmCompanys()
        {
            InitializeComponent();
        }

        private void frmCompanys_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            Companys oCompanys = new Companys();
            lvwCompanys.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oCompanys.Refresh();
            this.Text = "Company " + "[" + oCompanys.Count + "]";
            foreach (Company oCompany in oCompanys)
            {
                ListViewItem oItem = lvwCompanys.Items.Add(oCompany.CompanyCode);
                oItem.SubItems.Add(oCompany.CompanyName);
                oItem.Tag = oCompany;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCompany oForm = new frmCompany();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCompanys.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Company to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Company oCompany = (Company)lvwCompanys.SelectedItems[0].Tag;
            frmCompany oForm = new frmCompany();
            oForm.ShowDialog(oCompany);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Companys oCompanys = new Companys();
            //oCompanys.Refresh();
            //rptCompanys oReport = new rptCompanys();
            //oReport.SetDataSource(oCompanys);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwCompanys.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Company to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Company oCompany = (Company)lvwCompanys.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Company: " + oCompany.CompanyCode  + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCompany.Delete();
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