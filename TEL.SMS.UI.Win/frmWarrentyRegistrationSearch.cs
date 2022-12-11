using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TEL.SMS.BO;
using TEL.SMS.BO.BE ;
using TEL.SMS.BO.DA;
using TEL.SMS.Reports;

namespace TEL.SMS.UI.Win
{
    public partial class frmWarrentyRegistrationSearch : Form
    {
        private DSWarrantyRegister oDSWarrantyRegister;
        public frmWarrentyRegistrationSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.lvwWarrantyRegister.Items.Clear();
            this.LoadAllData();
            if (rdoAll.Checked == true)
            {
                oDSWarrantyRegister = (DSWarrantyRegister)this.Tag;
                foreach (DSWarrantyRegister.WarrantyRegisterRow ofRow in oDSWarrantyRegister.WarrantyRegister)
                {
                    ofRow.RptEntryDate = ofRow.EntryDate;
                }
                DataRow[] oRow = oDSWarrantyRegister.WarrantyRegister.Select(" RegMode= " + (int)DataType.DataTypeManual);                
                oDSWarrantyRegister = new DSWarrantyRegister();
                oDSWarrantyRegister.Merge(oRow);
                oDSWarrantyRegister.AcceptChanges();
                this.FillDate(oDSWarrantyRegister);                 
            }
            else if (rdoEntryDate.Checked == true)
            {
                oDSWarrantyRegister = (DSWarrantyRegister)this.Tag;
                foreach (DSWarrantyRegister.WarrantyRegisterRow ofRow in oDSWarrantyRegister.WarrantyRegister)
                {
                    ofRow.RptEntryDate = ofRow.EntryDate;
                    ofRow.EntryDate = ofRow.EntryDate.Date;                    
                }
                DataRow[] oRow = oDSWarrantyRegister.WarrantyRegister.Select(" EntryDate >= '" + EDateFrom.Value.Date + "' and  EntryDate<='" + EDateTo.Value.Date + "' and RegMode= " + (int)DataType.DataTypeManual);                    
                oDSWarrantyRegister = new DSWarrantyRegister();
                oDSWarrantyRegister.Merge(oRow);
                oDSWarrantyRegister.AcceptChanges();
                this.FillDate(oDSWarrantyRegister); 
            }
            else if (rdoPurchaseDate.Checked == true)
            {
                oDSWarrantyRegister = (DSWarrantyRegister)this.Tag;
                foreach (DSWarrantyRegister.WarrantyRegisterRow ofRow in oDSWarrantyRegister.WarrantyRegister)
                {
                    ofRow.RptEntryDate = ofRow.EntryDate;
                    ofRow.EntryDate = ofRow.EntryDate.Date;   
                }
                DataRow[] oRow = oDSWarrantyRegister.WarrantyRegister.Select(" PurchaseDate >= '" + PDateFrom.Value.Date + "' and  PurchaseDate<='" + PDateto.Value.Date + "' and RegMode= " + (int)DataType.DataTypeManual);
                oDSWarrantyRegister = new DSWarrantyRegister();
                oDSWarrantyRegister.Merge(oRow);
                oDSWarrantyRegister.AcceptChanges();
                this.FillDate(oDSWarrantyRegister);
            }

        }

        private void frmWarrentyRegistrationSearch_Load(object sender, EventArgs e)
        {
            this.rdoAll_Click(sender, e);               
        }

        private void rdoPurchaseDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoPurchaseDate_Click(object sender, EventArgs e)
        {
            if (rdoPurchaseDate.Checked == true)
            {
                PurGroup.Enabled = true;
                EntryGrp.Enabled = false;                
            }            
        }

        private void rdoEntryDate_Click(object sender, EventArgs e)
        {
            if (rdoEntryDate.Checked == true)
            {                
                EntryGrp.Enabled = true;
                PurGroup.Enabled = false;
            }
        }

        private void rdoAll_Click(object sender, EventArgs e)
        {
            if (rdoAll.Checked == true)
            {
                EntryGrp.Enabled = false;
                PurGroup.Enabled = false;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FillDate(DSWarrantyRegister oDSWarrantyRegister)
        {
            
            foreach (DSWarrantyRegister.WarrantyRegisterRow oWarrantyRegisterRow in oDSWarrantyRegister.WarrantyRegister)
            {
                ListViewItem oItem = lvwWarrantyRegister.Items.Add(oWarrantyRegisterRow.SerialNo);

                if (oWarrantyRegisterRow.IsCustomerCodeNull() == false)
                {
                    oItem.SubItems.Add(oWarrantyRegisterRow.CustomerCode);
                }
                if (oWarrantyRegisterRow.IsCustomerNameNull() == false)
                {
                    oItem.SubItems.Add(oWarrantyRegisterRow.CustomerName);
                }
                if (oWarrantyRegisterRow.IsCustomerAddressNull() == false)
                {
                    oItem.SubItems.Add(oWarrantyRegisterRow.CustomerAddress);
                }
                if (oWarrantyRegisterRow.IsDescriptionNull() == false)
                {
                    oItem.SubItems.Add(oWarrantyRegisterRow.Description.ToString());
                }
                if (oWarrantyRegisterRow.IsProductIDNull() == false)
                {
                    //DAProduct oDAProduct;
                    //oDAProduct = new DAProduct();
                    //DSProduct oDSProducut;
                    //oDSProducut =new DSProduct ();
                    // oDAProduct.GetProduct(oDSProducut, oWarrantyRegisterRow.ProductID);
                    oItem.SubItems.Add(oWarrantyRegisterRow.ProductID.ToString());
                }
                if (oWarrantyRegisterRow.IsPurchaseDateNull() == false)
                {
                    oItem.SubItems.Add(oWarrantyRegisterRow.PurchaseDate.ToString("dd-MMM-yyyy"));
                }
                if (oWarrantyRegisterRow.IsEntryDateNull ()==false )
                {
                    oItem.SubItems.Add(oWarrantyRegisterRow.RptEntryDate.ToString());
                }
                if (oWarrantyRegisterRow.IsUserNameNull() == false)
                {
                    oItem.SubItems.Add(oWarrantyRegisterRow.UserName);
                }
                    oItem.Tag = oWarrantyRegisterRow;                
            }

            this.Text = "WarrantyRegisters " + lvwWarrantyRegister.Items.Count.ToString();

            //Select first item in the list.
            if (lvwWarrantyRegister.Items.Count > 0)
            {
                lvwWarrantyRegister.Items[0].Selected = true;
                lvwWarrantyRegister.Focus();
            }
        }

        private void LoadAllData()
        {
            DSWarrantyRegister oDSWarrantyRegister = new DSWarrantyRegister();
            DAWarrantyRegister oDAWarrantyRegister = new DAWarrantyRegister();
            try
            {
                DBController.Instance.OpenNewConnection();
                oDAWarrantyRegister.GetAllWarrantyRegisters(oDSWarrantyRegister);
                DBController.Instance.CloseConnection();
                this.Tag = oDSWarrantyRegister;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not Load the data from the TelSVR02" + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}