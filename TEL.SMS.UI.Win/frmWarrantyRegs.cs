using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TEL.SMS.BO;
using TEL.SMS.BO.BE ;
using TEL.SMS.BO.DA;
using TEL.SMS.Reports;


namespace TEL.SMS.UI.Win
{
    public partial class frmWarrantyRegs : Form
    {
        //private DSRptWarrantyAct _oDSRptWarrantyAct;
        public frmWarrantyRegs()
        {
            InitializeComponent();
        }

        private void frmWarrantyRegs_Load(object sender, EventArgs e)
        {
            cboSearchOn.SelectedIndex = 0;
            //refreshList();
        }

        private void refreshList()
        {
            //Get All the mobiles.
            DSWarrantyRegister oDSWarrantyRegister = new DSWarrantyRegister();
            DAWarrantyRegister oDAWarrantyRegister = new DAWarrantyRegister();
            try
            {
                DBController.Instance.OpenNewConnection();
                if (rbtFinal.Checked)
                {
                    oDAWarrantyRegister.GetWarrantyRegisterBySearch(oDSWarrantyRegister, cboSearchOn.Text, txtFind.Text, WarrantyRegMode.Final);
                }
                else if (rbtSMS.Checked)
                {
                    oDAWarrantyRegister.GetWarrantyRegisterBySearch(oDSWarrantyRegister, cboSearchOn.Text, txtFind.Text, WarrantyRegMode.SMS); 
                }
                
                
                DBController.Instance.CloseConnection();
            }
            catch(Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin.", "Server connection",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //Clear and Populate list.
            lvwWarrantyRegister.Items.Clear();
            foreach (DSWarrantyRegister.WarrantyRegisterRow oWarrantyRegisterRow in oDSWarrantyRegister.WarrantyRegister)
            {
                ListViewItem oItem = lvwWarrantyRegister.Items.Add(oWarrantyRegisterRow.SerialNo);
                if (rbtSMS.Checked)
                {
                    oItem.SubItems.Add("");
                    oItem.SubItems.Add("");
                    oItem.SubItems.Add("");
                    oItem.SubItems.Add("");
                    oItem.SubItems.Add("");
                    oItem.SubItems.Add("");
                    oItem.SubItems.Add("");
                }
                else
                {
                    oItem.SubItems.Add(oWarrantyRegisterRow.CustomerCode);
                    oItem.SubItems.Add(oWarrantyRegisterRow.CustomerName);
                    oItem.SubItems.Add(oWarrantyRegisterRow.CustomerAddress);
                    //oItem.SubItems.Add(oWarrantyRegisterRow.TelephoneNo);
                    //oItem.SubItems.Add(oWarrantyRegisterRow.MobileNo);
                    oItem.SubItems.Add(GetProductName(oWarrantyRegisterRow.ProductID.ToString()));
                    oItem.SubItems.Add(oWarrantyRegisterRow.PurchaseDate.ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oWarrantyRegisterRow.EntryDate.ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oWarrantyRegisterRow.UserName);
                    oItem.Tag = oWarrantyRegisterRow;
                }
            }

            this.Text = "WarrantyRegisters " + lvwWarrantyRegister.Items.Count.ToString();
  
            //Select first item in the list.
            if (lvwWarrantyRegister.Items.Count > 0)
            {
                lvwWarrantyRegister.Items[0].Selected = true;
                lvwWarrantyRegister.Focus();
            }
        }

        private string GetProductName(string sCode)
        {
            DSProduct oDSProduct = new DSProduct();
            DAProduct oDAProduct = new DAProduct();

            DBController.Instance.OpenNewConnection();
            oDAProduct.GetProduct(oDSProduct, sCode);
            DBController.Instance.CloseConnection();

            if (oDSProduct.Product.Count > 0)
            {
                return oDSProduct.Product[0].ProductDescription;
            }
            else
            {
                return "";
            }

        }
        private void addNewWarrantyRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmWarrantyReg ofrmWarrantyReg = new frmWarrantyReg();
            //ofrmWarrantyReg.ShowDialog();
            //refreshList();
        }

        private void modifyWarrantyRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If no item is selected from the list.
            if (lvwWarrantyRegister.SelectedItems.Count == 0)
            {
                return;
            }

            DSWarrantyRegister.WarrantyRegisterRow oSelectedWarrantyRegister = (DSWarrantyRegister.WarrantyRegisterRow)lvwWarrantyRegister.SelectedItems[0].Tag;

            DSWarrantyRegister oDSWarrantyRegister = new DSWarrantyRegister();
            DSWarrantyRegister.WarrantyRegisterRow oRow = oDSWarrantyRegister.WarrantyRegister.NewWarrantyRegisterRow();
            oRow.WarrantyRegID = oSelectedWarrantyRegister.WarrantyRegID;
            oDSWarrantyRegister.WarrantyRegister.AddWarrantyRegisterRow(oRow);
            oDSWarrantyRegister.AcceptChanges();

            //frmWarrantyReg ofrmWarrantyReg = new frmWarrantyReg();
            //ofrmWarrantyReg.ShowDialog(oDSWarrantyRegister);
            //refreshList();		

        }

        private void deleteWarrantyRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwWarrantyRegister.SelectedItems.Count == 0)
            {
                return;
            }

            DSWarrantyRegister.WarrantyRegisterRow oSelectedWarrantyRegister = (DSWarrantyRegister.WarrantyRegisterRow)lvwWarrantyRegister.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete warranty no. " + oSelectedWarrantyRegister.SerialNo + "?", "Confirm warranty delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                DSWarrantyRegister oDSWarrantyRegister = new DSWarrantyRegister();
                DAWarrantyRegister oBOWarrantyRegister = new DAWarrantyRegister();
                DSWarrantyRegister.WarrantyRegisterRow oRow = oDSWarrantyRegister.WarrantyRegister.NewWarrantyRegisterRow();
                oRow.WarrantyRegID = oSelectedWarrantyRegister.WarrantyRegID;
                oDSWarrantyRegister.WarrantyRegister.AddWarrantyRegisterRow(oRow);
                oDSWarrantyRegister.AcceptChanges();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBOWarrantyRegister.Delete(oDSWarrantyRegister);
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

        private void lvwWarrantyRegister_DoubleClick(object sender, EventArgs e)
        {
            modifyWarrantyRegisterToolStripMenuItem_Click(sender, e);
        }

        private void lvwWarrantyRegister_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DSWarrantyRegister oDSWarrantyRegister = new DSWarrantyRegister();
            //UI Validation
            if (!Validate()) { return; }

            DAWarrantyRegister oDAWarrantyRegister = new DAWarrantyRegister();

            DSWarrantyRegister.WarrantyRegisterRow oSelectWarrentyRegisterRow = (DSWarrantyRegister.WarrantyRegisterRow)lvwWarrantyRegister.SelectedItems[0].Tag;

            DSWarrantyRegister.WarrantyRegisterRow oDSWarrantyRegisterRow  = oDSWarrantyRegister.WarrantyRegister.NewWarrantyRegisterRow();
            oDSWarrantyRegisterRow.WarrantyRegID = oSelectWarrentyRegisterRow.WarrantyRegID;
            oDSWarrantyRegister.WarrantyRegister.AddWarrantyRegisterRow(oDSWarrantyRegisterRow);
            oDSWarrantyRegister.AcceptChanges(); 

            DSRptWarrantyAct oDSRptWarrantyAct;
            oDSRptWarrantyAct = new DSRptWarrantyAct();
            oDAWarrantyRegister.GetWarrantyRegisterByID(oDSRptWarrantyAct, Convert.ToInt32(oDSWarrantyRegister.WarrantyRegister[0].WarrantyRegID.ToString()));
            foreach (DSRptWarrantyAct.RptWarrantyActRow oDSWarrentyAct in oDSRptWarrantyAct.RptWarrantyAct)
            {
                oDSWarrentyAct.ShowroomName = GetShowroomName(oDSWarrentyAct.SellerName.ToString());
            }
            oDSRptWarrantyAct.AcceptChanges();
            frmReportViewer oReportViewer = new frmReportViewer();
            rptWarrantyActivation oRptWarrantyAct = new rptWarrantyActivation();
            oRptWarrantyAct.SetDataSource(oDSRptWarrantyAct);
            oReportViewer.WarrantyActReportRefersh(oRptWarrantyAct);
            //oReportViewer.ReportRefersh(oRptWarrantyAct);
            oReportViewer.Show();
        }
        private string GetShowroomName(string sCode)
        {
            //DSShowroom oDSShowroom = new DSShowroom();
            DSCustomer oDSCustomer = new DSCustomer();
            DACustomer oDACustomer = new DACustomer();

            DBController.Instance.OpenNewConnection();
            oDACustomer.GetCustomer(oDSCustomer, sCode);  
            //oDACustomer.GetCustomer(oDSCustoemr, sCode);
            DBController.Instance.CloseConnection();

            if (oDSCustomer.Customer.Count > 0)
            {
                return oDSCustomer.Customer[0].CustomerName.ToString();
            }
            else
            {
                return "";
            }

        }
       
    }
}