using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CAC 
{
    public partial class frmCACSubmitQuotation : Form 
    {
        Quotation oQuotation;
        Quotations _oQuotations;
        int _nStatus = 0;
        int _nQuotationId = 0;
        //int _nQuotationStatus = 0;
        QuotationHistory oQuotationHistory;
        public frmCACSubmitQuotation(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(int nQuotationId)
        {
            DBController.Instance.OpenNewConnection();
            //this.Tag = oQuotation;
            _nQuotationId = nQuotationId;
            this.ShowDialog();
        }
        private void frmCACSubmitQuotation_Load(object sender, EventArgs e)
        {
            if (_nStatus == (int)Dictionary.QuotationStatus.Submit)
            {
                btnSave.Text = "Save";
                lblRemarks.Text = "Remarks";
            }
            else if (_nStatus == (int)Dictionary.QuotationStatus.Cancel)
            {
                btnSave.Text = "Cancel";
                lblRemarks.Text = "Reason";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                try
                {
                    oQuotationHistory = new QuotationHistory();
                    oQuotationHistory.QuotationID = _nQuotationId;
                    oQuotationHistory.CreateUserID = Utility.UserId;
                    oQuotationHistory.CreateDate = DateTime.Now;
                    if (_nStatus == (int)Dictionary.QuotationStatus.Submit)
                    {
                        oQuotationHistory.Status = (int)Dictionary.QuotationStatus.Submit; 
                    }
                    else if (_nStatus == (int)Dictionary.QuotationStatus.Cancel)
                    {
                        oQuotationHistory.Status = (int)Dictionary.QuotationStatus.Cancel; 
                    }
                    oQuotationHistory.Remarks = txtRemarks.Text;
                    if (chkIsFollowUp.Checked != true)
                    {
                        oQuotationHistory.Type = (int)Dictionary.QuotationHistoryType.Non_FollowUp;
                    }
                    else
                    {
                        oQuotationHistory.Type = (int)Dictionary.QuotationHistoryType.FollowUp;  
                    }
                    DBController.Instance.BeginNewTransaction();
                    oQuotationHistory.Add();
                    oQuotation = new Quotation();
                    if (chkIsTender.Checked == true)
                    {
                        oQuotation.TenderOpenDate = dtTenderDate.Value;
                        oQuotation.TenderOpenByDate(_nQuotationId);
                    }
                    else if(chkIsFollowUp.Checked == true)
                    {
                        oQuotation.FollowupDate = dtFollowUpDate.Value;
                        oQuotation.FollowUpByDate(_nQuotationId);
                    }
                        oQuotation.SubmitDate = dtDate.Value;
                        oQuotation.SubmitByDate(_nQuotationId, _nStatus);
                    
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Success fully Submit Quotation # " + oQuotationHistory.HistoryID.ToString(), "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}