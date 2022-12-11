
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 24,2012
// Time : 12.00 PM
// Description: Communication against Inquiry for Call Center
// Modify Person And Date:
// </summary>


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
    public partial class frmInquiryCommunication : Form
    {
        Utilities oInquiryCategoryBeforeSale;
        Utilities oInquiryCategoryAfterSale;

        Utilities oGetInquirySalesNoExecuted;

        InquirySaleNoExecuted oInquirySaleNoExecuted;
        InquirySaleNoExecuteds oInquirySaleNoExecuteds;


        public frmInquiryCommunication()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {

            //Inquiry Communication Status
            

            if (this.Tag == null)
                rdbNo_CheckedChanged(null, null);

            lvwSalesNoExecuated.Items.Clear();
            oGetInquirySalesNoExecuted = new Utilities();
            oGetInquirySalesNoExecuted.GetInquirySalesNoExecuted();
            foreach (Utility oUtility in oGetInquirySalesNoExecuted)
            {
                ListViewItem oItem = lvwSalesNoExecuated.Items.Add(oUtility.Satus);
                oItem.Tag = oUtility;
            }

        }

        private void frmInquiryCommunication_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
                LoadCombos();
           

            txtInvoiceNo.Enabled = false;
            dtInvoiceDate.Enabled = false;
            txtProductASG.Enabled = false;
            txtAmount.Enabled = false;
        }


        public void ShowDialog(Inquiry oInquiry)
        {
            this.Tag = oInquiry;
            LoadCombos();
            //cmbCommuStatus.SelectedIndex = oInquiry.CustomerCommuID;
            txtInvoiceNo.Text = oInquiry.InvoiceNo;
            //dtInvoiceDate.Value = Convert.ToDateTime(oInquiry.InvoiceDate.ToString());
            txtProductASG.Text = oInquiry.Product;
            txtAmount.Text = oInquiry.Amount;
            txtCommuRemarks.Text = oInquiry.CommuRemarks;



            if (oInquiry.SalesExecuatedID == 1)
            {
                rdbYes.Checked = true;
                rdbNo.Checked = false;
                rdbYes_CheckedChanged(null, null);
            }
            else
            {
                rdbNo.Checked = true;
                rdbYes.Checked = false;
            }
            oInquirySaleNoExecuteds = new InquirySaleNoExecuteds();
            oInquirySaleNoExecuteds.Refresh(oInquiry.InquiryID);
            for (int i = 0; i < lvwSalesNoExecuated.Items.Count; i++)
            {
                ListViewItem itm = lvwSalesNoExecuated.Items[i];
                Utility oUtility = (Utility)lvwSalesNoExecuated.Items[i].Tag;
                foreach (InquirySaleNoExecuted oInquirySaleNoExecuted in oInquirySaleNoExecuteds)
                {
                    if (oInquirySaleNoExecuted.TypeID == (int)Dictionary.InquiryLvwTypes.InquerySaleNoExecuted)
                        if (oInquirySaleNoExecuted.TypeDetailID == oUtility.SatusId)
                            lvwSalesNoExecuated.Items[i].Checked = true;

                }
            }


            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation
            int Counter = 0;
            if (rdbNo.Checked==true)
            {
                for (int i = 0; i < lvwSalesNoExecuated.Items.Count; i++)
                {
                    if (lvwSalesNoExecuated.Items[i].Checked == true)
                    {
                        Counter = Counter + 1;
                    }

                }
                if (Counter == 0)
                {
                    MessageBox.Show("You have to checked at least a reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            
            
                Inquiry oInquiry = (Inquiry)this.Tag;
                {
                    oInquiry.InvoiceNo = txtInvoiceNo.Text;
                    oInquiry.InvoiceDate = dtInvoiceDate.Value.Date;
                    oInquiry.Product = txtProductASG.Text;
                    oInquiry.Amount = txtAmount.Text;
                    oInquiry.CommuRemarks = txtCommuRemarks.Text;
                    oInquiry.CommuStatus = (int)Dictionary.InquiryCommunicationStatus.True;

                    if (rdbYes.Checked == true)
                    {
                        oInquiry.SalesExecuatedID = (int)Dictionary.InquirySalesExecuated.Yes;
                    }
                    else
                    {
                        oInquiry.SalesExecuatedID = (int)Dictionary.InquirySalesExecuated.No;
                    }
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oInquiry.UpdateCommunication();

                        oInquirySaleNoExecuted = new InquirySaleNoExecuted();
                        oInquirySaleNoExecuted.InquiryID = oInquiry.InquiryID;
                        oInquirySaleNoExecuted.TypeID = (int)Dictionary.InquiryLvwTypes.InquerySaleNoExecuted;
                        oInquirySaleNoExecuted.DeleteInquirySaleNoExecuted();


                        for (int i = 0; i < lvwSalesNoExecuated.Items.Count; i++)
                        {
                            ListViewItem itm = lvwSalesNoExecuated.Items[i];
                            if (lvwSalesNoExecuated.Items[i].Checked == true)
                            {
                                Utility oUtility = (Utility)lvwSalesNoExecuated.Items[i].Tag;
                                oInquirySaleNoExecuted = new InquirySaleNoExecuted();
                                oInquirySaleNoExecuted.InquiryID = oInquiry.InquiryID;
                                oInquirySaleNoExecuted.TypeID = (int)Dictionary.InquiryLvwTypes.InquerySaleNoExecuted;
                                oInquirySaleNoExecuted.TypeDetailID = oUtility.SatusId;
                                oInquirySaleNoExecuted.AddInquirySaleNoExecuted();

                            }
                        }
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
 
        }

        private void rdbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbYes.Checked == true)
            {
                lvwSalesNoExecuated.Items.Clear();
                lvwSalesNoExecuated.Enabled = false;

                txtInvoiceNo.Text = "";
                txtInvoiceNo.Enabled = true;
                dtInvoiceDate.Enabled = true;
                txtProductASG.Text = "";
                txtProductASG.Enabled = true;
                txtAmount.Text = "";
                txtAmount.Enabled = true;
            }
            
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNo.Checked == true)
            {
                lvwSalesNoExecuated.Enabled = true;
                lvwSalesNoExecuated.Items.Clear();
                oGetInquirySalesNoExecuted = new Utilities();
                oGetInquirySalesNoExecuted.GetInquirySalesNoExecuted();
                foreach (Utility oUtility in oGetInquirySalesNoExecuted)
                {
                    ListViewItem oItem = lvwSalesNoExecuated.Items.Add(oUtility.Satus);
                    oItem.Tag = oUtility;
                }

                txtInvoiceNo.Text = "";
                txtInvoiceNo.Enabled = false;
                dtInvoiceDate.Enabled = false;
                txtProductASG.Text = "";
                txtProductASG.Enabled = false;
                txtAmount.Text = "";
                txtAmount.Enabled = false;
            }
           
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}