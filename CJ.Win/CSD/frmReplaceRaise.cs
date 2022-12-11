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
    public partial class frmReplaceRaise : Form
    {
        public ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        public ReplaceHistory oReplaceHistory;

        CSDProductReplaces _oCSDProductReplaces;
        CSDProductReplace _oCSDProductReplace;

        public frmReplaceRaise()
        {
            InitializeComponent();
            //LoadCombo();
        }

        /* private void LoadCombo()
         {
             _oCSDProductReplaces = new CSDProductReplaces();
             _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Technical_Supervisor);
             cmbReason.Items.Clear();
             foreach (CSDProductReplace oCSDProductReplace in _oCSDProductReplaces)
             {
                 cmbReason.Items.Add(oCSDProductReplace.ReasonName);
             }
             cmbReason.SelectedIndex = 0;

       

             _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Technical_Manager);
             cmbTecMgrReason.Items.Clear();
             foreach (CSDProductReplace oCSDProductReplace in _oCSDProductReplaces)
             {
                 cmbTecMgrReason.Items.Add(oCSDProductReplace.ReasonName);
             }
             cmbReason.SelectedIndex = 0;

           
             _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Customer_Service_Manager);
             cmbMgrReason.Items.Clear();
             foreach (CSDProductReplace oCSDProductReplace in _oCSDProductReplaces)
             {
                 cmbMgrReason.Items.Add(oCSDProductReplace.ReasonName);
             }
             cmbReason.SelectedIndex = 0;
   
             _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Head_of_Service);
             cmbHeadReason.Items.Clear();
             foreach (CSDProductReplace oCSDProductReplace in _oCSDProductReplaces)
             {
                 cmbHeadReason.Items.Add(oCSDProductReplace.ReasonName);
             }
             cmbReason.SelectedIndex = 0;
         }*/

        public void ShowDialog(Replace oReplace)
        {
            this.Tag = oReplace;
            //LoadCombos();
            this.ctlCSDJob1.Enabled = false;
            ctlCSDJob1.txtCode.Text = oReplace.ReplaceJobFromCassandra.JobNo.ToString();
            ctlCSDJob1.txtDescription.Text = oReplace.ReplaceJobFromCassandra.CustomerName;
            txtInvoiceCashMemo.Text = oReplace.InvoiceCashMemo.ToString();
            dtPurchaseDate.Value = Convert.ToDateTime(oReplace.DateOfPurchase.ToString());
            dtFullWarrantyPeriod.Value = Convert.ToDateTime(oReplace.FullWarrantyPeriod.ToString());
            txtRaiseRemarks.Text = oReplace.ReiseRemarks.ToString();
            dtEDD.Value = Convert.ToDateTime(oReplace.EDD.ToString());

            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            //if (ctlCSDJob1.SelectedReplaceJobFromCassandra == null || ctlCSDJob1.txtCode.Text == "")
            if (ctlCSDJob1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCSDJob1.Focus();
                return false;
            }

            //if (ctlCSDJob1.SelectedReplaceJobFromCassandra == null)
            if (ctlCSDJob1.txtDescription.Text == "")
            {
                MessageBox.Show("Please enter a Valid Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtInvoiceCashMemo.Text == "")
            {
                MessageBox.Show("Please enter Invoice Or CashMemo Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                Replace oReplace = new Replace();
                oReplace.JobID = ctlCSDJob1.SelectedJob.JobID;
                oReplace.Status = (int)Dictionary.ReplaceStatusCriteria.Raise;
                oReplace.InvoiceCashMemo = txtInvoiceCashMemo.Text;
                oReplace.DateOfPurchase = dtPurchaseDate.Value.Date;
                oReplace.FullWarrantyPeriod = dtFullWarrantyPeriod.Value.Date;
                oReplace.ReiseRemarks = txtRaiseRemarks.Text;
                oReplace.EDD = dtEDD.Value.Date;
                oReplace.Type = 1;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oReplace.AddReplace();

                    oReplaceHistory = new ReplaceHistory();
                    oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                    oReplaceHistory.Remarks = txtRaiseRemarks.Text;
                    oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Raise;
                    oReplaceHistory.AddReplaceHistory();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Replace Raise Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Replace oReplace = (Replace)this.Tag;

                {
                    //oReplace.JobID = ctlCSDJob1.SelectedReplaceJobFromCassandra.JobID;
                    oReplace.InvoiceCashMemo = txtInvoiceCashMemo.Text;
                    oReplace.DateOfPurchase = dtPurchaseDate.Value.Date;
                    oReplace.FullWarrantyPeriod = dtFullWarrantyPeriod.Value.Date;
                    oReplace.ReiseRemarks = txtRaiseRemarks.Text;
                    oReplace.EDD = dtEDD.Value.Date;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oReplace.EditReplace();

                        {
                            oReplaceHistory = new ReplaceHistory();
                            oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                            oReplaceHistory.Remarks = this.txtRaiseRemarks.Text;
                            oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Raise;
                            oReplaceHistory.UpdateReplaceHistoryRemarks();
                        }
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Data Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlCSDJob1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCSDJob1.SelectedJob.JobID != null)
            {
                if (ctlCSDJob1.SelectedJob.Status != (int)Dictionary.JobStatus.Replace)
                {
                    MessageBox.Show("Only replace status job can be replace raise ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCSDJob1.txtCode.Text = "";
                }
            }
        }


    }
}