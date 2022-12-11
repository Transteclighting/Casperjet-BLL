// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 11,2011
// Time : 12.00 PM
// Description: order form for Distribution
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Report;
using CJ.Class.Report;
using CJ.Win.Security;

namespace CJ.Win
{
   

    public partial class frmPurchaseRequisitions : Form
    {
        private string _sCompanyCode;
        private int _nStatus;
        Utilities _oUtilitys;

        public frmPurchaseRequisitions()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Close();           
        }
      
        private void frmProductTransactions_Load(object sender, EventArgs e)
        {
            updateSecurity();
            getRequisitionStatus();
            _sCompanyCode = ConfigurationManager.AppSettings["CompanyInfo"].ToString();
            dtFromDate.Value = DateTime.Today.AddDays(-90);
            RefreshData();

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPurchaseRequisition oForm = new frmPurchaseRequisition();
            oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            oForm.MaximizeBox = false;
            oForm.ShowDialog(null);
            RefreshData();
        }        
      
        public void RefreshData()
        {          
            Utility oUtility = _oUtilitys[cmbStatus.SelectedIndex];
            _nStatus = oUtility.SatusId;
           
            PurchaseRequisitions oPurchaseRequisitions = new PurchaseRequisitions();
            lvwStockList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oPurchaseRequisitions.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text, _nStatus);


            foreach (PurchaseRequisition oPurchaseRequisition in oPurchaseRequisitions)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(oPurchaseRequisition.PONo.ToString());
                lstItem.SubItems.Add(oPurchaseRequisition.PINo.ToString());
                lstItem.SubItems.Add(oPurchaseRequisition.LCNo.ToString());              
                lstItem.SubItems.Add(oPurchaseRequisition.Supplier.SupplierName.ToString());
                if (oPurchaseRequisition.Status == (int)Dictionary.PurchaseRequisitionStatus.NOT_APPROVED)
                {
                    lstItem.SubItems.Add("NOT_APPROVED");
                }
                else if (oPurchaseRequisition.Status == (int)Dictionary.PurchaseRequisitionStatus.APPROVED)
                {
                    lstItem.SubItems.Add("APPROVED");
                }
                else if (oPurchaseRequisition.Status == (int)Dictionary.PurchaseRequisitionStatus.LC_OPENED)
                {
                    lstItem.SubItems.Add("LC_OPENED");
                }               
                else if (oPurchaseRequisition.Status == (int)Dictionary.PurchaseRequisitionStatus.RECEIVED)
                {
                    lstItem.SubItems.Add("RECEIVED");
                }
                else
                {
                    lstItem.SubItems.Add("CANCELED");
                }                
                lstItem.SubItems.Add(oPurchaseRequisition.EntryDate.ToString());
                lstItem.SubItems.Add(oPurchaseRequisition.User.Username.ToString());

                lstItem.Tag = oPurchaseRequisition;

            }
            setListViewRowColour();
        }
        private void getRequisitionStatus()
        {
            _oUtilitys = new Utilities();
            cmbStatus.Items.Clear();            
            DBController.Instance.OpenNewConnection();
            _oUtilitys.GetStatus();
            foreach (Utility oUtility in _oUtilitys)
            {
                cmbStatus.Items.Add(oUtility.Satus);
            }
            cmbStatus.SelectedIndex = cmbStatus.Items.Count - 1;
       }

        private void updateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();
            btnPrintTransaction.Enabled = true;
           
            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.ToolStripOrMenu + "'");

            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if (btnEdit.Tag.ToString() == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                   
                    else if (btndelete.Tag.ToString() == sPermissionKey)
                    {
                        btndelete.Enabled = true;
                    }
                    else if (btnPrintTransaction.Tag.ToString() == sPermissionKey)
                    {
                        btnPrintTransaction.Enabled = true;//M1.27
                    }
                }
            }   
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                PurchaseRequisition oPurchaseRequisition = (PurchaseRequisition)lvwStockList.SelectedItems[0].Tag;

                frmPurchaseRequisition oForm = new frmPurchaseRequisition();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oPurchaseRequisition);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void setListViewRowColour()
        {
            if (lvwStockList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwStockList.Items)
                {
                    if (oItem.SubItems[4].Text == Dictionary.PurchaseRequisitionStatus.NOT_APPROVED.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[4].Text == Dictionary.PurchaseRequisitionStatus.APPROVED.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 192, 255);
                    }
                    else if (oItem.SubItems[4].Text == Dictionary.PurchaseRequisitionStatus.LC_OPENED.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(255, 192, 255);
                    }

                    else if (oItem.SubItems[4].Text == Dictionary.PurchaseRequisitionStatus.RECEIVED.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 192);
                    }
                    else
                    {
                        oItem.BackColor = Color.FromArgb(255, 128, 128);
                    }
                }
            }
        }

        private void lvwStockList_DoubleClick(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                PurchaseRequisition oPurchaseRequisition = (PurchaseRequisition)lvwStockList.SelectedItems[0].Tag;

                frmPurchaseRequisition oForm = new frmPurchaseRequisition();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oPurchaseRequisition);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                PurchaseRequisition oPurchaseRequisition = (PurchaseRequisition)lvwStockList.SelectedItems[0].Tag;
                if (oPurchaseRequisition.Status == (int)Dictionary.PurchaseRequisitionStatus.CANCELED)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        CommercialInvoice oCommercialInvoice = new CommercialInvoice();
                        if (oCommercialInvoice.CheckPOID(oPurchaseRequisition.POID))
                            oPurchaseRequisition.Delete();
                        else
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error...Commercial invoice is exist");
                            return;
                        }
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Delete The Transaction : " + oPurchaseRequisition.PONo, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Please Change Status as CANCELED and Then Delete it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   

                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
           
        }

        private void btnPrintTransaction_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                PurchaseRequisition oPurchaseRequisition = (PurchaseRequisition)lvwStockList.SelectedItems[0].Tag;
                rptPurchaseRequisitionReports orptPurchaseRequisitionReports = new rptPurchaseRequisitionReports();

                

                DBController.Instance.BeginNewTransaction();
                orptPurchaseRequisitionReports.Report(oPurchaseRequisition.POID); 
                DBController.Instance.CommitTransaction();
                
                rptPurchaseRequisition oReport = new rptPurchaseRequisition();
                frmPrintPreview oForm = new frmPrintPreview();
                oReport.SetDataSource(orptPurchaseRequisitionReports);
                oReport.SetParameterValue("CompanyName",Utility.CompanyName);
                oReport.SetParameterValue("PrintedBy", Utility.Username.ToString());               
                oForm.ShowDialog(oReport);
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }      

    }
}
     