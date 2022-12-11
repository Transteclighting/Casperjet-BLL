using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmCustomerMappings : Form
    {
        //SPMainCats _oSPMainCats;
        public frmCustomerMappings()
        {
            InitializeComponent();
        }


      
        private void frmCustomerMappings_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            DataLoadControlUnMap();
            //dtFromDate.Value = 01 + "-" + Jan + "-" + DateTime.Today.Year;
            //dtFromDate.Value = "01 - Jan - " + DateTime.Today.Year;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {

            CustomerMappings oCustomerMappings = new CustomerMappings();

            lvwCustomerMapping.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oCustomerMappings.Refresh(txtERPCode.Text, txtCustomerCode.Text, txtCustomerName.Text);
            lblTotalMapping.Text = "Total " + "=" + oCustomerMappings.Count + "";
            foreach (CustomerMapping oCustomerMapping in oCustomerMappings)
            {
                ListViewItem oItem = lvwCustomerMapping.Items.Add(oCustomerMapping.CustomerERPCode.ToString());
                oItem.SubItems.Add(oCustomerMapping.CustomerCode.ToString());
                oItem.SubItems.Add(oCustomerMapping.CustomerName.ToString());

                oItem.Tag = oCustomerMapping;
            }
        }
        private void DataLoadControlUnMap()
        {

            CustomerMappings oCustomerMappings = new CustomerMappings();

            lvwCustomerNonMapping.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oCustomerMappings.RefreshNonMapping(dtFromDate.Value.Date, txtCustomerCodeU.Text, txtCustomerNameU.Text);
            lblTotalAll.Text = "Total " + "=" + oCustomerMappings.Count + "";
            foreach (CustomerMapping oCustomerMapping in oCustomerMappings)
            {
                ListViewItem oItem = lvwCustomerNonMapping.Items.Add(oCustomerMapping.CustomerCode.ToString());
                oItem.SubItems.Add(oCustomerMapping.CustomerName.ToString());
                oItem.Tag = oCustomerMapping;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwCustomerNonMapping.SelectedItems.Count != 0)
            {

                CustomerMapping oCustomerMapping = (CustomerMapping)lvwCustomerNonMapping.SelectedItems[0].Tag;

                frmCustomerMapping oForm = new frmCustomerMapping();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.MinimizeBox = false;
                oForm.Text = "Add Customer Mapping";
                oForm.ShowDialogNonMap(oCustomerMapping);
                DataLoadControl();
                DataLoadControlUnMap();

            }
            else
            {
                MessageBox.Show("Please Select a Row from UnMap portion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwCustomerMapping.SelectedItems.Count != 0)
            {
                CustomerMapping oCustomerMapping = (CustomerMapping)lvwCustomerMapping.SelectedItems[0].Tag;
                
                    if (MessageBox.Show("Do you want to Delete ERP: " + oCustomerMapping.CustomerERPCode + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            oCustomerMapping.CustomerERPCode = oCustomerMapping.CustomerERPCode;
                            oCustomerMapping.Delete();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Delete The Transaction : " + oCustomerMapping.CustomerERPCode, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataLoadControl();
                            DataLoadControlUnMap();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }
                        
                    }

            }
            else
            {
                MessageBox.Show("Please Select a Row from Mapped portion.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DataLoadControl();
            }
        }


        private void lvwCustomerMappings_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCustomerMapping.SelectedItems.Count != 0)
            {

                CustomerMapping oCustomerMapping = (CustomerMapping)lvwCustomerMapping.SelectedItems[0].Tag;

                frmCustomerMapping oForm = new frmCustomerMapping();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Customer Mapping";
                oForm.ShowDialog(oCustomerMapping);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row from Mapped portion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }
        private void lvwCustomerNonMappings_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCustomerNonMapping.SelectedItems.Count != 0)
            {

                CustomerMapping oCustomerMapping = (CustomerMapping)lvwCustomerNonMapping.SelectedItems[0].Tag;

                frmCustomerMapping oForm = new frmCustomerMapping();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Add Customer Mapping";
                oForm.ShowDialogNonMap(oCustomerMapping);
                DataLoadControl();
                DataLoadControlUnMap();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtERPCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtCustomerCodeU_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }

        private void txtCustomerNameU_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }


   
    }
}